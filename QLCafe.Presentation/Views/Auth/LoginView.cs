using QLCafe.Application.DTOs.Auth;
using QLCafe.Application.Interfaces;
using QLCafe.Application.Services;
using QLCafe.Domain.Enums;
using QLCafe.Presentation.Views.Cashier;
using QLCafe.Presentation.Views.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QLCafe.Presentation.Views.Auth  
{
    public partial class LoginView : Form
    {
        private readonly IAuthService _authService;

        public LoginView()
        {
            InitializeComponent();
            _authService = new AuthService(Program.ConnectionString);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoginView_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            HandleLogin();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HandleLogin();
                e.Handled = true;
            }
        }

        private void HandleLogin()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi service đăng nhập
            var request = new LoginRequest
            {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text
            };

            var result = _authService.Login(request);

            if (result.IsSuccess)
            {
                MessageBox.Show($"Đăng nhập thành công!\nChào mừng {result.DisplayName}",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // TODO: Chuyển đến form chính theo role
                ShowMainForm(result);
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi đăng nhập",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowMainForm(LoginResponse userInfo)
        {
            // Ẩn form login
            this.Hide();

            // Kiểm tra role và mở form tương ứng
            try
            {
                switch (userInfo.Role)
                {
                    case RoleType.Admin:
                        AdminMainView adminForm = new AdminMainView(userInfo.DisplayName, "Quản trị viên");

                        adminForm.Show();
                        break;

                    case RoleType.Cashier:  // Sửa thành Cashier thay vì ThuNgan
                                            // Mở form chính của thu ngân
                        CashierMainView cashierForm = new CashierMainView(userInfo.DisplayName, "Ca sáng");
                       
                        cashierForm.Show();
                        break;

                    case RoleType.InventoryManager:  // Sửa thành InventoryManager thay vì ThuKho
                        MessageBox.Show("Chức năng Thủ kho đang phát triển", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Show();
                        break;

                    default:
                        MessageBox.Show("Role không hợp lệ", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Show();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HandleLogin();
                e.Handled = true;
            }

        }
    }
}