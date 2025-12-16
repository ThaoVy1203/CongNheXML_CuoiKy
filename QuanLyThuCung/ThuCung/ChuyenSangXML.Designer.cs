namespace ThuCung
{
    partial class ChuyenSangXML
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelXML = new System.Windows.Forms.Panel();
            this.dgvXML = new System.Windows.Forms.DataGridView();
            this.lblXML = new System.Windows.Forms.Label();
            this.panelSQL = new System.Windows.Forms.Panel();
            this.btnDeleteSQL = new System.Windows.Forms.Button();
            this.btnEditSQL = new System.Windows.Forms.Button();
            this.btnAddSQL = new System.Windows.Forms.Button();
            this.btnConvertToXML = new System.Windows.Forms.Button();
            this.dgvSQL = new System.Windows.Forms.DataGridView();
            this.lblSQL = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelXML.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXML)).BeginInit();
            this.panelSQL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSQL)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.lblTitle.Size = new System.Drawing.Size(1850, 70);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🔄 So sánh dữ liệu XML và SQL";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelXML
            // 
            this.panelXML.BackColor = System.Drawing.Color.White;
            this.panelXML.Controls.Add(this.dgvXML);
            this.panelXML.Controls.Add(this.lblXML);
            this.panelXML.Location = new System.Drawing.Point(45, 85);
            this.panelXML.Name = "panelXML";
            this.panelXML.Padding = new System.Windows.Forms.Padding(15);
            this.panelXML.Size = new System.Drawing.Size(1802, 404);
            this.panelXML.TabIndex = 1;
            // 
            // dgvXML
            // 
            this.dgvXML.AllowUserToAddRows = false;
            this.dgvXML.AllowUserToDeleteRows = false;
            this.dgvXML.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvXML.BackgroundColor = System.Drawing.Color.White;
            this.dgvXML.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvXML.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvXML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvXML.Location = new System.Drawing.Point(15, 69);
            this.dgvXML.Name = "dgvXML";
            this.dgvXML.ReadOnly = true;
            this.dgvXML.RowHeadersWidth = 62;
            this.dgvXML.RowTemplate.Height = 28;
            this.dgvXML.Size = new System.Drawing.Size(1772, 320);
            this.dgvXML.TabIndex = 1;
            // 
            // lblXML
            // 
            this.lblXML.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.lblXML.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblXML.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblXML.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.lblXML.Location = new System.Drawing.Point(15, 15);
            this.lblXML.Name = "lblXML";
            this.lblXML.Padding = new System.Windows.Forms.Padding(10);
            this.lblXML.Size = new System.Drawing.Size(1772, 54);
            this.lblXML.TabIndex = 0;
            this.lblXML.Text = "📄 Dữ liệu từ XML";
            // 
            // panelSQL
            // 
            this.panelSQL.BackColor = System.Drawing.Color.White;
            this.panelSQL.Controls.Add(this.btnDeleteSQL);
            this.panelSQL.Controls.Add(this.btnEditSQL);
            this.panelSQL.Controls.Add(this.btnAddSQL);
            this.panelSQL.Controls.Add(this.btnConvertToXML);
            this.panelSQL.Controls.Add(this.dgvSQL);
            this.panelSQL.Controls.Add(this.lblSQL);
            this.panelSQL.Location = new System.Drawing.Point(45, 495);
            this.panelSQL.Name = "panelSQL";
            this.panelSQL.Padding = new System.Windows.Forms.Padding(15);
            this.panelSQL.Size = new System.Drawing.Size(1802, 372);
            this.panelSQL.TabIndex = 2;
            // 
            // btnDeleteSQL
            // 
            this.btnDeleteSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteSQL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnDeleteSQL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteSQL.FlatAppearance.BorderSize = 0;
            this.btnDeleteSQL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSQL.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeleteSQL.ForeColor = System.Drawing.Color.White;
            this.btnDeleteSQL.Location = new System.Drawing.Point(1670, 20);
            this.btnDeleteSQL.Name = "btnDeleteSQL";
            this.btnDeleteSQL.Size = new System.Drawing.Size(110, 40);
            this.btnDeleteSQL.TabIndex = 4;
            this.btnDeleteSQL.Text = "🗑 Xóa";
            this.btnDeleteSQL.UseVisualStyleBackColor = false;
            this.btnDeleteSQL.Click += new System.EventHandler(this.btnDeleteSQL_Click);
            // 
            // btnEditSQL
            // 
            this.btnEditSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditSQL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnEditSQL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditSQL.FlatAppearance.BorderSize = 0;
            this.btnEditSQL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditSQL.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditSQL.ForeColor = System.Drawing.Color.White;
            this.btnEditSQL.Location = new System.Drawing.Point(1545, 20);
            this.btnEditSQL.Name = "btnEditSQL";
            this.btnEditSQL.Size = new System.Drawing.Size(110, 40);
            this.btnEditSQL.TabIndex = 3;
            this.btnEditSQL.Text = "✏ Sửa";
            this.btnEditSQL.UseVisualStyleBackColor = false;
            this.btnEditSQL.Click += new System.EventHandler(this.btnEditSQL_Click);
            // 
            // btnAddSQL
            // 
            this.btnAddSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSQL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnAddSQL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddSQL.FlatAppearance.BorderSize = 0;
            this.btnAddSQL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSQL.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddSQL.ForeColor = System.Drawing.Color.White;
            this.btnAddSQL.Location = new System.Drawing.Point(1419, 20);
            this.btnAddSQL.Name = "btnAddSQL";
            this.btnAddSQL.Size = new System.Drawing.Size(110, 40);
            this.btnAddSQL.TabIndex = 5;
            this.btnAddSQL.Text = "➕ Thêm";
            this.btnAddSQL.UseVisualStyleBackColor = false;
            this.btnAddSQL.Click += new System.EventHandler(this.btnAddSQL_Click);
            // 
            // btnConvertToXML
            // 
            this.btnConvertToXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvertToXML.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(85)))), ((int)(((byte)(247)))));
            this.btnConvertToXML.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConvertToXML.FlatAppearance.BorderSize = 0;
            this.btnConvertToXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvertToXML.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnConvertToXML.ForeColor = System.Drawing.Color.White;
            this.btnConvertToXML.Location = new System.Drawing.Point(1234, 21);
            this.btnConvertToXML.Name = "btnConvertToXML";
            this.btnConvertToXML.Size = new System.Drawing.Size(170, 40);
            this.btnConvertToXML.TabIndex = 2;
            this.btnConvertToXML.Text = "🔄 Chuyển sang XML";
            this.btnConvertToXML.UseVisualStyleBackColor = false;
            this.btnConvertToXML.Click += new System.EventHandler(this.btnConvertToXML_Click);
            // 
            // dgvSQL
            // 
            this.dgvSQL.AllowUserToAddRows = false;
            this.dgvSQL.AllowUserToDeleteRows = false;
            this.dgvSQL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSQL.BackgroundColor = System.Drawing.Color.White;
            this.dgvSQL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSQL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSQL.Location = new System.Drawing.Point(15, 74);
            this.dgvSQL.Name = "dgvSQL";
            this.dgvSQL.ReadOnly = true;
            this.dgvSQL.RowHeadersWidth = 62;
            this.dgvSQL.RowTemplate.Height = 28;
            this.dgvSQL.Size = new System.Drawing.Size(1772, 283);
            this.dgvSQL.TabIndex = 1;
            // 
            // lblSQL
            // 
            this.lblSQL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.lblSQL.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSQL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSQL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.lblSQL.Location = new System.Drawing.Point(15, 15);
            this.lblSQL.Name = "lblSQL";
            this.lblSQL.Padding = new System.Windows.Forms.Padding(10);
            this.lblSQL.Size = new System.Drawing.Size(1772, 59);
            this.lblSQL.TabIndex = 0;
            this.lblSQL.Text = "🗄️ Dữ liệu từ SQL Server";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1677, 873);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(170, 45);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ChuyenSangXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.panelSQL);
            this.Controls.Add(this.panelXML);
            this.Controls.Add(this.lblTitle);
            this.Name = "ChuyenSangXML";
            this.Size = new System.Drawing.Size(1850, 946);
            this.panelXML.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvXML)).EndInit();
            this.panelSQL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSQL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelXML;
        private System.Windows.Forms.DataGridView dgvXML;
        private System.Windows.Forms.Label lblXML;
        private System.Windows.Forms.Panel panelSQL;
        private System.Windows.Forms.DataGridView dgvSQL;
        private System.Windows.Forms.Label lblSQL;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnConvertToXML;
        private System.Windows.Forms.Button btnAddSQL;
        private System.Windows.Forms.Button btnEditSQL;
        private System.Windows.Forms.Button btnDeleteSQL;
    }
}
