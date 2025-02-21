namespace DVLD.Applications
{
    partial class FrmInternationalDrivingLicenseApplications
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
            this.lblNumberOfInternationalDrivingLicenseApplications = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilterBy = new System.Windows.Forms.TextBox();
            this.dgvInternationalDrivingLicenseApplications = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmsInternationalDrivingLicenseApplication = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNewApplication = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ShowPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowLicenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalDrivingLicenseApplications)).BeginInit();
            this.cmsInternationalDrivingLicenseApplication.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumberOfInternationalDrivingLicenseApplications
            // 
            this.lblNumberOfInternationalDrivingLicenseApplications.AutoSize = true;
            this.lblNumberOfInternationalDrivingLicenseApplications.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfInternationalDrivingLicenseApplications.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNumberOfInternationalDrivingLicenseApplications.Location = new System.Drawing.Point(101, 550);
            this.lblNumberOfInternationalDrivingLicenseApplications.Name = "lblNumberOfInternationalDrivingLicenseApplications";
            this.lblNumberOfInternationalDrivingLicenseApplications.Size = new System.Drawing.Size(144, 21);
            this.lblNumberOfInternationalDrivingLicenseApplications.TabIndex = 39;
            this.lblNumberOfInternationalDrivingLicenseApplications.Text = "NumberOfRecords:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(11, 550);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 21);
            this.label3.TabIndex = 38;
            this.label3.Text = "#Records:";
            // 
            // txtFilterBy
            // 
            this.txtFilterBy.Location = new System.Drawing.Point(238, 267);
            this.txtFilterBy.Name = "txtFilterBy";
            this.txtFilterBy.Size = new System.Drawing.Size(121, 20);
            this.txtFilterBy.TabIndex = 37;
            this.txtFilterBy.Visible = false;
            this.txtFilterBy.TextChanged += new System.EventHandler(this.txtFilterBy_TextChanged);
            this.txtFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterBy_KeyPress);
            // 
            // dgvInternationalDrivingLicenseApplications
            // 
            this.dgvInternationalDrivingLicenseApplications.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvInternationalDrivingLicenseApplications.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvInternationalDrivingLicenseApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalDrivingLicenseApplications.ContextMenuStrip = this.cmsInternationalDrivingLicenseApplication;
            this.dgvInternationalDrivingLicenseApplications.GridColor = System.Drawing.Color.White;
            this.dgvInternationalDrivingLicenseApplications.Location = new System.Drawing.Point(11, 303);
            this.dgvInternationalDrivingLicenseApplications.Name = "dgvInternationalDrivingLicenseApplications";
            this.dgvInternationalDrivingLicenseApplications.ReadOnly = true;
            this.dgvInternationalDrivingLicenseApplications.Size = new System.Drawing.Size(907, 228);
            this.dgvInternationalDrivingLicenseApplications.TabIndex = 36;
            this.dgvInternationalDrivingLicenseApplications.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInternationalDrivingLicenseApplications_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(7, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 21);
            this.label2.TabIndex = 35;
            this.label2.Text = "Filter By:";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "IntLicenseID",
            "ApplicationID ",
            "DriverID  ",
            "L.LicenseID",
            "IsActive"});
            this.cbFilterBy.Location = new System.Drawing.Point(88, 268);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(121, 21);
            this.cbFilterBy.TabIndex = 34;
            this.cbFilterBy.Text = "None";
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(223, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(454, 30);
            this.label1.TabIndex = 33;
            this.label1.Text = "International Driving License Applications";
            // 
            // cmsInternationalDrivingLicenseApplication
            // 
            this.cmsInternationalDrivingLicenseApplication.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.ShowPersonDetailsToolStripMenuItem,
            this.ShowLicenseDetailsToolStripMenuItem,
            this.ShowPersonLicenseHistoryToolStripMenuItem});
            this.cmsInternationalDrivingLicenseApplication.Name = "cmsLocalDrivingLicenseApplication";
            this.cmsInternationalDrivingLicenseApplication.Size = new System.Drawing.Size(260, 178);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(256, 6);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD.Properties.Resources.Close2__1_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(829, 541);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 39);
            this.btnClose.TabIndex = 41;
            this.btnClose.Text = "       Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNewApplication
            // 
            this.btnNewApplication.AutoSize = true;
            this.btnNewApplication.Image = global::DVLD.Properties.Resources.Add_Book;
            this.btnNewApplication.Location = new System.Drawing.Point(862, 232);
            this.btnNewApplication.Name = "btnNewApplication";
            this.btnNewApplication.Size = new System.Drawing.Size(56, 56);
            this.btnNewApplication.TabIndex = 40;
            this.btnNewApplication.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Add_properties__1_;
            this.pictureBox1.Location = new System.Drawing.Point(333, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(216, 190);
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
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
            // FrmInternationalDrivingLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 585);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNewApplication);
            this.Controls.Add(this.lblNumberOfInternationalDrivingLicenseApplications);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFilterBy);
            this.Controls.Add(this.dgvInternationalDrivingLicenseApplications);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FrmInternationalDrivingLicenseApplications";
            this.Text = "FrmInternationalDrivingLicenseApplications";
            this.Load += new System.EventHandler(this.FrmInternationalDrivingLicenseApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalDrivingLicenseApplications)).EndInit();
            this.cmsInternationalDrivingLicenseApplication.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNewApplication;
        private System.Windows.Forms.Label lblNumberOfInternationalDrivingLicenseApplications;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFilterBy;
        private System.Windows.Forms.DataGridView dgvInternationalDrivingLicenseApplications;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip cmsInternationalDrivingLicenseApplication;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ShowPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowLicenseDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowPersonLicenseHistoryToolStripMenuItem;
    }
}