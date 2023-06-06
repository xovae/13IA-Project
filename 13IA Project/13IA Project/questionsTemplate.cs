using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13IA_Project
{

    public class QuestionTemplate
    {
        public string questionText;
        public string questionTopic;        //possible simplify, remove the string questionText and just read from questionLabel.Text as needed
        public string answerText;
        public const int PADDING = 10;
        public Panel panel = new Panel();
        public Label questionLabel = new Label();

        public QuestionTemplate(string questionTopic, string questionText, string answerText)
        {
            panel.AutoSize = true;
            panel.BorderStyle = BorderStyle.Fixed3D;
            questionLabel.AutoSize = true;
            questionLabel.Font = new Font(questionLabel.Font.FontFamily, 10, FontStyle.Bold);
            panel.Controls.Add(questionLabel);

            this.questionText = questionText;
            questionLabel.Text = questionText;
            this.questionTopic = questionTopic;
            this.answerText = answerText;
        }
    }

    public class TrueFalse : QuestionTemplate
    {
        public RadioButton radioButton1;
        public RadioButton radioButton2;

        public TrueFalse(string questionTopic, string questionText, string answer, string option1) : base(questionTopic, questionText, answer)
        {
            radioButton1.Text = answer; 
            panel.Controls.Add(radioButton1);

            radioButton2.Text = option1;
            panel.Controls.Add(radioButton2);
            radioButton2.Top = radioButton1.Height + PADDING;
        }
    }

    public class MultiChoice : QuestionTemplate
    {
        public RadioButton radioButton1 = new RadioButton();
        public RadioButton radioButton2 = new RadioButton();
        public RadioButton radioButton3 = new RadioButton();
        public RadioButton radioButton4 = new RadioButton();

        public MultiChoice(string questionTopic, string questionText, string answer, string option1, string option2, string option3) : base(questionTopic, questionText, answer)
        {
            radioButton1.AutoSize = true;
            radioButton1.Text = answer;
            panel.Controls.Add(radioButton1);
            radioButton1.Top = questionLabel.Height + PADDING;
            radioButton1.Left = PADDING / 2;

            radioButton2.AutoSize = true;
            radioButton2.Text = option1;
            panel.Controls.Add(radioButton2);
            radioButton2.Top = radioButton1.Bottom + PADDING;
            radioButton2.Left = PADDING / 2;

            radioButton3.AutoSize = true;
            radioButton3.Text = option2;
            panel.Controls.Add(radioButton3);
            radioButton3.Top = radioButton2.Bottom + PADDING;
            radioButton3.Left = PADDING / 2;

            radioButton4.AutoSize = true;
            radioButton4.Text = option3;
            panel.Controls.Add(radioButton4);
            radioButton4.Top = radioButton3.Bottom + PADDING;
            radioButton4.Left = PADDING / 2;
        }
    }

    public class MultiSelect : QuestionTemplate
    {
        public int numberOfCorrect;

        public CheckBox checkBox1;
        public CheckBox checkBox2;
        public CheckBox checkBox3;
        public CheckBox checkBox4;
        public CheckBox checkBox5;
        public CheckBox checkBox6;
        public CheckBox checkBox7;
        public CheckBox checkBox8;

        public MultiSelect(string questionTopic, string questionText, int numberOfCorrect, string input1, string input2, string input3, string input4) : base(questionTopic, questionText, input1)
        {
            this.numberOfCorrect = numberOfCorrect;
            checkBox1.Text = input1;
            checkBox2.Text = input2;
            checkBox3.Text = input3;
            checkBox4.Text = input4;
        }

        public MultiSelect(string questionTopic, string questionText, int numberOfCorrect, string input1, string input2, string input3, string input4, string input5, string input6, string input7, string input8) : base(questionTopic, questionText, input1)
        {
            this.numberOfCorrect = numberOfCorrect;
            checkBox1.Text = input1;
            checkBox2.Text = input2;
            checkBox3.Text = input3;
            checkBox4.Text = input4;
            checkBox5.Text = input5;
            checkBox6.Text = input6;
            checkBox7.Text = input7;
            checkBox8.Text = input8;
        }
    }
}
