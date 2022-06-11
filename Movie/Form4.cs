using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using Movie;

namespace Movie
{
    public partial class Form4 : Form
    {
        
        public Form4()
        {
            InitializeComponent();
            GetMovie_Area_time();
        }
        

        public void GetMovie_Area_time()
        {
            Form2 _form = new Form2(this); 
            string url = _form.GetTicketUrl();
            
            textBox1.Text = "평점" + url;

            IWebDriver a = new ChromeDriver();
            



        }

        


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 newForm = new Form2();
            newForm.Show();
            Program.ac.MainForm = newForm;
            this.Close();
        }
    }
}
