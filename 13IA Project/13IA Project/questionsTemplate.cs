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
        public string questionTopic;
        public string answerText;
        public Panel panel;

        public QuestionTemplate(string questionText, string questionTopic, string answerText)
        {
            this.questionText = questionText;
            this.questionTopic = questionTopic;
            this.answerText = answerText;
        }
    }

    public class TrueFalse : QuestionTemplate
    {
        public RadioButton radioButton1;
        public RadioButton radioButton2;

        public TrueFalse(string questionText, string questionTopic, string correctAnswer, string falseAnswer1) : base(questionText, questionTopic, correctAnswer)
        {
            radioButton1.Text = correctAnswer; 
            radioButton2.Text = falseAnswer1;
        }
    }

    public class MultiChoice : QuestionTemplate
    {
        public RadioButton radioButton1;
        public RadioButton radioButton2;
        public RadioButton radioButton3;
        public RadioButton radioButton4;

        public MultiChoice(string questionText, string questionTopic, string correctAnswer, string falseAnswer1, string falseAnswer2, string falseAnswer3) : base(questionText, questionTopic, correctAnswer)
        {
            radioButton1.Text = correctAnswer;
            radioButton2.Text = falseAnswer1;
            radioButton3.Text = falseAnswer2;
            radioButton4.Text = falseAnswer3;
        }
    }

    //public class MultiSelect: QuestionTemplate
    //{
    //    public CheckBox checkBox1;
    //    public CheckBox checkBox2;
    //    public CheckBox checkBox3;
    //    public CheckBox checkBox4;
    //    public CheckBox checkBox5;
    //    public CheckBox checkBox6;
    //    public CheckBox checkBox7;
    //    public CheckBox checkBox8;

    //    public MultiSelect(string questionText, string questionTopic, string answer1, string answer2, string answer3, string answer4) : base(questionText, questionTopic, answer1)
    //    {
    //        checkBox1.Text = correctAnswer;
    //        checkBox2.Text = falseAnswer1;
    //        checkBox3.Text = falseAnswer2;
    //        checkBox4.Text = falseAnswer3;
    //    }
        
    //    public MultiSelect(string questionText, string questionTopic, string correctAnswer, ) : base(questionText, questionTopic, correctAnswer)
    //    {
    //        checkBox1.Text = correctAnswer;
    //        checkBox2.Text = falseAnswer1;
    //        checkBox3.Text = falseAnswer2;
    //        checkBox4.Text = falseAnswer3;
    //    }
    //}
}
