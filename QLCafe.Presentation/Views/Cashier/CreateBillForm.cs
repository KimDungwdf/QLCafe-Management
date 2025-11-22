using QLCafe.Application.DTOs.Order;
using QLCafe.Application.Interfaces;
using QLCafe.Presentation.Controls.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCafe.Presentation.Views.Cashier
{
    public partial class CreateBillForm : Form
    {
        // --- KHAI BÁO BIẾN ---
        private readonly int _tableId;
        private readonly string _tableName;
        private readonly string _userName;
        private readonly IOrderService _orderService;

        // Biến lưu trữ tính toán
        private decimal _subTotal = 0;      // Tạm tính
        private decimal _discount = 0;      // Giảm giá
        private decimal _finalTotal = 0;    // Tổng cộng cần trả
        private bool _isCashPayment = true; // Trạng thái thanh toán (True=Tiền mặt, False=CK)

        // Cache QR Code (Để đỡ load lại nếu tiền ko đổi)
        private Image _qrImageCache = null;
        private decimal _cachedAmount = -1;

        // --- CONSTRUCTOR (HÀM KHỞI TẠO) ---
        public CreateBillForm(int tableId, string tableName, string userName, IOrderService orderService)
        {
            InitializeComponent();

            _tableId = tableId;
            _tableName = tableName;
            _userName = userName;
            _orderService = orderService;

            // Cài đặt hiển thị ban đầu
            SetupInitialUI();
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.button3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button3.Height = 66;
        }

        private void SetupInitialUI()
        {
            lblTableNameHeader.Text = _tableName;
            lblCashierValue.Text = _userName;
            lblDateValue.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblTimeValue.Text = DateTime.Now.ToString("HH:mm");

            // Tạo mã hóa đơn ảo (Thực tế lấy từ DB sau khi lưu)
            lblBillId.Text = "HD" + DateTime.Now.ToString("yyMMddHHmm");

            // Mặc định chọn Tiền mặt
            SelectPaymentMethod(true);

            // Mặc định giảm giá = 0
            txtGiamGia.Text = "0";
        }

        // --- SỰ KIỆN LOAD FORM ---
        private void CreateBillForm_Load(object sender, EventArgs e)
        {
            LoadOrderDetails();
            AdjustLayout();
        }

        // --- HÀM LOAD DỮ LIỆU TỪ SERVER ---
        private void LoadOrderDetails()
        {
            try
            {
                // 1. Gọi Service lấy thông tin Order
                var order = _orderService.GetCurrentOrderByTable(_tableId);

                if (order == null || order.Items.Count == 0)
                {
                    MessageBox.Show("Bàn này chưa có món nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }

                // 2. Xóa danh sách cũ
                flowBillItems.Controls.Clear();

                // 3. Cập nhật kích thước flowBillItems
                flowBillItems.Width = panelMain.Width - 50; // Trừ margin
                flowBillItems.Height = Math.Max(100, order.Items.Count * 45); // Tự động điều chỉnh chiều cao

                // 4. Duyệt qua từng món
                foreach (var item in order.Items)
                {
                    var rowControl = new BillItemRowControl();
                    rowControl.SetData(item.ProductName, item.Quantity, item.UnitPrice);

                    // QUAN TRỌNG: Đặt chiều rộng cho row control
                    rowControl.Width = flowBillItems.Width - 5; // Trừ scrollbar

                    flowBillItems.Controls.Add(rowControl);
                }

                // 5. Cập nhật số liệu
                _subTotal = order.SubTotal;
                UpdateCalculations();

                // 6. Tự động điều chỉnh vị trí các panel
                AdjustLayout();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdjustLayout()
        {
            // Tính toán vị trí panel3 dựa trên chiều cao thực tế của panelMain
            int panelMainBottom = panelMain.Location.Y + panelMain.Height;

            // Đặt panel3 ngay dưới panelMain với khoảng cách 20px
            panel3.Location = new Point(panelMain.Location.X, panelMainBottom + 20);

            // Tự động điều chỉnh chiều cao Form
            int formHeight = panel3.Location.Y + panel3.Height + 100; // +100 để có padding dưới
            this.ClientSize = new Size(this.ClientSize.Width, Math.Min(formHeight, 1200)); // Giới hạn max height
        }

        // --- HÀM TÍNH TOÁN TIỀN ---
        private void UpdateCalculations()
        {
            // 1. Lấy giá trị giảm giá
            decimal.TryParse(txtGiamGia.Text.Replace(",", ""), out _discount);

            // 2. Tính Tổng cộng
            _finalTotal = _subTotal - _discount;
            if (_finalTotal < 0) _finalTotal = 0;

            // 3. Hiển thị lên giao diện
            lblTamTinh.Text = _subTotal.ToString("N0") + "đ";
            lblTongCong.Text = _finalTotal.ToString("N0") + "đ";

            // 4. Reset Cache QR nếu tổng tiền thay đổi
            if (_finalTotal != _cachedAmount) _qrImageCache = null;

            // 5. Cập nhật lại phần thanh toán (Tiền thừa / QR)
            UpdatePaymentState();
        }

        // --- XỬ LÝ CHUYỂN ĐỔI TIỀN MẶT / CHUYỂN KHOẢN ---
        private void SelectPaymentMethod(bool isCash)
        {
            _isCashPayment = isCash;

            if (_isCashPayment)
            {
                // Giao diện Tiền mặt
                button1.BackColor = Color.FromArgb(230, 247, 255); // Xanh nhạt
                button1.FlatAppearance.BorderColor = Color.SeaGreen;

                button2.BackColor = Color.White;
                button2.FlatAppearance.BorderColor = Color.LightGray;

                panel4.Visible = true; // Hiện khung nhập tiền
                pictureBox1.Visible = false; // Ẩn QR Code

                txtKhachDua.Focus();
            }
            else
            {
                // Giao diện Chuyển khoản
                button2.BackColor = Color.FromArgb(230, 247, 255);
                button2.FlatAppearance.BorderColor = Color.SeaGreen;

                button1.BackColor = Color.White;
                button1.FlatAppearance.BorderColor = Color.LightGray;

                panel4.Visible = false; // Ẩn khung nhập tiền
                pictureBox1.Visible = true; // Hiện QR Code

                LoadVietQR();
            }
            UpdatePaymentState();
        }

        private void UpdatePaymentState()
        {
            if (!_isCashPayment) // Chuyển khoản
            {
                // Mặc định khách trả đủ
                txtKhachDua.Text = _finalTotal.ToString("N0");
            }
            else // Tiền mặt
            {
                // Tính tiền thừa
                decimal khachDua = 0;
                decimal.TryParse(txtKhachDua.Text.Replace(",", ""), out khachDua);

                decimal tienThua = khachDua - _finalTotal;
                label29.Text = tienThua.ToString("N0") + "đ"; // label29 là lblTienThua

                // Đổi màu cảnh báo
                label29.ForeColor = (tienThua < 0) ? Color.Red : Color.SeaGreen;
            }
        }

        // --- HÀM TẠO MÃ QR VIETQR ---
        private void LoadVietQR()
        {
            // Nếu đã có ảnh cache và tiền không đổi -> Dùng lại ảnh cũ cho nhanh
            if (_qrImageCache != null && _cachedAmount == _finalTotal)
            {
                pictureBox1.Image = _qrImageCache;
                return;
            }

            try
            {
                // Cấu hình VietQR
                string bankId = "MB"; // Ngân hàng MB
                string accountNo = "0333666999"; // SỐ TÀI KHOẢN CỦA BẠN
                string template = "compact";
                string content = $"Ban {_tableName}"; // Nội dung CK: Ban 1

                // Link API
                string url = $"https://img.vietqr.io/image/{bankId}-{accountNo}-{template}.png?amount={_finalTotal}&addInfo={content}";

                pictureBox1.Load(url); // Load ảnh từ mạng

                // Lưu Cache
                _qrImageCache = pictureBox1.Image;
                _cachedAmount = _finalTotal;
            }
            catch
            {
                // Lỗi mạng thì thôi, không crash app
            }
        }

        // --- CÁC SỰ KIỆN UI ---

        private void button1_Click(object sender, EventArgs e) // Nút Tiền mặt
        {
            SelectPaymentMethod(true);
        }

        private void button2_Click(object sender, EventArgs e) // Nút Chuyển khoản
        {
            SelectPaymentMethod(false);
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            UpdateCalculations(); // Tính lại tiền khi giảm giá thay đổi
        }

        // Sự kiện nhập tiền khách đưa (Format dấu phẩy và tính tiền thừa)
        private void txtKhachDua_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKhachDua.Text)) return;

            // 1. Lấy vị trí con trỏ hiện tại (để không bị nhảy về đầu)
            int selectionStart = txtKhachDua.SelectionStart;
            int lengthBefore = txtKhachDua.Text.Length;

            // 2. Xóa dấu phẩy cũ để lấy số thô
            string value = txtKhachDua.Text.Replace(",", "");

            if (long.TryParse(value, out long number))
            {
                // 3. Format lại có dấu phẩy
                txtKhachDua.TextChanged -= txtKhachDua_TextChanged; // Tạm tắt sự kiện
                txtKhachDua.Text = string.Format("{0:N0}", number);
                txtKhachDua.TextChanged += txtKhachDua_TextChanged; // Bật lại sự kiện

                // 4. Tính lại vị trí con trỏ (Logic thông minh)
                int lengthAfter = txtKhachDua.Text.Length;
                int newSelection = selectionStart + (lengthAfter - lengthBefore);
                if (newSelection < 0) newSelection = 0;
                txtKhachDua.SelectionStart = newSelection;
            }

            UpdatePaymentState(); // Tính lại tiền thừa
        }

        private void txtKhachDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và phím xóa
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // --- NÚT CHỐT ĐƠN: THANH TOÁN & IN ---
        private void button3_Click(object sender, EventArgs e)
        {
            // 1. Validate (Kiểm tra tiền mặt)
            if (_isCashPayment)
            {
                decimal khachDua = 0;
                decimal.TryParse(txtKhachDua.Text.Replace(",", ""), out khachDua);
                if (khachDua < _finalTotal)
                {
                    MessageBox.Show("Khách đưa chưa đủ tiền!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // 2. Xác định phương thức thanh toán
            string phuongThuc = _isCashPayment ? "Tiền mặt" : "Chuyển khoản";

            // 3. Thực hiện thanh toán
            try
            {
                // Gọi Service với đủ 4 tham số
                bool result = _orderService.Checkout(_tableId, _discount, phuongThuc, _userName);

                if (result)
                {
                    MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Trả về OK để Form cha load lại màu bàn
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thanh toán thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            // Không làm gì cả
        }
    }
}