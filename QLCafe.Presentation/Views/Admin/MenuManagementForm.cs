using System;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QLCafe.Application.Services;
using QLCafe.Presentation.Controls.Table;
using QLCafe.Infrastructure.Repositories;

namespace QLCafe.Presentation.Views.Admin
{
    public partial class MenuManagementForm : Form
    {
        private MenuProductRepository _productRepo;
        private CategoryService _categoryService;

        public MenuManagementForm()
        {
            InitializeComponent();
            Load += MenuManagementForm_Load;
            flowLayoutPanel1.SizeChanged += (s, e) => AdjustItemWidths();
        }

        private void MenuManagementForm_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["QLCafeConnection"].ConnectionString;
            _productRepo = new MenuProductRepository(cs);
            _categoryService = new CategoryService(cs);
            InitContainer();
            LoadProducts();
        }

        private void InitContainer()
        {
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
        }

        private void LoadProducts()
        {
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.Controls.Clear();

            var products = _productRepo.GetAll();
            var categories = _categoryService.GetAllPairs();
            if (categories.Count == 0)
            {
                flowLayoutPanel1.Controls.Add(new Label { Text = "Chưa có danh mục nào.", AutoSize = true, Font = new Font("Segoe UI", 11F, FontStyle.Italic), ForeColor = Color.DarkGray, Margin = new Padding(10, 20, 10, 10) });
                flowLayoutPanel1.ResumeLayout();
                return;
            }

            int availableWidth = flowLayoutPanel1.DisplayRectangle.Width - 20;
            if (availableWidth < 300) availableWidth = flowLayoutPanel1.Width - 40;

            // Nhóm sản phẩm theo danh mục
            var dict = products.GroupBy(p => p.CategoryName).ToDictionary(g => g.Key, g => g.ToList());

            foreach (var cat in categories.OrderBy(c => c.Name))
            {
                var categoryPanel = new Panel
                {
                    Width = availableWidth,
                    Height = 60, // sẽ tăng sau
                    Margin = new Padding(5, 5, 5, 15),
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle
                };

                // Header
                var lblCategory = new Label
                {
                    Text = cat.Name,
                    Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(12, 12)
                };
                categoryPanel.Controls.Add(lblCategory);

                var lblDelete = new Label
                {
                    Text = "✕ Xóa",
                    AutoSize = false,
                    Width = 60,
                    Height = 24,
                    BackColor = Color.FromArgb(220, 53, 69),
                    ForeColor = Color.White,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    Location = new Point(categoryPanel.Width - 70, 12)
                };
                lblDelete.Click += (s, e) => DeleteCategory(cat.Name);
                categoryPanel.Controls.Add(lblDelete);

                // Panel chứa món
                var itemsStartY = 50;
                int itemHeight = 54;
                int verticalSpacing = 8;
                int itemWidth = availableWidth - 24; // padding
                int currentY = itemsStartY;

                if (dict.TryGetValue(cat.Name, out var list) && list.Count > 0)
                {
                    foreach (var p in list)
                    {
                        var fc = new FoodControl();
                        fc.Bind(p.Id, p.Name, p.CategoryName, p.Price);
                        fc.DeleteRequested += Food_DeleteRequested;
                        fc.DeleteMode = true;
                        fc.SetCategoryVisible(false);
                        fc.Width = itemWidth;
                        fc.Height = itemHeight;
                        fc.Left = 12;
                        fc.Top = currentY;
                        categoryPanel.Controls.Add(fc);
                        currentY += itemHeight + verticalSpacing;
                    }
                }
                else
                {
                    var lblEmpty = new Label
                    {
                        Text = "Chưa có món",
                        AutoSize = true,
                        Font = new Font("Segoe UI", 10F, FontStyle.Italic),
                        ForeColor = Color.Gray,
                        Location = new Point(16, currentY + 6)
                    };
                    categoryPanel.Controls.Add(lblEmpty);
                    currentY += lblEmpty.Height + verticalSpacing;
                }

                categoryPanel.Height = currentY + 6;
                flowLayoutPanel1.Controls.Add(categoryPanel);
            }
            flowLayoutPanel1.ResumeLayout(true);
        }

        private void AdjustItemWidths()
        {
            int availableWidth = flowLayoutPanel1.DisplayRectangle.Width - 20;
            if (availableWidth < 300) return;
            foreach (Panel categoryPanel in flowLayoutPanel1.Controls.OfType<Panel>())
            {
                int itemWidth = availableWidth - 24;
                foreach (var fc in categoryPanel.Controls.OfType<FoodControl>())
                {
                    fc.Width = itemWidth;
                }
                // Update delete label position
                var lblDelete = categoryPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Text.Contains("Xóa"));
                if (lblDelete != null) lblDelete.Left = categoryPanel.Width - 70;
            }
        }

        private void Food_DeleteRequested(object sender, int productId)
        {
            var ctrl = (FoodControl)sender;
            if (MessageBox.Show($"Xóa món '{ctrl.ProductName}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_productRepo.Delete(productId)) LoadProducts();
                else MessageBox.Show("Không xóa được (có thể đang dùng trong hóa đơn)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenAddProduct()
        {
            using (var dlg = new AddProductDialog(_categoryService))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _productRepo.Insert(dlg.ProductName, dlg.SelectedCategoryId, dlg.Price);
                    LoadProducts();
                }
            }
        }

        private void OpenAddCategory()
        {
            using (var dlg = new AddCategory())
            {
                if (dlg.ShowDialog() == DialogResult.OK) LoadProducts();
            }
        }

        private void DeleteCategory(string categoryName)
        {
            var pair = _categoryService.GetAllPairs().FirstOrDefault(c => c.Name == categoryName);
            if (pair.Id == 0)
            {
                MessageBox.Show("Không tìm thấy danh mục để xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show($"Xóa danh mục '{categoryName}' và các món thuộc danh mục?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_categoryService.DeleteWithProducts(pair.Id)) LoadProducts();
                else MessageBox.Show("Không xóa được danh mục", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddFoodGlobal_Click(object sender, EventArgs e) => OpenAddProduct();
        private void BtnAddCategoryGlobal_Click(object sender, EventArgs e) => OpenAddCategory();
    }
}
