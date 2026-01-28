namespace QLCafe.Presentation.Controls.History
{
    partial class OrderHistoryCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblThoiGian = new System.Windows.Forms.Label();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.pnlInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lblTongTienHeader = new System.Windows.Forms.Label();
            this.lblPhuongThuc = new System.Windows.Forms.Label();
            this.lblThuNgan = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBan = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblTongCongFooter = new System.Windows.Forms.Label();
            this.lblGiamGia = new System.Windows.Forms.Label();
            this.lblTamTinh = new System.Windows.Forms.Label();
            this.lblLabel3 = new System.Windows.Forms.Label();
            this.lblLabel2 = new System.Windows.Forms.Label();
            this.lblLabel1 = new System.Windows.Forms.Label();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTrangThai);
            this.pnlHeader.Controls.Add(this.lblThoiGian);
            this.pnlHeader.Controls.Add(this.lblMaHD);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(10, 10);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(780, 65);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.BackColor = System.Drawing.Color.LightGreen;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTrangThai.Location = new System.Drawing.Point(636, 26);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(119, 21);
            this.lblTrangThai.TabIndex = 2;
            this.lblTrangThai.Text = "Đã thanh toán";
            this.lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblThoiGian
            // 
            this.lblThoiGian.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGian.ForeColor = System.Drawing.Color.Gray;
            this.lblThoiGian.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblThoiGian.Location = new System.Drawing.Point(3, 34);
            this.lblThoiGian.Name = "lblThoiGian";
            this.lblThoiGian.Size = new System.Drawing.Size(107, 21);
            this.lblThoiGian.TabIndex = 1;
            this.lblThoiGian.Text = "29/01/2026 - 08:15";
            this.lblThoiGian.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaHD
            // 
            this.lblMaHD.AutoSize = true;
            this.lblMaHD.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(62)))), ((int)(((byte)(38)))));
            this.lblMaHD.Location = new System.Drawing.Point(3, 9);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(80, 25);
            this.lblMaHD.TabIndex = 0;
            this.lblMaHD.Text = "#HD001";
            // 
            // pnlInfo
            // 
            this.pnlInfo.ColumnCount = 4;
            this.pnlInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlInfo.Controls.Add(this.lblTongTienHeader, 3, 1);
            this.pnlInfo.Controls.Add(this.lblPhuongThuc, 2, 1);
            this.pnlInfo.Controls.Add(this.lblThuNgan, 1, 1);
            this.pnlInfo.Controls.Add(this.label5, 3, 0);
            this.pnlInfo.Controls.Add(this.label4, 2, 0);
            this.pnlInfo.Controls.Add(this.label3, 1, 0);
            this.pnlInfo.Controls.Add(this.label2, 0, 0);
            this.pnlInfo.Controls.Add(this.lblBan, 0, 1);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.RowCount = 2;
            this.pnlInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlInfo.Size = new System.Drawing.Size(780, 134);
            this.pnlInfo.TabIndex = 3;
            // 
            // lblTongTienHeader
            // 
            this.lblTongTienHeader.AutoEllipsis = true;
            this.lblTongTienHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienHeader.ForeColor = System.Drawing.Color.Green;
            this.lblTongTienHeader.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTongTienHeader.Location = new System.Drawing.Point(588, 20);
            this.lblTongTienHeader.Name = "lblTongTienHeader";
            this.lblTongTienHeader.Size = new System.Drawing.Size(189, 28);
            this.lblTongTienHeader.TabIndex = 12;
            this.lblTongTienHeader.Text = "140,000đ";
            this.lblTongTienHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPhuongThuc
            // 
            this.lblPhuongThuc.AutoEllipsis = true;
            this.lblPhuongThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhuongThuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(62)))), ((int)(((byte)(38)))));
            this.lblPhuongThuc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPhuongThuc.Location = new System.Drawing.Point(393, 20);
            this.lblPhuongThuc.Name = "lblPhuongThuc";
            this.lblPhuongThuc.Size = new System.Drawing.Size(189, 28);
            this.lblPhuongThuc.TabIndex = 11;
            this.lblPhuongThuc.Text = "Tiền mặt";
            this.lblPhuongThuc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblThuNgan
            // 
            this.lblThuNgan.AutoEllipsis = true;
            this.lblThuNgan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThuNgan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(62)))), ((int)(((byte)(38)))));
            this.lblThuNgan.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblThuNgan.Location = new System.Drawing.Point(198, 20);
            this.lblThuNgan.Name = "lblThuNgan";
            this.lblThuNgan.Size = new System.Drawing.Size(189, 28);
            this.lblThuNgan.TabIndex = 10;
            this.lblThuNgan.Text = "Thu ngân ca sáng";
            this.lblThuNgan.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(588, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tổng tiền";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(393, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Phương thức";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(198, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Thu ngân";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Bàn";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBan
            // 
            this.lblBan.AutoEllipsis = true;
            this.lblBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(62)))), ((int)(((byte)(38)))));
            this.lblBan.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblBan.Location = new System.Drawing.Point(3, 20);
            this.lblBan.Name = "lblBan";
            this.lblBan.Size = new System.Drawing.Size(189, 28);
            this.lblBan.TabIndex = 9;
            this.lblBan.Text = "Bàn 5";
            this.lblBan.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pnlInfo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(10, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(780, 134);
            this.panel2.TabIndex = 4;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.lblTongCongFooter);
            this.pnlFooter.Controls.Add(this.lblGiamGia);
            this.pnlFooter.Controls.Add(this.lblTamTinh);
            this.pnlFooter.Controls.Add(this.lblLabel3);
            this.pnlFooter.Controls.Add(this.lblLabel2);
            this.pnlFooter.Controls.Add(this.lblLabel1);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(10, 412);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(780, 104);
            this.pnlFooter.TabIndex = 5;
            // 
            // lblTongCongFooter
            // 
            this.lblTongCongFooter.AutoSize = true;
            this.lblTongCongFooter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongCongFooter.ForeColor = System.Drawing.Color.Green;
            this.lblTongCongFooter.Location = new System.Drawing.Point(669, 57);
            this.lblTongCongFooter.Name = "lblTongCongFooter";
            this.lblTongCongFooter.Size = new System.Drawing.Size(102, 28);
            this.lblTongCongFooter.TabIndex = 11;
            this.lblTongCongFooter.Text = "140,000đ";
            // 
            // lblGiamGia
            // 
            this.lblGiamGia.AutoSize = true;
            this.lblGiamGia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiamGia.ForeColor = System.Drawing.Color.Red;
            this.lblGiamGia.Location = new System.Drawing.Point(532, 57);
            this.lblGiamGia.Name = "lblGiamGia";
            this.lblGiamGia.Size = new System.Drawing.Size(45, 28);
            this.lblGiamGia.TabIndex = 10;
            this.lblGiamGia.Tag = "";
            this.lblGiamGia.Text = "-0đ";
            // 
            // lblTamTinh
            // 
            this.lblTamTinh.AutoSize = true;
            this.lblTamTinh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTamTinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(62)))), ((int)(((byte)(38)))));
            this.lblTamTinh.Location = new System.Drawing.Point(358, 57);
            this.lblTamTinh.Name = "lblTamTinh";
            this.lblTamTinh.Size = new System.Drawing.Size(102, 28);
            this.lblTamTinh.TabIndex = 9;
            this.lblTamTinh.Text = "140,000đ";
            // 
            // lblLabel3
            // 
            this.lblLabel3.AutoSize = true;
            this.lblLabel3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabel3.ForeColor = System.Drawing.Color.Gray;
            this.lblLabel3.Location = new System.Drawing.Point(669, 22);
            this.lblLabel3.Name = "lblLabel3";
            this.lblLabel3.Size = new System.Drawing.Size(96, 21);
            this.lblLabel3.TabIndex = 8;
            this.lblLabel3.Text = "Thành tiền:";
            // 
            // lblLabel2
            // 
            this.lblLabel2.AutoSize = true;
            this.lblLabel2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabel2.ForeColor = System.Drawing.Color.Gray;
            this.lblLabel2.Location = new System.Drawing.Point(533, 22);
            this.lblLabel2.Name = "lblLabel2";
            this.lblLabel2.Size = new System.Drawing.Size(82, 21);
            this.lblLabel2.TabIndex = 7;
            this.lblLabel2.Text = "Giảm giá:";
            // 
            // lblLabel1
            // 
            this.lblLabel1.AutoSize = true;
            this.lblLabel1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabel1.ForeColor = System.Drawing.Color.Gray;
            this.lblLabel1.Location = new System.Drawing.Point(359, 22);
            this.lblLabel1.Name = "lblLabel1";
            this.lblLabel1.Size = new System.Drawing.Size(82, 21);
            this.lblLabel1.TabIndex = 6;
            this.lblLabel1.Text = "Tạm tính:";
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTiet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.ColumnHeadersVisible = false;
            this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTiet.Location = new System.Drawing.Point(10, 209);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.RowHeadersWidth = 62;
            this.dgvChiTiet.RowTemplate.Height = 28;
            this.dgvChiTiet.Size = new System.Drawing.Size(780, 203);
            this.dgvChiTiet.TabIndex = 6;
            // 
            // OrderHistoryCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvChiTiet);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlHeader);
            this.Name = "OrderHistoryCard";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(800, 526);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblMaHD;
        private System.Windows.Forms.Label lblThoiGian;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.TableLayoutPanel pnlInfo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBan;
        private System.Windows.Forms.Label lblTongTienHeader;
        private System.Windows.Forms.Label lblPhuongThuc;
        private System.Windows.Forms.Label lblThuNgan;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblTongCongFooter;
        private System.Windows.Forms.Label lblGiamGia;
        private System.Windows.Forms.Label lblTamTinh;
        private System.Windows.Forms.Label lblLabel3;
        private System.Windows.Forms.Label lblLabel2;
        private System.Windows.Forms.Label lblLabel1;
        private System.Windows.Forms.DataGridView dgvChiTiet;
    }
}
