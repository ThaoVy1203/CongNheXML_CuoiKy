using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Linq;
using System.Data.SqlClient;
using System.Xml.Linq;
using ThuCung.DatabaseHelper;

namespace ThuCung.Forms
{
    public partial class FromMain : Form
    {
        private static readonly string XmlPath =
    Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\data\ThuCung.xml"));

        private DataSet dsPetShop;
        private DataTable dtThuCung;
        private DataTable dtLoai;
        private UserControl currentPage = null;
        public FromMain()
        {
            InitializeComponent();
            SetupSearchTextBox();

            // Bật DoubleBuffered để tránh lỗi sọc khi scroll
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            // Bật DoubleBuffered cho FlowLayoutPanel
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, flowLayoutPets, new object[] { true });

            // Load dữ liệu khi form khởi tạo
            this.Load += FromMain_Load;

            // Thêm event cho combobox
            this.cboLoaiThuCung.SelectedIndexChanged += CboLoaiThuCung_SelectedIndexChanged;

            // Bo tròn góc nút Add Pet
            btnAddPet.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnAddPet.Width, btnAddPet.Height, 10, 10));

            

            // Thiết kế ComboBox đẹp hơn
            cboLoaiThuCung.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            cboLoaiThuCung.BackColor = Color.White;
            cboLoaiThuCung.ForeColor = Color.FromArgb(45, 55, 72);
            // Thêm hover effect cho menu buttons
            SetupMenuButtonHover(btnMenuHome);
            SetupMenuButtonHover(btnMenuManage);
            SetupMenuButtonHover(btnMenuReports);
            SetupMenuButtonHover(btnMenuInvoice);
            SetupMenuButtonHover(btnMenuHelp);
            SetupMenuButtonHover(btnMenuData);

            // Thêm click event cho menu buttons
            btnMenuHome.Click += BtnMenuHome_Logout_Click;
            btnMenuData.Click += BtnMenuData_Click;
            btnMenuReports.Click += BtnMenuReports_Click;

            // Thêm click event cho context menu items
            menuItemViewXml.Click += MenuItemViewXml_Click;
            menuItemExportXml.Click += MenuItemExportXml_Click;
            menuItemConvertXML.Click += menuItemConvertXML_Click;

            // Thêm click event cho nút Add Pet

            btnAddPet.Click += BtnAddPet_Click;
        }
        
        private void SetupSearchTextBox()
        {
            // Thiết kế ban đầu
            txtSearch.Text = "🔍 Tìm kiếm thú cưng...";
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Font = new Font("Segoe UI", 11);
            txtSearch.BorderStyle = BorderStyle.None; // Ẩn viền mặc định
            txtSearch.Padding = new Padding(15, 12, 15, 12); // Đệm trong

            // Tạo viền thủ công bằng Panel cha (panelSearchBorder)
            panelSearchBorder.BackColor = Color.FromArgb(37, 150, 190); // #2596be
            panelSearchBorder.Padding = new Padding(2); // Độ dày viền

            // Panel bên trong để làm nền trắng cho TextBox
            Panel innerPanel = new Panel
            {
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                Padding = new Padding(0)
            };
            innerPanel.Controls.Add(txtSearch);
            panelSearchBorder.Controls.Add(innerPanel);

            // Bo góc cho cả panel ngoài
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int radius = 10;
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panelSearchBorder.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(panelSearchBorder.Width - radius, panelSearchBorder.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, panelSearchBorder.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            panelSearchBorder.Region = new Region(path);

            // Xử lý Focus / Blur đẹp
            txtSearch.GotFocus += (s, e) =>
            {
                if (txtSearch.Text == "🔍 Tìm kiếm thú cưng...")
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.FromArgb(45, 55, 72);
                }
                panelSearchBorder.BackColor = Color.FromArgb(30, 130, 200); // Đậm hơn khi focus
            };

            txtSearch.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = "🔍 Tìm kiếm thú cưng...";
                    txtSearch.ForeColor = Color.Gray;
                }
                panelSearchBorder.BackColor = Color.FromArgb(37, 150, 190); // Trở về màu #2596be
            };

            // Tìm kiếm realtime
            txtSearch.TextChanged += (s, e) =>
            {
                string text = txtSearch.Text.Trim();
                if (text == "" || text == "🔍 Tìm kiếm thú cưng...")
                {
                    LoadThuCung(); // Hiện tất cả
                }
                else
                {
                    SearchPets(text);
                }
            };
        }
        private void BtnAddPet_Click(object sender, EventArgs e)
        {
            FormAddEdit formAdd = new FormAddEdit();
            if (formAdd.ShowDialog() == DialogResult.OK)
            {
                // Reload danh sách sau khi thêm
                LoadDataFromXml();
                LoadThuCung();
            }
        }

        private void SetupMenuButtonHover(Button btn)
        {
            btn.MouseEnter += (s, e) => {
                btn.BackColor = Color.FromArgb(66, 165, 245);
            };
            btn.MouseLeave += (s, e) => {
                btn.BackColor = Color.Transparent;
            };
        }

        private void BtnMenuHome_Logout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?",
                "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                FormLogin loginForm = new FormLogin();
                loginForm.FormClosed += (s, args) => this.Close();
                loginForm.Show();
            }
        }

        private void BtnMenuData_Click(object sender, EventArgs e)
        {
            contextMenuData.Show(btnMenuData, new Point(0, btnMenuData.Height));
        }

        private void BtnMenuReports_Click(object sender, EventArgs e)
        {
            contextMenuReports.Show(btnMenuReports, new Point(0, btnMenuReports.Height));
        }

        private void menuItemReportPets_Click(object sender, EventArgs e)
        {
            ShowPage(new BaoCaoThuCung());
        }

        private void menuItemReportRevenue_Click(object sender, EventArgs e)
        {
            ShowPage(new BaoCaoDoanhThu());
        }



        private void MenuItemViewXml_Click(object sender, EventArgs e)
        {
            ShowPage(new XemXML(dtThuCung));
        }

        private void MenuItemExportXml_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "XML Files (*.xml)|*.xml",
                    FileName = "ThuCung_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xml",
                    Title = "Xuất dữ liệu XML"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // Sao chép file XML gốc ra file mới
                    string fullPath = Path.GetFullPath(XmlPath);
                    File.Copy(fullPath, saveDialog.FileName, true);

                    MessageBox.Show("Xuất XML thành công!\nĐường dẫn: " + saveDialog.FileName,
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất XML: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern System.IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        private void FromMain_Load(object sender, EventArgs e)
        {
            string fullPath = Path.GetFullPath(XmlPath);
            if (!File.Exists(fullPath))
            {
                MessageBox.Show(
                    $"Không tìm thấy file dữ liệu!\nĐường dẫn: {fullPath}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.Close();
                return;
            }

            LoadDataFromXml();
            LoadLoaiThuCung();
            LoadThuCung();

            
        }

        private void LoadDataFromXml()
        {
            try
            {
                string fullPath = Path.GetFullPath(XmlPath);
                dsPetShop = new DataSet();
                dsPetShop.ReadXml(fullPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc file XML:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void LoadLoaiThuCung()
        {
            try
            {
                if (dsPetShop == null || !dsPetShop.Tables.Contains("Loai"))
                {
                    MessageBox.Show("Không tìm thấy bảng Loai trong XML!", "Lỗi");
                    return;
                }

                dtLoai = dsPetShop.Tables["Loai"];

                cboLoaiThuCung.Items.Clear();
                cboLoaiThuCung.Items.Add("🐾 Tất cả thú cưng");

                foreach (DataRow row in dtLoai.Rows)
                {
                    cboLoaiThuCung.Items.Add(row["tenLoai"].ToString());
                }

                cboLoaiThuCung.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load loại thú cưng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadThuCung(int? idLoai = null)
        {
            try
            {
                if (dsPetShop == null || !dsPetShop.Tables.Contains("ThuCung"))
                {
                    MessageBox.Show("Không tìm thấy bảng ThuCung trong XML!", "Lỗi");
                    return;
                }

                // Lấy toàn bộ dữ liệu từ bảng ThuCung
                dtThuCung = dsPetShop.Tables["ThuCung"].Copy();

                // Lọc theo idLoai nếu có
                if (idLoai.HasValue)
                {
                    DataRow[] filteredRows = dtThuCung.Select($"idLoai = {idLoai.Value}");
                    dtThuCung = dtThuCung.Clone(); // Tạo bảng mới với cùng cấu trúc
                    foreach (DataRow row in filteredRows)
                    {
                        dtThuCung.ImportRow(row);
                    }
                }

                DisplayPetCards();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load thú cưng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayPetCards()
        {
            flowLayoutPets.Controls.Clear();

            if (dtThuCung == null || dtThuCung.Rows.Count == 0)
            {
                Label lblEmpty = new Label
                {
                    Text = "Không có thú cưng nào",
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Padding = new Padding(20)
                };
                flowLayoutPets.Controls.Add(lblEmpty);
                return;
            }

            flowLayoutPets.Padding = new Padding(50, 30, 50, 30);

            foreach (DataRow row in dtThuCung.Rows)
            {
                Panel cardPanel = CreatePetCard(row);
                flowLayoutPets.Controls.Add(cardPanel);
            }
        }

        private Panel CreatePetCard(DataRow row)
        {
            Panel card = new Panel
            {
                Width = 350,
                Height = 420,
                BackColor = Color.White,
                Margin = new Padding(15),
                Padding = new Padding(0)
            };

            System.Drawing.Drawing2D.GraphicsPath cardPath = new System.Drawing.Drawing2D.GraphicsPath();
            cardPath.AddArc(0, 0, 20, 20, 180, 90);
            cardPath.AddArc(card.Width - 20, 0, 20, 20, 270, 90);
            cardPath.AddArc(card.Width - 20, card.Height - 20, 20, 20, 0, 90);
            cardPath.AddArc(0, card.Height - 20, 20, 20, 90, 90);
            cardPath.CloseFigure();
            card.Region = new Region(cardPath);

            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, card, new object[] { true });

            Panel imgPanel = new Panel
            {
                Width = 350,
                Height = 220,
                BackColor = Color.FromArgb(240, 245, 255),
                Dock = DockStyle.Top
            };

            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, imgPanel, new object[] { true });

            imgPanel.Paint += (s, e) =>
            {
                System.Drawing.Drawing2D.GraphicsPath imgPath = new System.Drawing.Drawing2D.GraphicsPath();
                imgPath.AddArc(0, 0, 20, 20, 180, 90);
                imgPath.AddArc(imgPanel.Width - 20, 0, 20, 20, 270, 90);
                imgPath.AddLine(imgPanel.Width, 20, imgPanel.Width, imgPanel.Height);
                imgPath.AddLine(imgPanel.Width, imgPanel.Height, 0, imgPanel.Height);
                imgPath.AddLine(0, imgPanel.Height, 0, 20);
                imgPath.CloseFigure();
                imgPanel.Region = new Region(imgPath);
            };

            PictureBox picBox = new PictureBox
            {
                Width = 350,
                Height = 220,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.FromArgb(240, 245, 255),
                Dock = DockStyle.Fill
            };

            string imagePath = row["anhThuCung"].ToString();
            bool imageLoaded = false;

            if (!string.IsNullOrEmpty(imagePath))
            {
                string projectPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));

                string[] possiblePaths = {
                    imagePath,
                    Path.Combine(Application.StartupPath, imagePath),
                    Path.Combine(Application.StartupPath, "Images", imagePath),
                    Path.Combine(Application.StartupPath, "Images", Path.GetFileName(imagePath)),
                    Path.Combine(projectPath, "Images", imagePath),
                    Path.Combine(projectPath, "Images", Path.GetFileName(imagePath))
                };

                foreach (string path in possiblePaths)
                {
                    if (File.Exists(path))
                    {
                        try
                        {
                            picBox.Image = Image.FromFile(path);
                            imgPanel.Controls.Add(picBox);
                            imageLoaded = true;
                            break;
                        }
                        catch { }
                    }
                }
            }

            if (!imageLoaded)
            {
                Label lblIcon = new Label
                {
                    Text = "🐾",
                    Font = new Font("Segoe UI Emoji", 80),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    ForeColor = Color.FromArgb(59, 130, 246),
                    BackColor = Color.FromArgb(240, 245, 255)
                };
                imgPanel.Controls.Add(lblIcon);
            }

            card.Controls.Add(imgPanel);

            Panel infoPanel = new Panel
            {
                Width = 350,
                Height = 200,
                Location = new Point(0, 220),
                BackColor = Color.White,
                Padding = new Padding(0)
            };

            Label lblName = new Label
            {
                Text = row["tenThuCung"].ToString(),
                Font = new Font("Segoe UI", 15, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 58, 138),
                AutoSize = false,
                Width = 320,
                Height = 32,
                Location = new Point(15, 8)
            };
            infoPanel.Controls.Add(lblName);

            string giong = row["giongThuCung"] != DBNull.Value ? row["giongThuCung"].ToString() : "Chưa rõ";
            string tuoi = row["tuoi"] != DBNull.Value ? row["tuoi"].ToString() + " tuổi" : "Chưa rõ tuổi";
            Label lblInfo = new Label
            {
                Text = $"{giong} • {tuoi}",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                AutoSize = false,
                Width = 320,
                Height = 24,
                Location = new Point(15, 45)
            };
            infoPanel.Controls.Add(lblInfo);

            Panel statusPanel = new Panel
            {
                Width = 105,
                Height = 26,
                Location = new Point(15, 75),
                BackColor = Color.FromArgb(220, 252, 231)
            };
            Label lblStatus = new Label
            {
                Text = "■ Khỏe mạnh",
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                ForeColor = Color.FromArgb(34, 197, 94),
                AutoSize = true,
                Location = new Point(7, 5)
            };
            statusPanel.Controls.Add(lblStatus);
            infoPanel.Controls.Add(statusPanel);

            Button btnEdit = new Button
            {
                Text = "✏ Chỉnh sửa",
                Width = 150,
                Height = 40,
                Location = new Point(15, 115),
                BackColor = Color.FromArgb(59, 130, 246),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Tag = row["idThuCung"]
            };
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.Click += BtnEdit_Click;

            System.Drawing.Drawing2D.GraphicsPath btnEditPath = new System.Drawing.Drawing2D.GraphicsPath();
            btnEditPath.AddArc(0, 0, 10, 10, 180, 90);
            btnEditPath.AddArc(btnEdit.Width - 10, 0, 10, 10, 270, 90);
            btnEditPath.AddArc(btnEdit.Width - 10, btnEdit.Height - 10, 10, 10, 0, 90);
            btnEditPath.AddArc(0, btnEdit.Height - 10, 10, 10, 90, 90);
            btnEditPath.CloseFigure();
            btnEdit.Region = new Region(btnEditPath);

            infoPanel.Controls.Add(btnEdit);

            Button btnDelete = new Button
            {
                Text = "🗑 Xóa",
                Width = 150,
                Height = 40,
                Location = new Point(175, 115),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(239, 68, 68),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Tag = row["idThuCung"]
            };
            btnDelete.FlatAppearance.BorderColor = Color.FromArgb(239, 68, 68);
            btnDelete.FlatAppearance.BorderSize = 2;
            btnDelete.Click += BtnDelete_Click;

            System.Drawing.Drawing2D.GraphicsPath btnDeletePath = new System.Drawing.Drawing2D.GraphicsPath();
            btnDeletePath.AddArc(0, 0, 10, 10, 180, 90);
            btnDeletePath.AddArc(btnDelete.Width - 10, 0, 10, 10, 270, 90);
            btnDeletePath.AddArc(btnDelete.Width - 10, btnDelete.Height - 10, 10, 10, 0, 90);
            btnDeletePath.AddArc(0, btnDelete.Height - 10, 10, 10, 90, 90);
            btnDeletePath.CloseFigure();
            btnDelete.Region = new Region(btnDeletePath);

            infoPanel.Controls.Add(btnDelete);

            card.Controls.Add(infoPanel);

            card.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, card.ClientRectangle,
                    Color.FromArgb(226, 232, 240), 2, ButtonBorderStyle.Solid,
                    Color.FromArgb(226, 232, 240), 2, ButtonBorderStyle.Solid,
                    Color.FromArgb(226, 232, 240), 2, ButtonBorderStyle.Solid,
                    Color.FromArgb(226, 232, 240), 2, ButtonBorderStyle.Solid);
            };

            return card;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int idThuCung = Convert.ToInt32(btn.Tag);

            FormAddEdit formEdit = new FormAddEdit(idThuCung);
            if (formEdit.ShowDialog() == DialogResult.OK)
            {
                LoadDataFromXml();
                LoadThuCung();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int idThuCung = Convert.ToInt32(btn.Tag);

            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa thú cưng này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            try
            {
                string fullPath = Path.GetFullPath(XmlPath);

                // ✅ Đọc trực tiếp file XML bằng XDocument
                XDocument doc = XDocument.Load(fullPath);

                // ✅ Tìm và xóa node ThuCung có idThuCung tương ứng
                var petToDelete = doc.Root
                    .Elements("ThuCung")
                    .FirstOrDefault(x => x.Element("idThuCung")?.Value == idThuCung.ToString());

                if (petToDelete == null)
                {
                    MessageBox.Show(
                        $"❌ Không tìm thấy thú cưng có ID = {idThuCung}",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // ✅ Xóa node
                petToDelete.Remove();

                // ✅ Lưu lại file
                doc.Save(fullPath);

                // ✅ Reload lại dữ liệu
                LoadDataFromXml();

                if (cboLoaiThuCung.SelectedIndex == 0)
                {
                    LoadThuCung();
                }
                else
                {
                    string tenLoai = cboLoaiThuCung.SelectedItem.ToString();
                    DataRow[] loaiRows = dtLoai.Select($"tenLoai = '{tenLoai}'");
                    if (loaiRows.Length > 0)
                    {
                        int idLoai = Convert.ToInt32(loaiRows[0]["idLoai"]);
                        LoadThuCung(idLoai);
                    }
                }

                MessageBox.Show(
                    "✅ Xóa thú cưng thành công!",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"❌ Lỗi: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void SearchPets(string keyword)
        {
            try
            {
                if (dsPetShop == null || !dsPetShop.Tables.Contains("ThuCung"))
                    return;

                keyword = keyword.ToLower();

                DataRow[] filteredRows = dsPetShop.Tables["ThuCung"].Select().Where(row =>
                {
                    string tenThuCung = row["tenThuCung"]?.ToString().ToLower() ?? "";
                    string giongThuCung = row["giongThuCung"]?.ToString().ToLower() ?? "";
                    return tenThuCung.Contains(keyword) || giongThuCung.Contains(keyword);
                }).ToArray();

                dtThuCung = dsPetShop.Tables["ThuCung"].Clone();
                foreach (DataRow row in filteredRows)
                {
                    dtThuCung.ImportRow(row);
                }

                DisplayPetCards();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CboLoaiThuCung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoaiThuCung.SelectedIndex == 0)
            {
                LoadThuCung();
            }
            else
            {
                string tenLoai = cboLoaiThuCung.SelectedItem.ToString();
                DataRow[] rows = dtLoai.Select($"tenLoai = '{tenLoai}'");
                if (rows.Length > 0)
                {
                    int idLoai = Convert.ToInt32(rows[0]["idLoai"]);
                    LoadThuCung(idLoai);
                }
            }
        }
        private void ShowPage(UserControl page = null)
        {
            // --- Bước 1: Quản lý hiển thị các Control chính ---

            // Xác định xem có hiển thị trang Quản lý thú cưng hay không (khi page == null)
            bool isPetManagement = (page == null);

            // Ẩn/Hiện panelFilter (Chứa ComboBox, TextBox Search, Add Button)
            panelFilter.Visible = isPetManagement;

            // Ẩn/Hiện flowLayoutPets (Chứa các Pet Card)
            flowLayoutPets.Visible = isPetManagement;

            // --- Bước 2: Xóa trang UserControl cũ (nếu có) ---
            for (int i = panelContent.Controls.Count - 1; i >= 0; i--)
            {
                Control ctrl = panelContent.Controls[i];
                // Chỉ xóa các Control thuộc loại UserControl (như XemHoaDon)
                if (ctrl is UserControl)
                {
                    panelContent.Controls.RemoveAt(i);
                    ctrl.Dispose();
                }
            }

            // --- Bước 3: Thêm và hiển thị trang mới (nếu có) ---
            if (page != null)
            {
                page.Dock = DockStyle.Fill;
                panelContent.Controls.Add(page);
                page.BringToFront(); // Đảm bảo trang mới nằm trên cùng
            }
        }
        private void btnMenuInvoice_Click(object sender, EventArgs e)
        {
            ShowPage(new XemHoaDon());
        }

        private void menuItemConvertXML_Click(object sender, EventArgs e)
        {
            ShowPage(new ChuyenSangXML());
        }

        private void menuItemConvertSQL_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Bạn có chắc muốn chuyển toàn bộ dữ liệu từ file XML sang SQL Server?\n\nDữ liệu cũ sẽ bị xóa hoàn toàn!",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            Cursor = Cursors.WaitCursor;
            try
            {
                string xmlPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\data\ThuCung.xml"));
                if (!File.Exists(xmlPath))
                {
                    MessageBox.Show("Không tìm thấy file XML!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                XDocument doc = XDocument.Load(xmlPath);

                using (SqlConnection conn = DatabaseHelper.DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            // XÓA theo thứ tự con -> cha
                            string[] deletes = { "tbChiTietHoaDon", "tbHoaDon", "tbThuCung", "tbNguoiDung", "tbLoai", "tbVaiTro" };
                            foreach (var t in deletes)
                                new SqlCommand($"DELETE FROM {t}", conn, tran).ExecuteNonQuery();

                            // Local helper: bật IDENTITY_INSERT, chạy action insert, tắt IDENTITY_INSERT
                            void InsertWithIdentity(string table, Action<SqlCommand> doInserts)
                            {
                                new SqlCommand($"SET IDENTITY_INSERT {table} ON", conn, tran).ExecuteNonQuery();
                                doInserts(null);
                                new SqlCommand($"SET IDENTITY_INSERT {table} OFF", conn, tran).ExecuteNonQuery();
                            }

                            // 1) tbVaiTro
                            InsertWithIdentity("tbVaiTro", _ =>
                            {
                                using (var cmd = new SqlCommand("INSERT INTO tbVaiTro (Id, TenVaiTro) VALUES (@id,@ten)", conn, tran))
                                {
                                    cmd.Parameters.Add("@id", SqlDbType.Int);
                                    cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 50);
                                    foreach (var vt in doc.Root.Elements("VaiTro"))
                                    {
                                        cmd.Parameters["@id"].Value = int.Parse(vt.Element("idVaiTro").Value);
                                        cmd.Parameters["@ten"].Value = vt.Element("tenVaiTro")?.Value ?? "";
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            });

                            // 2) tbNguoiDung
                            InsertWithIdentity("tbNguoiDung", _ =>
                            {
                                using (var cmd = new SqlCommand(
                                    "INSERT INTO tbNguoiDung (Id, HoTen, Email, MatKhau, Sdt, IdVaiTro) VALUES (@id,@ten,@mail,@mk,@sdt,@vt)",
                                    conn, tran))
                                {
                                    cmd.Parameters.AddRange(new[]
                                    {
                                new SqlParameter("@id", SqlDbType.Int),
                                new SqlParameter("@ten", SqlDbType.NVarChar,100),
                                new SqlParameter("@mail", SqlDbType.NVarChar,100),
                                new SqlParameter("@mk", SqlDbType.NVarChar,100),
                                new SqlParameter("@sdt", SqlDbType.NVarChar,15),
                                new SqlParameter("@vt", SqlDbType.Int)
                            });
                                    foreach (var nd in doc.Root.Elements("NguoiDung"))
                                    {
                                        cmd.Parameters["@id"].Value = int.Parse(nd.Element("idNguoiDung").Value);
                                        cmd.Parameters["@ten"].Value = nd.Element("hoTen")?.Value ?? "";
                                        cmd.Parameters["@mail"].Value = nd.Element("email")?.Value ?? "";
                                        cmd.Parameters["@mk"].Value = nd.Element("matKhau")?.Value ?? "";
                                        cmd.Parameters["@sdt"].Value = nd.Element("sdt")?.Value ?? "";
                                        cmd.Parameters["@vt"].Value = int.Parse(nd.Element("idVaiTro").Value);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            });

                            // 3) tbLoai
                            InsertWithIdentity("tbLoai", _ =>
                            {
                                using (var cmd = new SqlCommand("INSERT INTO tbLoai (Id, TenLoai) VALUES (@id,@ten)", conn, tran))
                                {
                                    cmd.Parameters.Add("@id", SqlDbType.Int);
                                    cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 50);
                                    foreach (var l in doc.Root.Elements("Loai"))
                                    {
                                        cmd.Parameters["@id"].Value = int.Parse(l.Element("idLoai").Value);
                                        cmd.Parameters["@ten"].Value = l.Element("tenLoai")?.Value ?? "";
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            });

                            // 4) tbThuCung
                            InsertWithIdentity("tbThuCung", _ =>
                            {
                                using (var cmd = new SqlCommand(
                                    @"INSERT INTO tbThuCung (Id, TenThuCung, Tuoi, GioiTinh, MauSac, CanNang, GiongThuCung, TieuChuanCanNang, AnhThuCung, GiaBan, IdLoai)
                              VALUES (@id,@ten,@tuoi,@gt,@ms,@cn,@giong,@tc,@anh,@gia,@idLoai)", conn, tran))
                                {
                                    cmd.Parameters.AddRange(new[]
                                    {
                                new SqlParameter("@id", SqlDbType.Int),
                                new SqlParameter("@ten", SqlDbType.NVarChar,100),
                                new SqlParameter("@tuoi", SqlDbType.Int),
                                new SqlParameter("@gt", SqlDbType.NVarChar,10),
                                new SqlParameter("@ms", SqlDbType.NVarChar,50),
                                new SqlParameter("@cn", SqlDbType.Float),
                                new SqlParameter("@giong", SqlDbType.NVarChar,100),
                                new SqlParameter("@tc", SqlDbType.Float),
                                new SqlParameter("@anh", SqlDbType.NVarChar,255),
                                new SqlParameter("@gia", SqlDbType.Decimal){ Precision = 18, Scale = 2 },
                                new SqlParameter("@idLoai", SqlDbType.Int)
                            });
                                    foreach (var tc in doc.Root.Elements("ThuCung"))
                                    {
                                        cmd.Parameters["@id"].Value = int.Parse(tc.Element("idThuCung").Value);
                                        cmd.Parameters["@ten"].Value = tc.Element("tenThuCung")?.Value ?? "";
                                        cmd.Parameters["@tuoi"].Value = int.Parse(tc.Element("tuoi")?.Value ?? "0");
                                        cmd.Parameters["@gt"].Value = tc.Element("gioiTinh")?.Value ?? "";
                                        cmd.Parameters["@ms"].Value = tc.Element("mauSac")?.Value ?? "";
                                        cmd.Parameters["@cn"].Value = double.Parse(tc.Element("canNang")?.Value ?? "0");
                                        cmd.Parameters["@giong"].Value = tc.Element("giongThuCung")?.Value ?? "";
                                        cmd.Parameters["@tc"].Value = double.Parse(tc.Element("tieuChuanCanNang")?.Value ?? "0");
                                        cmd.Parameters["@anh"].Value = tc.Element("anhThuCung")?.Value ?? "";
                                        cmd.Parameters["@gia"].Value = decimal.Parse(tc.Element("giaBan")?.Value ?? "0");
                                        cmd.Parameters["@idLoai"].Value = int.Parse(tc.Element("idLoai").Value);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            });

                            // 5) tbHoaDon
                            InsertWithIdentity("tbHoaDon", _ =>
                            {
                                using (var cmd = new SqlCommand(
                                    "INSERT INTO tbHoaDon (Id, IdNguoiDung, NgayLap, TongTien, GhiChu) VALUES (@id,@nd,@ngay,@tong,@ghi)",
                                    conn, tran))
                                {
                                    cmd.Parameters.AddRange(new[]
                                    {
                                new SqlParameter("@id", SqlDbType.Int),
                                new SqlParameter("@nd", SqlDbType.Int),
                                new SqlParameter("@ngay", SqlDbType.DateTime),
                                new SqlParameter("@tong", SqlDbType.Decimal){ Precision = 18, Scale = 2 },
                                new SqlParameter("@ghi", SqlDbType.NVarChar,255)
                            });
                                    foreach (var hd in doc.Root.Elements("HoaDon"))
                                    {
                                        cmd.Parameters["@id"].Value = int.Parse(hd.Element("idHoaDon").Value);
                                        cmd.Parameters["@nd"].Value = int.Parse(hd.Element("idNguoiDung").Value);
                                        cmd.Parameters["@ngay"].Value = DateTime.Parse(hd.Element("ngayLap").Value);
                                        cmd.Parameters["@tong"].Value = decimal.Parse(hd.Element("tongTien").Value);
                                        cmd.Parameters["@ghi"].Value = hd.Element("ghiChu")?.Value ?? "";
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            });

                            // 6) tbChiTietHoaDon
                            InsertWithIdentity("tbChiTietHoaDon", _ =>
                            {
                                using (var cmd = new SqlCommand(
                                    @"INSERT INTO tbChiTietHoaDon (Id, IdHoaDon, IdThuCung, SoLuong, DonGia, ThanhTien)
                              VALUES (@id,@hd,@tc,@sl,@dg,@tt)", conn, tran))
                                {
                                    cmd.Parameters.AddRange(new[]
                                    {
                                new SqlParameter("@id", SqlDbType.Int),
                                new SqlParameter("@hd", SqlDbType.Int),
                                new SqlParameter("@tc", SqlDbType.Int),
                                new SqlParameter("@sl", SqlDbType.Int),
                                new SqlParameter("@dg", SqlDbType.Decimal){ Precision = 18, Scale = 2 },
                                new SqlParameter("@tt", SqlDbType.Decimal){ Precision = 18, Scale = 2 }
                            });
                                    foreach (var ct in doc.Root.Elements("ChiTietHoaDon"))
                                    {
                                        cmd.Parameters["@id"].Value = int.Parse(ct.Element("idChiTiet").Value);
                                        cmd.Parameters["@hd"].Value = int.Parse(ct.Element("idHoaDon").Value);
                                        cmd.Parameters["@tc"].Value = int.Parse(ct.Element("idThuCung").Value);
                                        cmd.Parameters["@sl"].Value = int.Parse(ct.Element("soLuong").Value);
                                        cmd.Parameters["@dg"].Value = decimal.Parse(ct.Element("donGia").Value);
                                        cmd.Parameters["@tt"].Value = decimal.Parse(ct.Element("thanhTien").Value);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            });

                            // RESEED mỗi bảng về MAX(Id)
                            string[] reseed = { "tbVaiTro", "tbNguoiDung", "tbLoai", "tbThuCung", "tbHoaDon", "tbChiTietHoaDon" };
                            foreach (var t in reseed)
                                new SqlCommand($@"DECLARE @m INT; SELECT @m = ISNULL(MAX(Id),0) FROM {t}; DBCC CHECKIDENT('{t}', RESEED, @m);", conn, tran).ExecuteNonQuery();

                            tran.Commit();
                            MessageBox.Show("✅ Chuyển dữ liệu XML → SQL thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            try { tran.Rollback(); } catch { }
                            MessageBox.Show("Lỗi khi import: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnMenuManage_Click(object sender, EventArgs e)
        {
            ShowPage();           // Xóa trang khác, hiện lại trang quản lý thú cưng
            LoadThuCung();        // Cập nhật danh sách mới nhất
        }

        private void btnMenuHome_Click_1(object sender, EventArgs e)
        {

        }

        private void flowLayoutPets_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}