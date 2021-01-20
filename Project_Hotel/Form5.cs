using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Tulpep.NotificationWindow;

namespace Project_Hotel
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private static Form5 instance;
        public static Form5 getinstance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new Form5();
            else
                instance.BringToFront();
            return instance;
        }

        static int drinks=0;
        static int clean=0 ;
        static int events=0;

        static int breakfast = 0;
        static int lunch = 0;
        static int dinner = 0;

        static int total, meal;
        static int sum_now = 0;

        static int book_id;
        int id;



        SqlConnection conn = new SqlConnection("Data Source=MUSTAFATAHIR-PC\\SQLEXPRESS;Initial Catalog=project_hotel;User ID=sa;Password=mynameis32");
        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                textbox_amount_tot.Text = null;
                if (comboBox1.Text == "Your Choice.....")
                {
                    textBox1.Visible = true;
                }

                if (comboBox1.SelectedIndex == 0)
                {
                    int quantity = int.Parse(comboBox1.Text) * 200;
                    textBox_meals.Text = "Meals Total Cost : " + quantity;
                    breakfast = quantity;
                    meals();
                }
                if (comboBox1.SelectedIndex == 1)
                {
                    int quantity = int.Parse(comboBox1.Text) * 200;
                    textBox_meals.Text = "Meals Total Cost : " + quantity;
                    breakfast = quantity;
                    meals();
                }
                if (comboBox1.SelectedIndex == 2)
                {
                    int quantity = int.Parse(comboBox1.Text) * 200;
                    textBox_meals.Text = "Meals Total Cost : " + quantity;
                    breakfast = quantity;
                    meals();
                }

                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                textbox_amount_tot.Text = null;
                if (comboBox2.Text == "Your Choice....")
                {
                    textBox2.Visible = true;
                }

                if (comboBox2.SelectedIndex == 0)
                {
                    int quantity = int.Parse(comboBox2.Text) * 400;
                    textBox_meals.Text = "Meals Total Cost : " + quantity;
                    lunch = quantity;
                    meals();
                }
                if (comboBox2.SelectedIndex == 1)
                {
                    int quantity = int.Parse(comboBox2.Text) * 400;
                    textBox_meals.Text = "Meals Total Cost : " + quantity;
                    lunch = quantity;
                    meals();
                }
                if (comboBox2.SelectedIndex == 2)
                {
                    int quantity = int.Parse(comboBox2.Text) * 400;
                    textBox_meals.Text = "Meals Total Cost : " + quantity;
                    lunch = quantity;
                    meals();
                }

                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                textbox_amount_tot.Text = null;
                if (comboBox3.Text == "Your Choice......")
                {
                    textBox3.Visible = true;
                }

                if (comboBox3.SelectedIndex == 0)
                {
                    int quantity = int.Parse(comboBox3.Text) * 300;
                    dinner = quantity;
                    meals();
                }
                if (comboBox3.SelectedIndex == 1)
                {
                    int quantity = int.Parse(comboBox3.Text) * 300;
                    textBox_meals.Text = "Meals Total Cost : " + quantity;
                    dinner = quantity;
                    meals();
                }
                if (comboBox3.SelectedIndex == 2)
                {
                    int quantity = int.Parse(comboBox3.Text) * 300;
                    textBox_meals.Text = "Meals Total Cost : " + quantity;
                    dinner = quantity;
                    meals();
                }

                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;

            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;

            comboBox_events.Visible = false;
            textBox_quan.Visible = false;
            comboBox_drinks.Visible = false;
            textBox_cost.Visible = false;
            button2.Enabled = false;

            textBox_meals.Enabled = false;
            textBox_total_cost.Enabled = false;
            textbox_amount_tot.Enabled = false;

            PopupNotifier pop = new PopupNotifier();
            pop.Image = Properties.Resources.information;
            pop.TitleText = "ABC Hotel";
            pop.TitleColor = Color.Black;
            pop.ContentText = "if Selected Extra Service, only (Drinks data) will be saved in the Database\nNote: For Extra Service, You must Choose b/w Breakfast, lunch or Dinner \nNote :- Click on Extra service(s) Checkbox, to Register an Event";
            pop.AnimationInterval = 8;
            pop.Popup();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textbox_amount_tot.Text = null;
            int a;
            a = int.Parse(textBox1.Text);
            try
            {
                if (a.ToString() == string.Empty)
                {
                    comboBox1.Items.Add(null);                  
                }
                else if (comboBox1.Items.Contains(a.ToString()))
                {
                    comboBox1.Items.Add(null);
                }
                else
                {
                    comboBox1.Items.Insert(0, a);
                    textBox1.Visible = false;
                }
            }
            catch (Exception)
            {
                throw new already_exist();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textbox_amount_tot.Text = null;
            try
            {
                if (comboBox1.Text == "Your Choice.....")
                {
                    textBox1.Visible = true;
                    int quantity = int.Parse(textBox1.Text) * 200;
                    breakfast = quantity;
                    meals();
                }
            }
            catch(Exception)
            {
                textBox_meals.Text = null;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textbox_amount_tot.Text = null;
            int a;
            a = int.Parse(textBox2.Text);

            try
            {

                if (a.ToString() == string.Empty)
                {
                    comboBox2.Items.Add(null);
                }
                else if (comboBox2.Items.Contains(a.ToString()))
                {
                    comboBox2.Items.Add(null);
                }
                else
                {
                    comboBox2.Items.Insert(0, a);
                    textBox2.Visible = false;
                }
            }
            catch (Exception)
            {
                throw new already_exist();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textbox_amount_tot.Text = null;
            try
            {
                if (comboBox3.Text == "Your Choice......")
                {
                    textBox3.Visible = true;
                    int quantity = int.Parse(textBox3.Text) * 300;
                    dinner = quantity;
                    meals();
                }
            }
            catch(Exception)
            {
                textBox_meals.Text = null;
            }

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            textbox_amount_tot.Text = null;
            int a;
            a = int.Parse(textBox3.Text);

            try
            {

                if (a.ToString() == string.Empty)
                {
                    comboBox3.Items.Add(null);
                }
                else if (comboBox3.Items.Contains(a.ToString()))
                {
                    comboBox3.Items.Add(null);
                }
                else
                {
                    comboBox3.Items.Insert(0, a);
                    textBox3.Visible = false;
                }
            }
            catch (Exception)
            {
                throw new already_exist();
            }
        }

        private void checkBox1_extra_CheckedChanged(object sender, EventArgs e)
        {
            textbox_amount_tot.Text = null;
            try
            {
                if (checkBox1_extra.Checked == true)
                {
                    checkBox1.Visible = true;
                    checkBox2.Visible = true;
                    checkBox3.Visible = true;
                    textBox_cost.Visible = true;
                }
                else
                {
                    checkBox1.Visible = false;
                    checkBox2.Visible = false;
                    checkBox3.Visible = false;
                    comboBox_drinks.Visible = false;
                    textBox_quan.Visible = false;
                    textBox_cost.Visible = false;
                    textBox_total_cost.Text = null;
                    comboBox_events.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textbox_amount_tot.Text = null;
            try
            {
                if (checkBox1.Checked == true)
                {
                    comboBox_drinks.Visible = true;

                }
                else
                {
                    textBox_quan.Visible = false;
                    comboBox_drinks.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            textbox_amount_tot.Text = null;
            try
            {

                if (comboBox_drinks.SelectedIndex == 0)
                {
                    textBox_quan.Visible = true;
                }
                else if (comboBox_drinks.SelectedIndex == 1)
                {
                    textBox_quan.Visible = true;
                }
                else if (comboBox_drinks.SelectedIndex == 2)
                {
                    textBox_quan.Visible = true;
                }
                else if (comboBox_drinks.SelectedIndex == 3)
                {
                    textBox_quan.Visible = true;
                }
                else if (comboBox_drinks.SelectedIndex == 4)
                {
                    textBox_quan.Visible = true;
                }
                else if (comboBox_drinks.SelectedIndex == 5)
                {
                    textBox_quan.Visible = true;
                }
                else
                    textBox_quan.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            textbox_amount_tot.Text = null;
            try
            {

                if (checkBox2.Checked == true)
                {
                    int tot = 2100;
                    textBox_cost.Text = "Clean Service Total : " + tot;
                    clean = tot;
                    sum();

                }
                else
                {
                    textBox_cost.Text = "Clean Service Total : " + 0;
                    clean = 0;
                    sum();
                    textBox_total_cost.Text = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            textbox_amount_tot.Text = null;
            try
            {

                if (checkBox3.Checked == true)
                {
                    comboBox_events.Visible = true;
                }
                else
                {
                    comboBox_events.Visible = false;
                    textBox_cost.Text = "Events Total : " + 0;
                    events = 0;
                    sum();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox4_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            textbox_amount_tot.Text = null;
            try
            {

                if (comboBox_events.SelectedIndex == 0)
                {
                    int ev = 12000;
                    textBox_cost.Text = "Event Total : " + ev;
                    events = ev;
                    sum();
                }
                else
                {
                    textBox_cost.Text = "Events Total : " + 0;
                    events = 0;
                    sum();
                }

                if (comboBox_events.SelectedIndex == 1)
                {

                    Form7 f7 = Form7.getinstance();
                    f7.Visible = true;
                    this.WindowState = FormWindowState.Minimized;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox_quan_TextChanged(object sender, EventArgs e)
        {
            textbox_amount_tot.Text = null;
            try
            {
                if (comboBox_drinks.SelectedIndex == 0)
                {
                    int tot = int.Parse(textBox_quan.Text) * 220;
                    textBox_cost.Text = "Drinks Cost : " + tot.ToString();
                    drinks = tot;
                    sum();
                }
                else if (comboBox_drinks.SelectedIndex == 1)
                {
                    int tot = int.Parse(textBox_quan.Text) * 110;
                    textBox_cost.Text = "Drinks Cost : " + tot.ToString();
                    drinks = tot;
                    sum();
                }
                else if (comboBox_drinks.SelectedIndex == 2)
                {
                    int tot = int.Parse(textBox_quan.Text) * 300;
                    textBox_cost.Text = "Drinks Cost : " + tot.ToString();
                    drinks = tot;
                    sum();

                }
                else if (comboBox_drinks.SelectedIndex == 3)
                {
                    int tot = int.Parse(textBox_quan.Text) * 90;
                    textBox_cost.Text = "Drinks Cost : " + tot.ToString();
                    drinks = tot;
                    sum();

                }
                else if (comboBox_drinks.SelectedIndex == 4)
                {
                    int tot = int.Parse(textBox_quan.Text) * 120;
                    textBox_cost.Text = "Drinks Cost : " + tot.ToString();
                    drinks = tot;
                    sum();

                }
                else if (comboBox_drinks.SelectedIndex == 5)
                {
                    int tot = int.Parse(textBox_quan.Text) * 200;
                    textBox_cost.Text = "Drinks Cost : " + tot.ToString();
                    drinks = tot;
                    sum();
                }
                else
                {
                    drinks = 0;
                    sum();
                }
            }catch(Exception)
            {
                textBox_cost.Text = null;
            }
            
        }

        private void textBox_quan_Click(object sender, EventArgs e)
        {
        }

        public void sum()
        {
            total = drinks + clean + events;
            textBox_total_cost.Text = "Extra Service(s) Total : " + total.ToString();
        }

        public void meals()
        {
            meal = breakfast + lunch + dinner;
            textBox_meals.Text = "Meals Total Cost : " + meal.ToString();
        }

        public void add()
        {
            int add = total;
            int add1 = meal;
            sum_now = add + add1;
            textbox_amount_tot.Text = "Total Amount : " + sum_now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add();
            int pay;
            if(string.IsNullOrEmpty(comboBox1.Text) && string.IsNullOrEmpty(comboBox2.Text) && string.IsNullOrEmpty(comboBox3.Text))
            {
                MessageBox.Show("Field(s) are empty!","",MessageBoxButtons.OKCancel,MessageBoxIcon.Stop);
                return;
            }

            else if(string.IsNullOrEmpty(textBox_pay.Text))
            {
                MessageBox.Show("Payment should not be left blank!","",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            }

            else if(checkBox1_extra.Checked == true)
            {
                pay = 0;
                pay = int.Parse(textBox_pay.Text) - sum_now;
                if(pay < 0)
                {
                    try
                    {
                        throw new less_than();
                    }
                    catch(Exception)
                    {
                        return;
                    }
                }
                else
                {
                    label4.Text = "Returned : " + pay.ToString();
                }              

                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "select book_id from customers where cust_name = '" + Form3.fname + "' and cust_lname = '" + Form3.lname + "'";
                    SqlDataReader read = cmd.ExecuteReader();

                        while(read.Read())
                    {
                         id = read.GetInt32(0);
                        book_id = id;
                    }

                    //speaking feature
                    SpeechSynthesizer syn = new SpeechSynthesizer();
                        syn.Volume = 100;
                        syn.SelectVoiceByHints(VoiceGender.Male);
                        syn.Speak("Your order has been placed and will receive shortly");

                    PopupNotifier pn = new PopupNotifier();
                    pn.Image = Properties.Resources.information;
                    pn.TitleText = "ABC Hotel";
                    pn.TitleColor = Color.Black;
                    pn.ContentText = "You have 15 Seconds to Cancel Your Order.......";
                    pn.Popup();

                    button2.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                    with_extras();
                    reset();
                    timer1.Interval = 15000;
                    timer1.Start();
                }
            }

            else
            {
                 pay = 0;
                pay = int.Parse(textBox_pay.Text) - sum_now;
                if (pay < 0)
                {
                    try
                    {
                        throw new less_than();
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
                else
                {
                    label4.Text = "Returned : " + pay.ToString();
                }

                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select book_id from customers where cust_name = '" + Form3.fname + "' and cust_lname = '" + Form3.lname + "'";
                    SqlDataReader read = cmd.ExecuteReader();

                    while(read.Read())
                    {
                        id = read.GetInt32(0);
                        book_id = id;
                    }   

                    //speaking feature
                    SpeechSynthesizer syn = new SpeechSynthesizer();
                        syn.Volume = 100;
                        syn.SelectVoiceByHints(VoiceGender.Male);
                        syn.Speak("Your order has been placed and will receive shortly");

                    PopupNotifier pn = new PopupNotifier();
                    pn.Image = Properties.Resources.information;
                    pn.TitleText = "ABC Hotel";
                    pn.TitleColor = Color.Black;
                    pn.ContentText = "You have 15 Seconds to Cancel Your Order.......";
                    pn.Popup();

                    button2.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                    onlyfood();
                    reset();
                    timer1.Interval = 15000;
                    timer1.Start();

                }
            }
        }

        private void textBox_total_cost_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox_meals_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox_cost_TextChanged(object sender, EventArgs e)
        {

        }

        private void textbox_amount_tot_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {     
        }

        private void textBox_pay_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.Text == "Your Choice....")
                {
                    textBox2.Visible = true;
                    int quantity = int.Parse(textBox2.Text) * 400;
                    lunch = quantity;
                    meals();
                }
            }catch(Exception)
            {
                textBox_meals.Text = null;
            }

        }

        class less_than : Exception
        {
            public less_than()
            {
                MessageBox.Show("Paymnet amount not proper","",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }
        }

        public void reset()
        {
            comboBox1.Text = null;
            comboBox2.Text = null;
            comboBox3.Text = null;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            checkBox1_extra.Checked = false;
            comboBox_drinks.Text = null;
            textBox_quan.Text = null;
            comboBox_events.Text = null;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            textBox_cost.Text = null;
            textBox_meals.Text = null;
            textBox_total_cost.Text = null;
            textbox_amount_tot.Text = null;
            label4.Text = null;
            textBox_pay.Text = null;
        }

        public void onlyfood()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into food_items values('" + book_id.ToString() + "','Breakfast " + comboBox1.Text + " Lunch " + comboBox2.Text + "  Dinner " + comboBox3.Text + "','" + sum_now + "','" + textBox_pay.Text + "','On the way!')";
                cmd.ExecuteNonQuery();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(timer1.Interval == 15000)
            {
                timer1.Stop();
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update food_items set food_status = 'Delivered' from food_items inner join customers on food_items.book_id = customers.book_id where customers.cust_name = '" + Form3.fname + "' and customers.cust_lname = '" + Form3.lname + "'";
                    cmd.ExecuteNonQuery();
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

        private void button2_Click(object sender, EventArgs e)
        {
            cancel_order();
        }

        public void with_extras()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into food_items values('" + book_id.ToString() + "', 'Breakfast " + comboBox1.Text + " Lunch " + comboBox2.Text + "  Dinner " + comboBox3.Text + " Extra: Drinks " + comboBox_drinks.Text + textBox_quan.Text + "', '" + sum_now + "', '" + textBox_pay.Text + "', 'On the way!')";
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

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void cancel_order()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select food_status from food_items inner join customers on food_items.book_id = customers.book_id where customers.cust_name = '" + Form3.fname + "' and customers.cust_cnt = '"+Form3.cnt_no+"'";
                SqlDataReader rd = cmd.ExecuteReader();

                while(rd.Read())
                {
                    if(rd["food_status"].ToString() == "Delivered")
                    {
                        MessageBox.Show("Order can not be cancelled as it is delivered!");
                        return;
                    }
                    else if(rd["food_status"].ToString() == "On the way!")
                    {
                        MessageBox.Show("Order Cancelled");
                        cmd.CommandText = "UPDATE food_items SET food_status = 'Cancelled'  from food_items INNER JOIN customers ON food_items.book_id = customers.book_id where customers.cust_name = '"+Form3.fname+"' and customers.cust_cnt = '"+Form3.cnt_no+"'";
                        rd.Close();
                        cmd.ExecuteNonQuery();
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
                this.Close();
                Form5 f = new Form5();
                f.Visible = true;
            }
        }

        class already_exist: Exception
        {
            public already_exist()
            {
                MessageBox.Show("Entered value already exists\nYou must input a number that is not present","",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
   
    }

    
    }
