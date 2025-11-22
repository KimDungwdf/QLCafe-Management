using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLCafe.Presentation.Controls.Table
{
    public partial class FoodControl : UserControl
    {
        public int ProductId { get; private set; }

        public string ProductName
        {
            get => lbFoodName.Text;
            private set => lbFoodName.Text = value;
        }

        public string CategoryName
        {
            get => lbCategoryName.Text;
            private set => lbCategoryName.Text = value;
        }

        public decimal Price { get; private set; }

        public event EventHandler<int> DeleteRequested;

        public FoodControl()
        {
            InitializeComponent();
            ConfigureUI();
        }

        private void ConfigureUI()
        {
            lblDeleteProduct.Click += (s, e) => TriggerDelete();
            this.Resize += (s, e) => PositionDeleteLabel();
        }

        private void PositionDeleteLabel()
        {
            lblDeleteProduct.Left = panelMain.Width - lblDeleteProduct.Width - 12;
        }

        public void Bind(int id, string name, string category, decimal price)
        {
            ProductId = id;
            ProductName = name;
            CategoryName = category;
            Price = price;
            lbPrice.Text = price.ToString("N0") + " đ";
            PositionDeleteLabel();
        }

        private void TriggerDelete()
        {
            DeleteRequested?.Invoke(this, ProductId);
        }

        public void SetCategoryVisible(bool show)
        {
            lbCategoryName.Visible = show;
        }
    }
}
