using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ThuCung
{
    public partial class FormChiTietHoaDon : Form
    {
        private static readonly string XmlPath =
            Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\data\ThuCung.xml"));

        private int idHoaDon;
        private XDocument doc;
        private DataTable dtChiTiet = new DataTable();

        public FormChiTietHoaDon(int maHoaDon)
        {
            InitializeComponent();
            this.idHoaDon = maHoaDon;
            KhoiTaoDataTable();
        }

        private void KhoiTaoDataTable()
        {
            dtChiTiet.Columns.Add("STT", typeof(int));
            dtChiTiet.Columns.Add("Mã thú cưng", typeof(int));
            dtChiTiet.Columns.Add("Tên thú cưng", typeof(string));
            dtChiTiet.Columns.Add("Giống", typeof(string));
            dtChiTiet.Columns.Add("Số lượng", typeof(int));
            dtChiTiet.Columns.Add("Đơn giá", typeof(decimal));
            dtChiTiet.Columns.Add("Thành tiền", typeof(decimal));
        }

        private void FormChiTietHoaDon_Load(object sender, EventArgs e)
        {
            LoadThongTinHoaDon();
            LoadChiTietHoaDon();
        }

        private void LoadThongTinHoaDon()
        {
            try
            {
                if (!File.Exists(XmlPath))
                {
                    MessageBox.Show("Không tìm thấy file XML!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                doc = XDocument.Load(XmlPath);

                var hoaDon = doc.Root.Elements("HoaDon")
                    .FirstOrDefault(x => (int)x.Element("idHoaDon") == idHoaDon);

                if (hoaDon == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                int idNguoiDung = (int)hoaDon.Element("idNguoiDung");
                DateTime ngayLap = (DateTime)hoaDon.Element("ngayLap");
                decimal tongTien = (decimal)hoaDon.Element("tongTien");
                string ghiChu = hoaDon.Element("ghiChu")?.Value ?? "";

                var nguoiDung = doc.Root.Elements("NguoiDung")
                    .FirstOrDefault(x => (int)x.Element("idNguoiDung") == idNguoiDung);

                string tenKhachHang = nguoiDung?.Element("hoTen")?.Value ?? "Không rõ";
                string sdt = nguoiDung?.Element("sdt")?.Value ?? "";
                string email = nguoiDung?.Element("email")?.Value ?? "";

                lblMaHoaDon.Text = idHoaDon.ToString();
                lblNgayLap.Text = ngayLap.ToString("dd/MM/yyyy HH:mm");
                lblTenKhachHang.Text = tenKhachHang;
                lblSDT.Text = sdt;
                lblEmail.Text = email;
                lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
                lblGhiChu.Text = ghiChu;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc thông tin hóa đơn:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadChiTietHoaDon()
        {
            try
            {
                dtChiTiet.Clear();

                var chiTiets = doc.Root.Elements("ChiTietHoaDon")
                    .Where(x => (int)x.Element("idHoaDon") == idHoaDon)
                    .ToList();

                int stt = 1;
                foreach (var ct in chiTiets)
                {
                    int idThuCung = (int)ct.Element("idThuCung");
                    int soLuong = (int)ct.Element("soLuong");
                    decimal donGia = (decimal)ct.Element("donGia");
                    decimal thanhTien = (decimal)ct.Element("thanhTien");

                    var thuCung = doc.Root.Elements("ThuCung")
                        .FirstOrDefault(x => (int)x.Element("idThuCung") == idThuCung);

                    string tenThuCung = thuCung?.Element("tenThuCung")?.Value ?? "Không rõ";
                    string giong = thuCung?.Element("giongThuCung")?.Value ?? "";

                    dtChiTiet.Rows.Add(stt++, idThuCung, tenThuCung, giong, soLuong, donGia, thanhTien);
                }

                dgChiTiet.DataSource = dtChiTiet;

                dgChiTiet.Columns["STT"].Width = 50;
                dgChiTiet.Columns["Mã thú cưng"].Width = 80;
                dgChiTiet.Columns["Tên thú cưng"].Width = 150;
                dgChiTiet.Columns["Giống"].Width = 150;
                dgChiTiet.Columns["Số lượng"].Width = 80;
                dgChiTiet.Columns["Đơn giá"].Width = 120;
                dgChiTiet.Columns["Thành tiền"].Width = 120;

                dgChiTiet.Columns["Đơn giá"].DefaultCellStyle.Format = "N0";
                dgChiTiet.Columns["Thành tiền"].DefaultCellStyle.Format = "N0";
                dgChiTiet.Columns["Đơn giá"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgChiTiet.Columns["Thành tiền"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc chi tiết hóa đơn:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
