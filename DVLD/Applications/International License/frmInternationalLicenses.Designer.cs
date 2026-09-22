namespace DVLD.Licenses
{
    partial class frmInternationalLicenses
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvInternationalApp = new Guna.UI2.WinForms.Guna2DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTotalRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilter = new ReaLTaiizor.Controls.CyberComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnAddNewInternational = new Guna.UI2.WinForms.Guna2Button();
            this.cbIsActive = new ReaLTaiizor.Controls.CyberComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalApp)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial Black", 25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(195, -14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1197, 65);
            this.label3.TabIndex = 46;
            this.label3.Text = "International License Applications";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgvInternationalApp
            // 
            this.dgvInternationalApp.AllowUserToAddRows = false;
            this.dgvInternationalApp.AllowUserToDeleteRows = false;
            this.dgvInternationalApp.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvInternationalApp.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInternationalApp.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInternationalApp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvInternationalApp.ColumnHeadersHeight = 35;
            this.dgvInternationalApp.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInternationalApp.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvInternationalApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInternationalApp.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvInternationalApp.Location = new System.Drawing.Point(8, 8);
            this.dgvInternationalApp.MultiSelect = false;
            this.dgvInternationalApp.Name = "dgvInternationalApp";
            this.dgvInternationalApp.ReadOnly = true;
            this.dgvInternationalApp.RowHeadersVisible = false;
            this.dgvInternationalApp.RowHeadersWidth = 62;
            this.dgvInternationalApp.RowTemplate.Height = 29;
            this.dgvInternationalApp.Size = new System.Drawing.Size(1424, 331);
            this.dgvInternationalApp.TabIndex = 0;
            this.dgvInternationalApp.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvInternationalApp.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Navy;
            this.dgvInternationalApp.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Tahoma", 12F);
            this.dgvInternationalApp.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInternationalApp.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvInternationalApp.ThemeStyle.ReadOnly = true;
            this.dgvInternationalApp.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Tahoma", 12F);
            this.dgvInternationalApp.ThemeStyle.RowsStyle.Height = 29;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem10,
            this.toolStripMenuItem11});
            this.contextMenuStrip1.Name = "cmsLDLApplication";
            this.contextMenuStrip1.Size = new System.Drawing.Size(355, 148);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::DVLD.Properties.Resources.detailspersonicon;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(354, 48);
            this.toolStripMenuItem1.Text = "Show Person Details";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.PersonDetails_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Image = global::DVLD.Properties.Resources.driverlicensesicon;
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(354, 48);
            this.toolStripMenuItem10.Text = "Show License Details";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.DriverLicenseInfo_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Image = global::DVLD.Properties.Resources.managetesttypesicon;
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(354, 48);
            this.toolStripMenuItem11.Text = "Show Person License History";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.PersonLicenseHistory_Click);
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
            this.tbSearch.Location = new System.Drawing.Point(13, 247);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbSearch.PlaceholderText = "";
            this.tbSearch.SelectedText = "";
            this.tbSearch.Size = new System.Drawing.Size(292, 39);
            this.tbSearch.TabIndex = 47;
            this.tbSearch.Visible = false;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.AutoSize = true;
            this.lblTotalRecords.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecords.Location = new System.Drawing.Point(148, 654);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(28, 29);
            this.lblTotalRecords.TabIndex = 44;
            this.lblTotalRecords.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 654);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 29);
            this.label2.TabIndex = 43;
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
            "Driver ID",
            "LocalLicense ID",
            "Application ID",
            "Is Active"});
            this.cbFilter.Location = new System.Drawing.Point(13, 209);
            this.cbFilter.MaxDropDownItems = 12;
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.RGB = false;
            this.cbFilter.RoundingInt = 40;
            this.cbFilter.Size = new System.Drawing.Size(292, 34);
            this.cbFilter.TabIndex = 42;
            this.cbFilter.Timer_RGB = 300;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.Location = new System.Drawing.Point(8, 177);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(121, 29);
            this.lblFilter.TabIndex = 41;
            this.lblFilter.Text = "Filter By:";
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.dgvInternationalApp);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(8, 295);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.Padding = new System.Windows.Forms.Padding(8);
            this.guna2ShadowPanel1.Radius = 2;
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.ShadowShift = 2;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(1440, 347);
            this.guna2ShadowPanel1.TabIndex = 40;
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
            this.btnClose.Location = new System.Drawing.Point(1287, 647);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnClose.Size = new System.Drawing.Size(161, 44);
            this.btnClose.TabIndex = 45;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::DVLD.Properties.Resources.internationalicon;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(552, 29);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(399, 293);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 49;
            this.guna2PictureBox1.TabStop = false;
            // 
            // btnAddNewInternational
            // 
            this.btnAddNewInternational.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewInternational.BorderColor = System.Drawing.Color.Transparent;
            this.btnAddNewInternational.BorderRadius = 8;
            this.btnAddNewInternational.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewInternational.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewInternational.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNewInternational.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddNewInternational.FillColor = System.Drawing.Color.Transparent;
            this.btnAddNewInternational.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddNewInternational.ForeColor = System.Drawing.Color.White;
            this.btnAddNewInternational.Image = global::DVLD.Properties.Resources.addnewlocallicenseicon;
            this.btnAddNewInternational.ImageSize = new System.Drawing.Size(100, 100);
            this.btnAddNewInternational.Location = new System.Drawing.Point(1328, 177);
            this.btnAddNewInternational.Name = "btnAddNewInternational";
            this.btnAddNewInternational.Size = new System.Drawing.Size(120, 110);
            this.btnAddNewInternational.TabIndex = 48;
            this.btnAddNewInternational.Click += new System.EventHandler(this.btnAddewInternational_Click);
            // 
            // cbIsActive
            // 
            this.cbIsActive.BackColor = System.Drawing.SystemColors.Control;
            this.cbIsActive.ColorArrow = System.Drawing.Color.Navy;
            this.cbIsActive.ColorBackground = System.Drawing.SystemColors.Control;
            this.cbIsActive.ColorBackground_Pen = System.Drawing.Color.Navy;
            this.cbIsActive.ColorItemHover = System.Drawing.Color.PaleTurquoise;
            this.cbIsActive.ColorPen_1 = System.Drawing.Color.White;
            this.cbIsActive.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.cbIsActive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbIsActive.CyberComboBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.cbIsActive.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbIsActive.Font = new System.Drawing.Font("Arial", 11F);
            this.cbIsActive.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbIsActive.FormattingEnabled = true;
            this.cbIsActive.ItemHeight = 28;
            this.cbIsActive.Items.AddRange(new object[] {
            "All",
            "No",
            "Yes"});
            this.cbIsActive.Location = new System.Drawing.Point(13, 249);
            this.cbIsActive.MaxDropDownItems = 12;
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.RGB = false;
            this.cbIsActive.RoundingInt = 40;
            this.cbIsActive.Size = new System.Drawing.Size(292, 34);
            this.cbIsActive.TabIndex = 50;
            this.cbIsActive.Timer_RGB = 300;
            this.cbIsActive.Visible = false;
            this.cbIsActive.SelectedIndexChanged += new System.EventHandler(this.cbIsActive_SelectedIndexChange);
            // 
            // frmInternationalLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1451, 693);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddNewInternational);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.lblTotalRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.guna2PictureBox1);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmInternationalLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmInternationalLicenses";
            this.Load += new System.EventHandler(this.frmInternationalLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalApp)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.guna2ShadowPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton btnClose;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvInternationalApp;
        private Guna.UI2.WinForms.Guna2Button btnAddNewInternational;
        private Guna.UI2.WinForms.Guna2TextBox tbSearch;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.Label label2;
        private ReaLTaiizor.Controls.CyberComboBox cbFilter;
        private System.Windows.Forms.Label lblFilter;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private ReaLTaiizor.Controls.CyberComboBox cbIsActive;
    }
}