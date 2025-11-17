using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCafe.Presentation.Controls.Table
{
    public partial class OrderItemControl : UserControl
    {
        private string placeholderText = "Ghi chú (ví dụ: ít đường, thêm đá,...)";

        // KHAI BÁO EVENTS
        public event EventHandler<int> QuantityChanged;
        public event EventHandler<int> ItemRemoved;
        public event EventHandler<string> NoteChanged;

        public OrderItemControl()
        {
            InitializeComponent();

            // Gọi hàm Leave 1 lần khi Form mới load
            txtNote_Leave(txtNote, EventArgs.Empty);

            // THÊM SỰ KIỆN CHO CÁC NÚT
            btnIncrease.Click += (s, e) => QuantityChanged?.Invoke(this, Quantity + 1);
            btnDecrease.Click += (s, e) => QuantityChanged?.Invoke(this, Quantity - 1);
            btnRemove.Click += (s, e) => ItemRemoved?.Invoke(this, ProductID);
        }

        // THÊM PROPERTIES
        public int ProductID { get; set; }

        public string ProductName
        {
            get => lblProductName.Text;
            set => lblProductName.Text = value;
        }

        public int Quantity
        {
            get => int.Parse(lblQuantity.Text);
            set
            {
                lblQuantity.Text = value.ToString();
                UpdateTotalPrice();
            }
        }

        public decimal UnitPrice { get; set; }

        public string Note
        {
            get => txtNote.ForeColor == Color.Gray ? "" : txtNote.Text;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    txtNote_Leave(txtNote, EventArgs.Empty);
                }
                else
                {
                    txtNote.Text = value;
                    txtNote.ForeColor = Color.Black;
                }
            }
        }

        private void UpdateTotalPrice()
        {
            decimal total = UnitPrice * Quantity;
            lblTotalPrice.Text = total.ToString("N0") + " đ";
        }

        private void txtNote_Enter(object sender, EventArgs e)
        {
            // Nếu textbox đang hiển thị chữ mờ
            if (txtNote.Text == placeholderText)
            {
                // Xóa nó đi
                txtNote.Text = "";
                // Đổi màu chữ về màu đen (màu gõ chữ)
                txtNote.ForeColor = Color.Black;
            }
        }

        private void txtNote_Leave(object sender, EventArgs e)
        {
            // Nếu textbox bị bỏ trống
            if (string.IsNullOrWhiteSpace(txtNote.Text))
            {
                // Set lại chữ mờ
                txtNote.Text = placeholderText;
                // Đổi màu chữ sang màu xám (màu placeholder)
                txtNote.ForeColor = Color.Gray;
            }
        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {
            // GỬI EVENT KHI GHÍ CHÚ THAY ĐỔI
            if (txtNote.ForeColor != Color.Gray)
            {
                NoteChanged?.Invoke(this, Note);
            }
        }
    }
}