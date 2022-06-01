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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            GetMoiveList();
        }

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
           
        //}
        

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 newForm = new Form1();
            newForm.Show();
            Program.ac.MainForm = newForm;
            this.Close();
        }

        public void GetMoiveList()  //movie_list.json 데이터 읽기
        {
            try
            {
                string url = "http://lazytitan.dothome.co.kr/movie_list.json";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream);
                string retString = myStreamReader.ReadToEnd();

                myStreamReader.Close();
                myResponseStream.Close();

                JsonParser(retString);

            }
            catch (Exception e)
            {
                //
            }


        }
        private void JsonParser(String json)
        {
            JArray array = JArray.Parse(json.ToString());

            foreach (JObject itemObj in array)
            {
                textBox1.Text += "평점 : " + itemObj["grade"].ToString();
                textBox1.Text += "이미지 주소 : " + itemObj["img_url"].ToString();
                textBox1.Text += "영화 제목 : " + itemObj["movie_name"].ToString();
                textBox1.Text += "상영 시간" + itemObj["movie_time"].ToString();
                textBox1.Text += "티켓 주소 : " + itemObj["ticket_link"].ToString();


            }
        }

       
    }
}
