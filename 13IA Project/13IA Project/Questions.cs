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
        const int DISTANCE_FROM_OUTER = 100;

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
            List<string> answers = new List<string>();

            StreamReader sr = new StreamReader(filePath);

            lblTitle.Left = (pnlHeader.Width - lblTitle.Width) / 2;
            lblTitle.Top = (pnlHeader.Height - lblTitle.Height) / 2;

            try
            {
                while (!sr.EndOfStream)
                {
                    current = Encoding.UTF8.GetString(Convert.FromBase64String(sr.ReadLine())).Split(',');
                    answers.Clear();

                    if (current[0] == "Multichoice")
                    {
                        for (int i = 0; i < current.Count() - 4; i++)
                        {
                            answers.Add(current[i + 4]);
                        }
                        multichoiceList.Add(new MultiChoice(current[1], current[2], answers));
                        FormatQuestions(multichoiceList, multichoiceList.Last().panel);
                    }
                    else if (current[0] == "MultiSelect")
                    {
                        for (int i = 0; i < (current.Count() - 4); i++)
                        {
                            answers.Add(current[i + 4]);
                        }

                        multiselectList.Add(new MultiSelect(current[1], current[2], Convert.ToInt32(current[3]), answers));
                        FormatQuestions(multiselectList, multiselectList.Last().panel);
                    }
                    else if (current[0] == "TrueFalse")
                    {
                        truefalseList.Add(new TrueFalse(current[1], current[2], current[4]));
                        FormatQuestions(truefalseList, truefalseList.Last().panel);
                    }
                }
                sr.Close();
                if (truefalseList.Count != 0)
                {
                    foreach (var item in truefalseList)
                    {
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
            panel.Width = pnlQuestions.Width - DISTANCE_FROM_OUTER;

            distanceFromLeft = (pnlQuestions.Width - panel.Width) / 2;
            panel.Location = new Point(distanceFromLeft, distanceFromTop);
            distanceFromTop += panel.Height + PADDING / 2;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string selected;
            string output = $"{INTERNAL_WRITE_PATH}//{lblUsername.Text}//{lblUsername.Text} Results-{quizName}.csv";

            questionsComplete = true;

            try
            {
                StreamWriter sw = File.CreateText(output);


                sw.WriteLine(Encode("Question,Topic,UserAnswer(s),CorrectAnswer (MultiChoice),Correct?"));
                //sw.WriteLine("Question,Topic,UserAnswer(s),CorrectAnswer (MultiChoice),Correct?");

                if (multichoiceList.Count != 0)
                {
                    foreach (var item in multichoiceList)
                    {
                        selected = GetCheckedRadio(item.panel);
                        if (selected == null)
                        {
                            questionsComplete = false;
                        }

                        sw.Write(Encode($"{item.questionText},{item.questionTopic},{selected},{item.answerMulti},"));
                        //sw.Write($"{item.questionText},{item.questionTopic},{selected},{item.answerMulti},");

                        if (selected == item.answerMulti)
                        {
                            sw.WriteLine(Encode("Y"));
                            //sw.WriteLine("Y");
                            total++;
                        }
                        else
                        {
                            sw.WriteLine(Encode("N"));
                            //sw.WriteLine("N");
                        }
                    }
                }
                if (truefalseList.Count != 0)
                {
                    foreach (var item in truefalseList)
                    {
                        selected = GetCheckedRadio(item.panel);
                        if (selected == null)
                        {
                            questionsComplete = false;
                        }

                        //sw.Write($"{item.questionText},{item.questionTopic},{selected},{item.answerText},");
                        sw.Write(Encode($"{item.questionText},{item.questionTopic},{selected},{item.answerText},"));

                        if (selected == item.answerText)
                        {
                            sw.WriteLine(Encode("Y"));
                            //sw.WriteLine("Y");
                            total++;
                        }
                        else
                        {
                            sw.WriteLine(Encode("N"));
                            //sw.WriteLine("N");
                        }
                    }
                }
                if (multiselectList.Count != 0)
                {
                    List<string> inputs = new List<string>();
                    foreach (var item in multiselectList)
                    {
                        inputs = GetChecked(item.panel);
                        if (inputs.Count == 0)
                        {
                            questionsComplete = false;
                        }

                        sw.Write(Encode($"{item.questionText},{item.questionTopic},"));
                        //sw.Write($"{item.questionText},{item.questionTopic},");

                        inputs.Sort();

                        foreach (var item2 in inputs)
                        {
                            sw.Write(Encode($"{item2},"));
                            //sw.Write($"{item2},");
                        }

                        if (inputs.SequenceEqual(item.answers) == true)
                        {
                            sw.WriteLine(Encode("Y"));
                            //sw.WriteLine("Y");
                            total++;
                        }
                        else
                        {
                            //sw.WriteLine("N");
                            sw.WriteLine(Encode("N"));
                        }
                    }   
                }

                //sw.Write($"Score is {total} out of {multichoiceList.Count + multiselectList.Count + truefalseList.Count}");
                sw.Write(Encode($"Score is {total} out of {multichoiceList.Count + multiselectList.Count + truefalseList.Count}"));
                sw.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show($"The results could not be successfully exported! {ex}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            if (questionsComplete == false)
            {
                MessageBox.Show("Complete all quiz questions before submitting!", "Quiz Incomplete!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                File.Delete(output);
                total = 0;
            }
            else
            {
                Close();
                frmMenu.GetInstance().Show();
            }
        }

        private string Encode(string current)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(current));
        }

        //private void OutputRadio<T>(List<T> list, string questionText, string questionTopic, string answerText, Panel panel, StreamWriter sw)
        //{
        //    string selected;
        //    foreach (var item in list)
        //    {
        //        selected = GetCheckedRadio(panel);
        //        if (selected == null)
        //        {
        //            questionsComplete = false;
        //        }
        //        sw.Write($"{questionText},{questionTopic},{selected},{answerText},");
        //        if (selected == answerText)
        //        {
        //            sw.WriteLine("Yes");
        //            total++;
        //        }
        //        else
        //        {
        //            sw.WriteLine("No");
        //        }
        //    }
        //}

        private string GetCheckedRadio(Control container)
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

        private List<string> GetChecked(Control container)
        {
            List<string> checks = new List<string>();
            foreach (var control in container.Controls)
            {
                if (control is CheckBox check && check.Checked)
                {
                    checks.Add(check.Text);
                }
            }
            return checks;
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
            panel.Width = pnlQuestions.Width - DISTANCE_FROM_OUTER;
            int distanceFromLeft = (pnlQuestions.Width - panel.Width) / 2;
            panel.Left = distanceFromLeft;
        }
    }
}
