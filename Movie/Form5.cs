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
    public partial class Form5 : Form
    {
        public List<PictureBox> pictureBoxes = new List<PictureBox>();
        public int pic_count = 0;
        public List<TextBox> textBoxes = new List<TextBox>();
        public int text_count = 0;
        String retString;

        public Form5()
        {
            InitializeComponent();
            GetMovie_to_be_open();
            this.AdjustFormScrollbars(true);
        }

        private void GetMovie_to_be_open()
        {
            string url = "http://lazytitan.dothome.co.kr/movie_to_be_open.json";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream);
            retString = myStreamReader.ReadToEnd();

            myStreamReader.Close();
            myResponseStream.Close();

            JsonParser(retString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 newForm = new Form1();
            newForm.Show();
            Program.ac.MainForm = newForm;
            this.Close();
        }

        public void JsonParser(String json)
        {
            JArray array = JArray.Parse(json.ToString());
        ;
            int y = 10;

            foreach (JObject itemObj in array)
            {
                pictureBoxes.Add(new PictureBox());
                pictureBoxes[pic_count] = new PictureBox();
                this.Controls.Add(pictureBoxes[pic_count]);
                pictureBoxes[pic_count].Location = new Point(25, y);
                pictureBoxes[pic_count].Size = new Size(94, 114);
                pictureBoxes[pic_count].ImageLocation = itemObj["img_url"].ToString();
                pictureBoxes[pic_count].Load(itemObj["img_url"].ToString());

                textBoxes.Add(new TextBox());
                textBoxes[text_count] = new TextBox();
                this.Controls.Add(textBoxes[pic_count]);
                textBoxes[text_count].Location = new Point(150, y);
                textBoxes[text_count].Size = new Size(371, 108);
                textBoxes[text_count].Multiline = true;
                textBoxes[text_count].Text += "제목 : " + itemObj["movie_name"].ToString() + "\r\n";
                textBoxes[text_count].Text += "상영예정일 : " + itemObj["open_date"].ToString() + "\r\n";
                
                y += 150;
    


                text_count++;
                pic_count++;




                //button 클릭하면 itemObj["ticket_link"].ToString()값을 가지고 다음 form으로 넘어간 후 해당 http 주소에서 지역, 날짜에 대한 값을 입력하면 영화관을 시간 순으로 나열
            }
        }
    }
}
