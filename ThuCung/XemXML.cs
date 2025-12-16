using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace ThuCung
{
    public partial class XemXML : UserControl
    {
        private static readonly string XmlPath =
            Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\data\ThuCung.xml"));
        private string currentXmlPath = "";
        private DataTable filteredData = null;

        public XemXML()
        {
            InitializeComponent();
            this.Load += XemXML_Load;
        }

        // Constructor nhận dữ liệu đã lọc
        public XemXML(DataTable filteredPets) : this()
        {
            filteredData = filteredPets;
        }

        private void XemXML_Load(object sender, EventArgs e)
        {
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
                LoadXmlFromFile();
            }
        }

        private void HighlightXmlSyntax()
        {
            try
            {
                int startIndex = 0;

                while (startIndex < txtXmlContent.TextLength)
                {
                    int tagStart = txtXmlContent.Text.IndexOf('<', startIndex);
                    if (tagStart == -1) break;

                    int tagEnd = txtXmlContent.Text.IndexOf('>', tagStart);
                    if (tagEnd == -1) break;

                    txtXmlContent.Select(tagStart, tagEnd - tagStart + 1);
                    txtXmlContent.SelectionColor = Color.FromArgb(59, 130, 246);

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
