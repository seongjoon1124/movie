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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            GetMoiveRank();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 newForm = new Form1();
            newForm.Show();
            Program.ac.MainForm = newForm;
            this.Close();
        }
        public void GetMoiveRank()  //movie_list.json 데이터 읽기
        {
            try
            {
                string url = "http://lazytitan.dothome.co.kr/movie_rank.json";
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
                textBox1.Text += "순위 이미지 : " + itemObj["count_img"].ToString();
                textBox1.Text += "영화 제목 : " + itemObj["movie_name"].ToString();
                textBox1.Text += "순위 : " + itemObj["rank"].ToString();
                textBox1.Text += "변동률" + itemObj["variable"].ToString();
                textBox1.Text += "변동 이미지 : " + itemObj["variable_img"].ToString();


            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
