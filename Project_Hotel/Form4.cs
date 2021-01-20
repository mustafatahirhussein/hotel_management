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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private static Form4 instance;
        public static Form4 getinstance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new Form4();
            else
                instance.BringToFront();
            return instance;
        }

        public static int single = 0;
        public static int doubl = 0;
        public static int triple = 0;
        public static int twin = 0;
        public static int king = 0;
        public static int sum = 0;

        public static String a;
        public static String b;
        public static String c;
        public static String d;
        public static String ev;


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {                  
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";

            a = textBox1.Text;
            b = textBox2.Text;
            c = textBox3.Text;
            d = textBox4.Text;
            ev = textBox5.Text;

            pictureBox1.ImageLocation = "C:\\Users\\Mustafa Tahir\\Documents\\Visual Studio 2015\\Projects\\Project_Hotel\\single.jpg";
            textBox2.ForeColor = Color.Black;
            label7.Text = "1 Night Rent " + 1300;
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {           
        }
        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {    
        }
        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {      
        }
        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
        }
        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {     
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (int.Parse(textBox1.Text) != 0)
                {
                    single = int.Parse(textBox1.Text) * 1300;
                }
                if (int.Parse(textBox2.Text) != 0)
                {
                    doubl = int.Parse(textBox2.Text) * 2500;
                }

                if (int.Parse(textBox3.Text) != 0)
                {
                    triple = int.Parse(textBox3.Text) * 5000;
                }

                if (int.Parse(textBox4.Text) != 0)
                {
                    twin = int.Parse(textBox4.Text) * 11500;
                }

                if (int.Parse(textBox5.Text) != 0)
                {
                    king = int.Parse(textBox5.Text) * 15000;
                }
                sum = single + doubl + triple + twin + king;
                sum += 400;
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "C:\\Users\\Mustafa Tahir\\Documents\\Visual Studio 2015\\Projects\\Project_Hotel\\double.jpg";
            textBox2.ForeColor = Color.Black;
            label7.Text = "1 Night Rent " + 2500;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "C:\\Users\\Mustafa Tahir\\Documents\\Visual Studio 2015\\Projects\\Project_Hotel\\triple.jpg";
            textBox2.ForeColor = Color.Black;
            label7.Text = "1 Night Rent " + 5000;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "C:\\Users\\Mustafa Tahir\\Documents\\Visual Studio 2015\\Projects\\Project_Hotel\\twin.jpg";
            textBox1.ForeColor = Color.Black;
            label7.Text = "1 Night Rent " + 11500;
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "C:\\Users\\Mustafa Tahir\\Documents\\Visual Studio 2015\\Projects\\Project_Hotel\\king.tif";
            textBox5.ForeColor = Color.Black;
            label7.Text = "1 Night Rent " + 15000;
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "C:\\Users\\Mustafa Tahir\\Documents\\Visual Studio 2015\\Projects\\Project_Hotel\\single.jpg";
             textBox2.ForeColor = Color.Black;
            label7.Text = "1 Night Rent " + 1300;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
