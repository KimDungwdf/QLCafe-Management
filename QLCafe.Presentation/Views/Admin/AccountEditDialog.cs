using System;
using System.Drawing;
using System.Windows.Forms;
using QLCafe.Application.DTOs.Account;
using QLCafe.Application.Services;
using QLCafe.Domain.Enums;
using System.Text.RegularExpressions;

namespace QLCafe.Presentation.Views.Admin
{
    public class AccountEditDialog : Form
    {
        private readonly AccountService _service;
        private readonly AccountDto _editing;
        private readonly string _currentUsername; // Lưu username đang đăng nhập
        private TextBox txtUsername; 
        private TextBox txtDisplayName; 
        private ComboBox cboRole; 
        private TextBox txtPassword; 
        private Button btnSave; 
        private Button btnCancel;

        public AccountEditDialog(AccountService service, AccountDto editing = null)
        {
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            _service = service; _editing = editing; Init();
        }

        public AccountEditDialog(AccountService service, AccountDto editing, string currentUsername) : this(service, editing)
        {
            _currentUsername = currentUsername;
        }

        private void Init()
        {
            this.Text = _editing == null ? "Thêm tài khoản" : "Sửa tài khoản";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new Size(380, 260);
            this.MaximizeBox = false; this.MinimizeBox = false;
            this.Font = new Font("Segoe UI", 9F);

            Label lbl1 = new Label { Text = "Tên đăng nhập", Left = 20, Top = 22, Width = 120 };
            txtUsername = new TextBox { Left = 150, Top = 18, Width = 190 };
            
            Label lbl2 = new Label { Text = "Họ tên", Left = 20, Top = 62, Width = 120 };
            txtDisplayName = new TextBox { Left = 150, Top = 58, Width = 190 };
            
            Label lbl4 = new Label { Text = "Vai trò", Left = 20, Top = 102, Width = 120 };
            cboRole = new ComboBox { Left = 150, Top = 98, Width = 190, DropDownStyle = ComboBoxStyle.DropDownList };
            cboRole.Items.AddRange(new object[] { "Quản trị", "Thu ngân", "Thủ kho" });
            
            Label lbl6 = new Label { Text = "Mật khẩu", Left = 20, Top = 142, Width = 120 };
            txtPassword = new TextBox { Left = 150, Top = 138, Width = 190, UseSystemPasswordChar = true };
            
            btnSave = new Button { Text = "Lưu", Left = 150, Top = 185, Width = 90, DialogResult = DialogResult.OK };
            btnCancel = new Button { Text = "Hủy", Left = 250, Top = 185, Width = 90, DialogResult = DialogResult.Cancel };
            btnSave.Click += BtnSave_Click;

            if (_editing != null)
            {
                txtUsername.Text = _editing.Username; 
                txtUsername.Enabled = false; 
                txtDisplayName.Text = _editing.DisplayName;
                cboRole.SelectedIndex = RoleToIndex(_editing.Role);
                
                // Nếu đang sửa tài khoản hiện tại đang đăng nhập và là Admin, không cho đổi quyền
                if (!string.IsNullOrEmpty(_currentUsername) && 
                    _editing.Username.Equals(_currentUsername, StringComparison.OrdinalIgnoreCase) &&
                    _editing.Role == RoleType.Admin)
                {
                    cboRole.Enabled = false; // Khóa không cho đổi quyền
                }
                
                txtPassword.Enabled = false; 
                txtPassword.Text = string.Empty; // Not editing password
                
                this.Controls.AddRange(new Control[] { lbl1, txtUsername, lbl2, txtDisplayName, lbl4, cboRole, lbl6, txtPassword, btnSave, btnCancel });
            }
            else
            {
                cboRole.SelectedIndex = 1; // default Thu ngân
                this.Controls.AddRange(new Control[] { lbl1, txtUsername, lbl2, txtDisplayName, lbl4, cboRole, lbl6, txtPassword, btnSave, btnCancel });
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
        
        private RoleType IndexToRole(int idx) 
        { 
            if (idx == 0) return RoleType.Admin; 
            if (idx == 1) return RoleType.Cashier; 
            return RoleType.InventoryManager; 
        }

        private bool ValidatePassword(string password, out string errorMessage)
        {
            errorMessage = string.Empty;

            // Kiểm tra độ dài tối thiểu 9 ký tự
            if (password.Length < 9)
            {
                errorMessage = "Mật khẩu phải có ít nhất 9 ký tự!";
                return false;
            }

            // Kiểm tra có chữ hoa (A-Z)
            if (!Regex.IsMatch(password, @"[A-Z]"))
            {
                errorMessage = "Mật khẩu phải có ít nhất 1 chữ in hoa!";
                return false;
            }

            // Kiểm tra có chữ thường (a-z)
            if (!Regex.IsMatch(password, @"[a-z]"))
            {
                errorMessage = "Mật khẩu phải có ít nhất 1 chữ thường!";
                return false;
            }

            // Kiểm tra có chữ số (0-9)
            if (!Regex.IsMatch(password, @"[0-9]"))
            {
                errorMessage = "Mật khẩu phải có ít nhất 1 chữ số!";
                return false;
            }

            // Kiểm tra có ký tự đặc biệt
            if (!Regex.IsMatch(password, @"[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>/?]"))
            {
                errorMessage = "Mật khẩu phải có ít nhất 1 ký tự đặc biệt (!@#$%^&*()_+-=[]{}...)!";
                return false;
            }

            return true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtDisplayName.Text))
            { 
                MessageBox.Show("Vui lòng nhập đầy đủ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                this.DialogResult = DialogResult.None; 
                return; 
            }
            
            if (_editing == null && _service.UsernameExists(txtUsername.Text))
            { 
                MessageBox.Show("Tên đăng nhập đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                this.DialogResult = DialogResult.None; 
                return; 
            }

            // Kiểm tra nếu đang sửa tài khoản admin hiện tại và cố đổi quyền
            if (_editing != null && 
                !string.IsNullOrEmpty(_currentUsername) &&
                _editing.Username.Equals(_currentUsername, StringComparison.OrdinalIgnoreCase) &&
                _editing.Role == RoleType.Admin &&
                IndexToRole(cboRole.SelectedIndex) != RoleType.Admin)
            {
                MessageBox.Show("Không được phép thay đổi quyền của tài khoản quản trị viên đang đăng nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            if (_editing == null)
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text)) 
                { 
                    MessageBox.Show("Nhập mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                    this.DialogResult = DialogResult.None; 
                    return; 
                }

                // Validate mật khẩu mạnh
                string errorMessage;
                if (!ValidatePassword(txtPassword.Text, out errorMessage))
                {
                    MessageBox.Show(errorMessage, "Mật khẩu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.None;
                    return;
                }

                var dto = new AccountDto 
                { 
                    Username = txtUsername.Text.Trim(), 
                    DisplayName = txtDisplayName.Text.Trim(), 
                    Role = IndexToRole(cboRole.SelectedIndex) 
                };
                _service.Create(dto, txtPassword.Text.Trim());
            }
            else
            {
                _editing.DisplayName = txtDisplayName.Text.Trim(); 
                _editing.Role = IndexToRole(cboRole.SelectedIndex); 
                _service.Update(_editing);
            }
        }
    }
}
