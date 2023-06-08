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

        public bool questionCorrect = false;

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

        public void AddCheckBox()
        {

        }

        public void AddRadioButton(RadioButton button, Control above, string questionText)
        {
            button.AutoSize = true;
            button.Text = questionText;
            panel.Controls.Add(button);
            button.Top = above.Bottom + PADDING;
            button.Left = PADDING / 2;
        }

    }

    public class TrueFalse : QuestionTemplate
    {
        public RadioButton radioButton1 = new RadioButton();
        public RadioButton radioButton2 = new RadioButton();

        public TrueFalse(string questionTopic, string questionText, string answer) : base(questionTopic, questionText, answer)
        {
            AddRadioButton(radioButton1, questionLabel, "True");

            AddRadioButton(radioButton2, radioButton1, "False");
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
            AddRadioButton(radioButton1, questionLabel, answer);

            AddRadioButton(radioButton2, radioButton1, option1);

            AddRadioButton(radioButton3, radioButton2, option2);

            AddRadioButton(radioButton4, radioButton3, option3);
        }
    }

    public class MultiSelect : QuestionTemplate
    {
        public int numberOfCorrect;

        public CheckBox checkBox1 = new CheckBox();
        public CheckBox checkBox2 = new CheckBox();
        public CheckBox checkBox3 = new CheckBox();
        public CheckBox checkBox4 = new CheckBox();
        public CheckBox checkBox5 = new CheckBox();
        public CheckBox checkBox6 = new CheckBox();
        public CheckBox checkBox7 = new CheckBox();
        public CheckBox checkBox8 = new CheckBox();

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
