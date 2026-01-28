using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Configuration;
using System.Windows.Forms;

namespace QLCafe.Presentation.Views.Cashier
{
    public partial class ShiftReportForm : Form
    {
        // BIẾN TOÀN CỤC
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["QLCafeConnection"].ConnectionString;
        private DataTable _dtHoaDon; // Cache dữ liệu để xuất Excel

        public ShiftReportForm()
        {
            InitializeComponent();

            // 1. GIAO DIỆN NỀN & VIỀN
            this.BackColor = Color.FromArgb(240, 242, 245);
            try
            {
                if (pnlCardDoanhThu != null) pnlCardDoanhThu.Paint += DrawCardBorder;
                if (pnlCardHoaDon != null) pnlCardHoaDon.Paint += DrawCardBorder;
                if (pnlCardGiamGia != null) pnlCardGiamGia.Paint += DrawCardBorder;
                if (pnlCardTrungBinh != null) pnlCardTrungBinh.Paint += DrawCardBorder;
            }
            catch { }

            // 2. TỰ ĐỘNG GÁN SỰ KIỆN CHO NÚT
            if (btnExportExcel != null) btnExportExcel.Click += btnExportExcel_Click;
            if (btnPrintReport != null) btnPrintReport.Click += btnPrintReport_Click;

            Control btnXem = this.Controls.Find("btnXemBaoCao", true).Length > 0 ? this.Controls.Find("btnXemBaoCao", true)[0] : null;
            if (btnXem == null) btnXem = this.Controls.Find("btnViewReport", true).Length > 0 ? this.Controls.Find("btnViewReport", true)[0] : null;
            if (btnXem != null) btnXem.Click += btnXemBaoCao_Click;

            // 3. CĂN CHỈNH GIAO DIỆN BẢNG DƯỚI (ĐÃ SỬA: THẲNG HÀNG VỚI BẢNG TRÊN)
            // Tìm Panel chứa bảng Top Món
            Control[] pnlTops = this.Controls.Find("pnlTopProducts", true);
            if (pnlTops.Length > 0)
            {
                Panel p = (Panel)pnlTops[0];
                // SỬA Ở ĐÂY: Trái=0, Phải=0 để thẳng hàng. Dưới=20 để thoáng.
                p.Padding = new Padding(0, 0, 0, 20);
            }
            else if (dgvTopMon != null)
            {
                dgvTopMon.Margin = new Padding(0, 0, 0, 20);
            }

            // 4. KHỞI TẠO DỮ LIỆU
            SetupGrids();

            dtpTuNgay.Value = DateTime.Today;
            dtpDenNgay.Value = DateTime.Today;

            LoadCashierList();
            LoadReportData();

            // 5. CĂN CHỈNH FOOTER TỰ ĐỘNG
            this.Shown += (s, e) => UpdateFooterPosition();
            this.SizeChanged += (s, e) => UpdateFooterPosition();
            if (dgvHoaDon != null) dgvHoaDon.ColumnWidthChanged += (s, e) => UpdateFooterPosition();
        }

        // =========================================================
        // PHẦN A: CẤU HÌNH LƯỚI (GRID)
        // =========================================================
        private void SetupGrids()
        {
            // --- 1. BẢNG HÓA ĐƠN (TRÊN) ---
            if (dgvHoaDon != null)
            {
                ConfigureGridStyle(dgvHoaDon);
                dgvHoaDon.Columns.Clear();

                AddGridColumn(dgvHoaDon, "MaHD", "Mã HĐ", 100, DataGridViewContentAlignment.MiddleLeft);
                AddGridColumn(dgvHoaDon, "ThoiGian", "Thời gian", 140, DataGridViewContentAlignment.MiddleLeft);
                AddGridColumn(dgvHoaDon, "Ban", "Bàn", 80, DataGridViewContentAlignment.MiddleCenter);
                AddGridColumn(dgvHoaDon, "TongTienGoc", "Tổng tiền", 110, DataGridViewContentAlignment.MiddleRight, "N0");
                AddGridColumn(dgvHoaDon, "GiamGia", "Giảm giá", 100, DataGridViewContentAlignment.MiddleRight, "N0");

                var colThanhTien = AddGridColumn(dgvHoaDon, "ThanhTien", "Thành tiền", 120, DataGridViewContentAlignment.MiddleRight, "N0");
                colThanhTien.DefaultCellStyle.ForeColor = Color.SeaGreen;

                AddGridColumn(dgvHoaDon, "PhuongThuc", "Phương thức", 110, DataGridViewContentAlignment.MiddleLeft);

                DataGridViewTextBoxColumn colStatus = new DataGridViewTextBoxColumn();
                colStatus.DataPropertyName = "TrangThai";
                colStatus.HeaderText = "Trạng thái";
                colStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colStatus.DefaultCellStyle.ForeColor = Color.Green;
                dgvHoaDon.Columns.Add(colStatus);
            }

            // --- 2. BẢNG TOP MÓN (DƯỚI) ---
            if (dgvTopMon != null)
            {
                ConfigureGridStyle(dgvTopMon);
                dgvTopMon.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(101, 67, 33); // Nâu đậm
                dgvTopMon.Columns.Clear();

                AddGridColumn(dgvTopMon, "STT", "STT", 60, DataGridViewContentAlignment.MiddleCenter);

                // Cột Tên Món tự giãn (Fill) để bảng nhìn thoáng mà vẫn thẳng hàng 2 bên
                var colTen = AddGridColumn(dgvTopMon, "TenSanPham", "Tên sản phẩm", 200, DataGridViewContentAlignment.MiddleLeft);
                colTen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                AddGridColumn(dgvTopMon, "TenDanhMuc", "Danh mục", 150, DataGridViewContentAlignment.MiddleLeft);
                AddGridColumn(dgvTopMon, "SoLuongBan", "SL Bán", 100, DataGridViewContentAlignment.MiddleCenter);
                AddGridColumn(dgvTopMon, "DonGia", "Đơn giá", 120, DataGridViewContentAlignment.MiddleRight, "N0");

                var colDoanhThu = AddGridColumn(dgvTopMon, "DoanhThu", "Doanh thu", 150, DataGridViewContentAlignment.MiddleRight, "N0");
                colDoanhThu.DefaultCellStyle.ForeColor = Color.Brown;
                colDoanhThu.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }
        }

