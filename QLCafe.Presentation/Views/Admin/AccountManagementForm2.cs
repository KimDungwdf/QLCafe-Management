using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QLCafe.Presentation.Views.Admin
{
    public partial class AccountManagementForm2 : Form
    {
        public AccountManagementForm2()
        {
            InitializeComponent();
            // optional demo data to see style quickly (design-time friendly removed in runtime if binding exists)
            if (!DesignMode)
            {
                dgvAccounts.Rows.Add("admin", "Quản Trị Viên", "Quản trị", "Hoạt động");
                dgvAccounts.Rows.Add("thukho1", "Nhân Viên Kho A", "Thủ kho", "Hoạt động");
                dgvAccounts.Rows.Add("thungan1", "Thu Ngân Ca Sáng", "Thu ngân", "Hoạt động");
                dgvAccounts.Rows.Add("thungan2", "Thu Ngân 02", "Thu ngân", "Hoạt động");
            }

            txtSearch.GotFocus += (s, e) => { if (txtSearch.Text == "Tìm kiếm") { txtSearch.Text = string.Empty; txtSearch.ForeColor = Color.Black; } };
            txtSearch.LostFocus += (s, e) => { if (string.IsNullOrWhiteSpace(txtSearch.Text)) { txtSearch.Text = "Tìm kiếm"; txtSearch.ForeColor = Color.Gray; } };
            txtSearch.ForeColor = Color.Gray;

            // Increase header height a bit
            dgvAccounts.ColumnHeadersHeight = 56;
        }

        private void dgvAccounts_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Paint header with blue gradient bar
            if (e.RowIndex == -1)
            {
                e.Handled = true;
                using (LinearGradientBrush lg = new LinearGradientBrush(e.CellBounds,
                           Color.FromArgb(48, 131, 242),
                           Color.FromArgb(33, 96, 219),
                           LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(lg, e.CellBounds);
                }

                // bottom separator
                using (Pen p = new Pen(Color.FromArgb(220, 220, 220)))
                {
                    e.Graphics.DrawLine(p, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }

                // Header text
                string text = Convert.ToString(e.FormattedValue);
                using (var f = new Font("Segoe UI", 12f, FontStyle.Bold))
                using (Brush fb = new SolidBrush(Color.White))
                {
                    var rect = new Rectangle(e.CellBounds.Left + 10, e.CellBounds.Top, e.CellBounds.Width - 20, e.CellBounds.Height);
                    var sf = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center };
                    e.Graphics.DrawString(text, f, fb, rect, sf);
                }
                return;
            }

            if (e.RowIndex < 0) return;

            // Custom paint for Status column as green pill
            if (dgvAccounts.Columns[e.ColumnIndex].Name == "colStatus" && e.Value != null)
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                var rect = new Rectangle(e.CellBounds.X + 12, e.CellBounds.Y + 10, e.CellBounds.Width - 24, e.CellBounds.Height - 20);
                using (GraphicsPath path = GetRoundRect(rect, 14))
                using (SolidBrush bg = new SolidBrush(Color.FromArgb(214, 245, 222)))
                using (SolidBrush fg = new SolidBrush(Color.FromArgb(24, 163, 78)))
                {
                    e.Graphics.FillPath(bg, path);
                    var f = new Font("Segoe UI", 10.5f, FontStyle.Bold);
                    var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    e.Graphics.DrawString(Convert.ToString(e.Value), f, fg, rect, sf);
                }
                e.Paint(e.ClipBounds, DataGridViewPaintParts.Border);
                return;
            }

            // Draw vertical separator between edit and delete link columns to mimic "Sửa | Xóa"
            if (dgvAccounts.Columns[e.ColumnIndex].Name == "colDelete")
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                var x = e.CellBounds.Left - 6;
                using (Pen p = new Pen(Color.Silver))
                {
                    e.Graphics.DrawLine(p, x, e.CellBounds.Top + 12, x, e.CellBounds.Bottom - 12);
                }
                e.Handled = true;
            }
        }

        private static GraphicsPath GetRoundRect(Rectangle r, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;
            Rectangle arc = new Rectangle(r.Location, new Size(d, d));
            path.AddArc(arc, 180, 90);
            arc.X = r.Right - d;
            path.AddArc(arc, 270, 90);
            arc.Y = r.Bottom - d;
            path.AddArc(arc, 0, 90);
            arc.X = r.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
