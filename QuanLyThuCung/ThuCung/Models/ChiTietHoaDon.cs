using System;

namespace ThuCung.Models
{
    public class ChiTietHoaDon
    {
        public int IdChiTiet { get; set; }
        public int IdHoaDon { get; set; }
        public int? IdThuCung { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
    }
}
