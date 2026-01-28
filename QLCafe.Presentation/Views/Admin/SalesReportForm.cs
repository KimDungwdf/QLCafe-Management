using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLCafe.Application.Interfaces;
using QLCafe.Application.Services;
using QLCafe.Domain.DTOs;

namespace QLCafe.Presentation.Views.Admin
{
    public partial class SalesReportForm : Form
    {
        private ISalesReportService _salesReportService;
        private List<DailyRevenueDto> _dailyRevenueData;

        public SalesReportForm()
        {
            InitializeComponent();
            InitializeService();
            InitializeData();
            SetupDataGridView();
        }

        private void InitializeService()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QLCafeConnection"].ConnectionString;
            _salesReportService = new SalesReportService(connectionString);
        }

        private void InitializeData()
        {
            // Set default date range (current month)
            dtpFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpToDate.Value = DateTime.Now;

            // Set default report type
            cboReportType.SelectedIndex = 0;

            // Load initial report
            LoadReport();
        }

        private void SetupDataGridView()
        {
            dgvTopProducts.Columns.Clear();
            dgvTopProducts.AutoGenerateColumns = false;

            // Rank column
            DataGridViewTextBoxColumn colRank = new DataGridViewTextBoxColumn
            {
                Name = "colRank",
                HeaderText = "Hạng",
                Width = 80,
                DataPropertyName = "Rank"
            };
            dgvTopProducts.Columns.Add(colRank);

            // Product Name column
            DataGridViewTextBoxColumn colProductName = new DataGridViewTextBoxColumn
            {
                Name = "colProductName",
                HeaderText = "Tên món",
                Width = 300,
                DataPropertyName = "ProductName"
            };
            dgvTopProducts.Columns.Add(colProductName);

            // Quantity Sold column
            DataGridViewTextBoxColumn colQuantity = new DataGridViewTextBoxColumn
            {
                Name = "colQuantity",
                HeaderText = "Số lượng bán",
                Width = 150,
                DataPropertyName = "QuantitySold"
            };
            dgvTopProducts.Columns.Add(colQuantity);

            // Revenue column
            DataGridViewTextBoxColumn colRevenue = new DataGridViewTextBoxColumn
            {
                Name = "colRevenue",
                HeaderText = "Doanh thu",
                Width = 200,
                DataPropertyName = "Revenue"
            };
            dgvTopProducts.Columns.Add(colRevenue);

            // Percentage column
            DataGridViewTextBoxColumn colPercentage = new DataGridViewTextBoxColumn
            {
                Name = "colPercentage",
                HeaderText = "Tỷ trọng",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "Percentage"
            };
            dgvTopProducts.Columns.Add(colPercentage);

            // Format revenue column
            dgvTopProducts.CellFormatting += DgvTopProducts_CellFormatting;
        }

