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

namespace Movie
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            
        }

        public void GetMovie_Area_time()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Url = "https://movie.naver.com/movie/running/current.naver";
                driver.Url = "https://www.naver.com/";

            }
        }

        //private void Parser(String json)
        //{
        //    JArray array = JArray.Parse(json.ToString());

        //    foreach (JObject itemObj in array)
        //    {
        //        textBox1.Text += "평점 : " + itemObj["grade"].ToString();
        //        textBox1.Text += "이미지 주소 : " + itemObj["img_url"].ToString();
        //        textBox1.Text += "영화 제목 : " + itemObj["movie_name"].ToString();
        //        textBox1.Text += "상영 시간" + itemObj["movie_time"].ToString();
        //        textBox1.Text += "티켓 주소 : " + itemObj["ticket_link"].ToString();
        //    }
        //}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
