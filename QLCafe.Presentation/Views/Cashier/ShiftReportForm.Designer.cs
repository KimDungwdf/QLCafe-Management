namespace QLCafe.Presentation.Views.Cashier
{
    partial class ShiftReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.cboThuNgan = new System.Windows.Forms.ComboBox();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.lblThuNgan = new System.Windows.Forms.Label();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCardTrungBinh = new System.Windows.Forms.Panel();
            this.lblTrungBinhDon = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pnlCardGiamGia = new System.Windows.Forms.Panel();
            this.lblTongGiamGia = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pnlCardHoaDon = new System.Windows.Forms.Panel();
            this.lblTongHoaDon = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlCardDoanhThu = new System.Windows.Forms.Panel();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlBillSection = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.pnlBillFooter = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTongTienFooter = new System.Windows.Forms.Label();
            this.lblThanhTienFooter = new System.Windows.Forms.Label();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.lblGiamGiaFooter = new System.Windows.Forms.Label();
            this.pnlTopProducts = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvTopMon = new System.Windows.Forms.DataGridView();
            this.pnlFilter.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlCardTrungBinh.SuspendLayout();
            this.pnlCardGiamGia.SuspendLayout();
            this.pnlCardHoaDon.SuspendLayout();
            this.pnlCardDoanhThu.SuspendLayout();
            this.pnlBillSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.pnlBillFooter.SuspendLayout();
            this.pnlTopProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopMon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.btnXemBaoCao);
            this.pnlFilter.Controls.Add(this.cboThuNgan);
            this.pnlFilter.Controls.Add(this.dtpDenNgay);
            this.pnlFilter.Controls.Add(this.dtpTuNgay);
            this.pnlFilter.Controls.Add(this.lblDenNgay);
            this.pnlFilter.Controls.Add(this.lblThuNgan);
            this.pnlFilter.Controls.Add(this.lblTuNgay);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1150, 100);
            this.pnlFilter.TabIndex = 0;
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.BackColor = System.Drawing.Color.DarkOrange;
            this.btnXemBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemBaoCao.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnXemBaoCao.Image = global::QLCafe.Presentation.Properties.Resources.Screenshot_2026_01_29_005540_removebg_preview;
            this.btnXemBaoCao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemBaoCao.Location = new System.Drawing.Point(868, 38);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(226, 41);
            this.btnXemBaoCao.TabIndex = 6;
            this.btnXemBaoCao.Text = "Xem Báo Cáo";
            this.btnXemBaoCao.UseVisualStyleBackColor = false;
            // 
            // cboThuNgan
            // 
            this.cboThuNgan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThuNgan.FormattingEnabled = true;
            this.cboThuNgan.Location = new System.Drawing.Point(568, 51);
            this.cboThuNgan.Name = "cboThuNgan";
            this.cboThuNgan.Size = new System.Drawing.Size(237, 28);
            this.cboThuNgan.TabIndex = 5;
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(297, 54);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(124, 26);
            this.dtpDenNgay.TabIndex = 4;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(26, 54);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(124, 26);
            this.dtpTuNgay.TabIndex = 3;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDenNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(62)))), ((int)(((byte)(38)))));
            this.lblDenNgay.Location = new System.Drawing.Point(293, 13);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(83, 21);
            this.lblDenNgay.TabIndex = 2;
            this.lblDenNgay.Text = "Đến ngày";
            // 
            // lblThuNgan
            // 
            this.lblThuNgan.AutoSize = true;
            this.lblThuNgan.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThuNgan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(62)))), ((int)(((byte)(38)))));
            this.lblThuNgan.Location = new System.Drawing.Point(564, 13);
            this.lblThuNgan.Name = "lblThuNgan";
            this.lblThuNgan.Size = new System.Drawing.Size(82, 21);
            this.lblThuNgan.TabIndex = 1;
            this.lblThuNgan.Text = "Thu ngân";
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(62)))), ((int)(((byte)(38)))));
            this.lblTuNgay.Location = new System.Drawing.Point(22, 13);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(72, 21);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Từ ngày";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.pnlCardTrungBinh, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlCardGiamGia, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlCardHoaDon, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlCardDoanhThu, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 100);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1150, 100);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // pnlCardTrungBinh
            // 
            this.pnlCardTrungBinh.Controls.Add(this.lblTrungBinhDon);
            this.pnlCardTrungBinh.Controls.Add(this.label7);
            this.pnlCardTrungBinh.Controls.Add(this.panel7);
            this.pnlCardTrungBinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardTrungBinh.Location = new System.Drawing.Point(871, 10);
            this.pnlCardTrungBinh.Margin = new System.Windows.Forms.Padding(10);
            this.pnlCardTrungBinh.Name = "pnlCardTrungBinh";
            this.pnlCardTrungBinh.Size = new System.Drawing.Size(269, 80);
            this.pnlCardTrungBinh.TabIndex = 5;
            // 
            // lblTrungBinhDon
            // 
            this.lblTrungBinhDon.AutoSize = true;
            this.lblTrungBinhDon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrungBinhDon.Location = new System.Drawing.Point(11, 35);
            this.lblTrungBinhDon.Name = "lblTrungBinhDon";
            this.lblTrungBinhDon.Size = new System.Drawing.Size(50, 32);
            this.lblTrungBinhDon.TabIndex = 2;
            this.lblTrungBinhDon.Text = "0 đ";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Image = global::QLCafe.Presentation.Properties.Resources.Screenshot_2025_12_11_153704_removebg_preview;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(11, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(233, 25);
            this.label7.TabIndex = 1;
            this.label7.Text = "TB/Hóa đơn";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.SlateBlue;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(5, 80);
            this.panel7.TabIndex = 0;
            // 
            // pnlCardGiamGia
            // 
            this.pnlCardGiamGia.Controls.Add(this.lblTongGiamGia);
            this.pnlCardGiamGia.Controls.Add(this.label5);
            this.pnlCardGiamGia.Controls.Add(this.panel5);
            this.pnlCardGiamGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardGiamGia.Location = new System.Drawing.Point(584, 10);
            this.pnlCardGiamGia.Margin = new System.Windows.Forms.Padding(10);
            this.pnlCardGiamGia.Name = "pnlCardGiamGia";
            this.pnlCardGiamGia.Size = new System.Drawing.Size(267, 80);
            this.pnlCardGiamGia.TabIndex = 4;
            // 
            // lblTongGiamGia
            // 
            this.lblTongGiamGia.AutoSize = true;
            this.lblTongGiamGia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongGiamGia.Location = new System.Drawing.Point(11, 35);
            this.lblTongGiamGia.Name = "lblTongGiamGia";
            this.lblTongGiamGia.Size = new System.Drawing.Size(35, 32);
            this.lblTongGiamGia.TabIndex = 2;
            this.lblTongGiamGia.Text = "0 ";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Image = global::QLCafe.Presentation.Properties.Resources.Screenshot_2026_01_29_010702_removebg_preview;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(11, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(233, 25);
            this.label5.TabIndex = 1;
            this.label5.Text = "Tổng giảm giá";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gold;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(5, 80);
            this.panel5.TabIndex = 0;
            // 
            // pnlCardHoaDon
            // 
            this.pnlCardHoaDon.Controls.Add(this.lblTongHoaDon);
            this.pnlCardHoaDon.Controls.Add(this.label3);
            this.pnlCardHoaDon.Controls.Add(this.panel3);
            this.pnlCardHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardHoaDon.Location = new System.Drawing.Point(297, 10);
            this.pnlCardHoaDon.Margin = new System.Windows.Forms.Padding(10);
            this.pnlCardHoaDon.Name = "pnlCardHoaDon";
            this.pnlCardHoaDon.Size = new System.Drawing.Size(267, 80);
            this.pnlCardHoaDon.TabIndex = 3;
            // 
            // lblTongHoaDon
            // 
            this.lblTongHoaDon.AutoSize = true;
            this.lblTongHoaDon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongHoaDon.Location = new System.Drawing.Point(11, 35);
            this.lblTongHoaDon.Name = "lblTongHoaDon";
            this.lblTongHoaDon.Size = new System.Drawing.Size(35, 32);
            this.lblTongHoaDon.TabIndex = 2;
            this.lblTongHoaDon.Text = "0 ";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Image = global::QLCafe.Presentation.Properties.Resources.Screenshot_2026_01_29_010546_removebg_preview;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(11, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Số hóa đơn";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Orange;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(5, 80);
            this.panel3.TabIndex = 0;
            // 
            // pnlCardDoanhThu
            // 
            this.pnlCardDoanhThu.Controls.Add(this.lblTongDoanhThu);
            this.pnlCardDoanhThu.Controls.Add(this.label1);
            this.pnlCardDoanhThu.Controls.Add(this.panel1);
            this.pnlCardDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardDoanhThu.Location = new System.Drawing.Point(10, 10);
            this.pnlCardDoanhThu.Margin = new System.Windows.Forms.Padding(10);
            this.pnlCardDoanhThu.Name = "pnlCardDoanhThu";
            this.pnlCardDoanhThu.Size = new System.Drawing.Size(267, 80);
            this.pnlCardDoanhThu.TabIndex = 2;
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongDoanhThu.Location = new System.Drawing.Point(11, 35);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(50, 32);
            this.lblTongDoanhThu.TabIndex = 2;
            this.lblTongDoanhThu.Text = "0 đ";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Image = global::QLCafe.Presentation.Properties.Resources.Screenshot_2026_01_29_010211_removebg_preview;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tổng doanh thu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SeaGreen;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 80);
            this.panel1.TabIndex = 0;
            // 
            // pnlBillSection
            // 
            this.pnlBillSection.Controls.Add(this.pnlBillFooter);
            this.pnlBillSection.Controls.Add(this.dgvHoaDon);
            this.pnlBillSection.Controls.Add(this.label2);
            this.pnlBillSection.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBillSection.Location = new System.Drawing.Point(0, 200);
            this.pnlBillSection.Name = "pnlBillSection";
            this.pnlBillSection.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBillSection.Size = new System.Drawing.Size(1150, 506);
            this.pnlBillSection.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(62)))), ((int)(((byte)(38)))));
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(272, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "Chi tiết hóa đơn trong ca";
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHoaDon.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Brown;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvHoaDon.EnableHeadersVisualStyles = false;
            this.dgvHoaDon.Location = new System.Drawing.Point(10, 40);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.RowHeadersWidth = 62;
            this.dgvHoaDon.RowTemplate.Height = 28;
            this.dgvHoaDon.Size = new System.Drawing.Size(1130, 338);
            this.dgvHoaDon.TabIndex = 1;
            // 
            // pnlBillFooter
            // 
            this.pnlBillFooter.BackColor = System.Drawing.Color.White;
            this.pnlBillFooter.Controls.Add(this.lblGiamGiaFooter);
            this.pnlBillFooter.Controls.Add(this.btnPrintReport);
            this.pnlBillFooter.Controls.Add(this.btnExportExcel);
            this.pnlBillFooter.Controls.Add(this.lblThanhTienFooter);
            this.pnlBillFooter.Controls.Add(this.lblTongTienFooter);
            this.pnlBillFooter.Controls.Add(this.label4);
            this.pnlBillFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBillFooter.Location = new System.Drawing.Point(10, 378);
            this.pnlBillFooter.Name = "pnlBillFooter";
            this.pnlBillFooter.Size = new System.Drawing.Size(1130, 118);
            this.pnlBillFooter.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(168, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 32);
            this.label4.TabIndex = 3;
            this.label4.Text = "TỔNG CỘNG:";
            // 
            // lblTongTienFooter
            // 
            this.lblTongTienFooter.AutoSize = true;
            this.lblTongTienFooter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienFooter.Location = new System.Drawing.Point(366, 15);
            this.lblTongTienFooter.Name = "lblTongTienFooter";
            this.lblTongTienFooter.Size = new System.Drawing.Size(141, 32);
            this.lblTongTienFooter.TabIndex = 4;
            this.lblTongTienFooter.Text = "1,455,000đ";
            // 
            // lblThanhTienFooter
            // 
            this.lblThanhTienFooter.AutoSize = true;
            this.lblThanhTienFooter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThanhTienFooter.ForeColor = System.Drawing.Color.Green;
            this.lblThanhTienFooter.Location = new System.Drawing.Point(742, 15);
            this.lblThanhTienFooter.Name = "lblThanhTienFooter";
            this.lblThanhTienFooter.Size = new System.Drawing.Size(141, 32);
            this.lblThanhTienFooter.TabIndex = 5;
            this.lblThanhTienFooter.Text = "1,370,000đ";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Image = global::QLCafe.Presentation.Properties.Resources.Screenshot_2025_12_11_154008_removebg_preview;
            this.btnExportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportExcel.Location = new System.Drawing.Point(558, 63);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(216, 44);
            this.btnExportExcel.TabIndex = 6;
            this.btnExportExcel.Text = "Xuất excel";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnPrintReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintReport.ForeColor = System.Drawing.Color.White;
            this.btnPrintReport.Image = global::QLCafe.Presentation.Properties.Resources.Screenshot_2025_12_11_154008_removebg_preview;
            this.btnPrintReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintReport.Location = new System.Drawing.Point(821, 63);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(216, 44);
            this.btnPrintReport.TabIndex = 7;
            this.btnPrintReport.Text = "In báo cáo";
            this.btnPrintReport.UseVisualStyleBackColor = false;
            // 
            // lblGiamGiaFooter
            // 
            this.lblGiamGiaFooter.AutoSize = true;
            this.lblGiamGiaFooter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiamGiaFooter.Location = new System.Drawing.Point(552, 15);
            this.lblGiamGiaFooter.Name = "lblGiamGiaFooter";
            this.lblGiamGiaFooter.Size = new System.Drawing.Size(116, 32);
            this.lblGiamGiaFooter.TabIndex = 8;
            this.lblGiamGiaFooter.Text = "-85,000đ";
            // 
            // pnlTopProducts
            // 
            this.pnlTopProducts.Controls.Add(this.dgvTopMon);
            this.pnlTopProducts.Controls.Add(this.label6);
            this.pnlTopProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTopProducts.Location = new System.Drawing.Point(0, 706);
            this.pnlTopProducts.Name = "pnlTopProducts";
            this.pnlTopProducts.Size = new System.Drawing.Size(1150, 210);
            this.pnlTopProducts.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(62)))), ((int)(((byte)(38)))));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(256, 30);
            this.label6.TabIndex = 1;
            this.label6.Text = "Top sản phẩm bán chạy";
            // 
            // dgvTopMon
            // 
            this.dgvTopMon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTopMon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopMon.Location = new System.Drawing.Point(0, 30);
            this.dgvTopMon.Name = "dgvTopMon";
            this.dgvTopMon.RowHeadersWidth = 62;
            this.dgvTopMon.RowTemplate.Height = 28;
            this.dgvTopMon.Size = new System.Drawing.Size(1150, 180);
            this.dgvTopMon.TabIndex = 2;
            // 
            // ShiftReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1150, 916);
            this.Controls.Add(this.pnlTopProducts);
            this.Controls.Add(this.pnlBillSection);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pnlFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShiftReportForm";
            this.Text = "ShiftReportForm";
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlCardTrungBinh.ResumeLayout(false);
            this.pnlCardTrungBinh.PerformLayout();
            this.pnlCardGiamGia.ResumeLayout(false);
            this.pnlCardGiamGia.PerformLayout();
            this.pnlCardHoaDon.ResumeLayout(false);
            this.pnlCardHoaDon.PerformLayout();
            this.pnlCardDoanhThu.ResumeLayout(false);
            this.pnlCardDoanhThu.PerformLayout();
            this.pnlBillSection.ResumeLayout(false);
            this.pnlBillSection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.pnlBillFooter.ResumeLayout(false);
            this.pnlBillFooter.PerformLayout();
            this.pnlTopProducts.ResumeLayout(false);
            this.pnlTopProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopMon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.Label lblThuNgan;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.ComboBox cboThuNgan;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlCardDoanhThu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.Panel pnlCardTrungBinh;
        private System.Windows.Forms.Label lblTrungBinhDon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel pnlCardGiamGia;
        private System.Windows.Forms.Label lblTongGiamGia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel pnlCardHoaDon;
        private System.Windows.Forms.Label lblTongHoaDon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnlBillSection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Panel pnlBillFooter;
        private System.Windows.Forms.Label lblThanhTienFooter;
        private System.Windows.Forms.Label lblTongTienFooter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Label lblGiamGiaFooter;
        private System.Windows.Forms.Panel pnlTopProducts;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvTopMon;
    }
}