using QLCafe.Presentation.Views.Auth;
using QLCafe.Presentation.Views.History;
using System;
using System.Windows.Forms;

namespace QLCafe.Presentation.Views.Cashier
{
    public partial class CashierMainView : Form
    {
        private TableManagementForm tableManagementForm;
        private OrderHistoryForm orderHistoryForm;
        private ShiftReportForm shiftReportForm;

        // Constructor mặc định (Ít dùng, nhưng giữ để tránh lỗi Designer)
        public CashierMainView()
        {
            InitializeComponent();
        }

        // Constructor chính (Được gọi từ Login)
        public CashierMainView(string userName, string shift)
        {
            InitializeComponent();

            // 1. TRUYỀN userName VÀO HÀM KHỞI TẠO FORM CON
            InitializeForms(userName);

            lblUserName.Text = userName;
            lblShift.Text = shift;

            // Hiển thị màn hình quản lý bàn đầu tiên
            ShowTableManagement();
        }

        // 2. SỬA HÀM NÀY: Thêm tham số string userName
        private void InitializeForms(string userName)
        {
            // Khởi tạo các form con

            // 3. TRUYỀN userName XUỐNG TableManagementForm ĐỂ NÓ BIẾT AI ĐANG THAO TÁC
            tableManagementForm = new TableManagementForm(userName);

            orderHistoryForm = new OrderHistoryForm();
            shiftReportForm = new ShiftReportForm();

            SetFormProperties(tableManagementForm);
            SetFormProperties(orderHistoryForm);
            SetFormProperties(shiftReportForm);
        }

        private void SetFormProperties(Form form)
        {
            form.TopLevel = false;      // Cho phép nhúng vào control khác
            form.FormBorderStyle = FormBorderStyle.None; // Ẩn border
            form.Dock = DockStyle.Fill; // Fill toàn bộ panel
        }

        // --- CÁC SỰ KIỆN NÚT BẤM GIỮ NGUYÊN ---

        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToString("hh:mm tt");
        }

        private void btnTableManagement_Click(object sender, EventArgs e)
        {
            ShowTableManagement();
        }

        private void btnPayment_Click(object sender, EventArgs e) { }

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

        // --- CÁC HÀM HIỂN THỊ FORM CON ---

        private void ShowTableManagement()
        {
            ClearPanelContent();
            // Nếu form chưa được khởi tạo (trường hợp gọi constructor mặc định), thì tạo mới
            if (tableManagementForm == null)
            {
                // Fallback nếu không có username (dùng tạm tên mặc định)
                tableManagementForm = new TableManagementForm(lblUserName.Text != "" ? lblUserName.Text : "Admin");
                SetFormProperties(tableManagementForm);
            }

            panelContent.Controls.Add(tableManagementForm);
            tableManagementForm.Show();

            UpdateHeader("QUẢN LÝ BÀN");
        }

        private void ShowOrderHistory()
        {
            ClearPanelContent();
            if (orderHistoryForm == null)
            {
                orderHistoryForm = new OrderHistoryForm();
                SetFormProperties(orderHistoryForm);
            }
            panelContent.Controls.Add(orderHistoryForm);
            orderHistoryForm.Show();
            UpdateHeader("LỊCH SỬ ORDER");
        }

        private void ShowShiftReport()
        {
            ClearPanelContent();
            if (shiftReportForm == null)
            {
                shiftReportForm = new ShiftReportForm();
                SetFormProperties(shiftReportForm);
            }
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
            if (lblFunctionName != null)
            {
                lblFunctionName.Text = functionName;
            }
        }

        private void Logout()
        {
            var result = MessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoginView loginForm = new LoginView();
                loginForm.Show();
                this.Close();
            }
        }
    }
}