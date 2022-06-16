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

        public void JsonParser(String json)
        {
            JArray array = JArray.Parse(json.ToString());
        ;
            int y = 10;

            foreach (JObject itemObj in array)
            {
                PictureBox pictureBoxes = new PictureBox();
                this.Controls.Add(pictureBoxes);
                pictureBoxes.Location = new Point(25, y);
                pictureBoxes.Size = new Size(94, 114);
                pictureBoxes.ImageLocation = itemObj["img_url"].ToString();
                pictureBoxes.Load(itemObj["img_url"].ToString());

                Label labels = new Label();
                this.Controls.Add(labels);
                labels.Location = new Point(150, y);
                labels.Size = new Size(371, 108);
                labels.Text += "제목 : " + itemObj["movie_name"].ToString() + "\r\n";
                labels.Text += "상영예정일 : " + itemObj["open_date"].ToString() + "\r\n";
                labels.Font = new Font("NanumBarunGothicOTF YetHangul", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));

                y += 150;
    

            }
        }
    }
}
