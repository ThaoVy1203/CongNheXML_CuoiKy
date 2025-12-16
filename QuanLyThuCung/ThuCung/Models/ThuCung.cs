using System;

namespace ThuCung.Models
{
    public class ThuCung
    {
        public int IdThuCung { get; set; }
        public string TenThuCung { get; set; }
        public int? Tuoi { get; set; }
        public string GioiTinh { get; set; }
        public string MauSac { get; set; }
        public double? CanNang { get; set; }
        public string GiongThuCung { get; set; }
        public double? TieuChuanCanNang { get; set; }
        public string AnhThuCung { get; set; }
        public decimal GiaBan { get; set; }
        public int IdLoai { get; set; }
    }
}
