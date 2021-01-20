using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project_Hotel
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String user_name = textBox1.Text,user_pass = textBox2.Text;

            if(string.IsNullOrEmpty(user_name) || string.IsNullOrEmpty(user_pass))
            {
                MessageBox.Show("One or both Field(s) is Empty!", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            if (user_name.Equals("admin") && user_pass.Equals("admin"))
            {
                MessageBox.Show("Login Successful", "Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Hide();
                Form6 f6 = new Form6();
                f6.Visible = true;
            }
            else
            {
                MessageBox.Show("Invalid Login", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
