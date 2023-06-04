using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13IA_Project
{
    public partial class frmQuestions : Form
    {
        public string filePath;

        public frmQuestions(string path)
        {
            InitializeComponent();
            Icon = Properties.Resources.hbhs_icon;
            lblUsername.Text = Environment.UserName;
            filePath = path;
        }

        private void frmQuestions_Load(object sender, EventArgs e)
        {
            string[] current;
            int i = 0;
            StreamReader sr = new StreamReader(filePath);

            while (!sr.EndOfStream)
            {
                current = sr.ReadLine().Split(',');
                if (current[0] == "Multichoice")
                {
                    CreateMultichoicePanel(current);
                }
                //else if (current[0] == "SelectAll")
                //{

                //}
                i++;
            }
        }

        private void CreateMultichoicePanel(string[] info)
        {
            Panel panel = new Panel();
            panel.AutoSize = true;

            Label question = new Label();
            question.Text = info[1];
            panel.Controls.Add(question);

            RadioButton option1 = new RadioButton();
            option1.Text = info[2];
            panel.Controls.Add(option1);

            RadioButton option2 = new RadioButton();
            option2.Text = info[3];
            panel.Controls.Add(option2);

            RadioButton option3 = new RadioButton();
            option3.Text = info[4];
            panel.Controls.Add(option3);

            RadioButton option4 = new RadioButton();
            option4.Text = info[5];
            panel.Controls.Add(option4);

            panel.Update();
            pnlQuestions.Controls.Add(panel);
        }
    }
}
