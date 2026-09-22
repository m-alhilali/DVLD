namespace DVLD.Applications
{
    partial class frmRenewDrivingLicense
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
            this.lnklblLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.lnklblShowNewLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.btnRenew = new FontAwesome.Sharp.IconButton();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.ctrldriverLicenseInfoWithFilter1 = new DVLD.Controls.ctrlDriverLicenseInfoWithFilter();
            this.label3 = new System.Windows.Forms.Label();
            this.gbPersonInformation = new Guna.UI2.WinForms.Guna2GroupBox();
            this.guna2VSeparator1 = new Guna.UI2.WinForms.Guna2VSeparator();
            this.lblILApplicationID = new System.Windows.Forms.Label();
            this.iconPictureBox14 = new FontAwesome.Sharp.IconPictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblRenewLicenseID = new System.Windows.Forms.Label();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLicenseFees = new System.Windows.Forms.Label();
            this.iconPictureBox4 = new FontAwesome.Sharp.IconPictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.iconPictureBox12 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox11 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox10 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox8 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox5 = new FontAwesome.Sharp.IconPictureBox();
            this.lblExpirationDate = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNotes = new Guna.UI2.WinForms.Guna2TextBox();
            this.iconPictureBox6 = new FontAwesome.Sharp.IconPictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbPersonInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lnklblLicenseHistory
            // 
            this.lnklblLicenseHistory.AutoSize = true;
            this.lnklblLicenseHistory.Enabled = false;
            this.lnklblLicenseHistory.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lnklblLicenseHistory.Location = new System.Drawing.Point(4, 928);
            this.lnklblLicenseHistory.Name = "lnklblLicenseHistory";
            this.lnklblLicenseHistory.Size = new System.Drawing.Size(208, 24);
            this.lnklblLicenseHistory.TabIndex = 27;
            this.lnklblLicenseHistory.TabStop = true;
            this.lnklblLicenseHistory.Text = "Show Licenses History";
            this.lnklblLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblLicenseHistory_LinkClicked);
            // 
            // lnklblShowNewLicenseInfo
            // 
            this.lnklblShowNewLicenseInfo.AutoSize = true;
            this.lnklblShowNewLicenseInfo.Enabled = false;
            this.lnklblShowNewLicenseInfo.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lnklblShowNewLicenseInfo.Location = new System.Drawing.Point(218, 929);
            this.lnklblShowNewLicenseInfo.Name = "lnklblShowNewLicenseInfo";
            this.lnklblShowNewLicenseInfo.Size = new System.Drawing.Size(225, 24);
            this.lnklblShowNewLicenseInfo.TabIndex = 26;
            this.lnklblShowNewLicenseInfo.TabStop = true;
            this.lnklblShowNewLicenseInfo.Text = "Show New Licenses Info";
            this.lnklblShowNewLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblShowNewLicenseInfo_LinkClicked);
            // 
            // btnRenew
            // 
            this.btnRenew.BackColor = System.Drawing.Color.Navy;
            this.btnRenew.Enabled = false;
            this.btnRenew.Font = new System.Drawing.Font("Arial Black", 11F, System.Drawing.FontStyle.Bold);
            this.btnRenew.ForeColor = System.Drawing.SystemColors.Control;
            this.btnRenew.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnRenew.IconColor = System.Drawing.Color.LimeGreen;
            this.btnRenew.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRenew.IconSize = 43;
            this.btnRenew.Location = new System.Drawing.Point(811, 918);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnRenew.Size = new System.Drawing.Size(161, 44);
            this.btnRenew.TabIndex = 25;
            this.btnRenew.Text = "Renew";
            this.btnRenew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRenew.UseVisualStyleBackColor = false;
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
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
            this.btnClose.Location = new System.Drawing.Point(644, 918);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnClose.Size = new System.Drawing.Size(161, 44);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // ctrldriverLicenseInfoWithFilter1
            // 
            this.ctrldriverLicenseInfoWithFilter1.FilterEnabled = true;
            this.ctrldriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(6, 54);
            this.ctrldriverLicenseInfoWithFilter1.Name = "ctrldriverLicenseInfoWithFilter1";
            this.ctrldriverLicenseInfoWithFilter1.SetCustomBorderColor = System.Drawing.Color.Navy;
            this.ctrldriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(976, 575);
            this.ctrldriverLicenseInfoWithFilter1.TabIndex = 23;
            this.ctrldriverLicenseInfoWithFilter1.OnSelectedLicense += new System.Action<int>(this.driverLicenseInfoWithFilter1_OnSelectedLicense);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(12, -6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(696, 60);
            this.label3.TabIndex = 28;
            this.label3.Text = "Renew License Application";
            // 
            // gbPersonInformation
            // 
            this.gbPersonInformation.BorderColor = System.Drawing.Color.Navy;
            this.gbPersonInformation.BorderRadius = 4;
            this.gbPersonInformation.BorderThickness = 2;
            this.gbPersonInformation.Controls.Add(this.guna2VSeparator1);
            this.gbPersonInformation.Controls.Add(this.lblILApplicationID);
            this.gbPersonInformation.Controls.Add(this.iconPictureBox14);
            this.gbPersonInformation.Controls.Add(this.label12);
            this.gbPersonInformation.Controls.Add(this.lblRenewLicenseID);
            this.gbPersonInformation.Controls.Add(this.lblTotalFees);
            this.gbPersonInformation.Controls.Add(this.label4);
            this.gbPersonInformation.Controls.Add(this.lblLicenseFees);
            this.gbPersonInformation.Controls.Add(this.iconPictureBox4);
            this.gbPersonInformation.Controls.Add(this.label5);
            this.gbPersonInformation.Controls.Add(this.iconPictureBox12);
            this.gbPersonInformation.Controls.Add(this.iconPictureBox11);
            this.gbPersonInformation.Controls.Add(this.iconPictureBox10);
            this.gbPersonInformation.Controls.Add(this.iconPictureBox8);
            this.gbPersonInformation.Controls.Add(this.iconPictureBox5);
            this.gbPersonInformation.Controls.Add(this.lblExpirationDate);
            this.gbPersonInformation.Controls.Add(this.lblOldLicenseID);
            this.gbPersonInformation.Controls.Add(this.lblCreatedBy);
            this.gbPersonInformation.Controls.Add(this.lblApplicationFees);
            this.gbPersonInformation.Controls.Add(this.lblIssueDate);
            this.gbPersonInformation.Controls.Add(this.lblApplicationDate);
            this.gbPersonInformation.Controls.Add(this.iconPictureBox3);
            this.gbPersonInformation.Controls.Add(this.iconPictureBox2);
            this.gbPersonInformation.Controls.Add(this.iconPictureBox1);
            this.gbPersonInformation.Controls.Add(this.label2);
            this.gbPersonInformation.Controls.Add(this.label10);
            this.gbPersonInformation.Controls.Add(this.label9);
            this.gbPersonInformation.Controls.Add(this.label7);
            this.gbPersonInformation.Controls.Add(this.label11);
            this.gbPersonInformation.Controls.Add(this.label8);
            this.gbPersonInformation.Controls.Add(this.label6);
            this.gbPersonInformation.Controls.Add(this.label1);
            this.gbPersonInformation.Controls.Add(this.tbNotes);
            this.gbPersonInformation.Controls.Add(this.iconPictureBox6);
            this.gbPersonInformation.CustomBorderColor = System.Drawing.Color.Navy;
            this.gbPersonInformation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPersonInformation.ForeColor = System.Drawing.Color.White;
            this.gbPersonInformation.Location = new System.Drawing.Point(8, 623);
            this.gbPersonInformation.Name = "gbPersonInformation";
            this.gbPersonInformation.Size = new System.Drawing.Size(970, 293);
            this.gbPersonInformation.TabIndex = 29;
            this.gbPersonInformation.Text = "Person Information";
            // 
            // guna2VSeparator1
            // 
            this.guna2VSeparator1.BackColor = System.Drawing.Color.White;
            this.guna2VSeparator1.FillColor = System.Drawing.Color.Black;
            this.guna2VSeparator1.FillThickness = 2;
            this.guna2VSeparator1.Location = new System.Drawing.Point(492, 41);
            this.guna2VSeparator1.Name = "guna2VSeparator1";
            this.guna2VSeparator1.Size = new System.Drawing.Size(11, 183);
            this.guna2VSeparator1.TabIndex = 188;
            // 
            // lblILApplicationID
            // 
            this.lblILApplicationID.AutoSize = true;
            this.lblILApplicationID.BackColor = System.Drawing.Color.Transparent;
            this.lblILApplicationID.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblILApplicationID.ForeColor = System.Drawing.Color.Black;
            this.lblILApplicationID.Location = new System.Drawing.Point(239, 47);
            this.lblILApplicationID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblILApplicationID.Name = "lblILApplicationID";
            this.lblILApplicationID.Size = new System.Drawing.Size(76, 24);
            this.lblILApplicationID.TabIndex = 104;
            this.lblILApplicationID.Text = "??????";
            // 
            // iconPictureBox14
            // 
            this.iconPictureBox14.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox14.ForeColor = System.Drawing.Color.Navy;
            this.iconPictureBox14.IconChar = FontAwesome.Sharp.IconChar.Newspaper;
            this.iconPictureBox14.IconColor = System.Drawing.Color.Navy;
            this.iconPictureBox14.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox14.IconSize = 38;
            this.iconPictureBox14.Location = new System.Drawing.Point(8, 232);
            this.iconPictureBox14.Name = "iconPictureBox14";
            this.iconPictureBox14.Size = new System.Drawing.Size(38, 38);
            this.iconPictureBox14.TabIndex = 187;
            this.iconPictureBox14.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(47, 237);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 24);
            this.label12.TabIndex = 186;
            this.label12.Text = "Notes:";
            // 
            // lblRenewLicenseID
            // 
            this.lblRenewLicenseID.AutoSize = true;
            this.lblRenewLicenseID.BackColor = System.Drawing.Color.Transparent;
            this.lblRenewLicenseID.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblRenewLicenseID.ForeColor = System.Drawing.Color.Black;
            this.lblRenewLicenseID.Location = new System.Drawing.Point(745, 47);
            this.lblRenewLicenseID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRenewLicenseID.Name = "lblRenewLicenseID";
            this.lblRenewLicenseID.Size = new System.Drawing.Size(76, 24);
            this.lblRenewLicenseID.TabIndex = 100;
            this.lblRenewLicenseID.Text = "??????";
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.AutoSize = true;
            this.lblTotalFees.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalFees.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalFees.ForeColor = System.Drawing.Color.Black;
            this.lblTotalFees.Location = new System.Drawing.Point(742, 198);
            this.lblTotalFees.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(76, 24);
            this.lblTotalFees.TabIndex = 185;
            this.lblTotalFees.Text = "??????";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(552, 198);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 24);
            this.label4.TabIndex = 183;
            this.label4.Text = "Total Fees:";
            // 
            // lblLicenseFees
            // 
            this.lblLicenseFees.AutoSize = true;
            this.lblLicenseFees.BackColor = System.Drawing.Color.Transparent;
            this.lblLicenseFees.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblLicenseFees.ForeColor = System.Drawing.Color.Black;
            this.lblLicenseFees.Location = new System.Drawing.Point(239, 198);
            this.lblLicenseFees.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLicenseFees.Name = "lblLicenseFees";
            this.lblLicenseFees.Size = new System.Drawing.Size(76, 24);
            this.lblLicenseFees.TabIndex = 182;
            this.lblLicenseFees.Text = "??????";
            // 
            // iconPictureBox4
            // 
            this.iconPictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox4.ForeColor = System.Drawing.Color.Navy;
            this.iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.MoneyBills;
            this.iconPictureBox4.IconColor = System.Drawing.Color.Navy;
            this.iconPictureBox4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox4.IconSize = 38;
            this.iconPictureBox4.Location = new System.Drawing.Point(8, 194);
            this.iconPictureBox4.Name = "iconPictureBox4";
            this.iconPictureBox4.Size = new System.Drawing.Size(38, 38);
            this.iconPictureBox4.TabIndex = 181;
            this.iconPictureBox4.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(51, 198);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 24);
            this.label5.TabIndex = 180;
            this.label5.Text = "License Fees:";
            // 
            // iconPictureBox12
            // 
            this.iconPictureBox12.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox12.ForeColor = System.Drawing.Color.Navy;
            this.iconPictureBox12.IconChar = FontAwesome.Sharp.IconChar.CalendarCheck;
            this.iconPictureBox12.IconColor = System.Drawing.Color.Navy;
            this.iconPictureBox12.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox12.IconSize = 38;
            this.iconPictureBox12.Location = new System.Drawing.Point(8, 124);
            this.iconPictureBox12.Name = "iconPictureBox12";
            this.iconPictureBox12.Size = new System.Drawing.Size(38, 38);
            this.iconPictureBox12.TabIndex = 179;
            this.iconPictureBox12.TabStop = false;
            // 
            // iconPictureBox11
            // 
            this.iconPictureBox11.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox11.ForeColor = System.Drawing.Color.Navy;
            this.iconPictureBox11.IconChar = FontAwesome.Sharp.IconChar.CalendarTimes;
            this.iconPictureBox11.IconColor = System.Drawing.Color.Navy;
            this.iconPictureBox11.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox11.IconSize = 38;
            this.iconPictureBox11.Location = new System.Drawing.Point(508, 120);
            this.iconPictureBox11.Name = "iconPictureBox11";
            this.iconPictureBox11.Size = new System.Drawing.Size(38, 38);
            this.iconPictureBox11.TabIndex = 178;
            this.iconPictureBox11.TabStop = false;
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
            // iconPictureBox8
            // 
            this.iconPictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox8.ForeColor = System.Drawing.Color.Navy;
            this.iconPictureBox8.IconChar = FontAwesome.Sharp.IconChar.Orcid;
            this.iconPictureBox8.IconColor = System.Drawing.Color.Navy;
            this.iconPictureBox8.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox8.IconSize = 38;
            this.iconPictureBox8.Location = new System.Drawing.Point(508, 80);
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
            // lblExpirationDate
            // 
            this.lblExpirationDate.AutoSize = true;
            this.lblExpirationDate.BackColor = System.Drawing.Color.Transparent;
            this.lblExpirationDate.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblExpirationDate.ForeColor = System.Drawing.Color.Black;
            this.lblExpirationDate.Location = new System.Drawing.Point(745, 124);
            this.lblExpirationDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExpirationDate.Name = "lblExpirationDate";
            this.lblExpirationDate.Size = new System.Drawing.Size(76, 24);
            this.lblExpirationDate.TabIndex = 102;
            this.lblExpirationDate.Text = "??????";
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.BackColor = System.Drawing.Color.Transparent;
            this.lblOldLicenseID.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblOldLicenseID.ForeColor = System.Drawing.Color.Black;
            this.lblOldLicenseID.Location = new System.Drawing.Point(745, 82);
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
            this.lblCreatedBy.Location = new System.Drawing.Point(745, 161);
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
            this.lblApplicationFees.Location = new System.Drawing.Point(239, 163);
            this.lblApplicationFees.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(76, 24);
            this.lblApplicationFees.TabIndex = 98;
            this.lblApplicationFees.Text = "??????";
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.AutoSize = true;
            this.lblIssueDate.BackColor = System.Drawing.Color.Transparent;
            this.lblIssueDate.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblIssueDate.ForeColor = System.Drawing.Color.Black;
            this.lblIssueDate.Location = new System.Drawing.Point(239, 129);
            this.lblIssueDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.Size = new System.Drawing.Size(76, 24);
            this.lblIssueDate.TabIndex = 97;
            this.lblIssueDate.Text = "??????";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.BackColor = System.Drawing.Color.Transparent;
            this.lblApplicationDate.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblApplicationDate.ForeColor = System.Drawing.Color.Black;
            this.lblApplicationDate.Location = new System.Drawing.Point(239, 91);
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
            this.iconPictureBox3.Location = new System.Drawing.Point(8, 83);
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
            this.iconPictureBox2.Location = new System.Drawing.Point(8, 159);
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
            this.iconPictureBox1.Location = new System.Drawing.Point(508, 157);
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
            this.label2.Text = "R.L.Application ID:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(554, 124);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(173, 24);
            this.label10.TabIndex = 82;
            this.label10.Text = "Expiration Date:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(554, 82);
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
            this.label7.Size = new System.Drawing.Size(199, 24);
            this.label7.TabIndex = 80;
            this.label7.Text = "Renew License ID:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(554, 161);
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
            this.label8.Location = new System.Drawing.Point(51, 163);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(183, 24);
            this.label8.TabIndex = 77;
            this.label8.Text = "Application Fees:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(47, 129);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 24);
            this.label6.TabIndex = 76;
            this.label6.Text = "Issue Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(47, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 24);
            this.label1.TabIndex = 75;
            this.label1.Text = "Application Date:";
            // 
            // tbNotes
            // 
            this.tbNotes.AutoScroll = true;
            this.tbNotes.BorderColor = System.Drawing.Color.Navy;
            this.tbNotes.BorderRadius = 8;
            this.tbNotes.BorderThickness = 2;
            this.tbNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbNotes.DefaultText = "";
            this.tbNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNotes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNotes.FillColor = System.Drawing.SystemColors.Control;
            this.tbNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNotes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbNotes.ForeColor = System.Drawing.Color.Black;
            this.tbNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNotes.Location = new System.Drawing.Point(129, 224);
            this.tbNotes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.PlaceholderText = "";
            this.tbNotes.SelectedText = "";
            this.tbNotes.Size = new System.Drawing.Size(834, 63);
            this.tbNotes.TabIndex = 84;
            // 
            // iconPictureBox6
            // 
            this.iconPictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox6.ForeColor = System.Drawing.Color.Navy;
            this.iconPictureBox6.IconChar = FontAwesome.Sharp.IconChar.MoneyBills;
            this.iconPictureBox6.IconColor = System.Drawing.Color.Navy;
            this.iconPictureBox6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox6.IconSize = 38;
            this.iconPictureBox6.Location = new System.Drawing.Point(509, 194);
            this.iconPictureBox6.Name = "iconPictureBox6";
            this.iconPictureBox6.Size = new System.Drawing.Size(38, 38);
            this.iconPictureBox6.TabIndex = 184;
            this.iconPictureBox6.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.renewicon;
            this.pictureBox1.Location = new System.Drawing.Point(655, -15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(267, 210);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            // 
            // frmRenewDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 962);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gbPersonInformation);
            this.Controls.Add(this.lnklblLicenseHistory);
            this.Controls.Add(this.lnklblShowNewLicenseInfo);
            this.Controls.Add(this.btnRenew);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrldriverLicenseInfoWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRenewDrivingLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRenewDrivingLicense";
            this.Activated += new System.EventHandler(this.frmRenewDrivingLicense_Activated);
            this.Load += new System.EventHandler(this.frmRenewDrivingLicense_Load);
            this.gbPersonInformation.ResumeLayout(false);
            this.gbPersonInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnklblLicenseHistory;
        private System.Windows.Forms.LinkLabel lnklblShowNewLicenseInfo;
        private FontAwesome.Sharp.IconButton btnRenew;
        private FontAwesome.Sharp.IconButton btnClose;
        private Controls.ctrlDriverLicenseInfoWithFilter ctrldriverLicenseInfoWithFilter1;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2GroupBox gbPersonInformation;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox12;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox11;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox10;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox8;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox5;
        private System.Windows.Forms.Label lblILApplicationID;
        private System.Windows.Forms.Label lblExpirationDate;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label lblRenewLicenseID;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.Label lblApplicationDate;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLicenseFees;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalFees;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2TextBox tbNotes;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox14;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2VSeparator guna2VSeparator1;
    }
}