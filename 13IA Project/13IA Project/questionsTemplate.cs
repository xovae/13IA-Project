using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace _13IA_Project
{

    public class QuestionTemplate
    {
        public string questionText;
        public string questionTopic;        //possible simplify, remove the string questionText and just read from questionLabel.Text as needed

        public const int PADDING = 10;
        public Padding BOTTOM_PADDING = new Padding(0, 0, 0, PADDING / 5);

        public Panel panel = new Panel();
        public Label questionLabel = new Label();

        public bool questionCorrect = false;

        public Random rand = new Random();
        public int order = 0;

        public QuestionTemplate(string questionTopic, string questionText)
        {
            panel.AutoSize = true;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Padding = new Padding(5);
            panel.BackColor = Color.FromArgb(240, 240, 240);

            questionLabel.AutoSize = true;
            questionLabel.Font = new Font(questionLabel.Font.FontFamily, 10, FontStyle.Bold);
            panel.Controls.Add(questionLabel);
            questionLabel.Top += PADDING / 5;

            this.questionText = questionText;
            questionLabel.Text = questionText;
            this.questionTopic = questionTopic;
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

        public string answerText;

        public TrueFalse(string questionTopic, string questionText, string answer) : base(questionTopic, questionText)
        {
            answerText = answer;

            AddRadioButton(radioButton1, questionLabel, "True");

            AddRadioButton(radioButton2, radioButton1, "False");
        }
    }

    public class MultiChoice : QuestionTemplate
    {
        public string answerMulti;
        public List<RadioButton> radioButtons = new List<RadioButton>();
        
        public MultiChoice(string questionTopic, string questionText, List<string> inputs) : base(questionTopic, questionText)
        {
            answerMulti = inputs[0];

            inputs = inputs.OrderBy(x => rand.Next()).ToList();

            for (int i = 0; i < inputs.Count(); i++)
            {
                radioButtons.Add(new RadioButton());
                if (i == 0)
                {
                    AddRadioButton(radioButtons[i], questionLabel, inputs[i]);
                }
                else
                {
                    AddRadioButton(radioButtons[i], radioButtons[i - 1], inputs[i]);
                }
            }
        }
    }

    public class MultiSelect : QuestionTemplate
    {
        public List<string> answers = new List<string>();

        public List<CheckBox> checkBoxes = new List<CheckBox>();

        public MultiSelect(string questionTopic, string questionText, int numberOfCorrect, List<string> inputs) : base(questionTopic, questionText)
        {
            for (int i = 0; i < numberOfCorrect; i++)
            {
                answers.Add(inputs[i]);
            }

            answers.Sort();

            inputs = inputs.OrderBy(x => rand.Next()).ToList();

            for (int i = 0; i < inputs.Count; i++)
            {
                checkBoxes.Add(new CheckBox());
                if (i == 0)
                {
                    AddCheckBox(checkBoxes[i], questionLabel, inputs[i]);
                }
                else
                {
                    AddCheckBox(checkBoxes[i], checkBoxes[i - 1], inputs[i]);
                }
            }
        }
    }
}
