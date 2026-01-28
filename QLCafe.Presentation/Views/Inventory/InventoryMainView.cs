using QLCafe.Presentation.Views.Auth;
using System;
using System.Windows.Forms;

namespace QLCafe.Presentation.Views.Inventory
{
    public partial class InventoryMainView : Form
    {
        // ===== FORM CON =====
        private InventoryViewForm inventoryViewForm;
        private StockInForm stockInForm;
        private StockInHistoryForm stockInHistoryForm;
        private InventoryReportForm inventoryReportForm;

        public InventoryMainView()
        {
            InitializeComponent();
        }

        public InventoryMainView(string userName, string shift)
        {
            InitializeComponent();
            lblUserName.Text = userName;
            lblShift.Text = shift;
            
            InitializeForms();
            ShowInventoryView(); // Mặc định mở xem tồn kho
        }

        private void InitializeForms()
        {
            inventoryViewForm = new InventoryViewForm();
            stockInForm = new StockInForm();
            stockInHistoryForm = new StockInHistoryForm();
            inventoryReportForm = new InventoryReportForm();
        }

        // --- HÀM QUAN TRỌNG NHẤT: CHUYỂN FORM KHÔNG BỊ LỆCH ---
        private void SwitchForm(Form childForm, string title)
        {
            // 1. Xóa nội dung cũ
            panelContent.Controls.Clear();

            // 2. Cấu hình Form con
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;

            // 3. THÊM VÀO PANEL TRƯỚC (QUAN TRỌNG)
            panelContent.Controls.Add(childForm);

            // 4. SAU ĐÓ MỚI SET DOCK (ĐỂ NÓ TỰ TÍNH TOÁN KÍCH THƯỚC)
            childForm.Dock = DockStyle.Fill;
            childForm.BringToFront();

            // 5. Hiển thị
            childForm.Show();
            UpdateHeader(title);
        }

        // ================== BUTTON EVENT ==================
        private void bttViewinventory_Click(object sender, EventArgs e) => ShowInventoryView();
        private void btnStockin_Click(object sender, EventArgs e) => ShowStockIn();
        private void btnEntryhistory_Click(object sender, EventArgs e) => ShowStockInHistory();
        private void bttWarehousereport_Click(object sender, EventArgs e) => ShowInventoryReport();

        private void btnLogout_Click(object sender, EventArgs e) => Logout();

        // ================== SHOW FORM HELPER ==================
        private void ShowInventoryView() => SwitchForm(inventoryViewForm, "XEM TỒN KHO");
        private void ShowStockIn() => SwitchForm(stockInForm, "NHẬP KHO");
        private void ShowStockInHistory() => SwitchForm(stockInHistoryForm, "LỊCH SỬ NHẬP KHO");
        private void ShowInventoryReport() => SwitchForm(inventoryReportForm, "BÁO CÁO KHO");

        // ================== COMMON ==================
        private void UpdateHeader(string functionName)
        {
            if (lblFunctionName != null) lblFunctionName.Text = functionName;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label5 != null) label5.Text = DateTime.Now.ToString("hh:mm tt");
        }

        private void Logout()
        {
            var result = MessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                new LoginView().Show();
                this.Close();
            }
        }
    }
}