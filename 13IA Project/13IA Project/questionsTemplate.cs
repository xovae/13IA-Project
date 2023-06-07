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
        public Padding BOTTOM_PADDING = new Padding(0, 0, 0, PADDING / 5);

        public Panel panel = new Panel();
        public Label questionLabel = new Label();

        public QuestionTemplate(string questionTopic, string questionText, string answerText)
        {
            panel.AutoSize = true;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Padding = new Padding(5);
            questionLabel.AutoSize = true;
            questionLabel.Font = new Font(questionLabel.Font.FontFamily, 10, FontStyle.Bold);
            panel.Controls.Add(questionLabel);
            questionLabel.Top += PADDING / 5;

            this.questionText = questionText;
            questionLabel.Text = questionText;
            this.questionTopic = questionTopic;
            this.answerText = answerText;
        }
    }

    public class TrueFalse : QuestionTemplate
    {
        public RadioButton radioButton1 = new RadioButton();
        public RadioButton radioButton2 = new RadioButton();

        public TrueFalse(string questionTopic, string questionText, string answer) : base(questionTopic, questionText, answer)
        {
            radioButton1.AutoSize = true;
            radioButton1.Text = "True"; 
            panel.Controls.Add(radioButton1);
            radioButton1.Top = questionLabel.Bottom;
            radioButton1.Left = PADDING / 2;

            radioButton2.AutoSize = true;
            radioButton2.Text = "False";
            panel.Controls.Add(radioButton2);
            radioButton2.Top = radioButton1.Bottom + PADDING;
            radioButton2.Left = PADDING / 2;
            radioButton2.Padding = BOTTOM_PADDING;
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
            radioButton1.Top = questionLabel.Bottom;
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

            checkBox1.AutoSize = true;
            checkBox1.Text = input1;
            panel.Controls.Add(checkBox1);
            checkBox1.Top = questionLabel.Bottom;
            checkBox1.Left = PADDING / 2;

            checkBox2.AutoSize = true;
            checkBox2.Text = input2;
            panel.Controls.Add(checkBox2);
            checkBox2.Top = checkBox1.Bottom + PADDING;
            checkBox2.Left = PADDING / 2;

            checkBox3.AutoSize = true;
            checkBox3.Text = input3;
            panel.Controls.Add(checkBox3);
            checkBox3.Top = checkBox2.Bottom + PADDING;
            checkBox3.Left = PADDING / 2;

            checkBox4.AutoSize = true;
            checkBox4.Text = input4;
            panel.Controls.Add(checkBox4);
            checkBox4.Top = checkBox3.Bottom + PADDING;
            checkBox4.Left = PADDING / 2;
            checkBox4.Padding = BOTTOM_PADDING;
        }

        public MultiSelect(string questionTopic, string questionText, int numberOfCorrect, string input1, string input2, string input3, string input4, string input5, string input6, string input7, string input8) : base(questionTopic, questionText, input1)
        {
            this.numberOfCorrect = numberOfCorrect;

            checkBox1.AutoSize = true;
            checkBox1.Text = input1;
            panel.Controls.Add(checkBox1);
            checkBox1.Top = questionLabel.Bottom;
            checkBox1.Left = PADDING / 2;

            checkBox2.AutoSize = true;
            checkBox2.Text = input2;
            panel.Controls.Add(checkBox2);
            checkBox2.Top = checkBox1.Bottom + PADDING;
            checkBox2.Left = PADDING / 2;

            checkBox3.AutoSize = true;
            checkBox3.Text = input3;
            panel.Controls.Add(checkBox3);
            checkBox3.Top = checkBox2.Bottom + PADDING;
            checkBox3.Left = PADDING / 2;

            checkBox4.AutoSize = true;
            checkBox4.Text = input4;
            panel.Controls.Add(checkBox4);
            checkBox4.Top = checkBox3.Bottom + PADDING;
            checkBox4.Left = PADDING / 2;

            checkBox5.AutoSize = true;
            checkBox5.Text = input5;
            panel.Controls.Add(checkBox5);
            checkBox5.Top = checkBox4.Bottom + PADDING;
            checkBox5.Left = PADDING / 2;

            checkBox6.AutoSize = true;
            checkBox6.Text = input6;
            panel.Controls.Add(checkBox6);
            checkBox6.Top = checkBox5.Bottom + PADDING;
            checkBox6.Left = PADDING / 2;

            checkBox7.AutoSize = true;
            checkBox7.Text = input7;
            panel.Controls.Add(checkBox7);
            checkBox7.Top = checkBox6.Bottom + PADDING;
            checkBox7.Left = PADDING / 2;

            checkBox8.AutoSize = true;
            checkBox8.Text = input8;
            panel.Controls.Add(checkBox8);
            checkBox8.Top = checkBox7.Bottom + PADDING;
            checkBox8.Left = PADDING / 2;
            checkBox8.Padding = BOTTOM_PADDING;
        }
    }
}
