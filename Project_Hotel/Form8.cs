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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private static Form8 instance;
        public static Form8 getinstance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new Form8();
            else
                instance.BringToFront();
            return instance;
        }

        SqlConnection conn = new SqlConnection("Data Source=MUSTAFATAHIR-PC\\SQLEXPRESS;Initial Catalog=project_hotel;MultipleActiveResultSets=True;User ID=sa;Password=mynameis32");
        static int data;
        public static String book_id;

        private void Form8_Load(object sender, EventArgs e)
        {
            PopupNotifier pop = new PopupNotifier();
            pop.Image = Properties.Resources.information;
            pop.TitleText = "ABC Hotel";
            pop.TitleColor = Color.Black;
            pop.ContentText = "Entering Wrong Booking ID will non-function the Button(s) or Checkbox\nTo Place Food order, Click Update button";
            pop.AnimationInterval = 2;
            pop.Popup();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == string.Empty)
            {
                MessageBox.Show("Booking ID (Required)","",MessageBoxButtons.OK,MessageBoxIcon.Question);
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from customers where book_id = '"+textBox1.Text+"'";
                    SqlDataReader rd = cmd.ExecuteReader();

                        while (rd.Read())
                        {
                            //String data = rd.GetString(0);

                            if (rd["cust_total"].ToString() == "0")
                            {
                            cmd.CommandText = "insert into checkout values('" + rd[0].ToString() + "','" + rd[1].ToString() + "','" + rd[2].ToString() + "','" + rd[3].ToString() + "','" + rd[5].ToString() + "','" + rd[6].ToString() + "','" + rd[7].ToString() + "','" + rd[8].ToString() + "','" + rd[9].ToString() + "','" + rd[10].ToString() + "','" + rd[11].ToString() + "','" + rd[12].ToString() + "','" + rd[13].ToString() + "','" + rd[14].ToString() + "','" + rd[16].ToString() + "','Checked Out')";
                            rd.Close();
                            cmd.ExecuteNonQuery();
                            delete();
                            insert_room();
                            delete_foods();
                            delete_events();
                            delete_room();
                            MessageBox.Show("Checked Out Successfull\nThankYou for staying at our Hotel", "Checked Out", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                            PopupNotifier pop = new PopupNotifier();
                            pop.Image = Properties.Resources.information;
                            pop.TitleText = "ABC Hotel";
                            pop.TitleColor = Color.Black;
                            pop.ContentText = "All Food orders, Events associated with this Booking ID is deleted and Payment is Non-Refundable";
                            pop.AnimationInterval = 3;
                            pop.Popup();

                            DialogResult ask = MessageBox.Show("Would You like to Submit Feedback form ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if(ask == DialogResult.Yes)
                            {
                                Form13 f13 = Form13.getinstance();
                                f13.Visible = true;
                                this.WindowState = FormWindowState.Minimized;
                            }
                            return;
                            }

                            else if (rd["cust_total"].ToString() != "0")
                            {
                                DialogResult dr = MessageBox.Show("Customer Name : " + rd[1].ToString() + " " + rd[2].ToString() + "\nYou cannot CheckOut as your Dues are not Clear\nClick OK to Pay Amount", "Dues", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                                if (dr == DialogResult.OK)
                                {
                                Form11 f11 = Form11.getinstance();
                                    f11.Visible = true;
                                }
                                else
                            {
                                return;
                            }
                        }
                    }
                    rd.Close();
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                    book_id = textBox1.Text;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Booking ID (Required)", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from customers where book_id = '" + textBox1.Text + "'";
                    SqlDataReader rd = cmd.ExecuteReader();

                    while (rd.Read())
                    {
                        data = rd.GetInt32(0);

                        if (rd["book_id"].ToString() == textBox1.Text)
                        {
                            textBox2.Text = rd[0].ToString();
                            textBox3.Text = rd[1].ToString();
                            textBox4.Text = rd[2].ToString();
                            textBox5.Text = rd[3].ToString();
                            textBox6.Text = rd[4].ToString();
                            textBox7.Text = rd[5].ToString();
                            textBox8.Text = rd[6].ToString();
                            textBox9.Text = rd[7].ToString();
                            textBox10.Text = rd[8].ToString();
                            textBox11.Text = rd[9].ToString();
                            textBox12.Text = rd[10].ToString();
                            textBox13.Text = rd[11].ToString();
                            textBox14.Text = rd[12].ToString();  
                        }

                        else
                        {
                            MessageBox.Show("No such Id exists");
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
                    book_id = textBox1.Text;
                    this.Size = new Size(639, 462);
                }
            }
        }

        private void button2_Leave(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox8.Text) || string.IsNullOrEmpty(textBox9.Text) || string.IsNullOrEmpty(textBox10.Text) || string.IsNullOrEmpty(textBox11.Text) || string.IsNullOrEmpty(textBox12.Text) || string.IsNullOrEmpty(textBox13.Text))
            {
                MessageBox.Show("Booking ID (Required)", "", MessageBoxButtons.OK, MessageBoxIcon.Question);

            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update customers set cust_name = '" + textBox3.Text + "', cust_lname = '" + textBox4.Text + "', cust_gender = '" + textBox5.Text + "', cust_dob = '" + textBox6.Text + "', cust_cnic = '" + textBox7.Text + "', cust_email = '" + textBox8.Text + "', cust_country = '" + textBox9.Text + "',cust_city = '" + textBox10.Text + "', cust_religion = '" + textBox11.Text + "', cust_cnt = '" + textBox12.Text + "', cust_address = '" + textBox13.Text + "'  where book_id = '" + textBox1.Text + "'";
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Information Updated");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                    book_id = textBox1.Text;
                }
            }
    }

        private void checkBox1_food_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1_food.Checked == true)
            {
                if(string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Empty Field");
                    checkBox1_food.Checked = false;
                }
                else
                {
                    try
                    {
                        book_id = textBox1.Text;
                        conn.Open();
                        SqlCommand cmd = conn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select cust_name from customers where book_id = '" + textBox1.Text + "'";
                        SqlDataReader rd = cmd.ExecuteReader();

                        while (rd.Read())
                        {
                            String data = rd.GetString(0);

                            if (data == null)
                            {
                                MessageBox.Show("No such Id exists");
                            }
                            else
                            {
                                MessageBox.Show("Customer name : " + data);
                                Form9 f9 = Form9.getinstance();
                                f9.Visible = true;
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
                        checkBox1_food.Checked = false;
                        book_id = textBox1.Text;
                    }
                }
            }
        }

          public void delete()
          {
              try
              {
                  SqlCommand cmd = conn.CreateCommand();
                  cmd.CommandType = CommandType.Text;
                  cmd.CommandText = "delete from customers where book_id = '" + textBox1.Text + "'";
                  cmd.ExecuteNonQuery();
              }
              catch(Exception ex)
              {
                  MessageBox.Show(ex.Message);
              }
          }

        public void delete_foods()
        {
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from food_items where book_id = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void delete_room()
        {
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from room where book_id = '" + Form8.book_id + "'";
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void delete_events()
        {
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from reg_event where book_id = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void insert_room()
        {
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from room where book_id = '"+Form8.book_id+"'";
                SqlDataReader re = cmd.ExecuteReader();

                while(re.Read())
                {
                    cmd.CommandText = "insert into avl_room values('" + re[3].ToString() + "','" + re[2].ToString() + "','Empty')";
                    re.Close();
                    cmd.ExecuteNonQuery();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
