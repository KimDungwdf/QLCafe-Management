using System;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QLCafe.Application.Interfaces;
using QLCafe.Application.Services;
using QLCafe.Infrastructure.Repositories;
using QLCafe.Presentation.Controls.Table;

namespace QLCafe.Presentation.Views.Admin
{
    public partial class OrganizationForm : Form
    {
        private ITableManagementService _service;

        public OrganizationForm()
        {
            InitializeComponent();
            Load += OrganizationForm_Load;
            btnAddTable.Click += BtnAddTable_Click;
            flowLayoutPanel1.SizeChanged += (s, e) => AdjustItemWidths();
        }

        private void OrganizationForm_Load(object sender, EventArgs e)
        {
            var cs = ConfigurationManager.ConnectionStrings["QLCafeConnection"].ConnectionString;
            var repo = new TableManagementRepository(cs);
            var orderRepo = new OrderRepository(cs);
            _service = new TableManagementService(repo, orderRepo);
            InitContainer();
            LoadTables();
        }

        private void InitContainer()
        {
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Padding = new Padding(10);
        }

        private void LoadTables()
        {
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.Controls.Clear();

            var items = _service.GetAll();
            foreach (var t in items)
            {
                var ctl = new TableManagementControl();
                ctl.Margin = new Padding(10);
                ctl.Height = 170;
                ctl.Bind(t);
                if (t.TotalAmount > 0)
                {
                    var label = ctl.Controls.Find("lblTotalAmount", true).FirstOrDefault() as Label;
                    if (label != null)
                    {
                        label.Text = $"Tổng: {t.TotalAmount:N0} đ";
                        label.Visible = true;
                    }
                }
                ctl.EditRequested += Ctl_EditRequested;
                ctl.DeleteRequested += Ctl_DeleteRequested;
                flowLayoutPanel1.Controls.Add(ctl);
            }

            AdjustItemWidths();
            flowLayoutPanel1.ResumeLayout(true);
        }

        private void AdjustItemWidths()
        {
            // Tính toán chiều rộng phù hợp theo số cột, giữ min width
            int panelWidth = flowLayoutPanel1.ClientSize.Width - flowLayoutPanel1.Padding.Horizontal;
            if (panelWidth <= 0) return;

            // Chọn số cột mục tiêu theo kích thước hiện tại
            int minItemWidth = 360; // tối thiểu để layout đẹp
            int columns = Math.Max(1, panelWidth / (minItemWidth + 20)); // 20 = margin 2 bên
            int itemWidth = (panelWidth - (columns * 20)) / columns; // trừ khoảng cách
            if (itemWidth < minItemWidth) itemWidth = minItemWidth;

            foreach (Control c in flowLayoutPanel1.Controls)
            {
                c.Width = itemWidth;
            }
        }

        private void Ctl_EditRequested(object sender, int tableId)
        {
            var ctl = (TableManagementControl)sender;
            var currentName = ctl.TableNameText;
            var newName = PromptInput($"Đổi tên bàn (ID {tableId})", currentName);
            if (newName == null) return;
            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("Tên bàn không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_service.Rename(tableId, newName.Trim()))
            {
                ctl.TableNameText = newName.Trim();
            }
            else
            {
                MessageBox.Show("Không đổi tên được (trùng tên hoặc lỗi hệ thống)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Ctl_DeleteRequested(object sender, int tableId)
        {
            var ctl = (TableManagementControl)sender;
            var confirm = MessageBox.Show($"Xóa bàn '{ctl.TableNameText}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            if (_service.Delete(tableId, out var error))
            {
                flowLayoutPanel1.Controls.Remove(ctl);
                ctl.Dispose();
            }
            else
            {
                MessageBox.Show(error ?? "Không xóa được bàn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddTable_Click(object sender, EventArgs e)
        {
            using (var dlg = new AddTableDialog())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    var name = dlg.TableNameText;
                    var id = _service.Create(name, out var error);
                    if (id > 0)
                    {
                        LoadTables();
                    }
                    else
                    {
                        MessageBox.Show(error ?? "Không thể thêm bàn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private static string PromptInput(string title, string defaultText)
        {
            using (var f = new Form())
            using (var txt = new TextBox())
            using (var ok = new Button())
            using (var cancel = new Button())
            {
                f.Text = title;
                f.FormBorderStyle = FormBorderStyle.FixedDialog;
                f.StartPosition = FormStartPosition.CenterParent;
                f.ClientSize = new System.Drawing.Size(380, 120);
                f.MinimizeBox = false; f.MaximizeBox = false; f.ShowInTaskbar = false;

                txt.Left = 12; txt.Top = 12; txt.Width = 356; txt.Text = defaultText;
                ok.Text = "OK"; ok.Left = 212; ok.Top = 60; ok.Width = 70; ok.DialogResult = DialogResult.OK;
                cancel.Text = "Hủy"; cancel.Left = 298; cancel.Top = 60; cancel.Width = 70; cancel.DialogResult = DialogResult.Cancel;

                f.Controls.AddRange(new Control[] { txt, ok, cancel });
                f.AcceptButton = ok; f.CancelButton = cancel;
                return f.ShowDialog() == DialogResult.OK ? txt.Text : null;
            }
        }
    }
}
