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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
        public bool scoringEnabled = false;

        const int PADDING = 50;
        const int DISTANCE_FROM_OUTER = 100;        //constants used for scaling of elements

        //const string QUIZPATH = "..\\..\\..\\..\\Quiz Resources";
        const string QUIZPATH = "W://1 IT//9jboulto-13IA//Quiz-Resources";                          //internal and network locations of quiz files

        //const string WRITEPATH = "..\\..\\..\\..\\Quiz Output//";
        const string WRITEPATH = "W://1 IT//9jboulto-13IA//Quiz-Results//";                         //internal and network directories to write results files to

        //const string STUDENTINFO = "..\\..\\..\\..\\Quiz Resources//studentList.csv";
        const string STUDENTINFO = "W://1 IT//9jboulto-13IA//Quiz-Resources//studentList.csv";      //internal and network locations for studentList.csv, a core data file

        List<MultiChoice> multichoiceList = new List<MultiChoice>();
        List<MultiSelect> multiselectList = new List<MultiSelect>();    //lists used for storing of question types
        List<TrueFalse> truefalseList = new List<TrueFalse>();

        public frmQuestions(string path, string name, string displayName, string studentName)
        {
            InitializeComponent();
            Icon = Properties.Resources.hbhs_icon;
            lblUsername.Text = studentName;    //update UI elements
            filePath = path;
            lblTitle.Text = displayName;   //get the information for the selected quiz
            quizName = name;

            if (filePath.Contains("s-"))
            {
                scoringEnabled = true;
            }
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

        /// <summary>
        /// This method is used for the loading of generic quizzes.
        /// </summary>
        private void LoadQuiz()
        {
            try
            {
                StreamReader sr = new StreamReader(filePath);   //create a StreamReader for the selected quiz
                
                while (!sr.EndOfStream)
                {
                    LoadQuestion(sr.ReadLine());
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
            catch (IOException)  //if the given quiz file cannot be accesssed, give an error, close the window and navigate back to menu
            {
                MessageBox.Show($"The quiz file could not be read!", "Read Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                frmMenu.GetInstance().Show();   //show the menu form
            }
        }

        /// <summary>
        /// This method is used for the loading of 'bonus' quizzes, from a central 'quiz bank' file
        /// </summary>
        private void LoadRandomQuiz()
        {
            int totalQuestions = 0;
            int increment;

            List<int> previousRandoms = new List<int>();    //list used for storing previously generated questions to prevent double ups

            Random rand = new Random();     //used for random selection of questions

            try
            {
                StreamReader sr = new StreamReader(filePath);   //create a StreamReader for the selected quiz

                while (!sr.EndOfStream) 
                {
                    totalQuestions++;   //get a count of the total number of questions within the quiz bank
                    sr.ReadLine();
                }

                for (int i = 0; i < 10; i++)    //generates 10 questions
                {
                    sr.DiscardBufferedData();
                    sr.BaseStream.Position = 0;     //reset the StreamReader to the start of the file

                    increment = rand.Next(1, totalQuestions);   //select a random integer value to determine the index of the next question from the list
                    if (!previousRandoms.Contains(increment))   //if the question has not already been used
                    {
                        for (int i2 = 0; i2 < increment; i2++)
                        {
                            sr.ReadLine();  //skip forward to the select line
                        }
                        LoadQuestion(sr.ReadLine());    //read the contents of the chosen line, passing it to method LoadQuestion to prepare the question
                    }
                    else   //if the question has been used before (within the same quiz)
                    {
                        i--;    //decrement the loop by one
                    }
                    previousRandoms.Add(increment); //add the index position just used to the list of previously used indexes
                }
            }
            catch (IOException)  //if any errors are encountered in reading the quiz file
            {
                MessageBox.Show($"The quiz file could not be read!", "Invalid Quiz File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// This method is used for the generic loading of a quiz question, preparing it graphically.
        /// It is passed the raw line form a quiz file, and processes this data to create a new question object.
        /// </summary>
        /// <param name="rawLine"></param>
        private void LoadQuestion(string rawLine)
        {
            string[] current;
            string resourcePath;
            List<string> answers = new List<string>();      //variables used for temporary storage of information

            lblTitle.Left = (pnlHeader.Width - lblTitle.Width) / 2; //set the position of the title
            lblTitle.Top = (pnlHeader.Height - lblTitle.Height) / 2;

            current = Encoding.UTF8.GetString(Convert.FromBase64String(rawLine)).Split(',');  //read the current line, decoding from a base64 string
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
                        resourcePath = $"{QUIZPATH}//{quizName} - Resources//{current[2]}";
                        multichoiceList.Add(new MultiChoice(current[1], resourcePath, current[3], answers)); //attempt to pass the file path of the specified resource
                    }
                    catch (IOException)  //if it cannot be accessed
                    {
                        MessageBox.Show($"An image resource could not be accessed!", "Invalid Resource", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else   //if no resource is attached, pass an empty string ""
                {
                    multichoiceList.Add(new MultiChoice(current[1], "", current[3], answers));
                }
                if (multichoiceList.Count != 0)
                {
                    FormatQuestions(multichoiceList, multichoiceList.Last().panel); //format the current question + panel
                }
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
                        resourcePath = $"{QUIZPATH}//{quizName} - Resources//{current[2]}"; //attempt to access the resource
                        multiselectList.Add(new MultiSelect(current[1], resourcePath, current[3], Convert.ToInt32(current[4]), answers));
                    }
                    catch (IOException)  //if the resource cannot be accessed
                    {
                        MessageBox.Show($"An image resource could not be accessed!", "Invalid Resource", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else   //if no resource given
                {
                    multiselectList.Add(new MultiSelect(current[1], "", current[3], Convert.ToInt32(current[4]), answers));
                }
                if (multiselectList.Count != 0)
                {
                    FormatQuestions(multiselectList, multiselectList.Last().panel); //format the current question
                }
            }
            else if (current[0].Equals("TrueFalse", StringComparison.OrdinalIgnoreCase))    //if a true false question
            {
                if (current[2] != "")   //if given a resource
                {
                    try
                    {
                        resourcePath = $"{QUIZPATH}//{quizName} - Resources//{current[2]}"; //attempt to access the resource
                        truefalseList.Add(new TrueFalse(current[1], resourcePath, current[3], current[5]));
                    }
                    catch (IOException)
                    {
                        MessageBox.Show($"An image resource could not be accessed!", "Invalid Resource", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else    //if no resource given
                {
                    truefalseList.Add(new TrueFalse(current[1], "", current[3], current[5]));
                }
                if (truefalseList.Count != 0)
                {
                    FormatQuestions(truefalseList, truefalseList.Last().panel); //format the current question
                }
            }
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
        /// It is used to verify the user's input for each question, and output to a results file (given by const string file path INTERNALWRITEPATH).
        /// If any errors are encountered, a suitable error is given.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            List<string> incompleteQuestions = new List<string>();

            string selected;
           
            string output = $"{WRITEPATH}//{Environment.UserName}//{Environment.UserName} Results-{quizName}.csv";    //filepath for the given output file
           
            questionComplete = true;   //reset bool variable to true for the next question

            try
            {
                StreamWriter sw = File.CreateText(output);  //create a StreamWriter for writing the output file
                File.SetAttributes(output, FileAttributes.Hidden);

                sw.WriteLine("Question,Topic,UserAnswer(s),CorrectAnswer (MultiChoice),Correct?");  //adding headings

                if (multichoiceList.Count != 0) //if any multichoice questions are present
                {
                    foreach (var item in multichoiceList)   //for every multichoice question
                    {
                        selected = GetCheckedRadio(item.panel); //get the selected radio button
                        if (selected == "") //if a question has not been completed
                        {
                            questionComplete = false;   //set the trigger bool to false
                            item.panel.BackColor = Color.IndianRed;
                            incompleteQuestions.Add(item.questionText);
                        }
                        else
                        {
                            item.panel.BackColor = Color.Transparent;
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
                            item.panel.BackColor = Color.IndianRed;
                            incompleteQuestions.Add(item.questionText);
                        }
                        else
                        {
                            item.panel.BackColor = Color.Transparent;
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
                            questionComplete = false;   //set the trigger bool to false
                            item.panel.BackColor = Color.IndianRed;
                            incompleteQuestions.Add(item.questionText);
                        }
                        else
                        {
                            item.panel.BackColor = Color.Transparent;
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
            catch (IOException)  //if the StreamWriter fails
            {
                MessageBox.Show($"The results could not be successfully exported! Please retry.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            if (questionComplete == false)  //if any questions were not completed, present a message to the user, and delete the output file
            {
                var incompleteOutput = string.Join(Environment.NewLine, incompleteQuestions);
                MessageBox.Show($"Complete all quiz questions before submitting:{Environment.NewLine}{incompleteOutput}", "Quiz Incomplete!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                File.Delete(output);
                total = 0;
                incompleteQuestions.Clear();
            }
            else  //if output was successful
            {
                if (quizName == "Bonus Quiz")
                {
                    File.Delete(output);    //delete the output file (not needed for bonus quizzes)
                }

                try
                {
                    string[] current;

                    int tempScore = 0;

                    StreamReader sr = new StreamReader(STUDENTINFO);

                    List<int> studentScores = new List<int>();
                    List<string> studentNames = new List<string>();         //string lists used for temporary storage of studentList.csv information
                    List<string> studentSubjects = new List<string>();
                    List<string> studentClassesList = new List<string>();
                    List<string> userNames = new List<string>();

                    sr.ReadLine();  //skip the headings of the csv file

                    while (!sr.EndOfStream)
                    {
                        current = sr.ReadLine().Split(',');
                        userNames.Add(current[0]);
                        studentNames.Add(current[1]);               //read all student information into their respective lists for temporary storage
                        studentSubjects.Add(current[2]);
                        studentClassesList.Add(current[3]);
                        studentScores.Add(int.Parse(current[4]));
                    }

                    sr.Close(); //close the StreamReader object

                    int index = userNames.IndexOf(Environment.UserName);    //get the index of the line to be edited
                    tempScore = studentScores[index] + total;               //calculate the new score value for the user

                    if (EditLine($"{userNames[index]},{studentNames[index]},{studentSubjects[index]},{studentClassesList[index]},{tempScore}", STUDENTINFO, index) == 0)    //pass all the information at the given index location to method EditLine to update the student's information
                    {
                        if (scoringEnabled == true || quizName == "Bonus Quiz")
                        {
                            MessageBox.Show($"You scored {total} out of {multichoiceList.Count + multiselectList.Count + truefalseList.Count} ({total/(multichoiceList.Count + multiselectList.Count + truefalseList.Count) * 100}%)!", "Final Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        Close();    //close the form if submission was successful
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show($"Please retry submitting the quiz!", "Output error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// This method is used to edit the contents of a specific line in studentList.csv.
        /// </summary>
        /// <param name="newLine"></param>
        /// <param name="fileName"></param>
        /// <param name="editIndex"></param>
        private int EditLine(string newLine, string fileName, int editIndex)
        {
            try
            {
                string[] fileArray = File.ReadAllLines(fileName);   //read all the file into a temporary array
                fileArray[editIndex + 1] = newLine;                 //change the contents of the array (+1 accounts for the lack of headings)
                File.WriteAllLines(fileName, fileArray);            //rewrite the edited information to studentList.csv
                return 0;
            }
            catch (IOException)
            {
                MessageBox.Show($"Please retry submitting the quiz!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
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
        /// This event method shows the menu form if the quiz form is closed, and calls it's load event to update the displayed information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmQuestions_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMenu.GetInstance().Show();
            frmMenu.GetInstance().frmMenu_Load(this, null);
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
