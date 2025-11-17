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
            lblTableNameHeader.Text = tableName;

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

            // 🟢 DI CHUYỂN ĐOẠN NÀY RA NGOÀI - Reset nút về trạng thái sẵn sàng khi có món mới được thêm
            if (bttSend.Text == "✓ Đã gửi")
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
                // TODO: Thêm code để lưu order vào database ở đây

                // Đổi trạng thái nút thành đã gửi
                SetSendButtonToSentState();

                // Hiển thị thông báo
                MessageBox.Show("Đã gửi Order xuống bếp!", "Thành công",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);

                // TODO: Có thể thêm các xử lý khác sau khi gửi order thành công

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi order: {ex.Message}", "Lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phương thức đặt nút về trạng thái "Xác nhận và gửi xuống bếp"
        private void SetSendButtonToReadyState()
        {
            bttSend.BackColor = Color.FromArgb(0, 192, 0); // Màu xanh lá ban đầu
            bttSend.Text = "Xác nhận và gửi xuống bếp";
            bttSend.Enabled = true;
        }

        // Phương thức đặt nút về trạng thái "✓ Đã gửi"
        private void SetSendButtonToSentState()
        {
            bttSend.BackColor = Color.Green;
            bttSend.Text = "✓ Đã gửi";
            bttSend.Enabled = false; // Vô hiệu hóa nút khi đã gửi
        }
    }
}