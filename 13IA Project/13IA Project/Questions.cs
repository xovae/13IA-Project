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
using System.Windows.Controls.Primitives;
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

        public const string INTERNAL_WRITE_PATH = "..\\..\\..\\..\\Quiz Output//";

        List<MultiChoice> multichoiceList = new List<MultiChoice>();
        List<MultiSelect> multiselectList = new List<MultiSelect>();
        List<TrueFalse> truefalseList = new List<TrueFalse>();

        public int distanceFromTop;
        public int distanceFromLeft;

        public bool questionsComplete = true;

        public int total = 0;

        public frmQuestions(string path, string name)
        {
            InitializeComponent();
            Icon = Properties.Resources.hbhs_icon;
            lblUsername.Text = Environment.UserName;
            filePath = path;
            lblTitle.Text = name;
            quizName = name;
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
                sr.Close();
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
            string selected;
            string output = $"{INTERNAL_WRITE_PATH}//{lblUsername.Text}//{lblUsername.Text} Results-{quizName}.csv";

            StreamWriter sw = File.CreateText(output);
            sw.WriteLine("Question,Topic,UserAnswer,CorrectAnswer,Correct?");
            if (multichoiceList.Count != 0)
            {
                foreach (var item in multichoiceList)
                {
                    selected = GetChecked(item.panel);
                    if (selected == null)
                    {
                        questionsComplete = false;
                    }
                    sw.Write($"{item.questionText},{item.questionTopic},{selected},{item.answerText},");
                    if (selected == item.answerText)
                    {
                        sw.WriteLine("Yes");
                        total++;
                    }
                    else
                    {
                        sw.WriteLine("No");
                    }
                }
            }
            if (truefalseList.Count != 0)
            {
                foreach (var item in truefalseList)
                {
                    selected = GetChecked(item.panel);
                    if (selected == null)
                    {
                        questionsComplete = false;
                    }
                    sw.Write($"{item.questionText},{item.questionTopic},{selected},{item.answerText},");
                    if (selected == item.answerText)
                    {
                        sw.WriteLine("Yes");
                        total++;
                    }
                    else
                    {
                        sw.WriteLine("No");
                    }
                }
            }
            if (multiselectList.Count != 0)
            {
                //foreach (var item in multiselectList)
                //{
                    
                //}
                //for every checkbox ticked, add it's text content to a list
                //if it matches a list of correct answers
            }
            sw.WriteLine($"Score: {total} out ot {multichoiceList.Count + multiselectList.Count + truefalseList.Count}");
            sw.Close();
            if (questionsComplete == false)
            {
                MessageBox.Show("Complete all quiz questions before submitting!", "Quiz Incomplete!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                File.Delete(output);
            }
            else
            {
                Close();
                frmMenu.GetInstance().Show();
            }
        }

        //private void Output<T>(List<T> list, StreamWriter sw)
        //{
        //    //string selected;
        //    //foreach (var item in list)
        //    //{
        //    //    selected = GetChecked(item.panel);
        //    //    if (selected == null)
        //    //    {
        //    //        questionsComplete = false;
        //    //    }
        //    //    sw.Write($"{item.questionText},{item.questionTopic},{selected},{item.answerText},");
        //    //    if (selected == item.answerText)
        //    //    {
        //    //        sw.WriteLine("Yes");
        //    //        total++;
        //    //    }
        //    //    else
        //    //    {
        //    //        sw.WriteLine("No");
        //    //    }
        //    //}
        //}

        private string GetChecked(Control container)
        {
            foreach (var control in container.Controls)
            {
                if (control is RadioButton radio && radio.Checked)
                {
                    return radio.Text;
                }
            }

            return null;
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
            }
            foreach (var item in multiselectList)
            {
                ResizeQuestions(multiselectList, item.panel);
            }
            foreach (var item in truefalseList)
            {
                ResizeQuestions(truefalseList, item.panel);
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
