using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using QLCafe.Application.DTOs.Account;
using QLCafe.Application.Services;
using QLCafe.Domain.Enums;

namespace QLCafe.Presentation.Views.Admin
{
    public partial class AccountManagementForm2 : Form
    {
        private AccountService _accountService;
        private BindingList<AccountRow2> _rows;
        private System.Collections.Generic.List<AccountRow2> _allRows;
        private string _currentUsername; // Lưu username đang đăng nhập

        public AccountManagementForm2()
        {
            InitializeComponent();

            Load += AccountManagementForm2_Load;

            // Search placeholder behavior
            txtSearch.GotFocus += (s, e) => { if (txtSearch.Text == "Tìm kiếm") { txtSearch.Text = string.Empty; txtSearch.ForeColor = Color.Black; } };
            txtSearch.LostFocus += (s, e) => { if (string.IsNullOrWhiteSpace(txtSearch.Text)) { txtSearch.Text = "Tìm kiếm"; txtSearch.ForeColor = Color.Gray; } };
            txtSearch.ForeColor = Color.Gray;
            txtSearch.TextChanged += txtSearch_TextChanged;

            btnAddAccount.Click += btnAddAccount_Click;

            // Style tweak
            dgvAccounts.ColumnHeadersHeight = 56;
        }

        public AccountManagementForm2(string currentUsername) : this()
        {
            _currentUsername = currentUsername;
        }

        private void AccountManagementForm2_Load(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["QLCafeConnection"].ConnectionString;
            _accountService = new AccountService(conn);
            InitGrid();
            LoadData();
        }

        private void InitGrid()
        {
            dgvAccounts.AutoGenerateColumns = false;
            // Map data properties (bỏ Status)
            colUsername.DataPropertyName = nameof(AccountRow2.UserName);
            colFullName.DataPropertyName = nameof(AccountRow2.FullName);
            colRole.DataPropertyName = nameof(AccountRow2.Role);
        }

        private void LoadData()
        {
            var data = _accountService.GetAll();
            _allRows = data.Select(d => new AccountRow2
            {
                UserName = d.Username,
                FullName = d.DisplayName,
                Role = MapRole(d.Role)
                // Bỏ Status
            }).ToList();
            ApplyFilter();
        }

        private string MapRole(RoleType role)
        {
            switch (role)
            {
                case RoleType.Admin: return "Quản trị";
                case RoleType.Cashier: return "Thu ngân";
                case RoleType.InventoryManager: return "Thủ kho";
                default: return role.ToString();
            }
        }

        private RoleType ParseRole(string roleText)
        {
            if (roleText == "Quản trị") return RoleType.Admin;
            if (roleText == "Thu ngân") return RoleType.Cashier;
            if (roleText == "Thủ kho") return RoleType.InventoryManager;
            return RoleType.Cashier;
        }

        private void ApplyFilter()
        {
            if (_allRows == null) return;
            var termRaw = txtSearch.Text ?? string.Empty;
            var term = termRaw == "Tìm kiếm" ? string.Empty : termRaw.Trim().ToLowerInvariant();
            var view = string.IsNullOrEmpty(term)
                ? _allRows
                : _allRows.Where(r => (r.UserName ?? "").ToLowerInvariant().Contains(term)
                                    || (r.FullName ?? "").ToLowerInvariant().Contains(term)
                                    || (r.Role ?? "").ToLowerInvariant().Contains(term)).ToList();
            _rows = new BindingList<AccountRow2>(view);
            dgvAccounts.DataSource = _rows;
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            using (var f = new AccountEditDialog(_accountService, null, _currentUsername))
            {
                if (f.ShowDialog() == DialogResult.OK) LoadData();
            }
        }

        // Handle click inside actions cell: determine whether user clicked "Sửa" or "Xóa" by x position
        private void dgvAccounts_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvAccounts.Columns[e.ColumnIndex].Name != "colActions") return;
            var row = dgvAccounts.Rows[e.RowIndex].DataBoundItem as AccountRow2;
            if (row == null) return;

