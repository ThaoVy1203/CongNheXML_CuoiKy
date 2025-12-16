using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using ThuCung.DatabaseHelper;

namespace ThuCung.Forms
{
    public partial class FormAddEditSQL : Form
    {
        private int? petId = null;
        private TextBox txtTen, txtMauSac, txtGiong;
        private NumericUpDown numTuoi, numCanNang, numTieuChuan, numGia, numLoai;
        private ComboBox cboGioiTinh;
        private Button btnSave, btnCancel, btnBrowseImage;
        private PictureBox picPetImage;
        private string selectedImagePath = "";

        public FormAddEditSQL()
        {
            InitializeComponent();
            InitializeFormProperties();
            InitializeCustomComponents();
            this.Text = "Thêm thú cưng mới";
        }

        public FormAddEditSQL(int id) : this()
        {
            petId = id;
            this.Text = "Sửa thông tin thú cưng";
            LoadPetData();
        }

        private void InitializeFormProperties()
        {
            this.Width = 900;  // Tăng chiều rộng
            this.Height = 580;  // Giảm chiều cao
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(240, 245, 255);
        }

        private void InitializeCustomComponents()
        {
            int yPos = 20;
            int spacing = 45;
            int labelWidth = 160;
            int controlWidth = 250;
            int leftMargin = 20;
            int controlLeft = leftMargin + labelWidth + 10;

            // Title
            Label lblTitle = new Label
            {
                Text = petId.HasValue ? "Sửa thông tin thú cưng" : "Thêm thú cưng mới",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 58, 138),
                Left = leftMargin,
                Top = yPos,
                Width = 780,
                Height = 30
            };
            this.Controls.Add(lblTitle);
            yPos += 40;

            // Panel bên trái cho form nhập liệu
            Panel leftPanel = new Panel
            {
                Left = leftMargin,
                Top = yPos,
                Width = 480,
                Height = 420,
                BackColor = Color.Transparent
            };
            this.Controls.Add(leftPanel);

            // Panel bên phải cho ảnh - giảm chiều cao để vừa với nội dung
            Panel rightPanel = new Panel
            {
                Left = leftMargin + 500,
                Top = yPos,
                Width = 340,
                Height = 420,  // Giữ nguyên để chứa cả 2 nút
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(rightPanel);

            // Thêm label cho ảnh
            Label lblImage = new Label
            {
                Text = "Hình ảnh thú cưng",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 58, 138),
                Left = 10,
                Top = 10,
                Width = 320,
                Height = 25
            };
            rightPanel.Controls.Add(lblImage);

            // PictureBox để hiển thị ảnh - fit với khung camera
            picPetImage = new PictureBox
            {
                Left = 10,
                Top = 45,
                Width = 320,
                Height = 240,  // Tỷ lệ 4:3 như camera
                SizeMode = PictureBoxSizeMode.Zoom,  // Zoom để giữ tỷ lệ ảnh
                BackColor = Color.FromArgb(226, 232, 240),
                BorderStyle = BorderStyle.FixedSingle
            };
            picPetImage.Image = CreatePlaceholderImage();
            rightPanel.Controls.Add(picPetImage);

