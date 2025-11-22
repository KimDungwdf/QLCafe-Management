using QLCafe.Presentation.Controls.Table;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using QLCafe.Application.Interfaces;
using QLCafe.Application.Services;
using QLCafe.Infrastructure.Repositories;
using Dapper;

namespace QLCafe.Presentation.Views.Cashier
{
    public partial class OrderForm : Form
    {
        private string connectionString;
        private int currentTableID;
        private string currentTableName;
        private string currentUser;
        private Dictionary<int, OrderItemControl> orderItems = new Dictionary<int, OrderItemControl>();
        private IOrderService _orderService;
        private List<ProductInfo> allProducts = new List<ProductInfo>(); // Lưu toàn bộ sản phẩm để tìm kiếm

        public OrderForm(int tableID, string tableName, string userName)
        {
            InitializeComponent();

            // Lấy connection string từ App.config
            connectionString = ConfigurationManager.ConnectionStrings["QLCafeConnection"].ConnectionString;

            // KHỞI TẠO SERVICE LAYER - ĐÚNG KIẾN TRÚC N-LAYER
            var orderRepository = new OrderRepository(connectionString);
            _orderService = new OrderService(orderRepository);

            currentTableID = tableID;
            currentTableName = tableName;
            currentUser = userName;

            // Gán tên bàn vào header
            lblTableNameHeader.Text = "" + tableName;

            // Load sản phẩm từ database
            LoadProductsFromDatabase();

            // Đặt nút về trạng thái ban đầu
            SetSendButtonToReadyState();

            // 🆕 THÊM SỰ KIỆN CHO TEXTBOX TÌM KIẾM
            TxtSearch.Enter += TxtSearch_Enter;
            TxtSearch.Leave += TxtSearch_Leave;
            TxtSearch.TextChanged += TxtSearch_TextChanged;

            // 🆕 Đặt placeholder text ban đầu
            TxtSearch.Text = "Tìm kiếm món...";
            TxtSearch.ForeColor = Color.Gray;
        }

        // Class ProductInfo để map dữ liệu từ database
        public class ProductInfo
        {
            public int IDSanPham { get; set; }
            public string TenSanPham { get; set; }
            public decimal DonGia { get; set; }
            public string TenDanhMuc { get; set; }
        }

