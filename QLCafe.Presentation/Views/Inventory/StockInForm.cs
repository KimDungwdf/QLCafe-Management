using System;
using System.Collections.Generic;
using System.ComponentModel; // Cần thiết cho BindingList
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace QLCafe.Presentation.Views.Inventory
{
    // 1. CLASS FORM LUÔN ĐỨNG ĐẦU ĐỂ GIỮ ICON DESIGNER
    public partial class StockInForm : Form
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["QLCafeConnection"].ConnectionString;
        private BindingList<ImportItemDto> _cart = new BindingList<ImportItemDto>();

        // Khai báo ô tìm kiếm động
        private TextBox txtSearchGrid;

        public StockInForm()
        {
            InitializeComponent();
            this.ResizeRedraw = true;

            // Khởi tạo ô tìm kiếm TRƯỚC khi StyleUI
            InitializeDynamicSearchBox();

            StyleUI();

            this.Load += StockInForm_Load;
            cboNhaCungCap.SelectedIndexChanged += CboNhaCungCap_SelectedIndexChanged;
            cboNguyenLieu.SelectedIndexChanged += CboNguyenLieu_SelectedIndexChanged;
            txtSoLuong.KeyPress += OnlyAllowNumbers;
            txtDonGia.KeyPress += OnlyAllowNumbers;

            btnAdd.Click += BtnAdd_Click;
            btnRefresh.Click += (s, e) => ResetInput();
            btnCancel.Click += BtnCancel_Click;
            btnSave.Click += BtnSave_Click;

            dgvChiTietNhap.CellContentClick += dgvChiTietNhap_CellContentClick;
        }

        // =============================================================
        // TẠO Ô TÌM KIẾM (FIX LỖI FONT & VỊ TRÍ)
        // =============================================================
        private void InitializeDynamicSearchBox()
        {
            txtSearchGrid = new TextBox();
            txtSearchGrid.Size = new Size(250, 25);
            // Sửa lỗi CS1061: Khởi tạo Font mới
            txtSearchGrid.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            txtSearchGrid.ForeColor = Color.Gray;
            txtSearchGrid.Text = "🔍 Tìm tên nguyên liệu...";

            // Đặt kế bên tiêu đề (X=230) và phía trên bảng (Y=12)
            txtSearchGrid.Location = new Point(230, 12);

            // Placeholder logic
            txtSearchGrid.Enter += (s, e) => {
                if (txtSearchGrid.Text.Contains("🔍"))
                {
                    txtSearchGrid.Text = "";
                    txtSearchGrid.ForeColor = Color.Black;
                    txtSearchGrid.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                }
            };
            txtSearchGrid.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtSearchGrid.Text))
                {
                    txtSearchGrid.Text = "🔍 Tìm tên nguyên liệu...";
                    txtSearchGrid.ForeColor = Color.Gray;
                    txtSearchGrid.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
                }
            };

            txtSearchGrid.TextChanged += TxtSearchGrid_TextChanged;
            pnlGrid.Controls.Add(txtSearchGrid);
            txtSearchGrid.BringToFront();
        }

        private void TxtSearchGrid_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearchGrid.Text.ToLower();
            if (keyword.Contains("🔍") || dgvChiTietNhap.DataSource == null) return;

            // Sử dụng CurrencyManager để ẩn dòng an toàn
            CurrencyManager cm = (CurrencyManager)BindingContext[dgvChiTietNhap.DataSource];
            cm.SuspendBinding();
            foreach (DataGridViewRow row in dgvChiTietNhap.Rows)
            {
                var item = row.DataBoundItem as ImportItemDto;
                if (item != null) row.Visible = item.TenNguyenLieu.ToLower().Contains(keyword);
            }
            cm.ResumeBinding();
        }

        private void StockInForm_Load(object sender, EventArgs e)
        {
            LoadInitialData();
            ConfigGridView();
            dgvChiTietNhap.DataSource = _cart;
        }

        // =============================================================
        // PHẦN 1: CẤU HÌNH LƯỚI (FIX LỆCH & KÉO DÃN)
        // =============================================================
        private void ConfigGridView()
        {
            dgvChiTietNhap.AutoGenerateColumns = false;
            dgvChiTietNhap.Columns.Clear();
            dgvChiTietNhap.BackgroundColor = Color.White;
            dgvChiTietNhap.BorderStyle = BorderStyle.None;
            dgvChiTietNhap.RowHeadersVisible = false;
            dgvChiTietNhap.AllowUserToAddRows = false;
            dgvChiTietNhap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvChiTietNhap.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvChiTietNhap.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvChiTietNhap.RowTemplate.Height = 40;

            dgvChiTietNhap.EnableHeadersVisualStyles = false;
            dgvChiTietNhap.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(120, 53, 15);
            dgvChiTietNhap.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvChiTietNhap.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvChiTietNhap.ColumnHeadersHeight = 45;

            // Fix lệch: Header và Cell cùng căn lề
            AddTextCol("STT", "STT", 60, DataGridViewContentAlignment.MiddleCenter);
            AddTextCol("TenNguyenLieu", "Tên nguyên liệu", 200, DataGridViewContentAlignment.MiddleLeft, true, "", true);
            AddTextCol("DonViTinh", "Đơn vị", 100, DataGridViewContentAlignment.MiddleCenter);
            AddTextCol("SoLuong", "Số lượng", 100, DataGridViewContentAlignment.MiddleCenter, false, "N0");
            AddTextCol("DonGia", "Đơn giá", 140, DataGridViewContentAlignment.MiddleRight, false, "N0");
            AddTextCol("ThanhTien", "Thành tiền", 160, DataGridViewContentAlignment.MiddleRight, true, "N0");

            DataGridViewButtonColumn btnDel = new DataGridViewButtonColumn();
            btnDel.Name = "Action"; btnDel.HeaderText = "Thao tác"; btnDel.Text = "🗑 Xóa";
            btnDel.UseColumnTextForButtonValue = true; btnDel.FlatStyle = FlatStyle.Flat; btnDel.Width = 100;
            btnDel.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            btnDel.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            btnDel.DefaultCellStyle.BackColor = Color.FromArgb(220, 53, 69);
            btnDel.DefaultCellStyle.ForeColor = Color.White;
            btnDel.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 53, 69);
            dgvChiTietNhap.Columns.Add(btnDel);
        }

        private void AddTextCol(string prop, string head, int w, DataGridViewContentAlignment align, bool isBold = false, string fmt = "", bool isFill = false)
        {
            var col = new DataGridViewTextBoxColumn { DataPropertyName = prop, HeaderText = head, Width = w };
            col.HeaderCell.Style.Alignment = align;
            col.DefaultCellStyle.Alignment = align;
            if (isBold) col.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            if (fmt != "") col.DefaultCellStyle.Format = fmt;
            if (isFill) col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvChiTietNhap.Columns.Add(col);
        }

        // =============================================================
        // PHẦN 2: NGHIỆP VỤ (LƯU, HỦY, XÓA)
        // =============================================================
        private void CboNguyenLieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNguyenLieu.SelectedIndex != -1 && cboNguyenLieu.SelectedValue is int idNL)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(_connectionString))
                    {
                        conn.Open();
                        string sql = "SELECT TOP 1 DonGiaNhap FROM ChiTietPhieuNhap WHERE IDNguyenLieu = @id ORDER BY IDChiTietPN DESC";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", idNL);
                        object result = cmd.ExecuteScalar();
                        if (result != null) txtDonGia.Text = Convert.ToDecimal(result).ToString("0");
                        else txtDonGia.Clear();
                    }
                }
                catch { txtDonGia.Clear(); }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (cboNguyenLieu.SelectedIndex == -1 || string.IsNullOrEmpty(txtSoLuong.Text)) return;
            DataRowView row = cboNguyenLieu.SelectedItem as DataRowView;
            string realUnit = row["TenDVT"].ToString();

            int id = (int)cboNguyenLieu.SelectedValue;
            decimal sl = decimal.Parse(txtSoLuong.Text);
            decimal gia = decimal.Parse(txtDonGia.Text);

            var item = _cart.FirstOrDefault(x => x.IDNguyenLieu == id);
            if (item != null) { item.SoLuong += sl; item.DonGia = gia; }
            else { _cart.Add(new ImportItemDto { IDNguyenLieu = id, TenNguyenLieu = cboNguyenLieu.Text, DonViTinh = realUnit, SoLuong = sl, DonGia = gia }); }

            UpdateSummary();
            ResetInput();
        }

        private void dgvChiTietNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvChiTietNhap.Columns[e.ColumnIndex].Name == "Action")
            {
                _cart.RemoveAt(e.RowIndex);
                UpdateSummary();
            }
        }

        private void UpdateSummary()
        {
            for (int i = 0; i < dgvChiTietNhap.Rows.Count; i++)
                dgvChiTietNhap.Rows[i].Cells[0].Value = i + 1;

            lblTongMatHang.Text = _cart.Count.ToString();
            lblTongSoLuong.Text = _cart.Sum(x => x.SoLuong).ToString("N0");
            lblTongTien.Text = _cart.Sum(x => x.ThanhTien).ToString("N0") + " đ";
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (_cart.Count > 0 && MessageBox.Show("Hủy phiếu đang nhập?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            _cart.Clear();
            UpdateSummary();
            cboNhaCungCap.SelectedIndex = -1;
            txtInfoNCC.Clear();
            ResetInput();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cboNhaCungCap.SelectedIndex == -1) { MessageBox.Show("Vui lòng chọn Nhà cung cấp!"); return; }
            if (_cart.Count == 0) return;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    SqlCommand cmdH = new SqlCommand("sp_CreateStockIn", conn, trans) { CommandType = CommandType.StoredProcedure };
                    cmdH.Parameters.AddWithValue("@IDNhaCungCap", cboNhaCungCap.SelectedValue);
                    cmdH.Parameters.AddWithValue("@TenDangNhap", QLCafe.Shared.SessionManager.UserName);
                    int idPhieu = Convert.ToInt32(cmdH.ExecuteScalar());

                    foreach (var item in _cart)
                    {
                        SqlCommand cmdD = new SqlCommand("sp_AddStockInDetail", conn, trans) { CommandType = CommandType.StoredProcedure };
                        cmdD.Parameters.AddWithValue("@IDPhieuNhap", idPhieu);
                        cmdD.Parameters.AddWithValue("@IDNguyenLieu", item.IDNguyenLieu);
                        cmdD.Parameters.AddWithValue("@SoLuongNhap", item.SoLuong);
                        cmdD.Parameters.AddWithValue("@DonGiaNhap", item.DonGia);
                        cmdD.ExecuteNonQuery();
                    }
                    trans.Commit();
                    MessageBox.Show("✅ Đã lưu phiếu thành công!");
                    _cart.Clear(); UpdateSummary(); cboNhaCungCap.SelectedIndex = -1; txtInfoNCC.Clear();
                }
                catch (Exception ex) { trans.Rollback(); MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        // =============================================================
        // PHẦN 3: TRANG TRÍ GIAO DIỆN (FIX ĐÈ LƯỚI)
        // =============================================================
        private void StyleUI()
        {
            this.BackColor = Color.FromArgb(240, 242, 245);
            this.Padding = new Padding(20);
            DrawBorderForPanel(pnlInfo);
            DrawBorderForPanel(pnlInput);
            DrawBorderForPanel(pnlSummary);
            DrawSummaryBox(pnlItemCount);
            DrawSummaryBox(pnlTotalQty);
            DrawSummaryBox(pnlTotalAmount);

            // TIÊU ĐỀ: Đặt Padding top là 60 để không bị ô tìm kiếm đè bảng
            DecoratePanelWithTitle(pnlGrid, "📄 Chi Tiết Phiếu Nhập");
        }

        private void DrawSummaryBox(Panel p)
        {
            if (p == null) return;
            p.BackColor = Color.FromArgb(250, 250, 250);
            p.Paint += (s, e) => {
                e.Graphics.DrawRectangle(new Pen(Color.LightGray), 0, 0, p.Width - 1, p.Height - 1);
                using (Brush b = new SolidBrush(Color.FromArgb(120, 53, 15)))
                { e.Graphics.FillRectangle(b, 0, 10, 4, p.Height - 20); }
            };
            p.Resize += (s, e) => p.Invalidate();
        }

        private void DrawBorderForPanel(Panel p)
        {
            if (p == null) return;
            p.BackColor = Color.White;
            p.Paint += (s, e) => e.Graphics.DrawRectangle(new Pen(Color.LightGray), 0, 0, p.Width - 1, p.Height - 1);
            p.Resize += (s, e) => p.Invalidate();
        }

        private void DecoratePanelWithTitle(Panel pnl, string title)
        {
            if (pnl == null) return;
            pnl.BackColor = Color.White;
            // Tăng padding top lên 60px để tạo khoảng trống cho ô tìm kiếm
            pnl.Padding = new Padding(20, 60, 20, 20);
            pnl.Paint += (s, e) => {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Font font = new Font("Segoe UI", 12, FontStyle.Bold))
                using (Brush brush = new SolidBrush(Color.FromArgb(120, 53, 15)))
                {
                    g.DrawString(title, font, brush, 20, 15);
                    g.DrawLine(new Pen(Color.FromArgb(120, 53, 15), 2), 20, 42, pnl.Width - 20, 42);
                }
                g.DrawRectangle(new Pen(Color.LightGray), 0, 0, pnl.Width - 1, pnl.Height - 1);
            };
            pnl.Resize += (s, e) => pnl.Invalidate();
        }

        private void LoadInitialData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlDataAdapter daNCC = new SqlDataAdapter("SELECT IDNhaCungCap, TenNCC, DienThoai, DiaChi FROM NhaCungCap", conn);
                    DataTable dtNCC = new DataTable(); daNCC.Fill(dtNCC);
                    cboNhaCungCap.DataSource = dtNCC; cboNhaCungCap.DisplayMember = "TenNCC"; cboNhaCungCap.ValueMember = "IDNhaCungCap"; cboNhaCungCap.SelectedIndex = -1;

                    string sqlNL = "SELECT nl.IDNguyenLieu, nl.TenNguyenLieu, dvt.TenDVT FROM NguyenLieu nl JOIN DonViTinh dvt ON nl.IDDonViTinh = dvt.IDDonViTinh";
                    SqlDataAdapter daNL = new SqlDataAdapter(sqlNL, conn);
                    DataTable dtNL = new DataTable(); daNL.Fill(dtNL);
                    cboNguyenLieu.DataSource = dtNL; cboNguyenLieu.DisplayMember = "TenNguyenLieu"; cboNguyenLieu.ValueMember = "IDNguyenLieu"; cboNguyenLieu.SelectedIndex = -1;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void CboNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNhaCungCap.SelectedIndex != -1)
            {
                DataRowView row = cboNhaCungCap.SelectedItem as DataRowView;
                txtInfoNCC.Text = $"📞 SĐT: {row["DienThoai"]} - 🏠 ĐC: {row["DiaChi"]}";
            }
            else txtInfoNCC.Clear();
        }

        private void OnlyAllowNumbers(object s, KeyPressEventArgs e) { if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.') e.Handled = true; }

        private void ResetInput() { cboNguyenLieu.SelectedIndex = -1; txtSoLuong.Clear(); txtDonGia.Clear(); cboNguyenLieu.Focus(); }
    }

    // 2. LỚP DTO ĐƯA XUỐNG DƯỚI CÙNG
    public class ImportItemDto
    {
        public int IDNguyenLieu { get; set; }
        public string TenNguyenLieu { get; set; }
        public string DonViTinh { get; set; }
        public decimal SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien => SoLuong * DonGia;
    }
}