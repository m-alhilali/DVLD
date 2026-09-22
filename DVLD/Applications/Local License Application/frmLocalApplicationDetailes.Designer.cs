namespace DVLD.Applications
{
    partial class frmLocalApplicationDetailes
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
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.label12 = new System.Windows.Forms.Label();
            this.ctrlDrivingLicenseInfoWithApplicationBasicInfo1 = new DVLD.Controls.ctrlDrivingLicenseInfoWithApplicationBasicInfo();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Navy;
            this.btnClose.CausesValidation = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Arial Black", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            this.btnClose.IconColor = System.Drawing.Color.Red;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 43;
            this.btnClose.Location = new System.Drawing.Point(770, 648);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnClose.Size = new System.Drawing.Size(161, 44);
            this.btnClose.TabIndex = 249;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 25F);
            this.label12.Location = new System.Drawing.Point(233, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(454, 60);
            this.label12.TabIndex = 250;
            this.label12.Text = "Application Detailes";
            // 
            // ctrlDrivingLicenseInfoWithApplicationBasicInfo1
            // 
            this.ctrlDrivingLicenseInfoWithApplicationBasicInfo1.AutoSize = true;
            this.ctrlDrivingLicenseInfoWithApplicationBasicInfo1.Location = new System.Drawing.Point(-5, 79);
            this.ctrlDrivingLicenseInfoWithApplicationBasicInfo1.Name = "ctrlDrivingLicenseInfoWithApplicationBasicInfo1";
            this.ctrlDrivingLicenseInfoWithApplicationBasicInfo1.Size = new System.Drawing.Size(948, 564);
            this.ctrlDrivingLicenseInfoWithApplicationBasicInfo1.TabIndex = 251;
            // 
            // frmLocalApplicationDetailes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 696);
            this.Controls.Add(this.ctrlDrivingLicenseInfoWithApplicationBasicInfo1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label12);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLocalApplicationDetailes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLocalApplicationDetailes";
            this.Load += new System.EventHandler(this.frmLocalApplicationDetailes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label12;
        private FontAwesome.Sharp.IconButton btnClose;
        private DVLD.Controls.ctrlDrivingLicenseInfoWithApplicationBasicInfo ctrlDrivingLicenseInfoWithApplicationBasicInfo1;
    }
}