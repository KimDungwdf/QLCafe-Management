using QLCafe.Presentation.Components;
using System.Drawing;
using System.Windows.Forms;

namespace QLCafe.Presentation.Views.Admin
{
    partial class StockReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private DateTimePicker dtpFromDate;
        private DateTimePicker dtpToDate;
        private ComboBox cboTable;
        private ComboBox cboStatus;
        private RoundButton btnFilter;
        private DataGridView dgvTableHistory;
        private Label lblFromDate;
        private Label lblToDate;
        private Label lblTable;
        private Label lblStatus;
        private RoundedPanel pnlFilter;
        private RoundedPanel pnlData;

        private DataGridViewTextBoxColumn colOrderId;
        private DataGridViewTextBoxColumn colTableName;
        private DataGridViewTextBoxColumn colOrderDate;
        private DataGridViewTextBoxColumn colTotalAmount;
        private DataGridViewTextBoxColumn colEmployee;
        private DataGridViewTextBoxColumn colStatus;

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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlData = new QLCafe.Presentation.Components.RoundedPanel();
            this.dgvTableHistory = new System.Windows.Forms.DataGridView();
            this.colOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFilter = new QLCafe.Presentation.Components.RoundedPanel();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblTable = new System.Windows.Forms.Label();
            this.cboTable = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.btnFilter = new QLCafe.Presentation.Components.RoundButton();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableHistory)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlData
            // 
            this.pnlData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlData.BackColor = System.Drawing.Color.White;
            this.pnlData.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.pnlData.BorderThickness = 2;
            this.pnlData.Controls.Add(this.dgvTableHistory);
            this.pnlData.CornerRadius = 20;
            this.pnlData.Location = new System.Drawing.Point(36, 140);
            this.pnlData.Name = "pnlData";
            this.pnlData.Padding = new System.Windows.Forms.Padding(15);
            this.pnlData.Size = new System.Drawing.Size(1073, 490);
            this.pnlData.TabIndex = 1;
            this.pnlData.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlData_Paint);
            // 
            // dgvTableHistory
            // 
            this.dgvTableHistory.AllowUserToAddRows = false;
            this.dgvTableHistory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.dgvTableHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTableHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvTableHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTableHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTableHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(69)))), ((int)(((byte)(19)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(69)))), ((int)(((byte)(19)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTableHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTableHistory.ColumnHeadersHeight = 46;
            this.dgvTableHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTableHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrderId,
            this.colTableName,
            this.colOrderDate,
            this.colTotalAmount,
            this.colEmployee,
            this.colStatus});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTableHistory.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTableHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTableHistory.EnableHeadersVisualStyles = false;
            this.dgvTableHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(225)))), ((int)(((byte)(220)))));
            this.dgvTableHistory.Location = new System.Drawing.Point(15, 15);
            this.dgvTableHistory.MultiSelect = false;
            this.dgvTableHistory.Name = "dgvTableHistory";
            this.dgvTableHistory.ReadOnly = true;
            this.dgvTableHistory.RowHeadersVisible = false;
            this.dgvTableHistory.RowHeadersWidth = 51;
            this.dgvTableHistory.RowTemplate.Height = 50;
            this.dgvTableHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTableHistory.Size = new System.Drawing.Size(1043, 460);
            this.dgvTableHistory.TabIndex = 0;
            // 
            // colOrderId
            // 
            this.colOrderId.HeaderText = "Mã đơn";
            this.colOrderId.MinimumWidth = 6;
            this.colOrderId.Name = "colOrderId";
            this.colOrderId.ReadOnly = true;
            this.colOrderId.Width = 125;
            // 
            // colTableName
            // 
            this.colTableName.HeaderText = "Bàn";
            this.colTableName.MinimumWidth = 6;
            this.colTableName.Name = "colTableName";
            this.colTableName.ReadOnly = true;
            this.colTableName.Width = 120;
            // 
            // colOrderDate
            // 
            this.colOrderDate.HeaderText = "Ngày lập hóa đơn";
            this.colOrderDate.MinimumWidth = 6;
            this.colOrderDate.Name = "colOrderDate";
            this.colOrderDate.ReadOnly = true;
            this.colOrderDate.Width = 200;
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.HeaderText = "Tổng tiền";
            this.colTotalAmount.MinimumWidth = 6;
            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.ReadOnly = true;
            this.colTotalAmount.Width = 150;
            // 
            // colEmployee
            // 
            this.colEmployee.HeaderText = "Nhân viên";
            this.colEmployee.MinimumWidth = 6;
            this.colEmployee.Name = "colEmployee";
            this.colEmployee.ReadOnly = true;
            this.colEmployee.Width = 180;
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStatus.HeaderText = "Trạng thái";
            this.colStatus.MinimumWidth = 150;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.pnlFilter.BorderThickness = 2;
            this.pnlFilter.Controls.Add(this.lblFromDate);
            this.pnlFilter.Controls.Add(this.dtpFromDate);
            this.pnlFilter.Controls.Add(this.lblToDate);
            this.pnlFilter.Controls.Add(this.dtpToDate);
            this.pnlFilter.Controls.Add(this.lblTable);
            this.pnlFilter.Controls.Add(this.cboTable);
            this.pnlFilter.Controls.Add(this.lblStatus);
            this.pnlFilter.Controls.Add(this.cboStatus);
            this.pnlFilter.Controls.Add(this.btnFilter);
            this.pnlFilter.CornerRadius = 20;
            this.pnlFilter.Location = new System.Drawing.Point(36, 30);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1018, 90);
            this.pnlFilter.TabIndex = 0;
            this.pnlFilter.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFilter_Paint);
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFromDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(67)))), ((int)(((byte)(33)))));
            this.lblFromDate.Location = new System.Drawing.Point(25, 20);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(75, 23);
            this.lblFromDate.TabIndex = 0;
            this.lblFromDate.Text = "Từ ngày";
            this.lblFromDate.Click += new System.EventHandler(this.lblFromDate_Click);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CalendarFont = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFromDate.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(25, 46);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(180, 32);
            this.dtpFromDate.TabIndex = 1;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblToDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(67)))), ((int)(((byte)(33)))));
            this.lblToDate.Location = new System.Drawing.Point(230, 20);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(86, 23);
            this.lblToDate.TabIndex = 2;
            this.lblToDate.Text = "Đến ngày";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CalendarFont = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpToDate.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(230, 46);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(180, 32);
            this.dtpToDate.TabIndex = 3;
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(67)))), ((int)(((byte)(33)))));
            this.lblTable.Location = new System.Drawing.Point(440, 20);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(40, 23);
            this.lblTable.TabIndex = 4;
            this.lblTable.Text = "Bàn";
            // 
            // cboTable
            // 
            this.cboTable.BackColor = System.Drawing.Color.White;
            this.cboTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTable.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboTable.FormattingEnabled = true;
            this.cboTable.Items.AddRange(new object[] {
            "Tất cả"});
            this.cboTable.Location = new System.Drawing.Point(440, 46);
            this.cboTable.Name = "cboTable";
            this.cboTable.Size = new System.Drawing.Size(180, 33);
            this.cboTable.TabIndex = 5;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(67)))), ((int)(((byte)(33)))));
            this.lblStatus.Location = new System.Drawing.Point(650, 20);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(92, 23);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Trạng thái";
            // 
            // cboStatus
            // 
            this.cboStatus.BackColor = System.Drawing.Color.White;
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboStatus.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "Tất cả",
            "Hoàn thành",
            "Hủy",
            "Đang sử dụng"});
            this.cboStatus.Location = new System.Drawing.Point(650, 46);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(180, 33);
            this.cboStatus.TabIndex = 7;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(69)))), ((int)(((byte)(19)))));
            this.btnFilter.BorderRadius = 10;
            this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(846, 31);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(120, 45);
            this.btnFilter.TabIndex = 8;
            this.btnFilter.Text = "Lọc";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click_1);
            // 
            // StockReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(249)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(1135, 660);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.pnlFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StockReportForm";
            this.Text = "Lịch sử bàn";
            this.pnlData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableHistory)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}