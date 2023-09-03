namespace _13IA_Project
{
    partial class frmMenu
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pctLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSortBySubject = new System.Windows.Forms.Button();
            this.btnSortByClass = new System.Windows.Forms.Button();
            this.lstLeaderboard = new System.Windows.Forms.ListBox();
            this.lblLeadboard = new System.Windows.Forms.Label();
            this.lblHint = new System.Windows.Forms.Label();
            this.btnStart = new FontAwesome.Sharp.IconButton();
            this.lstQuizzes = new System.Windows.Forms.ListBox();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.pctLogo);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblUsername);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(988, 73);
            this.pnlHeader.TabIndex = 4;
            // 
            // pctLogo
            // 
            this.pctLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pctLogo.Location = new System.Drawing.Point(0, 0);
            this.pctLogo.Margin = new System.Windows.Forms.Padding(4);
            this.pctLogo.Name = "pctLogo";
            this.pctLogo.Size = new System.Drawing.Size(300, 73);
            this.pctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctLogo.TabIndex = 2;
            this.pctLogo.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitle.Location = new System.Drawing.Point(519, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(180, 34);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "HBHS Quizzes";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblUsername.Location = new System.Drawing.Point(867, 0);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(121, 25);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "lblUsername";
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.Transparent;
            this.pnlBody.Controls.Add(this.panel1);
            this.pnlBody.Controls.Add(this.lblHint);
            this.pnlBody.Controls.Add(this.btnStart);
            this.pnlBody.Controls.Add(this.lstQuizzes);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlBody.Location = new System.Drawing.Point(0, 73);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(988, 391);
            this.pnlBody.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSortBySubject);
            this.panel1.Controls.Add(this.btnSortByClass);
            this.panel1.Controls.Add(this.lstLeaderboard);
            this.panel1.Controls.Add(this.lblLeadboard);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 391);
            this.panel1.TabIndex = 14;
            // 
            // btnSortBySubject
            // 
            this.btnSortBySubject.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSortBySubject.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSortBySubject.ForeColor = System.Drawing.Color.White;
            this.btnSortBySubject.Location = new System.Drawing.Point(129, 359);
            this.btnSortBySubject.Margin = new System.Windows.Forms.Padding(4);
            this.btnSortBySubject.Name = "btnSortBySubject";
            this.btnSortBySubject.Size = new System.Drawing.Size(119, 28);
            this.btnSortBySubject.TabIndex = 15;
            this.btnSortBySubject.Text = "&Subject";
            this.btnSortBySubject.UseVisualStyleBackColor = true;
            this.btnSortBySubject.Click += new System.EventHandler(this.btnSortBySubject_Click);
            // 
            // btnSortByClass
            // 
            this.btnSortByClass.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSortByClass.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSortByClass.ForeColor = System.Drawing.Color.White;
            this.btnSortByClass.Location = new System.Drawing.Point(13, 359);
            this.btnSortByClass.Margin = new System.Windows.Forms.Padding(4);
            this.btnSortByClass.Name = "btnSortByClass";
            this.btnSortByClass.Size = new System.Drawing.Size(108, 28);
            this.btnSortByClass.TabIndex = 15;
            this.btnSortByClass.Text = "&Class";
            this.btnSortByClass.UseVisualStyleBackColor = true;
            this.btnSortByClass.Click += new System.EventHandler(this.btnSortByClass_Click);
            // 
            // lstLeaderboard
            // 
            this.lstLeaderboard.BackColor = System.Drawing.Color.White;
            this.lstLeaderboard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstLeaderboard.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLeaderboard.ForeColor = System.Drawing.Color.Black;
            this.lstLeaderboard.FormattingEnabled = true;
            this.lstLeaderboard.ItemHeight = 22;
            this.lstLeaderboard.Location = new System.Drawing.Point(4, 38);
            this.lstLeaderboard.Margin = new System.Windows.Forms.Padding(4);
            this.lstLeaderboard.Name = "lstLeaderboard";
            this.lstLeaderboard.Size = new System.Drawing.Size(254, 308);
            this.lstLeaderboard.TabIndex = 16;
            // 
            // lblLeadboard
            // 
            this.lblLeadboard.AutoSize = true;
            this.lblLeadboard.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeadboard.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblLeadboard.Location = new System.Drawing.Point(70, 9);
            this.lblLeadboard.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLeadboard.Name = "lblLeadboard";
            this.lblLeadboard.Size = new System.Drawing.Size(123, 25);
            this.lblLeadboard.TabIndex = 15;
            this.lblLeadboard.Text = "Leaderboard";
            // 
            // lblHint
            // 
            this.lblHint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHint.AutoSize = true;
            this.lblHint.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHint.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblHint.Location = new System.Drawing.Point(645, 273);
            this.lblHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(87, 18);
            this.lblHint.TabIndex = 13;
            this.lblHint.Text = "Select a quiz!";
            this.lblHint.Visible = false;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStart.IconChar = FontAwesome.Sharp.IconChar.Play;
            this.btnStart.IconColor = System.Drawing.Color.LimeGreen;
            this.btnStart.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStart.IconSize = 20;
            this.btnStart.Location = new System.Drawing.Point(605, 266);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(33, 31);
            this.btnStart.TabIndex = 12;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lstQuizzes
            // 
            this.lstQuizzes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstQuizzes.BackColor = System.Drawing.Color.White;
            this.lstQuizzes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstQuizzes.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstQuizzes.ForeColor = System.Drawing.Color.Black;
            this.lstQuizzes.FormattingEnabled = true;
            this.lstQuizzes.ItemHeight = 22;
            this.lstQuizzes.Location = new System.Drawing.Point(302, 38);
            this.lstQuizzes.Margin = new System.Windows.Forms.Padding(4);
            this.lstQuizzes.Name = "lstQuizzes";
            this.lstQuizzes.Size = new System.Drawing.Size(639, 220);
            this.lstQuizzes.TabIndex = 11;
            this.lstQuizzes.SelectedIndexChanged += new System.EventHandler(this.lstQuizzes_SelectedIndexChanged);
            this.lstQuizzes.DoubleClick += new System.EventHandler(this.btnStart_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::_13IA_Project.Properties.Resources.hbhs_background_bitmap;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(988, 464);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(994, 494);
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label lblHint;
        private FontAwesome.Sharp.IconButton btnStart;
        private System.Windows.Forms.ListBox lstQuizzes;
        private System.Windows.Forms.PictureBox pctLogo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLeadboard;
        private System.Windows.Forms.ListBox lstLeaderboard;
        private System.Windows.Forms.Button btnSortBySubject;
        private System.Windows.Forms.Button btnSortByClass;
    }
}

