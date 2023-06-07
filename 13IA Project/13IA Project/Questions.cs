using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace _13IA_Project
{
    public partial class frmQuestions : Form
    {
        public string filePath;
        public string quizName;

        const int PADDING = 50;
        const int PANEL_WIDTH = 100;

        const int MULTI_SMALL = 7;
        const int MULTI_LARGE = 11;

        List<MultiChoice> multichoiceList = new List<MultiChoice>();
        List<MultiSelect> multiselectList = new List<MultiSelect>();
        List<TrueFalse> truefalseList = new List<TrueFalse>();

        public frmQuestions(string path, string name)
        {
            InitializeComponent();
            Icon = Properties.Resources.hbhs_icon;
            lblUsername.Text = Environment.UserName;
            filePath = path;
            lblTitle.Text = name;
            pnlQuestions.Width = Width;
        }

        private void frmQuestions_Load(object sender, EventArgs e)
        {
            string[] current;
            int distanceFromTop = 0;
            int distanceFromLeft = 0;
            StreamReader sr = new StreamReader(filePath);

            lblTitle.Left = (pnlHeader.Width - lblTitle.Width) / 2;
            lblTitle.Top = (pnlHeader.Height - lblTitle.Height) / 2;

            try
            {
                while (!sr.EndOfStream)
            {
                current = sr.ReadLine().Split(',');
                if (current[0] == "Multichoice")
                {
                    multichoiceList.Add(new MultiChoice(current[1], current[2], current[3], current[4], current[5], current[6]));
                }
                else if (current[0] == "SelectAll")
                {
                    if (current.Length == MULTI_SMALL)
                    {
                        multiselectList.Add(new MultiSelect(current[1], current[2], Convert.ToInt32(current[3]), current[4], current[5], current[6], current[7]));
                    }
                    else if (current.Length == MULTI_LARGE)
                    {
                        multiselectList.Add(new MultiSelect(current[1], current[2], Convert.ToInt32(current[3]), current[4], current[5], current[6], current[7], current[8], current[9], current[10], current[11]));
                    }
                }
                else if (current[0] == "TrueFalse")
                {
                    truefalseList.Add(new TrueFalse(current[1], current[2], current[3]));
                }
            }
            foreach (var item in multichoiceList)
            {
                pnlQuestions.Controls.Add(item.panel);
                item.panel.Width = pnlQuestions.Width - PANEL_WIDTH;
                item.questionLabel.Left = (item.panel.Width - item.questionLabel.Width) / 2;

                distanceFromLeft = (pnlQuestions.Width - item.panel.Width) / 2;
                item.panel.Location = new Point(distanceFromLeft, distanceFromTop);
                distanceFromTop += item.panel.Height + PADDING;
            }
            foreach (var item in multiselectList)
            {
                pnlQuestions.Controls.Add(item.panel);
                item.panel.Width = pnlQuestions.Width - PANEL_WIDTH;
                item.questionLabel.Left = (item.panel.Width - item.questionLabel.Width) / 2;

                distanceFromLeft = (pnlQuestions.Width - item.panel.Width) / 2;
                item.panel.Location = new Point(distanceFromLeft, distanceFromTop);
                distanceFromTop += item.panel.Height + PADDING;
            }
            foreach (var item in truefalseList)
            {
                pnlQuestions.Controls.Add(item.panel);
                item.panel.Width = pnlQuestions.Width - PANEL_WIDTH;
                item.panel.Height = item.radioButton2.Bottom;
                item.questionLabel.Left = (item.panel.Width - item.questionLabel.Width) / 2;

                distanceFromLeft = (pnlQuestions.Width - item.panel.Width) / 2;
                item.panel.Location = new Point(distanceFromLeft, distanceFromTop);
                distanceFromTop += item.panel.Height + PADDING;
            }
            //if (multichoiceList.Count != 0)
            //{
            //    multichoiceList.Last().panel.Margin = new Padding(0, 0, 0, 10);
            //}
            //if (truefalseList.Count != 0)
            //{
            //    truefalseList.Last().panel.Padding = new Padding(0, 0, 0, 10);
            //}
            }
            catch (IOException ex)
            {
                MessageBox.Show($"The quiz file could not be read! {ex}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void CheckQuestions()
        {

        }

        private void frmQuestions_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMenu.GetInstance().Show();
        }

        private void frmQuestions_SizeChanged(object sender, EventArgs e)
        {
            pnlQuestions.Width = Width;
            foreach (var item in multichoiceList)
            {
                item.panel.Width = pnlQuestions.Width - PANEL_WIDTH;
                item.questionLabel.Left = (item.panel.Width - item.questionLabel.Width) / 2;
                int distanceFromLeft = (pnlQuestions.Width - item.panel.Width) / 2;
                item.panel.Left = distanceFromLeft;
            }
            foreach (var item in multiselectList)
            {
                item.panel.Width = pnlQuestions.Width - PANEL_WIDTH;
                item.questionLabel.Left = (item.panel.Width - item.questionLabel.Width) / 2;
                int distanceFromLeft = (pnlQuestions.Width - item.panel.Width) / 2;
                item.panel.Left = distanceFromLeft;
            }
            foreach (var item in truefalseList)
            {
                item.panel.Width = pnlQuestions.Width - PANEL_WIDTH;
                item.questionLabel.Left = (item.panel.Width - item.questionLabel.Width) / 2;
                int distanceFromLeft = (pnlQuestions.Width - item.panel.Width) / 2;
                item.panel.Left = distanceFromLeft;
            }

            lblTitle.Left = (pnlHeader.Width - lblTitle.Width) / 2;
            lblTitle.Top = (pnlHeader.Height - lblTitle.Height) / 2;
        }
    }
}