            // Calculate zones similar to painting
            var cellRect = dgvAccounts.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            int padding = 12;
            // Assume two link segments: "Sửa" and "Xóa" separated by a vertical bar
            using (var f = new Font("Segoe UI", 11f, FontStyle.Underline))
            {
                var g = dgvAccounts.CreateGraphics();
                Size editSize = TextRenderer.MeasureText(g, "Sửa", f, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.NoPadding);
                Size deleteSize = TextRenderer.MeasureText(g, "Xóa", f, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.NoPadding);
                int xEdit = cellRect.X + padding;
                var editRect = new Rectangle(xEdit, cellRect.Y + (cellRect.Height - editSize.Height) / 2, editSize.Width, editSize.Height);
                int xDelete = editRect.Right + 12 + 6; // 12 for separator padding, 6 for separator width/margin
                var deleteRect = new Rectangle(xDelete, cellRect.Y + (cellRect.Height - deleteSize.Height) / 2, deleteSize.Width, deleteSize.Height);

                var clickPoint = new Point(e.X + cellRect.X, e.Y + cellRect.Y);
                if (editRect.Contains(clickPoint))
                {
                    using (var dialog = new AccountEditDialog(_accountService, new AccountDto
                    {
                        Username = row.UserName,
                        DisplayName = row.FullName,
                        Role = ParseRole(row.Role)
                        // Bỏ Status
                    }, _currentUsername))
                    {
                        if (dialog.ShowDialog() == DialogResult.OK) LoadData();
                    }
                }
                else if (deleteRect.Contains(clickPoint))
                {
                    // Kiểm tra nếu đang cố xóa tài khoản admin đang đăng nhập
                    if (!string.IsNullOrEmpty(_currentUsername) && 
                        row.UserName.Equals(_currentUsername, StringComparison.OrdinalIgnoreCase) &&
                        ParseRole(row.Role) == RoleType.Admin)
                    {
                        MessageBox.Show("Không được phép xóa tài khoản quản trị viên đang đăng nhập!", 
                            "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (MessageBox.Show($"Xóa tài khoản '{row.UserName}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _accountService.Delete(row.UserName);
                        LoadData();
                    }
                }
            }
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

                using (Pen p = new Pen(Color.FromArgb(220, 220, 220)))
                {
                    e.Graphics.DrawLine(p, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }

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

            // Custom paint for Actions column: draw two links "Sửa" | "Xóa"
            if (dgvAccounts.Columns[e.ColumnIndex].Name == "colActions")
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                int padding = 12;
                using (var linkFont = new Font("Segoe UI", 11f, FontStyle.Underline))
                using (var blue = new SolidBrush(Color.FromArgb(33, 99, 255)))
                using (var red = new SolidBrush(Color.Firebrick))
                using (var sepPen = new Pen(Color.Silver))
                {
                    Size editSize = TextRenderer.MeasureText(g, "Sửa", linkFont, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.NoPadding);
                    Size deleteSize = TextRenderer.MeasureText(g, "Xóa", linkFont, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.NoPadding);
                    int xEdit = e.CellBounds.X + padding;
                    int y = e.CellBounds.Y + (e.CellBounds.Height - editSize.Height) / 2;
                    g.DrawString("Sửa", linkFont, blue, new PointF(xEdit, y));

                    int sepX = xEdit + editSize.Width + 6;
                    g.DrawLine(sepPen, sepX, e.CellBounds.Y + 12, sepX, e.CellBounds.Bottom - 12);

                    int xDelete = sepX + 6;
                    g.DrawString("Xóa", linkFont, red, new PointF(xDelete, y));
                }
                e.Paint(e.ClipBounds, DataGridViewPaintParts.Border);
                return;
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
            ApplyFilter();
        }
    }

    internal class AccountRow2
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
    }
}
