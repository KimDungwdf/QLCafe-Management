using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCafe.Presentation.Views.Admin
{
    public partial class AccountManagementForm : Form
    {
        private BindingList<AccountRow> _rows;
        public AccountManagementForm()
        {
            InitializeComponent();
        }

        private void AccountManagementForm_Load(object sender, EventArgs e)
        {
            InitGrid();
            LoadSample();
        }

        private void InitGrid()
        {
            dgvAccounts.AutoGenerateColumns = false;
            dgvAccounts.Columns.Clear();

            dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(AccountRow.Id),
                HeaderText = "ID",
                Width = 50
            });
            dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(AccountRow.UserName),
                HeaderText = "Tên đăng nhập",
                Width = 130
            });
            dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(AccountRow.FullName),
                HeaderText = "Họ tên",
                Width = 180
            });
            dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(AccountRow.Role),
                HeaderText = "Vai trò",
                Width = 110
            });
            dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(AccountRow.Phone),
                HeaderText = "SDT",
                Width = 120
            });
            dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(AccountRow.Status),
                HeaderText = "Trạng thái",
                Width = 120
            });
            // Action column placeholder (edit/delete)
            dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Thao tác",
                Width = 120,
                Name = "Actions"
            });

            dgvAccounts.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvAccounts.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvAccounts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dgvAccounts.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.DefaultCellStyle.Font = new Font("Segoe UI", 9F));
        }

        private void LoadSample()
        {
            _rows = new BindingList<AccountRow>(new List<AccountRow>
            {
                new AccountRow{ Id=1, UserName="thungan1", FullName="Nguyễn Văn A", Role="Thu ngân", Phone="0123456789", Status="Hoạt động"},
                new AccountRow{ Id=2, UserName="thungan2", FullName="Trần Thị B", Role="Thu ngân", Phone="0987654321", Status="Hoạt động"},
                new AccountRow{ Id=3, UserName="thukho1", FullName="Lê Văn C", Role="Thủ kho", Phone="0369852147", Status="Hoạt động"},
            });
            dgvAccounts.DataSource = _rows;
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thêm tài khoản - TODO");
        }

        private void dgvAccounts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvAccounts.Columns[e.ColumnIndex].DataPropertyName == nameof(AccountRow.Role) && e.Value != null)
            {
                e.Value = e.Value.ToString();
            }
        }

        private void dgvAccounts_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Badge style for Role & Status
                var col = dgvAccounts.Columns[e.ColumnIndex];
                if (col.DataPropertyName == nameof(AccountRow.Role) || col.DataPropertyName == nameof(AccountRow.Status))
                {
                    e.Handled = true;
                    e.PaintBackground(e.CellBounds, true);
                    string text = Convert.ToString(e.FormattedValue);
                    if (string.IsNullOrEmpty(text)) return;
                    Color back = col.DataPropertyName == nameof(AccountRow.Role) ? Color.FromArgb(225, 235, 255) : Color.FromArgb(219, 247, 227);
                    Color border = col.DataPropertyName == nameof(AccountRow.Role) ? Color.FromArgb(164, 198, 255) : Color.FromArgb(174, 231, 191);
                    Color fore = Color.FromArgb(60, 80, 160);
                    if (col.DataPropertyName == nameof(AccountRow.Status)) fore = Color.FromArgb(34, 120, 72);
                    var rect = new Rectangle(e.CellBounds.X + 8, e.CellBounds.Y + 12, e.CellBounds.Width - 16, e.CellBounds.Height - 24);
                    using (var path = RoundedRect(rect, 12))
                    using (var b = new SolidBrush(back))
                    using (var pen = new Pen(border))
                    using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                    using (var f = new Font("Segoe UI", 8.5F, FontStyle.Regular))
                    {
                        e.Graphics.FillPath(b, path);
                        e.Graphics.DrawPath(pen, path);
                        e.Graphics.DrawString(text, f, new SolidBrush(fore), rect, sf);
                    }
                }
                else if (col.Name == "Actions" && e.ColumnIndex == col.Index)
                {
                    e.Handled = true;
                    e.PaintBackground(e.CellBounds, true);
                    int iconSize = 18;
                    int padding = 6;
                    // Draw simple edit (blue square) and delete (red square)
                    var editRect = new Rectangle(e.CellBounds.X + padding, e.CellBounds.Y + (e.CellBounds.Height - iconSize) / 2, iconSize, iconSize);
                    var delRect = new Rectangle(e.CellBounds.Right - iconSize - padding, editRect.Y, iconSize, iconSize);
                    using (var editBrush = new SolidBrush(Color.FromArgb(35, 110, 235)))
                    using (var delBrush = new SolidBrush(Color.FromArgb(220, 65, 50)))
                    {
                        e.Graphics.FillRectangle(editBrush, editRect);
                        e.Graphics.FillRectangle(delBrush, delRect);
                    }
                }
            }
        }

        private void dgvAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvAccounts.Columns[e.ColumnIndex].Name == "Actions")
            {
                // Determine which icon region was clicked
                var cellRect = dgvAccounts.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                int iconSize = 18;
                int padding = 6;
                var editRect = new Rectangle(cellRect.X + padding, cellRect.Y + (cellRect.Height - iconSize) / 2, iconSize, iconSize);
                var delRect = new Rectangle(cellRect.Right - iconSize - padding, editRect.Y, iconSize, iconSize);
                var mousePos = dgvAccounts.PointToClient(Cursor.Position);
                if (editRect.Contains(mousePos))
                {
                    MessageBox.Show("Sửa tài khoản: " + _rows[e.RowIndex].UserName);
                }
                else if (delRect.Contains(mousePos))
                {
                    var r = MessageBox.Show("Xóa tài khoản?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        _rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }

        private System.Drawing.Drawing2D.GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            int d = radius * 2;
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }

    internal class AccountRow
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
    }
}
