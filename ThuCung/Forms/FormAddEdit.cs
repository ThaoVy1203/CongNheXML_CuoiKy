using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ThuCung.Forms
{
    public partial class FormAddEdit : Form
    {
        private static readonly string XmlPath =
     Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\data\ThuCung.xml"));
        private DataSet dsPetShop;
        private int? petId = null;
        private string selectedImagePath = "";

        public FormAddEdit()
        {
            InitializeComponent();
            LoadDataFromXml();
            InitializeForm();
        }

        public FormAddEdit(int id) : this()
        {
            petId = id;
            LoadPetData();
            lblTitle.Text = "Sửa thông tin thú cưng";
            lblSubtitle.Text = "Cập nhật thông tin thú cưng bên dưới";
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
                    this.Close();
                    return;
                }

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

        private void InitializeForm()
        {
            // Bo tròn các nút
            btnSave.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSave.Width, btnSave.Height, 10, 10));
            btnCancel.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnCancel.Width, btnCancel.Height, 10, 10));
            btnBrowseImage.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnBrowseImage.Width, btnBrowseImage.Height, 10, 10));

            // Load loại thú cưng
            LoadLoaiThuCung();

            // Set default image
            picPetImage.Image = CreatePlaceholderImage();

            // Event handlers
            btnBrowseImage.Click += BtnBrowseImage_Click;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern System.IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private Image CreatePlaceholderImage()
        {
            Bitmap bmp = new Bitmap(260, 260);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(226, 232, 240));
                using (Font font = new Font("Segoe UI Emoji", 60))
                {
                    string text = "📷";
                    SizeF textSize = g.MeasureString(text, font);
                    g.DrawString(text, font, Brushes.Gray, (260 - textSize.Width) / 2, (260 - textSize.Height) / 2);
                }
            }
            return bmp;
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

                DataTable dtLoai = dsPetShop.Tables["Loai"];

                cboLoaiThuCung.DisplayMember = "tenLoai";
                cboLoaiThuCung.ValueMember = "idLoai";
                cboLoaiThuCung.DataSource = dtLoai;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load loại thú cưng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPetData()
        {
            try
            {
                if (dsPetShop == null || !dsPetShop.Tables.Contains("ThuCung"))
                {
                    MessageBox.Show("Không tìm thấy bảng ThuCung trong XML!", "Lỗi");
                    return;
                }

                DataRow[] rows = dsPetShop.Tables["ThuCung"].Select($"idThuCung = {petId}");

                if (rows.Length > 0)
                {
                    DataRow row = rows[0];
                    txtTenThuCung.Text = row["tenThuCung"].ToString();
                    txtTuoi.Text = row["tuoi"].ToString();
                    txtGiongThuCung.Text = row["giongThuCung"].ToString();
                    cboGioiTinh.SelectedItem = row["gioiTinh"].ToString();
                    txtMauSac.Text = row["mauSac"].ToString();
                    txtCanNang.Text = row["canNang"].ToString();
                    txtTieuChuanCanNang.Text = row["tieuChuanCanNang"].ToString();
                    txtGiaBan.Text = row["giaBan"].ToString();
                    cboLoaiThuCung.SelectedValue = row["idLoai"];

                    selectedImagePath = row["anhThuCung"].ToString();

                    // Thử load ảnh từ nhiều đường dẫn khác nhau
                    if (!string.IsNullOrEmpty(selectedImagePath))
                    {
                        bool imageLoaded = false;
                        string projectPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));

                        string[] possiblePaths = {
                            selectedImagePath,
                            Path.Combine(Application.StartupPath, selectedImagePath),
                            Path.Combine(Application.StartupPath, "Images", selectedImagePath),
                            Path.Combine(Application.StartupPath, "Images", Path.GetFileName(selectedImagePath)),
                            Path.Combine(projectPath, "Images", selectedImagePath),
                            Path.Combine(projectPath, "Images", Path.GetFileName(selectedImagePath))
                        };

                        foreach (string path in possiblePaths)
                        {
                            if (File.Exists(path))
                            {
                                try
                                {
                                    picPetImage.Image = Image.FromFile(path);
                                    selectedImagePath = path;
                                    imageLoaded = true;
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
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                    // Load ảnh vào PictureBox
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                if (dsPetShop == null || !dsPetShop.Tables.Contains("ThuCung"))
                {
                    MessageBox.Show("Không tìm thấy bảng ThuCung!", "Lỗi");
                    return;
                }

                DataTable dtThuCung = dsPetShop.Tables["ThuCung"];

                if (petId.HasValue)
                {
                    // Update - Tìm dòng cần sửa
                    DataRow[] rows = dtThuCung.Select($"idThuCung = {petId}");
                    if (rows.Length > 0)
                    {
                        DataRow row = rows[0];
                        row["tenThuCung"] = txtTenThuCung.Text;
                        row["tuoi"] = int.Parse(txtTuoi.Text);
                        row["giongThuCung"] = txtGiongThuCung.Text;
                        row["gioiTinh"] = cboGioiTinh.SelectedItem.ToString();
                        row["mauSac"] = txtMauSac.Text;
                        row["canNang"] = decimal.Parse(txtCanNang.Text);
                        row["tieuChuanCanNang"] = decimal.Parse(txtTieuChuanCanNang.Text);
                        row["giaBan"] = decimal.Parse(txtGiaBan.Text);
                        row["anhThuCung"] = selectedImagePath;
                        row["idLoai"] = cboLoaiThuCung.SelectedValue;
                    }
                }
                else
                {
                    // Insert - Tạo ID mới
                    int newId = 1;
                    if (dtThuCung.Rows.Count > 0)
                    {
                        newId = dtThuCung.AsEnumerable()
                            .Max(r => Convert.ToInt32(r["idThuCung"])) + 1;
                    }

                    DataRow newRow = dtThuCung.NewRow();
                    newRow["idThuCung"] = newId;
                    newRow["tenThuCung"] = txtTenThuCung.Text;
                    newRow["tuoi"] = int.Parse(txtTuoi.Text);
                    newRow["giongThuCung"] = txtGiongThuCung.Text;
                    newRow["gioiTinh"] = cboGioiTinh.SelectedItem.ToString();
                    newRow["mauSac"] = txtMauSac.Text;
                    newRow["canNang"] = decimal.Parse(txtCanNang.Text);
                    newRow["tieuChuanCanNang"] = decimal.Parse(txtTieuChuanCanNang.Text);
                    newRow["giaBan"] = decimal.Parse(txtGiaBan.Text);
                    newRow["anhThuCung"] = selectedImagePath;
                    newRow["idLoai"] = cboLoaiThuCung.SelectedValue;

                    dtThuCung.Rows.Add(newRow);
                }

                // Lưu lại vào file XML
                string fullPath = Path.GetFullPath(XmlPath);
                dsPetShop.AcceptChanges();
                dsPetShop.WriteXml(fullPath);

                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenThuCung.Text))
            {
                MessageBox.Show("Vui lòng nhập tên thú cưng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenThuCung.Focus();
                return false;
            }

            if (!int.TryParse(txtTuoi.Text, out int tuoi) || tuoi < 0)
            {
                MessageBox.Show("Tuổi phải là số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTuoi.Focus();
                return false;
            }

            if (!decimal.TryParse(txtCanNang.Text, out decimal canNang) || canNang <= 0)
            {
                MessageBox.Show("Cân nặng phải là số dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCanNang.Focus();
                return false;
            }

            if (!decimal.TryParse(txtGiaBan.Text, out decimal giaBan) || giaBan <= 0)
            {
                MessageBox.Show("Giá bán phải là số dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaBan.Focus();
                return false;
            }

            if (cboLoaiThuCung.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn loại thú cưng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}