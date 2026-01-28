using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using QLCafe.Presentation.Controls.History; // Namespace chứa UserControl thẻ hóa đơn

namespace QLCafe.Presentation.Views.History
{
    public partial class OrderHistoryForm : Form
    {
        // Chuỗi kết nối lấy từ App.config
        private readonly string _connString = ConfigurationManager.ConnectionStrings["QLCafeConnection"].ConnectionString;

        public OrderHistoryForm()
        {
            InitializeComponent();

            // 1. Cấu hình FlowLayout (Danh sách cuộn)
            if (flowListOrders != null)
            {
                flowListOrders.AutoScroll = true;
                flowListOrders.FlowDirection = FlowDirection.TopDown; // Xếp dọc từ trên xuống
                flowListOrders.WrapContents = false; // Không cho xuống dòng ngang
            }

            // 2. Khởi tạo ngày mặc định (Hôm nay)
            dtpTuNgay.Value = DateTime.Today;
            dtpDenNgay.Value = DateTime.Today;

            // 3. Load dữ liệu vào ComboBox (Bàn, Trạng thái)
            LoadComboBoxData();

            // 4. Gán sự kiện nút bấm
            if (btnTimKiem != null)
                btnTimKiem.Click += (s, e) => LoadOrderHistory();

            // 5. Tự động tải danh sách khi mở form
            this.Load += (s, e) => LoadOrderHistory();

            // 6. Tự động resize thẻ khi kéo giãn cửa sổ
            this.SizeChanged += (s, e) => ResizeCards();
        }

        // =============================================================
        // HÀM 1: ĐỔ DỮ LIỆU VÀO COMBOBOX
        // =============================================================
        private void LoadComboBoxData()
        {
            try
            {
                // Load danh sách Bàn từ Database
                using (SqlConnection conn = new SqlConnection(_connString))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT IDBan, TenBan FROM Ban", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Thêm dòng "Tất cả bàn" lên đầu
                    DataRow row = dt.NewRow();
                    row["TenBan"] = "Tất cả bàn";
                    row["IDBan"] = -1; // Giá trị giả định
                    dt.Rows.InsertAt(row, 0);

                    if (cboBan != null)
                    {
                        cboBan.DataSource = dt;
                        cboBan.DisplayMember = "TenBan";
                        cboBan.ValueMember = "IDBan";
                        cboBan.SelectedIndex = 0;
                    }
                }

                // Load danh sách Trạng thái (Fix cứng)
                if (cboTrangThai != null)
                {
                    cboTrangThai.Items.Clear();
                    cboTrangThai.Items.Add("Tất cả");
                    cboTrangThai.Items.Add("Đã thanh toán");
                    cboTrangThai.Items.Add("Chưa thanh toán"); // (Nếu có tính năng lưu tạm)
                    cboTrangThai.Items.Add("Đã hủy");          // (Nếu có tính năng hủy đơn)
                    cboTrangThai.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                // Bỏ qua lỗi load combobox để không crash form
            }
        }

        // =============================================================
        // HÀM 2: TẢI DANH SÁCH HÓA ĐƠN & TẠO THẺ (CORE)
        // =============================================================
        private void LoadOrderHistory()
        {
            if (flowListOrders == null) return;

            flowListOrders.Controls.Clear(); // Xóa danh sách cũ
            Cursor.Current = Cursors.WaitCursor; // Hiển thị đồng hồ cát

            try
            {
                using (SqlConnection conn = new SqlConnection(_connString))
                {
                    conn.Open();

                    // Gọi Stored Procedure lấy danh sách
                    SqlCommand cmd = new SqlCommand("sp_GetOrderHistory", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Truyền tham số Ngày
                    cmd.Parameters.AddWithValue("@TuNgay", dtpTuNgay.Value.Date);
                    cmd.Parameters.AddWithValue("@DenNgay", dtpDenNgay.Value.Date);

                    // Truyền tham số Bàn
                    if (cboBan != null && cboBan.SelectedIndex > 0)
                        cmd.Parameters.AddWithValue("@TenBan", cboBan.Text);
                    else
                        cmd.Parameters.AddWithValue("@TenBan", DBNull.Value); // Lấy tất cả

                    // Truyền tham số Trạng thái
                    int status = -1; // -1: Tất cả
                    if (cboTrangThai != null)
                    {
                        if (cboTrangThai.Text == "Đã thanh toán") status = 1;
                        else if (cboTrangThai.Text == "Chưa thanh toán") status = 0;
                        else if (cboTrangThai.Text == "Đã hủy") status = 2; // Ví dụ
                    }
                    cmd.Parameters.AddWithValue("@TrangThai", status);

                    // Thực thi và lấy dữ liệu
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // --- VÒNG LẶP TẠO CARD ---
                    // Duyệt qua từng dòng kết quả và tạo UserControl tương ứng
                    foreach (DataRow row in dt.Rows)
                    {
                        OrderHistoryCard card = new OrderHistoryCard();

                        // 1. Gán ID để Card tự biết đường gọi DB lấy chi tiết món ăn
                        card.IDHoaDon = Convert.ToInt32(row["IDHoaDon"]);

                        // 2. Chuẩn bị dữ liệu hiển thị
                        string trangThaiText = "";
                        int trangThaiCode = Convert.ToInt32(row["TrangThai"]);
                        if (trangThaiCode == 1) trangThaiText = "Đã thanh toán";
                        else if (trangThaiCode == 0) trangThaiText = "Chưa thanh toán";
                        else trangThaiText = "Đã hủy";

                        // 3. Đổ dữ liệu vào Card
                        card.SetData(
                            row["MaHD"].ToString(),
                            Convert.ToDateTime(row["NgayLap"]).ToString("dd/MM/yyyy - HH:mm tt"),
                            row["TenBan"].ToString(),
                            row["ThuNgan"].ToString(),
                            row["PhuongThuc"].ToString(),
                            Convert.ToDecimal(row["TamTinh"]),
                            Convert.ToDecimal(row["GiamGia"]),
                            Convert.ToDecimal(row["TongCong"]),
                            trangThaiText
                        );

                        // 4. Kích hoạt Card load danh sách món ăn bên trong
                        card.LoadOrderDetails();

                        // 5. Chỉnh độ rộng Card cho đẹp (Trừ đi 25px để chừa chỗ cho thanh cuộn dọc)
                        card.Width = flowListOrders.Width - 25;

                        // 6. Thêm Card vào danh sách
                        flowListOrders.Controls.Add(card);
                    }

                    // Hiển thị thông báo nếu không có đơn nào
                    if (dt.Rows.Count == 0)
                    {
                        Label lblEmpty = new Label();
                        lblEmpty.Text = "Không tìm thấy hóa đơn nào trong khoảng thời gian này.";
                        lblEmpty.AutoSize = true;
                        lblEmpty.Font = new Font("Segoe UI", 12, FontStyle.Italic);
                        lblEmpty.ForeColor = Color.Gray;
                        lblEmpty.Padding = new Padding(20);
                        flowListOrders.Controls.Add(lblEmpty);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        // =============================================================
        // HÀM 3: TỰ ĐỘNG RESIZE THẺ KHI KÉO CỬA SỔ
        // =============================================================
        private void ResizeCards()
        {
            if (flowListOrders == null) return;

            // Khi form bị kéo giãn, ta cập nhật lại chiều rộng các thẻ bên trong
            foreach (Control ctrl in flowListOrders.Controls)
            {
                if (ctrl is OrderHistoryCard)
                {
                    ctrl.Width = flowListOrders.Width - 25;
                }
            }
        }
    }
}