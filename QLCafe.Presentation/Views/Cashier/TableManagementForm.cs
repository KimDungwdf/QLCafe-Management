using Dapper;
using QLCafe.Application.Services;
using QLCafe.Presentation.Controls.Table;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace QLCafe.Presentation.Views.Cashier
{
    public partial class TableManagementForm : Form
    {
        private string connectionString;
        private string currentUser = "thungan1"; // 🟢 THÊM BIẾN CURRENT USER

        public TableManagementForm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["QLCafeConnection"].ConnectionString;

            LoadTablesFromDatabase();
        }

        private void LoadTablesFromDatabase()
        {
            flowLayoutTables.Controls.Clear();

            try
            {
                var tableService = new TableService();
                var tableStatuses = tableService.GetTableStatusList();

                foreach (var tableStatus in tableStatuses)
                {
                    var tableControl = new TableButtonControl();
                    tableControl.TableData = tableStatus;
                    tableControl.TableID = tableStatus.Id;

                    // CLICK TRÁI VÀO BÀN
                    tableControl.TableClicked += (sender, e) =>
                    {
                        var clickedTable = (TableButtonControl)sender;
                        OnTableButtonClick(clickedTable.TableID, clickedTable.TableName);
                    };

                    // 🆕 CLICK VÀO BUTTON "THÊM MÓN"
                    tableControl.AddDishClicked += (sender, tableId) =>
                    {
                        OpenAddDishForm(tableId);
                    };

                    // 🆕 CLICK VÀO BUTTON "CHUYỂN BÀN"
                    tableControl.SwitchTableClicked += (sender, tableId) =>
                    {
                        OpenSwitchTableForm(tableId);
                    };

                    // 🆕 CLICK VÀO BUTTON "TẠO HÓA ĐƠN"
                    tableControl.CreateBillClicked += (sender, tableId) =>
                    {
                        OpenCreateBillForm(tableId);
                    };

                    flowLayoutTables.Controls.Add(tableControl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách bàn: {ex.Message}");
            }
        }

        // 🟢 PHƯƠNG THỨC XỬ LÝ CLICK BÀN
        private void OnTableButtonClick(int tableID, string tableName)
        {
            // Kiểm tra nếu bàn trống
            if (IsTableEmpty(tableID))
            {
                // MỞ ORDERFORM CHO BÀN TRỐNG
                var orderForm = new OrderForm(tableID, tableName, currentUser);
                var result = orderForm.ShowDialog(); // 🟢 DÙNG ShowDialog() ĐỂ CHỜ KẾT QUẢ

                // 🟢 SAU KHI ORDERFORM ĐÓNG, CẬP NHẬT LẠI GIAO DIỆN BÀN
                if (result == DialogResult.OK)
                {
                    RefreshTableStatus(); // 🟢 LOAD LẠI TOÀN BỘ DANH SÁCH BÀN
                    MessageBox.Show($"Đã tạo order cho {tableName}!", "Thành công",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Bàn đã có khách -> Mở form "Thêm món" (sẽ làm sau)
                MessageBox.Show($"Bàn {tableName} đã có khách! Vui lòng chọn 'Thêm món' hoặc chọn bàn khác!", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 🟢 PHƯƠNG THỨC KIỂM TRA BÀN TRỐNG
        private bool IsTableEmpty(int tableID)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var tableStatus = connection.QueryFirstOrDefault<int>(
                        "SELECT TrangThai FROM Ban WHERE IDBan = @TableID",
                        new { TableID = tableID }
                    );

                    return tableStatus == 0; // 0 = Trống, 1 = Có khách
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra trạng thái bàn: {ex.Message}");
                return false;
            }
        }

        // 🟢 PHƯƠNG THỨC CẬP NHẬT LẠI TRẠNG THÁI BÀN
        private void RefreshTableStatus()
        {
            LoadTablesFromDatabase(); // 🟢 RELOAD LẠI TOÀN BỘ DANH SÁCH BÀN
        }

        // Class để map dữ liệu từ database
        public class TableInfo
        {
            public int IDBan { get; set; }
            public string TenBan { get; set; }
            public int TrangThai { get; set; }
        }

        // 🟢 THÊM NÚT REFRESH ĐỂ CẬP NHẬT THỦ CÔNG (NẾU CẦN)
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshTableStatus();
        }

        // 🆕 THÊM CÁC PHƯƠNG THỨC XỬ LÝ BUTTON
        private void OpenAddDishForm(int tableId)
        {
            // TẠM THỜI HIỆN MESSAGEBOX - SAU SẼ THAY BẰNG FORM THẬT
            MessageBox.Show($"Mở form Thêm món cho bàn {tableId}", "Thêm món");

            // SAU NÀY: 
            // var addDishForm = new AddDishForm(tableId);
            // addDishForm.ShowDialog();
            // RefreshTableStatus(); // Cập nhật lại sau khi thêm món
        }

        private void OpenSwitchTableForm(int tableId)
        {
            MessageBox.Show($"Mở form Chuyển bàn cho bàn {tableId}", "Chuyển bàn");
        }

        private void OpenCreateBillForm(int tableId)
        {
            MessageBox.Show($"Mở form Tạo hóa đơn cho bàn {tableId}", "Tạo hóa đơn");
        }
    }
}