using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLCafe.Application.DTOs.Account;
using QLCafe.Application.Services;
using QLCafe.Domain.Enums;
using System.Configuration;

namespace QLCafe.Presentation.Views.Admin
{
    public partial class AccountManagementForm : Form
    {
        private BindingList<AccountRow> _rows;
        private List<AccountRow> _allRows;
        private AccountService _accountService;

        public AccountManagementForm() { InitializeComponent(); }

        private void AccountManagementForm_Load(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["QLCafeConnection"].ConnectionString;
            _accountService = new AccountService(conn);
            InitGrid();
            LoadData();
        }

        private void InitGrid()
        {
            dgvAccounts.AutoGenerateColumns = false;
            foreach (DataGridViewColumn c in dgvAccounts.Columns) c.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
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

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            using (var f = new AccountEditDialog(_accountService))
                if (f.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void dgvAccounts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvAccounts.Columns[e.ColumnIndex].DataPropertyName == nameof(AccountRow.Role) && e.Value != null)
                e.Value = e.Value.ToString();
        }

        private void dgvAccounts_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvAccounts.Columns[e.ColumnIndex].Name == "colActions")
            {
                e.Handled = true;
                bool isSelected = dgvAccounts.Rows[e.RowIndex].Selected;
                // Paint background respecting selection style
                if (isSelected)
                    e.Graphics.FillRectangle(new SolidBrush(dgvAccounts.DefaultCellStyle.SelectionBackColor), e.CellBounds);
                else
                    e.PaintBackground(e.CellBounds, true);

                string editText = "Sửa";
                string deleteText = "Xóa";
                string sep = "  |  ";
                // Colors adjusted when selected to ensure contrast
                Color editColor = isSelected ? Color.White : Color.FromArgb(35, 110, 235);
                Color deleteColor = isSelected ? Color.White : Color.FromArgb(220, 65, 50);
                Color sepColor = isSelected ? Color.Gainsboro : Color.Gray;
                Font linkFont = new Font("Segoe UI", 9F, isSelected ? FontStyle.Bold : FontStyle.Underline);
                Font sepFont = new Font("Segoe UI", 9F, isSelected ? FontStyle.Bold : FontStyle.Regular);

                var g = e.Graphics;
                SizeF editSize = g.MeasureString(editText, linkFont);
                SizeF sepSize = g.MeasureString(sep, sepFont);
                SizeF delSize = g.MeasureString(deleteText, linkFont);
                int totalWidth = (int)(editSize.Width + sepSize.Width + delSize.Width);
                int startX = e.CellBounds.X + (e.CellBounds.Width - totalWidth) / 2;
                int centerY = e.CellBounds.Y + (e.CellBounds.Height - (int)editSize.Height) / 2;

                using (var editBrush = new SolidBrush(editColor))
                using (var deleteBrush = new SolidBrush(deleteColor))
                using (var sepBrush = new SolidBrush(sepColor))
                {
                    g.DrawString(editText, linkFont, editBrush, new PointF(startX, centerY));
                    g.DrawString(sep, sepFont, sepBrush, new PointF(startX + editSize.Width, centerY));
                    g.DrawString(deleteText, linkFont, deleteBrush, new PointF(startX + editSize.Width + sepSize.Width, centerY));
                }

                var editRect = new Rectangle(startX, centerY, (int)editSize.Width, (int)editSize.Height);
                var delRect = new Rectangle(startX + (int)(editSize.Width + sepSize.Width), centerY, (int)delSize.Width, (int)delSize.Height);
                dgvAccounts.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag = new ActionCellRegions { Edit = editRect, Delete = delRect };
            }
        }

        private void dgvAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvAccounts.Columns[e.ColumnIndex].Name == "colActions")
            {
                var regions = dgvAccounts.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag as ActionCellRegions;
                if (regions == null) return;
                var mouse = dgvAccounts.PointToClient(Cursor.Position);
                if (regions.Edit.Contains(mouse))
                {
                    var row = _rows[e.RowIndex];
                    using (var f = new AccountEditDialog(_accountService, new AccountDto { Username = row.UserName, DisplayName = row.FullName, Status = row.Status, Role = ParseRole(row.Role) }))
                        if (f.ShowDialog() == DialogResult.OK) LoadData();
                }
                else if (regions.Delete.Contains(mouse))
                {
                    var row = _rows[e.RowIndex];
                    if (MessageBox.Show("Xóa tài khoản?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    { _accountService.Delete(row.UserName); LoadData(); }
                }
            }
        }

        private RoleType ParseRole(string roleText)
        { if (roleText == "Quản trị") return RoleType.Admin; if (roleText == "Thu ngân") return RoleType.Cashier; if (roleText == "Thủ kho") return RoleType.InventoryManager; return RoleType.Cashier; }

        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplyFilter();

        private void ApplyFilter()
        {
            if (_allRows == null) return;
            var term = (txtSearch.Text ?? string.Empty).Trim().ToLowerInvariant();
            var view = string.IsNullOrEmpty(term)
                ? _allRows
                : _allRows.Where(r => (r.UserName ?? "").ToLowerInvariant().Contains(term)
                                   || (r.FullName ?? "").ToLowerInvariant().Contains(term)
                                   || (r.Role ?? "").ToLowerInvariant().Contains(term)
                                   || (r.Status ?? "").ToLowerInvariant().Contains(term)).ToList();
            _rows = new BindingList<AccountRow>(view);
            dgvAccounts.DataSource = _rows;
        }

        private void lblSearch_Click(object sender, EventArgs e)
        {

        }
    }

    internal class AccountRow
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
    }

    internal class ActionCellRegions
    {
        public Rectangle Edit { get; set; }
        public Rectangle Delete { get; set; }
    }
}
