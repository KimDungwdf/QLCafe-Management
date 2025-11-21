using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLCafe.Presentation.Controls.Table
{
    public partial class ProductControl : UserControl
    {
        public event EventHandler<int> ProductClicked;
        public event EventHandler<int> DeleteRequested;
        private bool _deleteMode;
        public ProductControl()
        {
            InitializeComponent();
            // Click toàn bộ control sẽ thêm món
            this.Click += (s, e) => ProductClicked?.Invoke(this, ProductID);
            lblProductName.Click += (s, e) => ProductClicked?.Invoke(this, ProductID);
            lblPrice.Click += (s, e) => ProductClicked?.Invoke(this, ProductID);
            lblCategory.Click += (s, e) => ProductClicked?.Invoke(this, ProductID);
            panelBackground.Click += (s, e) => ProductClicked?.Invoke(this, ProductID);
            pbDelete.Cursor = Cursors.Hand;
            pbDelete.Click += (s, e) => DeleteRequested?.Invoke(this, ProductID);
        }

        public int ProductID { get; set; }

        public string ProductName
        {
            get => lblProductName.Text;
            set => lblProductName.Text = value;
        }

        public decimal Price
        {
            get
            {
                // Chuyển từ "25,000đ" về số
                string priceText = lblPrice.Text.Replace(" đ", "").Replace(",", "");
                return decimal.TryParse(priceText, out var v) ? v : 0;
            }
            set => lblPrice.Text = value.ToString("N0") + " đ";
        }

        public string Category
        {
            get => lblCategory.Text;
            set => lblCategory.Text = value;
        }

        // Cho phép ẩn/hiện nhãn danh mục khi đã nhóm theo danh mục bên ngoài
        public bool ShowCategory
        {
            get => lblCategory.Visible;
            set => lblCategory.Visible = value;
        }

        public bool DeleteMode
        {
            get => _deleteMode;
            set
            {
                _deleteMode = value;
                pbDelete.Visible = value;
            }
        }

        private void lblProductName_Click(object sender, EventArgs e)
        {

        }
    }
}
