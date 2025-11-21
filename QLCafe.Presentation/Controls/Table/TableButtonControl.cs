using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLCafe.Application.DTOs.Order;

namespace QLCafe.Presentation.Controls.Table
{
    public partial class TableButtonControl : UserControl
    {
        public event EventHandler TableClicked;
        public event EventHandler<int> AddDishClicked;
        public event EventHandler<int> SwitchTableClicked;
        public event EventHandler<int> CreateBillClicked;

        public TableButtonControl()
        {
            InitializeComponent();

            // Click event cho toàn bộ control
            panelMain.Click += (s, e) => TableClicked?.Invoke(this, e);
            lblTableName.Click += (s, e) => TableClicked?.Invoke(this, e);
            lblStatus.Click += (s, e) => TableClicked?.Invoke(this, e);
            lblOrderInfo.Click += (s, e) => TableClicked?.Invoke(this, e);
            listBoxOrderItems.Click += (s, e) => TableClicked?.Invoke(this, e);
            lblTotalAmount.Click += (s, e) => TableClicked?.Invoke(this, e);

            // CLICK EVENTS CHO 3 BUTTON MỚI (ĐÃ SỬA LỖI)
            btnAddDish.Click += (s, e) => AddDishClicked?.Invoke(this, TableID);
            btnSwitchTable.Click += (s, e) => SwitchTableClicked?.Invoke(this, TableID);
            btnCreateBill.Click += (s, e) => CreateBillClicked?.Invoke(this, TableID);
        }

        private TableStatusDto _tableData;
        public TableStatusDto TableData
        {
            get => _tableData;
            set
            {
                _tableData = value;
                UpdateControlView();
            }
        }

        public string TableName
        {
            get => lblTableName.Text;
            set => lblTableName.Text = value;
        }

        public string Status
        {
            get => lblStatus.Text;
            set
            {
                lblStatus.Text = value;
                lblStatus.ForeColor = value == "Trống" ? Color.Green : Color.Red;
            }
        }

        public string OrderInfo
        {
            get => lblOrderInfo.Text;
            set => lblOrderInfo.Text = value;
        }

        public int TableID { get; set; }

        private void UpdateControlView()
        {
            if (_tableData == null) return;

            TableName = _tableData.Name;
            Status = _tableData.Status;
            TableID = _tableData.Id;

            if (_tableData.Status == "Có khách")
            {
                lblOrderInfo.Visible = false;
                listBoxOrderItems.Visible = true;
                lblTotalAmount.Visible = true;
                btnAddDish.Visible = true;
                btnSwitchTable.Visible = true;
                btnCreateBill.Visible = true;

                listBoxOrderItems.Items.Clear();
                foreach (var item in _tableData.OrderItems)
                {
                    listBoxOrderItems.Items.Add($"{item.ProductName} x{item.Quantity}");
                }

                lblTotalAmount.Text = $"Tổng: {_tableData.TotalAmount.ToString("N0")} đ";
                panelMain.BackColor = Color.LightYellow;
            }
            else
            {
                lblOrderInfo.Visible = true;
                listBoxOrderItems.Visible = false;
                lblTotalAmount.Visible = false;
                btnAddDish.Visible = false;
                btnSwitchTable.Visible = false;
                btnCreateBill.Visible = false;
                panelMain.BackColor = SystemColors.Control;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // CÓ THỂ XÓA
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {

        }
    }
}