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
            this.lblUsername = new System.Windows.Forms.Label();
            this.pnlQuestions = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblUsername);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 37);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblUsername.Location = new System.Drawing.Point(735, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(65, 13);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "lblUsername";
            // 
            // pnlQuestions
            // 
            this.pnlQuestions.AutoScroll = true;
            this.pnlQuestions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQuestions.Location = new System.Drawing.Point(0, 37);
            this.pnlQuestions.Name = "pnlQuestions";
            this.pnlQuestions.Size = new System.Drawing.Size(800, 413);
            this.pnlQuestions.TabIndex = 2;
            // 
            // frmQuestions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlQuestions);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmQuestions";
            this.Text = "Questions";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmQuestions_FormClosed);
            this.Load += new System.EventHandler(this.frmQuestions_Load);
            this.Resize += new System.EventHandler(this.frmQuestions_Resize);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Panel pnlQuestions;
    }
}