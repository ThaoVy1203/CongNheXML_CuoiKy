using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ThuCung
{
    public partial class XemHoaDon : UserControl
    {
        private static readonly string XmlPath =
            Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\data\ThuCung.xml"));

        private XDocument doc;
        private DataTable dtHoaDon = new DataTable();
        private DataTable dtHoaDonGoc = new DataTable(); // Lưu dữ liệu gốc

        public XemHoaDon()
        {
            InitializeComponent();
            KhoiTaoDataTable();
        }

        private void KhoiTaoDataTable()
        {
            dtHoaDon.Columns.Add("Mã hoá đơn", typeof(int));
            dtHoaDon.Columns.Add("Mã khách hàng", typeof(int));
            dtHoaDon.Columns.Add("Tên khách hàng", typeof(string));
            dtHoaDon.Columns.Add("Ngày lập", typeof(DateTime));
            dtHoaDon.Columns.Add("Tổng tiền", typeof(decimal));
            dtHoaDon.Columns.Add("Ghi chú", typeof(string));

            dtHoaDonGoc.Columns.Add("Mã hoá đơn", typeof(int));
            dtHoaDonGoc.Columns.Add("Mã khách hàng", typeof(int));
            dtHoaDonGoc.Columns.Add("Tên khách hàng", typeof(string));
            dtHoaDonGoc.Columns.Add("Ngày lập", typeof(DateTime));
            dtHoaDonGoc.Columns.Add("Tổng tiền", typeof(decimal));
            dtHoaDonGoc.Columns.Add("Ghi chú", typeof(string));
        }

        private void XemHoaDon_Load(object sender, EventArgs e)
        {
            LoadDuLieuHoaDon();
            KhoiTaoComboThang();

            // Gắn sự kiện
            btnLamMoi.Click += btnLamMoi_Click;
            btnXoa.Click += btnXoa_Click;
            btnXemChiTiet.Click += btnXemChiTiet_Click;
            btnLoc.Click += btnLoc_Click;
            btnXuatHTML.Click += btnXuatHTML_Click;
            dgHoaDon.SelectionChanged += dgHoaDon_SelectionChanged;

            dgHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgHoaDon.MultiSelect = false;
        }

        private void KhoiTaoComboThang()
        {
            cboThang.Items.Add("Tất cả");
            for (int i = 1; i <= 12; i++)
            {
                cboThang.Items.Add($"Tháng {i}");
            }
            cboThang.SelectedIndex = 0;

            // Khởi tạo combo giá tiền
            KhoiTaoComboGia();
        }

        private void KhoiTaoComboGia()
        {
            string[] khoangGia = new string[]
            {
                "Tất cả",
                "0",
                "1,000,000",
                "2,000,000",
                "3,000,000",
                "5,000,000",
                "7,000,000",
                "10,000,000",
                "15,000,000",
                "20,000,000"
            };

            cboGiaTu.Items.AddRange(khoangGia);
            cboGiaDen.Items.AddRange(khoangGia);

            cboGiaTu.SelectedIndex = 0;
            cboGiaDen.SelectedIndex = 0;
        }

        private void LoadDuLieuHoaDon()
        {
            try
            {
                if (!File.Exists(XmlPath))
                {
                    MessageBox.Show("Không tìm thấy file XML!\n" + XmlPath, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                doc = XDocument.Load(XmlPath);
                dtHoaDon.Clear();
                dtHoaDonGoc.Clear();

                // ĐÚNG: Lấy tất cả thẻ <HoaDon> trực tiếp trong root
                var hoaDons = doc.Root.Elements("HoaDon");

                foreach (var hd in hoaDons)
                {
                    int idHoaDon = (int)hd.Element("idHoaDon");
                    int idNguoiDung = (int)hd.Element("idNguoiDung");
                    DateTime ngayLap = (DateTime)hd.Element("ngayLap");
                    decimal tongTien = (decimal)hd.Element("tongTien");
                    string ghiChu = hd.Element("ghiChu")?.Value ?? "";

                    // Tìm tên khách hàng
                    var nguoiDung = doc.Root.Elements("NguoiDung")
                        .FirstOrDefault(x => (int?)x.Element("idNguoiDung") == idNguoiDung);

                    string tenKhachHang = nguoiDung?.Element("hoTen")?.Value ?? "Không rõ";

                    dtHoaDon.Rows.Add(idHoaDon, idNguoiDung, tenKhachHang, ngayLap, tongTien, ghiChu);
                    dtHoaDonGoc.Rows.Add(idHoaDon, idNguoiDung, tenKhachHang, ngayLap, tongTien, ghiChu);
                }

                dgHoaDon.DataSource = dtHoaDon;

                // Đặt tiêu đề cột đẹp
                dgHoaDon.Columns["Mã hoá đơn"].HeaderText = "Mã hóa đơn";
                dgHoaDon.Columns["Mã khách hàng"].HeaderText = "Mã KH";
                dgHoaDon.Columns["Tên khách hàng"].HeaderText = "Khách hàng";
                dgHoaDon.Columns["Ngày lập"].HeaderText = "Ngày lập";
                dgHoaDon.Columns["Tổng tiền"].HeaderText = "Tổng tiền";
                dgHoaDon.Columns["Ghi chú"].HeaderText = "Ghi chú";

                // Format đẹp
                dgHoaDon.Columns["Tổng tiền"].DefaultCellStyle.Format = "N0";
                dgHoaDon.Columns["Ngày lập"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc file XML:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDuLieuHoaDon();
            ClearChiTiet();
        }

        private void dgHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgHoaDon.CurrentRow != null && !dgHoaDon.CurrentRow.IsNewRow)
            {
                var row = dgHoaDon.CurrentRow;
                tbMaHoaDon.Text = row.Cells["Mã hoá đơn"].Value.ToString();
                tbMaKhachHang.Text = row.Cells["Mã khách hàng"].Value.ToString();
                tbTenKhachHang.Text = row.Cells["Tên khách hàng"].Value.ToString();
                tbNgayLap.Text = ((DateTime)row.Cells["Ngày lập"].Value).ToString("dd/MM/yyyy HH:mm");
                tbTongTien.Text = ((decimal)row.Cells["Tổng tiền"].Value).ToString("N0");
                tbGhiChu.Text = row.Cells["Ghi chú"].Value?.ToString() ?? "";
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgHoaDon.CurrentRow == null || dgHoaDon.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maHD = Convert.ToInt32(dgHoaDon.CurrentRow.Cells["Mã hoá đơn"].Value);

            if (MessageBox.Show($"Xóa hóa đơn mã {maHD} và tất cả chi tiết của nó?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // XÓA CHI TIẾT HÓA ĐƠN TRƯỚC
                    var chiTietXoa = doc.Root.Elements("ChiTietHoaDon")
                        .Where(x => (int)x.Element("idHoaDon") == maHD)
                        .ToList();
                    chiTietXoa.ForEach(ct => ct.Remove());

                    // XÓA HÓA ĐƠN
                    var hoaDonXoa = doc.Root.Elements("HoaDon")
                        .FirstOrDefault(x => (int)x.Element("idHoaDon") == maHD);
                    hoaDonXoa?.Remove();

                    // LƯU LẠI FILE XML
                    doc.Save(XmlPath);

                    MessageBox.Show("Xóa hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDuLieuHoaDon();
                    ClearChiTiet();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
        }

        private void ClearChiTiet()
        {
            tbMaHoaDon.Clear();
            tbMaKhachHang.Clear();
            tbTenKhachHang.Clear();
            tbNgayLap.Clear();
            tbTongTien.Clear();
            tbGhiChu.Clear();
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbMaHoaDon.Text))
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xem chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int maHD = int.Parse(tbMaHoaDon.Text);
            FormChiTietHoaDon formChiTiet = new FormChiTietHoaDon(maHD);
            formChiTiet.ShowDialog();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                dtHoaDon.Clear();

                // Lấy giá trị lọc
                decimal? giaTu = null;
                decimal? giaDen = null;
                int? thang = null;

                if (cboGiaTu.SelectedIndex > 0)
                {
                    string giaText = cboGiaTu.SelectedItem.ToString().Replace(",", "");
                    giaTu = decimal.Parse(giaText);
                }

                if (cboGiaDen.SelectedIndex > 0)
                {
                    string giaText = cboGiaDen.SelectedItem.ToString().Replace(",", "");
                    giaDen = decimal.Parse(giaText);
                }

                if (cboThang.SelectedIndex > 0)
                {
                    thang = cboThang.SelectedIndex;
                }

                // Lọc dữ liệu
                foreach (DataRow row in dtHoaDonGoc.Rows)
                {
                    decimal tongTien = (decimal)row["Tổng tiền"];
                    DateTime ngayLap = (DateTime)row["Ngày lập"];

                    bool theoGia = true;
                    bool theoThang = true;

                    // Kiểm tra điều kiện giá
                    if (giaTu.HasValue && tongTien < giaTu.Value)
                        theoGia = false;

                    if (giaDen.HasValue && tongTien > giaDen.Value)
                        theoGia = false;

                    // Kiểm tra điều kiện tháng
                    if (thang.HasValue && ngayLap.Month != thang.Value)
                        theoThang = false;

                    // Thêm vào kết quả nếu thỏa mãn
                    if (theoGia && theoThang)
                    {
                        dtHoaDon.Rows.Add(
                            row["Mã hoá đơn"],
                            row["Mã khách hàng"],
                            row["Tên khách hàng"],
                            row["Ngày lập"],
                            row["Tổng tiền"],
                            row["Ghi chú"]
                        );
                    }
                }

                dgHoaDon.DataSource = dtHoaDon;
                MessageBox.Show($"Đã lọc được {dtHoaDon.Rows.Count} hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatHTML_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtHoaDon.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "HTML files (*.html)|*.html";
                saveDialog.FileName = $"DanhSachHoaDon_{DateTime.Now:yyyyMMdd_HHmmss}.html";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string html = TaoNoiDungHTML();
                    File.WriteAllText(saveDialog.FileName, html, System.Text.Encoding.UTF8);
                    MessageBox.Show("Xuất HTML thành công!\n" + saveDialog.FileName, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở file HTML
                    System.Diagnostics.Process.Start(saveDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất HTML: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string TaoNoiDungHTML()
        {
            var html = new System.Text.StringBuilder();

            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html lang='vi'>");
            html.AppendLine("<head>");
            html.AppendLine("    <meta charset='UTF-8'>");
            html.AppendLine("    <meta name='viewport' content='width=device-width, initial-scale=1.0'>");
            html.AppendLine("    <title>Danh Sách Hóa Đơn</title>");
            html.AppendLine("    <style>");
            html.AppendLine("        @import url('https://fonts.googleapis.com/css2?family=Inter:wght@300;400;500;600;700&display=swap');");
            html.AppendLine("        * { margin: 0; padding: 0; box-sizing: border-box; }");
            html.AppendLine("        body { font-family: 'Inter', 'Segoe UI', sans-serif; background: linear-gradient(135deg, #e3f2fd 0%, #bbdefb 50%, #90caf9 100%); min-height: 100vh; padding: 40px 20px; }");
            html.AppendLine("        .container { max-width: 1400px; margin: 0 auto; background: rgba(255, 255, 255, 0.98); border-radius: 24px; box-shadow: 0 20px 60px rgba(33, 150, 243, 0.15), 0 0 0 1px rgba(33, 150, 243, 0.1); overflow: hidden; backdrop-filter: blur(10px); }");
            html.AppendLine("        .header { background: linear-gradient(135deg, #42a5f5 0%, #2196f3 50%, #1e88e5 100%); color: white; padding: 50px 40px; position: relative; overflow: hidden; }");
            html.AppendLine("        .header::before { content: ''; position: absolute; top: -50%; right: -10%; width: 400px; height: 400px; background: rgba(255, 255, 255, 0.1); border-radius: 50%; }");
            html.AppendLine("        .header::after { content: ''; position: absolute; bottom: -30%; left: -5%; width: 300px; height: 300px; background: rgba(255, 255, 255, 0.08); border-radius: 50%; }");
            html.AppendLine("        .header h1 { font-size: 2.8em; margin-bottom: 12px; font-weight: 700; letter-spacing: -0.5px; position: relative; z-index: 1; }");
            html.AppendLine("        .header p { font-size: 1.15em; opacity: 0.95; font-weight: 300; position: relative; z-index: 1; }");
            html.AppendLine("        .content { padding: 45px 40px; background: white; }");
            html.AppendLine("        .stats { display: flex; justify-content: space-between; gap: 25px; margin-bottom: 45px; flex-wrap: wrap; }");
            html.AppendLine("        .stat-card { background: linear-gradient(135deg, #e3f2fd 0%, #bbdefb 100%); color: #1565c0; padding: 30px 25px; border-radius: 16px; text-align: center; flex: 1; min-width: 220px; box-shadow: 0 4px 20px rgba(33, 150, 243, 0.12); border: 1px solid rgba(33, 150, 243, 0.15); transition: all 0.3s ease; position: relative; overflow: hidden; }");
            html.AppendLine("        .stat-card::before { content: ''; position: absolute; top: 0; left: 0; right: 0; height: 4px; background: linear-gradient(90deg, #42a5f5, #2196f3, #1e88e5); }");
            html.AppendLine("        .stat-card:hover { transform: translateY(-5px); box-shadow: 0 8px 30px rgba(33, 150, 243, 0.2); }");
            html.AppendLine("        .stat-card h3 { font-size: 2.4em; margin-bottom: 8px; font-weight: 700; color: #1565c0; }");
            html.AppendLine("        .stat-card p { opacity: 0.85; font-size: 0.95em; font-weight: 500; color: #1976d2; }");
            html.AppendLine("        .table-wrapper { border-radius: 16px; overflow: hidden; box-shadow: 0 4px 20px rgba(33, 150, 243, 0.1); border: 1px solid rgba(33, 150, 243, 0.1); }");
            html.AppendLine("        table { width: 100%; border-collapse: collapse; background: white; }");
            html.AppendLine("        thead { background: linear-gradient(135deg, #42a5f5 0%, #2196f3 50%, #1e88e5 100%); color: white; }");
            html.AppendLine("        th { padding: 18px 20px; text-align: left; font-weight: 600; font-size: 0.95em; letter-spacing: 0.3px; text-transform: uppercase; }");
            html.AppendLine("        td { padding: 16px 20px; border-bottom: 1px solid #e3f2fd; font-size: 0.95em; color: #424242; }");
            html.AppendLine("        tbody tr { transition: all 0.2s ease; }");
            html.AppendLine("        tbody tr:hover { background: linear-gradient(90deg, #e3f2fd 0%, #f5fbff 100%); transform: scale(1.001); }");
            html.AppendLine("        tbody tr:nth-child(even) { background-color: #fafbfc; }");
            html.AppendLine("        tbody tr:nth-child(even):hover { background: linear-gradient(90deg, #e3f2fd 0%, #f5fbff 100%); }");
            html.AppendLine("        tbody tr:last-child td { border-bottom: none; }");
            html.AppendLine("        .price { color: #1565c0; font-weight: 700; font-size: 1.05em; }");
            html.AppendLine("        .footer { text-align: center; padding: 30px; color: #78909c; border-top: 1px solid #e3f2fd; margin-top: 40px; background: linear-gradient(180deg, #fafbfc 0%, white 100%); font-size: 0.9em; }");
            html.AppendLine("        @media (max-width: 768px) { .stats { flex-direction: column; } .stat-card { min-width: 100%; } table { font-size: 0.85em; } th, td { padding: 12px 10px; } }");
            html.AppendLine("    </style>");
            html.AppendLine("</head>");
            html.AppendLine("<body>");
            html.AppendLine("    <div class='container'>");
            html.AppendLine("        <div class='header'>");
            html.AppendLine("            <h1>🐾 DANH SÁCH HÓA ĐƠN</h1>");
            html.AppendLine($"            <p>Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}</p>");
            html.AppendLine("        </div>");
            html.AppendLine("        <div class='content'>");

            // Thống kê
            decimal tongDoanhThu = 0;
            foreach (DataRow row in dtHoaDon.Rows)
            {
                tongDoanhThu += (decimal)row["Tổng tiền"];
            }

            html.AppendLine("            <div class='stats'>");
            html.AppendLine("                <div class='stat-card'>");
            html.AppendLine($"                    <h3>{dtHoaDon.Rows.Count}</h3>");
            html.AppendLine("                    <p>Tổng hóa đơn</p>");
            html.AppendLine("                </div>");
            html.AppendLine("                <div class='stat-card'>");
            html.AppendLine($"                    <h3>{tongDoanhThu:N0} VNĐ</h3>");
            html.AppendLine("                    <p>Tổng doanh thu</p>");
            html.AppendLine("                </div>");
            html.AppendLine("                <div class='stat-card'>");
            html.AppendLine($"                    <h3>{(dtHoaDon.Rows.Count > 0 ? tongDoanhThu / dtHoaDon.Rows.Count : 0):N0} VNĐ</h3>");
            html.AppendLine("                    <p>Trung bình/hóa đơn</p>");
            html.AppendLine("                </div>");
            html.AppendLine("            </div>");

            // Bảng dữ liệu
            html.AppendLine("            <div class='table-wrapper'>");
            html.AppendLine("                <table>");
            html.AppendLine("                    <thead>");
            html.AppendLine("                        <tr>");
            html.AppendLine("                            <th>Mã HĐ</th>");
            html.AppendLine("                            <th>Khách hàng</th>");
            html.AppendLine("                            <th>Ngày lập</th>");
            html.AppendLine("                            <th>Tổng tiền</th>");
            html.AppendLine("                            <th>Ghi chú</th>");
            html.AppendLine("                        </tr>");
            html.AppendLine("                    </thead>");
            html.AppendLine("                    <tbody>");

            foreach (DataRow row in dtHoaDon.Rows)
            {
                html.AppendLine("                        <tr>");
                html.AppendLine($"                        <td>{row["Mã hoá đơn"]}</td>");
                html.AppendLine($"                        <td>{row["Tên khách hàng"]}</td>");
                html.AppendLine($"                        <td>{((DateTime)row["Ngày lập"]):dd/MM/yyyy HH:mm}</td>");
                html.AppendLine($"                        <td class='price'>{((decimal)row["Tổng tiền"]):N0} VNĐ</td>");
                html.AppendLine($"                        <td>{row["Ghi chú"]}</td>");
                html.AppendLine("                        </tr>");
            }

            html.AppendLine("                    </tbody>");
            html.AppendLine("                </table>");
            html.AppendLine("            </div>");
            html.AppendLine("        </div>");
            html.AppendLine("        <div class='footer'>");
            html.AppendLine("            <p>© 2024 Pet Shop Management System</p>");
            html.AppendLine("        </div>");
            html.AppendLine("    </div>");
            html.AppendLine("</body>");
            html.AppendLine("</html>");

            return html.ToString();
        }
    }
}