namespace DVLD.Licenses
{
    partial class frmDetainedLicense
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
            this.lnklblShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.lnklblShoeLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnIssue = new FontAwesome.Sharp.IconButton();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.lblLicenseID = new System.Windows.Forms.Label();
            this.iconPictureBox10 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox5 = new FontAwesome.Sharp.IconPictureBox();
            this.lblDetainID = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblDetainDate = new System.Windows.Forms.Label();
            this.iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbPersonInformation = new Guna.UI2.WinForms.Guna2GroupBox();
            this.tbFineFees = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ctrldriverLicenseInfoWithFilter1 = new DVLD.Controls.ctrlDriverLicenseInfoWithFilter();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.gbPersonInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lnklblShowLicenseInfo
            // 
            this.lnklblShowLicenseInfo.AutoSize = true;
            this.lnklblShowLicenseInfo.Enabled = false;
            this.lnklblShowLicenseInfo.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lnklblShowLicenseInfo.Location = new System.Drawing.Point(244, 842);
            this.lnklblShowLicenseInfo.Name = "lnklblShowLicenseInfo";
            this.lnklblShowLicenseInfo.Size = new System.Drawing.Size(180, 24);
            this.lnklblShowLicenseInfo.TabIndex = 42;
            this.lnklblShowLicenseInfo.TabStop = true;
            this.lnklblShowLicenseInfo.Text = "Show Licenses Info";
            this.lnklblShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblShowLicenseInfo_LinkClicked);
            // 
            // lnklblShoeLicenseHistory
            // 
            this.lnklblShoeLicenseHistory.AutoSize = true;
            this.lnklblShoeLicenseHistory.Enabled = false;
            this.lnklblShoeLicenseHistory.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lnklblShoeLicenseHistory.Location = new System.Drawing.Point(12, 842);
            this.lnklblShoeLicenseHistory.Name = "lnklblShoeLicenseHistory";
            this.lnklblShoeLicenseHistory.Size = new System.Drawing.Size(208, 24);
            this.lnklblShoeLicenseHistory.TabIndex = 41;
            this.lnklblShoeLicenseHistory.TabStop = true;
            this.lnklblShoeLicenseHistory.Text = "Show Licenses History";
            this.lnklblShoeLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblShoeLicenseHistory_LinkClicked);
            // 
            // btnIssue
            // 
            this.btnIssue.BackColor = System.Drawing.Color.Navy;
            this.btnIssue.Font = new System.Drawing.Font("Arial Black", 11F, System.Drawing.FontStyle.Bold);
            this.btnIssue.ForeColor = System.Drawing.SystemColors.Control;
            this.btnIssue.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnIssue.IconColor = System.Drawing.Color.LimeGreen;
            this.btnIssue.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnIssue.IconSize = 43;
            this.btnIssue.Location = new System.Drawing.Point(818, 831);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnIssue.Size = new System.Drawing.Size(161, 44);
            this.btnIssue.TabIndex = 40;
            this.btnIssue.Text = "Issue";
            this.btnIssue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIssue.UseVisualStyleBackColor = false;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
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
            this.btnClose.Location = new System.Drawing.Point(651, 832);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnClose.Size = new System.Drawing.Size(161, 44);
            this.btnClose.TabIndex = 39;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblLicenseID
            // 
            this.lblLicenseID.AutoSize = true;
            this.lblLicenseID.BackColor = System.Drawing.Color.Transparent;
            this.lblLicenseID.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblLicenseID.ForeColor = System.Drawing.Color.Black;
            this.lblLicenseID.Location = new System.Drawing.Point(683, 47);
            this.lblLicenseID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLicenseID.Name = "lblLicenseID";
            this.lblLicenseID.Size = new System.Drawing.Size(76, 24);
            this.lblLicenseID.TabIndex = 100;
            this.lblLicenseID.Text = "??????";
            // 
            // iconPictureBox10
            // 
            this.iconPictureBox10.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox10.ForeColor = System.Drawing.Color.Navy;
            this.iconPictureBox10.IconChar = FontAwesome.Sharp.IconChar.Orcid;
            this.iconPictureBox10.IconColor = System.Drawing.Color.Navy;
            this.iconPictureBox10.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox10.IconSize = 38;
            this.iconPictureBox10.Location = new System.Drawing.Point(8, 43);
            this.iconPictureBox10.Name = "iconPictureBox10";
            this.iconPictureBox10.Size = new System.Drawing.Size(38, 38);
            this.iconPictureBox10.TabIndex = 177;
            this.iconPictureBox10.TabStop = false;
            // 
            // iconPictureBox5
            // 
            this.iconPictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox5.ForeColor = System.Drawing.Color.Navy;
            this.iconPictureBox5.IconChar = FontAwesome.Sharp.IconChar.Orcid;
            this.iconPictureBox5.IconColor = System.Drawing.Color.Navy;
            this.iconPictureBox5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox5.IconSize = 38;
            this.iconPictureBox5.Location = new System.Drawing.Point(508, 39);
            this.iconPictureBox5.Name = "iconPictureBox5";
            this.iconPictureBox5.Size = new System.Drawing.Size(38, 38);
            this.iconPictureBox5.TabIndex = 175;
            this.iconPictureBox5.TabStop = false;
            // 
            // lblDetainID
            // 
            this.lblDetainID.AutoSize = true;
            this.lblDetainID.BackColor = System.Drawing.Color.Transparent;
            this.lblDetainID.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetainID.ForeColor = System.Drawing.Color.Black;
            this.lblDetainID.Location = new System.Drawing.Point(186, 45);
            this.lblDetainID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDetainID.Name = "lblDetainID";
            this.lblDetainID.Size = new System.Drawing.Size(76, 24);
            this.lblDetainID.TabIndex = 104;
            this.lblDetainID.Text = "??????";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.BackColor = System.Drawing.Color.Transparent;
            this.lblCreatedBy.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblCreatedBy.ForeColor = System.Drawing.Color.Black;
            this.lblCreatedBy.Location = new System.Drawing.Point(683, 94);
            this.lblCreatedBy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(76, 24);
            this.lblCreatedBy.TabIndex = 99;
            this.lblCreatedBy.Text = "??????";
            // 
            // lblDetainDate
            // 
            this.lblDetainDate.AutoSize = true;
            this.lblDetainDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDetainDate.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetainDate.ForeColor = System.Drawing.Color.Black;
            this.lblDetainDate.Location = new System.Drawing.Point(186, 87);
            this.lblDetainDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDetainDate.Name = "lblDetainDate";
            this.lblDetainDate.Size = new System.Drawing.Size(76, 24);
            this.lblDetainDate.TabIndex = 96;
            this.lblDetainDate.Text = "??????";
            // 
            // iconPictureBox3
            // 
            this.iconPictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox3.ForeColor = System.Drawing.Color.Navy;
            this.iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
            this.iconPictureBox3.IconColor = System.Drawing.Color.Navy;
            this.iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox3.IconSize = 38;
            this.iconPictureBox3.Location = new System.Drawing.Point(8, 80);
            this.iconPictureBox3.Name = "iconPictureBox3";
            this.iconPictureBox3.Size = new System.Drawing.Size(38, 38);
            this.iconPictureBox3.TabIndex = 90;
            this.iconPictureBox3.TabStop = false;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox2.ForeColor = System.Drawing.Color.Navy;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.MoneyBills;
            this.iconPictureBox2.IconColor = System.Drawing.Color.Navy;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 38;
            this.iconPictureBox2.Location = new System.Drawing.Point(8, 120);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(38, 38);
            this.iconPictureBox2.TabIndex = 86;
            this.iconPictureBox2.TabStop = false;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.Navy;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.iconPictureBox1.IconColor = System.Drawing.Color.Navy;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 38;
            this.iconPictureBox1.Location = new System.Drawing.Point(508, 83);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(38, 38);
            this.iconPictureBox1.TabIndex = 85;
            this.iconPictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(47, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 24);
            this.label2.TabIndex = 83;
            this.label2.Text = "Detain ID:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(552, 47);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 24);
            this.label7.TabIndex = 80;
            this.label7.Text = "License ID:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(554, 87);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(128, 24);
            this.label11.TabIndex = 78;
            this.label11.Text = "Created By:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(51, 124);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 24);
            this.label8.TabIndex = 77;
            this.label8.Text = "Fine Fees:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(47, 87);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 24);
            this.label3.TabIndex = 75;
            this.label3.Text = "Detain Date:";
            // 
            // gbPersonInformation
            // 
            this.gbPersonInformation.BorderColor = System.Drawing.Color.Navy;
            this.gbPersonInformation.BorderRadius = 4;
            this.gbPersonInformation.BorderThickness = 2;
            this.gbPersonInformation.Controls.Add(this.tbFineFees);
            this.gbPersonInformation.Controls.Add(this.lblLicenseID);
            this.gbPersonInformation.Controls.Add(this.iconPictureBox10);
            this.gbPersonInformation.Controls.Add(this.iconPictureBox5);
            this.gbPersonInformation.Controls.Add(this.lblDetainID);
            this.gbPersonInformation.Controls.Add(this.lblCreatedBy);
            this.gbPersonInformation.Controls.Add(this.lblDetainDate);
            this.gbPersonInformation.Controls.Add(this.iconPictureBox3);
            this.gbPersonInformation.Controls.Add(this.iconPictureBox2);
            this.gbPersonInformation.Controls.Add(this.iconPictureBox1);
            this.gbPersonInformation.Controls.Add(this.label2);
            this.gbPersonInformation.Controls.Add(this.label7);
            this.gbPersonInformation.Controls.Add(this.label11);
            this.gbPersonInformation.Controls.Add(this.label8);
            this.gbPersonInformation.Controls.Add(this.label3);
            this.gbPersonInformation.CustomBorderColor = System.Drawing.Color.Navy;
            this.gbPersonInformation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPersonInformation.ForeColor = System.Drawing.Color.White;
            this.gbPersonInformation.Location = new System.Drawing.Point(5, 666);
            this.gbPersonInformation.Name = "gbPersonInformation";
            this.gbPersonInformation.Size = new System.Drawing.Size(970, 164);
            this.gbPersonInformation.TabIndex = 38;
            this.gbPersonInformation.Text = "Detain Info";
            // 
            // tbFineFees
            // 
            this.tbFineFees.BorderColor = System.Drawing.Color.Navy;
            this.tbFineFees.BorderRadius = 8;
            this.tbFineFees.BorderThickness = 2;
            this.tbFineFees.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbFineFees.DefaultText = "";
            this.tbFineFees.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbFineFees.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbFineFees.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbFineFees.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbFineFees.FillColor = System.Drawing.SystemColors.Control;
            this.tbFineFees.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbFineFees.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbFineFees.ForeColor = System.Drawing.Color.Black;
            this.tbFineFees.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbFineFees.Location = new System.Drawing.Point(190, 116);
            this.tbFineFees.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbFineFees.Name = "tbFineFees";
            this.tbFineFees.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.tbFineFees.PlaceholderText = "Fine Fees";
            this.tbFineFees.SelectedText = "";
            this.tbFineFees.Size = new System.Drawing.Size(212, 36);
            this.tbFineFees.TabIndex = 83;
            this.tbFineFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFineFees_KeyPress);
            this.tbFineFees.Validating += new System.ComponentModel.CancelEventHandler(this.tbFineFees_Validating);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(281, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(344, 53);
            this.lblTitle.TabIndex = 37;
            this.lblTitle.Text = "Detain License";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.detainicon;
            this.pictureBox1.Location = new System.Drawing.Point(631, -13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(241, 227);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 48;
            this.pictureBox1.TabStop = false;
            // 
            // ctrldriverLicenseInfoWithFilter1
            // 
            this.ctrldriverLicenseInfoWithFilter1.FilterEnabled = true;
            this.ctrldriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(4, 74);
            this.ctrldriverLicenseInfoWithFilter1.Name = "ctrldriverLicenseInfoWithFilter1";
            this.ctrldriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(976, 589);
            this.ctrldriverLicenseInfoWithFilter1.TabIndex = 35;
            this.ctrldriverLicenseInfoWithFilter1.OnSelectedLicense += new System.Action<int>(this.driverLicenseInfoWithFilter1_OnSelectedLicense);
            // 
            // frmDetainedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 878);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lnklblShowLicenseInfo);
            this.Controls.Add(this.lnklblShoeLicenseHistory);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrldriverLicenseInfoWithFilter1);
            this.Controls.Add(this.gbPersonInformation);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDetainedLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDetainedLicense";
            this.Activated += new System.EventHandler(this.frmDetainedLicense_Activated);
            this.Load += new System.EventHandler(this.frmDetainedLicense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.gbPersonInformation.ResumeLayout(false);
            this.gbPersonInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnklblShowLicenseInfo;
        private System.Windows.Forms.LinkLabel lnklblShoeLicenseHistory;
        private FontAwesome.Sharp.IconButton btnIssue;
        private FontAwesome.Sharp.IconButton btnClose;
        private System.Windows.Forms.Label lblLicenseID;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox10;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox5;
        private System.Windows.Forms.Label lblDetainID;
        private DVLD.Controls.ctrlDriverLicenseInfoWithFilter ctrldriverLicenseInfoWithFilter1;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblDetainDate;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2GroupBox gbPersonInformation;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2TextBox tbFineFees;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}