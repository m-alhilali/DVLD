namespace DVLD.Controls
{
    partial class ctrlDrivingLicenseInfoWithApplicationBasicInfo
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
            this.ctrlDrivingLicenseApplicationInfo2 = new DVLD.Controls.ctrlDrivingLicenseApplicationInfo();
            this.ctrlApplicationBasicInfo1 = new DVLD.Controls.ctrlApplicationBasicInfo();
            this.SuspendLayout();
            // 
            // ctrlDrivingLicenseApplicationInfo2
            // 
            this.ctrlDrivingLicenseApplicationInfo2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.ctrlDrivingLicenseApplicationInfo2.Location = new System.Drawing.Point(1, 0);
            this.ctrlDrivingLicenseApplicationInfo2.Name = "ctrlDrivingLicenseApplicationInfo2";
            this.ctrlDrivingLicenseApplicationInfo2.Size = new System.Drawing.Size(940, 183);
            this.ctrlDrivingLicenseApplicationInfo2.TabIndex = 1;
            // 
            // ctrlApplicationBasicInfo1
            // 
            this.ctrlApplicationBasicInfo1.Location = new System.Drawing.Point(1, 180);
            this.ctrlApplicationBasicInfo1.Name = "ctrlApplicationBasicInfo1";
            this.ctrlApplicationBasicInfo1.Size = new System.Drawing.Size(944, 381);
            this.ctrlApplicationBasicInfo1.TabIndex = 2;
            // 
            // ctrlDrivingLicenseInfoWithApplicationBasicInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.ctrlApplicationBasicInfo1);
            this.Controls.Add(this.ctrlDrivingLicenseApplicationInfo2);
            this.Name = "ctrlDrivingLicenseInfoWithApplicationBasicInfo";
            this.Size = new System.Drawing.Size(948, 568);
            this.ResumeLayout(false);

        }

        #endregion
        private ctrlDrivingLicenseApplicationInfo ctrlDrivingLicenseApplicationInfo2;
        private ctrlApplicationBasicInfo ctrlApplicationBasicInfo1;
    }
}
