namespace ThuCung
{
    partial class BaoCaoThuCung
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelGenderChart = new System.Windows.Forms.Panel();
            this.lblGenderTitle = new System.Windows.Forms.Label();
            this.panelSpeciesChart = new System.Windows.Forms.Panel();
            this.lblSpeciesTitle = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelAgeChart = new System.Windows.Forms.Panel();
            this.lblAgeTitle = new System.Windows.Forms.Label();
            this.panelBreedChart = new System.Windows.Forms.Panel();
            this.lblBreedTitle = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.tableLayoutMain.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelAgeChart.SuspendLayout();
            this.panelBreedChart.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelGenderChart.SuspendLayout();
            this.panelSpeciesChart.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblSubtitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(67, 31, 67, 31);
            this.panelHeader.Size = new System.Drawing.Size(2133, 150);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.lblTitle.Location = new System.Drawing.Point(67, 14);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(574, 86);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Báo cáo Thú cưng";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitle.Location = new System.Drawing.Point(73, 100);
            this.lblSubtitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(558, 41);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Phân loại tất cả các động vật đã đăng ký.";
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.panelContent.Controls.Add(this.tableLayoutMain);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 150);
            this.panelContent.Margin = new System.Windows.Forms.Padding(4);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(53, 50, 53, 50);
            this.panelContent.Size = new System.Drawing.Size(2133, 1100);
            this.panelContent.TabIndex = 1;
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 2;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutMain.Controls.Add(this.panelLeft, 0, 0);
            this.tableLayoutMain.Controls.Add(this.panelRight, 1, 0);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutMain.Location = new System.Drawing.Point(53, 50);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 1;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1380F));
            this.tableLayoutMain.Size = new System.Drawing.Size(2027, 1380);
            this.tableLayoutMain.TabIndex = 0;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.panelAgeChart);
            this.panelRight.Controls.Add(this.panelBreedChart);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(612, 4);
            this.panelRight.Margin = new System.Windows.Forms.Padding(4);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(27, 0, 0, 0);
            this.panelRight.Size = new System.Drawing.Size(1411, 1372);
            this.panelRight.TabIndex = 1;
            // 
            // panelAgeChart
            // 
            this.panelAgeChart.BackColor = System.Drawing.Color.White;
            this.panelAgeChart.Controls.Add(this.lblAgeTitle);
            this.panelAgeChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAgeChart.Location = new System.Drawing.Point(27, 730);
            this.panelAgeChart.Margin = new System.Windows.Forms.Padding(4);
            this.panelAgeChart.Name = "panelAgeChart";
            this.panelAgeChart.Padding = new System.Windows.Forms.Padding(33, 31, 33, 50);
            this.panelAgeChart.Size = new System.Drawing.Size(1384, 600);
            this.panelAgeChart.TabIndex = 1;
            this.panelAgeChart.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelAgeChart_Paint);
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAgeTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblAgeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.lblAgeTitle.Location = new System.Drawing.Point(33, 31);
            this.lblAgeTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAgeTitle.Name = "lblAgeTitle";
            this.lblAgeTitle.Size = new System.Drawing.Size(1318, 44);
            this.lblAgeTitle.TabIndex = 0;
            this.lblAgeTitle.Text = "Phân bố tuổi";
            // 
            // panelBreedChart
            // 
            this.panelBreedChart.BackColor = System.Drawing.Color.White;
            this.panelBreedChart.Controls.Add(this.lblBreedTitle);
            this.panelBreedChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBreedChart.Location = new System.Drawing.Point(27, 0);
            this.panelBreedChart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 50);
            this.panelBreedChart.Name = "panelBreedChart";
            this.panelBreedChart.Padding = new System.Windows.Forms.Padding(33, 31, 33, 80);
            this.panelBreedChart.Size = new System.Drawing.Size(1384, 680);
            this.panelBreedChart.TabIndex = 0;
            this.panelBreedChart.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelBreedChart_Paint);
            // 
            // lblBreedTitle
            // 
            this.lblBreedTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBreedTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblBreedTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.lblBreedTitle.Location = new System.Drawing.Point(33, 31);
            this.lblBreedTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBreedTitle.Name = "lblBreedTitle";
            this.lblBreedTitle.Size = new System.Drawing.Size(1318, 44);
            this.lblBreedTitle.TabIndex = 0;
            this.lblBreedTitle.Text = "Phân loại giống";
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.panelGenderChart);
            this.panelLeft.Controls.Add(this.panelSpeciesChart);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(4, 4);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(4);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(600, 1372);
            this.panelLeft.TabIndex = 0;
            // 
            // panelGenderChart
            // 
            this.panelGenderChart.BackColor = System.Drawing.Color.White;
            this.panelGenderChart.Controls.Add(this.lblGenderTitle);
            this.panelGenderChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGenderChart.Location = new System.Drawing.Point(0, 730);
            this.panelGenderChart.Margin = new System.Windows.Forms.Padding(4);
            this.panelGenderChart.Name = "panelGenderChart";
            this.panelGenderChart.Padding = new System.Windows.Forms.Padding(33, 31, 33, 50);
            this.panelGenderChart.Size = new System.Drawing.Size(600, 600);
            this.panelGenderChart.TabIndex = 1;
            this.panelGenderChart.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelGenderChart_Paint);
            // 
            // lblGenderTitle
            // 
            this.lblGenderTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGenderTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblGenderTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.lblGenderTitle.Location = new System.Drawing.Point(33, 31);
            this.lblGenderTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGenderTitle.Name = "lblGenderTitle";
            this.lblGenderTitle.Size = new System.Drawing.Size(534, 44);
            this.lblGenderTitle.TabIndex = 0;
            this.lblGenderTitle.Text = "Phân bố giới tính";
            // 
            // panelSpeciesChart
            // 
            this.panelSpeciesChart.BackColor = System.Drawing.Color.White;
            this.panelSpeciesChart.Controls.Add(this.lblSpeciesTitle);
            this.panelSpeciesChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSpeciesChart.Location = new System.Drawing.Point(0, 0);
            this.panelSpeciesChart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 50);
            this.panelSpeciesChart.Name = "panelSpeciesChart";
            this.panelSpeciesChart.Padding = new System.Windows.Forms.Padding(33, 31, 33, 31);
            this.panelSpeciesChart.Size = new System.Drawing.Size(600, 680);
            this.panelSpeciesChart.TabIndex = 0;
            this.panelSpeciesChart.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelSpeciesChart_Paint);
            // 
            // lblSpeciesTitle
            // 
            this.lblSpeciesTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSpeciesTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblSpeciesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.lblSpeciesTitle.Location = new System.Drawing.Point(33, 31);
            this.lblSpeciesTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpeciesTitle.Name = "lblSpeciesTitle";
            this.lblSpeciesTitle.Size = new System.Drawing.Size(534, 44);
            this.lblSpeciesTitle.TabIndex = 0;
            this.lblSpeciesTitle.Text = "Tổng số thú cưng";
            // 
            // BaoCaoThuCung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BaoCaoThuCung";
            this.Size = new System.Drawing.Size(2133, 1250);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.tableLayoutMain.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelAgeChart.ResumeLayout(false);
            this.panelBreedChart.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.panelGenderChart.ResumeLayout(false);
            this.panelSpeciesChart.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelSpeciesChart;
        private System.Windows.Forms.Label lblSpeciesTitle;
        private System.Windows.Forms.Panel panelGenderChart;
        private System.Windows.Forms.Label lblGenderTitle;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelBreedChart;
        private System.Windows.Forms.Label lblBreedTitle;
        private System.Windows.Forms.Panel panelAgeChart;
        private System.Windows.Forms.Label lblAgeTitle;
    }
}