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
            Form2 _form = new Form2();
            String url = _form.GetTicketUrl();

            textBox1.Text += "주소 : " + url;
            //String test = "https://www.naver.com";

            //IWebDriver driver = new ChromeDriver("C:/Users/Sungjun/Desktop/ExamSelenium/packages/Selenium.WebDriver.ChromeDriver.102.0.5005.6102/driver/win32");
            //IWebDriver a = new ChromeDriver();
            //System.Diagnostics.Process.Start(url);


            using (IWebDriver Driver = new ChromeDriver("C:/Users/Sungjun/Desktop/ExamSelenium/packages/Selenium.WebDriver.ChromeDriver.102.0.5005.6102/driver/win32")) //크롬 드라이버 안맞아서 경로 지정
            {


                Driver.Url = url;

                var element = Driver.FindElement(By.XPath("//*[@id='rootDropBox']"));
                comboBox1.Items.Add(element.Text);

                IList<IWebElement> elements;
                //foreach (var item in elements)
                //{
                //    comboBox1.Items.Add((item).Text);
                //}

               
               

                //comboBox1.Items.Add(element.Text);
                

            }

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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
