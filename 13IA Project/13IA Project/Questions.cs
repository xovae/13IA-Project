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
            StreamReader sr = new StreamReader(filePath);

            while (!sr.EndOfStream)
            {
                current = sr.ReadLine().Split(',');
                if (current[0] == "Multichoice")
                {
                    multichoiceList.Add(new Multichoice(current[1], current[2], current[3], current[4], current[5], current[6]));
                }
                //else if (current[0] == "SelectAll")
                //{

                //}
            }
            foreach (var item in multichoiceList)
            {
                pnlQuestions.Controls.Add(item.panel);
            }
        }

        private void frmQuestions_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }

    class Multichoice
    {
        public Panel panel = new Panel();
        public Label question = new Label();
        public RadioButton option1 = new RadioButton();
        public RadioButton option2 = new RadioButton();
        public RadioButton option3 = new RadioButton();
        public RadioButton option4 = new RadioButton();
        public string answer;

        public Multichoice(string questionText, string option1Text, string option2Text, string option3Text, string option4Text, string answerText)
        {
            question.Text = questionText;
            panel.Controls.Add(question);
            option1.Text = option1Text;
            panel.Controls.Add(option1);
            option2.Text = option2Text;
            panel.Controls.Add(option2);
            option3.Text = option3Text;
            panel.Controls.Add(option3);
            option4.Text = option4Text;
            panel.Controls.Add(option4);
            answer = answerText;
            panel.AutoSize = true;
        }
    }

    //class SelectAll : Multichoice
    //{
    //    public CheckBox option5 = new CheckBox();
    //    public CheckBox option6 = new CheckBox();
    //    public CheckBox option7 = new CheckBox();
    //    public CheckBox option8 = new CheckBox();

    //    public SelectAll(string questionText, string option1Text, string option2Text, string option3Text, string option4Text, string answerText)
    //    {
    //        question.Text = questionText;
    //        panel.Controls.Add(question);
    //        option1.Text= option1Text;
    //        panel.Controls.Add(option1);
    //        option2.Text= option2Text;
    //        panel.Controls.Add(option2);
    //        option3.Text= option3Text;
    //        panel.Controls.Add(option3);
    //        option4.Text= option4Text;
    //        panel.Controls.Add(option4);
    //        answer = answerText;
    //        panel.AutoSize = true;
    //    }
        
    //    public SelectAll(string questionText, string option1Text, string option2Text, string option3Text, string option4Text, string option5Text, string option6Text, string option7Text, string option8Text, string answerText)
    //    {
    //        question.Text = questionText;
    //        panel.Controls.Add(question);
    //        option1.Text= option1Text;
    //        panel.Controls.Add(option1);
    //        option2.Text= option2Text;
    //        panel.Controls.Add(option2);
    //        option3.Text= option3Text;
    //        panel.Controls.Add(option3);
    //        option4.Text= option4Text;
    //        panel.Controls.Add(option4);
    //        option5.Text= option5Text;
    //        panel.Controls.Add(option5);
    //        option6.Text= option6Text;
    //        panel.Controls.Add(option6);
    //        option7.Text= option7Text;
    //        panel.Controls.Add(option7);
    //        option8.Text= option8Text;
    //        panel.Controls.Add(option8);
    //        answer = answerText;
    //        panel.AutoSize = true;
    //    }
    //}
}
