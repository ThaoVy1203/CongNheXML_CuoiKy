namespace ThuCung
{
    partial class BaoCaoDoanhThu
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelMonthlyChart = new System.Windows.Forms.Panel();
            this.lblMonthlyChartSubtitle = new System.Windows.Forms.Label();
            this.lblMonthlyChartTitle = new System.Windows.Forms.Label();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelPetTypeChart = new System.Windows.Forms.Panel();
            this.lblPetTypeChartSubtitle = new System.Windows.Forms.Label();
            this.lblPetTypeChartTitle = new System.Windows.Forms.Label();
            this.panelTotalRevenue = new System.Windows.Forms.Panel();
            this.lblGrowthRate = new System.Windows.Forms.Label();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.lblTotalRevenueSubtitle = new System.Windows.Forms.Label();
            this.lblTotalRevenueTitle = new System.Windows.Forms.Label();
            this.panelContent.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelMonthlyChart.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelPetTypeChart.SuspendLayout();
            this.panelTotalRevenue.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.panelContent.Controls.Add(this.panelRight);
            this.panelContent.Controls.Add(this.panelLeft);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(40);
            this.panelContent.Size = new System.Drawing.Size(1504, 800);
            this.panelContent.TabIndex = 0;
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContent_Paint);
            // 
            // panelRight
            // 
            this.panelRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRight.BackColor = System.Drawing.Color.Transparent;
            this.panelRight.Controls.Add(this.panelMonthlyChart);
            this.panelRight.Location = new System.Drawing.Point(480, 40);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(996, 730);
            this.panelRight.TabIndex = 1;
            // 
            // panelMonthlyChart
            // 
            this.panelMonthlyChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMonthlyChart.BackColor = System.Drawing.Color.White;
            this.panelMonthlyChart.Controls.Add(this.lblMonthlyChartSubtitle);
            this.panelMonthlyChart.Controls.Add(this.lblMonthlyChartTitle);
            this.panelMonthlyChart.Location = new System.Drawing.Point(0, 0);
            this.panelMonthlyChart.Name = "panelMonthlyChart";
            this.panelMonthlyChart.Padding = new System.Windows.Forms.Padding(40, 35, 40, 35);
            this.panelMonthlyChart.Size = new System.Drawing.Size(993, 727);
            this.panelMonthlyChart.TabIndex = 0;
            this.panelMonthlyChart.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMonthlyChart_Paint_1);
            // 
            // lblMonthlyChartSubtitle
            // 
            this.lblMonthlyChartSubtitle.AutoSize = true;
            this.lblMonthlyChartSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMonthlyChartSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblMonthlyChartSubtitle.Location = new System.Drawing.Point(40, 75);
            this.lblMonthlyChartSubtitle.Name = "lblMonthlyChartSubtitle";
            this.lblMonthlyChartSubtitle.Size = new System.Drawing.Size(379, 28);
            this.lblMonthlyChartSubtitle.TabIndex = 1;
            this.lblMonthlyChartSubtitle.Text = "Biểu đồ doanh thu hàng tháng trong năm.";
            // 
            // lblMonthlyChartTitle
            // 
            this.lblMonthlyChartTitle.AutoSize = true;
            this.lblMonthlyChartTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblMonthlyChartTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblMonthlyChartTitle.Location = new System.Drawing.Point(40, 35);
            this.lblMonthlyChartTitle.Name = "lblMonthlyChartTitle";
            this.lblMonthlyChartTitle.Size = new System.Drawing.Size(270, 36);
            this.lblMonthlyChartTitle.TabIndex = 0;
            this.lblMonthlyChartTitle.Text = "Xu hướng doanh thu";
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.Transparent;
            this.panelLeft.Controls.Add(this.panelPetTypeChart);
            this.panelLeft.Controls.Add(this.panelTotalRevenue);
            this.panelLeft.Location = new System.Drawing.Point(40, 40);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(420, 783);
            this.panelLeft.TabIndex = 0;
            // 
            // panelPetTypeChart
            // 
            this.panelPetTypeChart.BackColor = System.Drawing.Color.White;
            this.panelPetTypeChart.Controls.Add(this.lblPetTypeChartSubtitle);
            this.panelPetTypeChart.Controls.Add(this.lblPetTypeChartTitle);
            this.panelPetTypeChart.Location = new System.Drawing.Point(0, 240);
            this.panelPetTypeChart.Name = "panelPetTypeChart";
            this.panelPetTypeChart.Padding = new System.Windows.Forms.Padding(30);
            this.panelPetTypeChart.Size = new System.Drawing.Size(420, 540);
            this.panelPetTypeChart.TabIndex = 1;
            // 
            // lblPetTypeChartSubtitle
            // 
            this.lblPetTypeChartSubtitle.AutoSize = true;
            this.lblPetTypeChartSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPetTypeChartSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblPetTypeChartSubtitle.Location = new System.Drawing.Point(-1, 78);
            this.lblPetTypeChartSubtitle.Name = "lblPetTypeChartSubtitle";
            this.lblPetTypeChartSubtitle.Size = new System.Drawing.Size(406, 28);
            this.lblPetTypeChartSubtitle.TabIndex = 1;
            this.lblPetTypeChartSubtitle.Text = "Phân chia doanh thu theo từng loại thú cưng.";
            // 
            // lblPetTypeChartTitle
            // 
            this.lblPetTypeChartTitle.AutoSize = true;
            this.lblPetTypeChartTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblPetTypeChartTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblPetTypeChartTitle.Location = new System.Drawing.Point(20, 30);
            this.lblPetTypeChartTitle.Name = "lblPetTypeChartTitle";
            this.lblPetTypeChartTitle.Size = new System.Drawing.Size(376, 36);
            this.lblPetTypeChartTitle.TabIndex = 0;
            this.lblPetTypeChartTitle.Text = "Doanh thu theo loại thú cưng";
            // 
            // panelTotalRevenue
            // 
            this.panelTotalRevenue.BackColor = System.Drawing.Color.White;
            this.panelTotalRevenue.Controls.Add(this.lblGrowthRate);
            this.panelTotalRevenue.Controls.Add(this.lblTotalRevenue);
            this.panelTotalRevenue.Controls.Add(this.lblTotalRevenueSubtitle);
            this.panelTotalRevenue.Controls.Add(this.lblTotalRevenueTitle);
            this.panelTotalRevenue.Location = new System.Drawing.Point(0, 0);
            this.panelTotalRevenue.Name = "panelTotalRevenue";
            this.panelTotalRevenue.Padding = new System.Windows.Forms.Padding(30);
            this.panelTotalRevenue.Size = new System.Drawing.Size(420, 220);
            this.panelTotalRevenue.TabIndex = 0;
            // 
            // lblGrowthRate
            // 
            this.lblGrowthRate.AutoSize = true;
            this.lblGrowthRate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGrowthRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.lblGrowthRate.Location = new System.Drawing.Point(30, 180);
            this.lblGrowthRate.Name = "lblGrowthRate";
            this.lblGrowthRate.Size = new System.Drawing.Size(263, 28);
            this.lblGrowthRate.TabIndex = 3;
            this.lblGrowthRate.Text = "📈 +12.5% so với năm trước";
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.AutoSize = true;
            this.lblTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTotalRevenue.Location = new System.Drawing.Point(25, 110);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(93, 70);
            this.lblTotalRevenue.TabIndex = 2;
            this.lblTotalRevenue.Text = "0đ";
            // 
            // lblTotalRevenueSubtitle
            // 
            this.lblTotalRevenueSubtitle.AutoSize = true;
            this.lblTotalRevenueSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalRevenueSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalRevenueSubtitle.Location = new System.Drawing.Point(30, 70);
            this.lblTotalRevenueSubtitle.Name = "lblTotalRevenueSubtitle";
            this.lblTotalRevenueSubtitle.Size = new System.Drawing.Size(241, 28);
            this.lblTotalRevenueSubtitle.TabIndex = 1;
            this.lblTotalRevenueSubtitle.Text = "Doanh thu trong năm nay.";
            // 
            // lblTotalRevenueTitle
            // 
            this.lblTotalRevenueTitle.AutoSize = true;
            this.lblTotalRevenueTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenueTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTotalRevenueTitle.Location = new System.Drawing.Point(30, 30);
            this.lblTotalRevenueTitle.Name = "lblTotalRevenueTitle";
            this.lblTotalRevenueTitle.Size = new System.Drawing.Size(212, 36);
            this.lblTotalRevenueTitle.TabIndex = 0;
            this.lblTotalRevenueTitle.Text = "Tổng doanh thu";
            // 
            // BaoCaoDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelContent);
            this.Name = "BaoCaoDoanhThu";
            this.Size = new System.Drawing.Size(1504, 800);
            this.panelContent.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelMonthlyChart.ResumeLayout(false);
            this.panelMonthlyChart.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelPetTypeChart.ResumeLayout(false);
            this.panelPetTypeChart.PerformLayout();
            this.panelTotalRevenue.ResumeLayout(false);
            this.panelTotalRevenue.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTotalRevenue;
        private System.Windows.Forms.Label lblTotalRevenueTitle;
        private System.Windows.Forms.Label lblTotalRevenueSubtitle;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label lblGrowthRate;
        private System.Windows.Forms.Panel panelPetTypeChart;
        private System.Windows.Forms.Label lblPetTypeChartTitle;
        private System.Windows.Forms.Label lblPetTypeChartSubtitle;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelMonthlyChart;
        private System.Windows.Forms.Label lblMonthlyChartTitle;
        private System.Windows.Forms.Label lblMonthlyChartSubtitle;
    }
}
