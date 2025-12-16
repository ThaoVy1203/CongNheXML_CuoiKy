using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using ThuCung.DatabaseHelper;
using ThuCung.Forms;

namespace ThuCung
{
    public partial class ChuyenSangXML: UserControl
    {
        private static readonly string XmlPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\data\ThuCung.xml"));

        public ChuyenSangXML()
        {
            InitializeComponent();
            this.Load += ChuyenSangXML_Load;
            StyleDataGridViews();
        }

        private void ChuyenSangXML_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void StyleDataGridViews()
        {
            // Style cho dgvXML
            dgvXML.EnableHeadersVisualStyles = false;
            dgvXML.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(59, 130, 246);
            dgvXML.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvXML.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvXML.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvXML.ColumnHeadersHeight = 40;
            dgvXML.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 255);
            dgvXML.DefaultCellStyle.SelectionBackColor = Color.FromArgb(59, 130, 246);
            dgvXML.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvXML.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvXML.RowTemplate.Height = 35;

            // Style cho dgvSQL
            dgvSQL.EnableHeadersVisualStyles = false;
            dgvSQL.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 197, 94);
            dgvSQL.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSQL.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvSQL.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSQL.ColumnHeadersHeight = 40;
            dgvSQL.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 253, 244);
            dgvSQL.DefaultCellStyle.SelectionBackColor = Color.FromArgb(34, 197, 94);
            dgvSQL.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvSQL.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvSQL.RowTemplate.Height = 35;
        }

        private void LoadData()
        {
            LoadXMLData();
            LoadSQLData();
        }

        private void LoadXMLData()
        {
            try
            {
                if (!File.Exists(XmlPath))
                {
                    MessageBox.Show("Không tìm thấy file XML!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataSet ds = new DataSet();
                ds.ReadXml(XmlPath);

                if (ds.Tables.Contains("ThuCung") && ds.Tables.Contains("Loai"))
                {
                    DataTable dtThuCung = ds.Tables["ThuCung"].Copy();
                    DataTable dtLoai = ds.Tables["Loai"].Copy();
                    
                    // Tạo DataTable mới với JOIN
                    DataTable dt = new DataTable();
                    dt.Columns.Add("ID", typeof(int));
                    dt.Columns.Add("Tên thú cưng", typeof(string));
                    dt.Columns.Add("Tuổi", typeof(int));
                    dt.Columns.Add("Giới tính", typeof(string));
                    dt.Columns.Add("Màu sắc", typeof(string));
                    dt.Columns.Add("Cân nặng", typeof(double));
                    dt.Columns.Add("Giống", typeof(string));
                    dt.Columns.Add("Tiêu chuẩn cân nặng", typeof(double));
                    dt.Columns.Add("Ảnh thú cưng", typeof(string));
                    dt.Columns.Add("Giá bán", typeof(decimal));
                    dt.Columns.Add("ID Loại", typeof(int));
                    dt.Columns.Add("Tên loại", typeof(string));

                    // JOIN dữ liệu
                    foreach (DataRow rowTC in dtThuCung.Rows)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["ID"] = rowTC["idThuCung"];
                        newRow["Tên thú cưng"] = rowTC["tenThuCung"];
                        newRow["Tuổi"] = rowTC["tuoi"];
                        newRow["Giới tính"] = rowTC["gioiTinh"];
                        newRow["Màu sắc"] = rowTC["mauSac"];
                        newRow["Cân nặng"] = rowTC["canNang"];
                        newRow["Giống"] = rowTC["giongThuCung"];
                        newRow["Tiêu chuẩn cân nặng"] = rowTC.Table.Columns.Contains("tieuChuanCanNang") ? rowTC["tieuChuanCanNang"] : 0;
                        newRow["Ảnh thú cưng"] = rowTC.Table.Columns.Contains("anhThuCung") ? rowTC["anhThuCung"] : "";
                        newRow["Giá bán"] = rowTC["giaBan"];
                        newRow["ID Loại"] = rowTC["idLoai"];

                        // Tìm tên loại
                        int idLoai = Convert.ToInt32(rowTC["idLoai"]);
                        DataRow[] loaiRows = dtLoai.Select($"idLoai = {idLoai}");
                        if (loaiRows.Length > 0)
                        {
                            newRow["Tên loại"] = loaiRows[0]["tenLoai"];
                        }
                        else
                        {
                            newRow["Tên loại"] = "";
                        }

                        dt.Rows.Add(newRow);
                    }

                    dgvXML.DataSource = dt;
                    lblXML.Text = $"📄 Dữ liệu từ XML ({dt.Rows.Count} thú cưng)";
                }
                else if (ds.Tables.Contains("ThuCung"))
                {
                    // Fallback nếu không có bảng Loai
                    DataTable dt = ds.Tables["ThuCung"].Copy();
                    
                    if (dt.Columns.Contains("idThuCung")) dt.Columns["idThuCung"].ColumnName = "ID";
                    if (dt.Columns.Contains("tenThuCung")) dt.Columns["tenThuCung"].ColumnName = "Tên thú cưng";
                    if (dt.Columns.Contains("tuoi")) dt.Columns["tuoi"].ColumnName = "Tuổi";
                    if (dt.Columns.Contains("gioiTinh")) dt.Columns["gioiTinh"].ColumnName = "Giới tính";
                    if (dt.Columns.Contains("mauSac")) dt.Columns["mauSac"].ColumnName = "Màu sắc";
                    if (dt.Columns.Contains("canNang")) dt.Columns["canNang"].ColumnName = "Cân nặng";
                    if (dt.Columns.Contains("giongThuCung")) dt.Columns["giongThuCung"].ColumnName = "Giống";
                    if (dt.Columns.Contains("giaBan")) dt.Columns["giaBan"].ColumnName = "Giá bán";
                    if (dt.Columns.Contains("idLoai")) dt.Columns["idLoai"].ColumnName = "ID Loại";

                    dgvXML.DataSource = dt;
                    lblXML.Text = $"📄 Dữ liệu từ XML ({dt.Rows.Count} thú cưng)";
                }
                else
                {
                    MessageBox.Show("Không tìm thấy bảng ThuCung trong XML!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc XML: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSQLData()
        {
            try
            {
                string query = @"SELECT 
                    tc.Id AS 'ID',
                    tc.TenThuCung AS 'Tên thú cưng',
                    tc.Tuoi AS 'Tuổi',
                    tc.GioiTinh AS 'Giới tính',
                    tc.MauSac AS 'Màu sắc',
                    tc.CanNang AS 'Cân nặng',
                    tc.GiongThuCung AS 'Giống',
                    tc.TieuChuanCanNang AS 'Tiêu chuẩn cân nặng',
                    tc.AnhThuCung AS 'Ảnh thú cưng',
                    tc.GiaBan AS 'Giá bán',
                    tc.IdLoai AS 'ID Loại',
                    l.TenLoai AS 'Tên loại'
                FROM tbThuCung tc
                LEFT JOIN tbLoai l ON tc.IdLoai = l.Id
                ORDER BY tc.Id";

                DataTable dt = DatabaseHelper.DatabaseHelper.ExecuteQuery(query);
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvSQL.DataSource = dt;
                    lblSQL.Text = $"🗄️ Dữ liệu từ SQL Server ({dt.Rows.Count} thú cưng)";
                }
                else
                {
                    dgvSQL.DataSource = null;
                    lblSQL.Text = "🗄️ Dữ liệu từ SQL Server (0 thú cưng)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvSQL.DataSource = null;
                lblSQL.Text = "🗄️ Dữ liệu từ SQL Server (Lỗi kết nối)";
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            MessageBox.Show("Đã làm mới dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnConvertToXML_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn chuyển toàn bộ dữ liệu từ SQL Server sang file XML?\n\nDữ liệu XML cũ sẽ bị ghi đè!",
                "Xác nhận chuyển đổi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            try
            {
                Cursor = Cursors.WaitCursor;

                // Lấy toàn bộ dữ liệu từ SQL
                string query = "SELECT * FROM tbThuCung ORDER BY Id";
                DataTable dtSQL = DatabaseHelper.DatabaseHelper.ExecuteQuery(query);

                if (dtSQL == null || dtSQL.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu trong SQL để chuyển đổi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Đọc file XML hiện tại để giữ lại các bảng khác (Loai, NguoiDung, etc.)
                DataSet dsXML = new DataSet();
                if (File.Exists(XmlPath))
                {
                    dsXML.ReadXml(XmlPath);
                }

                // Xóa bảng ThuCung cũ nếu có
                if (dsXML.Tables.Contains("ThuCung"))
                {
                    dsXML.Tables.Remove("ThuCung");
                }

                // Lấy danh sách Loai để JOIN
                string queryLoai = "SELECT Id, TenLoai FROM tbLoai";
                DataTable dtLoai = DatabaseHelper.DatabaseHelper.ExecuteQuery(queryLoai);
                
                // Tạo bảng ThuCung mới với cấu trúc XML (bao gồm cả tenLoai)
                DataTable dtXMLNew = new DataTable("ThuCung");
                dtXMLNew.Columns.Add("idThuCung", typeof(int));
                dtXMLNew.Columns.Add("tenThuCung", typeof(string));
                dtXMLNew.Columns.Add("tuoi", typeof(int));
                dtXMLNew.Columns.Add("gioiTinh", typeof(string));
                dtXMLNew.Columns.Add("mauSac", typeof(string));
                dtXMLNew.Columns.Add("canNang", typeof(double));
                dtXMLNew.Columns.Add("giongThuCung", typeof(string));
                dtXMLNew.Columns.Add("tieuChuanCanNang", typeof(double));
                dtXMLNew.Columns.Add("anhThuCung", typeof(string));
                dtXMLNew.Columns.Add("giaBan", typeof(decimal));
                dtXMLNew.Columns.Add("idLoai", typeof(int));
                dtXMLNew.Columns.Add("tenLoai", typeof(string)); // Thêm cột tenLoai

                // Copy dữ liệu từ SQL sang XML
                foreach (DataRow sqlRow in dtSQL.Rows)
                {
                    DataRow xmlRow = dtXMLNew.NewRow();
                    xmlRow["idThuCung"] = sqlRow["Id"];
                    xmlRow["tenThuCung"] = sqlRow["TenThuCung"];
                    xmlRow["tuoi"] = sqlRow["Tuoi"];
                    xmlRow["gioiTinh"] = sqlRow["GioiTinh"];
                    xmlRow["mauSac"] = sqlRow["MauSac"];
                    xmlRow["canNang"] = sqlRow["CanNang"];
                    xmlRow["giongThuCung"] = sqlRow["GiongThuCung"];
                    xmlRow["tieuChuanCanNang"] = sqlRow["TieuChuanCanNang"];
                    xmlRow["anhThuCung"] = sqlRow["AnhThuCung"];
                    xmlRow["giaBan"] = sqlRow["GiaBan"];
                    xmlRow["idLoai"] = sqlRow["IdLoai"];
                    
                    // Tìm tên loại từ bảng Loai
                    if (dtLoai != null && dtLoai.Rows.Count > 0)
                    {
                        int idLoai = Convert.ToInt32(sqlRow["IdLoai"]);
                        DataRow[] loaiRows = dtLoai.Select($"Id = {idLoai}");
                        if (loaiRows.Length > 0)
                        {
                            xmlRow["tenLoai"] = loaiRows[0]["TenLoai"];
                        }
                        else
                        {
                            xmlRow["tenLoai"] = "Chưa xác định";
                        }
                    }
                    else
                    {
                        xmlRow["tenLoai"] = "Chưa xác định";
                    }
                    
                    dtXMLNew.Rows.Add(xmlRow);
                }

                // Thêm bảng ThuCung mới vào DataSet
                dsXML.Tables.Add(dtXMLNew);

                // Đặt tên DataSet để giữ cấu trúc XML giống file gốc
                if (string.IsNullOrEmpty(dsXML.DataSetName) || dsXML.DataSetName == "NewDataSet")
                {
                    dsXML.DataSetName = "PetShopData";
                }
                
                // Lưu lại file XML (không dùng WriteSchema để tránh thay đổi cấu trúc)
                dsXML.WriteXml(XmlPath);

                MessageBox.Show(
                    $"✅ Chuyển đổi thành công!\n\nĐã chuyển {dtSQL.Rows.Count} thú cưng từ SQL sang XML.",
                    "Hoàn tất",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Reload dữ liệu
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chuyển đổi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnAddSQL_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo form nhập liệu
                FormAddEditSQL formAdd = new FormAddEditSQL();
                if (formAdd.ShowDialog() == DialogResult.OK)
                {
                    LoadSQLData();
                    MessageBox.Show("Thêm thú cưng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditSQL_Click(object sender, EventArgs e)
        {
            if (dgvSQL.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một thú cưng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataGridViewRow row = dgvSQL.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["ID"].Value);

                // Sử dụng form FormAddEditSQL
                FormAddEditSQL formEdit = new FormAddEditSQL(id);
                if (formEdit.ShowDialog() == DialogResult.OK)
                {
                    LoadSQLData();
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnDeleteSQL_Click(object sender, EventArgs e)
        {
            if (dgvSQL.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một thú cưng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataGridViewRow row = dgvSQL.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["ID"].Value);
                string tenThuCung = row.Cells["Tên thú cưng"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa thú cưng '{tenThuCung}' không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Xóa các bản ghi liên quan trong tbChiTietHoaDon trước
                    string deleteChiTietQuery = "DELETE FROM tbChiTietHoaDon WHERE IdThuCung = @id";
                    System.Data.SqlClient.SqlParameter[] chiTietParams = {
                        new System.Data.SqlClient.SqlParameter("@id", id)
                    };
                    DatabaseHelper.DatabaseHelper.ExecuteNonQuery(deleteChiTietQuery, chiTietParams);

                    // Sau đó xóa thú cưng
                    string deleteQuery = "DELETE FROM tbThuCung WHERE Id = @id";
                    System.Data.SqlClient.SqlParameter[] parameters = {
                        new System.Data.SqlClient.SqlParameter("@id", id)
                    };

                    int deleteResult = DatabaseHelper.DatabaseHelper.ExecuteNonQuery(deleteQuery, parameters);
                    if (deleteResult > 0)
                    {
                        MessageBox.Show("Xóa thú cưng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSQLData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
