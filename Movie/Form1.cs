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
using Movie_list;

namespace Movie
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetHttp();


        }
        public string GetHttp()
        {
            //ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
            //ChromeDriver chromeDriver = new ChromeDriver(chromeDriverService);
            //chromeDriver.Navigate().GoToUrl("http://lazytitan.dothome.co.kr/movie_list.json"); // 웹 사이트에 접속합니다.
            string result = null;

            try
            {
                string url = "http://lazytitan.dothome.co.kr/movie_list.json";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "text/html;charset=UTF-8";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                //myStreamReader.Close();
                //myResponseStream.Close();
                result = myStreamReader.ReadToEnd();
                JsonParser(result);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;

        }
        private void JsonParser(String json)
        {
            JObject obj = JObject.Parse(json);
            JArray array = JArray.Parse(obj["d"].ToString());

            foreach (JObject itemObj in array)
            {
                textBox1.Text += "grade : " + itemObj["grade"].ToString();
                textBox1.Text += "img_url : " + itemObj["img_url"].ToString();
                textBox1.Text += "movie_name : " + itemObj["movie_name"].ToString();
                textBox1.Text += "movie_time" + itemObj["movie_time"].ToString();
                textBox1.Text += "ticket_link : " + itemObj["ticket_link"].ToString();

                
            }
        }
    }
}
