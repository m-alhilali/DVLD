namespace DVLD.Applications
{
    partial class frmLocalDrivingLicenseApplication
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTotalRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilter = new ReaLTaiizor.Controls.CyberComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.dgvLDLApp = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cmsLDLApplication = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEditApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCancelApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSechduleTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSechduleTestVision = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSechduleTestWritten = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSechduleTestStreet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmIssueDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.btnAddPeople = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLDLApp)).BeginInit();
            this.cmsLDLApplication.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSearch
            // 
            this.tbSearch.BorderColor = System.Drawing.Color.Navy;
            this.tbSearch.BorderRadius = 8;
            this.tbSearch.BorderThickness = 2;
            this.tbSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbSearch.DefaultText = "";
            this.tbSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbSearch.FillColor = System.Drawing.SystemColors.Control;
            this.tbSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbSearch.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.ForeColor = System.Drawing.Color.Black;
            this.tbSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbSearch.Location = new System.Drawing.Point(11, 251);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbSearch.PlaceholderText = "";
            this.tbSearch.SelectedText = "";
            this.tbSearch.Size = new System.Drawing.Size(292, 39);
            this.tbSearch.TabIndex = 21;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.AutoSize = true;
            this.lblTotalRecords.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecords.Location = new System.Drawing.Point(146, 723);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(28, 29);
            this.lblTotalRecords.TabIndex = 16;
            this.lblTotalRecords.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 723);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 29);
            this.label2.TabIndex = 15;
            this.label2.Text = "#Records:";
            // 
            // cbFilter
            // 
            this.cbFilter.BackColor = System.Drawing.SystemColors.Control;
            this.cbFilter.ColorArrow = System.Drawing.Color.Navy;
            this.cbFilter.ColorBackground = System.Drawing.SystemColors.Control;
            this.cbFilter.ColorBackground_Pen = System.Drawing.Color.Navy;
            this.cbFilter.ColorItemHover = System.Drawing.Color.PaleTurquoise;
            this.cbFilter.ColorPen_1 = System.Drawing.Color.White;
            this.cbFilter.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.cbFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbFilter.CyberComboBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.cbFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFilter.Font = new System.Drawing.Font("Arial", 11F);
            this.cbFilter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.ItemHeight = 28;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "National No",
            "Name",
            "Class Name",
            "L.D.L.AppID",
            "Status"});
            this.cbFilter.Location = new System.Drawing.Point(11, 213);
            this.cbFilter.MaxDropDownItems = 12;
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.RGB = false;
            this.cbFilter.RoundingInt = 40;
            this.cbFilter.Size = new System.Drawing.Size(292, 34);
            this.cbFilter.TabIndex = 14;
            this.cbFilter.Timer_RGB = 300;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.Location = new System.Drawing.Point(6, 181);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(121, 29);
            this.lblFilter.TabIndex = 13;
            this.lblFilter.Text = "Filter By:";
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.dgvLDLApp);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(6, 299);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.Padding = new System.Windows.Forms.Padding(8);
            this.guna2ShadowPanel1.Radius = 2;
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.ShadowShift = 2;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(1440, 400);
            this.guna2ShadowPanel1.TabIndex = 12;
            // 
            // dgvLDLApp
            // 
            this.dgvLDLApp.AllowUserToAddRows = false;
            this.dgvLDLApp.AllowUserToDeleteRows = false;
            this.dgvLDLApp.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvLDLApp.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLDLApp.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLDLApp.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLDLApp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLDLApp.ColumnHeadersHeight = 35;
            this.dgvLDLApp.ContextMenuStrip = this.cmsLDLApplication;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLDLApp.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLDLApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLDLApp.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvLDLApp.Location = new System.Drawing.Point(8, 8);
            this.dgvLDLApp.MultiSelect = false;
            this.dgvLDLApp.Name = "dgvLDLApp";
            this.dgvLDLApp.ReadOnly = true;
            this.dgvLDLApp.RowHeadersVisible = false;
            this.dgvLDLApp.RowHeadersWidth = 62;
            this.dgvLDLApp.RowTemplate.Height = 29;
            this.dgvLDLApp.Size = new System.Drawing.Size(1424, 384);
            this.dgvLDLApp.TabIndex = 0;
            this.dgvLDLApp.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvLDLApp.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Navy;
            this.dgvLDLApp.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Tahoma", 12F);
            this.dgvLDLApp.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLDLApp.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvLDLApp.ThemeStyle.ReadOnly = true;
            this.dgvLDLApp.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvLDLApp.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Tahoma", 12F);
            this.dgvLDLApp.ThemeStyle.RowsStyle.Height = 29;
            this.dgvLDLApp.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLDLApp_CellContentClick);
            this.dgvLDLApp.SelectionChanged += new System.EventHandler(this.dgvPeople_SelectionChanged);
            // 
            // cmsLDLApplication
            // 
            this.cmsLDLApplication.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmsLDLApplication.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.cmsLDLApplication.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailsToolStripMenuItem,
            this.tsmEditApplication,
            this.deleteToolStripMenuItem,
            this.tsmCancelApplication,
            this.tsmSechduleTest,
            this.tsmIssueDrivingLicense,
            this.tsmShowLicense,
            this.tsmShowPersonLicenseHistory});
            this.cmsLDLApplication.Name = "cmsLDLApplication";
            this.cmsLDLApplication.Size = new System.Drawing.Size(373, 308);
            this.cmsLDLApplication.Opening += new System.ComponentModel.CancelEventHandler(this.cmsLDLApplication_Opening);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.Image = global::DVLD.Properties.Resources.detailspersonicon;
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(372, 38);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            this.showApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDetailsToolStripMenuItem_Click);
            // 
            // tsmEditApplication
            // 
            this.tsmEditApplication.Image = global::DVLD.Properties.Resources.editicon;
            this.tsmEditApplication.Name = "tsmEditApplication";
            this.tsmEditApplication.Size = new System.Drawing.Size(372, 38);
            this.tsmEditApplication.Text = "Edit Application";
            this.tsmEditApplication.Click += new System.EventHandler(this.tsmEditApplication_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::DVLD.Properties.Resources.deleteicon;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(372, 38);
            this.deleteToolStripMenuItem.Text = "Delete Application";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // tsmCancelApplication
            // 
            this.tsmCancelApplication.Image = global::DVLD.Properties.Resources.SubtractionIcon;
            this.tsmCancelApplication.Name = "tsmCancelApplication";
            this.tsmCancelApplication.Size = new System.Drawing.Size(372, 38);
            this.tsmCancelApplication.Text = "Cancel Application";
            this.tsmCancelApplication.Click += new System.EventHandler(this.CancelToolStripMenuItem_Click);
            // 
            // tsmSechduleTest
            // 
            this.tsmSechduleTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSechduleTestVision,
            this.tsmSechduleTestWritten,
            this.tsmSechduleTestStreet});
            this.tsmSechduleTest.Image = global::DVLD.Properties.Resources.managetesttypesicon;
            this.tsmSechduleTest.Name = "tsmSechduleTest";
            this.tsmSechduleTest.Size = new System.Drawing.Size(372, 38);
            this.tsmSechduleTest.Text = "Sechdule Test";
            // 
            // tsmSechduleTestVision
            // 
            this.tsmSechduleTestVision.Image = global::DVLD.Properties.Resources.testvisionicon;
            this.tsmSechduleTestVision.Name = "tsmSechduleTestVision";
            this.tsmSechduleTestVision.Size = new System.Drawing.Size(308, 40);
            this.tsmSechduleTestVision.Text = "Sechdule vision Test";
            this.tsmSechduleTestVision.Click += new System.EventHandler(this.tsmSechduleTestVision_Click);
            // 
            // tsmSechduleTestWritten
            // 
            this.tsmSechduleTestWritten.Image = global::DVLD.Properties.Resources.testwrittenicon;
            this.tsmSechduleTestWritten.Name = "tsmSechduleTestWritten";
            this.tsmSechduleTestWritten.Size = new System.Drawing.Size(308, 40);
            this.tsmSechduleTestWritten.Text = "Sechdule Written Test";
            this.tsmSechduleTestWritten.Click += new System.EventHandler(this.tsmSechduleTestWritten_Click);
            // 
            // tsmSechduleTestStreet
            // 
            this.tsmSechduleTestStreet.Image = global::DVLD.Properties.Resources.teststreeticon;
            this.tsmSechduleTestStreet.Name = "tsmSechduleTestStreet";
            this.tsmSechduleTestStreet.Size = new System.Drawing.Size(308, 40);
            this.tsmSechduleTestStreet.Text = "Sechdule Street Test";
            this.tsmSechduleTestStreet.Click += new System.EventHandler(this.tsmSechduleTestStreet_Click);
            // 
            // tsmIssueDrivingLicense
            // 
            this.tsmIssueDrivingLicense.Image = global::DVLD.Properties.Resources.locallicenseicon;
            this.tsmIssueDrivingLicense.Name = "tsmIssueDrivingLicense";
            this.tsmIssueDrivingLicense.Size = new System.Drawing.Size(372, 38);
            this.tsmIssueDrivingLicense.Text = "Issue Driving License(First Time)";
            this.tsmIssueDrivingLicense.Click += new System.EventHandler(this.tsmIssueDrivingLicense_Click);
            // 
            // tsmShowLicense
            // 
            this.tsmShowLicense.Image = global::DVLD.Properties.Resources.locallicenseicon;
            this.tsmShowLicense.Name = "tsmShowLicense";
            this.tsmShowLicense.Size = new System.Drawing.Size(372, 38);
            this.tsmShowLicense.Text = "Show License";
            this.tsmShowLicense.Click += new System.EventHandler(this.tsmShowLicense_Click);
            // 
            // tsmShowPersonLicenseHistory
            // 
            this.tsmShowPersonLicenseHistory.Image = global::DVLD.Properties.Resources.classlicenseicon_png;
            this.tsmShowPersonLicenseHistory.Name = "tsmShowPersonLicenseHistory";
            this.tsmShowPersonLicenseHistory.Size = new System.Drawing.Size(372, 38);
            this.tsmShowPersonLicenseHistory.Text = "Show Person License History";
            this.tsmShowPersonLicenseHistory.Click += new System.EventHandler(this.tsmShowPersonLicenseHistory_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial Black", 22F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(595, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(862, 70);
            this.label3.TabIndex = 19;
            this.label3.Text = "_LocalDrivungLicenseApplication Driving License Applications";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Navy;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Arial Black", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            this.btnClose.IconColor = System.Drawing.Color.Red;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 43;
            this.btnClose.Location = new System.Drawing.Point(1285, 705);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnClose.Size = new System.Drawing.Size(161, 44);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            // 
            // btnAddPeople
            // 
            this.btnAddPeople.BackColor = System.Drawing.Color.Transparent;
            this.btnAddPeople.BorderColor = System.Drawing.Color.Transparent;
            this.btnAddPeople.BorderRadius = 8;
            this.btnAddPeople.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddPeople.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddPeople.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddPeople.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddPeople.FillColor = System.Drawing.Color.Transparent;
            this.btnAddPeople.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddPeople.ForeColor = System.Drawing.Color.White;
            this.btnAddPeople.Image = global::DVLD.Properties.Resources.addnewlocallicenseicon;
            this.btnAddPeople.ImageSize = new System.Drawing.Size(100, 100);
            this.btnAddPeople.Location = new System.Drawing.Point(1326, 181);
            this.btnAddPeople.Name = "btnAddPeople";
            this.btnAddPeople.Size = new System.Drawing.Size(120, 110);
            this.btnAddPeople.TabIndex = 23;
            this.btnAddPeople.Click += new System.EventHandler(this.btnAddPeople_Click);
            this.btnAddPeople.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.btnAddPeople.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::DVLD.Properties.Resources.locallicenseicon;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(239, -33);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(405, 366);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 24;
            this.guna2PictureBox1.TabStop = false;
            // 
            // frmLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1453, 761);
            this.Controls.Add(this.btnAddPeople);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.lblTotalRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.guna2PictureBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmLocalDrivingLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "_LocalDrivungLicenseApplication Driving License Application";
            this.Load += new System.EventHandler(this.frmLocalDrivingLicenseApplication_Load);
            this.guna2ShadowPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLDLApp)).EndInit();
            this.cmsLDLApplication.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox tbSearch;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.Label label2;
        private ReaLTaiizor.Controls.CyberComboBox cbFilter;
        private System.Windows.Forms.Label lblFilter;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvLDLApp;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton btnClose;
        private Guna.UI2.WinForms.Guna2Button btnAddPeople;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.ContextMenuStrip cmsLDLApplication;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmEditApplication;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmCancelApplication;
        private System.Windows.Forms.ToolStripMenuItem tsmSechduleTest;
        private System.Windows.Forms.ToolStripMenuItem tsmSechduleTestVision;
        private System.Windows.Forms.ToolStripMenuItem tsmSechduleTestWritten;
        private System.Windows.Forms.ToolStripMenuItem tsmSechduleTestStreet;
        private System.Windows.Forms.ToolStripMenuItem tsmIssueDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmShowLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmShowPersonLicenseHistory;
    }
}