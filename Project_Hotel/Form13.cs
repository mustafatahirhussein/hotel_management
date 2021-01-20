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
using Tulpep.NotificationWindow;

namespace Project_Hotel
{
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private static Form13 instance;
        public static Form13 getinstance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new Form13();
            else
                instance.BringToFront();
            return instance;
        }

        SqlConnection conn = new SqlConnection("Data Source=MUSTAFATAHIR-PC\\SQLEXPRESS;Initial Catalog=project_hotel;User ID=sa;Password=mynameis32");

        private void button1_Click(object sender, EventArgs e)
        {
        }

        public void feedback_1star()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into feedback values ('"+Form8.book_id+"','"+comboBox1.Text+"','"+comboBox2.Text+"','"+comboBox3.Text+"','1 Star - "+label5.Text+"')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Feedback submission Successfull", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void feedback_2star()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into feedback values ('" + Form8.book_id + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','2 Stars - " + label6.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Feedback submission Successfull", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void feedback_3star()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into feedback values ('" + Form8.book_id + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','3 Stars - " + label7.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Feedback submission Successfull", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void feedback_4star()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into feedback values ('" + Form8.book_id + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','4 Stars - " + label8.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Feedback submission Successfull", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void feedback_5star()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into feedback values ('" + Form8.book_id + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','5 Stars - " + label9.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Feedback submission Successfull", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text) || string.IsNullOrEmpty(comboBox3.Text))
            {
                MessageBox.Show("Field(s) is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                pictureBox6.Image = Properties.Resources.tick;
                pictureBox7.Image = null;
                pictureBox8.Image = null;
                pictureBox9.Image = null;
                pictureBox10.Image = null;
                label5.Text = "Poor";

                feedback_1star();
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text) || string.IsNullOrEmpty(comboBox3.Text))
            {
                MessageBox.Show("Field(s) is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                pictureBox7.Image = Properties.Resources.tick;
                pictureBox6.Image = null;
                pictureBox8.Image = null;
                pictureBox9.Image = null;
                pictureBox10.Image = null;
                label6.Text = "Average";

                feedback_2star();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text) || string.IsNullOrEmpty(comboBox3.Text))
            {
                MessageBox.Show("Field(s) is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                pictureBox8.Image = Properties.Resources.tick;
                pictureBox6.Image = null;
                pictureBox7.Image = null;
                pictureBox9.Image = null;
                pictureBox10.Image = null;
                label7.Text = "Good";

                feedback_3star();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text) || string.IsNullOrEmpty(comboBox3.Text))
            {
                MessageBox.Show("Field(s) is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                pictureBox9.Image = Properties.Resources.tick;
                pictureBox6.Image = null;
                pictureBox7.Image = null;
                pictureBox8.Image = null;
                pictureBox10.Image = null;
                label8.Text = "Excellent";

                feedback_4star();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text) || string.IsNullOrEmpty(comboBox3.Text))
            {
                MessageBox.Show("Field(s) is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                pictureBox10.Image = Properties.Resources.tick;
                pictureBox6.Image = null;
                pictureBox7.Image = null;
                pictureBox8.Image = null;
                pictureBox9.Image = null;
                label9.Text = "Above Expectations";

                feedback_5star();
            }
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            pictureBox6.Image = null;
            pictureBox7.Image = null;
            pictureBox8.Image = null;
            pictureBox9.Image = null;
            pictureBox10.Image = null;

            PopupNotifier pn = new PopupNotifier();
            pn.Image = Properties.Resources.information;
            pn.TitleText = "ABC Hotel";
            pn.TitleColor = Color.Black;
            pn.ContentText = "Select appropriate Star from rating section to submit your Feedback !";
            pn.AnimationInterval = 3;
            pn.Popup();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
