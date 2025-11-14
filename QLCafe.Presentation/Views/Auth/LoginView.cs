using QLCafe.Application.DTOs.Auth;
using QLCafe.Application.Interfaces;
using QLCafe.Application.Services;
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
            _authService = new AuthService(); // Tạm thời new trực tiếp
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoginView_Load(object sender, EventArgs e)
        {
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
            // Validation cơ bản
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
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

                // TODO: Chuyển đến Main Form
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
            // Tạm thời tạo Main Form đơn giản
            var mainForm = new Form
            {
                Text = $"QL Cafe - {userInfo.DisplayName} ({userInfo.Role})",
                WindowState = FormWindowState.Maximized
            };

            this.Hide();
            mainForm.ShowDialog();
            this.Close();
        }
    }
}