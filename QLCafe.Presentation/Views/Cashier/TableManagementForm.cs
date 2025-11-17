using QLCafe.Presentation.Controls.Table;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Dapper;

namespace QLCafe.Presentation.Views.Cashier
{
    public partial class TableManagementForm : Form
    {
        private string connectionString;
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
                using (var connection = new SqlConnection(connectionString))
                {
                    var tables = connection.Query<TableInfo>(
                        "sp_GetTableList",
                        commandType: CommandType.StoredProcedure
                    ).ToList();

                    foreach (var table in tables)
                    {
                        var tableControl = new TableButtonControl();
                        tableControl.TableID = table.IDBan;
                        tableControl.TableName = table.TenBan;
                        tableControl.Status = table.TrangThai == 0 ? "Trống" : "Có khách";
                        tableControl.OrderInfo = table.TrangThai == 0 ? "Nhấn để order" : "Đang phục vụ";

                        tableControl.TableClicked += (sender, e) =>
                        {
                            var clickedTable = (TableButtonControl)sender;

                            // MỞ ORDER FORM THẬT
                            var orderForm = new OrderForm(clickedTable.TableID, clickedTable.TableName, "thungan1");
                            orderForm.ShowDialog();

                            // Reload lại danh sách bàn để cập nhật trạng thái
                            LoadTablesFromDatabase();
                        };

                        flowLayoutTables.Controls.Add(tableControl);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách bàn: {ex.Message}\n\nChi tiết: {ex.InnerException?.Message}");
            }
        }

        // Class để map dữ liệu từ database
        public class TableInfo
        {
            public int IDBan { get; set; }
            public string TenBan { get; set; }
            public int TrangThai { get; set; }
        }
    }
}
