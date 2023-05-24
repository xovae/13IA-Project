using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13IA_Project
{
    public partial class Form1 : Form
    {
        public bool buttonClick = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            lblToolTip.Hide();
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
    }
}
