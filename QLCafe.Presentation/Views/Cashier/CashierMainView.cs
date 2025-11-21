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

namespace QLCafe.Presentation.Views.Cashier
{
    public partial class CashierMainView : Form
    {
        private TableManagementForm tableManagementForm;
        private OrderHistoryForm orderHistoryForm;
        private ShiftReportForm shiftReportForm;
        public CashierMainView()
        {
            InitializeComponent();
        }

        public CashierMainView(string userName, string shift)
        {
            InitializeComponent();
            InitializeForms();

            lblUserName.Text = userName;
            lblShift.Text = shift;
            ShowTableManagement();
        }

        private void InitializeForms()
        {
            // Khởi tạo các form con
            tableManagementForm = new TableManagementForm();
            orderHistoryForm = new OrderHistoryForm();
            shiftReportForm = new ShiftReportForm();

            SetFormProperties(tableManagementForm);
            SetFormProperties(orderHistoryForm);
            SetFormProperties(shiftReportForm);
        }

        private void SetFormProperties(Form form)
        {
            form.TopLevel = false;     // Cho phép nhúng vào control khác
            form.FormBorderStyle = FormBorderStyle.None; // Ẩn border
            form.Dock = DockStyle.Fill; // Fill toàn bộ panel
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToString("hh:mm tt");
        }

        private void btnTableManagement_Click(object sender, EventArgs e)
        {
            ShowTableManagement();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {;
        }

        private void btnOrderHistory_Click(object sender, EventArgs e)
        {
            ShowOrderHistory();
        }

        private void btnShiftReport_Click(object sender, EventArgs e)
        {
            ShowShiftReport();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }

        // PHƯƠNG THỨC HIỂN THỊ FORM
        private void ShowTableManagement()
        {
            ClearPanelContent();
            panelContent.Controls.Add(tableManagementForm);
            tableManagementForm.Show();

            UpdateHeader("QUẢN LÝ BÀN");
        }

        private void ShowOrderHistory()
        {
            ClearPanelContent(); 
            panelContent.Controls.Add(orderHistoryForm); 
            orderHistoryForm.Show();
            UpdateHeader("LỊCH SỬ ORDER");
        }

        private void ShowShiftReport()
        {
            ClearPanelContent();
            panelContent.Controls.Add(shiftReportForm); 
            shiftReportForm.Show();
            UpdateHeader("BÁO CÁO CA");
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