            // Nút chọn ảnh
            btnBrowseImage = new Button
            {
                Text = "📁 Chọn hình ảnh",
                Left = 10,
                Top = 300,
                Width = 320,
                Height = 45,
                BackColor = Color.FromArgb(59, 130, 246),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnBrowseImage.FlatAppearance.BorderSize = 0;
            btnBrowseImage.Click += BtnBrowseImage_Click;
            rightPanel.Controls.Add(btnBrowseImage);

            // Nút Lưu - đặt trong rightPanel
            btnSave = new Button
            {
                Text = "💾 Lưu",
                Left = 10,
                Top = 360,  // Dưới nút chọn ảnh
                Width = 155,
                Height = 45,
                BackColor = Color.FromArgb(59, 130, 246),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;
            rightPanel.Controls.Add(btnSave);

            // Nút Hủy - đặt trong rightPanel
            btnCancel = new Button
            {
                Text = "❌ Hủy",
                Left = 175,  // Bên cạnh nút Lưu
                Top = 360,
                Width = 155,
                Height = 45,
                BackColor = Color.FromArgb(239, 68, 68),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            rightPanel.Controls.Add(btnCancel);

            // Reset yPos cho các control trong leftPanel
            int leftPanelY = 0;

            // Tên thú cưng
            Label lblTen = new Label { Text = "Tên thú cưng:", Left = 0, Top = leftPanelY, Width = labelWidth, Font = new Font("Segoe UI", 10) };
            txtTen = new TextBox { Left = labelWidth + 10, Top = leftPanelY, Width = controlWidth, Font = new Font("Segoe UI", 10) };
            leftPanel.Controls.Add(lblTen);
            leftPanel.Controls.Add(txtTen);
            leftPanelY += spacing;

            // Tuổi
            Label lblTuoi = new Label { Text = "Tuổi:", Left = 0, Top = leftPanelY, Width = labelWidth, Font = new Font("Segoe UI", 10) };
            numTuoi = new NumericUpDown { Left = labelWidth + 10, Top = leftPanelY, Width = controlWidth, Minimum = 0, Maximum = 50, Font = new Font("Segoe UI", 10) };
            leftPanel.Controls.Add(lblTuoi);
            leftPanel.Controls.Add(numTuoi);
            leftPanelY += spacing;

            // Giới tính
            Label lblGioiTinh = new Label { Text = "Giới tính:", Left = 0, Top = leftPanelY, Width = labelWidth, Font = new Font("Segoe UI", 10) };
            cboGioiTinh = new ComboBox { Left = labelWidth + 10, Top = leftPanelY, Width = controlWidth, DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 10) };
            cboGioiTinh.Items.AddRange(new object[] { "Đực", "Cái" });
            cboGioiTinh.SelectedIndex = 0;
            leftPanel.Controls.Add(lblGioiTinh);
            leftPanel.Controls.Add(cboGioiTinh);
            leftPanelY += spacing;

            // Màu sắc
            Label lblMauSac = new Label { Text = "Màu sắc:", Left = 0, Top = leftPanelY, Width = labelWidth, Font = new Font("Segoe UI", 10) };
            txtMauSac = new TextBox { Left = labelWidth + 10, Top = leftPanelY, Width = controlWidth, Font = new Font("Segoe UI", 10) };
            leftPanel.Controls.Add(lblMauSac);
            leftPanel.Controls.Add(txtMauSac);
            leftPanelY += spacing;

            // Cân nặng
            Label lblCanNang = new Label { Text = "Cân nặng (kg):", Left = 0, Top = leftPanelY, Width = labelWidth, Font = new Font("Segoe UI", 10) };
            numCanNang = new NumericUpDown { Left = labelWidth + 10, Top = leftPanelY, Width = controlWidth, DecimalPlaces = 2, Minimum = 0, Maximum = 100, Font = new Font("Segoe UI", 10) };
            leftPanel.Controls.Add(lblCanNang);
            leftPanel.Controls.Add(numCanNang);
            leftPanelY += spacing;

            // Giống
            Label lblGiong = new Label { Text = "Giống:", Left = 0, Top = leftPanelY, Width = labelWidth, Font = new Font("Segoe UI", 10) };
            txtGiong = new TextBox { Left = labelWidth + 10, Top = leftPanelY, Width = controlWidth, Font = new Font("Segoe UI", 10) };
            leftPanel.Controls.Add(lblGiong);
            leftPanel.Controls.Add(txtGiong);
            leftPanelY += spacing;

            // Tiêu chuẩn cân nặng
            Label lblTieuChuan = new Label { Text = "Tiêu chuẩn cân nặng:", Left = 0, Top = leftPanelY, Width = labelWidth, Font = new Font("Segoe UI", 10) };
            numTieuChuan = new NumericUpDown { Left = labelWidth + 10, Top = leftPanelY, Width = controlWidth, DecimalPlaces = 2, Minimum = 0, Maximum = 100, Font = new Font("Segoe UI", 10) };
            leftPanel.Controls.Add(lblTieuChuan);
            leftPanel.Controls.Add(numTieuChuan);
            leftPanelY += spacing;

            // Giá bán
            Label lblGia = new Label { Text = "Giá bán:", Left = 0, Top = leftPanelY, Width = labelWidth, Font = new Font("Segoe UI", 10) };
            numGia = new NumericUpDown { Left = labelWidth + 10, Top = leftPanelY, Width = controlWidth, Maximum = 999999999, ThousandsSeparator = true, Font = new Font("Segoe UI", 10) };
            leftPanel.Controls.Add(lblGia);
            leftPanel.Controls.Add(numGia);
            leftPanelY += spacing;

            // ID Loại
            Label lblLoai = new Label { Text = "ID Loại:", Left = 0, Top = leftPanelY, Width = labelWidth, Font = new Font("Segoe UI", 10) };
            numLoai = new NumericUpDown { Left = labelWidth + 10, Top = leftPanelY, Width = controlWidth, Minimum = 1, Maximum = 100, Value = 1, Font = new Font("Segoe UI", 10) };
            leftPanel.Controls.Add(lblLoai);
            leftPanel.Controls.Add(numLoai);
            leftPanelY += spacing + 20;

            // Set Accept và Cancel buttons
            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;
        }

        private Image CreatePlaceholderImage()
        {
            Bitmap bmp = new Bitmap(320, 240);  // Tỷ lệ 4:3
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(226, 232, 240));
                using (Font font = new Font("Segoe UI Emoji", 50))
                {
                    string text = "📷";
                    SizeF textSize = g.MeasureString(text, font);
                    g.DrawString(text, font, Brushes.Gray, (320 - textSize.Width) / 2, (240 - textSize.Height) / 2);
                }
            }
            return bmp;
        }

