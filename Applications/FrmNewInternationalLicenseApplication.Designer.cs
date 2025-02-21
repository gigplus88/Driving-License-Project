namespace DVLD.Applications
{
    partial class FrmNewInternationalLicenseApplication
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.lblShowLicensesInfo = new System.Windows.Forms.LinkLabel();
            this.llblShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.llblShowLicensesInfo = new System.Windows.Forms.LinkLabel();
            this.ButtonIssue = new System.Windows.Forms.Button();
            this.btnIssue = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrLicenseInfo1 = new DVLD.Controls.ctrlLicenseInfo();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(295, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 30);
            this.label1.TabIndex = 24;
            this.label1.Text = "International License Application";
            // 
            // lblShowLicensesHistory
            // 
            this.lblShowLicensesHistory.AutoSize = true;
            this.lblShowLicensesHistory.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowLicensesHistory.Location = new System.Drawing.Point(45, 935);
            this.lblShowLicensesHistory.Name = "lblShowLicensesHistory";
            this.lblShowLicensesHistory.Size = new System.Drawing.Size(165, 21);
            this.lblShowLicensesHistory.TabIndex = 25;
            this.lblShowLicensesHistory.TabStop = true;
            this.lblShowLicensesHistory.Text = "Show Licenses History";
            // 
            // lblShowLicensesInfo
            // 
            this.lblShowLicensesInfo.AutoSize = true;
            this.lblShowLicensesInfo.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowLicensesInfo.Location = new System.Drawing.Point(296, 935);
            this.lblShowLicensesInfo.Name = "lblShowLicensesInfo";
            this.lblShowLicensesInfo.Size = new System.Drawing.Size(142, 21);
            this.lblShowLicensesInfo.TabIndex = 26;
            this.lblShowLicensesInfo.TabStop = true;
            this.lblShowLicensesInfo.Text = "Show Licenses Info";
            // 
            // llblShowLicensesHistory
            // 
            this.llblShowLicensesHistory.AutoSize = true;
            this.llblShowLicensesHistory.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblShowLicensesHistory.Location = new System.Drawing.Point(45, 935);
            this.llblShowLicensesHistory.Name = "llblShowLicensesHistory";
            this.llblShowLicensesHistory.Size = new System.Drawing.Size(165, 21);
            this.llblShowLicensesHistory.TabIndex = 25;
            this.llblShowLicensesHistory.TabStop = true;
            this.llblShowLicensesHistory.Text = "Show Licenses History";
            this.llblShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblShowLicensesHistory_LinkClicked);
            // 
            // llblShowLicensesInfo
            // 
            this.llblShowLicensesInfo.AutoSize = true;
            this.llblShowLicensesInfo.Enabled = false;
            this.llblShowLicensesInfo.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblShowLicensesInfo.Location = new System.Drawing.Point(296, 935);
            this.llblShowLicensesInfo.Name = "llblShowLicensesInfo";
            this.llblShowLicensesInfo.Size = new System.Drawing.Size(142, 21);
            this.llblShowLicensesInfo.TabIndex = 26;
            this.llblShowLicensesInfo.TabStop = true;
            this.llblShowLicensesInfo.Text = "Show Licenses Info";
            this.llblShowLicensesInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblShowLicensesInfo_LinkClicked);
            // 
            // ButtonIssue
            // 
            this.ButtonIssue.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonIssue.Image = global::DVLD.Properties.Resources.Left_Handed__1_;
            this.ButtonIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonIssue.Location = new System.Drawing.Point(883, 928);
            this.ButtonIssue.Name = "ButtonIssue";
            this.ButtonIssue.Size = new System.Drawing.Size(85, 34);
            this.ButtonIssue.TabIndex = 112;
            this.ButtonIssue.Text = "      Issue";
            this.ButtonIssue.UseVisualStyleBackColor = true;
            this.ButtonIssue.Click += new System.EventHandler(this.Issue_Click);
            // 
            // btnIssue
            // 
            this.btnIssue.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.Image = global::DVLD.Properties.Resources.Left_Handed__1_;
            this.btnIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssue.Location = new System.Drawing.Point(883, 928);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(85, 34);
            this.btnIssue.TabIndex = 113;
            this.btnIssue.Text = "      Issue";
            this.btnIssue.UseVisualStyleBackColor = true;
            // 
            // Close
            // 
            this.Close.Image = global::DVLD.Properties.Resources.Close2;
            this.Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Close.Location = new System.Drawing.Point(784, 928);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(89, 34);
            this.Close.TabIndex = 110;
            this.Close.Text = "     Close";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD.Properties.Resources.Close2;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(784, 928);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 34);
            this.btnClose.TabIndex = 111;
            this.btnClose.Text = "     Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // ctrLicenseInfo1
            // 
            this.ctrLicenseInfo1.Location = new System.Drawing.Point(3, 89);
            this.ctrLicenseInfo1.Name = "ctrLicenseInfo1";
            this.ctrLicenseInfo1.Size = new System.Drawing.Size(976, 830);
            this.ctrLicenseInfo1.TabIndex = 0;
            // 
            // FrmNewInternationalLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 965);
            this.Controls.Add(this.ButtonIssue);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.llblShowLicensesInfo);
            this.Controls.Add(this.llblShowLicensesHistory);
            this.Controls.Add(this.lblShowLicensesInfo);
            this.Controls.Add(this.lblShowLicensesHistory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrLicenseInfo1);
            this.Name = "FrmNewInternationalLicenseApplication";
            this.Text = "New International License Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ctrlLicenseInfo ctrLicenseInfo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lblShowLicensesHistory;
        private System.Windows.Forms.LinkLabel lblShowLicensesInfo;
        private System.Windows.Forms.LinkLabel llblShowLicensesHistory;
        private System.Windows.Forms.LinkLabel llblShowLicensesInfo;
        private System.Windows.Forms.Button ButtonIssue;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button btnClose;
    }
}