using System;
using System.Windows.Forms;

namespace QLCafe.Presentation.Views.Admin
{
    public partial class AddTableDialog : Form
    {
        public string TableNameText => txtName.Text.Trim();

        public AddTableDialog()
        {
            InitializeComponent();
            btnCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
            btnClose.Click += (s, e) => DialogResult = DialogResult.Cancel;
            AcceptButton = btnAdd;
            CancelButton = btnCancel;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên bàn", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void lblName_Click(object sender, EventArgs e) { }
    }
}
