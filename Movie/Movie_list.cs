//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Net;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using System.IO;
//using Newtonsoft.Json;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Windows.Forms;
//using Newtonsoft.Json.Linq;



//namespace Movie_list
//{
//    class List_view
//    {
       
//            public string GetHttp()
//            {
//            //ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
//            //ChromeDriver chromeDriver = new ChromeDriver(chromeDriverService);
//            //chromeDriver.Navigate().GoToUrl("http://lazytitan.dothome.co.kr/movie_list.json"); // 웹 사이트에 접속합니다.
//            string result = null;

//            try
//            {
//                string url = "http://lazytitan.dothome.co.kr/movie_list.json";
//                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
//                request.Method = "POST";
//                request.ContentType = "text/html;charset=UTF-8";
//                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//                Stream myResponseStream = response.GetResponseStream();
//                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
//                string retString = myStreamReader.ReadToEnd();
//                //myStreamReader.Close();
//                //myResponseStream.Close();
//                result = myStreamReader.ReadToEnd();
//                JsonParser(result);

//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//            }
//            return result;

//            }
//        public void JsonParser(String json)
//        {
//            JObject obj = JObject.Parse(json);
//            JArray array = JArray.Parse(obj["d"].ToString());

//            foreach (JObject itemObj in array)
//            {
//                String grade = itemObj["grade"].ToString();
//                String img_url= itemObj["img_url"].ToString();
//                String movie_name = itemObj["movie_name"].ToString();
//                String movie_time = itemObj["movie_time"].ToString();
//                String ticket_ling = itemObj["ticket_link"].ToString();

//                Console.WriteLine(grade);
//                Console.WriteLine(img_url);
//                Console.WriteLine(movie_name);
//                Console.WriteLine(movie_time);
//                Console.WriteLine(ticket_ling);
//            }
//        }



//    }
//}
