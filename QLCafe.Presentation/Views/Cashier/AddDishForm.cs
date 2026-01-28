using Dapper;
using QLCafe.Application.Interfaces;
using QLCafe.Application.Services;
using QLCafe.Infrastructure.Repositories;
using QLCafe.Presentation.Controls.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLCafe.Presentation.Views.Cashier
{
    public partial class AddDishForm : Form
    {
        private string connectionString;
        private int currentTableID;
        private string currentTableName;
        private string currentUser;
        private Dictionary<int, OrderItemControl> orderItems = new Dictionary<int, OrderItemControl>();
        private Dictionary<int, int> originalQuantities = new Dictionary<int, int>();
        private IOrderService _orderService;
        private List<ProductInfo> allProducts = new List<ProductInfo>();

        public AddDishForm(int tableID, string tableName, string userName)
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["QLCafeConnection"].ConnectionString;

            // KHỞI TẠO SERVICE LAYER
            var orderRepository = new OrderRepository(connectionString);
            _orderService = new OrderService(orderRepository);

            currentTableID = tableID;
            currentTableName = tableName;
            currentUser = userName;

            // Đổi tiêu đề thành "Thêm món"
            lblHeaderPrefix.Text = "Thêm món -";
            lblTableNameHeader.Text = tableName;

            // Load sản phẩm và order hiện tại
            LoadProductsFromDatabase();
            LoadCurrentOrder();

            SetSendButtonToReadyState();

            // 🆕 THÊM SỰ KIỆN TÌM KIẾM
            TxtSearch.Enter += TxtSearch_Enter;
            TxtSearch.Leave += TxtSearch_Leave;
            TxtSearch.TextChanged += TxtSearch_TextChanged;

            // 🆕 ĐẶT PLACEHOLDER
            TxtSearch.Text = "Tìm kiếm món...";
            TxtSearch.ForeColor = Color.Gray;
        }

        // Class ProductInfo
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
                    // 🆕 LƯU VÀO allProducts
                    allProducts = connection.Query<ProductInfo>(
                        @"SELECT sp.IDSanPham, sp.TenSanPham, sp.DonGia, dm.TenDanhMuc 
                  FROM SanPham sp 
                  JOIN DanhMucMon dm ON sp.IDDanhMuc = dm.IDDanhMuc 
                  ORDER BY dm.TenDanhMuc, sp.TenSanPham",
                        commandType: CommandType.Text
                    ).ToList();

                    // 🆕 HIỂN THỊ TẤT CẢ SẢN PHẨM
                    DisplayProducts(allProducts);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sản phẩm: {ex.Message}");
            }
        }

        private void LoadCurrentOrder()
        {
            try
            {
                var currentOrder = _orderService.GetCurrentOrderByTable(currentTableID);

                if (currentOrder.Items.Count == 0)
                {
                    lblEmptyOrder.Visible = true;
                    flowLayoutOrderItems.Visible = false;
                    panelFooter.Visible = false;
                    return;
                }

                lblEmptyOrder.Visible = false;
                flowLayoutOrderItems.Visible = true;
                panelFooter.Visible = true;

                foreach (var item in currentOrder.Items)
                {
                    AddExistingProductToOrder(item.ProductId, item.ProductName, item.UnitPrice, item.Quantity);
                }

                UpdateTotalAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải order hiện tại: {ex.Message}");
            }
        }

        private void AddExistingProductToOrder(int productId, string productName, decimal price, int quantity)
        {
            var orderItem = new OrderItemControl();
            orderItem.ProductID = productId;
            orderItem.ProductName = productName;
            orderItem.UnitPrice = price;
            orderItem.Quantity = quantity;

            originalQuantities[productId] = quantity;
            CustomizeOrderItemForAddDish(orderItem);

            flowLayoutOrderItems.Controls.Add(orderItem);
            orderItems.Add(productId, orderItem);
        }

        private void AddProductToOrder(int productId, string productName, decimal price)
        {
            if (bttSend.Text == "✓ Order đã gửi xuống bếp!")
            {
                SetSendButtonToReadyState();
            }

            if (orderItems.ContainsKey(productId))
            {
                var existingItem = orderItems[productId];
                int newQuantity = existingItem.Quantity + 1;

                if (newQuantity < originalQuantities[productId])
                {
                    MessageBox.Show($"Không thể giảm số lượng món {productName} từ {existingItem.Quantity} xuống {newQuantity}. Số lượng tối thiểu là {originalQuantities[productId]}",
                                  "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                existingItem.Quantity = newQuantity;
            }
            else
            {
                var orderItem = new OrderItemControl();
                orderItem.ProductID = productId;
                orderItem.ProductName = productName;
                orderItem.UnitPrice = price;
                orderItem.Quantity = 1;

                originalQuantities[productId] = 0;
                CustomizeOrderItemForAddDish(orderItem);

                flowLayoutOrderItems.Controls.Add(orderItem);
                orderItems.Add(productId, orderItem);
            }

            UpdateTotalAmount();

            if (lblEmptyOrder.Visible)
            {
                lblEmptyOrder.Visible = false;
                flowLayoutOrderItems.Visible = true;
                panelFooter.Visible = true;
            }
        }

        private void CustomizeOrderItemForAddDish(OrderItemControl orderItem)
        {
            orderItem.QuantityChanged += (sender, newQuantity) =>
            {
                if (originalQuantities.ContainsKey(orderItem.ProductID))
                {
                    int minQuantity = originalQuantities[orderItem.ProductID];

                    if (newQuantity < minQuantity)
                    {
                        MessageBox.Show($"Không thể giảm số lượng món {orderItem.ProductName} xuống dưới {minQuantity}",
                                      "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        orderItem.Quantity = minQuantity;
                        return;
                    }
                }

                orderItem.Quantity = newQuantity;
                UpdateTotalAmount();

                if (bttSend.Text == "✓ Order đã gửi xuống bếp!")
                {
                    SetSendButtonToReadyState();
                }
            };

            orderItem.ItemRemoved += (sender, productIdToRemove) =>
            {
                if (originalQuantities.ContainsKey(productIdToRemove) && originalQuantities[productIdToRemove] > 0)
                {
                    MessageBox.Show($"Không thể xóa món {orderItem.ProductName} vì đã được order trước đó. Chỉ có thể thêm số lượng.",
                                  "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                RemoveProductFromOrder(productIdToRemove);
            };
        }

        private void RemoveProductFromOrder(int productId)
        {
            if (orderItems.ContainsKey(productId))
            {
                var itemToRemove = orderItems[productId];
                flowLayoutOrderItems.Controls.Remove(itemToRemove);
                orderItems.Remove(productId);
                originalQuantities.Remove(productId);

                UpdateTotalAmount();

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

        private void bttSend_Click(object sender, EventArgs e)
        {
            bool hasNewItems = orderItems.Any(item =>
                item.Value.Quantity > (originalQuantities.ContainsKey(item.Key) ? originalQuantities[item.Key] : 0));

            if (!hasNewItems)
            {
                MessageBox.Show("Vui lòng thêm món mới hoặc tăng số lượng món hiện có trước khi gửi!", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveAdditionalItemsToDatabase();
                SetSendButtonToSentState();

                MessageBox.Show("Đã thêm món và gửi Order xuống bếp! Form sẽ đóng sau 2 giây.", "Thành công",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);

                Timer closeTimer = new Timer();
                closeTimer.Interval = 2000;
                closeTimer.Tick += (s, args) =>
                {
                    closeTimer.Stop();
                    closeTimer.Dispose();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                };
                closeTimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm món: {ex.Message}", "Lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tìm đến hàm này trong AddDishForm.cs và sửa lại như sau:
        private void SaveAdditionalItemsToDatabase()
        {
            try
            {
                foreach (var orderItem in orderItems.Values)
                {
                    int originalQty = originalQuantities.ContainsKey(orderItem.ProductID) ?
                                    originalQuantities[orderItem.ProductID] : 0;

                    // Số lượng khách gọi thêm (Ví dụ: bàn đang có 1, gọi thêm 2 -> check 2)
                    // Hoặc nếu bạn muốn check tổng thì dùng orderItem.Quantity
                    int additionalQty = orderItem.Quantity - originalQty;

                    if (additionalQty > 0)
                    {
                        // --- BẮT ĐẦU ĐOẠN CODE KIỂM TRA TỒN KHO ---
                        // Kiểm tra xem có đủ nguyên liệu cho số lượng gọi thêm không
                        string missingIngredient = _orderService.CheckStockAvailability(orderItem.ProductID, additionalQty);

                        if (missingIngredient != null)
                        {
                            // Nếu thiếu, ném lỗi để dừng vòng lặp và báo cho thu ngân
                            throw new Exception($"Không đủ nguyên liệu '{missingIngredient}' để làm món {orderItem.ProductName}!");
                        }
                        // --- KẾT THÚC ĐOẠN CODE KIỂM TRA ---

                        _orderService.AddItemToOrder(currentTableID, orderItem.ProductID, additionalQty, currentUser);
                    }
                }
            }
            catch (Exception ex)
            {
                // Lỗi sẽ được bắt ở nút Lưu (bttSend_Click) và hiện MessageBox
                throw new Exception(ex.Message);
            }
        }

        private void SetSendButtonToReadyState()
        {
            bttSend.BackColor = Color.FromArgb(0, 192, 0);
            bttSend.Text = "Xác nhận và gửi xuống bếp";
            bttSend.Enabled = true;
        }

        private void SetSendButtonToSentState()
        {
            bttSend.BackColor = Color.Green;
            bttSend.Text = "✓ Order đã gửi xuống bếp!";
            bttSend.Enabled = false;
        }

        private void AddDishForm_Load(object sender, EventArgs e)
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

        // 🆕 PHƯƠNG THỨC LOẠI BỎ DẤU
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