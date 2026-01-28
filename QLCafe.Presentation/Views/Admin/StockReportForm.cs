using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLCafe.Domain.DTOs;
using QLCafe.Application.Interfaces;
using QLCafe.Application.Services;

namespace QLCafe.Presentation.Views.Admin
{
    public partial class StockReportForm : Form
    {
        private IBillService _billService;
        private List<BillHistoryDto> _allBills;
        private List<BillHistoryDto> _filteredBills;

        public StockReportForm()
        {
            InitializeComponent();
            InitializeService();
            InitializeData();
            SetupEventHandlers();
        }

        private void InitializeService()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QLCafeConnection"].ConnectionString;
            _billService = new BillService(connectionString);
        }

        private void InitializeData()
        {
            // Set default dates
            dtpFromDate.Value = DateTime.Now.AddDays(-7);
            dtpToDate.Value = DateTime.Now;

            // Load table names into combo box
            LoadTableNames();

            // Set default combo box selections
            cboTable.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;

            // Setup DataGridView
            dgvTableHistory.AutoGenerateColumns = false;
            dgvTableHistory.CellPainting += DgvTableHistory_CellPainting;

            // Load initial data
            LoadBillHistory();
        }

        private void LoadTableNames()
        {
            try
            {
                cboTable.Items.Clear();
                cboTable.Items.Add("Tất cả");

                var tableNames = _billService.GetAllTableNames();
                foreach (var tableName in tableNames)
                {
                    cboTable.Items.Add(tableName);
                }

                cboTable.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách bàn: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupEventHandlers()
        {
            btnFilter.Click += BtnFilter_Click;
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            LoadBillHistory();
        }

        private void LoadBillHistory()
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

                // Get table filter
                int? tableId = null;
                string selectedTable = cboTable.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedTable) && selectedTable != "Tất cả")
                {
                    // Find table ID by name (we'll need to modify this if we want to filter by table)
                    // For now, we'll filter by table name after getting all data
                }

