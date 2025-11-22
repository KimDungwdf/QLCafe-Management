using System;
using System.Windows.Forms;
using QLCafe.Application.DTOs.Table;

namespace QLCafe.Presentation.Controls.Table
{
    public partial class TableManagementControl : UserControl
    {
        public event EventHandler<int> EditRequested;
        public event EventHandler<int> DeleteRequested;

        public int TableId { get; private set; }
        public string TableNameText { get => lblTableName.Text; set => lblTableName.Text = value; }
        public string StatusText { get => lblStatus.Text; set => lblStatus.Text = value; }

        public TableManagementControl()
        {
            InitializeComponent();
            btnEditDish.Click += (s, e) => EditRequested?.Invoke(this, TableId);
            btnDeleteTable.Click += (s, e) => DeleteRequested?.Invoke(this, TableId);
        }

        public void Bind(TableAdminItemDto dto)
        {
            TableId = dto.Id;
            TableNameText = dto.Name;
            StatusText = dto.StatusText;
            lblStatus.ForeColor = dto.IsOccupied ? System.Drawing.Color.Red : System.Drawing.Color.Green;
            // Show admin buttons
            btnEditDish.Visible = true;
            btnDeleteTable.Visible = true;
            // Hide order details area for admin view
            listBoxOrderItems.Visible = false;
            lblTotalAmount.Visible = dto.TotalAmount > 0;
            if (dto.TotalAmount > 0) lblTotalAmount.Text = $"Tổng: {dto.TotalAmount:N0} đ";
        }

        private void panelMain_Paint(object sender, PaintEventArgs e) { }
        private void btnAddDish_Click(object sender, EventArgs e) { }
    }
}
