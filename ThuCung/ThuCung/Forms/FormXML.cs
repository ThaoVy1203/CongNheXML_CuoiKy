using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace ThuCung.Forms
{
    public partial class FormXML : Form
    {
        private static readonly string XmlPath =
    Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\data\ThuCung.xml"));
        private string currentXmlPath = "";
        private DataTable filteredData = null;

        public FormXML()
        {
            InitializeComponent();

            // Thêm event handlers
            btnLoadXml.Click += BtnLoadXml_Click;
            btnRefresh.Click += BtnRefresh_Click;
            btnClose.Click += BtnClose_Click;
            this.Load += FormXML_Load;
        }

        // Constructor nhận dữ liệu đã lọc từ FromMain
        public FormXML(DataTable filteredPets) : this()
        {
            filteredData = filteredPets;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Bo tròn góc các nút sau khi form load
            btnLoadXml.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnLoadXml.Width, btnLoadXml.Height, 10, 10));
            btnRefresh.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnRefresh.Width, btnRefresh.Height, 10, 10));
            btnClose.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnClose.Width, btnClose.Height, 10, 10));
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

        private void FormXML_Load(object sender, EventArgs e)
        {
            // Load dữ liệu từ XML
            LoadXmlFromFile();
        }

        private void LoadXmlFromFile()
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

                // Nếu có dữ liệu đã lọc, hiển thị dữ liệu đã lọc
                if (filteredData != null && filteredData.Rows.Count > 0)
                {
                    DataSet ds = new DataSet("PetManagement");
                    DataTable dt = filteredData.Copy();
                    dt.TableName = "ThuCung";
                    ds.Tables.Add(dt);

                    DisplayXmlFromDataSet(ds);
                }
                else
                {
                    // Nếu không, hiển thị toàn bộ XML
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(fullPath);

                    StringWriter sw = new StringWriter();
                    XmlTextWriter xmlWriter = new XmlTextWriter(sw);
                    xmlWriter.Formatting = Formatting.Indented;
                    xmlWriter.Indentation = 2;
                    xmlDoc.Save(xmlWriter);

                    txtXmlContent.Text = sw.ToString();
                }

                HighlightXmlSyntax();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load XML: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayXmlFromDataSet(DataSet ds)
        {
            try
            {
                // Chuyển DataSet thành XML string với format đẹp
                StringWriter sw = new StringWriter();
                XmlTextWriter xmlWriter = new XmlTextWriter(sw);
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.Indentation = 2;
                ds.WriteXml(xmlWriter);

                txtXmlContent.Text = sw.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chuyển đổi dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLoadXml_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog
            {
                Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*",
                Title = "Chọn file XML"
            };

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    currentXmlPath = openDialog.FileName;

                    // Đọc và format XML
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(currentXmlPath);

                    StringWriter sw = new StringWriter();
                    XmlTextWriter xmlWriter = new XmlTextWriter(sw);
                    xmlWriter.Formatting = Formatting.Indented;
                    xmlWriter.Indentation = 2;
                    xmlDoc.Save(xmlWriter);

                    txtXmlContent.Text = sw.ToString();
                    HighlightXmlSyntax();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đọc file XML: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentXmlPath) && File.Exists(currentXmlPath))
            {
                // Reload file XML đã chọn
                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(currentXmlPath);

                    StringWriter sw = new StringWriter();
                    XmlTextWriter xmlWriter = new XmlTextWriter(sw);
                    xmlWriter.Formatting = Formatting.Indented;
                    xmlWriter.Indentation = 2;
                    xmlDoc.Save(xmlWriter);

                    txtXmlContent.Text = sw.ToString();
                    HighlightXmlSyntax();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi làm mới: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Reload file XML mặc định
                LoadXmlFromFile();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HighlightXmlSyntax()
        {
            try
            {
                // Đơn giản hóa: chỉ đổi màu cho tags
                int startIndex = 0;

                while (startIndex < txtXmlContent.TextLength)
                {
                    int tagStart = txtXmlContent.Text.IndexOf('<', startIndex);
                    if (tagStart == -1) break;

                    int tagEnd = txtXmlContent.Text.IndexOf('>', tagStart);
                    if (tagEnd == -1) break;

                    txtXmlContent.Select(tagStart, tagEnd - tagStart + 1);
                    txtXmlContent.SelectionColor = Color.FromArgb(59, 130, 246); // Blue

                    startIndex = tagEnd + 1;
                }

                txtXmlContent.Select(0, 0);
            }
            catch
            {
                // Bỏ qua lỗi syntax highlighting
            }
        }
    }
}