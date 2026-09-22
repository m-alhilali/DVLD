namespace DVLD.Tests
{
    partial class frmTakeTest
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
            this.label7 = new System.Windows.Forms.Label();
            this.iconPictureBox5 = new FontAwesome.Sharp.IconPictureBox();
            this.rbtnPass = new System.Windows.Forms.RadioButton();
            this.rbtnFailed = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.tbNotes = new Guna.UI2.WinForms.Guna2TextBox();
            this.iconPictureBox8 = new FontAwesome.Sharp.IconPictureBox();
            this.btnSaveTest = new FontAwesome.Sharp.IconButton();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.ctrlSecheduledTest1 = new DVLD.Controls.ctrlSecheduledTest();
            this.lblSubTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox8)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(7, 731);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 24);
            this.label7.TabIndex = 116;
            this.label7.Text = "Result:";
            // 
            // iconPictureBox5
            // 
            this.iconPictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox5.ForeColor = System.Drawing.Color.Navy;
            this.iconPictureBox5.IconChar = FontAwesome.Sharp.IconChar.Hashtag;
            this.iconPictureBox5.IconColor = System.Drawing.Color.Navy;
            this.iconPictureBox5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox5.IconSize = 42;
            this.iconPictureBox5.Location = new System.Drawing.Point(90, 728);
            this.iconPictureBox5.Name = "iconPictureBox5";
            this.iconPictureBox5.Size = new System.Drawing.Size(42, 44);
            this.iconPictureBox5.TabIndex = 116;
            this.iconPictureBox5.TabStop = false;
            // 
            // rbtnPass
            // 
            this.rbtnPass.AutoSize = true;
            this.rbtnPass.Checked = true;
            this.rbtnPass.Font = new System.Drawing.Font("Tahoma", 10F);
            this.rbtnPass.Location = new System.Drawing.Point(138, 731);
            this.rbtnPass.Name = "rbtnPass";
            this.rbtnPass.Size = new System.Drawing.Size(75, 28);
            this.rbtnPass.TabIndex = 117;
            this.rbtnPass.TabStop = true;
            this.rbtnPass.Text = "Pass";
            this.rbtnPass.UseVisualStyleBackColor = true;
            // 
            // rbtnFailed
            // 
            this.rbtnFailed.AutoSize = true;
            this.rbtnFailed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.rbtnFailed.Location = new System.Drawing.Point(256, 729);
            this.rbtnFailed.Name = "rbtnFailed";
            this.rbtnFailed.Size = new System.Drawing.Size(66, 28);
            this.rbtnFailed.TabIndex = 118;
            this.rbtnFailed.Text = "Fail";
            this.rbtnFailed.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(7, 765);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 24);
            this.label9.TabIndex = 119;
            this.label9.Text = "Notes:";
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
            this.tbNotes.Location = new System.Drawing.Point(85, 766);
            this.tbNotes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.PlaceholderText = "";
            this.tbNotes.SelectedText = "";
            this.tbNotes.Size = new System.Drawing.Size(529, 106);
            this.tbNotes.TabIndex = 120;
            // 
            // iconPictureBox8
            // 
            this.iconPictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox8.ForeColor = System.Drawing.Color.Navy;
            this.iconPictureBox8.IconChar = FontAwesome.Sharp.IconChar.PenAlt;
            this.iconPictureBox8.IconColor = System.Drawing.Color.Navy;
            this.iconPictureBox8.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox8.IconSize = 66;
            this.iconPictureBox8.Location = new System.Drawing.Point(12, 792);
            this.iconPictureBox8.Name = "iconPictureBox8";
            this.iconPictureBox8.Size = new System.Drawing.Size(66, 79);
            this.iconPictureBox8.TabIndex = 121;
            this.iconPictureBox8.TabStop = false;
            // 
            // btnSaveTest
            // 
            this.btnSaveTest.BackColor = System.Drawing.Color.Navy;
            this.btnSaveTest.Font = new System.Drawing.Font("Arial Black", 11F, System.Drawing.FontStyle.Bold);
            this.btnSaveTest.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSaveTest.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnSaveTest.IconColor = System.Drawing.Color.Lime;
            this.btnSaveTest.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSaveTest.IconSize = 40;
            this.btnSaveTest.Location = new System.Drawing.Point(448, 873);
            this.btnSaveTest.Name = "btnSaveTest";
            this.btnSaveTest.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnSaveTest.Size = new System.Drawing.Size(161, 41);
            this.btnSaveTest.TabIndex = 118;
            this.btnSaveTest.Text = "Save";
            this.btnSaveTest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveTest.UseVisualStyleBackColor = false;
            this.btnSaveTest.Click += new System.EventHandler(this.btnSaveTest_Click);
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
            this.btnClose.Location = new System.Drawing.Point(287, 872);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnClose.Size = new System.Drawing.Size(161, 41);
            this.btnClose.TabIndex = 117;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlSecheduledTest1
            // 
            this.ctrlSecheduledTest1.Location = new System.Drawing.Point(4, 4);
            this.ctrlSecheduledTest1.Name = "ctrlSecheduledTest1";
            this.ctrlSecheduledTest1.Size = new System.Drawing.Size(610, 721);
            this.ctrlSecheduledTest1.TabIndex = 122;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblSubTitle.ForeColor = System.Drawing.Color.Red;
            this.lblSubTitle.Location = new System.Drawing.Point(337, 731);
            this.lblSubTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(277, 22);
            this.lblSubTitle.TabIndex = 123;
            this.lblSubTitle.Text = "You cannot change the result";
            this.lblSubTitle.Visible = false;
            // 
            // frmTakeTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 913);
            this.Controls.Add(this.lblSubTitle);
            this.Controls.Add(this.ctrlSecheduledTest1);
            this.Controls.Add(this.btnSaveTest);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.iconPictureBox8);
            this.Controls.Add(this.tbNotes);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.rbtnFailed);
            this.Controls.Add(this.rbtnPass);
            this.Controls.Add(this.iconPictureBox5);
            this.Controls.Add(this.label7);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTakeTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Take Test";
            this.Load += new System.EventHandler(this.frmTakeTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox5;
        private System.Windows.Forms.RadioButton rbtnPass;
        private System.Windows.Forms.RadioButton rbtnFailed;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox tbNotes;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox8;
        private FontAwesome.Sharp.IconButton btnSaveTest;
        private FontAwesome.Sharp.IconButton btnClose;
        private Controls.ctrlSecheduledTest ctrlSecheduledTest1;
        private System.Windows.Forms.Label lblSubTitle;
    }
}