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

namespace _13IA_Project
{
    public partial class frmQuestions : Form
    {
        public string filePath;

        List<Multichoice> multichoiceList = new List<Multichoice>();

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
            int distanceFromTop = 0;
            int distanceFromLeft = 0;
            StreamReader sr = new StreamReader(filePath);

            while (!sr.EndOfStream)
            {
                current = sr.ReadLine().Split(',');
                if (current[0] == "Multichoice")
                {
                    multichoiceList.Add(new Multichoice(current[2], current[3], current[4], current[5], current[6]));
                }
                //else if (current[0] == "SelectAll")
                //{

                //}
            }
            foreach (var item in multichoiceList)
            {
                pnlQuestions.Controls.Add(item.panel);
                item.panel.Location = new Point(distanceFromLeft, distanceFromTop);
                distanceFromTop += 500 - item.panel.Height;
            }
        }

        private void frmQuestions_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMenu.GetInstance().Show();
        }
    }

    class Multichoice
    {
        public Panel panel = new Panel();
        public Label question = new Label();
        public string answer;

        public RadioButton option1 = new RadioButton();
        public RadioButton option2 = new RadioButton();
        public RadioButton option3 = new RadioButton();
        public RadioButton option4 = new RadioButton();
        
        public Multichoice(string questionText, string correctAnswerText, string falseAnswer1, string falseAnswer2, string falseAnswer3)
        {
            answer = correctAnswerText;
            panel.AutoSize = true;
            panel.BorderStyle = BorderStyle.Fixed3D;
            option1.AutoSize = true;
            option2.AutoSize = true;
            option3.AutoSize = true;
            option4.AutoSize = true;

            question.Text = questionText;
            panel.Controls.Add(question);
            option1.Text = correctAnswerText;
            panel.Controls.Add(option1);
            option2.Text = falseAnswer1;            //RANDOMLY SHUFFLE WHERE THE ANSWER IS 
            panel.Controls.Add(option2);
            option3.Text = falseAnswer2;
            panel.Controls.Add(option3);
            option4.Text = falseAnswer3;
            panel.Controls.Add(option4);
        }
    }

    //class MultiSelect : Multichoice
    //{
    //    //public Panel panel = new Panel();
    //    //public Label question = new Label();
    //    //public string answer;

    //    public CheckBox optionMulti1 = new CheckBox();
    //    public CheckBox optionMulti2 = new CheckBox();
    //    public CheckBox optionMulti3 = new CheckBox();
    //    public CheckBox optionMulti4 = new CheckBox();
    //    public CheckBox optionMulti5 = new CheckBox();
    //    public CheckBox optionMulti6 = new CheckBox();
    //    public CheckBox optionMulti7 = new CheckBox();
    //    public CheckBox optionMulti8 = new CheckBox();

    //    public MultiSelect(string questionText, string option1Text, string option2Text, string option3Text, string option4Text, string answerText)
    //    {
    //        question.Text = questionText;
    //        panel.Controls.Add(question);
    //        optionMulti1.Text = option1Text;
    //        panel.Controls.Add(option1);
    //        optionMulti2.Text = option2Text;
    //        panel.Controls.Add(option2);
    //        optionMulti3.Text = option3Text;
    //        panel.Controls.Add(option3);
    //        optionMulti4.Text = option4Text;
    //        panel.Controls.Add(option4);

    //        answer = answerText;
    //        panel.AutoSize = true;
    //    }

    //    public MultiSelect(string questionText, string option1Text, string option2Text, string option3Text, string option4Text, string option5Text, string option6Text, string option7Text, string option8Text, string answerText)
    //    {
    //        question.Text = questionText;
    //        panel.Controls.Add(question);
    //        optionMulti1.Text = option1Text;
    //        panel.Controls.Add(optionMulti1);
    //        optionMulti2.Text = option2Text;
    //        panel.Controls.Add(optionMulti2);
    //        optionMulti3.Text = option3Text;
    //        panel.Controls.Add(optionMulti3);
    //        optionMulti4.Text = option4Text;
    //        panel.Controls.Add(optionMulti4);
    //        optionMulti5.Text = option5Text;
    //        panel.Controls.Add(optionMulti5);
    //        optionMulti6.Text = option6Text;
    //        panel.Controls.Add(optionMulti6);
    //        optionMulti7.Text = option7Text;
    //        panel.Controls.Add(optionMulti7);
    //        optionMulti8.Text = option8Text;
    //        panel.Controls.Add(optionMulti8);

    //        answer = answerText;
    //        panel.AutoSize = true;

            
    //    }
    //}
}
