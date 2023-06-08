using _13IA_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13IA_Project
{
    public partial class frmMenu : Form
    {
        private static frmMenu instance;
        public static frmMenu GetInstance() 
        {
            return instance;
        }

        const string INTERNALPATH = "..\\..\\..\\..\\Quiz Resources";

        public string selectedQuiz;
        public string selectedQuizName;
        public string[] quizPaths;
        public string[] quizNames;

        //public const float LIST_HEIGHT = 199 / 416 * 100;
        //public const float LIST_WIDTH = 479 / 757 * 100;
        //public const int BUTTON_PADDING = 6;

        //Font SmallFont = new Font("Microsoft Sans Serif", 8);
        //Font MediumFont = new Font("Microsoft Sans Serif", 12);
        //Font LargeFont = new Font("Microsoft Sans Serif", 14);

        public frmMenu()
        {
            InitializeComponent();
            instance = this;
            Icon = Resources.hbhs_icon;
            pctLogo.Image = Resources.hbhs_logo___text;
            lblUsername.Text = Environment.UserName;
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            quizPaths = Directory.GetFiles(INTERNALPATH, "*.csv", SearchOption.AllDirectories);
            quizNames = Directory.GetFiles(INTERNALPATH, "*.csv").Select(Path.GetFileNameWithoutExtension).ToArray();
            foreach (var item in quizNames)
            {
                lstQuizzes.Items.Add(item);
            }
        }

        private void lstQuizzes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstQuizzes.SelectedIndex != -1)
            {
                selectedQuiz = quizPaths[lstQuizzes.SelectedIndex];
                selectedQuizName = lstQuizzes.SelectedItem.ToString();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (selectedQuiz != null)
            {
                frmQuestions quiz = new frmQuestions(selectedQuiz, selectedQuizName);
                quiz.Show();
                Hide();
                lblHint.Hide();
            }
            else
            {
                lblHint.Show();
            }
        }

        private void FormatElements()
        {
            lblTitle.Left = (pnlHeader.Width - lblTitle.Width) / 2;
            lblTitle.Top = (pnlHeader.Height - lblTitle.Height) / 2;

            lstQuizzes.Left = (pnlBody.Width - lstQuizzes.Width) / 2;

            btnStart.Left = (pnlBody.Width - btnStart.Width) / 2;
        }
    }
}
