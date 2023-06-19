using _13IA_Teacher_Quiz_Software.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13IA_Teacher_Quiz_Software
{
    public partial class frmQuiz : Form
    {
        const string OPENFILTER = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
        const string SAVEFILTER = "Quiz Files (*.quiz)|*.quiz|All Files (*.*)|*.*";
        const string RESOURCEFILTER = "Image Files (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp|All Files (*.*)|*.*";

        const string INTERNALQUIZPATH = "..\\..\\..\\..\\Quiz Resources";
        const string INTERNALRESULTSPATH = "..\\..\\..\\..\\Quiz Output//";

        public string[] quizPaths;
        public string[] quizNames;
        public string selectedQuizPath;
        public string selectedQuizName;

        public frmQuiz()
        {
            InitializeComponent();
            Icon = Resources.hbhs_icon;
        }

        private void frmQuiz_Load(object sender, EventArgs e)
        {
            quizPaths = Directory.GetFiles(INTERNALQUIZPATH, "*.quiz", SearchOption.AllDirectories);
            quizNames = Directory.GetFiles(INTERNALQUIZPATH, "*.quiz").Select(Path.GetFileNameWithoutExtension).ToArray();

            foreach (var item in quizNames)
            {
                cmbQuizzes.Items.Add(item);
            }
        }

        private void cmbQuizzes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbQuizzes.SelectedIndex != -1)
            {
                selectedQuizPath = quizPaths[cmbQuizzes.SelectedIndex];
                selectedQuizName = quizNames[cmbQuizzes.SelectedIndex];
            }
        }

        private void btnAddResource_Click(object sender, EventArgs e)
        {
            string resourceDirectory; 

            if (selectedQuizPath != null)
            {
                if (Directory.Exists($"{INTERNALQUIZPATH}//{selectedQuizName} - Resources") != true)
                {
                    Directory.CreateDirectory($"{INTERNALQUIZPATH}//{selectedQuizName} - Resources");
                }
                
                openFileDialog1.Filter = RESOURCEFILTER;
                resourceDirectory = $"{INTERNALQUIZPATH}//{selectedQuizName} - Resources";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.Copy(openFileDialog1.FileName, $"{resourceDirectory}//{openFileDialog1.SafeFileName}");
                    }
                    catch (IOException ex)
                    { 
                        MessageBox.Show($"The selected resource could not be added! {ex}", "Invalid Resource", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = OPENFILTER;
            saveFileDialog1.Filter = SAVEFILTER;
            saveFileDialog1.InitialDirectory = INTERNALQUIZPATH;

            byte[] current;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StreamReader sr = new StreamReader(openFileDialog1.FileName);
                        StreamWriter sw = File.CreateText(saveFileDialog1.FileName);

                        while (!sr.EndOfStream)
                        {
                            current = Encoding.UTF8.GetBytes(sr.ReadLine());
                            sw.WriteLine(Convert.ToBase64String(current));
                        }

                        sr.Close();
                        sw.Close();
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show($"The selected file could not be encoded! {ex}", "Encoding Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        File.Delete(saveFileDialog1.FileName);
                    }
                }
            }
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = SAVEFILTER;
            saveFileDialog1.Filter = OPENFILTER;
            openFileDialog1.InitialDirectory = INTERNALQUIZPATH;

            byte[] current;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StreamReader sr = new StreamReader(openFileDialog1.FileName);
                        StreamWriter sw = File.CreateText(saveFileDialog1.FileName);

                        try
                        {
                            while (!sr.EndOfStream)
                            {
                                current = Convert.FromBase64String(sr.ReadLine());
                                sw.WriteLine(Encoding.UTF8.GetString(current));
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"The selected file was not correctly encoded {ex}", "Decoding Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        sr.Close();
                        sw.Close();


                        DialogResult dr = MessageBox.Show("Would you like to open the decoded file?", "Decoding Successful", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dr == DialogResult.Yes)
                        {
                            Process.Start(saveFileDialog1.FileName);
                        }
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show($"The selected file could not be Decoded! {ex}", "Decoding Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        File.Delete(saveFileDialog1.FileName);
                    }
                }
            }
        }

        private void btnDecodeResults_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = OPENFILTER;
            saveFileDialog1.Filter = OPENFILTER;
            openFileDialog1.InitialDirectory = INTERNALRESULTSPATH;

            byte[] current;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StreamReader sr = new StreamReader(openFileDialog1.FileName);
                        StreamWriter sw = File.CreateText(saveFileDialog1.FileName);

                        while (!sr.EndOfStream)
                        {
                            current = Convert.FromBase64String(sr.ReadLine());
                            sw.WriteLine(Encoding.UTF8.GetString(current));
                        }

                        sr.Close();
                        sw.Close();


                        DialogResult dr = MessageBox.Show("Would you like to open the decoded file?", "Decoding Successful", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dr == DialogResult.Yes)
                        {
                            Process.Start(saveFileDialog1.FileName);
                        }
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show($"The selected file could not be Decoded! {ex}", "Decoding Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        File.Delete(saveFileDialog1.FileName);
                    }
                }
            }
        }
    }
}
