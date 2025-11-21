using System;
using System.Configuration;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using QLCafe.Application.Services;

namespace QLCafe.Presentation.Views.Admin
{
    public partial class AddCategory : Form
    {
        private CategoryService _categoryService;
        private const string Placeholder = "Ví dụ: Cà phê, Trà, Sinh tố...";

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501; // Works on Vista+

        public AddCategory()
        {
            InitializeComponent();
        }

        private void AddCategory_Load(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["QLCafeConnection"].ConnectionString;
            _categoryService = new CategoryService(conn);
            ApplyPlaceholder(); // fallback if cue banner unsupported
            try { SendMessage(txtName.Handle, EM_SETCUEBANNER, 0, Placeholder); } catch { }
        }

        private void ApplyPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                txtName.ForeColor = Color.Gray;
                txtName.Text = Placeholder;
            }
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            if (txtName.Text == Placeholder)
            {
                txtName.Text = string.Empty;
                txtName.ForeColor = Color.Black;
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            ApplyPlaceholder();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var name = txtName.Text.Trim();
            if (name == Placeholder) name = string.Empty;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_categoryService.Exists(name))
            {
                MessageBox.Show("Danh mục đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                _categoryService.Create(name);
                MessageBox.Show("Thêm danh mục thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
