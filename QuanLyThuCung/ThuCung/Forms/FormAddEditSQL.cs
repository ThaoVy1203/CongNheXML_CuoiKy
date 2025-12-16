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
        private Button btnSave, btnCancel;

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
            this.Width = 550;
            this.Height = 620;
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
            int controlWidth = 300;
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
                Width = 480,
                Height = 30
            };
            this.Controls.Add(lblTitle);
            yPos += 40;

            // Tên thú cưng
            Label lblTen = new Label { Text = "Tên thú cưng:", Left = leftMargin, Top = yPos, Width = labelWidth, Font = new Font("Segoe UI", 10) };
            txtTen = new TextBox { Left = controlLeft, Top = yPos, Width = controlWidth, Font = new Font("Segoe UI", 10) };
            this.Controls.Add(lblTen);
            this.Controls.Add(txtTen);
            yPos += spacing;

            // Tuổi
            Label lblTuoi = new Label { Text = "Tuổi:", Left = leftMargin, Top = yPos, Width = labelWidth, Font = new Font("Segoe UI", 10) };
            numTuoi = new NumericUpDown { Left = controlLeft, Top = yPos, Width = controlWidth, Minimum = 0, Maximum = 50, Font = new Font("Segoe UI", 10) };
            this.Controls.Add(lblTuoi);
            this.Controls.Add(numTuoi);
            yPos += spacing;

            // Giới tính
            Label lblGioiTinh = new Label { Text = "Giới tính:", Left = leftMargin, Top = yPos, Width = labelWidth, Font = new Font("Segoe UI", 10) };
            cboGioiTinh = new ComboBox { Left = controlLeft, Top = yPos, Width = controlWidth, DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 10) };
            cboGioiTinh.Items.AddRange(new object[] { "Đực", "Cái" });
            cboGioiTinh.SelectedIndex = 0;
            this.Controls.Add(lblGioiTinh);
            this.Controls.Add(cboGioiTinh);
            yPos += spacing;

            // Màu sắc
            Label lblMauSac = new Label { Text = "Màu sắc:", Left = leftMargin, Top = yPos, Width = labelWidth, Font = new Font("Segoe UI", 10) };
            txtMauSac = new TextBox { Left = controlLeft, Top = yPos, Width = controlWidth, Font = new Font("Segoe UI", 10) };
            this.Controls.Add(lblMauSac);
            this.Controls.Add(txtMauSac);
            yPos += spacing;

            // Cân nặng
            Label lblCanNang = new Label { Text = "Cân nặng (kg):", Left = leftMargin, Top = yPos, Width = labelWidth, Font = new Font("Segoe UI", 10) };
            numCanNang = new NumericUpDown { Left = controlLeft, Top = yPos, Width = controlWidth, DecimalPlaces = 2, Minimum = 0, Maximum = 100, Font = new Font("Segoe UI", 10) };
            this.Controls.Add(lblCanNang);
            this.Controls.Add(numCanNang);
            yPos += spacing;

            // Giống
            Label lblGiong = new Label { Text = "Giống:", Left = leftMargin, Top = yPos, Width = labelWidth, Font = new Font("Segoe UI", 10) };
            txtGiong = new TextBox { Left = controlLeft, Top = yPos, Width = controlWidth, Font = new Font("Segoe UI", 10) };
            this.Controls.Add(lblGiong);
            this.Controls.Add(txtGiong);
            yPos += spacing;

            // Tiêu chuẩn cân nặng
            Label lblTieuChuan = new Label { Text = "Tiêu chuẩn cân nặng:", Left = leftMargin, Top = yPos, Width = labelWidth, Font = new Font("Segoe UI", 10) };
            numTieuChuan = new NumericUpDown { Left = controlLeft, Top = yPos, Width = controlWidth, DecimalPlaces = 2, Minimum = 0, Maximum = 100, Font = new Font("Segoe UI", 10) };
            this.Controls.Add(lblTieuChuan);
            this.Controls.Add(numTieuChuan);
            yPos += spacing;

            // Giá bán
            Label lblGia = new Label { Text = "Giá bán:", Left = leftMargin, Top = yPos, Width = labelWidth, Font = new Font("Segoe UI", 10) };
            numGia = new NumericUpDown { Left = controlLeft, Top = yPos, Width = controlWidth, Maximum = 999999999, ThousandsSeparator = true, Font = new Font("Segoe UI", 10) };
            this.Controls.Add(lblGia);
            this.Controls.Add(numGia);
            yPos += spacing;

            // ID Loại
            Label lblLoai = new Label { Text = "ID Loại:", Left = leftMargin, Top = yPos, Width = labelWidth, Font = new Font("Segoe UI", 10) };
            numLoai = new NumericUpDown { Left = controlLeft, Top = yPos, Width = controlWidth, Minimum = 1, Maximum = 100, Value = 1, Font = new Font("Segoe UI", 10) };
            this.Controls.Add(lblLoai);
            this.Controls.Add(numLoai);
            yPos += spacing + 20;

            // Buttons
            btnSave = new Button
            {
                Text = "💾 Lưu",
                Left = controlLeft + 80,
                Top = yPos,
                Width = 100,
                Height = 40,
                BackColor = Color.FromArgb(59, 130, 246),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;

            btnCancel = new Button
            {
                Text = "❌ Hủy",
                Left = controlLeft + 190,
                Top = yPos,
                Width = 100,
                Height = 40,
                BackColor = Color.FromArgb(239, 68, 68),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);
            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;
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
                        new SqlParameter("@gia", (decimal)numGia.Value),
                        new SqlParameter("@loai", (int)numLoai.Value),
                        new SqlParameter("@id", petId.Value)
                    };

                    int result = DatabaseHelper.DatabaseHelper.ExecuteNonQuery(updateQuery, parameters);
                    if (result > 0)
                    {
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
                        new SqlParameter("@anh", ""),
                        new SqlParameter("@gia", (decimal)numGia.Value),
                        new SqlParameter("@loai", (int)numLoai.Value)
                    };

                    int result = DatabaseHelper.DatabaseHelper.ExecuteNonQuery(insertQuery, parameters);
                    if (result > 0)
                    {
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
