using QLCafe.Presentation.Views.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCafe.Presentation.Views.Admin
{
    public partial class AdminMainView : Form
    {
        private AccountManagementForm2 accountManagementForm;
        private MenuManagementForm menuManagementForm;
        private OrganizationForm organizationForm;
        private SalesReportForm salesReportForm;
        private StockReportForm stockReportForm;
        private string _currentUsername; // Lưu username đang đăng nhập

        public AdminMainView()
        {
            InitializeComponent();
        }

        public AdminMainView(string userName, string shift)
        {
            InitializeComponent();
            InitializeForms();

            lblUserName.Text = userName;
            lblShift.Text = shift;
            ShowAccountManagement();
        }

        public AdminMainView(string userName, string shift, string username)
        {
            InitializeComponent();
            _currentUsername = username; // Lưu username
            InitializeForms();

            lblUserName.Text = userName;
            lblShift.Text = shift;
            ShowAccountManagement();
        }

        private void InitializeForms()
        {
            // Khởi tạo các form con
            accountManagementForm = new AccountManagementForm2(_currentUsername);
            menuManagementForm = new MenuManagementForm();
            organizationForm = new OrganizationForm();
            salesReportForm = new SalesReportForm();
            stockReportForm = new StockReportForm();

            SetFormProperties(accountManagementForm);
            SetFormProperties(menuManagementForm);
            SetFormProperties(organizationForm);
            SetFormProperties(salesReportForm);
            SetFormProperties(stockReportForm);
        }

        private void SetFormProperties(Form form)
        {
            form.TopLevel = false;     // Cho phép nhúng vào control khác
            form.FormBorderStyle = FormBorderStyle.None; // Ẩn border
            form.Dock = DockStyle.Fill; // Fill toàn bộ panel
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToString("hh:mm tt");
        }

        private void bttUserAccount_Click(object sender, EventArgs e)
        {
            ShowAccountManagement();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            ShowMenuManagement();
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            ShowOrganization();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            ShowStockReport();
        }

        private void bttSaleReport_Click(object sender, EventArgs e)
        {
            ShowSalesReport();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void ShowAccountManagement()
        {
            ClearPanelContent();
            panelContent.Controls.Add(accountManagementForm);
            accountManagementForm.Show();

            UpdateHeader("QUẢN LÝ TÀI KHOẢN");
        }

        private void ShowMenuManagement()
        {
            ClearPanelContent();
            panelContent.Controls.Add(menuManagementForm);
            menuManagementForm.Show();
            UpdateHeader("QUẢN LÝ MENU");
        }

        private void ShowOrganization()
        {
            ClearPanelContent();
            panelContent.Controls.Add(organizationForm);
            organizationForm.Show();
            UpdateHeader("QUẢN LÝ BÀN");
        }

        private void ShowSalesReport()
        {
            ClearPanelContent();
            panelContent.Controls.Add(salesReportForm);
            salesReportForm.Show();
            UpdateHeader("BÁO CÁO DOANH THU");
        }

        private void ShowStockReport()
        {
            ClearPanelContent();
            panelContent.Controls.Add(stockReportForm);
            stockReportForm.Show();
            UpdateHeader("BÁO CÁO TỒN KHO");
        }

        private void ClearPanelContent()
        {
            foreach (Control control in panelContent.Controls)
            {
                if (control is Form form)
                {
                    form.Hide();
                }
            }
            panelContent.Controls.Clear();
        }

        private void UpdateHeader(string functionName)
        {
            if (lblFunctionName != null) // Kiểm tra null
            {
                lblFunctionName.Text = functionName;
            }
            else
            {
                MessageBox.Show("lblFunctionName chưa được khởi tạo!");
            }
        }

        private void Logout()
        {
            var result = MessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Mở lại form Login
                LoginView loginForm = new LoginView();
                loginForm.Show();
                this.Close(); // Đóng form thu ngân
            }
        }
    }
}
