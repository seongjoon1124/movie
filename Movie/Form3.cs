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
        private Form activeForm;

        public Form3()
        {
            InitializeComponent();
            GetMoiveRank();
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
            int y = 0;

            foreach (JObject itemObj in array)
            {

                PictureBox pictureBoxes = new PictureBox();
                this.Controls.Add(pictureBoxes);
                pictureBoxes.Location = new Point(75, y + 34);
                pictureBoxes.Size = new Size(47, 32);
                pictureBoxes.ImageLocation = itemObj["count_img"].ToString();
                pictureBoxes.Load(itemObj["count_img"].ToString());

                Label labels = new Label();
                this.Controls.Add(labels);
                labels.Location = new Point(150, y + 32);
                labels.Size = new Size(300, 32);
                labels.Text += "제목 : " + itemObj["movie_name"].ToString() + "\r\n";
                labels.Font = new Font("NanumBarunGothicOTF YetHangul", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));

                Label line = new Label();
                this.Controls.Add(line);
                line.Location = new Point(0, labels.Location.Y + 50);
                line.AutoSize = false;
                line.BorderStyle = BorderStyle.Fixed3D;
                line.Width = 816;
                line.Height = 2;

                y = line.Location.Y;
            }
        }

    }
}
