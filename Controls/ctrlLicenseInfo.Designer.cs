namespace DVLD.Controls
{
    partial class ctrlLicenseInfo
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnFilterByLicenseID = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txtLicenseID = new System.Windows.Forms.TextBox();
            this.driverLicenseInfo1 = new DVLD.Controls.DriverLicenseInfo();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnFilterByLicenseID);
            this.gbFilter.Controls.Add(this.label16);
            this.gbFilter.Controls.Add(this.txtLicenseID);
            this.gbFilter.Location = new System.Drawing.Point(3, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(668, 103);
            this.gbFilter.TabIndex = 0;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            this.gbFilter.Enter += new System.EventHandler(this.gbFilter_Enter);
            // 
            // btnFilterByLicenseID
            // 
            this.btnFilterByLicenseID.Image = global::DVLD.Properties.Resources.Driver_License1;
            this.btnFilterByLicenseID.Location = new System.Drawing.Point(565, 37);
            this.btnFilterByLicenseID.Name = "btnFilterByLicenseID";
            this.btnFilterByLicenseID.Size = new System.Drawing.Size(53, 44);
            this.btnFilterByLicenseID.TabIndex = 87;
            this.btnFilterByLicenseID.UseVisualStyleBackColor = true;
            this.btnFilterByLicenseID.Click += new System.EventHandler(this.btnFilterByLicenseID_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(63, 51);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(84, 16);
            this.label16.TabIndex = 86;
            this.label16.Text = "License ID:";
            // 
            // txtLicenseID
            // 
            this.txtLicenseID.Location = new System.Drawing.Point(253, 50);
            this.txtLicenseID.Name = "txtLicenseID";
            this.txtLicenseID.Size = new System.Drawing.Size(149, 20);
            this.txtLicenseID.TabIndex = 0;
            this.txtLicenseID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLicenseID_KeyPress);
            // 
            // driverLicenseInfo1
            // 
            this.driverLicenseInfo1.Location = new System.Drawing.Point(3, 110);
            this.driverLicenseInfo1.Name = "driverLicenseInfo1";
            this.driverLicenseInfo1.Size = new System.Drawing.Size(967, 468);
            this.driverLicenseInfo1.TabIndex = 1;
            this.driverLicenseInfo1.Load += new System.EventHandler(this.driverLicenseInfo1_Load);
            // 
            // ctrlLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.driverLicenseInfo1);
            this.Controls.Add(this.gbFilter);
            this.Name = "ctrlLicenseInfo";
            this.Size = new System.Drawing.Size(976, 591);
            this.Load += new System.EventHandler(this.ctrLicenseInfo_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.TextBox txtLicenseID;
        private System.Windows.Forms.Button btnFilterByLicenseID;
        private System.Windows.Forms.Label label16;
        private DriverLicenseInfo driverLicenseInfo1;
    }
}
