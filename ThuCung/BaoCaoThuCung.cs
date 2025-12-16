using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ThuCung
{
    public partial class BaoCaoThuCung: UserControl
    {
        private static readonly string XmlPath =
    Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\data\ThuCung.xml"));
        private DataSet dsPetShop;
        private DataTable speciesData;
        private DataTable genderData;
        private DataTable ageData;
        private DataTable breedData;

        public BaoCaoThuCung()
        {
            InitializeComponent();
            this.Load += BaoCaoThuCung_Load;

            // Thêm event Paint cho các panel
            panelSpeciesChart.Paint += PanelSpeciesChart_Paint;
            panelGenderChart.Paint += PanelGenderChart_Paint;
            panelAgeChart.Paint += PanelAgeChart_Paint;
            panelBreedChart.Paint += PanelBreedChart_Paint;
        }

        private void BaoCaoThuCung_Load(object sender, EventArgs e)
        {
            LoadDataFromXml();
            LoadAllData();
        }

        private void LoadDataFromXml()
        {
            try
            {
                string fullPath = Path.GetFullPath(XmlPath);
                if (!File.Exists(fullPath))
                {
                    MessageBox.Show("Không tìm thấy file dữ liệu XML!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dsPetShop = new DataSet();
                dsPetShop.ReadXml(fullPath);

                // Debug: Kiểm tra các bảng đã load
                System.Diagnostics.Debug.WriteLine("=== TABLES LOADED ===");
                foreach (DataTable table in dsPetShop.Tables)
                {
                    System.Diagnostics.Debug.WriteLine($"Table: {table.TableName} ({table.Rows.Count} rows)");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc file XML:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAllData()
        {
            try
            {
                if (dsPetShop == null)
                {
                    MessageBox.Show("DataSet chưa được load!", "Lỗi");
                    return;
                }

                if (!dsPetShop.Tables.Contains("ThuCung"))
                {
                    MessageBox.Show("Không tìm thấy bảng ThuCung!", "Lỗi");
                    return;
                }

                if (!dsPetShop.Tables.Contains("Loai"))
                {
                    MessageBox.Show("Không tìm thấy bảng Loai!", "Lỗi");
                    return;
                }

                // Load dữ liệu theo loại - FIX: Chuyển đổi string sang int
                var allLoai = dsPetShop.Tables["Loai"].AsEnumerable()
                    .Select(r => new {
                        idLoai = Convert.ToInt32(r["idLoai"]),
                        tenLoai = r["tenLoai"].ToString()
                    });

                var thuCungByLoai = dsPetShop.Tables["ThuCung"].AsEnumerable()
                    .GroupBy(r => Convert.ToInt32(r["idLoai"]))
                    .ToDictionary(g => g.Key, g => g.Count());

                var loaiStats = allLoai.Select(loai => new {
                    tenLoai = loai.tenLoai,
                    SoLuong = thuCungByLoai.ContainsKey(loai.idLoai) ? thuCungByLoai[loai.idLoai] : 0
                }).OrderByDescending(x => x.SoLuong);

                speciesData = new DataTable();
                speciesData.Columns.Add("tenLoai", typeof(string));
                speciesData.Columns.Add("SoLuong", typeof(int));
                foreach (var item in loaiStats)
                {
                    speciesData.Rows.Add(item.tenLoai, item.SoLuong);
                }

                // Load dữ liệu theo giới tính
                var genderStats = dsPetShop.Tables["ThuCung"].AsEnumerable()
                    .GroupBy(r => r["gioiTinh"].ToString())
                    .Select(g => new { gioiTinh = g.Key, SoLuong = g.Count() });

                genderData = new DataTable();
                genderData.Columns.Add("gioiTinh", typeof(string));
                genderData.Columns.Add("SoLuong", typeof(int));
                foreach (var item in genderStats)
                {
                    genderData.Rows.Add(item.gioiTinh, item.SoLuong);
                }

                // Load dữ liệu theo độ tuổi
                var ageStats = dsPetShop.Tables["ThuCung"].AsEnumerable()
                    .GroupBy(r => {
                        int tuoi = Convert.ToInt32(r["tuoi"]);
                        if (tuoi >= 0 && tuoi <= 2) return "0-2";
                        if (tuoi >= 3 && tuoi <= 5) return "3-5";
                        if (tuoi >= 6 && tuoi <= 8) return "6-8";
                        if (tuoi >= 9 && tuoi <= 11) return "9-11";
                        return "12+";
                    })
                    .Select(g => new { NhomTuoi = g.Key, SoLuong = g.Count() })
                    .OrderBy(x => x.NhomTuoi);

                ageData = new DataTable();
                ageData.Columns.Add("NhomTuoi", typeof(string));
                ageData.Columns.Add("SoLuong", typeof(int));
                foreach (var item in ageStats)
                {
                    ageData.Rows.Add(item.NhomTuoi, item.SoLuong);
                }

                // Load top 5 giống
                var breedStats = dsPetShop.Tables["ThuCung"].AsEnumerable()
                    .Where(r => !string.IsNullOrEmpty(r["giongThuCung"].ToString()))
                    .GroupBy(r => r["giongThuCung"].ToString())
                    .Select(g => new { giongThuCung = g.Key, SoLuong = g.Count() })
                    .OrderByDescending(x => x.SoLuong)
                    .Take(5);

                breedData = new DataTable();
                breedData.Columns.Add("giongThuCung", typeof(string));
                breedData.Columns.Add("SoLuong", typeof(int));
                foreach (var item in breedStats)
                {
                    breedData.Rows.Add(item.giongThuCung, item.SoLuong);
                }

                // Debug output
                System.Diagnostics.Debug.WriteLine($"Species: {speciesData.Rows.Count} rows");
                System.Diagnostics.Debug.WriteLine($"Gender: {genderData.Rows.Count} rows");
                System.Diagnostics.Debug.WriteLine($"Age: {ageData.Rows.Count} rows");
                System.Diagnostics.Debug.WriteLine($"Breed: {breedData.Rows.Count} rows");

                // Refresh các panel vẽ
                panelSpeciesChart.Invalidate();
                panelGenderChart.Invalidate();
                panelAgeChart.Invalidate();
                panelBreedChart.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message + "\n\n" + ex.StackTrace,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PanelSpeciesChart_Paint(object sender, PaintEventArgs e)
        {
            if (speciesData == null || speciesData.Rows.Count == 0)
            {
                DrawNoDataMessage(e.Graphics, panelSpeciesChart, "Không có dữ liệu loại thú cưng");
                return;
            }

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int total = 0;
            foreach (DataRow row in speciesData.Rows)
                total += Convert.ToInt32(row["SoLuong"]);

            if (total == 0)
            {
                DrawNoDataMessage(g, panelSpeciesChart, "Chưa có thú cưng nào");
                return;
            }

            // Vẽ biểu đồ tròn (donut)
            int chartSize = 180;
            int chartX = (panelSpeciesChart.Width - chartSize) / 2 - 20;
            int chartY = 60;
            Rectangle rect = new Rectangle(chartX, chartY, chartSize, chartSize);
            float startAngle = -90;

            Color[] colors = {
                Color.FromArgb(59, 130, 246),
                Color.FromArgb(147, 197, 253),
                Color.FromArgb(96, 165, 250),
                Color.FromArgb(37, 99, 235),
                Color.FromArgb(191, 219, 254)
            };

            int colorIndex = 0;
            int yLegend = chartY + chartSize + 30;

            foreach (DataRow row in speciesData.Rows)
            {
                int count = Convert.ToInt32(row["SoLuong"]);
                if (count == 0) continue; // Bỏ qua loại không có thú cưng khi vẽ

                float sweepAngle = (float)count / total * 360;

                using (SolidBrush brush = new SolidBrush(colors[colorIndex % colors.Length]))
                {
                    g.FillPie(brush, rect, startAngle, sweepAngle);
                }

                startAngle += sweepAngle;
                colorIndex++;
            }

            // Vẽ legend (hiển thị cả loại có 0 thú cưng)
            colorIndex = 0;
            yLegend = chartY + chartSize + 30;
            foreach (DataRow row in speciesData.Rows)
            {
                int count = Convert.ToInt32(row["SoLuong"]);

                using (SolidBrush brush = new SolidBrush(colors[colorIndex % colors.Length]))
                {
                    g.FillEllipse(brush, 30, yLegend, 12, 12);
                }

                string legendText = $"{row["tenLoai"]}";
                g.DrawString(legendText, new Font("Segoe UI", 9), Brushes.Black, 50, yLegend - 2);

                string countText = $"{count} ({(total > 0 ? (count * 100.0 / total) : 0):F1}%)";
                SizeF countSize = g.MeasureString(countText, new Font("Segoe UI", 9, FontStyle.Bold));
                g.DrawString(countText, new Font("Segoe UI", 9, FontStyle.Bold), Brushes.Black,
                    panelSpeciesChart.Width - countSize.Width - 30, yLegend - 2);

                colorIndex++;
                yLegend += 22;
            }

            // Vẽ lỗ giữa (donut hole)
            int holeSize = 70;
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                g.FillEllipse(brush, rect.X + (chartSize - holeSize) / 2,
                    rect.Y + (chartSize - holeSize) / 2, holeSize, holeSize);
            }

            // Vẽ tổng số ở giữa
            string totalText = total.ToString();
            using (Font font = new Font("Segoe UI", 28, FontStyle.Bold))
            {
                SizeF size = g.MeasureString(totalText, font);
                g.DrawString(totalText, font, Brushes.Black,
                    rect.X + (rect.Width - size.Width) / 2,
                    rect.Y + (rect.Height - size.Height) / 2 - 8);
            }

            using (Font font = new Font("Segoe UI", 9))
            {
                SizeF size = g.MeasureString("Tổng số", font);
                g.DrawString("Tổng số", font, Brushes.Gray,
                    rect.X + (rect.Width - size.Width) / 2,
                    rect.Y + rect.Height / 2 + 18);
            }
        }

        private void PanelGenderChart_Paint(object sender, PaintEventArgs e)
        {
            if (genderData == null || genderData.Rows.Count == 0)
            {
                DrawNoDataMessage(e.Graphics, panelGenderChart, "Không có dữ liệu giới tính");
                return;
            }

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int total = 0;
            foreach (DataRow row in genderData.Rows)
                total += Convert.ToInt32(row["SoLuong"]);

            if (total == 0) return;

            // Vẽ biểu đồ tròn (donut)
            int chartSize = 180;
            int chartX = (panelGenderChart.Width - chartSize) / 2 - 20;
            int chartY = 60;
            Rectangle rect = new Rectangle(chartX, chartY, chartSize, chartSize);
            float startAngle = -90;

            Color[] colors = {
                Color.FromArgb(59, 130, 246),
                Color.FromArgb(147, 197, 253)
            };

            int colorIndex = 0;
            int yLegend = chartY + chartSize + 30;

            foreach (DataRow row in genderData.Rows)
            {
                int count = Convert.ToInt32(row["SoLuong"]);
                float sweepAngle = (float)count / total * 360;

                using (SolidBrush brush = new SolidBrush(colors[colorIndex % colors.Length]))
                {
                    g.FillPie(brush, rect, startAngle, sweepAngle);
                }

                // Vẽ legend
                using (SolidBrush brush = new SolidBrush(colors[colorIndex % colors.Length]))
                {
                    g.FillEllipse(brush, 30, yLegend, 12, 12);
                }

                string genderText = row["gioiTinh"].ToString();
                g.DrawString(genderText, new Font("Segoe UI", 9), Brushes.Black, 50, yLegend - 2);

                string countText = $"{count} ({(count * 100.0 / total):F0}%)";
                SizeF countSize = g.MeasureString(countText, new Font("Segoe UI", 9, FontStyle.Bold));
                g.DrawString(countText, new Font("Segoe UI", 9, FontStyle.Bold), Brushes.Black,
                    panelGenderChart.Width - countSize.Width - 30, yLegend - 2);

                startAngle += sweepAngle;
                colorIndex++;
                yLegend += 22;
            }

            // Vẽ lỗ giữa
            int holeSize = 70;
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                g.FillEllipse(brush, rect.X + (chartSize - holeSize) / 2,
                    rect.Y + (chartSize - holeSize) / 2, holeSize, holeSize);
            }

            // Vẽ icon giới tính ở giữa
            using (Font font = new Font("Segoe UI", 36))
            {
                string icon = "⚥";
                SizeF size = g.MeasureString(icon, font);
                g.DrawString(icon, font, Brushes.Gray,
                    rect.X + (rect.Width - size.Width) / 2,
                    rect.Y + (rect.Height - size.Height) / 2);
            }
        }

        private void PanelBreedChart_Paint(object sender, PaintEventArgs e)
        {
            if (breedData == null || breedData.Rows.Count == 0)
            {
                DrawNoDataMessage(e.Graphics, panelBreedChart, "Không có dữ liệu giống");
                return;
            }

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int maxCount = 0;
            foreach (DataRow row in breedData.Rows)
            {
                int count = Convert.ToInt32(row["SoLuong"]);
                if (count > maxCount) maxCount = count;
            }

            if (maxCount == 0) return;

            int barHeight = 40;
            int barSpacing = 18;
            int startY = 70;
            int startX = 30;
            int maxBarWidth = panelBreedChart.Width - 200;

            Color barColor = Color.FromArgb(59, 130, 246);

            // Vẽ tiêu đề phụ
            g.DrawString("5 giống phổ biến nhất.", new Font("Segoe UI", 9),
                Brushes.Gray, startX, 45);

            for (int i = 0; i < breedData.Rows.Count; i++)
            {
                DataRow row = breedData.Rows[i];
                string breed = row["giongThuCung"].ToString();
                int count = Convert.ToInt32(row["SoLuong"]);
                int barWidth = (int)((double)count / maxCount * maxBarWidth);

                int y = startY + i * (barHeight + barSpacing);

                // Vẽ thanh nền
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(226, 232, 240)))
                {
                    g.FillRectangle(brush, startX, y, maxBarWidth, barHeight);
                }

                // Vẽ thanh dữ liệu
                using (SolidBrush brush = new SolidBrush(barColor))
                {
                    g.FillRectangle(brush, startX, y, barWidth, barHeight);
                }

                // Vẽ tên giống
                g.DrawString(breed, new Font("Segoe UI", 10), Brushes.White, startX + 10, y + 11);

                // Vẽ số lượng
                string countText = count.ToString();
                g.DrawString(countText, new Font("Segoe UI", 11, FontStyle.Bold),
                    Brushes.Black, startX + maxBarWidth + 15, y + 10);
            }
        }

        private void PanelAgeChart_Paint(object sender, PaintEventArgs e)
        {
            if (ageData == null || ageData.Rows.Count == 0)
            {
                DrawNoDataMessage(e.Graphics, panelAgeChart, "Không có dữ liệu độ tuổi");
                return;
            }

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int maxCount = 0;
            foreach (DataRow row in ageData.Rows)
            {
                int count = Convert.ToInt32(row["SoLuong"]);
                if (count > maxCount) maxCount = count;
            }

            if (maxCount == 0) maxCount = 1;

            int barWidth = 100;
            int barSpacing = 50;
            int maxBarHeight = panelAgeChart.Height - 170;
            int baseY = panelAgeChart.Height - 60;

            Color barColor = Color.FromArgb(59, 130, 246);

            // Tính tuổi trung bình
            if (dsPetShop.Tables.Contains("ThuCung") && dsPetShop.Tables["ThuCung"].Rows.Count > 0)
            {
                var avgAge = dsPetShop.Tables["ThuCung"].AsEnumerable()
                    .Average(r => Convert.ToDouble(r["tuoi"]));
                g.DrawString($"Tuổi trung bình là {avgAge:F1} tuổi.", new Font("Segoe UI", 9),
                    Brushes.Gray, 30, 45);
            }

            // Sắp xếp theo thứ tự tuổi
            string[] ageOrder = { "0-2", "3-5", "6-8", "9-11", "12+" };

            // Tính tổng chiều rộng để căn giữa
            int totalWidth = (barWidth * ageOrder.Length) + (barSpacing * (ageOrder.Length - 1));
            int startX = (panelAgeChart.Width - totalWidth) / 2;

            for (int i = 0; i < ageOrder.Length; i++)
            {
                DataRow[] rows = ageData.Select($"NhomTuoi = '{ageOrder[i]}'");
                int count = rows.Length > 0 ? Convert.ToInt32(rows[0]["SoLuong"]) : 0;

                int barHeight = maxCount > 0 ? (int)((double)count / maxCount * maxBarHeight) : 0;
                if (barHeight < 5 && count > 0) barHeight = 5;

                int x = startX + i * (barWidth + barSpacing);
                int y = baseY - barHeight;

                // Vẽ số lượng TRƯỚC (trên đầu cột, bên ngoài)
                if (count > 0)
                {
                    string countText = count.ToString();
                    SizeF countSize = g.MeasureString(countText, new Font("Segoe UI", 11, FontStyle.Bold));
                    g.DrawString(countText, new Font("Segoe UI", 11, FontStyle.Bold),
                        Brushes.Black, x + (barWidth - countSize.Width) / 2, y - 30);
                }

                // Vẽ cột SAU (để số không bị che)
                using (SolidBrush brush = new SolidBrush(barColor))
                {
                    g.FillRectangle(brush, x, y, barWidth, barHeight);
                }

                // Vẽ nhãn tuổi
                SizeF labelSize = g.MeasureString(ageOrder[i], new Font("Segoe UI", 10));
                g.DrawString(ageOrder[i], new Font("Segoe UI", 10), Brushes.Gray,
                    x + (barWidth - labelSize.Width) / 2, baseY + 8);
            }
        }

        private void DrawNoDataMessage(Graphics g, Panel panel, string message)
        {
            g.Clear(Color.White);
            using (Font font = new Font("Segoe UI", 12))
            {
                SizeF size = g.MeasureString(message, font);
                g.DrawString(message, font, Brushes.Gray,
                    (panel.Width - size.Width) / 2,
                    (panel.Height - size.Height) / 2);
            }
        }
    }
}
