using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Hotel
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private static Form12 instance;
        public static Form12 getinstance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new Form12();
            else
                instance.BringToFront();
            return instance;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            timer1.Interval = 5000;
            timer1.Start();
            label1.Text = "Processing.........";
            webBrowser1.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(timer1.Interval == 5000)
            {
                timer1.Stop();
                label1.Text = "Ready";
                this.Size = new Size(1033, 550);
                StringBuilder sb = new StringBuilder("https://www.google.com/maps/place/Abc+Hotel/@15.1672346,120.5841873,17z/data=!3m1!4b1!4m5!3m4!1s0x3396f277e59fac69:0x31a6b08523971ac1!8m2!3d15.1672294!4d120.586376");

                webBrowser1.Visible = true;
                webBrowser1.Navigate(sb.ToString());
            }
        }
    }
}