                // Get status filter
                int? statusFilter = null;
                string selectedStatus = cboStatus.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedStatus))
                {
                    switch (selectedStatus)
                    {
                        case "Hoàn thành":
                            statusFilter = 1;
                            break;
                        case "Đang sử dụng":
                            statusFilter = 0;
                            break;
                        case "Hủy":
                            statusFilter = -1;
                            break;
                        default: // "Tất cả"
                            statusFilter = null;
                            break;
                    }
                }

                // Load data from database
                _allBills = _billService.GetBillHistory(fromDate, toDate, tableId, statusFilter);

                // Apply table name filter if needed
                if (!string.IsNullOrEmpty(selectedTable) && selectedTable != "Tất cả")
                {
                    _filteredBills = _allBills.Where(b => b.TableName == selectedTable).ToList();
                }
                else
                {
                    _filteredBills = _allBills;
                }

                // Display data
                DisplayBillHistory(_filteredBills);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải lịch sử: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayBillHistory(List<BillHistoryDto> bills)
        {
            dgvTableHistory.Rows.Clear();

            if (bills == null || bills.Count == 0)
            {
                return;
            }

            foreach (var bill in bills)
            {
                string orderDate = bill.OrderDate.ToString("dd/MM/yyyy HH:mm");
                string totalAmount = bill.TotalAmount.ToString("N0") + " đ";
                
                // Get status text from StatusCode to ensure correct Vietnamese display
                string statusDisplay = GetStatusText(bill.StatusCode);

                dgvTableHistory.Rows.Add(
                    bill.BillCode,
                    bill.TableName,
                    orderDate,
                    totalAmount,
                    bill.EmployeeName,
                    statusDisplay
                );
            }
        }

        private string GetStatusText(int statusCode)
        {
            switch (statusCode)
            {
                case 0:
                    return "Đang sử dụng";
                case 1:
                    return "Hoàn thành";
                case -1:
                    return "Hủy";
                default:
                    return "Không xác định";
            }
        }

        private string NormalizeStatus(string status)
        {
            if (string.IsNullOrEmpty(status))
                return status;

            // Normalize common variations or corrupted text
            string normalized = status.Trim();
            
            // Map based on StatusCode if status text is corrupted
            if (normalized.Contains("?") || normalized.Length < 3)
            {
                // Return default based on common patterns
                return normalized;
            }

            // Ensure proper Vietnamese text
            switch (normalized)
            {
                case "Hoàn thành":
                case "Hoan thanh":
                    return "Hoàn thành";
                case "Đang sử dụng":
                case "Dang su dung":
                    return "Đang sử dụng";
                case "Hủy":
                case "Huy":
                    return "Hủy";
                default:
                    return normalized;
            }
        }

        private void DgvTableHistory_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Paint header
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                e.Handled = true;
                using (SolidBrush headerBrush = new SolidBrush(Color.FromArgb(139, 69, 19)))
                {
                    e.Graphics.FillRectangle(headerBrush, e.CellBounds);
                }

                using (Pen borderPen = new Pen(Color.FromArgb(100, 50, 10)))
                {
                    e.Graphics.DrawLine(borderPen, e.CellBounds.Left, e.CellBounds.Bottom - 1,
                        e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }

                string headerText = Convert.ToString(e.FormattedValue);
                e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                using (Font headerFont = new Font("Segoe UI", 11f, FontStyle.Bold))
                using (SolidBrush textBrush = new SolidBrush(Color.White))
                {
                    StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    Rectangle textRect = new Rectangle(e.CellBounds.X, e.CellBounds.Y,
                        e.CellBounds.Width, e.CellBounds.Height);
                    e.Graphics.DrawString(headerText, headerFont, textBrush, textRect, sf);
                }
                return;
            }

            // Paint status column with colored pills
            if (e.RowIndex >= 0 && dgvTableHistory.Columns[e.ColumnIndex].Name == "colStatus" && e.Value != null)
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);

                string status = e.Value.ToString();
                Color bgColor, textColor;

                switch (status)
                {
                    case "Hoàn thành":
                        bgColor = Color.FromArgb(214, 245, 222);
                        textColor = Color.FromArgb(24, 163, 78);
                        break;
                    case "Hủy":
                        bgColor = Color.FromArgb(255, 220, 220);
                        textColor = Color.FromArgb(200, 50, 50);
                        break;
                    case "Đang sử dụng":
                        bgColor = Color.FromArgb(255, 243, 205);
                        textColor = Color.FromArgb(184, 134, 11);
                        break;
                    default:
                        bgColor = Color.LightGray;
                        textColor = Color.Gray;
                        break;
                }

                Rectangle pillRect = new Rectangle(
                    e.CellBounds.X + 15,
                    e.CellBounds.Y + 10,
                    e.CellBounds.Width - 30,
                    e.CellBounds.Height - 20
                );

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                
                using (GraphicsPath path = GetRoundedRectangle(pillRect, 12))
                using (SolidBrush bgBrush = new SolidBrush(bgColor))
                using (SolidBrush textBrush = new SolidBrush(textColor))
                using (Font font = new Font("Segoe UI", 9.5f, FontStyle.Bold))
                {
                    e.Graphics.FillPath(bgBrush, path);
                    StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    e.Graphics.DrawString(status, font, textBrush, pillRect, sf);
                }

                e.Paint(e.CellBounds, DataGridViewPaintParts.Border);
            }
        }

        private GraphicsPath GetRoundedRectangle(Rectangle bounds, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            Rectangle arc = new Rectangle(bounds.Location, new Size(diameter, diameter));
            path.AddArc(arc, 180, 90);

            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        private void lblFromDate_Click(object sender, EventArgs e)
        {

        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblToDate_Click(object sender, EventArgs e)
        {

        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblTable_Click(object sender, EventArgs e)
        {

        }

        private void cboTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click_1(object sender, EventArgs e)
        {

        }

        private void pnlFilter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlData_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
