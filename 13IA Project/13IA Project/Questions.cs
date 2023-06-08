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

        const int MULTI_SMALL = 8;
        const int MULTI_LARGE = 12;

        List<MultiChoice> multichoiceList = new List<MultiChoice>();
        List<MultiSelect> multiselectList = new List<MultiSelect>();
        List<TrueFalse> truefalseList = new List<TrueFalse>();

        public int distanceFromTop;
        public int distanceFromLeft;

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
                    else if (current[0] == "MultiSelect")
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
                if (multichoiceList.Count != 0)
                {
                    foreach (var item in multichoiceList)
                    {
                        FormatQuestions(multichoiceList, item.panel);
                    }
                }
                if (multiselectList.Count != 0)
                {
                    foreach (var item in multiselectList)
                    {
                        FormatQuestions(multiselectList, item.panel);
                    }
                }
                if (truefalseList.Count != 0)
                {
                    foreach (var item in truefalseList)
                    {
                        FormatQuestions(truefalseList, item.panel);
                        item.panel.Height = item.radioButton2.Bottom;
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"The quiz file could not be read! {ex}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatQuestions<T>(List<T> list, Panel panel)
        {
            pnlQuestions.Controls.Add(panel);
            panel.Width = pnlQuestions.Width - PANEL_WIDTH;

            distanceFromLeft = (pnlQuestions.Width - panel.Width) / 2;
            panel.Location = new Point(distanceFromLeft, distanceFromTop);
            distanceFromTop += panel.Height + PADDING / 2;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (multichoiceList.Count != 0)
            {
                foreach (var item in multichoiceList)
                {
                    if (item.radioButton1.Checked == true)
                    {
                        item.questionCorrect = true;
                    }
                }
                foreach (var item in truefalseList)
                {
                    if (item.radioButton1.Checked == true)
                    {
                        item.questionCorrect = true;
                    }
                }
                //foreach (var item in multiselectList)
                //{
                    
                //}
            }
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
                ResizeQuestions(multiselectList, item.panel);
                //item.panel.Width = pnlQuestions.Width - PANEL_WIDTH;
                ////item.questionLabel.Left = (item.panel.Width - item.questionLabel.Width) / 2;
                //int distanceFromLeft = (pnlQuestions.Width - item.panel.Width) / 2;
                //item.panel.Left = distanceFromLeft;
            }
            foreach (var item in multiselectList)
            {
                ResizeQuestions(multiselectList, item.panel);
                //item.panel.Width = pnlQuestions.Width - PANEL_WIDTH;
                ////item.questionLabel.Left = (item.panel.Width - item.questionLabel.Width) / 2;
                //int distanceFromLeft = (pnlQuestions.Width - item.panel.Width) / 2;
                //item.panel.Left = distanceFromLeft;
            }
            foreach (var item in truefalseList)
            {
                ResizeQuestions(truefalseList, item.panel);
                //item.panel.Width = pnlQuestions.Width - PANEL_WIDTH;
                ////item.questionLabel.Left = (item.panel.Width - item.questionLabel.Width) / 2;
                //int distanceFromLeft = (pnlQuestions.Width - item.panel.Width) / 2;
                //item.panel.Left = distanceFromLeft;
            }

            lblTitle.Left = (pnlHeader.Width - lblTitle.Width) / 2;
            lblTitle.Top = (pnlHeader.Height - lblTitle.Height) / 2;
        }

        private void ResizeQuestions<T>(List<T> list, Panel panel)
        {
            panel.Width = pnlQuestions.Width - PANEL_WIDTH;
            int distanceFromLeft = (pnlQuestions.Width - panel.Width) / 2;
            panel.Left = distanceFromLeft;
        }
    }
}
