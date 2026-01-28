using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QLCafe.Domain.DTOs;
using QLCafe.Application.Services;
using QLCafe.Infrastructure.Repositories;
using System.IO;

namespace QLCafe.Presentation.Views.Inventory
{
    public partial class InventoryViewForm : Form
    {
        private readonly InventoryService _inventoryService;
        private List<InventoryDto> _allInventory;

        // Cấu hình viền
        private readonly Color _borderColor = Color.FromArgb(120, 53, 15);
        private const int _borderThickness = 2;

        public InventoryViewForm()
        {
            InitializeComponent();

            // 1. Padding để tạo khoảng cách cho viền
            this.Padding = new Padding(20, 0, 20, 20);
            this.ResizeRedraw = true;
            this.Paint += InventoryViewForm_Paint;

            // 2. Khởi tạo
            InitializeManualColumns();
            LoadStateComboBox();

            // 3. Kết nối
            string connectionString = ConfigurationManager.ConnectionStrings["QLCafeConnection"].ConnectionString;
            var inventoryRepo = new InventoryRepository(connectionString);
            _inventoryService = new InventoryService(inventoryRepo);

            LoadData();
        }

        // Vẽ viền nâu bao quanh
        private void InventoryViewForm_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = dgvInventory.Bounds;
            rect.Inflate(1, 1);
            using (Pen pen = new Pen(_borderColor, _borderThickness))
            {
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        // =================================================================================
        // CẤU HÌNH BẢNG (FIX LỖI ADDCOL TẠI ĐÂY)
        // =================================================================================
        private void InitializeManualColumns()
        {
            dgvInventory.AutoGenerateColumns = false;
            dgvInventory.Columns.Clear();

            // Setup chung
            dgvInventory.Dock = DockStyle.Fill;
            dgvInventory.BackgroundColor = Color.White;
            dgvInventory.BorderStyle = BorderStyle.None;
            dgvInventory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvInventory.RowHeadersVisible = false;

            dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventory.MultiSelect = false;
            dgvInventory.AllowUserToAddRows = false;
            dgvInventory.AllowUserToDeleteRows = false;
            dgvInventory.ReadOnly = true;
            dgvInventory.SelectionChanged += (s, e) => dgvInventory.ClearSelection();

            // Header đẹp
            dgvInventory.EnableHeadersVisualStyles = false;
            dgvInventory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvInventory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(120, 53, 15);
            dgvInventory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvInventory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold); // Header to rõ
            dgvInventory.ColumnHeadersHeight = 50;

            // Rows
            dgvInventory.RowTemplate.Height = 45; // Dòng cao thoáng
            dgvInventory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgvInventory.DefaultCellStyle.BackColor = Color.White;
            dgvInventory.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dgvInventory.DefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Regular); // Font chữ nội dung 11pt

            // Ẩn màu chọn
            dgvInventory.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvInventory.DefaultCellStyle.SelectionForeColor = Color.FromArgb(64, 64, 64);

            // --- ĐỊNH NGHĨA CỘT ---

            // Cột 1: Tên Nguyên Liệu -> IN ĐẬM (isBold: true)
            AddCol("TenNguyenLieu", "Tên Nguyên Liệu", 220, DataGridViewContentAlignment.MiddleLeft, "", true);

            // Các cột khác -> Chữ thường (Mặc định)
            AddCol("TenDVT", "ĐVT", 80, DataGridViewContentAlignment.MiddleCenter);
            AddCol("SoLuongTon", "Tồn Kho", 100, DataGridViewContentAlignment.MiddleCenter, "N2");
            AddCol("TonKhoToiThieu", "Tối Thiểu", 100, DataGridViewContentAlignment.MiddleCenter, "N0");
            AddCol("TrangThaiText", "Trạng Thái", 140, DataGridViewContentAlignment.MiddleCenter);

            // Cột HealthBar
            var imgCol = new DataGridViewImageColumn();
            imgCol.Name = "HealthBar";
            imgCol.HeaderText = "Mức độ tồn kho";
            imgCol.FillWeight = 160;
            imgCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInventory.Columns.Add(imgCol);

            dgvInventory.CellPainting -= DgvInventory_CellPainting_New;
            dgvInventory.CellPainting += DgvInventory_CellPainting_New;
        }

