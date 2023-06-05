using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace _13IA_Project
{
   public class question
   {
      public string questionText;
      public string answers;
      public Panel panel;

      public question(string questionText, string answers, Panel panel)
      {
         this.questionText = questionText;
         this.answers = answers;
         this.panel = panel;
      }


   }

   public class MultiChoice : question
   {

      public RadioButton radioButton1;
      public RadioButton radioButton2;
      public RadioButton radioButton3;
      public RadioButton radioButton4;

      public MultiChoice(string questionText, string answers, Panel panel, string a1, string a2, string a3, string a4) : base(questionText, answers, panel)
      {
         radioButton1.Text = a1;
         radioButton2.Text = a2;
         radioButton3.Text = a3;
         radioButton4.Text = a4;
      }
   }

   public class TrueFalse : question
   {
      public RadioButton radioButton1;
      public RadioButton radioButton2;

      public TrueFalse(string questionText, string answers, Panel panel, string a1, string a2) : base(questionText, answers, panel)
      {
         radioButton1.Text = a1;
         radioButton2.Text = a2;
      }
   }

   public class FillInTheBlank : question
   {
      public Label Label1;

      public FillInTheBlank(string questionText, string answers, Panel panel) : base(questionText, answers, panel)
      {
         Label1.Text = answers;
      }
   }

   public class Matching : question
   {
      public Label Label1;
      public Label Label2;
      public Label Label3;
      public Label Label4;

      public Matching(string questionText, string answers, Panel panel, string a1, string a2, string a3, string a4) : base(questionText, answers, panel)
      {
         Label1.Text = a1;
         Label2.Text = a2;
         Label3.Text = a3;
         Label4.Text = a4;
      }
   }

   public class ShortAnswer : question
   {
      public Label Label1;

      public ShortAnswer(string questionText, string answers, Panel panel) : base(questionText, answers, panel)
      {
         Label1.Text = answers;
      }
   }

   public class Essay : question
   {
      public Label Label1;

      public Essay(string questionText, string answers, Panel panel) : base(questionText, answers, panel)
      {
         Label1.Text = answers;
      }
   }

   public class Ranking : question
   {
      public Label Label1;
      public Label Label2;
      public Label Label3;
      public Label Label4;

      public Ranking(string questionText, string answers, Panel panel, string a1, string a2, string a3, string a4) : base(questionText, answers, panel)
      {
         Label1.Text = a1;
         Label2.Text = a2;
         Label3.Text = a3;
         Label4.Text = a4;
      }
   }

   public class MultiSelect 
   {
      public CheckBox CheckBox1;
      public CheckBox CheckBox2;
      public CheckBox CheckBox3;
      public CheckBox CheckBox4;

      public MultiSelect(string questionText, string answers, Panel panel, string a1, string a2, string a3, string a4) : base(questionText, answers, panel)
      {
         CheckBox1.Text = a1;
         CheckBox2.Text = a2;
         CheckBox3.Text = a3;
         CheckBox4.Text = a4;
      }
   }

}
