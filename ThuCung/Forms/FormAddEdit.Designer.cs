namespace ThuCung.Forms
{
    partial class FormAddEdit
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.picPetImage = new System.Windows.Forms.PictureBox();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.lblPetImage = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.lblTenThuCung = new System.Windows.Forms.Label();
            this.txtTenThuCung = new System.Windows.Forms.TextBox();
            this.lblTuoi = new System.Windows.Forms.Label();
            this.txtTuoi = new System.Windows.Forms.TextBox();
            this.lblGiongThuCung = new System.Windows.Forms.Label();
            this.txtGiongThuCung = new System.Windows.Forms.TextBox();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.lblMauSac = new System.Windows.Forms.Label();
            this.txtMauSac = new System.Windows.Forms.TextBox();
            this.lblCanNang = new System.Windows.Forms.Label();
            this.txtCanNang = new System.Windows.Forms.TextBox();
            this.lblTieuChuanCanNang = new System.Windows.Forms.Label();
            this.txtTieuChuanCanNang = new System.Windows.Forms.TextBox();
            this.lblGiaBan = new System.Windows.Forms.Label();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.lblLoaiThuCung = new System.Windows.Forms.Label();
            this.cboLoaiThuCung = new System.Windows.Forms.ComboBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPetImage)).BeginInit();
            this.panelRight.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblSubtitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(50, 35, 50, 35);
            this.panelHeader.Size = new System.Drawing.Size(1200, 130);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(50, 35);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(280, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thêm thú cưng";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.lblSubtitle.Location = new System.Drawing.Point(55, 90);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(310, 30);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Nhập thông tin thú cưng bên dưới";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.panelContent.Controls.Add(this.panelLeft);
            this.panelContent.Controls.Add(this.panelRight);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 130);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(50, 40, 50, 40);
            this.panelContent.Size = new System.Drawing.Size(1200, 620);
            this.panelContent.TabIndex = 1;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.White;
            this.panelLeft.Controls.Add(this.lblPetImage);
            this.panelLeft.Controls.Add(this.picPetImage);
            this.panelLeft.Controls.Add(this.btnBrowseImage);
            this.panelLeft.Location = new System.Drawing.Point(50, 40);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(35);
            this.panelLeft.Size = new System.Drawing.Size(380, 540);
            this.panelLeft.TabIndex = 0;
            // 
            // lblPetImage
            // 
            this.lblPetImage.AutoSize = true;
            this.lblPetImage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPetImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.lblPetImage.Location = new System.Drawing.Point(35, 35);
            this.lblPetImage.Name = "lblPetImage";
            this.lblPetImage.Size = new System.Drawing.Size(160, 32);
            this.lblPetImage.TabIndex = 0;
            this.lblPetImage.Text = "Hình ảnh thú cưng";
            // 
            // picPetImage
            // 
            this.picPetImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.picPetImage.Location = new System.Drawing.Point(35, 80);
            this.picPetImage.Name = "picPetImage";
            this.picPetImage.Size = new System.Drawing.Size(310, 310);
            this.picPetImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPetImage.TabIndex = 1;
            this.picPetImage.TabStop = false;
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.BackColor = System.Drawing.Color.White;
            this.btnBrowseImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseImage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnBrowseImage.FlatAppearance.BorderSize = 2;
            this.btnBrowseImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseImage.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBrowseImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnBrowseImage.Location = new System.Drawing.Point(35, 410);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(310, 50);
            this.btnBrowseImage.TabIndex = 2;
            this.btnBrowseImage.Text = "📁 Chọn hình ảnh";
            this.btnBrowseImage.UseVisualStyleBackColor = false;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.Controls.Add(this.lblTenThuCung);
            this.panelRight.Controls.Add(this.txtTenThuCung);
            this.panelRight.Controls.Add(this.lblTuoi);
            this.panelRight.Controls.Add(this.txtTuoi);
            this.panelRight.Controls.Add(this.lblGiongThuCung);
            this.panelRight.Controls.Add(this.txtGiongThuCung);
            this.panelRight.Controls.Add(this.lblGioiTinh);
            this.panelRight.Controls.Add(this.cboGioiTinh);
            this.panelRight.Controls.Add(this.lblMauSac);
            this.panelRight.Controls.Add(this.txtMauSac);
            this.panelRight.Controls.Add(this.lblCanNang);
            this.panelRight.Controls.Add(this.txtCanNang);
            this.panelRight.Controls.Add(this.lblTieuChuanCanNang);
            this.panelRight.Controls.Add(this.txtTieuChuanCanNang);
            this.panelRight.Controls.Add(this.lblGiaBan);
            this.panelRight.Controls.Add(this.txtGiaBan);
            this.panelRight.Controls.Add(this.lblLoaiThuCung);
            this.panelRight.Controls.Add(this.cboLoaiThuCung);
            this.panelRight.Location = new System.Drawing.Point(450, 40);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(35);
            this.panelRight.Size = new System.Drawing.Size(700, 540);
            this.panelRight.TabIndex = 1;
            // 
            // lblTenThuCung
            // 
            this.lblTenThuCung.AutoSize = true;
            this.lblTenThuCung.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTenThuCung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.lblTenThuCung.Location = new System.Drawing.Point(35, 35);
            this.lblTenThuCung.Name = "lblTenThuCung";
            this.lblTenThuCung.Size = new System.Drawing.Size(150, 30);
            this.lblTenThuCung.TabIndex = 0;
            this.lblTenThuCung.Text = "Tên thú cưng *";
            // 
            // txtTenThuCung
            // 
            this.txtTenThuCung.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTenThuCung.Location = new System.Drawing.Point(35, 68);
            this.txtTenThuCung.Name = "txtTenThuCung";
            this.txtTenThuCung.Size = new System.Drawing.Size(630, 32);
            this.txtTenThuCung.TabIndex = 1;
            // 
            // lblTuoi
            // 
            this.lblTuoi.AutoSize = true;
            this.lblTuoi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTuoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.lblTuoi.Location = new System.Drawing.Point(35, 118);
            this.lblTuoi.Name = "lblTuoi";
            this.lblTuoi.Size = new System.Drawing.Size(120, 30);
            this.lblTuoi.TabIndex = 2;
            this.lblTuoi.Text = "Tuổi (năm) *";
            // 
            // txtTuoi
            // 
            this.txtTuoi.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTuoi.Location = new System.Drawing.Point(35, 151);
            this.txtTuoi.Name = "txtTuoi";
            this.txtTuoi.Size = new System.Drawing.Size(300, 32);
            this.txtTuoi.TabIndex = 3;
            // 
            // lblGiongThuCung
            // 
            this.lblGiongThuCung.AutoSize = true;
            this.lblGiongThuCung.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblGiongThuCung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.lblGiongThuCung.Location = new System.Drawing.Point(355, 118);
            this.lblGiongThuCung.Name = "lblGiongThuCung";
            this.lblGiongThuCung.Size = new System.Drawing.Size(80, 30);
            this.lblGiongThuCung.TabIndex = 4;
            this.lblGiongThuCung.Text = "Giống";
            // 
            // txtGiongThuCung
            // 
            this.txtGiongThuCung.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtGiongThuCung.Location = new System.Drawing.Point(355, 151);
            this.txtGiongThuCung.Name = "txtGiongThuCung";
            this.txtGiongThuCung.Size = new System.Drawing.Size(310, 32);
            this.txtGiongThuCung.TabIndex = 5;
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblGioiTinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.lblGioiTinh.Location = new System.Drawing.Point(35, 201);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(110, 30);
            this.lblGioiTinh.TabIndex = 6;
            this.lblGioiTinh.Text = "Giới tính *";
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinh.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboGioiTinh.FormattingEnabled = true;
            this.cboGioiTinh.Items.AddRange(new object[] { "Đực", "Cái" });
            this.cboGioiTinh.Location = new System.Drawing.Point(35, 234);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(300, 38);
            this.cboGioiTinh.TabIndex = 7;
            // 
            // lblMauSac
            // 
            this.lblMauSac.AutoSize = true;
            this.lblMauSac.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMauSac.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.lblMauSac.Location = new System.Drawing.Point(355, 201);
            this.lblMauSac.Name = "lblMauSac";
            this.lblMauSac.Size = new System.Drawing.Size(100, 30);
            this.lblMauSac.TabIndex = 8;
            this.lblMauSac.Text = "Màu sắc";
            // 
            // txtMauSac
            // 
            this.txtMauSac.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMauSac.Location = new System.Drawing.Point(355, 234);
            this.txtMauSac.Name = "txtMauSac";
            this.txtMauSac.Size = new System.Drawing.Size(310, 32);
            this.txtMauSac.TabIndex = 9;
            // 
            // lblCanNang
            // 
            this.lblCanNang.AutoSize = true;
            this.lblCanNang.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCanNang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.lblCanNang.Location = new System.Drawing.Point(35, 284);
            this.lblCanNang.Name = "lblCanNang";
            this.lblCanNang.Size = new System.Drawing.Size(150, 30);
            this.lblCanNang.TabIndex = 10;
            this.lblCanNang.Text = "Cân nặng (kg) *";
            // 
            // txtCanNang
            // 
            this.txtCanNang.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtCanNang.Location = new System.Drawing.Point(35, 317);
            this.txtCanNang.Name = "txtCanNang";
            this.txtCanNang.Size = new System.Drawing.Size(300, 32);
            this.txtCanNang.TabIndex = 11;
            // 
            // lblTieuChuanCanNang
            // 
            this.lblTieuChuanCanNang.AutoSize = true;
            this.lblTieuChuanCanNang.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTieuChuanCanNang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.lblTieuChuanCanNang.Location = new System.Drawing.Point(355, 284);
            this.lblTieuChuanCanNang.Name = "lblTieuChuanCanNang";
            this.lblTieuChuanCanNang.Size = new System.Drawing.Size(200, 30);
            this.lblTieuChuanCanNang.TabIndex = 12;
            this.lblTieuChuanCanNang.Text = "Tiêu chuẩn CN (kg)";
            // 
            // txtTieuChuanCanNang
            // 
            this.txtTieuChuanCanNang.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTieuChuanCanNang.Location = new System.Drawing.Point(355, 317);
            this.txtTieuChuanCanNang.Name = "txtTieuChuanCanNang";
            this.txtTieuChuanCanNang.Size = new System.Drawing.Size(310, 32);
            this.txtTieuChuanCanNang.TabIndex = 13;
            // 
            // lblGiaBan
            // 
            this.lblGiaBan.AutoSize = true;
            this.lblGiaBan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblGiaBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.lblGiaBan.Location = new System.Drawing.Point(35, 367);
            this.lblGiaBan.Name = "lblGiaBan";
            this.lblGiaBan.Size = new System.Drawing.Size(150, 30);
            this.lblGiaBan.TabIndex = 14;
            this.lblGiaBan.Text = "Giá bán (VNĐ) *";
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtGiaBan.Location = new System.Drawing.Point(35, 400);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(300, 32);
            this.txtGiaBan.TabIndex = 15;
            // 
            // lblLoaiThuCung
            // 
            this.lblLoaiThuCung.AutoSize = true;
            this.lblLoaiThuCung.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblLoaiThuCung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.lblLoaiThuCung.Location = new System.Drawing.Point(355, 367);
            this.lblLoaiThuCung.Name = "lblLoaiThuCung";
            this.lblLoaiThuCung.Size = new System.Drawing.Size(160, 30);
            this.lblLoaiThuCung.TabIndex = 16;
            this.lblLoaiThuCung.Text = "Loại thú cưng *";
            // 
            // cboLoaiThuCung
            // 
            this.cboLoaiThuCung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiThuCung.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboLoaiThuCung.FormattingEnabled = true;
            this.cboLoaiThuCung.Location = new System.Drawing.Point(355, 400);
            this.cboLoaiThuCung.Name = "cboLoaiThuCung";
            this.cboLoaiThuCung.Size = new System.Drawing.Size(310, 38);
            this.cboLoaiThuCung.TabIndex = 17;
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.White;
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 750);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(50, 25, 50, 25);
            this.panelButtons.Size = new System.Drawing.Size(1200, 90);
            this.panelButtons.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnCancel.FlatAppearance.BorderSize = 2;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.btnCancel.Location = new System.Drawing.Point(880, 25);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 50);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(1040, 25);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 50);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "💾 Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // FormAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 840);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm/Sửa Thú Cưng";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPetImage)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label lblPetImage;
        private System.Windows.Forms.PictureBox picPetImage;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblTenThuCung;
        private System.Windows.Forms.TextBox txtTenThuCung;
        private System.Windows.Forms.Label lblTuoi;
        private System.Windows.Forms.TextBox txtTuoi;
        private System.Windows.Forms.Label lblGiongThuCung;
        private System.Windows.Forms.TextBox txtGiongThuCung;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.Label lblMauSac;
        private System.Windows.Forms.TextBox txtMauSac;
        private System.Windows.Forms.Label lblCanNang;
        private System.Windows.Forms.TextBox txtCanNang;
        private System.Windows.Forms.Label lblTieuChuanCanNang;
        private System.Windows.Forms.TextBox txtTieuChuanCanNang;
        private System.Windows.Forms.Label lblGiaBan;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.Label lblLoaiThuCung;
        private System.Windows.Forms.ComboBox cboLoaiThuCung;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}
