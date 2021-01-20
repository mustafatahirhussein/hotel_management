using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Project_Hotel
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            timer1.Start();
        }

        SqlConnection conn = new SqlConnection("Data Source=MUSTAFATAHIR-PC\\SQLEXPRESS;Initial Catalog=project_hotel;User ID=sa;Password=mynameis32");

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.dataGridView1.Font = new Font("Times", 10);
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select customers.book_id,customers.cust_name,customers.cust_lname,customers.cust_gender,customers.cust_dob,customers.cust_cnic,customers.cust_email,customers.cust_country,customers.cust_city,customers.cust_cnt,customers.cust_address,room.room_type,room.room_no,customers.cust_chk_in,customers.cust_chk_out,customers.cust_staydays,customers.cust_payment_type,customers.cust_payment_status from customers inner join room on customers.book_id = room.book_id";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label1.Text = dt.ToString();
            label2.Text = dt.ToString();
            label3.Text = dt.ToString();
            label4.Text = dt.ToString();
            label12.Text = dt.ToString();
            label13.Text = dt.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridView2.Font = new Font("Times", 10);
            this.dataGridView3.Font = new Font("Times", 10);
            avl_rooms();
            occupy_rooms();
        }

        public void avl_rooms()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from avl_room where avl_room.room_status = 'Empty'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView3.DataSource = dt;

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

        public void occupy_rooms()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select customers.book_id,customers.cust_name,customers.cust_lname,customers.cust_gender,customers.cust_cnic,customers.cust_country,customers.cust_city,customers.cust_cnt,room.room_no,room.room_type,room.noOfperson,room.room_status from customers inner join room on customers.book_id = room.book_id where room.room_status = 'Booked'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView2.DataSource = dt;

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

        public void food_orders()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select customers.book_id,customers.cust_name,customers.cust_lname,food_items.foods,food_items.total,food_items.paid,food_items.food_status from customers inner join food_items on customers.book_id = food_items.book_id";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView4.DataSource = dt;

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

        public void reg_events()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT customers.book_id,customers.cust_name,customers.cust_lname,customers.cust_gender,customers.cust_cnt,room.room_no,reg_event.event_name,reg_event.event_desc,reg_event.event_start,reg_event.noOfGuests,reg_event.payment_type from customers inner join room on customers.book_id = room.book_id INNER JOIN reg_event on customers.book_id = reg_event.book_id";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView5.DataSource = dt;

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

        private void button2_Click(object sender, EventArgs e)
        {
            this.dataGridView4.Font = new Font("Times", 10);
            food_orders();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.dataGridView5.Font = new Font("Times", 10);
            reg_events();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            add();
        }

        public void add()
        {
            if (string.IsNullOrEmpty(comboBox1.Text) && string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Field(s) is empty");
            }
            else if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("You have not selected room type");
            }
            else if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("You have not selected room type");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into avl_room values('" + textBox1.Text + "','" + comboBox1.Text + "','Empty')";
                    cmd.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                    textBox1.Text = null;
                    comboBox1.Text = null;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dv = this.dataGridView3.Rows[e.RowIndex];

                textBox1.Text = dv.Cells["room_no"].Value.ToString();
                comboBox1.Text = dv.Cells["room_type"].Value.ToString();
            }
        }

        public void delete()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from avl_room where room_no = '" + textBox1.Text + "'";
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

        private void button5_Click(object sender, EventArgs e)
        {
            delete();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            String path = Directory.GetCurrentDirectory() + "\\customer_record.txt";

            StreamWriter sw = new StreamWriter(path, append: true);
            sw.Write("Booking ID\t\tFirst\t\tLast\t\tGender\t\tDOB\t\tCnic\t\tEmail\t\tCountry\t\tCity\t\tReligion\t\tContact\t\tAddress\t\tPersons#\t\tRoom Type\t\tRoom #\t\tChecked IN\t\tChecked Out\t\tDays #\t\tAmount\t\tPayment Type\n");
            try
            {
                string sLine = "";

                for (int r = 0; r <= dataGridView1.Rows.Count - 1; r++)
                {
                    for (int c = 0; c <= dataGridView1.Columns.Count - 1; c++)
                    {
                        sLine = sLine + dataGridView1.Rows[r].Cells[c].Value;
                        if (c != dataGridView1.Columns.Count - 1)
                        {
                            sLine = sLine + "\t\t";
                        }
                    }
                    sw.WriteLine(sLine);
                    sLine = "";
                }

                sw.Close();
                MessageBox.Show("Data Saved.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sw.Close();
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Visible = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            show();
        }

        public void show()
        {
            try
            {
                this.dataGridView6.Font = new Font("Times", 10);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from checkout";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView6.DataSource = dt;
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

        public void feedback()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT feedback.book_id,checkout.cust_name,checkout.cust_lname,checkout.cust_gender,checkout.cust_cnt, feedback.food_qual,feedback.envr, feedback.services, feedback.rating_star from feedback inner join checkout on feedback.book_id = checkout.book_id";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView7.DataSource = dt;

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

        private void button7_Click(object sender, EventArgs e)
        {
            String path = Directory.GetCurrentDirectory() + "\\checkout_records.txt";

            StreamWriter sw = new StreamWriter(path, append: true);
            sw.Write("Booking ID\t\tFirst\t\tLast\t\tGender\t\tCnic\t\tEmail\t\tCountry\t\tCity\t\tReligion\t\tContact\t\tAddress\t\tChecked IN\t\tChecked Out\t\tDays #\t\tPayment Type\n");
            try
            {
                string sLine = "";

                for (int r = 0; r <= dataGridView6.Rows.Count - 1; r++)
                {
                    for (int c = 0; c <= dataGridView6.Columns.Count - 1; c++)
                    {
                        sLine = sLine + dataGridView6.Rows[r].Cells[c].Value;
                        if (c != dataGridView6.Columns.Count - 1)
                        {
                            sLine = sLine + "\t\t";
                        }
                    }
                    sw.WriteLine(sLine);
                    sLine = "";
                }

                sw.Close();
                MessageBox.Show("Data Saved.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sw.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.dataGridView7.Font = new Font("Times", 10);
            feedback();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                try
                {
                    this.dataGridView1.Font = new Font("Times", 10);
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select customers.book_id,customers.cust_name,customers.cust_lname,customers.cust_gender,customers.cust_dob,customers.cust_cnic,customers.cust_email,customers.cust_country,customers.cust_city,customers.cust_cnt,customers.cust_address,room.room_type,room.room_no,customers.cust_chk_in,customers.cust_chk_out,customers.cust_staydays,customers.cust_payment_type,customers.cust_payment_status from customers inner join room on customers.book_id = room.book_id order by cust_name";
                    cmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

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
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                try
                {
                    this.dataGridView6.Font = new Font("Times", 10);
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from checkout order by cust_name";
                    cmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView6.DataSource = dt;

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

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                try
                {
                    this.dataGridView1.Font = new Font("Times", 10);
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select customers.book_id,customers.cust_name,customers.cust_lname,customers.cust_gender,customers.cust_dob,customers.cust_cnic,customers.cust_email,customers.cust_country,customers.cust_city,customers.cust_cnt,customers.cust_address,room.room_type,room.room_no,customers.cust_chk_in,customers.cust_chk_out,customers.cust_staydays,customers.cust_payment_type,customers.cust_payment_status from customers inner join room on customers.book_id = room.book_id order by cust_country";
                    cmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

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

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                try
                {
                    this.dataGridView6.Font = new Font("Times", 10);
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from checkout order by cust_country";
                    cmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView6.DataSource = dt;

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
    }
}