        private void DgvTopProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTopProducts.Columns[e.ColumnIndex].Name == "colRevenue" && e.Value != null)
            {
                decimal value = Convert.ToDecimal(e.Value);
                e.Value = value.ToString("N0") + " đ";
                e.FormattingApplied = true;
            }
            else if (dgvTopProducts.Columns[e.ColumnIndex].Name == "colPercentage" && e.Value != null)
            {
                decimal value = Convert.ToDecimal(e.Value);
                e.Value = value.ToString("F1") + "%";
                e.FormattingApplied = true;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date;

                // Validate date range
                if (fromDate > toDate)
                {
                    MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Load summary data
                var reportData = _salesReportService.GetSalesReport(fromDate, toDate);
                DisplaySummary(reportData);

                // Load daily revenue data
                _dailyRevenueData = _salesReportService.GetDailyRevenue(fromDate, toDate);
                pnlChartContent.Invalidate(); // Trigger repaint

                // Load top products
                var topProducts = _salesReportService.GetTopProducts(fromDate, toDate, 10);
                DisplayTopProducts(topProducts);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải báo cáo: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplaySummary(SalesReportDto report)
        {
            // Total Revenue
            lblTotalRevenueValue.Text = report.TotalRevenue.ToString("N0") + " đ";
            DisplayChangeLabel(lblTotalRevenueChange, report.RevenueChangePercent);

            // Total Orders (NOTE: Not showing cancelled orders as requested)
            lblTotalOrdersValue.Text = report.TotalOrders.ToString("N0");
            DisplayChangeLabel(lblTotalOrdersChange, report.OrderChangePercent);

            // Average Order Value
            lblAverageOrderValue.Text = report.AverageOrderValue.ToString("N0") + " đ";
            decimal avgChange = report.PreviousPeriodRevenue > 0 && report.PreviousPeriodOrders > 0
                ? ((report.AverageOrderValue - (report.PreviousPeriodRevenue / report.PreviousPeriodOrders))
                    / (report.PreviousPeriodRevenue / report.PreviousPeriodOrders)) * 100
                : 0;
            DisplayChangeLabel(lblAverageOrderChange, avgChange);
        }

        private void DisplayChangeLabel(Label label, decimal changePercent)
        {
            string arrow = changePercent >= 0 ? "↑" : "↓";
            label.Text = $"{arrow} {Math.Abs(changePercent):F1}% so với tháng trước";
            label.ForeColor = changePercent >= 0 ? Color.Green : Color.Red;
        }

        private void DisplayTopProducts(List<TopProductDto> products)
        {
            dgvTopProducts.DataSource = null;
            dgvTopProducts.DataSource = products;
        }

        private void pnlChartContent_Paint(object sender, PaintEventArgs e)
        {
            if (_dailyRevenueData == null || _dailyRevenueData.Count == 0)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Chart dimensions
            int leftMargin = 60;
            int rightMargin = 30;
            int topMargin = 20;
            int bottomMargin = 40;
            int chartWidth = pnlChartContent.Width - leftMargin - rightMargin;
            int chartHeight = pnlChartContent.Height - topMargin - bottomMargin;

            if (chartWidth <= 0 || chartHeight <= 0)
                return;

            // Find max revenue for scaling
            decimal maxRevenue = _dailyRevenueData.Max(d => d.Revenue);
            if (maxRevenue == 0)
                maxRevenue = 1;

            // Calculate bar width and spacing
            int barCount = _dailyRevenueData.Count;
            float barWidth = (float)chartWidth / barCount * 0.7f;
            float spacing = (float)chartWidth / barCount;

            // Draw bars
            for (int i = 0; i < _dailyRevenueData.Count; i++)
            {
                var data = _dailyRevenueData[i];
                float barHeight = (float)(data.Revenue / maxRevenue * chartHeight);
                float x = leftMargin + i * spacing + (spacing - barWidth) / 2;
                float y = topMargin + chartHeight - barHeight;

                // Draw bar
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(139, 69, 19)))
                {
                    g.FillRectangle(brush, x, y, barWidth, barHeight);
                }

                // Draw date label
                using (Font font = new Font("Segoe UI", 7.5f))
                using (SolidBrush textBrush = new SolidBrush(Color.Gray))
                {
                    StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Near
                    };
                    string dateLabel = data.Date.ToString("dd/MM");
                    g.DrawString(dateLabel, font, textBrush,
                        x + barWidth / 2,
                        topMargin + chartHeight + 5,
                        sf);
                }
            }

            // Draw Y-axis labels
            using (Font font = new Font("Segoe UI", 8f))
            using (SolidBrush textBrush = new SolidBrush(Color.Gray))
            {
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Far,
                    LineAlignment = StringAlignment.Center
                };

                for (int i = 0; i <= 5; i++)
                {
                    decimal value = maxRevenue * i / 5;
                    float y = topMargin + chartHeight - (chartHeight * i / 5);
                    string label = (value / 1000).ToString("N0") + "K";
                    g.DrawString(label, font, textBrush, leftMargin - 10, y, sf);

                    // Draw grid line
                    using (Pen pen = new Pen(Color.FromArgb(230, 230, 230)))
                    {
                        g.DrawLine(pen, leftMargin, y, leftMargin + chartWidth, y);
                    }
                }
            }

            // Draw legend (moved to bottom)
            using (Font font = new Font("Segoe UI", 9f))
            using (SolidBrush textBrush = new SolidBrush(Color.Gray))
            using (SolidBrush boxBrush = new SolidBrush(Color.FromArgb(139, 69, 19)))
            {
                int legendX = leftMargin + (chartWidth / 2) - 60; // Center horizontally
                int legendY = topMargin + chartHeight + 25; // Below date labels
                g.FillRectangle(boxBrush, legendX, legendY, 15, 15);
                g.DrawString("Doanh thu (VNĐ)", font, textBrush, legendX + 20, legendY);
            }
        }
    }
}
