using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using QLCafe.Presentation.Controls.History; // Namespace chứa thẻ hóa đơn (UserControl)

namespace QLCafe.Presentation.Views.History
{
    public partial class OrderHistoryForm : Form
    {
        // Lấy chuỗi kết nối từ file config
        private readonly string _connString = ConfigurationManager.ConnectionStrings["QLCafeConnection"].ConnectionString;

        public OrderHistoryForm()
        {
            InitializeComponent();

            // 1. Cấu hình FlowLayout (Danh sách cuộn)
            if (flowListOrders != null)
            {
                flowListOrders.AutoScroll = true;
                flowListOrders.FlowDirection = FlowDirection.TopDown; // Xếp dọc từ trên xuống
                flowListOrders.WrapContents = false; // Không cho xuống dòng ngang (để thẻ dài hết cỡ)
            }

            // 2. Khởi tạo ngày mặc định
            // Mẹo: Để ngày bắt đầu là đầu tháng để dễ nhìn thấy dữ liệu
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Today;

            // 3. Tải dữ liệu vào các ComboBox
            LoadComboBoxData();

            // 4. Gán sự kiện cho nút Tìm kiếm
            if (btnTimKiem != null)
            {
                btnTimKiem.Click += (s, e) => LoadOrderHistory();
            }

            // 5. Tự động tải danh sách khi mở form
            this.Load += (s, e) => LoadOrderHistory();

            // 6. Tự động chỉnh lại chiều rộng thẻ khi người dùng kéo giãn cửa sổ
            this.SizeChanged += (s, e) => ResizeCards();
        }

        // =============================================================
        // HÀM 1: ĐỔ DỮ LIỆU VÀO COMBOBOX (BÀN & TRẠNG THÁI)
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
                    row["IDBan"] = -1;
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
                    cboTrangThai.Items.Add("Tất cả");           // Giá trị -1
                    cboTrangThai.Items.Add("Đã thanh toán");    // Giá trị 1
                    cboTrangThai.Items.Add("Chưa thanh toán");  // Giá trị 0
                    cboTrangThai.Items.Add("Đã hủy");           // Giá trị 2 (nếu có)
                    cboTrangThai.SelectedIndex = 0;
                }
            }
            catch (Exception)
            {
                // Bỏ qua lỗi load combobox
            }
        }

        // =============================================================
        // HÀM 2: TẢI DANH SÁCH HÓA ĐƠN & TẠO THẺ (CORE LOGIC)
        // =============================================================
        private void LoadOrderHistory()
        {
            // --- 1. Validate Ngày tháng ---
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (flowListOrders == null) return;

            // Xóa danh sách cũ
            flowListOrders.Controls.Clear();
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                using (SqlConnection conn = new SqlConnection(_connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_GetOrderHistory", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // --- TRUYỀN THAM SỐ SQL ---
                    cmd.Parameters.AddWithValue("@TuNgay", dtpTuNgay.Value.Date);
                    cmd.Parameters.AddWithValue("@DenNgay", dtpDenNgay.Value.Date);

                    // Tham số Bàn
                    if (cboBan != null && cboBan.SelectedIndex > 0)
                        cmd.Parameters.AddWithValue("@TenBan", cboBan.Text);
                    else
                        cmd.Parameters.AddWithValue("@TenBan", DBNull.Value); // Lấy tất cả

                    // Tham số Trạng thái
                    int status = -1; // Mặc định lấy tất cả
                    if (cboTrangThai != null)
                    {
                        string selectedStatus = cboTrangThai.Text;
                        if (selectedStatus == "Đã thanh toán") status = 1;
                        else if (selectedStatus == "Chưa thanh toán") status = 0;
                        else if (selectedStatus == "Đã hủy") status = 2;
                    }
                    cmd.Parameters.AddWithValue("@TrangThai", status);

                    // Lấy dữ liệu
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // --- VÒNG LẶP TẠO THẺ (OrderHistoryCard) ---
                    foreach (DataRow row in dt.Rows)
                    {
                        OrderHistoryCard card = new OrderHistoryCard();

                        // 1. Gán ID (để thẻ tự load chi tiết món ăn)
                        card.IDHoaDon = Convert.ToInt32(row["IDHoaDon"]);

                        // 2. Xử lý text trạng thái
                        string trangThaiText = "";
                        int trangThaiCode = Convert.ToInt32(row["TrangThai"]);

                        if (trangThaiCode == 1) trangThaiText = "Đã thanh toán";
                        else if (trangThaiCode == 0) trangThaiText = "Chưa thanh toán";
                        else trangThaiText = "Đã hủy";

                        // 3. Đổ dữ liệu hiển thị lên thẻ
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

                        // 4. Kích hoạt thẻ load chi tiết món ăn từ DB
                        card.LoadOrderDetails();

                        // 5. Căn chỉnh giao diện thẻ
                        // Chiều rộng = Chiều rộng khung chứa - 25 (trừ hao thanh cuộn dọc)
                        card.Width = flowListOrders.Width - 25;

                        // QUAN TRỌNG: Tạo khoảng cách giữa các thẻ (Margin Bottom = 30)
                        card.Margin = new Padding(0, 0, 0, 30);

                        // 6. Thêm vào danh sách
                        flowListOrders.Controls.Add(card);
                    }

                    // --- HIỂN THỊ THÔNG BÁO NẾU KHÔNG CÓ DỮ LIỆU ---
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

            // Khi người dùng phóng to/thu nhỏ cửa sổ, cập nhật lại chiều rộng thẻ
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