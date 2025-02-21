namespace DVLD.Test_Type.Street_Test
{
    partial class FrmStreetTestAppointments
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumberOfAppointments = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.cmsAppointments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TakeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.ctrlDrivingLicenseApplication1 = new DVLD.Controls.ctrlDrivingLicenseApplication();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnNewStreetTest = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.cmsAppointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 649);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 43;
            this.label1.Text = "Appointments:";
            // 
            // lblNumberOfAppointments
            // 
            this.lblNumberOfAppointments.AutoSize = true;
            this.lblNumberOfAppointments.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfAppointments.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNumberOfAppointments.Location = new System.Drawing.Point(115, 929);
            this.lblNumberOfAppointments.Name = "lblNumberOfAppointments";
            this.lblNumberOfAppointments.Size = new System.Drawing.Size(144, 21);
            this.lblNumberOfAppointments.TabIndex = 41;
            this.lblNumberOfAppointments.Text = "NumberOfRecords:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(25, 929);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 21);
            this.label3.TabIndex = 40;
            this.label3.Text = "#Records:";
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvAppointments.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.ContextMenuStrip = this.cmsAppointments;
            this.dgvAppointments.GridColor = System.Drawing.Color.White;
            this.dgvAppointments.Location = new System.Drawing.Point(26, 688);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvAppointments.Size = new System.Drawing.Size(921, 228);
            this.dgvAppointments.TabIndex = 39;
            this.dgvAppointments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAppointments_CellClick);
            // 
            // cmsAppointments
            // 
            this.cmsAppointments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.TakeTestToolStripMenuItem});
            this.cmsAppointments.Name = "cmsAppointments";
            this.cmsAppointments.Size = new System.Drawing.Size(163, 116);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editToolStripMenuItem.Image = global::DVLD.Properties.Resources.Edit2;
            this.editToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(162, 56);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // TakeTestToolStripMenuItem
            // 
            this.TakeTestToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TakeTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.Add_Book_Large;
            this.TakeTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TakeTestToolStripMenuItem.Name = "TakeTestToolStripMenuItem";
            this.TakeTestToolStripMenuItem.Size = new System.Drawing.Size(162, 56);
            this.TakeTestToolStripMenuItem.Text = "Take Test";
            this.TakeTestToolStripMenuItem.Click += new System.EventHandler(this.TakeTestToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(293, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(402, 37);
            this.label4.TabIndex = 37;
            this.label4.Text = "Street Test Appointments";
            // 
            // ctrlDrivingLicenseApplication1
            // 
            this.ctrlDrivingLicenseApplication1.Location = new System.Drawing.Point(26, 192);
            this.ctrlDrivingLicenseApplication1.Name = "ctrlDrivingLicenseApplication1";
            this.ctrlDrivingLicenseApplication1.Size = new System.Drawing.Size(921, 439);
            this.ctrlDrivingLicenseApplication1.TabIndex = 35;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD.Properties.Resources.application_list1;
            this.pictureBox2.Location = new System.Drawing.Point(392, 67);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(52, 67);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 44;
            this.pictureBox2.TabStop = false;
            // 
            // btnNewStreetTest
            // 
            this.btnNewStreetTest.AutoSize = true;
            this.btnNewStreetTest.Image = global::DVLD.Properties.Resources.Calendar_Plus__1_;
            this.btnNewStreetTest.Location = new System.Drawing.Point(904, 636);
            this.btnNewStreetTest.Name = "btnNewStreetTest";
            this.btnNewStreetTest.Size = new System.Drawing.Size(43, 38);
            this.btnNewStreetTest.TabIndex = 42;
            this.btnNewStreetTest.UseVisualStyleBackColor = true;
            this.btnNewStreetTest.Click += new System.EventHandler(this.btnNewStreetTest_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Car__1_;
            this.pictureBox1.Location = new System.Drawing.Point(381, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 105);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD.Properties.Resources.Close2;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(860, 922);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 34);
            this.btnClose.TabIndex = 36;
            this.btnClose.Text = "     Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmStreetTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 961);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNewStreetTest);
            this.Controls.Add(this.lblNumberOfAppointments);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvAppointments);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlDrivingLicenseApplication1);
            this.Name = "FrmStreetTestAppointments";
            this.Text = "FrmStreetTestQAppointments";
            this.Load += new System.EventHandler(this.FrmStreetTestAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.cmsAppointments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNewStreetTest;
        private System.Windows.Forms.Label lblNumberOfAppointments;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClose;
        private Controls.ctrlDrivingLicenseApplication ctrlDrivingLicenseApplication1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ContextMenuStrip cmsAppointments;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TakeTestToolStripMenuItem;
    }
}