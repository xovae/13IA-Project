using _13IA_Teacher_Quiz_Software.Properties;
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

namespace _13IA_Teacher_Quiz_Software
{
    public partial class frmQuiz : Form
    {
        const string OPENFILTER = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
        const string SAVEFILTER = "Quiz Files (*.quiz)|*.quiz|All Files (*.*)|*.*";

        const string INTERNALQUIZPATH = "..\\..\\..\\..\\Quiz Resources";

        public frmQuiz()
        {
            InitializeComponent();
            Icon = Resources.hbhs_icon;
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
    }
}
