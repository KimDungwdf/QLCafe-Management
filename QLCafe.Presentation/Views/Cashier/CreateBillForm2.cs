using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QLCafe.Application.Interfaces;
using QLCafe.Application.DTOs.Order;

namespace QLCafe.Presentation.Views.Cashier
{
    public partial class CreateBillForm2 : Form
    {
        // ==========================================
        // 1. KHAI BÁO BIẾN TOÀN CỤC
        // ==========================================
        private int _tableId;
        private string _tableName;
        private string _user;
        private IOrderService _orderService;

        private decimal _currentOrderSubTotal = 0;
        private string _paymentMethod = "Tiền mặt";

        // ==========================================
        // 2. HÀM KHỞI TẠO (CONSTRUCTOR)
        // ==========================================
        public CreateBillForm2(int tableId, string tableName, string user, IOrderService orderService)
        {
            InitializeComponent();

            // -----------------------------------------------------------
            // A. CẤU HÌNH LƯỚI BẰNG CODE (SỬA LỖI HIỂN THỊ 100%)
            // -----------------------------------------------------------
            SetupGrid();

            // -----------------------------------------------------------
            // B. NỐI SỰ KIỆN NÚT BẤM THỦ CÔNG (CHỐNG LỖI BẤM KO ĂN)
            // -----------------------------------------------------------
            this.btnConfirmCheckout.Click += new EventHandler(this.btnConfirmCheckout_Click);
            this.btnPrintInvoice.Click += new EventHandler(this.btnPrintInvoice_Click);

            this.btnCash.Click += new EventHandler(this.PaymentMethod_Click);
            this.btnCard.Click += new EventHandler(this.PaymentMethod_Click);
            this.btnMomo.Click += new EventHandler(this.PaymentMethod_Click);
            this.btnBank.Click += new EventHandler(this.PaymentMethod_Click);

            this.txtDiscountInput.TextChanged += new EventHandler(this.txtDiscountInput_TextChanged);

            // Sự kiện vẽ viền nét đứt (Kiểm tra tên Panel trong Designer của bạn)
            if (this.pnlDiscountInputBorder != null)
                this.pnlDiscountInputBorder.Paint += new PaintEventHandler(this.pnlDiscountInputBorder_Paint);

            // Tìm panel chứa các nút thanh toán (thường là panel1 hoặc pnlPayment)
            // Bạn có thể bỏ qua dòng này nếu đã gán trong Designer, hoặc uncomment nếu cần
            // this.panel1.Paint += new PaintEventHandler(this.panel1_Paint); 

            // -----------------------------------------------------------
            // C. KHỞI TẠO DỮ LIỆU
            // -----------------------------------------------------------
            this._tableId = tableId;
            this._tableName = tableName;
            this._user = user;
            this._orderService = orderService;

            lblTableName.Text = tableName;
            lblCashierName.Text = user;
            lblDateValue.Text = DateTime.Now.ToString("HH:mm dd/MM/yyyy");

            LoadBillData();
        }

        // ==========================================
        // 3. HÀM SETUP GRID (THUỐC ĐẶC TRỊ HIỂN THỊ)
        // ==========================================
        private void SetupGrid()
        {
            // Reset sạch sẽ lưới
            dgvItems.AutoGenerateColumns = false;
            dgvItems.Columns.Clear();
            dgvItems.ScrollBars = ScrollBars.None; // Tắt thanh cuộn
            dgvItems.ColumnHeadersVisible = false; // Ẩn tiêu đề (vì đã có Label bên ngoài)
            dgvItems.RowHeadersVisible = false;
            dgvItems.BackgroundColor = Color.White;
            dgvItems.BorderStyle = BorderStyle.None;
            dgvItems.CellBorderStyle = DataGridViewCellBorderStyle.None;

            // Cột 1: Tên món
            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
            colName.DataPropertyName = "ProductName"; // Khớp với OrderItemDto
            colName.HeaderText = "Tên món";
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Tự giãn
            colName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvItems.Columns.Add(colName);

            // Cột 2: SL
            DataGridViewTextBoxColumn colQty = new DataGridViewTextBoxColumn();
            colQty.DataPropertyName = "Quantity";
            colQty.HeaderText = "SL";
            colQty.Width = 35;
            colQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvItems.Columns.Add(colQty);

            // Cột 3: Đơn giá
            DataGridViewTextBoxColumn colPrice = new DataGridViewTextBoxColumn();
            colPrice.DataPropertyName = "UnitPrice";
            colPrice.HeaderText = "Đơn giá";
            colPrice.Width = 70;
            colPrice.DefaultCellStyle.Format = "N0";
            colPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvItems.Columns.Add(colPrice);

            // Cột 4: Thành tiền
            DataGridViewTextBoxColumn colTotal = new DataGridViewTextBoxColumn();
            colTotal.DataPropertyName = "Total";
            colTotal.HeaderText = "Thành tiền";
            colTotal.Width = 85;
            colTotal.DefaultCellStyle.Format = "N0";
            colTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colTotal.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvItems.Columns.Add(colTotal);
        }

