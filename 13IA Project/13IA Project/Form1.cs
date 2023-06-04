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
        public bool buttonClick = true;

        const string INTERNALPATH = "..\\..\\..\\..\\Quiz Resources";

        public string selectedQuiz;
        public string[] quizPaths;
        public string[] quizNames;

        public frmMenu()
        {
            InitializeComponent();
            Icon = Resources.hbhs_icon;
            lblUsername.Text = Environment.UserName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            button1.Enabled = false;
            lblToolTip.Hide();

            quizPaths = Directory.GetFiles(INTERNALPATH, "*.csv", SearchOption.AllDirectories);
            quizNames = Directory.GetFiles(INTERNALPATH, "*.csv").Select(Path.GetFileNameWithoutExtension).ToArray();
            foreach (var item in quizNames)
            {
                lstQuizzes.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            buttonClick = true;
            label1.Text = "Button!";
            label1.BackColor = Color.Aquamarine;
            lblToolTip.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (buttonClick == true)
            {
                label1.Text = "clicked!";
                label1.BackColor = Color.White;
                buttonClick = false;
                button1.Enabled = true;
                lblToolTip.Show();
            }
        }

        private void lstQuizzes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstQuizzes.SelectedIndex != -1)
            {
                selectedQuiz = quizPaths[lstQuizzes.SelectedIndex];
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (selectedQuiz != null)
            {
                frmQuestions quiz = new frmQuestions(selectedQuiz);
                quiz.Show();
                Hide();
            }
            else
            {
                lblHint.Show();
            }
        }
    }
}
