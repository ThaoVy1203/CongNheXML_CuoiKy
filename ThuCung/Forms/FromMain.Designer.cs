namespace ThuCung.Forms
{
    partial class FromMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPets = new System.Windows.Forms.FlowLayoutPanel();
            this.panelSearchBorder = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnAddPet = new System.Windows.Forms.Button();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.cboLoaiThuCung = new System.Windows.Forms.ComboBox();
            this.btnMenuData = new System.Windows.Forms.Button();
            this.btnMenuHelp = new System.Windows.Forms.Button();
            this.btnMenuInvoice = new System.Windows.Forms.Button();
            this.btnMenuReports = new System.Windows.Forms.Button();
            this.btnMenuManage = new System.Windows.Forms.Button();
            this.btnMenuHome = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.menuItemViewXml = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExportXml = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuData = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemConvertSQL = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemConvertXML = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSystem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuReports = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemReportPets = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemReportRevenue = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelSearchBorder.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.contextMenuData.SuspendLayout();
            this.contextMenuSystem.SuspendLayout();
            this.contextMenuReports.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPets
            // 
            this.flowLayoutPets.AutoScroll = true;
            this.flowLayoutPets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.flowLayoutPets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPets.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPets.Name = "flowLayoutPets";
            this.flowLayoutPets.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.flowLayoutPets.Size = new System.Drawing.Size(1400, 742);
            this.flowLayoutPets.TabIndex = 7;
            this.flowLayoutPets.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPets_Paint);
            // 
            // panelSearchBorder
            // 
            this.panelSearchBorder.BackColor = System.Drawing.Color.White;
            this.panelSearchBorder.Controls.Add(this.txtSearch);
            this.panelSearchBorder.Location = new System.Drawing.Point(344, 55);
            this.panelSearchBorder.Name = "panelSearchBorder";
            this.panelSearchBorder.Padding = new System.Windows.Forms.Padding(2);
            this.panelSearchBorder.Size = new System.Drawing.Size(300, 40);
            this.panelSearchBorder.TabIndex = 5;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(5, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(280, 30);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.Text = "🔍 Tìm kiếm thú cưng...";
            // 
            // btnAddPet
            // 
            this.btnAddPet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnAddPet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddPet.FlatAppearance.BorderSize = 0;
            this.btnAddPet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPet.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddPet.ForeColor = System.Drawing.Color.White;
            this.btnAddPet.Location = new System.Drawing.Point(1092, 43);
            this.btnAddPet.Name = "btnAddPet";
            this.btnAddPet.Size = new System.Drawing.Size(271, 50);
            this.btnAddPet.TabIndex = 4;
            this.btnAddPet.Text = "➕ Thêm thú cưng";
            this.btnAddPet.UseVisualStyleBackColor = false;
            // 
            // panelFilter
            // 
            this.panelFilter.BackColor = System.Drawing.Color.White;
            this.panelFilter.Controls.Add(this.btnAddPet);
            this.panelFilter.Controls.Add(this.panelSearchBorder);
            this.panelFilter.Controls.Add(this.cboLoaiThuCung);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 0);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Padding = new System.Windows.Forms.Padding(30, 40, 30, 20);
            this.panelFilter.Size = new System.Drawing.Size(1400, 128);
            this.panelFilter.TabIndex = 6;
            // 
            // cboLoaiThuCung
            // 
            this.cboLoaiThuCung.BackColor = System.Drawing.Color.White;
            this.cboLoaiThuCung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiThuCung.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboLoaiThuCung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.cboLoaiThuCung.FormattingEnabled = true;
            this.cboLoaiThuCung.Location = new System.Drawing.Point(38, 55);
            this.cboLoaiThuCung.Name = "cboLoaiThuCung";
            this.cboLoaiThuCung.Size = new System.Drawing.Size(250, 38);
            this.cboLoaiThuCung.TabIndex = 0;
            // 
            // btnMenuData
            // 
            this.btnMenuData.BackColor = System.Drawing.Color.Transparent;
            this.btnMenuData.FlatAppearance.BorderSize = 0;
            this.btnMenuData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuData.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMenuData.ForeColor = System.Drawing.Color.White;
            this.btnMenuData.Location = new System.Drawing.Point(975, 0);
            this.btnMenuData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMenuData.Name = "btnMenuData";
            this.btnMenuData.Size = new System.Drawing.Size(270, 77);
            this.btnMenuData.TabIndex = 4;
            this.btnMenuData.Text = "Chuyển đổi dữ liệu ▼";
            this.btnMenuData.UseVisualStyleBackColor = false;
            // 
            // btnMenuHelp
            // 
            this.btnMenuHelp.BackColor = System.Drawing.Color.Transparent;
            this.btnMenuHelp.FlatAppearance.BorderSize = 0;
            this.btnMenuHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuHelp.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMenuHelp.ForeColor = System.Drawing.Color.White;
            this.btnMenuHelp.Location = new System.Drawing.Point(825, 0);
            this.btnMenuHelp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMenuHelp.Name = "btnMenuHelp";
            this.btnMenuHelp.Size = new System.Drawing.Size(150, 77);
            this.btnMenuHelp.TabIndex = 3;
            this.btnMenuHelp.Text = "Trợ giúp";
            this.btnMenuHelp.UseVisualStyleBackColor = false;
            // 
            // btnMenuInvoice
            // 
            this.btnMenuInvoice.BackColor = System.Drawing.Color.Transparent;
            this.btnMenuInvoice.FlatAppearance.BorderSize = 0;
            this.btnMenuInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuInvoice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMenuInvoice.ForeColor = System.Drawing.Color.White;
            this.btnMenuInvoice.Location = new System.Drawing.Point(675, 0);
            this.btnMenuInvoice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMenuInvoice.Name = "btnMenuInvoice";
            this.btnMenuInvoice.Size = new System.Drawing.Size(150, 77);
            this.btnMenuInvoice.TabIndex = 5;
            this.btnMenuInvoice.Text = "Xem hóa đơn";
            this.btnMenuInvoice.UseVisualStyleBackColor = false;
            this.btnMenuInvoice.Click += new System.EventHandler(this.btnMenuInvoice_Click);
            // 
            // btnMenuReports
            // 
            this.btnMenuReports.BackColor = System.Drawing.Color.Transparent;
            this.btnMenuReports.FlatAppearance.BorderSize = 0;
            this.btnMenuReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuReports.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMenuReports.ForeColor = System.Drawing.Color.White;
            this.btnMenuReports.Location = new System.Drawing.Point(450, 0);
            this.btnMenuReports.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMenuReports.Name = "btnMenuReports";
            this.btnMenuReports.Size = new System.Drawing.Size(225, 77);
            this.btnMenuReports.TabIndex = 2;
            this.btnMenuReports.Text = "Báo cáo thống kê ▼";
            this.btnMenuReports.UseVisualStyleBackColor = false;
            // 
            // btnMenuManage
            // 
            this.btnMenuManage.BackColor = System.Drawing.Color.Transparent;
            this.btnMenuManage.FlatAppearance.BorderSize = 0;
            this.btnMenuManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuManage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMenuManage.ForeColor = System.Drawing.Color.White;
            this.btnMenuManage.Location = new System.Drawing.Point(225, 0);
            this.btnMenuManage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMenuManage.Name = "btnMenuManage";
            this.btnMenuManage.Size = new System.Drawing.Size(225, 77);
            this.btnMenuManage.TabIndex = 1;
            this.btnMenuManage.Text = "Quản lý thú cưng";
            this.btnMenuManage.UseVisualStyleBackColor = false;
            this.btnMenuManage.Click += new System.EventHandler(this.btnMenuManage_Click);
            // 
            // btnMenuHome
            // 
            this.btnMenuHome.BackColor = System.Drawing.Color.Transparent;
            this.btnMenuHome.FlatAppearance.BorderSize = 0;
            this.btnMenuHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuHome.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMenuHome.ForeColor = System.Drawing.Color.White;
            this.btnMenuHome.Location = new System.Drawing.Point(45, 0);
            this.btnMenuHome.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMenuHome.Name = "btnMenuHome";
            this.btnMenuHome.Size = new System.Drawing.Size(180, 77);
            this.btnMenuHome.TabIndex = 0;
            this.btnMenuHome.Text = "Đăng xuất";
            this.btnMenuHome.UseVisualStyleBackColor = false;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.panelMenu.Controls.Add(this.btnMenuHome);
            this.panelMenu.Controls.Add(this.btnMenuManage);
            this.panelMenu.Controls.Add(this.btnMenuReports);
            this.panelMenu.Controls.Add(this.btnMenuInvoice);
            this.panelMenu.Controls.Add(this.btnMenuHelp);
            this.panelMenu.Controls.Add(this.btnMenuData);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 115);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1400, 77);
            this.panelMenu.TabIndex = 5;
            // 
            // menuItemViewXml
            // 
            this.menuItemViewXml.Name = "menuItemViewXml";
            this.menuItemViewXml.Size = new System.Drawing.Size(223, 32);
            this.menuItemViewXml.Text = "Xem XML";
            // 
            // menuItemExportXml
            // 
            this.menuItemExportXml.Name = "menuItemExportXml";
            this.menuItemExportXml.Size = new System.Drawing.Size(223, 32);
            this.menuItemExportXml.Text = "Xuất XML";
            // 
            // contextMenuData
            // 
            this.contextMenuData.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemViewXml,
            this.menuItemExportXml,
            this.menuItemConvertSQL,
            this.menuItemConvertXML});
            this.contextMenuData.Name = "contextMenuData";
            this.contextMenuData.Size = new System.Drawing.Size(224, 132);
            // 
            // menuItemConvertSQL
            // 
            this.menuItemConvertSQL.Name = "menuItemConvertSQL";
            this.menuItemConvertSQL.Size = new System.Drawing.Size(223, 32);
            this.menuItemConvertSQL.Text = "Chuyển sang SQL";
            this.menuItemConvertSQL.Click += new System.EventHandler(this.menuItemConvertSQL_Click);
            // 
            // menuItemConvertXML
            // 
            this.menuItemConvertXML.Name = "menuItemConvertXML";
            this.menuItemConvertXML.Size = new System.Drawing.Size(223, 32);
            this.menuItemConvertXML.Text = "Chuyển sang XML";
            this.menuItemConvertXML.Click += new System.EventHandler(this.menuItemConvertXML_Click);
            // 
            // menuItemLogout
            // 
            this.menuItemLogout.Name = "menuItemLogout";
            this.menuItemLogout.Size = new System.Drawing.Size(165, 32);
            this.menuItemLogout.Text = "Đăng xuất";
            // 
            // contextMenuSystem
            // 
            this.contextMenuSystem.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuSystem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemLogout});
            this.contextMenuSystem.Name = "contextMenuSystem";
            this.contextMenuSystem.Size = new System.Drawing.Size(166, 36);
            // 
            // contextMenuReports
            // 
            this.contextMenuReports.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuReports.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemReportPets,
            this.menuItemReportRevenue});
            this.contextMenuReports.Name = "contextMenuReports";
            this.contextMenuReports.Size = new System.Drawing.Size(235, 68);
            // 
            // menuItemReportPets
            // 
            this.menuItemReportPets.Name = "menuItemReportPets";
            this.menuItemReportPets.Size = new System.Drawing.Size(234, 32);
            this.menuItemReportPets.Text = "Báo cáo thú cưng";
            this.menuItemReportPets.Click += new System.EventHandler(this.menuItemReportPets_Click);
            // 
            // menuItemReportRevenue
            // 
            this.menuItemReportRevenue.Name = "menuItemReportRevenue";
            this.menuItemReportRevenue.Size = new System.Drawing.Size(234, 32);
            this.menuItemReportRevenue.Text = "Báo cáo doanh thu";
            this.menuItemReportRevenue.Click += new System.EventHandler(this.menuItemReportRevenue_Click);
            // 
            // menuItemSettings
            // 
            this.menuItemSettings.Name = "menuItemSettings";
            this.menuItemSettings.Size = new System.Drawing.Size(165, 32);
            this.menuItemSettings.Text = "Cài đặt";
            // 
            // lblUser
            // 
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUser.BackColor = System.Drawing.Color.Transparent;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.lblUser.Location = new System.Drawing.Point(1050, 40);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(320, 30);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "👤 Admin - Manager";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblSubtitle.Location = new System.Drawing.Point(62, 72);
            this.lblSubtitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(241, 45);
            this.lblSubtitle.TabIndex = 2;
            this.lblSubtitle.Text = "Pet Dashboard";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.lblTitle.Location = new System.Drawing.Point(146, 22);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(157, 48);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "PetFolio";
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.BackColor = System.Drawing.Color.Transparent;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI Emoji", 22F);
            this.lblLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblLogo.Location = new System.Drawing.Point(60, 14);
            this.lblLogo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(85, 58);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "🐾";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.lblLogo);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblSubtitle);
            this.panelHeader.Controls.Add(this.lblUser);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1400, 115);
            this.panelHeader.TabIndex = 4;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.panelFilter);
            this.panelContent.Controls.Add(this.flowLayoutPets);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 192);
            this.panelContent.Margin = new System.Windows.Forms.Padding(2);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1400, 742);
            this.panelContent.TabIndex = 0;
            // 
            // FromMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 934);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelHeader);
            this.MinimumSize = new System.Drawing.Size(1399, 897);
            this.Name = "FromMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Thú Cưng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelSearchBorder.ResumeLayout(false);
            this.panelSearchBorder.PerformLayout();
            this.panelFilter.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.contextMenuData.ResumeLayout(false);
            this.contextMenuSystem.ResumeLayout(false);
            this.contextMenuReports.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPets;
        private System.Windows.Forms.Panel panelSearchBorder;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAddPet;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.ComboBox cboLoaiThuCung;
        private System.Windows.Forms.Button btnMenuData;
        private System.Windows.Forms.Button btnMenuHelp;
        private System.Windows.Forms.Button btnMenuInvoice;
        private System.Windows.Forms.Button btnMenuReports;
        private System.Windows.Forms.Button btnMenuManage;
        private System.Windows.Forms.Button btnMenuHome;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemViewXml;
        private System.Windows.Forms.ToolStripMenuItem menuItemExportXml;
        private System.Windows.Forms.ContextMenuStrip contextMenuData;
        private System.Windows.Forms.ToolStripMenuItem menuItemLogout;
        private System.Windows.Forms.ContextMenuStrip contextMenuSystem;
        private System.Windows.Forms.ToolStripMenuItem menuItemSettings;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.ToolStripMenuItem menuItemConvertSQL;
        private System.Windows.Forms.ToolStripMenuItem menuItemConvertXML;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.ContextMenuStrip contextMenuReports;
        private System.Windows.Forms.ToolStripMenuItem menuItemReportPets;
        private System.Windows.Forms.ToolStripMenuItem menuItemReportRevenue;
    }
}