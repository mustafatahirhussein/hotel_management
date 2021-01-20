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
using System.Globalization;
using System.Diagnostics;
using System.Speech.Synthesis;
using System.Data.SqlClient;
using Tulpep.NotificationWindow;
using System.Net;

namespace Project_Hotel
{
    public partial class Form3 : Form
    {
    
        SqlConnection conn = new SqlConnection("Data Source=MUSTAFATAHIR-PC\\SQLEXPRESS;Initial Catalog=project_hotel;User ID=sa;Password=mynameis32;MultipleActiveResultSets=true");
        public Form3()
        {
            InitializeComponent();
            timer1.Start();
        }
        public static int total;
        public static int stay = 0;
        static int id;

        public static String fname, lname;
        public static String cnt_no, room_no;

        List<String> cultures = new List<String>();
        CultureInfo[] culture_info = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
        RegionInfo region;

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrEmpty(cust_fname.Text) || string.IsNullOrEmpty(cust_lname.Text) || string.IsNullOrEmpty(comboBox1_gender.Text) || string.IsNullOrEmpty(birth_month.Text) || string.IsNullOrEmpty(birth_day.Text) || string.IsNullOrEmpty(cnic_no.Text) || string.IsNullOrEmpty(email.Text) || string.IsNullOrEmpty(comboBox_country.Text) || string.IsNullOrEmpty(city.Text) || string.IsNullOrEmpty(textBox_passport.Text) || string.IsNullOrEmpty(contact.Text) || string.IsNullOrEmpty(address.Text) || string.IsNullOrEmpty(room_members.Text) || string.IsNullOrEmpty(combobox_room_type.Text) || string.IsNullOrEmpty(combobox_avl_rooms.Text) || string.IsNullOrEmpty(comboBox1_payment.Text))
            {
                MessageBox.Show("Field(s) is empty!","",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
               
            }

            else if(combobox_room_type.SelectedIndex == 1 || combobox_room_type.SelectedIndex == 2 || combobox_room_type.SelectedIndex == 3 || combobox_room_type.SelectedIndex == 4 || combobox_room_type.SelectedIndex == 5)
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "insert into customers ([cust_name],[cust_lname],[cust_gender],[cust_dob],[cust_cnic], [cust_email],[cust_country] ,[cust_city]  , [cust_religion] , [cust_cnt]  ,[cust_address] , [cust_chk_in]  ,[cust_chk_out], [cust_staydays]  ,[cust_total]  ,[cust_payment_type],[cust_payment_status],[cust_status]) values('" + cust_fname.Text + "','" + cust_lname.Text + "','" + comboBox1_gender.Text + "','" + birth_month.Text + "/" + birth_day.Text + "/" + birth_year.Text + "','" + cnic_no.Text + "','" + email.Text + "','" + comboBox_country.Text + "','" + city.Text + "','" + textBox_passport.Text + "','" + contact.Text + "','" + address.Text + "','" + dateTimePicker1_checkin.Text + "','" + dateTimePicker1_checkout.Text + "','" + textBox_daysofstay.Text + "','" + textbox_total.Text + "','" + comboBox1_payment.Text + "','Pending...','Checked In')";
                    cmd.ExecuteNonQuery();                  
                    cmd.CommandText = "select book_id from customers where cust_name = '" + cust_fname.Text + "' and cust_cnt = '"+contact.Text+"'";
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                         id = read.GetInt32(0);
                      
                        //speaking feature
                        SpeechSynthesizer syn = new SpeechSynthesizer();
                        syn.Volume = 100;
                        syn.SelectVoiceByHints(VoiceGender.Male);
                        syn.Speak("Your Booking has been confirmed with Id : " + id.ToString());
                        MessageBox.Show("Booking Id generated :-" + id.ToString(),"",MessageBoxButtons.OK,MessageBoxIcon.Information);
      
                        button1.Enabled = false;
                        button3.Visible = true;
                        checkBox1_food.Enabled = true;

                        PopupNotifier pn = new PopupNotifier();
                        pn.Image = Properties.Resources.information;
                        pn.TitleText = "ABC Hotel";
                        pn.TitleColor = Color.Black;
                        pn.ContentText = "A SMS has been sent to " + contact.Text + " for Confirmation";
                        pn.Popup();
                    }
                    
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                    sendSMS();
                    update();
                    remove_room();
                    fname = cust_fname.Text;
                    lname = cust_lname.Text;
                    cnt_no = contact.Text;
                    room_no = combobox_avl_rooms.Text;
                }
            }

            else if (combobox_room_type.SelectedIndex == 6)
            {
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = conn.CreateCommand();
                        cmd.CommandText = "insert into customers ([cust_name],[cust_lname],[cust_gender],[cust_dob],[cust_cnic], [cust_email],[cust_country] ,[cust_city]  , [cust_religion] , [cust_cnt]  ,[cust_address] , [cust_chk_in]  ,[cust_chk_out], [cust_staydays]  ,[cust_total]  ,[cust_payment_type],[cust_payment_status],[cust_status]) values('" + cust_fname.Text + "','" + cust_lname.Text + "','" + comboBox1_gender.Text + "','" + birth_month.Text + "/" + birth_day.Text + "/" + birth_year.Text + "','" + cnic_no.Text + "','" + email.Text + "','" + comboBox_country.Text + "','" + city.Text + "','" + textBox_passport.Text + "','" + contact.Text + "','" + address.Text + "','" + dateTimePicker1_checkin.Text + "','" + dateTimePicker1_checkout.Text + "','" + textBox_daysofstay.Text + "','" + textbox_total.Text + "','" + comboBox1_payment.Text + "','Pending...','Checked In')";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "select book_id from customers where cust_name = '" + cust_fname.Text + "' and cust_cnt = '" + contact.Text + "'";
                        SqlDataReader read = cmd.ExecuteReader();
                        while (read.Read())
                        {

                        id = read.GetInt32(0);
                        
                        //speaking feature
                        SpeechSynthesizer syn = new SpeechSynthesizer();
                            syn.Volume = 100;
                            syn.SelectVoiceByHints(VoiceGender.Male);
                            syn.Speak("Your Booking has been confirmed with Id : " + id.ToString());
                            MessageBox.Show("Booking Id generated :-" + id.ToString(),"",MessageBoxButtons.OK,MessageBoxIcon.Information);

                        button1.Enabled = false;
                        button3.Visible = true;
                        checkBox1_food.Enabled = true;

                        PopupNotifier pn = new PopupNotifier();
                        pn.Image = Properties.Resources.information;
                        pn.TitleText = "ABC Hotel";
                        pn.TitleColor = Color.Black;
                        pn.ContentText = "A SMS has been sent to " + contact.Text + " for Confirmation";
                        pn.Popup();
                        
                    }
                }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                    conn.Close();
                    sendSMS1();
                    update();
                    remove_room();
                    fname = cust_fname.Text;
                    lname = cust_lname.Text;
                    cnt_no = contact.Text;
                    room_no = combobox_avl_rooms.Text;
                }
                }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            date_time_text.Text = dt.ToString();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            foreach (CultureInfo culture in culture_info)
            {
                region = new RegionInfo(culture.LCID);

                if(!cultures.Contains(region.EnglishName))
                {
                    cultures.Add(region.EnglishName);                  
                    comboBox_country.Items.Add(region.EnglishName+" ("+region.ISOCurrencySymbol+")");
                }
            }
            button_foodorder.Visible = false;
            button3.Visible = false;
            textBox_daysofstay.Enabled = false;
            textbox_total.Enabled = false;
            checkBox1_food.Enabled = false;
            fname = cust_fname.Text;
            lname = cust_lname.Text;
            cnt_no = contact.Text;
            room_no = combobox_avl_rooms.Text;

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_gender_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            e.DrawFocusRectangle();

            if (e.Index > -1 && imageList1.Images.Count >= e.Index)
            { //for image
                e.Graphics.DrawImage(imageList1.Images[e.Index], new PointF(e.Bounds.X, e.Bounds.Y));
                // for text
                e.Graphics.DrawString(comboBox1_gender.Items[e.Index].ToString(), comboBox1_gender.Font,
                System.Drawing.Brushes.Black,
                new RectangleF(e.Bounds.X + 30, e.Bounds.Y + 10, e.Bounds.Width, e.Bounds.Height));
            }

        }

        private void combobox_room_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combobox_room_type.Text == "Single")
            {
                combobox_avl_rooms.Items.Clear();
                combobox_avl_rooms.DropDownStyle = ComboBoxStyle.DropDownList;
                pictureBox1.ImageLocation = "C:\\Users\\Mustafa Tahir\\Documents\\Visual Studio 2015\\Projects\\Project_Hotel\\single.jpg";
                label_room_rent.Text = "1 Night Rent "+1300;
                textBox_daysofstay.Text = "";
                textBox1_tax.Text = "";
                textbox_total.Text = "";
                single();
            }
            else if (combobox_room_type.Text == "Double")
            {
                combobox_avl_rooms.Items.Clear();
                combobox_avl_rooms.DropDownStyle = ComboBoxStyle.DropDownList;
                pictureBox1.ImageLocation = "C:\\Users\\Mustafa Tahir\\Documents\\Visual Studio 2015\\Projects\\Project_Hotel\\double.jpg";
                label_room_rent.Text = "1 Night Rent " + 2500;
                textBox_daysofstay.Text = "";
                textBox1_tax.Text = "";
                textbox_total.Text = "";
                dbl();
            }
            else if (combobox_room_type.Text == "Triple")
            {
                combobox_avl_rooms.Items.Clear();
                combobox_avl_rooms.DropDownStyle = ComboBoxStyle.DropDownList;
                pictureBox1.ImageLocation = "C:\\Users\\Mustafa Tahir\\Documents\\Visual Studio 2015\\Projects\\Project_Hotel\\triple.jpg";
                label_room_rent.Text = "1 Night Rent " + 5000;
                textBox_daysofstay.Text = "";
                textBox1_tax.Text = "";
                textbox_total.Text = "";
                triple();
            }
            else if (combobox_room_type.Text == "Twin")
            {
                combobox_avl_rooms.Items.Clear();
                combobox_avl_rooms.DropDownStyle = ComboBoxStyle.DropDownList;
                pictureBox1.ImageLocation = "C:\\Users\\Mustafa Tahir\\Documents\\Visual Studio 2015\\Projects\\Project_Hotel\\twin.jpg";
                label_room_rent.Text = "1 Night Rent " + 11500;
                textBox_daysofstay.Text = "";
                textBox1_tax.Text = "";
                textbox_total.Text = "";
                twin();
            }
            else if (combobox_room_type.Text == "King")
            {
                combobox_avl_rooms.Items.Clear();
                combobox_avl_rooms.DropDownStyle = ComboBoxStyle.DropDownList;
                pictureBox1.ImageLocation = "C:\\Users\\Mustafa Tahir\\Documents\\Visual Studio 2015\\Projects\\Project_Hotel\\king.tif";
                label_room_rent.Text = "1 Night Rent " + 15000;
                textBox_daysofstay.Text = "";
                textBox1_tax.Text = "";
                textbox_total.Text = "";
                king();
            }
            else if (combobox_room_type.Text == "Custom")
            {
                label_room_rent.Text = string.Empty;
                combobox_avl_rooms.Items.Clear();
                combobox_avl_rooms.DropDownStyle = ComboBoxStyle.DropDown;
                combobox_avl_rooms.Text = "None";
                textBox_daysofstay.Text = "";
                textBox1_tax.Text = "";
                textbox_total.Text = "";
                pictureBox1.ImageLocation = null;
                Form4 f4 = Form4.getinstance();
                f4.Visible = true;
                this.WindowState = FormWindowState.Minimized;
            }

            else if (combobox_room_type.Text == "Select")
            {
                label_room_rent.Text = string.Empty;
                pictureBox1.ImageLocation = null;
                combobox_avl_rooms.Items.Clear();
            }

            else
            {
                pictureBox1.Hide();
                return;
            }
        }

        private void checkBox1_food_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1_food.Checked == true)
            {
                button_foodorder.Visible = true;               
            }
            else
                button_foodorder.Visible = false;
        }

        private void comboBox1_payment_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button_foodorder_Click(object sender, EventArgs e)
        {
            checkBox1_food.Checked = false;
            Form5 f5 = Form5.getinstance();
            f5.Visible = true;
            this.WindowState = FormWindowState.Minimized;
        }

        private void dateTimePicker1_checkout_ValueChanged(object sender, EventArgs e)
        {
            DateTime checkin = dateTimePicker1_checkin.Value;
            DateTime checkout = dateTimePicker1_checkout.Value;

            if (checkout.Date < checkin.Date)
            {
                MessageBox.Show("CheckOut date must be greater than Checkin","", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePicker1_checkout.Value = DateTime.Today;
                return;
            }
      
            else
            {
                TimeSpan ts = checkout-checkin;
               var numberOfDays = Math.Round((checkout - checkin).TotalDays);
                textBox_daysofstay.Text = "Total Days  " + string.Format("{0}",numberOfDays);

                if (combobox_room_type.Text == "Single")
                {
                    textbox_total.Text = (numberOfDays*1300+400).ToString();
                    textBox1_tax.Enabled = false;
                    textBox1_tax.Text = "Tax : 400";
                }
                else if (combobox_room_type.Text == "Double")
                {
                    textbox_total.Text = (numberOfDays * 2500+400).ToString();
                    textBox1_tax.Enabled = false;
                    textBox1_tax.Text = "Tax : 400";
                }
                else if (combobox_room_type.Text == "Triple")
                {
                    textbox_total.Text = (numberOfDays * 5000+400).ToString();
                    textBox1_tax.Enabled = false;
                    textBox1_tax.Text = "Tax : 400";
                }
                else if (combobox_room_type.Text == "Twin")
                {
                    textbox_total.Text = (numberOfDays * 11500+400).ToString();
                    textBox1_tax.Enabled = false;
                    textBox1_tax.Text = "Tax : 400";
                }
                else if (combobox_room_type.Text == "King")
                {
                    textbox_total.Text = (numberOfDays * 15000+400).ToString();
                    textBox1_tax.Enabled = false;
                    textBox1_tax.Text = "Tax : 400";
                }

                else if (combobox_room_type.Text == "Custom")
                {
                    textbox_total.Text = (Form4.sum*numberOfDays).ToString();
                    textBox1_tax.Enabled = false;
                    textBox1_tax.Text = "Tax : 400";
                }
                else
                {
                    numberOfDays = 0.0;
                    textbox_total.Text = "Total : " + numberOfDays;
                    textBox1_tax.Enabled = false;
                    textBox1_tax.Text = "Tax : 0.0";
                }
            }
        }

        private void checkBox1_food_Click(object sender, EventArgs e)
        {
        }

        private void room_choice_TextChanged(object sender, EventArgs e)
        {

        }

        private void birth_month_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cust_fname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_room_rent_Click(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_checkin_ValueChanged(object sender, EventArgs e)
        {
            DateTime checkin = dateTimePicker1_checkin.Value;
             if (checkin.Date < DateTime.Today)
            {
                MessageBox.Show("Checkin date must not be less than current date","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                dateTimePicker1_checkin.Value = DateTime.Today;
            }
        }

        private void textbox_total_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
        }

        private void combobox_avl_rooms_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void combobox_avl_rooms_Click(object sender, EventArgs e)
        {
        }

        private void combobox_avl_rooms_Leave(object sender, EventArgs e)
        {
        }

        private void button_room_search_Click(object sender, EventArgs e)
        {
        }

        private void button_room_search_Leave(object sender, EventArgs e)
        {
        }

        private void checkBox_checkout_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_checkout.Checked == true)
            {
                Form8 f8 = Form8.getinstance();
                f8.Visible = true;
                this.WindowState = FormWindowState.Minimized;
                checkBox_checkout.Checked = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Visible = true;
        }

        private void date_time_text_TextChanged(object sender, EventArgs e)
        {

        }

        public void update()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into room values('"+id.ToString()+"','"+room_members.Text+"','"+combobox_room_type.Text+"','"+combobox_avl_rooms.Text+"','Booked')";
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

        public void single()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select room_no from avl_room where room_type = 'Single'";
                SqlDataReader read = cmd.ExecuteReader();

                while(read.Read())
                {
                    int no = read.GetInt32(0);
                    combobox_avl_rooms.Items.Add(no);
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

        public void dbl()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select room_no from avl_room where room_type = 'Double'";
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    int no = read.GetInt32(0);
                    combobox_avl_rooms.Items.Add(no);
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

        public void triple()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select room_no from avl_room where room_type = 'Triple'";
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    int no = read.GetInt32(0);
                    combobox_avl_rooms.Items.Add(no);
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

        public void twin()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select room_no from avl_room where room_type = 'Twin'";
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    int no = read.GetInt32(0);
                    combobox_avl_rooms.Items.Add(no);
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


        public void king()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select room_no from avl_room where room_type = 'King'";
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    int no = read.GetInt32(0);
                    combobox_avl_rooms.Items.Add(no);
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

        public void remove_room()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from avl_room where room_no = '" + combobox_avl_rooms.Text + "'";
                cmd.ExecuteNonQuery(); 
            }
            catch(Exception)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        public string sendSMS()
        {
            String result;
            string apiKey = "inPxOpSpuG8-wuLmXGaYHZKbAtFognEnfw88eLm8ow";
            string numbers = contact.Text; // in a comma seperated list
            string message = "Your Booking has been confirmed at ABC Hotel with ID "+id.ToString()+"\nRoom No "+combobox_avl_rooms.Text+"\nRoom type "+combobox_room_type.Text;
            string sender = "ABC Hotel";

            String url = "https://api.txtlocal.com/send/?apikey=" + apiKey + "&numbers=" + numbers + "&message=" + message + "&sender=" + sender;
            //refer to parameters to complete correct url string

            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);

            objRequest.Method = "POST";
            objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
            objRequest.ContentType = "application/x-www-form-urlencoded";
            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(url);
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                myWriter.Close();
            }

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                // Close and clean up the StreamReader
                sr.Close();
            }
            return result;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 f1 = new Form1();
            f1.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Sure You want to Exit", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(a == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                //do nothing
            }
        }

        public string sendSMS1()
        {
            String result;
            string apiKey = "inPxOpSpuG8-wuLmXGaYHZKbAtFognEnfw88eLm8ow";
            string numbers = contact.Text; // in a comma seperated list
            string message = "Your Booking has been confirmed at ABC Hotel with ID " + id.ToString() + "\nRoom No " + combobox_avl_rooms.Text + "\nRoom type " + combobox_room_type.Text+"\nYou will receive complete information about Rooms at your arrival";
            string sender = "ABC Hotel";

            String url = "https://api.txtlocal.com/send/?apikey=" + apiKey + "&numbers=" + numbers + "&message=" + message + "&sender=" + sender;
            //refer to parameters to complete correct url string

            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);

            objRequest.Method = "POST";
            objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
            objRequest.ContentType = "application/x-www-form-urlencoded";
            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(url);
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                myWriter.Close();
            }

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                // Close and clean up the StreamReader
                sr.Close();
            }
            return result;
        }

        private void label21_Click(object sender, EventArgs e)
        {
            Form12 f12 = Form12.getinstance();
            f12.Show();
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
    }