        private void ConfigureGridStyle(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.EnableHeadersVisualStyles = false;

            // Header
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(177, 43, 43);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Row
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.RowTemplate.Height = 35;
            dgv.DefaultCellStyle.SelectionBackColor = Color.White;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private DataGridViewTextBoxColumn AddGridColumn(DataGridView dgv, string dataName, string header, int width, DataGridViewContentAlignment align, string format = "")
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.DataPropertyName = dataName;
            col.HeaderText = header;
            col.Width = width;
            col.DefaultCellStyle.Alignment = align;
            if (!string.IsNullOrEmpty(format)) col.DefaultCellStyle.Format = format;
            dgv.Columns.Add(col);
            return col;
        }

        // =========================================================
        // PHẦN B: LOGIC TẢI DỮ LIỆU
        // =========================================================
        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            LoadReportData();
        }

        private void LoadReportData()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Cursor.Current = Cursors.Default;
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    // 1. LẤY 4 THẺ THỐNG KÊ
                    using (SqlCommand cmd = new SqlCommand("sp_Report_GetOverview", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TuNgay", dtpTuNgay.Value.Date);
                        cmd.Parameters.AddWithValue("@DenNgay", dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1));

                        object userParam = DBNull.Value;
                        if (cboThuNgan != null && cboThuNgan.SelectedValue != null && cboThuNgan.SelectedValue.ToString() != "ALL")
                            userParam = cboThuNgan.SelectedValue.ToString();
                        cmd.Parameters.AddWithValue("@NguoiLap", userParam);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (lblTongDoanhThu != null) lblTongDoanhThu.Text = (reader["TongDoanhThu"] != DBNull.Value ? Convert.ToDecimal(reader["TongDoanhThu"]).ToString("N0") : "0") + " đ";
                                if (lblTongHoaDon != null) lblTongHoaDon.Text = (reader["SoHoaDon"] != DBNull.Value ? reader["SoHoaDon"].ToString() : "0") + " hóa đơn";
                                if (lblTongGiamGia != null) lblTongGiamGia.Text = (reader["TongGiamGia"] != DBNull.Value ? Convert.ToDecimal(reader["TongGiamGia"]).ToString("N0") : "0") + " đ";
                                if (lblTrungBinhDon != null) lblTrungBinhDon.Text = (reader["TrungBinhDon"] != DBNull.Value ? Convert.ToDecimal(reader["TrungBinhDon"]).ToString("N0") : "0") + " đ";
                            }
                        }
                    }

                    // 2. LẤY DANH SÁCH HÓA ĐƠN
                    if (dgvHoaDon != null)
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_Report_GetBillList", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@TuNgay", dtpTuNgay.Value.Date);
                            cmd.Parameters.AddWithValue("@DenNgay", dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1));

                            object userParam = DBNull.Value;
                            if (cboThuNgan != null && cboThuNgan.SelectedValue != null && cboThuNgan.SelectedValue.ToString() != "ALL")
                                userParam = cboThuNgan.SelectedValue.ToString();
                            cmd.Parameters.AddWithValue("@NguoiLap", userParam);

                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            _dtHoaDon = new DataTable();
                            da.Fill(_dtHoaDon);
                            dgvHoaDon.DataSource = _dtHoaDon;

                            // Tính tổng Footer
                            decimal totalGoc = 0, totalGiam = 0, totalThanh = 0;
                            if (_dtHoaDon.Rows.Count > 0)
                            {
                                var sumGoc = _dtHoaDon.Compute("SUM(TongTienGoc)", string.Empty);
                                var sumGiam = _dtHoaDon.Compute("SUM(GiamGia)", string.Empty);
                                var sumThanh = _dtHoaDon.Compute("SUM(ThanhTien)", string.Empty);
                                totalGoc = sumGoc != DBNull.Value ? Convert.ToDecimal(sumGoc) : 0;
                                totalGiam = sumGiam != DBNull.Value ? Convert.ToDecimal(sumGiam) : 0;
                                totalThanh = sumThanh != DBNull.Value ? Convert.ToDecimal(sumThanh) : 0;
                            }

                            if (lblTongTienFooter != null) lblTongTienFooter.Text = totalGoc.ToString("N0") + "đ";
                            if (lblGiamGiaFooter != null) lblGiamGiaFooter.Text = "-" + totalGiam.ToString("N0") + "đ";
                            if (lblThanhTienFooter != null)
                            {
                                lblThanhTienFooter.Text = totalThanh.ToString("N0") + "đ";
                                lblThanhTienFooter.ForeColor = Color.SeaGreen;
                            }
                            UpdateFooterPosition();
                        }
                    }

                    // 3. LẤY TOP SẢN PHẨM
                    if (dgvTopMon != null)
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_Report_GetTopProducts", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@TuNgay", dtpTuNgay.Value.Date);
                            cmd.Parameters.AddWithValue("@DenNgay", dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1));

                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dtTop = new DataTable();
                            da.Fill(dtTop);

                            dtTop.Columns.Add("STT", typeof(int));
                            for (int i = 0; i < dtTop.Rows.Count; i++) dtTop.Rows[i]["STT"] = i + 1;

                            dgvTopMon.DataSource = dtTop;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        // =========================================================
        // PHẦN C: XUẤT EXCEL & IN ẤN
        // =========================================================
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (_dtHoaDon == null || _dtHoaDon.Rows.Count == 0) return;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv";
            sfd.FileName = $"BaoCao_{DateTime.Now:ddMMyyyy}.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Mã HĐ,Thời Gian,Bàn,Tổng tiền gốc,Giảm giá,Thành tiền,Phương thức,Trạng thái");
                    foreach (DataRow row in _dtHoaDon.Rows)
                    {
                        sb.AppendLine($"{row["MaHD"]},{Convert.ToDateTime(row["ThoiGian"]):dd/MM/yyyy HH:mm},{row["Ban"]},{row["TongTienGoc"]},{row["GiamGia"]},{row["ThanhTien"]},{row["PhuongThuc"]},{row["TrangThai"]}");
                    }
                    string tongFooter = lblThanhTienFooter != null ? lblThanhTienFooter.Text.Replace("đ", "").Replace(",", "") : "0";
                    sb.AppendLine($",,,TỔNG CỘNG:,,{tongFooter},,");

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                }
                catch (Exception ex) { MessageBox.Show("Lỗi xuất file: " + ex.Message); }
            }
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (s, args) => {
                Bitmap bmp = new Bitmap(this.Width, this.Height);
                this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
                Rectangle m = args.MarginBounds;
                float ratio = (float)m.Width / (float)bmp.Width;
                args.Graphics.DrawImage(bmp, m.Left, m.Top, m.Width, bmp.Height * ratio);
            };
            PrintDialog dlg = new PrintDialog();
            dlg.Document = pd;
            if (dlg.ShowDialog() == DialogResult.OK) pd.Print();
        }

        private void LoadCashierList()
        {
            try
            {
                if (cboThuNgan == null) return;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT TenDangNhap, TenHienThi FROM TaiKhoan", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    DataRow row = dt.NewRow(); row["TenDangNhap"] = "ALL"; row["TenHienThi"] = "--- Tất cả nhân viên ---";
                    dt.Rows.InsertAt(row, 0);
                    cboThuNgan.DataSource = dt; cboThuNgan.DisplayMember = "TenHienThi"; cboThuNgan.ValueMember = "TenDangNhap";
                }
            }
            catch { }
        }

        private void UpdateFooterPosition()
        {
            if (dgvHoaDon == null || dgvHoaDon.Columns.Count == 0) return;
            void Align(Label lbl, int idx)
            {
                if (lbl == null) return;
                Rectangle r = dgvHoaDon.GetColumnDisplayRectangle(idx, true);
                lbl.Location = new Point(dgvHoaDon.Location.X + r.X, lbl.Location.Y);
                lbl.Width = r.Width;
                lbl.TextAlign = ContentAlignment.MiddleRight;
                lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }
            Align(lblTongTienFooter, 3); Align(lblGiamGiaFooter, 4); Align(lblThanhTienFooter, 5);
        }

        private void DrawCardBorder(object sender, PaintEventArgs e)
        {
            Panel p = (Panel)sender;
            using (Pen pen = new Pen(Color.FromArgb(220, 220, 220), 1))
                e.Graphics.DrawRectangle(pen, 0, 0, p.Width - 1, p.Height - 1);
        }
    }
}