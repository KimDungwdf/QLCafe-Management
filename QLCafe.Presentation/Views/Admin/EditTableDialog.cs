using System;
using System.Windows.Forms;

namespace QLCafe.Presentation.Views.Admin
{
    public partial class EditTableDialog : Form
    {
        public string TableNameText
        {
            get => txtTableName.Text;
            set => txtTableName.Text = value ?? string.Empty;
        }

        public EditTableDialog()
        {
            InitializeComponent();
            // Wire dialog behaviors
            btnUpdate.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;

        }

        private void txtTableName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
