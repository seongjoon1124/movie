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

        static String Ticket_url = "";

        private Form activeForm;

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

        private void OpenChildForm(Form childForm, Object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.Controls.Add(childForm);
            this.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

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
 
            

            foreach (JObject itemObj in array)
            {
                Button btn = new Button();
                btn = new Button();
                this.Controls.Add(btn);
                btn.Name = (itemObj["movie_name"].ToString());
                btn.Text = "예매하기";
                btn.Location = new Point(565, y);
                btn.Size = new Size(95, 114);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = new Font("NanumBarunGothicOTF YetHangul", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));

                PictureBox pictureBoxes = new PictureBox();
                pictureBoxes = new PictureBox();
                this.Controls.Add(pictureBoxes);
                pictureBoxes.Location = new Point(25, y);
                pictureBoxes.Size = new Size(94, 114);
                pictureBoxes.ImageLocation = itemObj["img_url"].ToString();
                pictureBoxes.Load(itemObj["img_url"].ToString());

                Label labels = new Label();
                labels = new Label();
                this.Controls.Add(labels);
                labels.Location = new Point(150, y + 20);
                labels.Size = new Size(371, 108);
                labels.Text += "제목 : " + itemObj["movie_name"].ToString() + "\r\n";
                labels.Text += "\r\n평점 : " + itemObj["grade"].ToString() + "\r\n";
                labels.Text += "시간 : " + itemObj["movie_time"].ToString() + "\r\n";
                labels.Font = new Font("NanumBarunGothicOTF YetHangul", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));

                Label line = new Label();
                this.Controls.Add(line);
                line.Location = new Point(0, pictureBoxes.Location.Y + pictureBoxes.Height + 20);
                line.AutoSize = false;
                line.BorderStyle = BorderStyle.Fixed3D;
                line.Width = 816;
                line.Height = 2;

                y += 150;

                btn.Click += button_Click;

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
                    if (Object["movie_name"].ToString() == thisbtn.Name)
                    {
                        Ticket_url = Object["ticket_link"].ToString();

                        OpenChildForm(new Form4(), sender);
                        //this.Hide();
                        //Form4 newForm = new Form4();
                        //newForm.Show();
                        //Program.ac.MainForm = newForm;
                        //this.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                //
                Console.WriteLine("ERROR : " + ex);
            }
    
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
