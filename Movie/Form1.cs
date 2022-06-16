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
    public partial class Form1 : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        public int getWidth
        {
            get
            {
                return this.panelsidetitle.Size.Width;
            }
        }

        public Form1()
        {
            InitializeComponent();
            random = new Random();
        }

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("NanumBarunGothicOTF YetHangul", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                    panelsidetitle.BackColor = color;
                    paneltitlebar.BackColor = ThemeColor.ChangeColorBrighness(color, -0.3);
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelmenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(67, 77, 95);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("NanumBarunGothicOTF YetHangul", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                }
            }
        }
        private void OpenChildForm(Form childForm, Object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            homelabel.Text = childForm.Text;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form2(), sender);
            //this.Hide();
            //Form2 newForm = new Form2();
            //newForm.Show();
            //Program.ac.MainForm = newForm;
            //this.Close();
        }
       

        private void button2_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new Form3(), sender);
            //this.Hide();
            //Form3 newForm = new Form3();
            //newForm.Show();
            //Program.ac.MainForm = newForm;
            //this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form5(), sender);
            //this.Hide();
            //Form5 newForm = new Form5();
            //newForm.Show();
            //Program.ac.MainForm = newForm;
            //this.Close();
        }

        public void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
