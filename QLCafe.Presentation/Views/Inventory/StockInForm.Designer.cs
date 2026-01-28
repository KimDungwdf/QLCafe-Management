namespace QLCafe.Presentation.Views.Inventory
{
    partial class StockInForm
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
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.txtInfoNCC = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cboNhaCungCap = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.cboNguyenLieu = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.tlpTop = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlItemCount = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTongMatHang = new System.Windows.Forms.Label();
            this.pnlTotalQty = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTongSoLuong = new System.Windows.Forms.Label();
            this.pnlTotalAmount = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvChiTietNhap = new System.Windows.Forms.DataGridView();
            this.pnlInfo.SuspendLayout();
            this.pnlInput.SuspendLayout();
            this.tlpTop.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlItemCount.SuspendLayout();
            this.pnlTotalQty.SuspendLayout();
            this.pnlTotalAmount.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.Controls.Add(this.dateTimePicker1);
            this.pnlInfo.Controls.Add(this.label15);
            this.pnlInfo.Controls.Add(this.txtInfoNCC);
            this.pnlInfo.Controls.Add(this.label16);
            this.pnlInfo.Controls.Add(this.cboNhaCungCap);
            this.pnlInfo.Controls.Add(this.label17);
            this.pnlInfo.Controls.Add(this.label18);
            this.pnlInfo.Controls.Add(this.label19);
            this.pnlInfo.Controls.Add(this.label20);
            this.pnlInfo.Location = new System.Drawing.Point(10, 0);
            this.pnlInfo.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(593, 452);
            this.pnlInfo.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(19, 307);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(558, 37);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label15.Location = new System.Drawing.Point(15, 270);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(288, 34);
            this.label15.TabIndex = 7;
            this.label15.Text = "Ngày nhập";
            // 
            // txtInfoNCC
            // 
            this.txtInfoNCC.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtInfoNCC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInfoNCC.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfoNCC.Location = new System.Drawing.Point(20, 204);
            this.txtInfoNCC.Multiline = true;
            this.txtInfoNCC.Name = "txtInfoNCC";
            this.txtInfoNCC.ReadOnly = true;
            this.txtInfoNCC.Size = new System.Drawing.Size(557, 40);
            this.txtInfoNCC.TabIndex = 6;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label16.Location = new System.Drawing.Point(15, 161);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(355, 29);
            this.label16.TabIndex = 5;
            this.label16.Text = "Thông tin nhà cung cấp";
            // 
            // cboNhaCungCap
            // 
            this.cboNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNhaCungCap.FormattingEnabled = true;
            this.cboNhaCungCap.Location = new System.Drawing.Point(19, 103);
            this.cboNhaCungCap.Name = "cboNhaCungCap";
            this.cboNhaCungCap.Size = new System.Drawing.Size(558, 38);
            this.cboNhaCungCap.TabIndex = 4;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(171, 66);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(20, 25);
            this.label17.TabIndex = 3;
            this.label17.Text = "*";
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label18.Location = new System.Drawing.Point(15, 62);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(331, 38);
            this.label18.TabIndex = 2;
            this.label18.Text = "Nhà cung cấp";
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(53)))), ((int)(((byte)(15)))));
            this.label19.Location = new System.Drawing.Point(27, 48);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(550, 2);
            this.label19.TabIndex = 1;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(53)))), ((int)(((byte)(15)))));
            this.label20.Image = global::QLCafe.Presentation.Properties.Resources.Screenshot_2026_01_28_101153_removebg_preview;
            this.label20.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label20.Location = new System.Drawing.Point(14, 6);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(386, 42);
            this.label20.TabIndex = 0;
            this.label20.Text = "Thông Tin Phiếu Nhập";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlInput
            // 
            this.pnlInput.BackColor = System.Drawing.Color.White;
            this.pnlInput.Controls.Add(this.btnRefresh);
            this.pnlInput.Controls.Add(this.btnAdd);
            this.pnlInput.Controls.Add(this.txtDonGia);
            this.pnlInput.Controls.Add(this.label21);
            this.pnlInput.Controls.Add(this.label22);
            this.pnlInput.Controls.Add(this.txtSoLuong);
            this.pnlInput.Controls.Add(this.label23);
            this.pnlInput.Controls.Add(this.label24);
            this.pnlInput.Controls.Add(this.label25);
            this.pnlInput.Controls.Add(this.cboNguyenLieu);
            this.pnlInput.Controls.Add(this.label26);
            this.pnlInput.Controls.Add(this.label27);
            this.pnlInput.Controls.Add(this.label28);
            this.pnlInput.Location = new System.Drawing.Point(623, 0);
            this.pnlInput.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(613, 452);
            this.pnlInput.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Image = global::QLCafe.Presentation.Properties.Resources.Screenshot_2026_01_28_112919_removebg_preview;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(355, 380);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(195, 50);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(53)))), ((int)(((byte)(15)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = global::QLCafe.Presentation.Properties.Resources.Screenshot_2026_01_28_111700_removebg_preview;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(29, 380);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(283, 50);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Thêm vào phiếu";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDonGia.Location = new System.Drawing.Point(29, 302);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(546, 37);
            this.txtDonGia.TabIndex = 12;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(190, 274);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(20, 25);
            this.label21.TabIndex = 11;
            this.label21.Text = "*";
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label22.Location = new System.Drawing.Point(24, 270);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(288, 34);
            this.label22.TabIndex = 10;
            this.label22.Text = "Đơn giá (VNĐ)";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuong.Location = new System.Drawing.Point(29, 204);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(546, 37);
            this.txtSoLuong.TabIndex = 9;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Red;
            this.label23.Location = new System.Drawing.Point(162, 165);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(20, 25);
            this.label23.TabIndex = 8;
            this.label23.Text = "*";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Red;
            this.label24.Location = new System.Drawing.Point(162, 66);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(20, 25);
            this.label24.TabIndex = 7;
            this.label24.Text = "*";
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label25.Location = new System.Drawing.Point(24, 161);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(355, 29);
            this.label25.TabIndex = 6;
            this.label25.Text = "Số lượng (-)";
            // 
            // cboNguyenLieu
            // 
            this.cboNguyenLieu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNguyenLieu.FormattingEnabled = true;
            this.cboNguyenLieu.Location = new System.Drawing.Point(29, 103);
            this.cboNguyenLieu.Name = "cboNguyenLieu";
            this.cboNguyenLieu.Size = new System.Drawing.Size(546, 38);
            this.cboNguyenLieu.TabIndex = 5;
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label26.Location = new System.Drawing.Point(24, 62);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(331, 38);
            this.label26.TabIndex = 3;
            this.label26.Text = "Nguyên liệu";
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(53)))), ((int)(((byte)(15)))));
            this.label27.Location = new System.Drawing.Point(25, 48);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(550, 2);
            this.label27.TabIndex = 2;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(53)))), ((int)(((byte)(15)))));
            this.label28.Image = global::QLCafe.Presentation.Properties.Resources.Screenshot_2026_01_28_111700_removebg_preview;
            this.label28.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label28.Location = new System.Drawing.Point(23, 6);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(332, 42);
            this.label28.TabIndex = 1;
            this.label28.Text = "Thêm nguyên liệu";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpTop
            // 
            this.tlpTop.ColumnCount = 2;
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.25382F));
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.74618F));
            this.tlpTop.Controls.Add(this.pnlInfo, 0, 0);
            this.tlpTop.Controls.Add(this.pnlInput, 1, 0);
            this.tlpTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTop.Location = new System.Drawing.Point(0, 0);
            this.tlpTop.Name = "tlpTop";
            this.tlpTop.RowCount = 1;
            this.tlpTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop.Size = new System.Drawing.Size(1326, 462);
            this.tlpTop.TabIndex = 3;
            // 
            // pnlSummary
            // 
            this.pnlSummary.BackColor = System.Drawing.Color.Snow;
            this.pnlSummary.Controls.Add(this.tableLayoutPanel1);
            this.pnlSummary.Controls.Add(this.btnSave);
            this.pnlSummary.Controls.Add(this.btnCancel);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSummary.Location = new System.Drawing.Point(0, 787);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Padding = new System.Windows.Forms.Padding(20, 50, 20, 20);
            this.pnlSummary.Size = new System.Drawing.Size(1326, 263);
            this.pnlSummary.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.pnlItemCount, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlTotalQty, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlTotalAmount, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1286, 100);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // pnlItemCount
            // 
            this.pnlItemCount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlItemCount.Controls.Add(this.label3);
            this.pnlItemCount.Controls.Add(this.lblTongMatHang);
            this.pnlItemCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlItemCount.Location = new System.Drawing.Point(3, 3);
            this.pnlItemCount.Name = "pnlItemCount";
            this.pnlItemCount.Size = new System.Drawing.Size(422, 94);
            this.pnlItemCount.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(331, 38);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tổng số mặt hàng";
            // 
            // lblTongMatHang
            // 
            this.lblTongMatHang.AutoSize = true;
            this.lblTongMatHang.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongMatHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(53)))), ((int)(((byte)(15)))));
            this.lblTongMatHang.Location = new System.Drawing.Point(11, 47);
            this.lblTongMatHang.Name = "lblTongMatHang";
            this.lblTongMatHang.Size = new System.Drawing.Size(38, 45);
            this.lblTongMatHang.TabIndex = 4;
            this.lblTongMatHang.Text = "0";
            // 
            // pnlTotalQty
            // 
            this.pnlTotalQty.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTotalQty.Controls.Add(this.label4);
            this.pnlTotalQty.Controls.Add(this.lblTongSoLuong);
            this.pnlTotalQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTotalQty.Location = new System.Drawing.Point(431, 3);
            this.pnlTotalQty.Name = "pnlTotalQty";
            this.pnlTotalQty.Size = new System.Drawing.Size(422, 94);
            this.pnlTotalQty.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label4.Location = new System.Drawing.Point(11, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(331, 38);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tổng số lượng";
            // 
            // lblTongSoLuong
            // 
            this.lblTongSoLuong.AutoSize = true;
            this.lblTongSoLuong.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongSoLuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(53)))), ((int)(((byte)(15)))));
            this.lblTongSoLuong.Location = new System.Drawing.Point(10, 47);
            this.lblTongSoLuong.Name = "lblTongSoLuong";
            this.lblTongSoLuong.Size = new System.Drawing.Size(38, 45);
            this.lblTongSoLuong.TabIndex = 6;
            this.lblTongSoLuong.Text = "0";
            // 
            // pnlTotalAmount
            // 
            this.pnlTotalAmount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTotalAmount.Controls.Add(this.label5);
            this.pnlTotalAmount.Controls.Add(this.lblTongTien);
            this.pnlTotalAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTotalAmount.Location = new System.Drawing.Point(859, 3);
            this.pnlTotalAmount.Name = "pnlTotalAmount";
            this.pnlTotalAmount.Size = new System.Drawing.Size(424, 94);
            this.pnlTotalAmount.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label5.Location = new System.Drawing.Point(11, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(331, 38);
            this.label5.TabIndex = 7;
            this.label5.Text = "Tổng tiền nhập";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(53)))), ((int)(((byte)(15)))));
            this.lblTongTien.Location = new System.Drawing.Point(10, 47);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(38, 45);
            this.lblTongTien.TabIndex = 8;
            this.lblTongTien.Text = "0";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::QLCafe.Presentation.Properties.Resources.Screenshot_2026_01_28_131519_removebg_preview;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(721, 203);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(314, 49);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Lưu phiếu nhập";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Image = global::QLCafe.Presentation.Properties.Resources.Screenshot_2026_01_28_131333_removebg_preview;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(404, 203);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(262, 49);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Hủy phiếu";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvChiTietNhap);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 462);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1326, 325);
            this.pnlGrid.TabIndex = 5;
            // 
            // dgvChiTietNhap
            // 
            this.dgvChiTietNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietNhap.Location = new System.Drawing.Point(0, 0);
            this.dgvChiTietNhap.Name = "dgvChiTietNhap";
            this.dgvChiTietNhap.RowHeadersWidth = 62;
            this.dgvChiTietNhap.RowTemplate.Height = 28;
            this.dgvChiTietNhap.Size = new System.Drawing.Size(1326, 325);
            this.dgvChiTietNhap.TabIndex = 1;
            // 
            // StockInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1326, 1050);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.tlpTop);
            this.Name = "StockInForm";
            this.Text = "StockInForm";
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.tlpTop.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlItemCount.ResumeLayout(false);
            this.pnlItemCount.PerformLayout();
            this.pnlTotalQty.ResumeLayout(false);
            this.pnlTotalQty.PerformLayout();
            this.pnlTotalAmount.ResumeLayout(false);
            this.pnlTotalAmount.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietNhap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtInfoNCC;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboNhaCungCap;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cboNguyenLieu;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TableLayoutPanel tlpTop;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlTotalAmount;
        private System.Windows.Forms.Panel pnlTotalQty;
        private System.Windows.Forms.Panel pnlItemCount;
        private System.Windows.Forms.Label lblTongMatHang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTongSoLuong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvChiTietNhap;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}