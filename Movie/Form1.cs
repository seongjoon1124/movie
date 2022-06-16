using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;


namespace Movie
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        //private void Form1_Load(object sender, EventArgs e)
        //{


        //}

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 newForm = new Form2();
            newForm.Show();
            Program.ac.MainForm = newForm;
            this.Close();



        }
       

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form3 newForm = new Form3();
            newForm.Show();
            Program.ac.MainForm = newForm;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 newForm = new Form5();
            newForm.Show();
            Program.ac.MainForm = newForm;
            this.Close();
        }
    }
}
