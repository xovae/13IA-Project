﻿using _13IA_Project.Properties;
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

        public string selectedQuiz;
        public string selectedQuizName;         //strings used for the storage of quiz paths, names, and the comparison of results files to existing quizzes
        public string quizResultsCheck;

        public string[] quizPaths;
        public string[] quizNames;      //string arrays used for storing all quiz paths, names, and results files loaded directly from the given directory
        public string[] quizResults;

        public List<string> userNames = new List<string>();
        public List<string> studentNames = new List<string>();  //string Lists used for the storing of usernames and student's first names

        public List<string> quizNameList = new List<string>();  //string Lists used for storing the truncated lists of quiz paths and names
        public List<string> quizPathList = new List<string>();

        public frmMenu()
        {
            InitializeComponent();
            instance = this;    //preparing method GetInstance
            Icon = Resources.hbhs_icon; //preparing some graphical elements on loading
            pctLogo.Image = Resources.hbhs_logo___text;
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            string[] current;
            string userName = Environment.UserName; //reading the username
            int index = 0;

            quizPaths = Directory.GetFiles(INTERNALQUIZPATH, "*.quiz", SearchOption.AllDirectories);
            quizNames = Directory.GetFiles(INTERNALQUIZPATH, "*.quiz").Select(Path.GetFileNameWithoutExtension).ToArray();  //loading all quiz paths, names, and result files into their respective arrays, according to the given directories
            quizResults = Directory.GetFiles($"{INTERNALRESULTSPATH}//{userName}//", "*.csv").Select(Path.GetFileNameWithoutExtension).ToArray();

            foreach (var item in quizNames)
            {
                quizNameList.Add(item);         //assigning all the contents of the arrays to their respective lists
            }
            foreach (var item in quizPaths)
            {
                quizPathList.Add(item);
            }

            if (quizResults.Length != 0)    //if any results files are present
            {
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
            }
            else    //if no results files are present
            {
                foreach (var item in quizNames) //add all quizzes to the ListBox lstQuizzes
                {
                    lstQuizzes.Items.Add(item);
                }
            }

            try
            {
                StreamReader sr = new StreamReader(STUDENTINFO);    //create a StreamReader to process all user information (studentList.csv)

                while (!sr.EndOfStream)
                {
                    current = sr.ReadLine().Split(',');
                    userNames.Add(current[0]);          //add all userNames to the respectivce list
                    studentNames.Add(current[1]);       //add all student's names to the respective list
                }
                index = userNames.IndexOf(userName);    //get the matching index position of the username in the list for the matching device username
                lblUsername.Text = studentNames[index]; //set the label on the form to reflect this name
            }
            catch (IOException ex)  //if the file cannot be accessed
            {
                MessageBox.Show($"studentList.csv could not be accessed! {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblUsername.Text = Environment.UserName;    //set the label to the device username as a fallback
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
                selectedQuiz = quizPathList[lstQuizzes.SelectedIndex];
                selectedQuizName = lstQuizzes.SelectedItem.ToString();
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
                frmQuestions quiz = new frmQuestions(selectedQuiz, selectedQuizName);
                quiz.Show();    //create a instance of frmQuestions, with the selected quiz
                Hide();         //hide the menu
                lblHint.Hide();
            }
            else
            {
                lblHint.Show();
            }
        }
    }
}
