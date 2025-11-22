using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLCafe.Presentation.Controls.Table
{
    public partial class BillItemRowControl : UserControl
    {
        public BillItemRowControl()
        {
            InitializeComponent();
            // Đặt kích thước mặc định cho dòng này
            this.Size = new Size(750, 40);
            this.BackColor = Color.White;
            this.Margin = new Padding(0, 2, 0, 2);
        }

        // Hàm này nhận dữ liệu từ bên ngoài đổ vào các Label
        public void SetData(string tenMon, int soLuong, decimal donGia)
        {
            // Xóa các control cũ nếu có để tránh trùng lặp khi gọi lại
            this.Controls.Clear();
            this.Width = 720;

            // 1. Cột Thành tiền (Nằm sát bên phải)
            Label lblThanhTien = new Label();
            lblThanhTien.Text = (soLuong * donGia).ToString("N0");
            lblThanhTien.AutoSize = false;
            lblThanhTien.Width = 100;
            lblThanhTien.Dock = DockStyle.Right;
            lblThanhTien.TextAlign = ContentAlignment.MiddleRight;
            lblThanhTien.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            // 2. Cột Đơn giá
            Label lblDonGia = new Label();
            lblDonGia.Text = donGia.ToString("N0");
            lblDonGia.AutoSize = false;
            lblDonGia.Width = 90;
            lblDonGia.Dock = DockStyle.Right;
            lblDonGia.TextAlign = ContentAlignment.MiddleRight;

            // 3. Cột Số lượng (SL)
            Label lblSL = new Label();
            lblSL.Text = soLuong.ToString();
            lblSL.AutoSize = false;
            lblSL.Width = 40;
            lblSL.Dock = DockStyle.Right;
            lblSL.TextAlign = ContentAlignment.MiddleCenter;

            // 4. Cột Tên món (Chiếm hết phần còn lại bên trái)
            Label lblTenMon = new Label();
            lblTenMon.Text = tenMon;
            lblTenMon.Dock = DockStyle.Fill;
            lblTenMon.TextAlign = ContentAlignment.MiddleLeft;
            lblTenMon.AutoEllipsis = true;

            // 5. Kẻ đường gạch mờ dưới chân
            Panel pnlLine = new Panel();
            pnlLine.Height = 1;
            pnlLine.Dock = DockStyle.Bottom;
            pnlLine.BackColor = Color.WhiteSmoke;

            // --- ADD VÀO USER CONTROL (Thứ tự quan trọng) ---
            // Add từ dưới lên trên (Dock Right add trước)
            this.Controls.Add(lblTenMon);
            this.Controls.Add(lblSL);
            this.Controls.Add(lblDonGia);
            this.Controls.Add(lblThanhTien);
            this.Controls.Add(pnlLine);

            lblTenMon.Width = 350;  // Tên món rộng hơn
            lblSL.Width = 60;       // Số lượng
            lblDonGia.Width = 120;  // Đơn giá
            lblThanhTien.Width = 120; // Thành tiền
        }
    }
}