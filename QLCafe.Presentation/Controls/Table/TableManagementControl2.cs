using System;
using System.Windows.Forms;
using QLCafe.Application.DTOs.Table;

namespace QLCafe.Presentation.Controls.Table
{
    public partial class TableManagementControl2 : UserControl
    {
        public event EventHandler<int> EditRequested;
        public event EventHandler<int> DeleteRequested;

        public int TableId { get; private set; }
        public string TableNameText { get => lblTableName.Text; set => lblTableName.Text = value; }
        public string StatusText { get => lblStatusText.Text; set => lblStatusText.Text = value; }

        public TableManagementControl2()
        {
            InitializeComponent();
            btnEdit.Click += (s, e) => EditRequested?.Invoke(this, TableId);
            btnDelete.Click += (s, e) => DeleteRequested?.Invoke(this, TableId);
        }

        public void Bind(TableAdminItemDto dto)
        {
            TableId = dto.Id;
            TableNameText = dto.Name;
            StatusText = dto.StatusText;
            // status pill color by occupancy
            statusPill.BackColor = dto.IsOccupied ? System.Drawing.Color.FromArgb(250, 226, 226) : System.Drawing.Color.FromArgb(226, 245, 230);
            lblStatusText.ForeColor = dto.IsOccupied ? System.Drawing.Color.FromArgb(170, 60, 60) : System.Drawing.Color.FromArgb(60, 140, 90);

            // items
            if (dto.IsOccupied && dto.OrderItems != null && dto.OrderItems.Count > 0)
            {
                lblItems.Text = string.Join("\r\n", dto.OrderItems.ConvertAll(i => $"{i.ProductName} x{i.Quantity}"));
                itemsPanel.Visible = true;
                separator.Visible = true;
                lblTotalLabel.Visible = true;
                lblTotalAmount.Visible = true;
            }
            else
            {
                lblItems.Text = string.Empty;
                itemsPanel.Visible = false;
                separator.Visible = false;
                lblTotalLabel.Visible = false;
                lblTotalAmount.Visible = false;
            }

            if (dto.TotalAmount > 0)
            {
                lblTotalAmount.Text = $"{dto.TotalAmount:N0} đ";
            }
        }

        private void cardPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
