using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;

namespace QLCafe.Presentation.Controls.History
{
    public partial class OrderHistoryCard : UserControl
    {
        private readonly string _connString = ConfigurationManager.ConnectionStrings["QLCafeConnection"].ConnectionString;
        public int IDHoaDon { get; set; }

        public OrderHistoryCard()
        {
            InitializeComponent();

            // Padding nội dung bên trong để không đè lên viền đen
            this.Padding = new Padding(3);
            this.BackColor = Color.White;

            StyleGrid();
            FixAlignment();
        }

        // =============================================================
        // 1. CẤU HÌNH LƯỚI (ĐÃ SỬA: Kéo Tên món và SL lại gần nhau)
        // =============================================================
        private void StyleGrid()
        {
            if (dgvChiTiet == null) return;

            dgvChiTiet.AutoGenerateColumns = false;
            dgvChiTiet.BackgroundColor = Color.White;
            dgvChiTiet.BorderStyle = BorderStyle.None;
            dgvChiTiet.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvChiTiet.GridColor = Color.FromArgb(220, 220, 220); // Kẻ ngang mờ
            dgvChiTiet.ColumnHeadersVisible = false;
            dgvChiTiet.RowHeadersVisible = false;
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvChiTiet.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvChiTiet.RowTemplate.Height = 35;
            dgvChiTiet.DefaultCellStyle.Padding = new Padding(5, 0, 5, 0);

            dgvChiTiet.Columns.Clear();

            // --- CHIẾN THUẬT: CỐ ĐỊNH CHIỀU RỘNG CÁC CỘT SỐ ---

            // Cột 1: Tên món (AutoSizeMode = Fill) -> Nó sẽ chiếm hết khoảng trống còn lại
            DataGridViewTextBoxColumn colTen = new DataGridViewTextBoxColumn();
            colTen.DataPropertyName = "TenSanPham";
            colTen.HeaderText = "Tên món";
            colTen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTen.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvChiTiet.Columns.Add(colTen);

            // Cột 2: Số lượng (Cố định 60px) -> Không bị chạy lung tung
            DataGridViewTextBoxColumn colSL = new DataGridViewTextBoxColumn();
            colSL.DataPropertyName = "SoLuong";
            colSL.HeaderText = "SL";
            colSL.Width = 60; // Cố định
            colSL.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colSL.DefaultCellStyle.Format = "x0";
            dgvChiTiet.Columns.Add(colSL);

            // Cột 3: Đơn giá (Cố định 100px)
            DataGridViewTextBoxColumn colGia = new DataGridViewTextBoxColumn();
            colGia.DataPropertyName = "DonGia";
            colGia.HeaderText = "Đơn giá";
            colGia.Width = 100;
            colGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colGia.DefaultCellStyle.Format = "N0";
            dgvChiTiet.Columns.Add(colGia);

            // Cột 4: Thành tiền (Cố định 120px)
            DataGridViewTextBoxColumn colTien = new DataGridViewTextBoxColumn();
            colTien.DataPropertyName = "ThanhTien";
            colTien.HeaderText = "Thành tiền";
            colTien.Width = 120;
            colTien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colTien.DefaultCellStyle.Format = "N0";
            colTien.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvChiTiet.Columns.Add(colTien);
        }

        // =============================================================
        // 2. VẼ VIỀN ĐEN ĐẬM (Theo yêu cầu)
        // =============================================================
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Viền ĐEN, dày 2px
            int size = 2;
            using (Pen p = new Pen(Color.Black, size))
            {
                // Vẽ lùi vào trong một chút để không bị mất nét
                e.Graphics.DrawRectangle(p, size / 2, size / 2, this.Width - size, this.Height - size);
            }
        }

        // =============================================================
        // 3. LOAD DATA & BẮT NGOẠI LỆ KỸ CÀNG
        // =============================================================
        public void LoadOrderDetails()
        {
            try
            {
                if (this.IDHoaDon <= 0) return; // ID không hợp lệ thì thoát luôn

                using (SqlConnection conn = new SqlConnection(_connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_GetOrderHistoryDetails", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDHoaDon", this.IDHoaDon);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvChiTiet.DataSource = dt;

                    // --- Tính toán chiều cao ---
                    int headerH = pnlHeader != null ? pnlHeader.Height : 50;
                    int infoH = pnlInfo != null ? pnlInfo.Height : 60;
                    int footerH = pnlFooter != null ? pnlFooter.Height : 70;
                    int fixedHeight = headerH + infoH + footerH + 20;

                    int rowHeight = dgvChiTiet.RowTemplate.Height;
                    int gridHeight = (dt.Rows.Count * rowHeight);
                    if (dt.Rows.Count > 0) gridHeight += 10; // Padding lưới

                    this.Height = fixedHeight + gridHeight;
                    dgvChiTiet.Height = gridHeight;
                }
            }
            catch (Exception ex)
            {
                // Nếu lỗi: Có thể hiện 1 dòng thông báo trong grid hoặc để trống
                // Không nên MessageBox ở đây vì nếu load 100 thẻ lỗi sẽ hiện 100 cái Popup
            }
        }

        // --- CÁC HÀM KHÁC GIỮ NGUYÊN ---
        private void FixAlignment()
        {
            if (pnlInfo != null)
            {
                foreach (Control ctrl in pnlInfo.Controls)
                {
                    if (ctrl is Label lbl) { lbl.TextAlign = ContentAlignment.MiddleLeft; lbl.Dock = DockStyle.Fill; }
                }
            }
            if (lblTrangThai != null) lblTrangThai.TextAlign = ContentAlignment.MiddleRight;
        }

        public void SetData(string maHD, string thoiGian, string ban, string thuNgan, string phuongThuc, decimal tamTinh, decimal giamGia, decimal tongCong, string trangThai)
        {
            if (lblMaHD != null) lblMaHD.Text = maHD;
            if (lblThoiGian != null) lblThoiGian.Text = thoiGian;
            if (lblBan != null) lblBan.Text = ban;
            if (lblThuNgan != null) lblThuNgan.Text = thuNgan;
            if (lblPhuongThuc != null) lblPhuongThuc.Text = phuongThuc;

            if (lblTongTienHeader != null)
            {
                lblTongTienHeader.Text = tongCong.ToString("N0") + "đ";
                lblTongTienHeader.ForeColor = Color.SeaGreen;
            }

            if (lblTamTinh != null) lblTamTinh.Text = tamTinh.ToString("N0") + "đ";
            if (lblGiamGia != null) lblGiamGia.Text = "-" + giamGia.ToString("N0") + "đ";
            if (lblTongCongFooter != null) lblTongCongFooter.Text = tongCong.ToString("N0") + "đ";

            if (lblTrangThai != null)
            {
                lblTrangThai.Text = trangThai.Contains("Đã") ? "● " + trangThai : trangThai;
                lblTrangThai.ForeColor = trangThai.Contains("Đã") ? Color.SeaGreen : Color.Red;
            }
        }
    }
}