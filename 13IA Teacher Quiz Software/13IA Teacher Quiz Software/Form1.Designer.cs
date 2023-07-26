namespace _13IA_Teacher_Quiz_Software
{
    partial class frmQuiz
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnEncode = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnDecode = new System.Windows.Forms.Button();
            this.cmbQuizzes = new System.Windows.Forms.ComboBox();
            this.btnAddResource = new System.Windows.Forms.Button();
            this.btnRandomResources = new System.Windows.Forms.Button();
            this.cmbRandom = new System.Windows.Forms.ComboBox();
            this.lblRandom = new System.Windows.Forms.Label();
            this.btnAddBank = new System.Windows.Forms.Button();
            this.btnOpenBank = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblTitle.Location = new System.Drawing.Point(115, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(149, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quiz Encoding";
            // 
            // btnEncode
            // 
            this.btnEncode.Location = new System.Drawing.Point(85, 40);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(91, 23);
            this.btnEncode.TabIndex = 1;
            this.btnEncode.Text = "&Add Quiz";
            this.btnEncode.UseVisualStyleBackColor = true;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnDecode
            // 
            this.btnDecode.Location = new System.Drawing.Point(202, 40);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(91, 23);
            this.btnDecode.TabIndex = 2;
            this.btnDecode.Text = "Open &Quiz";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // cmbQuizzes
            // 
            this.cmbQuizzes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuizzes.FormattingEnabled = true;
            this.cmbQuizzes.Location = new System.Drawing.Point(69, 87);
            this.cmbQuizzes.Name = "cmbQuizzes";
            this.cmbQuizzes.Size = new System.Drawing.Size(121, 21);
            this.cmbQuizzes.TabIndex = 4;
            this.cmbQuizzes.SelectedIndexChanged += new System.EventHandler(this.cmbQuizzes_SelectedIndexChanged);
            // 
            // btnAddResource
            // 
            this.btnAddResource.Location = new System.Drawing.Point(219, 87);
            this.btnAddResource.Name = "btnAddResource";
            this.btnAddResource.Size = new System.Drawing.Size(91, 23);
            this.btnAddResource.TabIndex = 5;
            this.btnAddResource.Text = "&Add Resources";
            this.btnAddResource.UseVisualStyleBackColor = true;
            this.btnAddResource.Click += new System.EventHandler(this.btnAddResource_Click);
            // 
            // btnRandomResources
            // 
            this.btnRandomResources.Location = new System.Drawing.Point(219, 236);
            this.btnRandomResources.Name = "btnRandomResources";
            this.btnRandomResources.Size = new System.Drawing.Size(91, 23);
            this.btnRandomResources.TabIndex = 6;
            this.btnRandomResources.Text = "Add &Resources";
            this.btnRandomResources.UseVisualStyleBackColor = true;
            this.btnRandomResources.Click += new System.EventHandler(this.btnRandomResources_Click);
            // 
            // cmbRandom
            // 
            this.cmbRandom.FormattingEnabled = true;
            this.cmbRandom.Location = new System.Drawing.Point(69, 236);
            this.cmbRandom.Name = "cmbRandom";
            this.cmbRandom.Size = new System.Drawing.Size(121, 21);
            this.cmbRandom.TabIndex = 7;
            this.cmbRandom.SelectedIndexChanged += new System.EventHandler(this.cmbRandom_SelectedIndexChanged);
            // 
            // lblRandom
            // 
            this.lblRandom.AutoSize = true;
            this.lblRandom.BackColor = System.Drawing.Color.Transparent;
            this.lblRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lblRandom.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblRandom.Location = new System.Drawing.Point(114, 147);
            this.lblRandom.Name = "lblRandom";
            this.lblRandom.Size = new System.Drawing.Size(150, 24);
            this.lblRandom.TabIndex = 8;
            this.lblRandom.Text = "Random Banks";
            // 
            // btnAddBank
            // 
            this.btnAddBank.Location = new System.Drawing.Point(85, 191);
            this.btnAddBank.Name = "btnAddBank";
            this.btnAddBank.Size = new System.Drawing.Size(91, 23);
            this.btnAddBank.TabIndex = 9;
            this.btnAddBank.Text = "Add &Bank";
            this.btnAddBank.UseVisualStyleBackColor = true;
            this.btnAddBank.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // btnOpenBank
            // 
            this.btnOpenBank.Location = new System.Drawing.Point(202, 191);
            this.btnOpenBank.Name = "btnOpenBank";
            this.btnOpenBank.Size = new System.Drawing.Size(91, 23);
            this.btnOpenBank.TabIndex = 10;
            this.btnOpenBank.Text = "&Open Bank";
            this.btnOpenBank.UseVisualStyleBackColor = true;
            this.btnOpenBank.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // frmQuiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::_13IA_Teacher_Quiz_Software.Properties.Resources.hbhs_background;
            this.ClientSize = new System.Drawing.Size(378, 306);
            this.Controls.Add(this.btnOpenBank);
            this.Controls.Add(this.btnAddBank);
            this.Controls.Add(this.lblRandom);
            this.Controls.Add(this.cmbRandom);
            this.Controls.Add(this.btnRandomResources);
            this.Controls.Add(this.btnAddResource);
            this.Controls.Add(this.cmbQuizzes);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.btnEncode);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmQuiz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HBHS Revision Quizzes (Teacher Copy)";
            this.Load += new System.EventHandler(this.frmQuiz_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.ComboBox cmbQuizzes;
        private System.Windows.Forms.Button btnAddResource;
        private System.Windows.Forms.Button btnRandomResources;
        private System.Windows.Forms.ComboBox cmbRandom;
        private System.Windows.Forms.Label lblRandom;
        private System.Windows.Forms.Button btnAddBank;
        private System.Windows.Forms.Button btnOpenBank;
    }
}

