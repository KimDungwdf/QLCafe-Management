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

            // Thêm padding cho nội dung bên trong không dính vào viền đen
            this.Padding = new Padding(3);
            this.BackColor = Color.White;

            StyleGrid();
            FixAlignment();
        }

        // =============================================================
        // 1. CẤU HÌNH LƯỚI (FIX LỖI CỘT CÁCH XA NHAU)
        // =============================================================
        private void StyleGrid()
        {
            if (dgvChiTiet == null) return;

            dgvChiTiet.AutoGenerateColumns = false;
            dgvChiTiet.BackgroundColor = Color.White;
            dgvChiTiet.BorderStyle = BorderStyle.None;
            dgvChiTiet.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvChiTiet.GridColor = Color.FromArgb(220, 220, 220);
            dgvChiTiet.ColumnHeadersVisible = false;
            dgvChiTiet.RowHeadersVisible = false;
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvChiTiet.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvChiTiet.RowTemplate.Height = 35;
            dgvChiTiet.DefaultCellStyle.Padding = new Padding(5, 0, 5, 0);

            dgvChiTiet.Columns.Clear();

            // --- CHIẾN THUẬT MỚI: DÙNG TỈ LỆ % (FillWeight) ĐỂ CÁC CỘT KHÔNG BỊ ĐẨY XA ---

            // Cột 1: Tên món (Chiếm 45% chiều rộng)
            DataGridViewTextBoxColumn colTen = new DataGridViewTextBoxColumn();
            colTen.DataPropertyName = "TenSanPham";
            colTen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTen.FillWeight = 45; // <--- Giảm cái này xuống để không đẩy cột kia ra xa
            colTen.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvChiTiet.Columns.Add(colTen);

            // Cột 2: Số lượng (Chiếm 15%)
            DataGridViewTextBoxColumn colSL = new DataGridViewTextBoxColumn();
            colSL.DataPropertyName = "SoLuong";
            colSL.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colSL.FillWeight = 15;
            colSL.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colSL.DefaultCellStyle.Format = "x0";
            dgvChiTiet.Columns.Add(colSL);

            // Cột 3: Đơn giá (Chiếm 20%)
            DataGridViewTextBoxColumn colGia = new DataGridViewTextBoxColumn();
            colGia.DataPropertyName = "DonGia";
            colGia.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colGia.FillWeight = 20;
            colGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colGia.DefaultCellStyle.Format = "N0";
            dgvChiTiet.Columns.Add(colGia);

            // Cột 4: Thành tiền (Chiếm 20%)
            DataGridViewTextBoxColumn colTien = new DataGridViewTextBoxColumn();
            colTien.DataPropertyName = "ThanhTien";
            colTien.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTien.FillWeight = 20;
            colTien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colTien.DefaultCellStyle.Format = "N0";
            colTien.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvChiTiet.Columns.Add(colTien);
        }

        // =============================================================
        // 2. VẼ VIỀN ĐEN ĐẬM (FIX LỖI NHÌN KHÔNG RÕ KHỐI)
        // =============================================================
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Vẽ viền ĐEN, độ dày 2px
            int borderThickness = 2;
            Color borderColor = Color.Black; // Hoặc Color.FromArgb(60, 60, 60) nếu muốn đen xám

            using (Pen p = new Pen(borderColor, borderThickness))
            {
                // Vẽ hình chữ nhật bao quanh (trừ đi 1 chút để viền nằm trọn bên trong)
                e.Graphics.DrawRectangle(p,
                    borderThickness / 2,
                    borderThickness / 2,
                    this.Width - borderThickness,
                    this.Height - borderThickness);
            }
        }

        // --- CÁC HÀM LOGIC KHÁC GIỮ NGUYÊN ---
        private void FixAlignment()
        {
            if (pnlInfo != null)
            {
                foreach (Control ctrl in pnlInfo.Controls)
                {
                    if (ctrl is Label lbl)
                    {
                        lbl.TextAlign = ContentAlignment.MiddleLeft;
                        lbl.Dock = DockStyle.Fill;
                    }
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
                lblTrangThai.Text = trangThai;
                if (trangThai.Contains("Đã thanh toán"))
                {
                    lblTrangThai.ForeColor = Color.SeaGreen;
                    lblTrangThai.Text = "● " + trangThai;
                }
                else
                {
                    lblTrangThai.ForeColor = Color.Red;
                    lblTrangThai.Text = "● " + trangThai;
                }
            }
        }

        public void LoadOrderDetails()
        {
            try
            {
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

                    int headerH = pnlHeader != null ? pnlHeader.Height : 50;
                    int infoH = pnlInfo != null ? pnlInfo.Height : 60;
                    int footerH = pnlFooter != null ? pnlFooter.Height : 70;
                    int fixedHeight = headerH + infoH + footerH + 15;

                    int rowHeight = dgvChiTiet.RowTemplate.Height;
                    int gridHeight = (dt.Rows.Count * rowHeight);
                    if (dt.Rows.Count > 0) gridHeight += 10;

                    this.Height = fixedHeight + gridHeight;
                    dgvChiTiet.Height = gridHeight;
                }
            }
            catch (Exception) { }
        }
    }
}