        // ==========================================
        // 4. LOGIC TẢI DỮ LIỆU & TÍNH TOÁN
        // ==========================================
        private void LoadBillData()
        {
            try
            {
                var orderDto = _orderService.GetCurrentOrderByTable(_tableId);

                if (orderDto != null && orderDto.Items != null)
                {
                    dgvItems.DataSource = orderDto.Items.ToList();

                    // Tự động giãn chiều cao Grid theo số lượng món
                    int rowHeight = dgvItems.RowTemplate.Height;
                    // Cộng thêm một chút padding dưới cùng
                    dgvItems.Height = (dgvItems.Rows.Count * rowHeight) + 10;
                    lblBillId.Text = $"#HD{orderDto.Id.ToString("D6")}";
                    _currentOrderSubTotal = orderDto.SubTotal;
                    lblSubTotalValue.Text = _currentOrderSubTotal.ToString("N0") + "đ";

                    UpdateFinalTotal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void txtDiscountInput_TextChanged(object sender, EventArgs e)
        {
            UpdateFinalTotal();
        }

        private void UpdateFinalTotal()
        {
            decimal manualDiscount = 0;
            // Chặn số âm
            if (decimal.TryParse(txtDiscountInput.Text, out manualDiscount))
            {
                if (manualDiscount < 0)
                {
                    MessageBox.Show("Không được nhập số tiền âm!", "Cảnh báo");
                    manualDiscount = 0;
                    txtDiscountInput.Text = "0";
                }
            }

            lblDiscountValue.Text = "-" + manualDiscount.ToString("N0") + "đ";

            decimal grandTotal = _currentOrderSubTotal - manualDiscount;
            if (grandTotal < 0) grandTotal = 0;

            lblGrandTotalValue.Text = grandTotal.ToString("N0") + "đ";
        }

        // ==========================================
        // 5. XỬ LÝ SỰ KIỆN (THANH TOÁN - IN - PT)
        // ==========================================
        private void PaymentMethod_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            _paymentMethod = btn.Text;

            // Reset giao diện nút
            btnCash.BackColor = btnCard.BackColor = btnMomo.BackColor = btnBank.BackColor = Color.White;
            btnCash.ForeColor = btnCard.ForeColor = btnMomo.ForeColor = btnBank.ForeColor = Color.Black;

            // Highlight nút chọn
            btn.BackColor = Color.FromArgb(45, 45, 45);
            btn.ForeColor = Color.White;

            if (_paymentMethod == "Momo" || _paymentMethod == "Chuyển khoản")
                MessageBox.Show($"Đã hiện mã QR {_paymentMethod}!", "Thông báo");
        }

        private void btnConfirmCheckout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Xác nhận thanh toán {_tableName}?\nTổng: {lblGrandTotalValue.Text}",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    decimal discount = 0;
                    decimal.TryParse(txtDiscountInput.Text, out discount);

                    // Gọi Service (4 tham số: ID, Giảm giá, Phương thức, Người dùng)
                    bool isSuccess = _orderService.Checkout(_tableId, discount, _paymentMethod, _user);

                    if (isSuccess)
                    {
                        MessageBox.Show("✅ Thanh toán thành công!", "Thông báo");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thanh toán: " + ex.Message);
                }
            }
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                // Chụp ảnh Panel hóa đơn (pnlReceipt)
                Bitmap bmp = new Bitmap(pnlReceipt.Width, pnlReceipt.Height);
                pnlReceipt.DrawToBitmap(bmp, new Rectangle(0, 0, pnlReceipt.Width, pnlReceipt.Height));

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Ảnh PNG|*.png";
                sfd.FileName = $"HoaDon_{_tableName}_{DateTime.Now:HHmm}";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    bmp.Save(sfd.FileName);
                    MessageBox.Show("Đã lưu ảnh hóa đơn!", "Thành công");
                    // Mở ảnh lên xem ngay
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi in: " + ex.Message);
            }
        }

        // ==========================================
        // 6. HIỆU ỨNG ĐỒ HỌA (VIỀN NÉT ĐỨT)
        // ==========================================
        private void DrawDashedBorder(object sender, PaintEventArgs e)
        {
            Panel p = (Panel)sender;
            using (Pen pen = new Pen(Color.Gray, 1))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                e.Graphics.DrawRectangle(pen, 0, 0, p.Width - 1, p.Height - 1);
            }
        }

        private void pnlDiscountInputBorder_Paint(object sender, PaintEventArgs e)
        {
            DrawDashedBorder(sender, e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DrawDashedBorder(sender, e);
        }
    }
}