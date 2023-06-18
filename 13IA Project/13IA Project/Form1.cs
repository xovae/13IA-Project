using _13IA_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
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

        const string INTERNALQUIZPATH = "..\\..\\..\\..\\Quiz Resources";
        const string INTERNALRESULTSPATH = "..\\..\\..\\..\\Quiz Output//";
        const string STUDENTINFO = "..\\..\\..\\..\\Quiz Resources//studentList.csv";

        public string selectedQuiz;
        public string selectedQuizName;
        public string verify;

        public string[] quizPaths;
        public string[] quizNames;
        public string[] quizResults;

        public int quizIncrement = 0;

        public List<string> userNames = new List<string>();
        public List<string> studentNames = new List<string>();

        public List<string> quizNameList = new List<string>();
        public List<string> quizPathList = new List<string>();

        public frmMenu()
        {
            InitializeComponent();
            instance = this;
            Icon = Resources.hbhs_icon;
            pctLogo.Image = Resources.hbhs_logo___text;
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            string[] current;
            string userName = Environment.UserName;
            int index = 0;

            quizPaths = Directory.GetFiles(INTERNALQUIZPATH, "*.quiz", SearchOption.AllDirectories);
            quizNames = Directory.GetFiles(INTERNALQUIZPATH, "*.quiz").Select(Path.GetFileNameWithoutExtension).ToArray();
            quizResults = Directory.GetFiles($"{INTERNALRESULTSPATH}//{userName}//", "*.csv").Select(Path.GetFileNameWithoutExtension).ToArray();

            foreach (var item in quizNames)
            {
                quizNameList.Add(item);
            }
            foreach (var item in quizPaths)
            {
                quizPathList.Add(item);
            }

            if (quizResults.Length != 0)
            {
                for (int i = 0; i < quizResults.Length; i++)
                {
                    verify = quizResults[i].Remove(0, userName.Length + 9);
                    if (quizNameList.Contains(verify) == true)
                    {
                        index = quizNameList.IndexOf(verify);
                        quizNameList.Remove(verify);
                        quizPathList.RemoveAt(index);
                    }
                }
                foreach (var item in quizNameList)
                {
                    lstQuizzes.Items.Add(item);
                }
            }
            else
            {
                foreach (var item in quizNames)
                {
                    lstQuizzes.Items.Add(item);
                }
            }

            try
            {
                StreamReader sr = new StreamReader(STUDENTINFO);

                while (!sr.EndOfStream)
                {
                    current = sr.ReadLine().Split(',');
                    userNames.Add(current[0]);
                    studentNames.Add(current[1]);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"studentList.csv could not be accessed! {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            index = userNames.IndexOf(userName);
            lblUsername.Text = studentNames[index];
        }

        private void lstQuizzes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstQuizzes.SelectedIndex != -1)
            {
                selectedQuiz = quizPathList[lstQuizzes.SelectedIndex];
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
    }
}