        private void BtnBrowseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp",
                Title = "Chọn hình ảnh thú cưng"
            };

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    selectedImagePath = openDialog.FileName;
                    using (var img = Image.FromFile(selectedImagePath))
                    {
                        picPetImage.Image = new Bitmap(img);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi load ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadPetData()
        {
            try
            {
                string query = "SELECT * FROM tbThuCung WHERE Id = @id";
                SqlParameter[] parameters = { new SqlParameter("@id", petId.Value) };
                DataTable dt = DatabaseHelper.DatabaseHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtTen.Text = row["TenThuCung"].ToString();
                    numTuoi.Value = Convert.ToInt32(row["Tuoi"]);
                    cboGioiTinh.SelectedItem = row["GioiTinh"].ToString();
                    txtMauSac.Text = row["MauSac"].ToString();
                    numCanNang.Value = Convert.ToDecimal(row["CanNang"]);
                    txtGiong.Text = row["GiongThuCung"].ToString();
                    numTieuChuan.Value = Convert.ToDecimal(row["TieuChuanCanNang"]);
                    numGia.Value = Convert.ToDecimal(row["GiaBan"]);
                    numLoai.Value = Convert.ToInt32(row["IdLoai"]);
                    
                    // Load ảnh nếu có
                    selectedImagePath = row["AnhThuCung"]?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(selectedImagePath))
                    {
                        string projectPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, @"..\..\"));
                        string[] possiblePaths = {
                            selectedImagePath,
                            System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, selectedImagePath),
                            System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Images", selectedImagePath),
                            System.IO.Path.Combine(projectPath, "Images", selectedImagePath),
                            System.IO.Path.Combine(projectPath, "Images", System.IO.Path.GetFileName(selectedImagePath))
                        };

                        foreach (string path in possiblePaths)
                        {
                            if (System.IO.File.Exists(path))
                            {
                                try
                                {
                                    picPetImage.Image = Image.FromFile(path);
                                    selectedImagePath = path;
                                    break;
                                }
                                catch { }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                MessageBox.Show("Vui lòng nhập tên thú cưng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTen.Focus();
                return;
            }

            try
            {
                if (petId.HasValue)
                {
                    // Update
                    string updateQuery = @"UPDATE tbThuCung SET 
                                         TenThuCung = @ten, 
                                         Tuoi = @tuoi, 
                                         GioiTinh = @gt, 
                                         MauSac = @ms, 
                                         CanNang = @cn, 
                                         GiongThuCung = @giong, 
                                         TieuChuanCanNang = @tc, 
                                         AnhThuCung = @anh,
                                         GiaBan = @gia, 
                                         IdLoai = @loai
                                         WHERE Id = @id";

                    SqlParameter[] parameters = {
                        new SqlParameter("@ten", txtTen.Text),
                        new SqlParameter("@tuoi", (int)numTuoi.Value),
                        new SqlParameter("@gt", cboGioiTinh.SelectedItem.ToString()),
                        new SqlParameter("@ms", txtMauSac.Text),
                        new SqlParameter("@cn", (double)numCanNang.Value),
                        new SqlParameter("@giong", txtGiong.Text),
                        new SqlParameter("@tc", (double)numTieuChuan.Value),
                        new SqlParameter("@anh", selectedImagePath),
                        new SqlParameter("@gia", (decimal)numGia.Value),
                        new SqlParameter("@loai", (int)numLoai.Value),
                        new SqlParameter("@id", petId.Value)
                    };

                    int result = DatabaseHelper.DatabaseHelper.ExecuteNonQuery(updateQuery, parameters);
                    if (result > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    // Insert
                    string insertQuery = @"INSERT INTO tbThuCung (TenThuCung, Tuoi, GioiTinh, MauSac, CanNang, GiongThuCung, TieuChuanCanNang, AnhThuCung, GiaBan, IdLoai)
                                         VALUES (@ten, @tuoi, @gt, @ms, @cn, @giong, @tc, @anh, @gia, @loai)";

                    SqlParameter[] parameters = {
                        new SqlParameter("@ten", txtTen.Text),
                        new SqlParameter("@tuoi", (int)numTuoi.Value),
                        new SqlParameter("@gt", cboGioiTinh.SelectedItem.ToString()),
                        new SqlParameter("@ms", txtMauSac.Text),
                        new SqlParameter("@cn", (double)numCanNang.Value),
                        new SqlParameter("@giong", txtGiong.Text),
                        new SqlParameter("@tc", (double)numTieuChuan.Value),
                        new SqlParameter("@anh", selectedImagePath),
                        new SqlParameter("@gia", (decimal)numGia.Value),
                        new SqlParameter("@loai", (int)numLoai.Value)
                    };

                    int result = DatabaseHelper.DatabaseHelper.ExecuteNonQuery(insertQuery, parameters);
                    if (result > 0)
                    {
                        MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
