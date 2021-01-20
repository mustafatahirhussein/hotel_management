using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Hotel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Thread th = new Thread(new ThreadStart(run));
            th.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            th.Abort();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form2 f2 = new Form2();
            f2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form3 f3 = new Form3();
            f3.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void run()
        {
            Application.Run(new SplashForm());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
