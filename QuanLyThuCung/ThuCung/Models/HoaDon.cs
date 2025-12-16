using System;

namespace ThuCung.Models
{
    public class HoaDon
    {
        public int IdHoaDon { get; set; }
        public int IdNguoiDung { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }
        public string GhiChu { get; set; }
    }
}