        // --- ĐÂY LÀ HÀM ADDCOL DUY NHẤT (ĐÃ FIX LỖI AMBIGUOUS) ---
        private void AddCol(string dataProperty, string header, int width, DataGridViewContentAlignment align, string format = "", bool isBold = false)
        {
            var col = new DataGridViewTextBoxColumn();
            col.DataPropertyName = dataProperty;
            col.Name = dataProperty;
            col.HeaderText = header;
            col.FillWeight = width;
            col.DefaultCellStyle.Alignment = align;
            col.HeaderCell.Style.Alignment = align;

            if (!string.IsNullOrEmpty(format))
                col.DefaultCellStyle.Format = format;

            // Xử lý in đậm nếu được yêu cầu
            if (isBold)
            {
                col.DefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            }

            dgvInventory.Columns.Add(col);
        }

        // =================================================================================
        // CÁC HÀM XỬ LÝ KHÁC (GIỮ NGUYÊN)
        // =================================================================================
        private void DgvInventory_CellPainting_New(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0 || dgvInventory.Columns[e.ColumnIndex].Name != "HealthBar") return;

                e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);

                if (e.RowIndex >= dgvInventory.Rows.Count) return;
                var row = dgvInventory.Rows[e.RowIndex];
                if (row.DataBoundItem == null) return;

                var rowData = row.DataBoundItem as InventoryDto;
                if (rowData == null) return;

                double percent = rowData.PhanTramTon;
                if (percent < 0) percent = 0; if (percent > 100) percent = 100;

                Color barColor = Color.FromArgb(46, 204, 113);
                if (rowData.TrangThaiColor == 1) barColor = Color.FromArgb(231, 76, 60);
                else if (rowData.TrangThaiColor == 2) barColor = Color.FromArgb(241, 196, 15);

                Rectangle rect = e.CellBounds;
                rect.Inflate(-10, -8);
                using (Pen pen = new Pen(Color.Silver)) e.Graphics.DrawRectangle(pen, rect);

                if (percent > 0)
                {
                    using (SolidBrush brush = new SolidBrush(barColor))
                        e.Graphics.FillRectangle(brush, new Rectangle(rect.X + 1, rect.Y + 1, (int)((rect.Width - 2) * (percent / 100)), rect.Height - 2));
                }
                else
                {
                    Font font = e.CellStyle?.Font ?? this.Font;
                    TextRenderer.DrawText(e.Graphics, "Hết hàng", font, rect, Color.Red, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
                e.Handled = true;
            }
            catch { }
        }

        private void LoadData()
        {
            try
            {
                var result = _inventoryService.GetDashboardData();
                var dashboard = result.Item1;
                _allInventory = result.Item2;

                if (dashboard != null)
                {
                    UpdateLabel("lblTotal", dashboard.TongNguyenLieu.ToString());
                    UpdateLabel("lblStable", dashboard.OnDinh.ToString());
                    UpdateLabel("lblCritical", dashboard.CanNhapGap.ToString());
                    UpdateLabel("lblWarning", dashboard.SapHet.ToString());
                }

                DisplayInventory(_allInventory);
                LoadUnitComboBox();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void DisplayInventory(List<InventoryDto> data)
        {
            if (data == null) return;
            dgvInventory.AutoGenerateColumns = false;
            var bindingList = new System.ComponentModel.BindingList<InventoryDto>(data);
            dgvInventory.DataSource = new BindingSource(bindingList, null);
            dgvInventory.ClearSelection();
        }

        private void LoadUnitComboBox()
        {
            if (cboUnit == null || _allInventory == null) return;
            cboUnit.DrawMode = DrawMode.Normal;
            cboUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUnit.BackColor = Color.White;
            cboUnit.ForeColor = Color.Black;

            var units = _allInventory.Select(x => x.TenDVT).Where(x => !string.IsNullOrEmpty(x)).Distinct().ToArray();
            cboUnit.DataSource = null;
            cboUnit.Items.Clear();
            cboUnit.Items.Add("Tất cả");
            cboUnit.Items.AddRange(units);
            cboUnit.SelectedIndex = 0;
        }

        private void LoadStateComboBox()
        {
            if (cboState == null) return;
            cboState.DrawMode = DrawMode.Normal;
            cboState.Items.Clear();
            cboState.Items.Add("Tất cả");
            cboState.Items.Add("Cần nhập gấp");
            cboState.Items.Add("Sắp hết");
            cboState.Items.Add("Ổn định");
            cboState.SelectedIndex = 0;
        }

        private void btnFilter_Click_1(object sender, EventArgs e)
        {
            if (_allInventory == null) return;
            string state = cboState.SelectedItem?.ToString() ?? "Tất cả";
            string unit = cboUnit.SelectedItem?.ToString() ?? "Tất cả";

            var filtered = _allInventory.Where(x =>
                (state == "Tất cả" || x.TrangThaiText == state) &&
                (unit == "Tất cả" || x.TenDVT == unit)
            ).ToList();
            DisplayInventory(filtered);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvInventory.Rows.Count == 0) return;
            try
            {
                SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV File (*.csv)|*.csv", FileName = "TonKho_" + DateTime.Now.ToString("ddMMyy") + ".csv" };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                    {
                        string header = string.Join(",", dgvInventory.Columns.Cast<DataGridViewColumn>().Where(c => c.Name != "HealthBar").Select(c => c.HeaderText));
                        sw.WriteLine(header);
                        foreach (DataGridViewRow row in dgvInventory.Rows)
                        {
                            if (row.IsNewRow) continue;
                            string line = "";
                            foreach (DataGridViewColumn col in dgvInventory.Columns)
                            {
                                if (col.Name != "HealthBar")
                                {
                                    string val = row.Cells[col.Name].Value?.ToString() ?? "";
                                    if (val.Contains(",")) val = "\"" + val + "\"";
                                    line += val + ",";
                                }
                            }
                            sw.WriteLine(line.TrimEnd(','));
                        }
                    }
                    MessageBox.Show("Xuất file thành công!");
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = sfd.FileName, UseShellExecute = true });
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void UpdateLabel(string name, string value)
        {
            var c = Controls.Find(name, true);
            if (c.Length > 0) c[0].Text = value;
        }

        private void dgvInventory_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void cboUnit_SelectedIndexChanged(object sender, EventArgs e) { }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // 1. Kiểm tra nếu chưa có dữ liệu thì thôi
            if (_allInventory == null || _allInventory.Count == 0) return;

            try
            {
                // 2. Lấy từ khóa người dùng nhập, xóa khoảng trắng thừa, chuyển về chữ thường
                string keyword = txtSearch.Text.Trim().ToLower();

                // 3. Nếu ô tìm kiếm trống -> Hiện lại danh sách gốc đầy đủ
                if (string.IsNullOrEmpty(keyword))
                {
                    DisplayInventory(_allInventory);
                    return;
                }

                // 4. Lọc dữ liệu (Tìm trên tất cả các trường hiển thị)
                var searchResult = _allInventory.Where(x =>
                    // Cột 1: Tìm theo Tên (Kiểm tra khác null trước để tránh lỗi)
                    (x.TenNguyenLieu != null && x.TenNguyenLieu.ToLower().Contains(keyword)) ||

                    // Cột 2: Tìm theo ĐVT
                    (x.TenDVT != null && x.TenDVT.ToLower().Contains(keyword)) ||

                    // Cột 3: Tìm theo Tồn kho (Chuyển số sang chuỗi để so sánh)
                    x.SoLuongTon.ToString().Contains(keyword) ||

                    // Cột 4: Tìm theo Tối thiểu
                    x.TonKhoToiThieu.ToString().Contains(keyword) ||

                    // Cột 5: Tìm theo Trạng thái (Chữ "Cần nhập gấp", "Hết hàng"...)
                    (x.TrangThaiText != null && x.TrangThaiText.ToLower().Contains(keyword))

                // Cột 6 là hình ảnh (HealthBar) nên ta tìm theo TrangThaiText là đủ ý nghĩa rồi
                ).ToList();

                // 5. Hiển thị kết quả tìm được ra bảng
                DisplayInventory(searchResult);
            }
            catch (Exception)
            {
                // Nếu có lỗi gì trong lúc gõ thì lờ đi, không crash phần mềm
            }
        }
    }
}