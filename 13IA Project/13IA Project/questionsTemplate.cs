using System;
using System.Collections.Generic;
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
        public Panel panel = new Panel();
        public Label questionLabel = new Label();

        public QuestionTemplate(string questionTopic, string questionText, string answerText)
        {
            panel.AutoSize = true;
            panel.BorderStyle = BorderStyle.Fixed3D;
            questionLabel.AutoSize = true;
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

        public TrueFalse(string questionTopic, string questionText, string correctAnswer, string falseAnswer1) : base(questionTopic, questionText, correctAnswer)
        {
            radioButton1.Text = correctAnswer; 
            panel.Controls.Add(radioButton1);

            radioButton2.Text = falseAnswer1;
            panel.Controls.Add(radioButton2);
            radioButton2.Top = radioButton1.Height + 10;
        }
    }

    public class MultiChoice : QuestionTemplate
    {
        public RadioButton radioButton1 = new RadioButton();
        public RadioButton radioButton2 = new RadioButton();
        public RadioButton radioButton3 = new RadioButton();
        public RadioButton radioButton4 = new RadioButton();

        public MultiChoice(string questionTopic, string questionText, string correctAnswer, string falseAnswer1, string falseAnswer2, string falseAnswer3) : base(questionTopic, questionText, correctAnswer)
        {
            radioButton1.Text = correctAnswer;
            panel.Controls.Add(radioButton1);
            radioButton1.Top = questionLabel.Height + 10;

            radioButton2.Text = falseAnswer1;
            panel.Controls.Add(radioButton2);
            radioButton2.Top = radioButton1.Bottom + 10;

            radioButton3.Text = falseAnswer2;
            panel.Controls.Add(radioButton3);
            radioButton3.Top = radioButton2.Bottom + 10;

            radioButton4.Text = falseAnswer3;
            panel.Controls.Add(radioButton4);
            radioButton4.Top = radioButton3.Bottom + 10;
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

        public MultiSelect(string questionTopic, string questionText, int numberOfCorrect, string answer1, string answer2, string answer3, string answer4) : base(questionTopic, questionText, answer1)
        {
            this.numberOfCorrect = numberOfCorrect;
            checkBox1.Text = answer1;
            checkBox2.Text = answer2;
            checkBox3.Text = answer3;
            checkBox4.Text = answer4;
        }

        public MultiSelect(string questionTopic, string questionText, int numberOfCorrect, string answer1, string answer2, string answer3, string answer4, string answer5, string answer6, string answer7, string answer8) : base(questionTopic, questionText, answer1)
        {
            this.numberOfCorrect = numberOfCorrect;
            checkBox1.Text = answer1;
            checkBox2.Text = answer2;
            checkBox3.Text = answer3;
            checkBox4.Text = answer4;
            checkBox5.Text = answer5;
            checkBox6.Text = answer6;
            checkBox7.Text = answer7;
            checkBox8.Text = answer8;
        }
    }
}
