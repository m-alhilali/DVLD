namespace DVLD.Applications
{
    partial class frmReplaceForDamageOrLostLicense
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
            this.gbReplacement = new Guna.UI2.WinForms.Guna2GroupBox();
            this.rbtnLost = new System.Windows.Forms.RadioButton();
            this.rbtnDamage = new System.Windows.Forms.RadioButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbPersonInformation = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblReplaceLicenseID = new System.Windows.Forms.Label();
            this.iconPictureBox10 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox8 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox5 = new FontAwesome.Sharp.IconPictureBox();
            this.lblRApplicationID = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lnklblShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.lnklblShoeLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnIssue = new FontAwesome.Sharp.IconButton();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.ctrldriverLicenseInfoWithFilter1 = new DVLD.Controls.ctrlDriverLicenseInfoWithFilter();
            this.gbReplacement.SuspendLayout();
            this.gbPersonInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbReplacement
            // 
            this.gbReplacement.BorderColor = System.Drawing.Color.Navy;
            this.gbReplacement.BorderRadius = 4;
            this.gbReplacement.BorderThickness = 2;
            this.gbReplacement.Controls.Add(this.rbtnLost);
            this.gbReplacement.Controls.Add(this.rbtnDamage);
            this.gbReplacement.CustomBorderColor = System.Drawing.Color.Navy;
            this.gbReplacement.CustomBorderThickness = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.gbReplacement.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbReplacement.ForeColor = System.Drawing.Color.White;
            this.gbReplacement.Location = new System.Drawing.Point(476, 79);
            this.gbReplacement.Name = "gbReplacement";
            this.gbReplacement.Size = new System.Drawing.Size(495, 135);
            this.gbReplacement.TabIndex = 5;
            this.gbReplacement.Text = "Replacenment For";
            // 
            // rbtnLost
            // 
            this.rbtnLost.AutoSize = true;
            this.rbtnLost.BackColor = System.Drawing.Color.Transparent;
            this.rbtnLost.Checked = true;
            this.rbtnLost.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.rbtnLost.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rbtnLost.Location = new System.Drawing.Point(299, 68);
            this.rbtnLost.Name = "rbtnLost";
            this.rbtnLost.Size = new System.Drawing.Size(176, 36);
            this.rbtnLost.TabIndex = 1;
            this.rbtnLost.TabStop = true;
            this.rbtnLost.Text = "Lost License";
            this.rbtnLost.UseVisualStyleBackColor = false;
            this.rbtnLost.CheckedChanged += new System.EventHandler(this.rbtnLost_CheckedChanged);
            // 
            // rbtnDamage
            // 
            this.rbtnDamage.AutoSize = true;
            this.rbtnDamage.BackColor = System.Drawing.Color.Transparent;
            this.rbtnDamage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.rbtnDamage.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rbtnDamage.Location = new System.Drawing.Point(14, 68);
            this.rbtnDamage.Name = "rbtnDamage";
            this.rbtnDamage.Size = new System.Drawing.Size(223, 36);
            this.rbtnDamage.TabIndex = 0;
            this.rbtnDamage.Text = "Damage License";
            this.rbtnDamage.UseVisualStyleBackColor = false;
            this.rbtnDamage.CheckedChanged += new System.EventHandler(this.rbtnDamage_CheckedChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTitle.Location = new System.Drawing.Point(87, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(795, 53);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Replacement For Damaged License";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // gbPersonInformation
            // 
            this.gbPersonInformation.BorderColor = System.Drawing.Color.Navy;
            this.gbPersonInformation.BorderRadius = 4;
            this.gbPersonInformation.BorderThickness = 2;
            this.gbPersonInformation.Controls.Add(this.lblReplaceLicenseID);
            this.gbPersonInformation.Controls.Add(this.iconPictureBox10);
            this.gbPersonInformation.Controls.Add(this.iconPictureBox8);
            this.gbPersonInformation.Controls.Add(this.iconPictureBox5);
            this.gbPersonInformation.Controls.Add(this.lblRApplicationID);
            this.gbPersonInformation.Controls.Add(this.lblOldLicenseID);
            this.gbPersonInformation.Controls.Add(this.lblCreatedBy);
            this.gbPersonInformation.Controls.Add(this.lblApplicationFees);
            this.gbPersonInformation.Controls.Add(this.lblApplicationDate);
            this.gbPersonInformation.Controls.Add(this.iconPictureBox3);
            this.gbPersonInformation.Controls.Add(this.iconPictureBox2);
            this.gbPersonInformation.Controls.Add(this.iconPictureBox1);
            this.gbPersonInformation.Controls.Add(this.label2);
            this.gbPersonInformation.Controls.Add(this.label9);
            this.gbPersonInformation.Controls.Add(this.label7);
            this.gbPersonInformation.Controls.Add(this.label11);
            this.gbPersonInformation.Controls.Add(this.label8);
            this.gbPersonInformation.Controls.Add(this.label3);
            this.gbPersonInformation.CustomBorderColor = System.Drawing.Color.Navy;
            this.gbPersonInformation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPersonInformation.ForeColor = System.Drawing.Color.White;
            this.gbPersonInformation.Location = new System.Drawing.Point(1, 668);
            this.gbPersonInformation.Name = "gbPersonInformation";
            this.gbPersonInformation.Size = new System.Drawing.Size(970, 160);
            this.gbPersonInformation.TabIndex = 30;
            this.gbPersonInformation.Text = "Applications Info For License Replacement";
            // 
            // lblReplaceLicenseID
            // 
            this.lblReplaceLicenseID.AutoSize = true;
            this.lblReplaceLicenseID.BackColor = System.Drawing.Color.Transparent;
            this.lblReplaceLicenseID.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblReplaceLicenseID.ForeColor = System.Drawing.Color.Black;
            this.lblReplaceLicenseID.Location = new System.Drawing.Point(755, 48);
            this.lblReplaceLicenseID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReplaceLicenseID.Name = "lblReplaceLicenseID";
            this.lblReplaceLicenseID.Size = new System.Drawing.Size(76, 24);
            this.lblReplaceLicenseID.TabIndex = 100;
            this.lblReplaceLicenseID.Text = "??????";
            // 
            // iconPictureBox10
            // 
            this.iconPictureBox10.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox10.ForeColor = System.Drawing.Color.Navy;
            this.iconPictureBox10.IconChar = FontAwesome.Sharp.IconChar.Orcid;
            this.iconPictureBox10.IconColor = System.Drawing.Color.Navy;
            this.iconPictureBox10.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox10.IconSize = 38;
            this.iconPictureBox10.Location = new System.Drawing.Point(8, 39);
            this.iconPictureBox10.Name = "iconPictureBox10";
            this.iconPictureBox10.Size = new System.Drawing.Size(38, 38);
            this.iconPictureBox10.TabIndex = 177;
            this.iconPictureBox10.TabStop = false;
            // 
            // iconPictureBox8
            // 
            this.iconPictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox8.ForeColor = System.Drawing.Color.Navy;
            this.iconPictureBox8.IconChar = FontAwesome.Sharp.IconChar.Orcid;
            this.iconPictureBox8.IconColor = System.Drawing.Color.Navy;
            this.iconPictureBox8.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox8.IconSize = 38;
            this.iconPictureBox8.Location = new System.Drawing.Point(508, 77);
            this.iconPictureBox8.Name = "iconPictureBox8";
            this.iconPictureBox8.Size = new System.Drawing.Size(38, 38);
            this.iconPictureBox8.TabIndex = 176;
            this.iconPictureBox8.TabStop = false;
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
            // lblRApplicationID
            // 
            this.lblRApplicationID.AutoSize = true;
            this.lblRApplicationID.BackColor = System.Drawing.Color.Transparent;
            this.lblRApplicationID.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblRApplicationID.ForeColor = System.Drawing.Color.Black;
            this.lblRApplicationID.Location = new System.Drawing.Point(239, 47);
            this.lblRApplicationID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRApplicationID.Name = "lblRApplicationID";
            this.lblRApplicationID.Size = new System.Drawing.Size(76, 24);
            this.lblRApplicationID.TabIndex = 104;
            this.lblRApplicationID.Text = "??????";
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.BackColor = System.Drawing.Color.Transparent;
            this.lblOldLicenseID.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblOldLicenseID.ForeColor = System.Drawing.Color.Black;
            this.lblOldLicenseID.Location = new System.Drawing.Point(755, 83);
            this.lblOldLicenseID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(76, 24);
            this.lblOldLicenseID.TabIndex = 101;
            this.lblOldLicenseID.Text = "??????";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.BackColor = System.Drawing.Color.Transparent;
            this.lblCreatedBy.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblCreatedBy.ForeColor = System.Drawing.Color.Black;
            this.lblCreatedBy.Location = new System.Drawing.Point(755, 119);
            this.lblCreatedBy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(76, 24);
            this.lblCreatedBy.TabIndex = 99;
            this.lblCreatedBy.Text = "??????";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.BackColor = System.Drawing.Color.Transparent;
            this.lblApplicationFees.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblApplicationFees.ForeColor = System.Drawing.Color.Black;
            this.lblApplicationFees.Location = new System.Drawing.Point(239, 119);
            this.lblApplicationFees.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(76, 24);
            this.lblApplicationFees.TabIndex = 98;
            this.lblApplicationFees.Text = "??????";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.BackColor = System.Drawing.Color.Transparent;
            this.lblApplicationDate.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblApplicationDate.ForeColor = System.Drawing.Color.Black;
            this.lblApplicationDate.Location = new System.Drawing.Point(239, 81);
            this.lblApplicationDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(76, 24);
            this.lblApplicationDate.TabIndex = 96;
            this.lblApplicationDate.Text = "??????";
            // 
            // iconPictureBox3
            // 
            this.iconPictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox3.ForeColor = System.Drawing.Color.Navy;
            this.iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
            this.iconPictureBox3.IconColor = System.Drawing.Color.Navy;
            this.iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox3.IconSize = 38;
            this.iconPictureBox3.Location = new System.Drawing.Point(8, 77);
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
            this.iconPictureBox2.Location = new System.Drawing.Point(8, 115);
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
            this.iconPictureBox1.Location = new System.Drawing.Point(508, 112);
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
            this.label2.Size = new System.Drawing.Size(200, 24);
            this.label2.TabIndex = 83;
            this.label2.Text = "L.R.Application ID:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(554, 83);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(163, 24);
            this.label9.TabIndex = 81;
            this.label9.Text = "Old License ID:";
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
            this.label7.Size = new System.Drawing.Size(210, 24);
            this.label7.TabIndex = 80;
            this.label7.Text = "Replace License ID:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(554, 119);
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
            this.label8.Location = new System.Drawing.Point(51, 119);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(183, 24);
            this.label8.TabIndex = 77;
            this.label8.Text = "Application Fees:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(47, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 24);
            this.label3.TabIndex = 75;
            this.label3.Text = "Application Date:";
            // 
            // lnklblShowLicenseInfo
            // 
            this.lnklblShowLicenseInfo.AutoSize = true;
            this.lnklblShowLicenseInfo.Enabled = false;
            this.lnklblShowLicenseInfo.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lnklblShowLicenseInfo.Location = new System.Drawing.Point(240, 841);
            this.lnklblShowLicenseInfo.Name = "lnklblShowLicenseInfo";
            this.lnklblShowLicenseInfo.Size = new System.Drawing.Size(180, 24);
            this.lnklblShowLicenseInfo.TabIndex = 34;
            this.lnklblShowLicenseInfo.TabStop = true;
            this.lnklblShowLicenseInfo.Text = "Show Licenses Info";
            this.lnklblShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblShowLicenseInfo_LinkClicked);
            // 
            // lnklblShoeLicenseHistory
            // 
            this.lnklblShoeLicenseHistory.AutoSize = true;
            this.lnklblShoeLicenseHistory.Enabled = false;
            this.lnklblShoeLicenseHistory.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lnklblShoeLicenseHistory.Location = new System.Drawing.Point(12, 841);
            this.lnklblShoeLicenseHistory.Name = "lnklblShoeLicenseHistory";
            this.lnklblShoeLicenseHistory.Size = new System.Drawing.Size(208, 24);
            this.lnklblShoeLicenseHistory.TabIndex = 33;
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
            this.btnIssue.Location = new System.Drawing.Point(814, 829);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnIssue.Size = new System.Drawing.Size(161, 44);
            this.btnIssue.TabIndex = 32;
            this.btnIssue.Text = "Issue";
            this.btnIssue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIssue.UseVisualStyleBackColor = false;
            this.btnIssue.Click += new System.EventHandler(this.btnSave_Click);
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
            this.btnClose.Location = new System.Drawing.Point(647, 830);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnClose.Size = new System.Drawing.Size(161, 44);
            this.btnClose.TabIndex = 31;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrldriverLicenseInfoWithFilter1
            // 
            this.ctrldriverLicenseInfoWithFilter1.FilterEnabled = true;
            this.ctrldriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(0, 76);
            this.ctrldriverLicenseInfoWithFilter1.Name = "ctrldriverLicenseInfoWithFilter1";
            this.ctrldriverLicenseInfoWithFilter1.SetCustomBorderColor = System.Drawing.Color.Navy;
            this.ctrldriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(976, 589);
            this.ctrldriverLicenseInfoWithFilter1.TabIndex = 0;
            this.ctrldriverLicenseInfoWithFilter1.OnSelectedLicense += new System.Action<int>(this.driverLicenseInfoWithFilter1_OnSelectedLicense);
            // 
            // frmReplaceForDamageOrLostLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 874);
            this.Controls.Add(this.lnklblShowLicenseInfo);
            this.Controls.Add(this.lnklblShoeLicenseHistory);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbPersonInformation);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gbReplacement);
            this.Controls.Add(this.ctrldriverLicenseInfoWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReplaceForDamageOrLostLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replacement For Damaged License";
            this.Activated += new System.EventHandler(this.frmReplaceLostOrDamagedLicenseApplication_Activated);
            this.Load += new System.EventHandler(this.frmReplaceForDamageOrLostLicense_Load);
            this.gbReplacement.ResumeLayout(false);
            this.gbReplacement.PerformLayout();
            this.gbPersonInformation.ResumeLayout(false);
            this.gbPersonInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ctrlDriverLicenseInfoWithFilter ctrldriverLicenseInfoWithFilter1;
        private Guna.UI2.WinForms.Guna2GroupBox gbReplacement;
        private System.Windows.Forms.RadioButton rbtnLost;
        private System.Windows.Forms.RadioButton rbtnDamage;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2GroupBox gbPersonInformation;
        private System.Windows.Forms.Label lblReplaceLicenseID;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox10;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox8;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox5;
        private System.Windows.Forms.Label lblRApplicationID;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblApplicationDate;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel lnklblShowLicenseInfo;
        private System.Windows.Forms.LinkLabel lnklblShoeLicenseHistory;
        private FontAwesome.Sharp.IconButton btnIssue;
        private FontAwesome.Sharp.IconButton btnClose;
    }
}