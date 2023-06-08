namespace _13IA_Project
{
    partial class frmQuestions
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.pnlQuestions = new System.Windows.Forms.Panel();
            this.btnCheck = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlQuestions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblUsername);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 37);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(368, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(65, 25);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Title!";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblUsername.Location = new System.Drawing.Point(730, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.lblUsername.Size = new System.Drawing.Size(70, 18);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "lblUsername";
            // 
            // pnlQuestions
            // 
            this.pnlQuestions.AutoScroll = true;
            this.pnlQuestions.AutoSize = true;
            this.pnlQuestions.Controls.Add(this.btnCheck);
            this.pnlQuestions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQuestions.Location = new System.Drawing.Point(0, 37);
            this.pnlQuestions.Margin = new System.Windows.Forms.Padding(3, 3, 3, 50);
            this.pnlQuestions.Name = "pnlQuestions";
            this.pnlQuestions.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.pnlQuestions.Size = new System.Drawing.Size(800, 424);
            this.pnlQuestions.TabIndex = 2;
            // 
            // btnCheck
            // 
            this.btnCheck.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCheck.Location = new System.Drawing.Point(0, 395);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(800, 24);
            this.btnCheck.TabIndex = 0;
            this.btnCheck.TabStop = false;
            this.btnCheck.Text = "done!";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // frmQuestions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Controls.Add(this.pnlQuestions);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(650, 500);
            this.Name = "frmQuestions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Questions";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmQuestions_FormClosed);
            this.Load += new System.EventHandler(this.frmQuestions_Load);
            this.SizeChanged += new System.EventHandler(this.frmQuestions_SizeChanged);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlQuestions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Panel pnlQuestions;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCheck;
    }
}