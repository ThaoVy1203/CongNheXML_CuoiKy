using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ThuCung.Forms
{
    public partial class FormLogin : Form
    {
        private static readonly string XmlPath =
    Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\data\ThuCung.xml"));
        private DataSet dsPetShop;

        public FormLogin()
        {
            InitializeComponent();
            // Điền sẵn tài khoản để test nhanh
            txtUsername.Text = "admin@gmail.com";
            txtPassword.Text = "123456";

            // Đưa con trỏ vào cuối ô username (đẹp hơn)
            txtUsername.SelectionStart = txtUsername.Text.Length;
            string fullPath = Path.GetFullPath(XmlPath);
            if (!File.Exists(fullPath))
            {
                MessageBox.Show(
                    $"Không tìm thấy file dữ liệu!\n" +
                    $"Đường dẫn: {fullPath}\n\n" +
                    $"Vui lòng kiểm tra:\n" +
                    $"- File ThuCung.xml có trong thư mục 'data' không?\n" +
                    $"- Thuộc tính Copy to Output Directory đã bật chưa?",
                    "Lỗi khởi động",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            LoadDataFromXml(fullPath);
            btnLogin.Click += btnLogin_Click;
            txtPassword.KeyPress += txtPassword_KeyPress;
            txtUsername.KeyPress += txtUsername_KeyPress;
        }

        private void LoadDataFromXml(string path)
        {
            try
            {
                dsPetShop = new DataSet();
                dsPetShop.ReadXml(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi đọc file XML:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ email và mật khẩu!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (CheckLogin(email, password))
            {
                MessageBox.Show(
                    "Đăng nhập thành công!",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Hide();
                FromMain mainForm = new FromMain();
                mainForm.FormClosed += (s, args) => this.Close();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show(
                    "Email hoặc mật khẩu không đúng!",
                    "Lỗi đăng nhập",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private bool CheckLogin(string email, string matKhau)
        {
            try
            {
                if (dsPetShop == null || !dsPetShop.Tables.Contains("NguoiDung"))
                    return false;

                var table = dsPetShop.Tables["NguoiDung"];

                foreach (DataRow row in table.Rows)
                {
                    string dbEmail = row["email"]?.ToString().Trim() ?? "";
                    string dbPassword = row["matKhau"]?.ToString().Trim() ?? "";

                    if (dbEmail == email && dbPassword == matKhau)
                        return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
                e.Handled = true;
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Focus();
                e.Handled = true;
            }
        }
    }
}