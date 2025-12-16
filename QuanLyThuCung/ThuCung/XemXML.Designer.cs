namespace ThuCung
{
    partial class XemXML
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
            this.panelContent = new System.Windows.Forms.Panel();
            this.txtXmlContent = new System.Windows.Forms.RichTextBox();
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.btnLoadXml = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelContent.SuspendLayout();
            this.panelToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.panelContent.Controls.Add(this.txtXmlContent);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 70);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(30);
            this.panelContent.Size = new System.Drawing.Size(1400, 730);
            this.panelContent.TabIndex = 1;
            // 
            // txtXmlContent
            // 
            this.txtXmlContent.BackColor = System.Drawing.Color.White;
            this.txtXmlContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtXmlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtXmlContent.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtXmlContent.Location = new System.Drawing.Point(30, 30);
            this.txtXmlContent.Name = "txtXmlContent";
            this.txtXmlContent.ReadOnly = true;
            this.txtXmlContent.Size = new System.Drawing.Size(1340, 670);
            this.txtXmlContent.TabIndex = 0;
            this.txtXmlContent.Text = "";
            this.txtXmlContent.WordWrap = false;
            // 
            // panelToolbar
            // 
            this.panelToolbar.BackColor = System.Drawing.Color.White;
            this.panelToolbar.Controls.Add(this.btnLoadXml);
            this.panelToolbar.Controls.Add(this.btnRefresh);
            this.panelToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolbar.Location = new System.Drawing.Point(0, 0);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Padding = new System.Windows.Forms.Padding(30, 15, 30, 15);
            this.panelToolbar.Size = new System.Drawing.Size(1400, 70);
            this.panelToolbar.TabIndex = 0;
            // 
            // btnLoadXml
            // 
            this.btnLoadXml.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnLoadXml.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadXml.FlatAppearance.BorderSize = 0;
            this.btnLoadXml.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadXml.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLoadXml.ForeColor = System.Drawing.Color.White;
            this.btnLoadXml.Location = new System.Drawing.Point(38, 15);
            this.btnLoadXml.Name = "btnLoadXml";
            this.btnLoadXml.Size = new System.Drawing.Size(180, 40);
            this.btnLoadXml.TabIndex = 0;
            this.btnLoadXml.Text = "📂 Mở file XML";
            this.btnLoadXml.UseVisualStyleBackColor = false;
            this.btnLoadXml.Click += new System.EventHandler(this.BtnLoadXml_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(238, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(180, 40);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // XemXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelToolbar);
            this.Name = "XemXML";
            this.Size = new System.Drawing.Size(1400, 800);
            this.panelContent.ResumeLayout(false);
            this.panelToolbar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelToolbar;
        private System.Windows.Forms.Button btnLoadXml;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.RichTextBox txtXmlContent;
    }
}
