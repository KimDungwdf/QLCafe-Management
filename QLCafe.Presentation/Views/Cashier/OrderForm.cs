using QLCafe.Presentation.Controls.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Dapper;
using QLCafe.Presentation.Controls.Table;

namespace QLCafe.Presentation.Views.Cashier
{
    public partial class OrderForm : Form
    {
        private string connectionString;
        private int currentTableID;
        private string currentTableName;
        private string currentUser;
        private Dictionary<int, OrderItemControl> orderItems = new Dictionary<int, OrderItemControl>();

        public OrderForm(int tableID, string tableName, string userName)
        {
            InitializeComponent();

            // Lấy connection string từ App.config
            connectionString = ConfigurationManager.ConnectionStrings["QLCafeConnection"].ConnectionString;
            bttSend.Click += bttSend_Click;
            currentTableID = tableID;
            currentTableName = tableName;
            currentUser = userName;

            // Gán tên bàn vào header
            lblTableNameHeader.Text = "" + tableName;

            // Load sản phẩm từ database
            LoadProductsFromDatabase();

            // Đặt nút về trạng thái ban đầu
            SetSendButtonToReadyState();
        }

        // Thêm class này trong file OrderForm.cs
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
                using (var connection = new SqlConnection(connectionString))
                {
                    var products = connection.Query<ProductInfo>(
                        @"SELECT sp.IDSanPham, sp.TenSanPham, sp.DonGia, dm.TenDanhMuc 
                  FROM SanPham sp 
                  JOIN DanhMucMon dm ON sp.IDDanhMuc = dm.IDDanhMuc 
                  ORDER BY dm.TenDanhMuc, sp.TenSanPham",
                        commandType: CommandType.Text
                    ).ToList();

                    // Xóa controls cũ
                    flowLayoutProducts.Controls.Clear();

                    // Group theo danh mục
                    var grouped = products.GroupBy(p => p.TenDanhMuc);

                    foreach (var group in grouped)
                    {
                        // Panel chứa 1 danh mục
                        var categoryPanel = new Panel
                        {
                            Width = flowLayoutProducts.ClientSize.Width - 30,
                            AutoSize = true,
                            AutoSizeMode = AutoSizeMode.GrowAndShrink,
                            Margin = new Padding(3, 3, 3, 15)
                        };

                        // Tiêu đề danh mục
                        var lblCategoryTitle = new Label
                        {
                            Text = group.Key,
                            AutoSize = true,
                            Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                            ForeColor = Color.FromArgb(68, 68, 68),
                            Dock = DockStyle.Top,
                            Padding = new Padding(0, 0, 0, 4)
                        };
                        categoryPanel.Controls.Add(lblCategoryTitle);

                        // FlowLayoutPanel con cho các món trong danh mục
                        var productsPanel = new FlowLayoutPanel
                        {
                            FlowDirection = FlowDirection.TopDown,
                            WrapContents = false,
                            AutoSize = true,
                            AutoSizeMode = AutoSizeMode.GrowAndShrink,
                            Dock = DockStyle.Top
                        };

                        foreach (var product in group)
                        {
                            var productControl = new ProductControl();
                            productControl.ProductID = product.IDSanPham;
                            productControl.ProductName = product.TenSanPham;
                            productControl.Price = product.DonGia;
                            productControl.Category = product.TenDanhMuc;
                            productControl.ShowCategory = false; // Ẩn vì đã có tiêu đề nhóm

                            // Xử lý khi click vào product
                            productControl.ProductClicked += (sender, productId) =>
                            {
                                AddProductToOrder(productId, product.TenSanPham, product.DonGia);
                            };

                            productsPanel.Controls.Add(productControl);
                        }

                        // Thêm panel món vào dưới label (đảo ngược thứ tự Dock)
                        categoryPanel.Controls.Add(productsPanel);
                        productsPanel.BringToFront();

                        flowLayoutProducts.Controls.Add(categoryPanel);
                    }
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
                // 🟢 LƯU ORDER VÀO DATABASE
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

        // 🟢 PHƯƠNG THỨC LƯU ORDER VÀO DATABASE
        private void SaveOrderToDatabase()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Sử dụng transaction để đảm bảo tính toàn vẹn dữ liệu
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Với mỗi món trong order, gọi stored procedure
                        foreach (var orderItem in orderItems.Values)
                        {
                            connection.Execute(
                                "sp_AddBillDetail",
                                new
                                {
                                    IDBan = currentTableID,
                                    IDSanPham = orderItem.ProductID,
                                    SoLuong = orderItem.Quantity,
                                    TenDangNhap = currentUser
                                },
                                transaction: transaction,
                                commandType: CommandType.StoredProcedure
                            );
                        }

                        transaction.Commit();

                        // TRIGGER SẼ TỰ ĐỘNG CẬP NHẬT TRẠNG THÁI BÀN THÀNH "Có khách"
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
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
    }
}