        private void LoadProductsFromDatabase()
        {
             try
    {
        using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
        {
            // 🆕 QUAN TRỌNG: LƯU DANH SÁCH SẢN PHẨM ĐẦY ĐỦ VÀO allProducts
            allProducts = connection.Query<ProductInfo>(
                @"SELECT sp.IDSanPham, sp.TenSanPham, sp.DonGia, dm.TenDanhMuc 
                  FROM SanPham sp 
                  JOIN DanhMucMon dm ON sp.IDDanhMuc = dm.IDDanhMuc 
                  ORDER BY dm.TenDanhMuc, sp.TenSanPham",
                commandType: CommandType.Text
            ).ToList();

            // 🆕 HIỂN THỊ TẤT CẢ SẢN PHẨM BAN ĐẦU
            DisplayProducts(allProducts);
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Lỗi khi tải danh sách sản phẩm: {ex.Message}");
    }
        }

        private void AddProductToOrder(int productId, string productName, decimal price)
        {
            // Nếu đây là món đầu tiên, chuyển trạng thái
            if (orderItems.Count == 0)
            {
                lblEmptyOrder.Visible = false;
                flowLayoutOrderItems.Visible = true;
                panelFooter.Visible = true;
            }

            // Reset nút về trạng thái sẵn sàng khi có món mới được thêm
            if (bttSend.Text == "✓ Order đã gửi xuống bếp!")
            {
                SetSendButtonToReadyState();
            }

            // Kiểm tra món đã có chưa
            if (orderItems.ContainsKey(productId))
            {
                // Đã có -> tăng số lượng
                var existingItem = orderItems[productId];
                existingItem.Quantity += 1;
            }
            else
            {
                // Chưa có -> tạo OrderItemControl mới
                var orderItem = new OrderItemControl();
                orderItem.ProductID = productId;
                orderItem.ProductName = productName;
                orderItem.UnitPrice = price;
                orderItem.Quantity = 1;

                // Xử lý sự kiện
                orderItem.QuantityChanged += (sender, newQuantity) =>
                {
                    if (newQuantity <= 0)
                    {
                        RemoveProductFromOrder(productId);
                    }
                    else
                    {
                        orderItem.Quantity = newQuantity;
                        UpdateTotalAmount();

                        // Reset nút khi số lượng thay đổi
                        if (bttSend.Text == "✓ Order đã gửi xuống bếp!")
                        {
                            SetSendButtonToReadyState();
                        }
                    }
                };

                orderItem.ItemRemoved += (sender, productIdToRemove) =>
                {
                    RemoveProductFromOrder(productIdToRemove);
                };

                // QUAN TRỌNG: THÊM VÀO FLOWLAYOUTPANEL
                flowLayoutOrderItems.Controls.Add(orderItem);
                orderItems.Add(productId, orderItem);
            }

            UpdateTotalAmount();
        }

        private void RemoveProductFromOrder(int productId)
        {
            if (orderItems.ContainsKey(productId))
            {
                var itemToRemove = orderItems[productId];
                flowLayoutOrderItems.Controls.Remove(itemToRemove);
                orderItems.Remove(productId);

                UpdateTotalAmount();

                // Nếu không còn món nào
                if (orderItems.Count == 0)
                {
                    lblEmptyOrder.Visible = true;
                    flowLayoutOrderItems.Visible = false;
                    panelFooter.Visible = false;
                }
            }
        }

        private void UpdateTotalAmount()
        {
            decimal total = orderItems.Values.Sum(item => item.UnitPrice * item.Quantity);
            lblTotalAmount.Text = total.ToString("N0") + " đ";
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
        }

        private void bttSend_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có món nào trong order không
            if (orderItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món trước khi gửi order!", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 🟢 LƯU ORDER VÀO DATABASE - DÙNG SERVICE LAYER
                SaveOrderToDatabase();

                // 🟢 ĐỔI TRẠNG THÁI NÚT THÀNH "Order đã gửi xuống bếp!"
                SetSendButtonToSentState();

                // 🟢 HIỂN THỊ THÔNG BÁO VÀ ĐÓNG FORM SAU 2 GIÂY
                MessageBox.Show("Đã gửi Order xuống bếp! Form sẽ đóng sau 2 giây.", "Thành công",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 🟢 TẠO TIMER ĐỂ ĐÓNG FORM SAU 2 GIÂY
                Timer closeTimer = new Timer();
                closeTimer.Interval = 2000; // 2 giây
                closeTimer.Tick += (s, args) =>
                {
                    closeTimer.Stop();
                    closeTimer.Dispose();
                    this.DialogResult = DialogResult.OK; // 🟢 TRẢ VỀ KẾT QUẢ THÀNH CÔNG
                    this.Close(); // 🟢 ĐÓNG FORM
                };
                closeTimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi order: {ex.Message}", "Lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🟢 PHƯƠNG THỨC LƯU ORDER VÀO DATABASE - ĐÃ REFACTOR DÙNG SERVICE LAYER
        private void SaveOrderToDatabase()
        {
            try
            {
                // DÙNG SERVICE LAYER THAY VÌ DIRECT DB ACCESS
                // Với mỗi món trong order, gọi service method
                foreach (var orderItem in orderItems.Values)
                {
                    _orderService.AddItemToOrder(currentTableID, orderItem.ProductID, orderItem.Quantity, currentUser);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lưu order: {ex.Message}");
            }
        }

        // Phương thức đặt nút về trạng thái "Xác nhận và gửi xuống bếp"
        private void SetSendButtonToReadyState()
        {
            bttSend.BackColor = Color.FromArgb(0, 192, 0); // Màu xanh lá ban đầu
            bttSend.Text = "Xác nhận và gửi xuống bếp";
            bttSend.Enabled = true;
        }

        // 🟢 PHƯƠNG THỨC ĐẶT NÚT VỀ TRẠNG THÁI "Order đã gửi xuống bếp!"
        private void SetSendButtonToSentState()
        {
            bttSend.BackColor = Color.Green;
            bttSend.Text = "✓ Order đã gửi xuống bếp!";
            bttSend.Enabled = false; // Vô hiệu hóa nút khi đã gửi
        }

        private void lblHeaderPrefix_Click(object sender, EventArgs e)
        {
        }

        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (TxtSearch.Text == "Tìm kiếm món...")
            {
                TxtSearch.Text = "";
                TxtSearch.ForeColor = Color.Black;
            }
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtSearch.Text))
            {
                TxtSearch.Text = "Tìm kiếm món...";
                TxtSearch.ForeColor = Color.Gray;
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            // Chỉ tìm kiếm khi không phải là placeholder text
            if (TxtSearch.Text != "Tìm kiếm món..." && TxtSearch.ForeColor != Color.Gray)
            {
                SearchProducts();
            }
        }

        // 🆕 PHƯƠNG THỨC TÌM KIẾM
        private void SearchProducts()
        {
            try
            {
                string searchText = TxtSearch.Text.Trim();

                if (searchText == "Tìm kiếm món..." || string.IsNullOrWhiteSpace(searchText))
                {
                    DisplayProducts(allProducts);
                    return;
                }

                // 🆕 CHUẨN HÓA TỪ KHÓA TÌM KIẾM
                string normalizedSearch = NormalizeSearchText(searchText);

                // Tìm kiếm CÓ DẤU, KHÔNG DẤU, và KHÔNG KHOẢNG CÁCH
                var filteredProducts = allProducts.Where(product =>
                {
                    string productName = product.TenSanPham.ToLower();
                    string category = product.TenDanhMuc.ToLower();

                    // 🆕 CHUẨN HÓA TÊN SẢN PHẨM
                    string normalizedProductName = NormalizeSearchText(productName);
                    string normalizedCategory = NormalizeSearchText(category);

                    // Tìm kiếm có dấu
                    bool exactMatch = productName.Contains(searchText.ToLower()) ||
                                     category.Contains(searchText.ToLower());

                    // Tìm kiếm không dấu
                    bool noDiacriticMatch = RemoveDiacritics(productName).Contains(RemoveDiacritics(searchText.ToLower())) ||
                                           RemoveDiacritics(category).Contains(RemoveDiacritics(searchText.ToLower()));

                    // 🆕 TÌM KIẾM KHÔNG KHOẢNG CÁCH
                    bool noSpaceMatch = normalizedProductName.Contains(normalizedSearch) ||
                                       normalizedCategory.Contains(normalizedSearch);

                    return exactMatch || noDiacriticMatch || noSpaceMatch;
                }).ToList();

                DisplayProducts(filteredProducts);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🆕 PHƯƠNG THỨC CHUẨN HÓA TỪ KHÓA TÌM KIẾM
        private string NormalizeSearchText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            // Chuyển về chữ thường, bỏ dấu, và loại bỏ khoảng trắng
            string noDiacritics = RemoveDiacritics(text.ToLower());
            string noSpaces = noDiacritics.Replace(" ", "").Replace("  ", "");

            return noSpaces;
        }


        private string RemoveDiacritics(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            var normalizedString = text.Normalize(System.Text.NormalizationForm.FormD);
            var stringBuilder = new System.Text.StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(System.Text.NormalizationForm.FormC).ToLower();
        }

        // 🆕 PHƯƠNG THỨC HIỂN THỊ SẢN PHẨM
        private void DisplayProducts(List<ProductInfo> products)
        {
            // Xóa controls cũ
            flowLayoutProducts.Controls.Clear();

            foreach (var product in products)
            {
                var productControl = new ProductControl();
                productControl.ProductID = product.IDSanPham;
                productControl.ProductName = product.TenSanPham;
                productControl.Price = product.DonGia;
                productControl.Category = product.TenDanhMuc;

                // Xử lý khi click vào product
                productControl.ProductClicked += (sender, productId) =>
                {
                    AddProductToOrder(productId, product.TenSanPham, product.DonGia);
                };

                // THÊM VÀO FLOWLAYOUTPANEL
                flowLayoutProducts.Controls.Add(productControl);
            }
        }
    }
}