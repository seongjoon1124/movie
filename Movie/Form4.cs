using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using Movie;

namespace Movie
{
    public partial class Form4 : Form
    {


        public Form4()
        {
            InitializeComponent();
            GetMovie_Area_time();
            initRoot();

        }

        IWebDriver Driver = new ChromeDriver();
        String url;

        public void GetMovie_Area_time()
        {
            Form2 _form = new Form2();
            url = _form.GetTicketUrl();

            textBox1.Text += "주소 : " + url;
            //String test = "https://www.naver.com";
        }

        public void initRoot()
        {
            comboBox1.DisplayMember = "value";
            comboBox1.ValueMember = "key";
            Dictionary<string, string> rootArea = new Dictionary<string, string>();
            rootArea.Add("1", "서울");
            rootArea.Add("2", "인천");
            rootArea.Add("3", "경기");
            rootArea.Add("4", "대전");
            rootArea.Add("5", "충청");
            rootArea.Add("6", "강원");
            rootArea.Add("7", "광주");
            rootArea.Add("8", "전라");
            rootArea.Add("9", "부산");
            rootArea.Add("10", "대구");
            rootArea.Add("11", "경상");
            rootArea.Add("12", "제주");

            comboBox1.DataSource = new BindingSource(rootArea, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            initSub();
        }

        public void initSub()
        {
            string sub_value = comboBox1.SelectedValue.ToString();
            if (sub_value == "1")
            {
                comboBox2.DisplayMember = "value";
                comboBox2.ValueMember = "key";
                Dictionary<string, string> subArea = new Dictionary<string, string>();
                subArea.Add("53", "강남구/서초구");
                subArea.Add("54", "강동구/송파구/광진구");
                subArea.Add("55", "강북구/도봉구/노원구");
                subArea.Add("56", "강서구/양천구");
                subArea.Add("57", "관악구/동작구");
                subArea.Add("58", "구로구/금천구/영등포구");
                subArea.Add("59", "마포구/서대문구");
                subArea.Add("60", "동대문구/성동구");
                subArea.Add("61", "성북구/중랑구");
                subArea.Add("62", "은평구");
                subArea.Add("63", "종로구");
                subArea.Add("64", "중구");
                subArea.Add("65", "용산구");

                comboBox2.DataSource = new BindingSource(subArea, null);
            }


            if (sub_value == "2")
            {
                comboBox2.DisplayMember = "value";
                comboBox2.ValueMember = "key";
                Dictionary<string, string> subArea = new Dictionary<string, string>();
                subArea.Add("46", "인천");


                comboBox2.DataSource = new BindingSource(subArea, null);
            }

            if (sub_value == "3")
            {
                comboBox2.DisplayMember = "value";
                comboBox2.ValueMember = "key";
                Dictionary<string, string> subArea = new Dictionary<string, string>();
                subArea.Add("66", "수원/화성");
                subArea.Add("67", "시흥/안산");
                subArea.Add("68", "안양/군포/의왕");
                subArea.Add("69", "광명/부천");
                subArea.Add("70", "고양/파주");
                subArea.Add("71", "성남/용인/하남");
                subArea.Add("72", "오산/안성/평택");
                subArea.Add("73", "남양주/구리");
                subArea.Add("74", "여주/이천");
                subArea.Add("75", "의정부");
                subArea.Add("76", "김포");
                subArea.Add("77", "동두천/양주");
                subArea.Add("78", "광주");
                subArea.Add("83", "포천");
                subArea.Add("85", "가평");

                comboBox2.DataSource = new BindingSource(subArea, null);
            }

            if (sub_value == "4")
            {
                comboBox2.DisplayMember = "value";
                comboBox2.ValueMember = "key";
                Dictionary<string, string> subArea = new Dictionary<string, string>();
                subArea.Add("47", "대전");

                comboBox2.DataSource = new BindingSource(subArea, null);
            }

            if (sub_value == "5")
            {
                comboBox2.DisplayMember = "value";
                comboBox2.ValueMember = "key";
                Dictionary<string, string> subArea = new Dictionary<string, string>();
                subArea.Add("48", "충청");

                comboBox2.DataSource = new BindingSource(subArea, null);
            }

            if (sub_value == "6")
            {
                comboBox2.DisplayMember = "value";
                comboBox2.ValueMember = "key";
                Dictionary<string, string> subArea = new Dictionary<string, string>();
                subArea.Add("49", "강원");

                comboBox2.DataSource = new BindingSource(subArea, null);
            }

            if (sub_value == "7")
            {
                comboBox2.DisplayMember = "value";
                comboBox2.ValueMember = "key";
                Dictionary<string, string> subArea = new Dictionary<string, string>();
                subArea.Add("50", "광주");

                comboBox2.DataSource = new BindingSource(subArea, null);
            }

            if (sub_value == "8")
            {
                comboBox2.DisplayMember = "value";
                comboBox2.ValueMember = "key";
                Dictionary<string, string> subArea = new Dictionary<string, string>();
                subArea.Add("24", "전라");

                comboBox2.DataSource = new BindingSource(subArea, null);
            }

            if (sub_value == "9")
            {
                comboBox2.DisplayMember = "value";
                comboBox2.ValueMember = "key";
                Dictionary<string, string> subArea = new Dictionary<string, string>();
                subArea.Add("26", "금정구");
                subArea.Add("27", "남구");
                subArea.Add("28", "동래구");
                subArea.Add("29", "부산진구");
                subArea.Add("30", "북구");
                subArea.Add("31", "사상구");
                subArea.Add("32", "연제구");
                subArea.Add("33", "중구");
                subArea.Add("34", "해운대구");
                subArea.Add("79", "기장군");
                subArea.Add("80", "사하구");
                subArea.Add("81", "강서구");

                comboBox2.DataSource = new BindingSource(subArea, null);
            }

            if (sub_value == "10")
            {
                comboBox2.DisplayMember = "value";
                comboBox2.ValueMember = "key";
                Dictionary<string, string> subArea = new Dictionary<string, string>();
                subArea.Add("51", "대구");

                comboBox2.DataSource = new BindingSource(subArea, null);
            }

            if (sub_value == "11")
            {
                comboBox2.DisplayMember = "value";
                comboBox2.ValueMember = "key";
                Dictionary<string, string> subArea = new Dictionary<string, string>();
                subArea.Add("35", "거제/통영");
                subArea.Add("36", "거창");
                subArea.Add("37", "김해/양산");
                subArea.Add("38", "창원/마산");
                subArea.Add("39", "밀양");
                subArea.Add("40", "진주");
                subArea.Add("41", "경산");
                subArea.Add("42", "경주/포항");
                subArea.Add("43", "구미/김천");
                subArea.Add("44", "안동");
                subArea.Add("45", "울산");
                subArea.Add("84", "의성");
                subArea.Add("86", "산청");

                comboBox2.DataSource = new BindingSource(subArea, null);
            }

            if (sub_value == "12")
            {
                comboBox2.DisplayMember = "value";
                comboBox2.ValueMember = "key";
                Dictionary<string, string> subArea = new Dictionary<string, string>();
                subArea.Add("52", "제주");

                comboBox2.DataSource = new BindingSource(subArea, null);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 newForm = new Form2();
            newForm.Show();
            Program.ac.MainForm = newForm;
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            MessageBox.Show(date);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Sub_Value : " + comboBox1.SelectedValue.ToString());

            Console.WriteLine("Sub_Area : " + comboBox2.SelectedValue.ToString());

            Driver.Url = url;

            IJavaScriptExecutor ex = (IJavaScriptExecutor)Driver;

            Console.WriteLine("changeMenu.change('date', '" + dateTimePicker1.Value.ToString() + "');");

            ex.ExecuteScript("changeMenu.change('root', '" + comboBox1.SelectedValue.ToString() + "');");
            ex.ExecuteScript("changeMenu.change('sub', '" + comboBox2.SelectedValue.ToString() + "');");
            ex.ExecuteScript("changeMenu.change('date', '"+ dateTimePicker1.Value.ToString("yyyy-MM-dd") + "');");

        }
    }
}
