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
        private BindingList<AccountRow> _rows;
        private System.Collections.Generic.List<AccountRow> _allRows;

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
            dgvAccounts.CellContentClick += dgvAccounts_CellContentClick;

            // Style tweak
            dgvAccounts.ColumnHeadersHeight = 56;
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
            // Map data properties
            colUsername.DataPropertyName = nameof(AccountRow.UserName);
            colFullName.DataPropertyName = nameof(AccountRow.FullName);
            colRole.DataPropertyName = nameof(AccountRow.Role);
            colStatus.DataPropertyName = nameof(AccountRow.Status);
        }

        private void LoadData()
        {
            var data = _accountService.GetAll();
            _allRows = data.Select(d => new AccountRow
            {
                UserName = d.Username,
                FullName = d.DisplayName,
                Role = MapRole(d.Role),
                Status = string.IsNullOrEmpty(d.Status) ? "Hoạt động" : d.Status
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
                                    || (r.Role ?? "").ToLowerInvariant().Contains(term)
                                    || (r.Status ?? "").ToLowerInvariant().Contains(term)).ToList();
            _rows = new BindingList<AccountRow>(view);
            dgvAccounts.DataSource = _rows;
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            using (var f = new AccountEditDialog(_accountService))
            {
                if (f.ShowDialog() == DialogResult.OK) LoadData();
            }
        }

        private void dgvAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvAccounts.Columns[e.ColumnIndex] == colEdit)
            {
                var row = dgvAccounts.Rows[e.RowIndex].DataBoundItem as AccountRow;
                if (row == null) return;
                using (var f = new AccountEditDialog(_accountService, new AccountDto
                {
                    Username = row.UserName,
                    DisplayName = row.FullName,
                    Role = ParseRole(row.Role),
                    Status = row.Status
                }))
                {
                    if (f.ShowDialog() == DialogResult.OK) LoadData();
                }
            }
            else if (dgvAccounts.Columns[e.ColumnIndex] == colDelete)
            {
                var row = dgvAccounts.Rows[e.RowIndex].DataBoundItem as AccountRow;
                if (row == null) return;
                if (MessageBox.Show($"Xóa tài khoản '{row.UserName}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _accountService.Delete(row.UserName);
                    LoadData();
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
            ApplyFilter();
        }
    }
}
