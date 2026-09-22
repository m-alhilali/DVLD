namespace DVLD.Tests
{
    partial class frmSchduleTest
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
            this.ctrlSchduleTest1 = new DVLD.Controls.ctrlSchduleTest();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Navy;
            this.btnClose.Font = new System.Drawing.Font("Arial Black", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            this.btnClose.IconColor = System.Drawing.Color.Red;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 40;
            this.btnClose.Location = new System.Drawing.Point(358, 803);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnClose.Size = new System.Drawing.Size(161, 41);
            this.btnClose.TabIndex = 115;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlSchduleTest1
            // 
            this.ctrlSchduleTest1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlSchduleTest1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ctrlSchduleTest1.Location = new System.Drawing.Point(0, 0);
            this.ctrlSchduleTest1.Name = "ctrlSchduleTest1";
            this.ctrlSchduleTest1.Size = new System.Drawing.Size(685, 844);
            this.ctrlSchduleTest1.TabIndex = 116;
            this.ctrlSchduleTest1.TestTypeID = DVLD_DataBusinessLayer.clsTestTypes.enTestType.VisionTest;
            this.ctrlSchduleTest1.Load += new System.EventHandler(this.ctrlSchduleTest1_Load);
            // 
            // frmSchduleTest
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(685, 846);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlSchduleTest1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSchduleTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedule Test";
            this.Load += new System.EventHandler(this.frmAddSchduleTestAppintment_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private FontAwesome.Sharp.IconButton btnClose;
        private Controls.ctrlSchduleTest ctrlSchduleTest1;
    }
}