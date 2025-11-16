using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCafe.Presentation.Controls.Table
{
    public partial class TableButtonControl : UserControl
    {
        public event EventHandler TableClicked;
        public TableButtonControl()
        {
            InitializeComponent();
            // Click event cho toàn bộ control
            panelMain.Click += (s, e) => TableClicked?.Invoke(this, e);
            lblTableName.Click += (s, e) => TableClicked?.Invoke(this, e);
            lblStatus.Click += (s, e) => TableClicked?.Invoke(this, e);
            lblOrderInfo.Click += (s, e) => TableClicked?.Invoke(this, e);
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
                // Đổi màu theo trạng thái
                lblStatus.ForeColor = value == "Trống" ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            }
        }

        public string OrderInfo
        {
            get => lblOrderInfo.Text;
            set => lblOrderInfo.Text = value;
        }

        public int TableID { get; set; } // Để lưu ID bàn từ database
    }
}
