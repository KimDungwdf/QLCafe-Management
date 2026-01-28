using QLCafe.Presentation.Components;
using System.Drawing;
using System.Windows.Forms;

namespace QLCafe.Presentation.Views.Admin
{
    partial class SalesReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label lblFromDate;
        private Label lblToDate;
        private Label lblReportType;
        private DateTimePicker dtpFromDate;
        private DateTimePicker dtpToDate;
        private ComboBox cboReportType;
        private RoundButton btnGenerate;

        // Summary cards
        private RoundedPanel pnlTotalRevenue;
        private RoundedPanel pnlTotalOrders;
        private RoundedPanel pnlAverageOrder;

        private Label lblTotalRevenueTitle;
        private Label lblTotalRevenueValue;
        private Label lblTotalRevenueChange;

        private Label lblTotalOrdersTitle;
        private Label lblTotalOrdersValue;
        private Label lblTotalOrdersChange;

        private Label lblAverageOrderTitle;
        private Label lblAverageOrderValue;
        private Label lblAverageOrderChange;

        // Chart and table panels
        private RoundedPanel pnlChart;
        private RoundedPanel pnlTopProducts;

        private Label lblChartTitle;
        private Panel pnlChartContent;

        private Label lblTopProductsTitle;
        private DataGridView dgvTopProducts;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            this.lblReportType = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.cboReportType = new System.Windows.Forms.ComboBox();
            this.btnGenerate = new QLCafe.Presentation.Components.RoundButton();
            this.pnlTotalRevenue = new QLCafe.Presentation.Components.RoundedPanel();
            this.lblTotalRevenueTitle = new System.Windows.Forms.Label();
            this.lblTotalRevenueValue = new System.Windows.Forms.Label();
            this.lblTotalRevenueChange = new System.Windows.Forms.Label();
            this.pnlTotalOrders = new QLCafe.Presentation.Components.RoundedPanel();
            this.lblTotalOrdersTitle = new System.Windows.Forms.Label();
            this.lblTotalOrdersValue = new System.Windows.Forms.Label();
            this.lblTotalOrdersChange = new System.Windows.Forms.Label();
            this.pnlAverageOrder = new QLCafe.Presentation.Components.RoundedPanel();
            this.lblAverageOrderTitle = new System.Windows.Forms.Label();
            this.lblAverageOrderValue = new System.Windows.Forms.Label();
            this.lblAverageOrderChange = new System.Windows.Forms.Label();
            this.pnlChart = new QLCafe.Presentation.Components.RoundedPanel();
            this.lblChartTitle = new System.Windows.Forms.Label();
            this.pnlChartContent = new System.Windows.Forms.Panel();
            this.pnlTopProducts = new QLCafe.Presentation.Components.RoundedPanel();
            this.lblTopProductsTitle = new System.Windows.Forms.Label();
            this.dgvTopProducts = new System.Windows.Forms.DataGridView();
            this.pnlTotalRevenue.SuspendLayout();
            this.pnlTotalOrders.SuspendLayout();
            this.pnlAverageOrder.SuspendLayout();
            this.pnlChart.SuspendLayout();
            this.pnlTopProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFromDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(67)))), ((int)(((byte)(33)))));
            this.lblFromDate.Location = new System.Drawing.Point(75, 5);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(75, 23);
            this.lblFromDate.TabIndex = 0;
            this.lblFromDate.Text = "Từ ngày";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblToDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(67)))), ((int)(((byte)(33)))));
            this.lblToDate.Location = new System.Drawing.Point(280, 5);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(86, 23);
            this.lblToDate.TabIndex = 2;
            this.lblToDate.Text = "Đến ngày";
            // 
            // lblReportType
            // 
            this.lblReportType.AutoSize = true;
            this.lblReportType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblReportType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(67)))), ((int)(((byte)(33)))));
            this.lblReportType.Location = new System.Drawing.Point(490, 5);
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.Size = new System.Drawing.Size(110, 23);
            this.lblReportType.TabIndex = 4;
            this.lblReportType.Text = "Loại báo cáo";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CalendarFont = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(75, 30);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(180, 32);
            this.dtpFromDate.TabIndex = 1;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CalendarFont = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(280, 30);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(180, 32);
            this.dtpToDate.TabIndex = 3;
            // 
            // cboReportType
            // 
            this.cboReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReportType.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboReportType.FormattingEnabled = true;
            this.cboReportType.Items.AddRange(new object[] {
            "Theo ngày",
            "Theo tuần",
            "Theo tháng"});
            this.cboReportType.Location = new System.Drawing.Point(490, 30);
            this.cboReportType.Name = "cboReportType";
            this.cboReportType.Size = new System.Drawing.Size(180, 33);
            this.cboReportType.TabIndex = 5;
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(69)))), ((int)(((byte)(19)))));
            this.btnGenerate.BorderRadius = 10;
            this.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(700, 25);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(160, 42);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "Xuất báo cáo";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // pnlTotalRevenue
            // 
            this.pnlTotalRevenue.BackColor = System.Drawing.Color.White;
            this.pnlTotalRevenue.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.pnlTotalRevenue.BorderThickness = 2;
            this.pnlTotalRevenue.Controls.Add(this.lblTotalRevenueTitle);
            this.pnlTotalRevenue.Controls.Add(this.lblTotalRevenueValue);
            this.pnlTotalRevenue.Controls.Add(this.lblTotalRevenueChange);
            this.pnlTotalRevenue.CornerRadius = 15;
            this.pnlTotalRevenue.Location = new System.Drawing.Point(40, 90);
            this.pnlTotalRevenue.Name = "pnlTotalRevenue";
            this.pnlTotalRevenue.Padding = new System.Windows.Forms.Padding(20);
            this.pnlTotalRevenue.Size = new System.Drawing.Size(330, 130);
            this.pnlTotalRevenue.TabIndex = 7;
            // 
            // lblTotalRevenueTitle
            // 
            this.lblTotalRevenueTitle.AutoSize = true;
            this.lblTotalRevenueTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalRevenueTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalRevenueTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTotalRevenueTitle.Name = "lblTotalRevenueTitle";
            this.lblTotalRevenueTitle.Size = new System.Drawing.Size(134, 23);
            this.lblTotalRevenueTitle.TabIndex = 0;
            this.lblTotalRevenueTitle.Text = "Tổng doanh thu";
            // 
            // lblTotalRevenueValue
            // 
            this.lblTotalRevenueValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenueValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(69)))), ((int)(((byte)(19)))));
            this.lblTotalRevenueValue.Location = new System.Drawing.Point(20, 50);
            this.lblTotalRevenueValue.Name = "lblTotalRevenueValue";
            this.lblTotalRevenueValue.Size = new System.Drawing.Size(290, 40);
            this.lblTotalRevenueValue.TabIndex = 1;
            this.lblTotalRevenueValue.Text = "0 đ";
            // 
            // lblTotalRevenueChange
            // 
            this.lblTotalRevenueChange.AutoSize = true;
            this.lblTotalRevenueChange.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalRevenueChange.ForeColor = System.Drawing.Color.Green;
            this.lblTotalRevenueChange.Location = new System.Drawing.Point(20, 95);
            this.lblTotalRevenueChange.Name = "lblTotalRevenueChange";
            this.lblTotalRevenueChange.Size = new System.Drawing.Size(164, 20);
            this.lblTotalRevenueChange.TabIndex = 2;
            this.lblTotalRevenueChange.Text = "↑ 0% so với tháng trước";
            // 
            // pnlTotalOrders
            // 
            this.pnlTotalOrders.BackColor = System.Drawing.Color.White;
            this.pnlTotalOrders.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.pnlTotalOrders.BorderThickness = 2;
            this.pnlTotalOrders.Controls.Add(this.lblTotalOrdersTitle);
            this.pnlTotalOrders.Controls.Add(this.lblTotalOrdersValue);
            this.pnlTotalOrders.Controls.Add(this.lblTotalOrdersChange);
            this.pnlTotalOrders.CornerRadius = 15;
            this.pnlTotalOrders.Location = new System.Drawing.Point(390, 90);
            this.pnlTotalOrders.Name = "pnlTotalOrders";
            this.pnlTotalOrders.Padding = new System.Windows.Forms.Padding(20);
            this.pnlTotalOrders.Size = new System.Drawing.Size(330, 130);
            this.pnlTotalOrders.TabIndex = 8;
            // 
            // lblTotalOrdersTitle
            // 
            this.lblTotalOrdersTitle.AutoSize = true;
            this.lblTotalOrdersTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalOrdersTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalOrdersTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTotalOrdersTitle.Name = "lblTotalOrdersTitle";
            this.lblTotalOrdersTitle.Size = new System.Drawing.Size(108, 23);
            this.lblTotalOrdersTitle.TabIndex = 0;
            this.lblTotalOrdersTitle.Text = "Số đơn hàng";
            // 
            // lblTotalOrdersValue
            // 
            this.lblTotalOrdersValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalOrdersValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(69)))), ((int)(((byte)(19)))));
            this.lblTotalOrdersValue.Location = new System.Drawing.Point(20, 50);
            this.lblTotalOrdersValue.Name = "lblTotalOrdersValue";
            this.lblTotalOrdersValue.Size = new System.Drawing.Size(290, 40);
            this.lblTotalOrdersValue.TabIndex = 1;
            this.lblTotalOrdersValue.Text = "0";
            // 
            // lblTotalOrdersChange
            // 
            this.lblTotalOrdersChange.AutoSize = true;
            this.lblTotalOrdersChange.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalOrdersChange.ForeColor = System.Drawing.Color.Green;
            this.lblTotalOrdersChange.Location = new System.Drawing.Point(20, 95);
            this.lblTotalOrdersChange.Name = "lblTotalOrdersChange";
            this.lblTotalOrdersChange.Size = new System.Drawing.Size(164, 20);
            this.lblTotalOrdersChange.TabIndex = 2;
            this.lblTotalOrdersChange.Text = "↑ 0% so với tháng trước";
            // 
            // pnlAverageOrder
            // 
            this.pnlAverageOrder.BackColor = System.Drawing.Color.White;
            this.pnlAverageOrder.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.pnlAverageOrder.BorderThickness = 2;
            this.pnlAverageOrder.Controls.Add(this.lblAverageOrderTitle);
            this.pnlAverageOrder.Controls.Add(this.lblAverageOrderValue);
            this.pnlAverageOrder.Controls.Add(this.lblAverageOrderChange);
            this.pnlAverageOrder.CornerRadius = 15;
            this.pnlAverageOrder.Location = new System.Drawing.Point(740, 90);
            this.pnlAverageOrder.Name = "pnlAverageOrder";
            this.pnlAverageOrder.Padding = new System.Windows.Forms.Padding(20);
            this.pnlAverageOrder.Size = new System.Drawing.Size(330, 130);
            this.pnlAverageOrder.TabIndex = 9;
            // 
            // lblAverageOrderTitle
            // 
            this.lblAverageOrderTitle.AutoSize = true;
            this.lblAverageOrderTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAverageOrderTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblAverageOrderTitle.Location = new System.Drawing.Point(20, 20);
            this.lblAverageOrderTitle.Name = "lblAverageOrderTitle";
            this.lblAverageOrderTitle.Size = new System.Drawing.Size(179, 23);
            this.lblAverageOrderTitle.TabIndex = 0;
            this.lblAverageOrderTitle.Text = "Giá trị trung bình/đơn";
            // 
            // lblAverageOrderValue
            // 
            this.lblAverageOrderValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblAverageOrderValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(69)))), ((int)(((byte)(19)))));
            this.lblAverageOrderValue.Location = new System.Drawing.Point(20, 50);
            this.lblAverageOrderValue.Name = "lblAverageOrderValue";
            this.lblAverageOrderValue.Size = new System.Drawing.Size(290, 40);
            this.lblAverageOrderValue.TabIndex = 1;
            this.lblAverageOrderValue.Text = "0 đ";
            // 
            // lblAverageOrderChange
            // 
            this.lblAverageOrderChange.AutoSize = true;
            this.lblAverageOrderChange.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAverageOrderChange.ForeColor = System.Drawing.Color.Green;
            this.lblAverageOrderChange.Location = new System.Drawing.Point(20, 95);
            this.lblAverageOrderChange.Name = "lblAverageOrderChange";
            this.lblAverageOrderChange.Size = new System.Drawing.Size(164, 20);
            this.lblAverageOrderChange.TabIndex = 2;
            this.lblAverageOrderChange.Text = "↑ 0% so với tháng trước";
            // 
            // pnlChart
            // 
            this.pnlChart.BackColor = System.Drawing.Color.White;
            this.pnlChart.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.pnlChart.BorderThickness = 2;
            this.pnlChart.Controls.Add(this.lblChartTitle);
            this.pnlChart.Controls.Add(this.pnlChartContent);
            this.pnlChart.CornerRadius = 15;
            this.pnlChart.Location = new System.Drawing.Point(40, 240);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Padding = new System.Windows.Forms.Padding(20);
            this.pnlChart.Size = new System.Drawing.Size(1151, 300);
            this.pnlChart.TabIndex = 10;
            // 
            // lblChartTitle
            // 
            this.lblChartTitle.AutoSize = true;
            this.lblChartTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblChartTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(67)))), ((int)(((byte)(33)))));
            this.lblChartTitle.Location = new System.Drawing.Point(20, 20);
            this.lblChartTitle.Name = "lblChartTitle";
            this.lblChartTitle.Size = new System.Drawing.Size(313, 30);
            this.lblChartTitle.TabIndex = 0;
            this.lblChartTitle.Text = "Biểu đồ doanh thu theo ngày";
            // 
            // pnlChartContent
            // 
            this.pnlChartContent.Location = new System.Drawing.Point(20, 60);
            this.pnlChartContent.Name = "pnlChartContent";
            this.pnlChartContent.Size = new System.Drawing.Size(1105, 220);
            this.pnlChartContent.TabIndex = 1;
            this.pnlChartContent.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlChartContent_Paint);
            // 
            // pnlTopProducts
            // 
            this.pnlTopProducts.BackColor = System.Drawing.Color.White;
            this.pnlTopProducts.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.pnlTopProducts.BorderThickness = 2;
            this.pnlTopProducts.Controls.Add(this.lblTopProductsTitle);
            this.pnlTopProducts.Controls.Add(this.dgvTopProducts);
            this.pnlTopProducts.CornerRadius = 15;
            this.pnlTopProducts.Location = new System.Drawing.Point(40, 560);
            this.pnlTopProducts.Name = "pnlTopProducts";
            this.pnlTopProducts.Padding = new System.Windows.Forms.Padding(20);
            this.pnlTopProducts.Size = new System.Drawing.Size(1151, 350);
            this.pnlTopProducts.TabIndex = 11;
            // 
            // lblTopProductsTitle
            // 
            this.lblTopProductsTitle.AutoSize = true;
            this.lblTopProductsTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTopProductsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(67)))), ((int)(((byte)(33)))));
            this.lblTopProductsTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTopProductsTitle.Name = "lblTopProductsTitle";
            this.lblTopProductsTitle.Size = new System.Drawing.Size(287, 30);
            this.lblTopProductsTitle.TabIndex = 0;
            this.lblTopProductsTitle.Text = "Top 10 món bán chạy nhất";
            // 
            // dgvTopProducts
            // 
            this.dgvTopProducts.AllowUserToAddRows = false;
            this.dgvTopProducts.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.dgvTopProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTopProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTopProducts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTopProducts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(69)))), ((int)(((byte)(19)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(69)))), ((int)(((byte)(19)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTopProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTopProducts.ColumnHeadersHeight = 46;
            this.dgvTopProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTopProducts.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTopProducts.EnableHeadersVisualStyles = false;
            this.dgvTopProducts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(225)))), ((int)(((byte)(220)))));
            this.dgvTopProducts.Location = new System.Drawing.Point(20, 60);
            this.dgvTopProducts.MultiSelect = false;
            this.dgvTopProducts.Name = "dgvTopProducts";
            this.dgvTopProducts.ReadOnly = true;
            this.dgvTopProducts.RowHeadersVisible = false;
            this.dgvTopProducts.RowHeadersWidth = 51;
            this.dgvTopProducts.RowTemplate.Height = 45;
            this.dgvTopProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopProducts.Size = new System.Drawing.Size(1105, 270);
            this.dgvTopProducts.TabIndex = 1;
            // 
            // SalesReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(249)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(1249, 660);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.lblReportType);
            this.Controls.Add(this.cboReportType);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.pnlTotalRevenue);
            this.Controls.Add(this.pnlTotalOrders);
            this.Controls.Add(this.pnlAverageOrder);
            this.Controls.Add(this.pnlChart);
            this.Controls.Add(this.pnlTopProducts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SalesReportForm";
            this.Text = "Báo cáo doanh thu";
            this.pnlTotalRevenue.ResumeLayout(false);
            this.pnlTotalRevenue.PerformLayout();
            this.pnlTotalOrders.ResumeLayout(false);
            this.pnlTotalOrders.PerformLayout();
            this.pnlAverageOrder.ResumeLayout(false);
            this.pnlAverageOrder.PerformLayout();
            this.pnlChart.ResumeLayout(false);
            this.pnlChart.PerformLayout();
            this.pnlTopProducts.ResumeLayout(false);
            this.pnlTopProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}