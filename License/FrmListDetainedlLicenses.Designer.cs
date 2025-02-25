namespace DVLD.License
{
    partial class FrmListDetainedlLicenses
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
            this.lblNumberOfDetainedLicenses = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilterBy = new System.Windows.Forms.TextBox();
            this.dgvListDetainedLicenses = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.cmsDetainedLicenses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReleaseLicense = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDetainLicense = new System.Windows.Forms.Button();
            this.ShowPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowLicenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseDetainedLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListDetainedLicenses)).BeginInit();
            this.cmsDetainedLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumberOfDetainedLicenses
            // 
            this.lblNumberOfDetainedLicenses.AutoSize = true;
            this.lblNumberOfDetainedLicenses.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfDetainedLicenses.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNumberOfDetainedLicenses.Location = new System.Drawing.Point(103, 560);
            this.lblNumberOfDetainedLicenses.Name = "lblNumberOfDetainedLicenses";
            this.lblNumberOfDetainedLicenses.Size = new System.Drawing.Size(144, 21);
            this.lblNumberOfDetainedLicenses.TabIndex = 38;
            this.lblNumberOfDetainedLicenses.Text = "NumberOfRecords:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(13, 560);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 21);
            this.label3.TabIndex = 37;
            this.label3.Text = "#Records:";
            // 
            // txtFilterBy
            // 
            this.txtFilterBy.Location = new System.Drawing.Point(289, 277);
            this.txtFilterBy.Name = "txtFilterBy";
            this.txtFilterBy.Size = new System.Drawing.Size(121, 20);
            this.txtFilterBy.TabIndex = 36;
            this.txtFilterBy.Visible = false;
            this.txtFilterBy.TextChanged += new System.EventHandler(this.txtFilterBy_TextChanged);
            this.txtFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterBy_KeyPress);
            // 
            // dgvListDetainedLicenses
            // 
            this.dgvListDetainedLicenses.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvListDetainedLicenses.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvListDetainedLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListDetainedLicenses.ContextMenuStrip = this.cmsDetainedLicenses;
            this.dgvListDetainedLicenses.GridColor = System.Drawing.Color.White;
            this.dgvListDetainedLicenses.Location = new System.Drawing.Point(12, 313);
            this.dgvListDetainedLicenses.Name = "dgvListDetainedLicenses";
            this.dgvListDetainedLicenses.ReadOnly = true;
            this.dgvListDetainedLicenses.Size = new System.Drawing.Size(1017, 228);
            this.dgvListDetainedLicenses.TabIndex = 35;
            this.dgvListDetainedLicenses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListDetainedLicenses_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(58, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 21);
            this.label2.TabIndex = 34;
            this.label2.Text = "Filter By:";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Detain ID",
            "Is Released",
            "National No",
            "Full Name ",
            "Released Application ID",
            "",
            ""});
            this.cbFilterBy.Location = new System.Drawing.Point(139, 278);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(121, 21);
            this.cbFilterBy.TabIndex = 33;
            this.cbFilterBy.Text = "None";
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // cmsDetainedLicenses
            // 
            this.cmsDetainedLicenses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.ShowPersonDetailsToolStripMenuItem,
            this.ShowLicenseDetailsToolStripMenuItem,
            this.ShowPersonLicenseHistoryToolStripMenuItem,
            this.releaseDetainedLicenseToolStripMenuItem});
            this.cmsDetainedLicenses.Name = "cmsLocalDrivingLicenseApplication";
            this.cmsDetainedLicenses.Size = new System.Drawing.Size(260, 234);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(256, 6);
            // 
            // btnReleaseLicense
            // 
            this.btnReleaseLicense.AutoSize = true;
            this.btnReleaseLicense.Image = global::DVLD.Properties.Resources.Hand_Side_View_Skin_Type_31;
            this.btnReleaseLicense.Location = new System.Drawing.Point(888, 243);
            this.btnReleaseLicense.Name = "btnReleaseLicense";
            this.btnReleaseLicense.Size = new System.Drawing.Size(56, 56);
            this.btnReleaseLicense.TabIndex = 41;
            this.btnReleaseLicense.UseVisualStyleBackColor = true;
            this.btnReleaseLicense.Click += new System.EventHandler(this.btnReleaseLicense_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD.Properties.Resources.Close2__1_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(940, 551);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 39);
            this.btnClose.TabIndex = 40;
            this.btnClose.Text = "       Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDetainLicense
            // 
            this.btnDetainLicense.AutoSize = true;
            this.btnDetainLicense.Image = global::DVLD.Properties.Resources.Hand__1___1_;
            this.btnDetainLicense.Location = new System.Drawing.Point(972, 243);
            this.btnDetainLicense.Name = "btnDetainLicense";
            this.btnDetainLicense.Size = new System.Drawing.Size(57, 56);
            this.btnDetainLicense.TabIndex = 39;
            this.btnDetainLicense.UseVisualStyleBackColor = true;
            this.btnDetainLicense.Click += new System.EventHandler(this.btnDetainLicense_Click);
            // 
            // ShowPersonDetailsToolStripMenuItem
            // 
            this.ShowPersonDetailsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowPersonDetailsToolStripMenuItem.Image = global::DVLD.Properties.Resources.Bullet_List__1_1;
            this.ShowPersonDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowPersonDetailsToolStripMenuItem.Name = "ShowPersonDetailsToolStripMenuItem";
            this.ShowPersonDetailsToolStripMenuItem.Size = new System.Drawing.Size(259, 56);
            this.ShowPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            this.ShowPersonDetailsToolStripMenuItem.Click += new System.EventHandler(this.ShowPersonDetailsToolStripMenuItem_Click);
            // 
            // ShowLicenseDetailsToolStripMenuItem
            // 
            this.ShowLicenseDetailsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ShowLicenseDetailsToolStripMenuItem.Image = global::DVLD.Properties.Resources.Driver_License12;
            this.ShowLicenseDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowLicenseDetailsToolStripMenuItem.Name = "ShowLicenseDetailsToolStripMenuItem";
            this.ShowLicenseDetailsToolStripMenuItem.Size = new System.Drawing.Size(259, 56);
            this.ShowLicenseDetailsToolStripMenuItem.Text = "Show License Details";
            this.ShowLicenseDetailsToolStripMenuItem.Click += new System.EventHandler(this.ShowLicenseDetailsToolStripMenuItem_Click);
            // 
            // ShowPersonLicenseHistoryToolStripMenuItem
            // 
            this.ShowPersonLicenseHistoryToolStripMenuItem.Image = global::DVLD.Properties.Resources.Driver_1_1;
            this.ShowPersonLicenseHistoryToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowPersonLicenseHistoryToolStripMenuItem.Name = "ShowPersonLicenseHistoryToolStripMenuItem";
            this.ShowPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(259, 56);
            this.ShowPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.ShowPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.ShowPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // releaseDetainedLicenseToolStripMenuItem
            // 
            this.releaseDetainedLicenseToolStripMenuItem.Enabled = false;
            this.releaseDetainedLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.Hand_Side_View_Skin_Type_3;
            this.releaseDetainedLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.releaseDetainedLicenseToolStripMenuItem.Name = "releaseDetainedLicenseToolStripMenuItem";
            this.releaseDetainedLicenseToolStripMenuItem.Size = new System.Drawing.Size(259, 56);
            this.releaseDetainedLicenseToolStripMenuItem.Text = "Release Detained License";
            this.releaseDetainedLicenseToolStripMenuItem.Click += new System.EventHandler(this.releaseDetainedLicenseToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Hand__1_;
            this.pictureBox1.Location = new System.Drawing.Point(419, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(195, 199);
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(400, 208);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(264, 31);
            this.label9.TabIndex = 128;
            this.label9.Text = "List Detained Licenses";
            // 
            // FrmListDetainedlLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 599);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnReleaseLicense);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDetainLicense);
            this.Controls.Add(this.lblNumberOfDetainedLicenses);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFilterBy);
            this.Controls.Add(this.dgvListDetainedLicenses);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FrmListDetainedlLicenses";
            this.Text = "List Detained Licenses";
            this.Load += new System.EventHandler(this.FrmListDetainedlLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListDetainedLicenses)).EndInit();
            this.cmsDetainedLicenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDetainLicense;
        private System.Windows.Forms.Label lblNumberOfDetainedLicenses;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFilterBy;
        private System.Windows.Forms.DataGridView dgvListDetainedLicenses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip cmsDetainedLicenses;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ShowPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowLicenseDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainedLicenseToolStripMenuItem;
        private System.Windows.Forms.Button btnReleaseLicense;
        private System.Windows.Forms.Label label9;
    }
}