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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
            payment_due();
        }

        private static Form11 instance;
        public static Form11 getinstance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new Form11();
            else
                instance.BringToFront();
            return instance;
        }

        SqlConnection conn = new SqlConnection("Data Source=MUSTAFATAHIR-PC\\SQLEXPRESS;Initial Catalog=project_hotel;User ID=sa;Password=mynameis32");

        private void Form11_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Payment Field is empty");
                return;
            }
            else
            {
                try
                {
                    if(int.Parse(textBox2.Text) < int.Parse(textBox1.Text))
                    {
                        MessageBox.Show("Payment amount not proper","",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                        return;
                    }
                    else
                    {
                        conn.Open();
                        SqlCommand cmd = conn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select * from customers where book_id = '" + Form8.book_id + "'";
                        SqlDataReader rd = cmd.ExecuteReader();

                        while(rd.Read())
                        {
                            cmd.CommandText = "insert into checkout values('" + rd[0].ToString() + "','" + rd[1].ToString() + "','" + rd[2].ToString() + "','" + rd[3].ToString() + "','" + rd[5].ToString() + "','" + rd[6].ToString() + "','" + rd[7].ToString() + "','" + rd[8].ToString() + "','" + rd[9].ToString() + "','" + rd[10].ToString() + "','" + rd[11].ToString() + "','" + rd[12].ToString() + "','" + rd[13].ToString() + "','" + rd[14].ToString() + "','" + rd[16].ToString() + "','Checked Out')";
                            rd.Close();
                            cmd.ExecuteNonQuery();
                            delete();
                            insert_room();
                            delete_foods();
                            delete_events();
                            delete_room();
                            MessageBox.Show("Your Paymnet is now cleard....\nThankYou for staying at our Hotel", "Checked Out!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                            PopupNotifier pop = new PopupNotifier();
                            pop.Image = Properties.Resources.information;
                            pop.TitleText = "ABC Hotel";
                            pop.TitleColor = Color.Black;
                            pop.ContentText = "All Food orders, Events associated with this account is deleted and payment is Non-Refundable";
                            pop.AnimationInterval = 3;
                            pop.Popup();

                            DialogResult ask = MessageBox.Show("Would You like to Submit Feedback form ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (ask == DialogResult.Yes)
                            {
                                Form13 f13 = Form13.getinstance();
                                f13.Visible = true;
                                this.WindowState = FormWindowState.Minimized;
                            }
                            return;
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                    this.Hide();
                }
            }
            }

        public void payment_due()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select cust_total from customers where book_id = '" + Form8.book_id + "'";
                SqlDataReader rd = cmd.ExecuteReader();

                while(rd.Read())
                {
                    textBox1.Text = rd["cust_total"].ToString();
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

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void delete()
        {
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from customers where book_id = '" + Form8.book_id+ "'";
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

        public void delete_foods()
        {
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from food_items where book_id = '" + Form8.book_id + "'";
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
                cmd.CommandText = "select * from room where book_id = '" + Form8.book_id + "'";
                SqlDataReader re = cmd.ExecuteReader();

                while (re.Read())
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

        public void delete_events()
        {
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from reg_event where book_id = '" + Form8.book_id + "'";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    }
