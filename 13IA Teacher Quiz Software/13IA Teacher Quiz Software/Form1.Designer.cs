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
            this.btnDecodeResults = new System.Windows.Forms.Button();
            this.cmbQuizzes = new System.Windows.Forms.ComboBox();
            this.btnAddResource = new System.Windows.Forms.Button();
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
            this.btnEncode.Location = new System.Drawing.Point(29, 40);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(91, 23);
            this.btnEncode.TabIndex = 1;
            this.btnEncode.Text = "&Encode Quiz";
            this.btnEncode.UseVisualStyleBackColor = true;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnDecode
            // 
            this.btnDecode.Location = new System.Drawing.Point(146, 40);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(91, 23);
            this.btnDecode.TabIndex = 2;
            this.btnDecode.Text = "&Decode Quiz";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // btnDecodeResults
            // 
            this.btnDecodeResults.Location = new System.Drawing.Point(263, 40);
            this.btnDecodeResults.Name = "btnDecodeResults";
            this.btnDecodeResults.Size = new System.Drawing.Size(91, 23);
            this.btnDecodeResults.TabIndex = 3;
            this.btnDecodeResults.Text = "Decode &Results";
            this.btnDecodeResults.UseVisualStyleBackColor = true;
            this.btnDecodeResults.Click += new System.EventHandler(this.btnDecodeResults_Click);
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
            // frmQuiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::_13IA_Teacher_Quiz_Software.Properties.Resources.hbhs_background;
            this.ClientSize = new System.Drawing.Size(378, 306);
            this.Controls.Add(this.btnAddResource);
            this.Controls.Add(this.cmbQuizzes);
            this.Controls.Add(this.btnDecodeResults);
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
        private System.Windows.Forms.Button btnDecodeResults;
        private System.Windows.Forms.ComboBox cmbQuizzes;
        private System.Windows.Forms.Button btnAddResource;
    }
}

