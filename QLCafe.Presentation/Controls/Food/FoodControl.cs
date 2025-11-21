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

        private bool _deleteMode;

        public static FoodControl CreateForManagement(int id, string name, string category, decimal price, EventHandler<int> deleteHandler)
        {
            var fc = new FoodControl();
            fc.Bind(id, name, category, price);
            fc.SetCategoryVisible(false);
            fc.DeleteMode = true; // bật xóa mặc định cho màn quản lý
            if (deleteHandler != null) fc.DeleteRequested += deleteHandler;
            return fc;
        }

        public FoodControl()
        {
            InitializeComponent();
            ConfigureUI();
        }

        private void ConfigureUI()
        {
            // Các font đã set trong Designer, chỉ thêm sự kiện Xóa
            pbDelete.Cursor = Cursors.Hand;
            pbDelete.Click += pbDelete_Click;
        }

        public void Bind(int id, string name, string category, decimal price)
        {
            ProductId = id;
            ProductName = name;
            CategoryName = category;
            Price = price;
            lbPrice.Text = price.ToString("N0") + " đ";
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

        private void pbDelete_Click(object sender, EventArgs e)
        {
            if (_deleteMode)
                DeleteRequested?.Invoke(this, ProductId);
        }

        public void SetCategoryVisible(bool show)
        {
            lbCategoryName.Visible = show;
        }
    }
}
