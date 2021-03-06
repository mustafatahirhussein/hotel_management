﻿using System;
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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private static Form10 instance;
        public static Form10 getinstance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new Form10();
            else
                instance.BringToFront();
            return instance;
        }

        SqlConnection conn = new SqlConnection("Data Source=MUSTAFATAHIR-PC\\SQLEXPRESS;Initial Catalog=project_hotel;User ID=sa;Password=mynameis32");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(comboBox1.Text))
                {
                    MessageBox.Show("Field(s) is empty!");
                    return;
                }
                else if (string.IsNullOrEmpty(textBox_credit.Text))
                {
                    MessageBox.Show("Credit Card # is Mandatory");
                }

                else
                {
                    register();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox_credit.Visible = false;
            show_info();

            PopupNotifier pop = new PopupNotifier();
            pop.Image = Properties.Resources.information;
            pop.TitleText = "ABC Hotel";
            pop.TitleColor = Color.Black;
            pop.ContentText = "Event Registration\nAfter registering, You will have 1 day to Cancel it";
            pop.AnimationInterval = 3;
            pop.Popup();
        }


        public void show_info()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from customers";
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    textBox1.Text = read[0].ToString();
                    textBox2.Text = read[1].ToString();
                    textBox4.Text = read[10].ToString();
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void register()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into reg_event values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + dateTimePicker1.Value + "','" + textBox7.Text + "','" + comboBox1.Text + "','Pending....','In Process....')";
                cmd.ExecuteNonQuery();

                MessageBox.Show("Event has been Registered", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                PopupNotifier pop = new PopupNotifier();
                pop.Image = Properties.Resources.information;
                pop.TitleText = "ABC Hotel";
                pop.TitleColor = Color.Black;
                pop.ContentText = "Please wait... , While your Credit Cared # is verified, You will receive a Message";
                pop.AnimationInterval = 8;
                pop.Popup();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                button1.Enabled = false;
                timer1.Interval = 10000;
                timer1.Start();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime schedule = dateTimePicker1.Value;
            if (schedule < DateTime.Today)
            {
                MessageBox.Show("Scheduling date must not be less than current date", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePicker1.Value = DateTime.Today;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBox_credit.Visible = true;
            }
            else
                textBox_credit.Visible = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }



        public void delete()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from reg_event where book_id = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                cancel_event();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Interval == 10000)
            {
                timer1.Stop();

                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update reg_event set payment_status = 'Verified', event_status = 'Scheduled' where book_id = '" + textBox1.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your Credit # is verified\nYou will be notified soon about Payment !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }

        public void cancel_event()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT event_start FROM reg_event where book_id = '" + textBox1.Text + "'";
                SqlDataReader re = cmd.ExecuteReader();

                while (re.Read())
                {
                    var tomorrow = DateTime.Today.AddDays(1);

                    if (tomorrow.ToString() != re["event_start"].ToString())
                    {
                        re.Close();
                        update();
                        MessageBox.Show("Event Cancelled Successfully\nPayment will be refunded","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        return;
                    }
                    else if (tomorrow.ToString() == re["event_start"].ToString())
                    {
                        MessageBox.Show("Event cannot be cancelled as all Arrangements have been done","",MessageBoxButtons.OKCancel,MessageBoxIcon.Stop);
                        return;
                    }
                }
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

        public void update()
        {
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update reg_event set payment_status = '-',  event_status = 'Cancelled' where book_id = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
