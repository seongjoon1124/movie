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
        public List<String> ticket_url = new List<String>();
        public List<Button> btn = new List<Button>();    
        public int btn_count = 0;
        public List<PictureBox> pictureBoxes = new List<PictureBox>();
        public int pic_count = 0;
        public List<TextBox> textBoxes = new List<TextBox>();
        public int text_count = 0;
        static String Ticket_url = "";


        String retString;
        Form4 frm4;

        public Form2()
        {
            InitializeComponent();
            GetMoiveList();
        }
        public Form2(Form4 _form4)
        {
            InitializeComponent();
            frm4 = _form4;
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
                retString = myStreamReader.ReadToEnd();

                myStreamReader.Close();
                myResponseStream.Close();

                JsonParser(retString);

            }
            catch (Exception e)
            {
                //
            }


        }

        
        public void JsonParser(String json)
        {
            JArray array = JArray.Parse(json.ToString());
            int y = 10;
            int p_y = 10;
            int t_y = 10;
            

            foreach (JObject itemObj in array)
            {
                btn.Add(new Button());
                btn[btn_count] = new Button();
                this.Controls.Add(btn[btn_count]);
                btn[btn_count].Text = (itemObj["movie_name"].ToString());
                btn[btn_count].Location = new Point(565, y);
                btn[btn_count].Size = new Size(95, 24);

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
                textBoxes[text_count].Text += "\r\n평점 : " + itemObj["grade"].ToString() + "\r\n";
                textBoxes[text_count].Text += "시간 : " + itemObj["movie_time"].ToString() + "\r\n";



                y += 150;
                p_y += 150;

                
                



                ticket_url.Add(itemObj["ticket_link"].ToString());
                btn[btn_count].Click += button_Click;
                
                text_count++;
                btn_count++;
                pic_count++;




                //button 클릭하면 itemObj["ticket_link"].ToString()값을 가지고 다음 form으로 넘어간 후 해당 http 주소에서 지역, 날짜에 대한 값을 입력하면 영화관을 시간 순으로 나열
            }
        }

        public String GetTicketUrl()    //form4로 전환할 때 ticket_url을 가지고 가는 get메소드
        {
            return Ticket_url;
        }
        public void button_Click(object sender, EventArgs e)
        {
            Button thisbtn = sender as Button;
            JArray array = JArray.Parse(retString.ToString());
            try
            {
                foreach (JObject Object in array)
                {
                    if (Object["movie_name"].ToString() == thisbtn.Text)
                    {
                        Ticket_url = Object["ticket_link"].ToString();

                        this.Hide();
                        Form4 newForm = new Form4();
                        newForm.Show();
                        Program.ac.MainForm = newForm;
                        this.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                //
            }
    
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
