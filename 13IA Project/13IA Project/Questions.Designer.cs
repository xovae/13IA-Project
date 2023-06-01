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
            this.pnlLeftSidebar = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlGraphics = new System.Windows.Forms.Panel();
            this.pnlCentre = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlLeftSidebar
            // 
            this.pnlLeftSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeftSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftSidebar.Name = "pnlLeftSidebar";
            this.pnlLeftSidebar.Size = new System.Drawing.Size(142, 450);
            this.pnlLeftSidebar.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(142, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(658, 100);
            this.pnlHeader.TabIndex = 1;
            // 
            // pnlGraphics
            // 
            this.pnlGraphics.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlGraphics.Location = new System.Drawing.Point(600, 100);
            this.pnlGraphics.Name = "pnlGraphics";
            this.pnlGraphics.Size = new System.Drawing.Size(200, 350);
            this.pnlGraphics.TabIndex = 2;
            // 
            // pnlCentre
            // 
            this.pnlCentre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCentre.Location = new System.Drawing.Point(142, 100);
            this.pnlCentre.Name = "pnlCentre";
            this.pnlCentre.Size = new System.Drawing.Size(458, 350);
            this.pnlCentre.TabIndex = 3;
            // 
            // frmQuestions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlCentre);
            this.Controls.Add(this.pnlGraphics);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlLeftSidebar);
            this.Name = "frmQuestions";
            this.Text = "Questions";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeftSidebar;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlGraphics;
        private System.Windows.Forms.Panel pnlCentre;
    }
}