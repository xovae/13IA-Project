using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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

        public Random rand = new Random();
        public int order = 0;

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

        public void AddCheckBox(CheckBox check, Control above, string questionText)
        {
            check.AutoSize = true;
            check.Text = questionText;
            panel.Controls.Add(check);
            check.Top = above.Bottom + PADDING;
            check.Left = PADDING / 2;
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
            order = rand.Next(1, 5);
            if (order == 1)
            {
                AddRadioButton(radioButton1, questionLabel, answer);

                AddRadioButton(radioButton2, radioButton1, option1);

                AddRadioButton(radioButton3, radioButton2, option2);

                AddRadioButton(radioButton4, radioButton3, option3);
            }
            else if (order == 2)
            {
                AddRadioButton(radioButton2, questionLabel, option1);

                AddRadioButton(radioButton3, radioButton2, option2);

                AddRadioButton(radioButton4, radioButton3, option3);

                AddRadioButton(radioButton1, radioButton4, answer);
            }
            else if (order == 3)
            {
                AddRadioButton(radioButton3, questionLabel, option2);

                AddRadioButton(radioButton4, radioButton3, option3);

                AddRadioButton(radioButton1, radioButton4, answer);

                AddRadioButton(radioButton2, radioButton1, option1);
            }
            else if (order == 4)
            {
                AddRadioButton(radioButton4, questionLabel, option3);

                AddRadioButton(radioButton1, radioButton4, answer);

                AddRadioButton(radioButton2, radioButton1, option1);

                AddRadioButton(radioButton3, radioButton2, option2);
            }
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

            AddCheckBox(checkBox1, questionLabel, input1);

            AddCheckBox(checkBox2, checkBox1, input2);

            AddCheckBox(checkBox3, checkBox2, input3);

            AddCheckBox(checkBox4, checkBox3, input4);
        }

        public MultiSelect(string questionTopic, string questionText, int numberOfCorrect, string input1, string input2, string input3, string input4, string input5, string input6, string input7, string input8) : base(questionTopic, questionText, input1)
        {
            this.numberOfCorrect = numberOfCorrect;

            AddCheckBox(checkBox1, questionLabel, input1);

            AddCheckBox(checkBox2, checkBox1, input2);

            AddCheckBox(checkBox3, checkBox2, input3);

            AddCheckBox(checkBox4, checkBox3, input4);
            
            AddCheckBox(checkBox5, checkBox4, input5);

            AddCheckBox(checkBox6, checkBox5, input6);

            AddCheckBox(checkBox7, checkBox6, input7);

            AddCheckBox(checkBox8, checkBox7, input8);
        }
    }
}
