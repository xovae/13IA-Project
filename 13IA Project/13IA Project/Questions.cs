using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace _13IA_Project
{
    public partial class frmQuestions : Form
    {
        public string filePath;     //constants used for storing the quiz's path and name currently being loaded
        public string quizName;

        public int distanceFromTop;
        public int distanceFromLeft;    //variables used for scaling of panels
        public int total = 0;           //counter variable used for user score

        public bool questionComplete = true;   //bool used for checking if all questions are completed

        const int PADDING = 50;
        const int DISTANCE_FROM_OUTER = 100;        //constants used for scaling of elements

        public const string INTERNALQUIZPATH = "..\\..\\..\\..\\Quiz Resources";
        public const string INTERNAL_WRITE_PATH = "..\\..\\..\\..\\Quiz Output//";  //file paths of quiz files and output files

        List<MultiChoice> multichoiceList = new List<MultiChoice>();
        List<MultiSelect> multiselectList = new List<MultiSelect>();    //lists used for storing of question types
        List<TrueFalse> truefalseList = new List<TrueFalse>();

        public frmQuestions(string path, string name)
        {
            InitializeComponent();
            Icon = Properties.Resources.hbhs_icon;
            lblUsername.Text = Environment.UserName;    //update UI elements
            filePath = path;
            lblTitle.Text = name;   //get the information for the selected quiz
            quizName = name;
        }

        /// <summary>
        /// This event method is called upon Form frmQuestion loading.
        /// It is passed a file path for the current selected quiz, and inteprets this line by line, displaying this information visually to the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmQuestions_Load(object sender, EventArgs e)
        {
            if (quizName == "Bonus Quiz")
            {
                LoadRandomQuiz();
            }
            else
            {
                LoadQuiz();
            }
        }

        private void LoadQuiz()
        {
            string[] current;
            string resourcePath;    //variables used for loading quiz information
            List<string> answers = new List<string>();

            StreamReader sr = new StreamReader(filePath);   //create a StreamReader for the selected quiz

            lblTitle.Left = (pnlHeader.Width - lblTitle.Width) / 2; //set the position of the title
            lblTitle.Top = (pnlHeader.Height - lblTitle.Height) / 2;

            try
            {
                while (!sr.EndOfStream)
                {
                    current = Encoding.UTF8.GetString(Convert.FromBase64String(sr.ReadLine())).Split(',');  //read the current line, decoding from a base64 string
                    answers.Clear();

                    if (current[0].Equals("Multichoice", StringComparison.OrdinalIgnoreCase))   //if a multichoice type question
                    {
                        for (int i = 0; i < current.Count() - 5; i++)   //get all the possible answers ( - 5 for the first non-answer elements, i.e. question, topic, resource)
                        {
                            answers.Add(current[i + 5]);
                        }
                        if (current[2] != "")   //if the given question has a resource attached
                        {
                            try
                            {
                                resourcePath = $"{INTERNALQUIZPATH}//{quizName} - Resources//{current[2]}";
                                multichoiceList.Add(new MultiChoice(current[1], resourcePath, current[3], answers)); //attempt to pass the file path of the specified resource
                            }
                            catch (IOException ex)  //if it cannot be accessed
                            {
                                MessageBox.Show($"The given resource could not be accessed! {ex}", "Invalid Resource", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else   //if no resource is attached, pass an empty string ""
                        {
                            multichoiceList.Add(new MultiChoice(current[1], "", current[3], answers));
                        }
                        FormatQuestions(multichoiceList, multichoiceList.Last().panel); //format the current question + panel
                    }
                    else if (current[0].Equals("MultiSelect", StringComparison.OrdinalIgnoreCase))  //if a select all that apply type question
                    {
                        for (int i = 0; i < (current.Count() - 5); i++) //get all answer elements
                        {
                            answers.Add(current[i + 5]);
                        }
                        if (current[2] != "")   //if given a resource path
                        {
                            try
                            {
                                resourcePath = $"{INTERNALQUIZPATH}//{quizName} - Resources//{current[2]}"; //attempt to access the resource
                                multiselectList.Add(new MultiSelect(current[1], resourcePath, current[3], Convert.ToInt32(current[4]), answers));
                            }
                            catch (IOException ex)  //if the resource cannot be accessed
                            {
                                MessageBox.Show($"The given resource could not be accessed! {ex}", "Invalid Resource", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else   //if no resource given
                        {
                            multiselectList.Add(new MultiSelect(current[1], "", current[3], Convert.ToInt32(current[4]), answers));
                        }
                        FormatQuestions(multiselectList, multiselectList.Last().panel); //format the current question
                    }
                    else if (current[0].Equals("TrueFalse", StringComparison.OrdinalIgnoreCase))    //if a true false question
                    {
                        if (current[2] != "")   //if given a resource
                        {
                            resourcePath = $"{INTERNALQUIZPATH}//{quizName} - Resources//{current[2]}"; //attempt to access the resource
                            truefalseList.Add(new TrueFalse(current[1], resourcePath, current[3], current[5]));
                        }
                        else    //if no resource given
                        {
                            truefalseList.Add(new TrueFalse(current[1], "", current[3], current[5]));
                        }
                        FormatQuestions(truefalseList, truefalseList.Last().panel); //format the current question
                    }
                }
                sr.Close(); //once completed, close the Streamreader
                if (truefalseList.Count != 0)   //if TrueFalse questions are present
                {
                    foreach (var item in truefalseList)
                    {
                        item.panel.Height = item.radioButton2.Bottom;   //formatting quick fix due to panel abnormalities
                    }
                }
            }
            catch (IOException ex)  //if the given quiz file cannot be accesssed, give an error, close the window and navigate back to menu
            {
                MessageBox.Show($"The quiz file could not be read! {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                frmMenu.GetInstance().Show();   //show the menu form
            }
        }

        private void LoadRandomQuiz()
        {

        }

        /// <summary>
        /// This method is passed a generic list <T>, and a Panel object. 
        /// It adds the given panel to the premade panel pnlQuestions, and formats the size and location.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="panel"></param>
        private void FormatQuestions<T>(List<T> list, Panel panel)
        {
            pnlQuestions.Controls.Add(panel);   //add the current question panel to the master panel
            panel.Width = pnlQuestions.Width - DISTANCE_FROM_OUTER; //set its width

            distanceFromLeft = (pnlQuestions.Width - panel.Width) / 2;
            panel.Location = new Point(distanceFromLeft, distanceFromTop);  //set its position
            distanceFromTop += panel.Height + PADDING / 2;
        }

        /// <summary>
        /// This event method is called when Button btnCheck is clicked.
        /// It is used to verify the user's input for each question, and output to a results file (given by const string file path INTERNAL_WRITE_PATH).
        /// If any errors are encountered, a suitable error is given.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            string selected;
            string output = $"{INTERNAL_WRITE_PATH}//{lblUsername.Text}//{lblUsername.Text} Results-{quizName}.csv";    //filepath for the given output file

            questionComplete = true;   //reset bool variable to true for the next question

            try
            {
                StreamWriter sw = File.CreateText(output);  //create a StreamWriter for writing the output file

                sw.WriteLine("Question,Topic,UserAnswer(s),CorrectAnswer (MultiChoice),Correct?");  //adding headings

                if (multichoiceList.Count != 0) //if any multichoice questions are present
                {
                    foreach (var item in multichoiceList)   //for every multichoice question
                    {
                        selected = GetCheckedRadio(item.panel); //get the selected radio button
                        if (selected == "") //if a question has not been completed
                        {
                            questionComplete = false;   //set the trigger bool to false
                        }

                        sw.Write($"{item.questionText},{item.questionTopic},{selected},{item.answerMulti},");   //write the question, topic, user's input, and correct answer

                        if (selected.Equals(item.answerMulti, StringComparison.OrdinalIgnoreCase))  //if the user's input is correct
                        {
                            sw.WriteLine("Y");  //write the output to file and increment the total score by one
                            total++;
                        }
                        else
                        {
                            sw.WriteLine("N");  //output no
                        }
                    }
                }
                if (truefalseList.Count != 0)   //if any truefalse questions are present
                {
                    foreach (var item in truefalseList)     //for every truefalse question
                    {
                        selected = GetCheckedRadio(item.panel); //get the user's input
                        if (selected == "")     //if the user has not selected an option
                        {
                            questionComplete = false;   //set the trigger bool to false
                        }

                        sw.Write($"{item.questionText},{item.questionTopic},{selected},{item.answerText},");    //output the question, topic, user input, and answer

                        if (selected.Equals(item.answerText, StringComparison.OrdinalIgnoreCase))   //if the user's answer is correct
                        {
                            sw.WriteLine("Y");  //output yes and increment total score by one
                            total++;
                        }
                        else
                        {
                            sw.WriteLine("N");  //output no
                        }
                    }
                }
                if (multiselectList.Count != 0) //if any select all that apply questions are present
                {
                    List<string> inputs = new List<string>();   //string list used for storing the user's selected checkboxes

                    foreach (var item in multiselectList)   //for each select all that apply question
                    {
                        inputs = GetChecked(item.panel);    //get all the user's selected inputs
                        if (inputs.Count == 0)  //if the user has not selected any options
                        {
                            questionComplete = false;   //set the trigger obol to false
                        }

                        sw.Write($"{item.questionText},{item.questionTopic},"); //write the question and topic

                        inputs.Sort();  //sort the list of inputs

                        foreach (var item2 in inputs)   //write each select input
                        {
                            sw.Write($"{item2},");
                        }

                        if (inputs.SequenceEqual(item.answers) == true) //if the selected inputs matches the answers (correct answer)
                        {
                            sw.WriteLine("Y");  //output yes and increment the total score by one
                            total++;
                        }
                        else
                        {
                            sw.WriteLine("N");  //output no
                        }
                    }   
                }

                sw.Write($"Score is {total} out of {multichoiceList.Count + multiselectList.Count + truefalseList.Count}"); //output the user's total score
                sw.Close(); //close the StreamWriter
            }
            catch (IOException ex)  //if the StreamWriter fails
            {
                MessageBox.Show($"The results could not be successfully exported! {ex}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            if (questionComplete == false)  //if any questions were not completed, present a message to the user, and delete the output file
            {
                MessageBox.Show("Complete all quiz questions before submitting!", "Quiz Incomplete!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                File.Delete(output);
                total = 0;
            }
            else  //if output was successful
            {
                Close();    //close the form
                frmMenu.GetInstance().Show();   //show the menu
            }
        }

        /// <summary>
        /// This method is given a generic Panel.
        /// It checks for each control in the container, and gets the text data of any selected RadioButtons.
        /// Otherwise, it reutrns an empty string ""
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        private string GetCheckedRadio(Panel container)
        {
            foreach (var control in container.Controls) //for every control
            {
                if (control is RadioButton radio && radio.Checked)  //if the control is a RadioButton and checked
                {
                    return radio.Text;  //return its text data
                }
            }

            return "";
        }

        /// <summary>
        /// This method is a passed a generic Panel.
        /// For every CheckBox found in the container, it gets it's text data and adds it to list checks.
        /// It then returns the string List checks
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        private List<string> GetChecked(Panel container)
        {
            List<string> checks = new List<string>();   //string list used for storing selected inputs

            foreach (var control in container.Controls) //for each control in the panel
            {
                if (control is CheckBox check && check.Checked) //if the control is a CheckBox and selcted
                {
                    checks.Add(check.Text); //add its text data to the list
                }
            }
            return checks;  //return the list
        }

        /// <summary>
        /// This event method shows the menu form if the quiz form is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmQuestions_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMenu.GetInstance().Show();
        }
        
        /// <summary>
        /// This event method is called whenever the form is resized.
        /// It dynamically resizes all the question objects in the form to fit the size of the current window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmQuestions_SizeChanged(object sender, EventArgs e)
        {
            pnlQuestions.Width = Width;
            foreach (var item in multichoiceList)
            {
                ResizeQuestions(multiselectList, item.panel);       //calling method ResizeQuestions for every question
            }
            foreach (var item in multiselectList)
            {
                ResizeQuestions(multiselectList, item.panel);
            }
            foreach (var item in truefalseList)
            {
                ResizeQuestions(truefalseList, item.panel);
            }

            lblTitle.Left = (pnlHeader.Width - lblTitle.Width) / 2; //repositioning the label
            lblTitle.Top = (pnlHeader.Height - lblTitle.Height) / 2;
        }

        /// <summary>
        /// generic method used for resizing Panel objects in the form window.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="panel"></param>
        private void ResizeQuestions<T>(List<T> list, Panel panel)
        {
            panel.Width = pnlQuestions.Width - DISTANCE_FROM_OUTER;
            int distanceFromLeft = (pnlQuestions.Width - panel.Width) / 2;  //setting the scaling and positioning of the question objects
            panel.Left = distanceFromLeft;
        }
    }
}
