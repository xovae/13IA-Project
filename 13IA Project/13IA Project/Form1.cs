﻿using _13IA_Project.Properties;
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

        const string INTERNALQUIZPATH = "..\\..\\..\\..\\Quiz Resources";
        const string INTERNALRESULTSPATH = "..\\..\\..\\..\\Quiz Output//";

        public string selectedQuiz;
        public string selectedQuizName;
        public string[] quizPaths;
        public string[] quizNames;
        public string[] quizResults;

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
            quizPaths = Directory.GetFiles(INTERNALQUIZPATH, "*.csv", SearchOption.AllDirectories);
            quizNames = Directory.GetFiles(INTERNALQUIZPATH, "*.csv").Select(Path.GetFileNameWithoutExtension).ToArray();
            quizResults = Directory.GetFiles($"{INTERNALRESULTSPATH}//{lblUsername.Text}//", "*.csv").Select(Path.GetFileNameWithoutExtension).ToArray();
            //foreach (var item in quizResults)
            //{
            //    item.Remove(0, lblUsername.Text.Length + 9);
            //}
            //foreach (var item in quizNames)
            //{
            //    for (int i = 0; i < quizResults.Length; i++)
            //    {
            //        if (!item.Contains(quizResults[i]))
            //        {
            //            lstQuizzes.Items.Add(item);
            //        }
            //    }
            //}
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
    }
}
