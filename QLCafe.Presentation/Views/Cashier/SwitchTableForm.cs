using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QLCafe.Application.Interfaces;
using QLCafe.Application.DTOs.Table;
using QLCafe.Application.DTOs.Order;

namespace QLCafe.Presentation.Views.Cashier
{
    public partial class SwitchTableForm : Form
    {
        private readonly ITableService _tableService;
        private readonly IOrderService _orderService;
        private readonly int _currentTableId;
        private readonly string _currentTableName;
        private readonly string _currentUser;
        private TableStatusDto _currentTableStatus;

        public SwitchTableForm(int tableId, string tableName, string userName, ITableService tableService, IOrderService orderService)
        {
            InitializeComponent();
            _tableService = tableService;
            _orderService = orderService;
            _currentTableId = tableId;
            _currentTableName = tableName;
            _currentUser = userName;

            // Setup ComboBox draw mode
            comboBoxTargetTable.DrawMode = DrawMode.OwnerDrawFixed;
            comboBoxTargetTable.DrawItem += ComboBoxTargetTable_DrawItem;
        }

        private void SwitchTableForm_Load(object sender, EventArgs e)
        {
            LoadCurrentTableInfo();
            LoadAvailableTables();
        }

        private void LoadCurrentTableInfo()
        {
            try
            {
                // Lấy thông tin bàn hiện tại
                var tableStatusList = _tableService.GetTableStatusList();
                _currentTableStatus = tableStatusList.FirstOrDefault(t => t.Id == _currentTableId);

                if (_currentTableStatus != null)
                {
                    // Hiển thị thông tin bàn
                    lblTableName.Text = _currentTableStatus.Name;
                    lblTotalAmount.Text = _currentTableStatus.TotalAmount.ToString("N0") + " đ";

                    // Tính số món
                    int itemCount = _currentTableStatus.OrderItems?.Count ?? 0;
                    lblItemCount.Text = $"{itemCount} món đã order";
                }
                else
                {
                    lblTableName.Text = _currentTableName;
                    lblTotalAmount.Text = "0 đ";
                    lblItemCount.Text = "0 món đã order";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin bàn: {ex.Message}", "Lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAvailableTables()
        {
            try
            {
                // Lấy danh sách bàn trống
                var availableTables = _tableService.GetAvailableTables();

                // Clear ComboBox trước
                comboBoxTargetTable.Items.Clear();

                // Thêm placeholder text
                comboBoxTargetTable.Items.Add("-- Chọn bàn trống --");

                // Thêm danh sách bàn trống
                foreach (var table in availableTables)
                {
                    comboBoxTargetTable.Items.Add(table);
                }

                comboBoxTargetTable.DisplayMember = "Name";

                // Chọn item đầu tiên (placeholder)
                comboBoxTargetTable.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách bàn: {ex.Message}", "Lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxTargetTable_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            var item = comboBoxTargetTable.Items[e.Index];
            string text = (e.Index == 0) ? item.ToString() : ((TableDto)item).Name;

            // Nếu là placeholder, vẽ màu xám
            if (e.Index == 0)
            {
                using (var grayBrush = new SolidBrush(Color.Gray))
                using (var italicFont = new Font(e.Font, FontStyle.Italic))
                {
                    e.Graphics.DrawString(text, italicFont, grayBrush, e.Bounds);
                }
            }
            else
            {
                using (var blackBrush = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(text, e.Font, blackBrush, e.Bounds);
                }
            }

            e.DrawFocusRectangle();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Kiểm tra không được chọn placeholder
            if (comboBoxTargetTable.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng chọn bàn đích!", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxTargetTable.Focus();
                return;
            }

            // Lấy bàn đích được chọn
            var targetTable = (TableDto)comboBoxTargetTable.SelectedItem;

            // Kiểm tra không được chọn cùng bàn
            if (targetTable.Id == _currentTableId)
            {
                MessageBox.Show("Không thể chuyển cùng một bàn!", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra bàn có order không
            if (_currentTableStatus?.OrderItems == null || !_currentTableStatus.OrderItems.Any())
            {
                MessageBox.Show("Bàn này không có order để chuyển!", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị xác nhận
            var confirmResult = MessageBox.Show(
                $"Xác nhận chuyển từ {_currentTableName} sang {targetTable.Name}?\n\n" +
                $"{_currentTableStatus.OrderItems.Count} món sẽ được chuyển sang bàn mới.",
                "Xác nhận chuyển bàn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                PerformTableSwitch(targetTable);
            }
        }

        private void PerformTableSwitch(TableDto targetTable)
        {
            try
            {
                // Disable nút trong khi xử lý
                btnConfirm.Enabled = false;
                btnCancel.Enabled = false;
                btnConfirm.Text = "Đang xử lý...";

                var request = new SwitchTableRequest
                {
                    FromTableId = _currentTableId,
                    ToTableId = targetTable.Id,
                    UserName = _currentUser
                };

                // Thực hiện chuyển bàn
                bool success = _tableService.SwitchTable(request);

                if (success)
                {
                    MessageBox.Show($"Đã chuyển thành công từ {_currentTableName} sang {targetTable.Name}!",
                                  "Thành công",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Chuyển bàn thất bại!", "Lỗi",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chuyển bàn: {ex.Message}", "Lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Re-enable nút
                btnConfirm.Enabled = true;
                btnConfirm.Text = "Xác nhận";
                btnCancel.Enabled = true;
            }
        }

        private void comboBoxTargetTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Khi chọn bàn đích, validate để enable/disable nút xác nhận
            if (comboBoxTargetTable.SelectedIndex > 0)
            {
                btnConfirm.Enabled = true;
                btnConfirm.BackColor = Color.FromArgb(0, 192, 0);
                btnConfirm.ForeColor = Color.White;
            }
            else
            {
                btnConfirm.Enabled = false;
                btnConfirm.BackColor = Color.LightGray;
                btnConfirm.ForeColor = Color.DarkGray;
            }
        }
    }
}