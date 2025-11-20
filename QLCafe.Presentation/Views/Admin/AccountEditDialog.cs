using System;
using System.Drawing;
using System.Windows.Forms;
using QLCafe.Application.DTOs.Account;
using QLCafe.Application.Services;
using QLCafe.Domain.Enums;

namespace QLCafe.Presentation.Views.Admin
{
    public class AccountEditDialog : Form
    {
        private readonly AccountService _service;
        private readonly AccountDto _editing;
        private TextBox txtUsername; private TextBox txtDisplayName; private ComboBox cboRole; private ComboBox cboStatus; private TextBox txtPassword; private Button btnSave; private Button btnCancel;

        public AccountEditDialog(AccountService service, AccountDto editing = null)
        {



            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            _service = service; _editing = editing; Init();
        }

        private void Init()
        {
            this.Text = _editing == null ? "Thêm tài khoản" : "Sửa tài khoản";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new Size(380, 320);
            this.MaximizeBox = false; this.MinimizeBox = false;
            this.Font = new Font("Segoe UI", 9F);

            Label lbl1 = new Label { Text = "Tên đăng nhập", Left = 20, Top = 22, Width = 120 };
            txtUsername = new TextBox { Left = 150, Top = 18, Width = 190 };
            Label lbl2 = new Label { Text = "Họ tên", Left = 20, Top = 62, Width = 120 };
            txtDisplayName = new TextBox { Left = 150, Top = 58, Width = 190 };
            Label lbl4 = new Label { Text = "Vai trò", Left = 20, Top = 102, Width = 120 };
            cboRole = new ComboBox { Left = 150, Top = 98, Width = 190, DropDownStyle = ComboBoxStyle.DropDownList };
            cboRole.Items.AddRange(new object[] { "Quản trị", "Thu ngân", "Thủ kho" });
            Label lbl5 = new Label { Text = "Trạng thái", Left = 20, Top = 142, Width = 120 };
            cboStatus = new ComboBox { Left = 150, Top = 138, Width = 190, DropDownStyle = ComboBoxStyle.DropDownList };
            cboStatus.Items.AddRange(new object[] { "Hoạt động", "Ngừng" });
            Label lbl6 = new Label { Text = "Mật khẩu", Left = 20, Top = 182, Width = 120 };
            txtPassword = new TextBox { Left = 150, Top = 178, Width = 190, UseSystemPasswordChar = true };
            btnSave = new Button { Text = "Lưu", Left = 150, Top = 235, Width = 90, DialogResult = DialogResult.OK };
            btnCancel = new Button { Text = "Hủy", Left = 250, Top = 235, Width = 90, DialogResult = DialogResult.Cancel };
            btnSave.Click += BtnSave_Click;
            this.Controls.AddRange(new Control[] { lbl1, txtUsername, lbl2, txtDisplayName, lbl4, cboRole, lbl5, cboStatus, lbl6, txtPassword, btnSave, btnCancel });

            if (_editing != null)
            {
                txtUsername.Text = _editing.Username; txtUsername.Enabled = false; txtDisplayName.Text = _editing.DisplayName; cboRole.SelectedIndex = RoleToIndex(_editing.Role); cboStatus.SelectedItem = string.IsNullOrEmpty(_editing.Status) ? "Hoạt động" : _editing.Status; txtPassword.Enabled = false; txtPassword.Text = string.Empty; // Not editing password
            }
            else
            {
                cboRole.SelectedIndex = 1; // default Thu ngân
                cboStatus.SelectedIndex = 0;
            }
        }

        private int RoleToIndex(RoleType role)
        {
            switch (role)
            {
                case RoleType.Admin: return 0;
                case RoleType.Cashier: return 1;
                case RoleType.InventoryManager: return 2;
                default: return 1;
            }
        }
        private RoleType IndexToRole(int idx) { if (idx == 0) return RoleType.Admin; if (idx == 1) return RoleType.Cashier; return RoleType.InventoryManager; }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtDisplayName.Text))
            { MessageBox.Show("Vui lòng nhập đầy đủ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); this.DialogResult = DialogResult.None; return; }
            if (_editing == null && _service.UsernameExists(txtUsername.Text))
            { MessageBox.Show("Tên đăng nhập đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); this.DialogResult = DialogResult.None; return; }

            if (_editing == null)
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text)) { MessageBox.Show("Nhập mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); this.DialogResult = DialogResult.None; return; }
                var dto = new AccountDto { Username = txtUsername.Text.Trim(), DisplayName = txtDisplayName.Text.Trim(), Status = cboStatus.SelectedItem.ToString(), Role = IndexToRole(cboRole.SelectedIndex) };
                _service.Create(dto, txtPassword.Text.Trim());
            }
            else
            {
                _editing.DisplayName = txtDisplayName.Text.Trim(); _editing.Status = cboStatus.SelectedItem.ToString(); _editing.Role = IndexToRole(cboRole.SelectedIndex); _service.Update(_editing);
            }
        }
    }
}
