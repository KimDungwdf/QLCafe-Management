namespace QLCafe.Domain.DTOs
{
    public class InventoryDto
    {
        public string TenNguyenLieu { get; set; }
        public string TenDVT { get; set; }
        public decimal SoLuongTon { get; set; }
        public decimal TonKhoToiThieu { get; set; }
        public string TrangThaiText { get; set; }
        public int TrangThaiColor { get; set; }
        public double PhanTramTon { get; set; }
    }
}