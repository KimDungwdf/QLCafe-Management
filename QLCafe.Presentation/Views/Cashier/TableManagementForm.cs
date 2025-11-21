using QLCafe.Presentation.Controls.Table;
using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using QLCafe.Application.Interfaces;
using QLCafe.Application.Services;
using QLCafe.Infrastructure.Repositories;

namespace QLCafe.Presentation.Views.Cashier
{
    public partial class TableManagementForm : Form
    {
        private string connectionString;
        private string currentUser = "thungan1";
        private ITableService _tableService;
        private IOrderService _orderService;

        public TableManagementForm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["QLCafeConnection"].ConnectionString;

            var tableRepository = new TableRepository(connectionString);
            var orderRepository = new OrderRepository(connectionString);
            _tableService = new TableService(tableRepository, orderRepository);
            _orderService = new OrderService(orderRepository);

            LoadTablesFromDatabase();
        }

        private void LoadTablesFromDatabase()
        {
            flowLayoutTables.Controls.Clear();

            try
            {
                var tableStatuses = _tableService.GetTableStatusList();

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

                    // CLICK VÀO BUTTON "THÊM MÓN"
                    tableControl.AddDishClicked += (sender, tableId) =>
                    {
                        OpenAddDishForm(tableId);
                    };

                    // CLICK VÀO BUTTON "CHUYỂN BÀN"
                    tableControl.SwitchTableClicked += (sender, tableId) =>
                    {
                        OpenSwitchTableForm(tableId);
                    };

                    // CLICK VÀO BUTTON "TẠO HÓA ĐƠN"
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

        // PHƯƠNG THỨC XỬ LÝ CLICK BÀN
        private void OnTableButtonClick(int tableID, string tableName)
        {
            // Kiểm tra nếu bàn trống - DÙNG SERVICE
            if (IsTableEmpty(tableID))
            {
                // MỞ ORDERFORM CHO BÀN TRỐNG
                var orderForm = new OrderForm(tableID, tableName, currentUser);
                var result = orderForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    RefreshTableStatus();
                    MessageBox.Show($"Đã tạo order cho {tableName}!", "Thành công",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Bàn đã có khách -> Mở form "Thêm món"
                MessageBox.Show($"Bàn {tableName} đã có khách! Vui lòng chọn 'Thêm món' hoặc chọn bàn khác!", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 🟢 PHƯƠNG THỨC KIỂM TRA BÀN TRỐNG - DÙNG SERVICE
        private bool IsTableEmpty(int tableID)
        {
            try
            {
                // DÙNG SERVICE THAY VÌ DIRECT DB ACCESS
                return _tableService.IsTableEmpty(tableID);
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
            LoadTablesFromDatabase();
        }

        // 🟢 NÚT REFRESH
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshTableStatus();
        }

        // 🟢 MỞ FORM THÊM MÓN - ĐÃ CẬP NHẬT THÀNH FORM THẬT
        private void OpenAddDishForm(int tableId)
        {
            try
            {
                string tableName = GetTableNameById(tableId);
                var addDishForm = new AddDishForm(tableId, tableName, currentUser);
                var result = addDishForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    RefreshTableStatus();
                    MessageBox.Show($"Đã thêm món cho {tableName}!", "Thành công",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form thêm món: {ex.Message}", "Lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🟢 PHƯƠNG THỨC LẤY TÊN BÀN THEO ID - DÙNG SERVICE
        private string GetTableNameById(int tableId)
        {
            try
            {
                var table = _tableService.GetTableById(tableId);
                return table?.Name ?? $"Bàn {tableId}";
            }
            catch
            {
                return $"Bàn {tableId}";
            }
        }

        private void OpenSwitchTableForm(int tableId)
        {
            try
            {
                string tableName = GetTableNameById(tableId);

                // Mở form chuyển bàn
                var switchTableForm = new SwitchTableForm(tableId, tableName, currentUser, _tableService, _orderService);
                var result = switchTableForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    RefreshTableStatus();
                    MessageBox.Show($"Đã chuyển bàn {tableName} thành công!", "Thành công",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form chuyển bàn: {ex.Message}", "Lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenCreateBillForm(int tableId)
        {
            try
            {
                // 1. Lấy tên bàn
                string tableName = GetTableNameById(tableId);

                // 2. Mở Form Thanh Toán (CreateBillForm)
                // Truyền đủ 4 tham số: ID Bàn, Tên Bàn, Người dùng, Service
                var createBillForm = new CreateBillForm(tableId, tableName, currentUser, _orderService);

                var result = createBillForm.ShowDialog();

                // 3. Nếu thanh toán thành công (Form trả về OK)
                if (result == DialogResult.OK)
                {
                    // Tải lại danh sách bàn (để bàn vừa thanh toán chuyển sang màu Trống/Xanh)
                    RefreshTableStatus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}