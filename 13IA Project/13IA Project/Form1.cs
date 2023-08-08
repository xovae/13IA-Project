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
        public static frmMenu GetInstance()     //method used for retrieving the current instance of the form from other forms
        {
            return instance;
        }

        const string INTERNALQUIZPATH = "..\\..\\..\\..\\Quiz Resources";
        const string INTERNALRESULTSPATH = "..\\..\\..\\..\\Quiz Output//";             //const strings used for internal file paths of program elements
        const string STUDENTINFO = "..\\..\\..\\..\\Quiz Resources//studentList.csv";
        const string INTERNALBONUSPATH = "..\\..\\..\\..\\Quiz Resources//Bonus Quizzes//";

        const string NINEITQUIZPATH = "W://StudentPickup//1_IT Dept//09IT//";
        const string TENITQUIZPATH = "W://StudentPickup//1_IT Dept//10ITA//";
        //const string FOODQUIZPATH = "W://StudentPickup//";

        const string NINEITBONUSPATH = "W://StudentPickup//1_IT Dept//09IT//";
        const string TENITBONUSPATH = "W://StudentPickup//1_IT Dept//10ITA//";
        //const string FOODBONUSPATH = "W://StudentPickup//";

        const string NINEITRESULTSPATH = "W://Dropboxes//Tr//9IT//";
        const string TENITRESULTSPATH = "W://Dropboxes//Tr//10IT//";
        //const string FOODRESULTSPATH = "W://Dropboxes//";

        //const string NETWORKSTUDENTINFO = "W://1 IT//";

        public string selectedQuiz;
        public string selectedQuizName;         //strings used for the storage of quiz paths, names, and the comparison of results files to existing quizzes
        public string quizResultsCheck;
        public string studentSubject;
        public string studentClass;

        public string[] quizPaths;
        public string[] quizNames;      //string arrays used for storing all quiz paths, names, and results files loaded directly from the given directory
        public string[] quizResults;

        public List<string> userNames = new List<string>();
        public List<string> studentNames = new List<string>();  //string Lists used for the storing of usernames and student's first names
        public List<string> studentSubjectsList = new List<string>();
        public List<string> studentClassesList = new List<string>();
        public List<int> studentPoints = new List<int>();

        public List<string> quizNameList = new List<string>();  //string Lists used for storing the truncated lists of quiz paths and names
        public List<string> quizPathList = new List<string>();

        public List<StudentProfile> studentsList = new List<StudentProfile>();
        public List<StudentProfile> sortedStudentList = new List<StudentProfile>();

        public const int PADDING = 15;

        public frmMenu()
        {
            InitializeComponent();
            instance = this;    //preparing method GetInstance
            Icon = Resources.hbhs_icon; //preparing some graphical elements on loading
            pctLogo.Image = Resources.hbhs_logo___text;
        }

        public void frmMenu_Load(object sender, EventArgs e)
        {
            string[] current;
            string userName = Environment.UserName; //reading the username
            int index = 0;

            if (quizResults != null)
            {
                lstQuizzes.Items.Clear();
                Array.Clear(quizPaths, 0, quizPaths.Length);
                Array.Clear(quizNames, 0, quizNames.Length);
                Array.Clear(quizResults, 0, quizResults.Length);

                quizNameList.Clear();
                quizPathList.Clear();
            }

            userNames.Clear();
            studentNames.Clear();
            studentSubjectsList.Clear();
            studentClassesList.Clear();
            studentPoints.Clear();

            studentsList.Clear();
            sortedStudentList.Clear();

            quizPaths = Directory.GetFiles(INTERNALQUIZPATH, "*.quiz", SearchOption.AllDirectories);
            quizNames = Directory.GetFiles(INTERNALQUIZPATH, "*.quiz").Select(Path.GetFileNameWithoutExtension).ToArray();  //loading all quiz paths, names, and result files into their respective arrays, according to the given directories

            if (Directory.Exists($"{INTERNALRESULTSPATH}//{userName}") != true)
            {
                Directory.CreateDirectory($"{INTERNALRESULTSPATH}//{userName}");
            }

            quizResults = Directory.GetFiles($"{INTERNALRESULTSPATH}//{userName}//", "*.csv").Select(Path.GetFileNameWithoutExtension).ToArray();

            foreach (var item in quizNames)
            {
                quizNameList.Add(item);         //assigning all the contents of the arrays to their respective lists
            }
            foreach (var item in quizPaths)
            {
                quizPathList.Add(item);
            }

            try
            {
                StreamReader sr = new StreamReader(STUDENTINFO);    //create a StreamReader to process all user information (studentList.csv)

                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    current = sr.ReadLine().Split(',');
                    userNames.Add(current[0]);          //add all userNames to the respectivce list
                    studentNames.Add(current[1]);       //add all student's names to the respective list
                    studentSubjectsList.Add(current[2]);
                    studentClassesList.Add(current[3]);
                    studentPoints.Add(int.Parse(current[4]));
                }
                index = userNames.IndexOf(userName);    //get the matching index position of the username in the list for the matching device username
                lblUsername.Text = studentNames[index]; //set the label on the form to reflect this name
                studentSubject = studentSubjectsList[index];
                studentClass = studentClassesList[index];

                for (int i = 0; i < studentNames.Count; i++)
                {
                    studentsList.Add(new StudentProfile(studentNames[i], studentSubjectsList[i], studentClassesList[i], studentPoints[i]));
                }

                sortedStudentList = studentsList.OrderBy(o=>o.Score).ToList();
                sortedStudentList.Reverse();

                lstLeaderboard.Items.Clear();
                lstLeaderboard.Items.Add("Name".PadRight(PADDING) + "Score");
                
                foreach (var item in sortedStudentList)
                {
                    if (item.Class == studentClass)
                    {
                        lstLeaderboard.Items.Add(item.Name.PadRight(PADDING) + item.Score);
                    }
                }
            }
            catch (IOException ex)  //if the file cannot be accessed
            {
                MessageBox.Show($"studentList.csv could not be accessed! {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblUsername.Text = Environment.UserName;    //set the label to the device username as a fallback
            }

            if (quizResults.Length != 0)    //if any results files are present
            {
                lstQuizzes.Items.Clear();
                lstQuizzes.Refresh();
                for (int i = 0; i < quizResults.Length; i++)
                {
                    quizResultsCheck = quizResults[i].Remove(0, userName.Length + 9);   //get the name of the results file with the additional formatting removed (9 characters long: {username} Results-)
                    if (quizNameList.Contains(quizResultsCheck) == true)    //if there is a results file for the given quiz 
                    {
                        index = quizNameList.IndexOf(quizResultsCheck); 
                        quizNameList.Remove(quizResultsCheck);          //remove the quiz from both lists
                        quizPathList.RemoveAt(index);
                    }
                }
                foreach (var item in quizNameList)  //add all quizzes that do not have a results file to the ListBox lstQuizzes
                {
                    lstQuizzes.Items.Add(item);
                }
                if (quizNameList.Count == 0)
                {
                    lstQuizzes.Items.Add("Bonus Quiz");
                }
            }
            else    //if no results files are present
            {
                foreach (var item in quizNames) //add all quizzes to the ListBox lstQuizzes
                {
                    lstQuizzes.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// This event method is called whenever the selected index in ListBox lstQuizzes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstQuizzes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstQuizzes.SelectedIndex != -1)
            {
                if (lstQuizzes.SelectedItem.ToString() == "Bonus Quiz")
                {
                    if (studentSubject == "IT")
                    {
                        selectedQuiz = $"{INTERNALBONUSPATH}//randomBankIT.quiz";
                        selectedQuizName = "Bonus Quiz";
                    }
                    else if (studentSubject == "Food")
                    {
                        selectedQuiz = $"{INTERNALBONUSPATH}//randomBankFood.quiz";
                        selectedQuizName = "Bonus Quiz";
                    }
                }
                else
                {
                    selectedQuiz = quizPathList[lstQuizzes.SelectedIndex];
                    selectedQuizName = lstQuizzes.SelectedItem.ToString();
                }
            }
        }

        /// <summary>
        /// This event method is called when Button btnStart is clicked.
        /// It is used to load the selected quiz into a new form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (selectedQuiz != null)   //if the user has selected a valid quiz
            {
                frmQuestions quiz = new frmQuestions(selectedQuiz, selectedQuizName, lblUsername.Text);
                quiz.Show();    //create a instance of frmQuestions, with the selected quiz
                Hide();         //hide the menu
                lblHint.Hide();
            }
            else
            {
                lblHint.Show();
            }
        }

        private void btnSortByClass_Click(object sender, EventArgs e)
        {
            lstLeaderboard.Items.Clear();
            lstLeaderboard.Items.Add("Name".PadRight(PADDING) + "Score");

            foreach (var item in sortedStudentList)
            {
                if (item.Class == studentClass)
                {
                    lstLeaderboard.Items.Add(item.Name.PadRight(PADDING) + item.Score);
                }
            }
        }

        private void btnSortBySubject_Click(object sender, EventArgs e)
        {
            lstLeaderboard.Items.Clear();
            lstLeaderboard.Items.Add("Name".PadRight(PADDING) + "Score");

            foreach (var item in sortedStudentList)
            {
                if (item.Subject == studentSubject)
                {
                    lstLeaderboard.Items.Add(item.Name.PadRight(PADDING) + item.Score);
                }
            }
        }
    }

    public class StudentProfile
    {
        public string Name;
        public string Class;
        public string Subject;
        public int Score;

        public StudentProfile(string name, string subject, string studentClass, int score)
        {
            Name = name;
            Class = studentClass;
            Subject = subject;
            Score = score;
        }
    }
}
