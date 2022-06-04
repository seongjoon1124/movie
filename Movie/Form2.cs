﻿using System;
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
        public List<String> ticket_url = new List<String>();
        public List<Button> btn = new List<Button>();    
        public int btn_count = 0;

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
            int y = 10;
            

            foreach (JObject itemObj in array)
            {
                textBox1.Text += "평점 : " + itemObj["grade"].ToString();
                textBox1.Text += "이미지 주소 : " + itemObj["img_url"].ToString();
                textBox1.Text += "영화 제목 : " + itemObj["movie_name"].ToString();
                textBox1.Text += "상영 시간" + itemObj["movie_time"].ToString();
                textBox1.Text += "예매하기 : " + itemObj["ticket_link"].ToString(); //button으로 전환 후 클릭 시 영화관, 지역, 시간 form으로 넘어가게
                btn.Add(new Button());
                btn[btn_count] = new Button();
                this.Controls.Add(btn[btn_count]);
                btn[btn_count].Text = (itemObj["movie_name"].ToString());
                btn[btn_count].Location = new Point(565, y);
                btn[btn_count].Size = new Size(95, 24);
               
                y += 60;
                
                ticket_url.Add(itemObj["ticket_link"].ToString());

                btn[btn_count].Click += button_Click;
                
                
                btn_count++;




                //button 클릭하면 itemObj["ticket_link"].ToString()값을 가지고 다음 form으로 넘어간 후 해당 http 주소에서 지역, 날짜에 대한 값을 입력하면 영화관을 시간 순으로 나열
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            Form4 newForm = new Form4();
            newForm.Show();
            Program.ac.MainForm = newForm;
            this.Close();

            int i = 0;
            foreach (String ts in ticket_url)
            {
                if (ts == ticket_url.Find())
                {
                    System.Diagnostics.Process.Start(ticket_url[i]);
                } 
                i++;
            }
    
        }





        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
