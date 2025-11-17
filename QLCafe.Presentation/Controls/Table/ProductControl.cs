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
    public partial class ProductControl : UserControl
    {
        public event EventHandler<int> ProductClicked;
        public ProductControl()
        {
            InitializeComponent();
            // Click toàn bộ control sẽ thêm món
            this.Click += (s, e) => ProductClicked?.Invoke(this, ProductID);
            lblProductName.Click += (s, e) => ProductClicked?.Invoke(this, ProductID);
            lblPrice.Click += (s, e) => ProductClicked?.Invoke(this, ProductID);
            lblCategory.Click += (s, e) => ProductClicked?.Invoke(this, ProductID);
            panelBackground.Click += (s, e) => ProductClicked?.Invoke(this, ProductID);
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
                return decimal.Parse(priceText);
            }
            set => lblPrice.Text = value.ToString("N0") + " đ";
        }

        public string Category
        {
            get => lblCategory.Text;
            set => lblCategory.Text = value;
        }

        private void lblProductName_Click(object sender, EventArgs e)
        {

        }
    }
}
