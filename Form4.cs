using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Isabella_Grigolla
{
    
    //yyyy-MM-dd HH:mm:ss
    public partial class Form4 : Form
    {

        MySqlConnection con = new MySqlConnection("Data Source=127.0.0.1,3306;" +
                "Initial Catalog =client_schedule;" +
                "Integrated Security =true;" +
                "User =sqlUser;" +
                "Password =Passw0rd!");
        MySqlConnection con2 = new MySqlConnection("Data Source=127.0.0.1,3306;" +
               "Initial Catalog =client_schedule;" +
               "Integrated Security =true;" +
               "User =sqlUser;" +
               "Password =Passw0rd!");

        MySqlDataAdapter cust = new MySqlDataAdapter();
        MySqlDataAdapter custIdNames = new MySqlDataAdapter();

        int appointmentId;

        MySqlDataAdapter deleteAppt= new MySqlDataAdapter();


        public Form4()
        {
            InitializeComponent();
        }

        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();

        private void Form4_Load(object sender, EventArgs e)
        {

            try
            {
                {
                    cust.SelectCommand = new MySqlCommand("SELECT * FROM appointment", con);
                    DataTable custTableView = new DataTable();
                    cust.Fill(custTableView);
                    dataGridView1.DataSource = custTableView;

                    custIdNames.SelectCommand = new MySqlCommand("SELECT customerId, customerName FROM customer", con);
                    DataTable custIdView = new DataTable();
                    custIdNames.Fill(custIdView);
                    comboBox1.DataSource = custIdView;
                    comboBox1.DisplayMember = "customerName";
                    comboBox1.ValueMember = "customerId";

                    custIdNames.SelectCommand = new MySqlCommand("SELECT userId, userName FROM user", con);
                    DataTable userIdView = new DataTable();
                    custIdNames.Fill(userIdView);
                    comboBox2.DataSource = userIdView;
                    comboBox2.DisplayMember = "userName";
                    comboBox2.ValueMember = "userId";

                    
                    

                    // label7.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    foreach (DataGridViewRow r in dataGridView1.Rows)
                    {
                        DateTime apptFifteenReminder = Convert.ToDateTime(r.Cells[9].Value);
                        int apptId = Convert.ToInt32(r.Cells[0].Value);
                        int custId = Convert.ToInt32(r.Cells[1].Value);


                        if (apptFifteenReminder >= DateTime.Now && apptFifteenReminder <= DateTime.Now.AddMinutes(15))
                        {
                            MessageBox.Show("Appointment Alert\n" + "Appointment Id:" + apptId + "\n with Customer Id:" + custId);
                        }

                    }

                    for (int i = 0; i < custTableView.Rows.Count; i++)
                    {
                        custTableView.Rows[i]["start"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)custTableView.Rows[i]["start"], TimeZoneInfo.Local).ToString();
                        custTableView.Rows[i]["end"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)custTableView.Rows[i]["end"], TimeZoneInfo.Local).ToString();
                    }

                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int apptId = (int)dataGridView1.SelectedCells[0].Value;
            appointmentId = apptId;

            con.Open();
            string selectCustAppt = "SELECT appointment.customerId, customer.customerName, appointment.userId, appointment.type, appointment.start, appointment.end FROM appointment, customer WHERE appointmentId = '" + apptId + "' AND appointment.customerID = customer.customerID";
            
            MySqlCommand command;
            
            MySqlDataReader mdr;
            

            command = new MySqlCommand(selectCustAppt, con);
            

            mdr = command.ExecuteReader();

            

            if (mdr.Read())
            {

                DateTime var222 = mdr.GetDateTime("start");
                DateTime var333 = mdr.GetDateTime("end");
                TimeZoneInfo systemTimeZone = TimeZoneInfo.Local;

                DateTime toLocalDateTimeStart = TimeZoneInfo.ConvertTimeFromUtc(var222, systemTimeZone);
                DateTime toLocalDateTimeEnd = TimeZoneInfo.ConvertTimeFromUtc(var333, systemTimeZone);


                textBox1.Text = mdr.GetString("type");
                comboBox1.Text = mdr.GetString("customerName");
                dateTimePicker1.Value = toLocalDateTimeStart;
                dateTimePicker2.Value = toLocalDateTimeEnd;
                comboBox2.Text = mdr.GetString("userId");
               
            }
            else
            {
                MessageBox.Show("Error Invalid ID. \n Try Again.");
            }
            con.Close();
            mdr.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MySqlCommand commandUser = new MySqlCommand("SELECT CURRENT_USER()", con);
            DataTable dataUserLog = new DataTable();
            MySqlDataAdapter sda = new MySqlDataAdapter(commandUser);
            sda.Fill(dataUserLog);
            string currentUser;
            currentUser = dataUserLog.Rows[0].ItemArray[0].ToString();
          

            bool? start1 = null;
            bool? end2 = null;
            


            DateTime dt1 = dateTimePicker1.Value;
            TimeSpan st1 = new TimeSpan(dt1.Hour, dt1.Minute, dt1.Second);

            DateTime dt2 = dateTimePicker2.Value;
            TimeSpan st2 = new TimeSpan(dt2.Hour, dt2.Minute, dt2.Second);

            foreach (DataGridViewRow r in dataGridView1.Rows)
            {

                DateTime callValue = Convert.ToDateTime(r.Cells[9].Value);
                DateTime callsValue = Convert.ToDateTime(r.Cells[10].Value);
                if (dateTimePicker1.Value == callValue)
                {

                    start1 = true;
                }
                else if (dateTimePicker2.Value == callsValue)
                {

                    end2 = true;
                }
                else if (dt1 == callValue.AddMinutes(15))
                {
                    start1 = true;
                }
                else if (dt2 == callsValue.AddMinutes(15))
                {
                    end2 = true;
                }
                else if (dt1 == callValue.AddMinutes(30))
                {
                    start1 = true;
                }
                else if (dt2 == callsValue.AddMinutes(30))
                {
                    end2 = true;
                }
                else if (dt1 == callValue.AddMinutes(45))
                {
                    start1 = true;
                }
                else if (dt2 == callsValue.AddMinutes(45))
                {
                    end2 = true;
                }
                else if (callValue <= dt1 && dt1 <= callsValue)
                {
                    start1 = true;
                }
                else if (callValue <= dt2 && dt2 <= callsValue)
                {
                    end2 = true;
                }
                else
                {
                    start1 = false;
                    end2 = false;
                }
            }

            Action<string> addErrorCodes = x => MessageBox.Show(x);
            //Creation of main Lambda line to better streamline messageboxes. Since the if else statements cover a wide variety, it's easier to keep track of it.
            

            try
            {
                


                if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date || dateTimePicker1.Value.Hour > dateTimePicker2.Value.Hour)
                {
                    addErrorCodes("Start time cannot be later than end time.");
                }
                else if (dateTimePicker1.Value.Day != dateTimePicker2.Value.Day || dateTimePicker2.Value.Day != dateTimePicker1.Value.Day)
                {
                    addErrorCodes("Appointment has to be on the same day.");
                }
                else if (dateTimePicker1.Value.Hour < 9 || dateTimePicker2.Value.Hour > 15)
                {
                    addErrorCodes("Appointment has to be within business hours.");
                }
                else if (start1 == true || end2 == true)
                {
                    addErrorCodes("Cannot create appointment. \nThere is already an appointment during parts of this time.");
                }
                else if (string.IsNullOrEmpty(textBox1.Text))
                {
                    addErrorCodes("Appointment Type cannot be empty.");
                }
                else
                {
                    

                    DateTime dtp1 = dateTimePicker1.Value;
                    DateTime dtp2 = dateTimePicker2.Value;

                    DateTime dateTimePicker1Format = TimeZoneInfo.ConvertTimeToUtc(dtp1);
                    DateTime dateTimePicker2Format = TimeZoneInfo.ConvertTimeToUtc(dtp2);

                    

                    string dateTimePicker1Format2 = dateTimePicker1Format.ToString("yyyy-MM-dd HH:mm:ss");
                    string dateTimePicker2Format3 = dateTimePicker2Format.ToString("yyyy-MM-dd HH:mm:ss");

                    cust.InsertCommand = new MySqlCommand("INSERT INTO appointment (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES ('" + comboBox1.SelectedValue.ToString() + "','" + comboBox2.SelectedValue.ToString() + "', 'not needed', 'not needed', 'not needed', 'not needed', '" + textBox1.Text + "', 'not needed', '" + dateTimePicker1Format2 + "', '" + dateTimePicker2Format3 + "', NOW(), '" + currentUser + "', NOW(), '" + currentUser + "')", con);


                    con.Open();
                    cust.InsertCommand.ExecuteNonQuery();
                    con.Close();

                    textBox1.Text = String.Empty;

                    cust.SelectCommand = new MySqlCommand("SELECT * FROM appointment", con);
                    DataTable custTableView = new DataTable();
                    cust.Fill(custTableView);
                    dataGridView1.DataSource = custTableView;

                    MessageBox.Show("Added New Appointment");
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        

        public void button2_Click(object sender, EventArgs e)
        {
            


            bool? start3 = null;
            bool? end4 = null;

            DateTime dt1 = dateTimePicker1.Value;
            DateTime dt2 = dateTimePicker2.Value;

            foreach (DataGridViewRow r in dataGridView1.Rows)
            {

                DateTime callValue = Convert.ToDateTime(r.Cells[9].Value);
                DateTime callsValue = Convert.ToDateTime(r.Cells[10].Value);
                DateTime box1 = dateTimePicker1.Value;
                DateTime box2 = dateTimePicker2.Value;

                if (box1 == callValue)
                {
                    start3 = true;
                }
                else if (box2 == callsValue)
                {
                    end4 = true;
                }
                else if (dt1 == callValue.AddMinutes(15))
                {
                    start3 = true;
                }
                else if (dt2 == callsValue.AddMinutes(15))
                {
                    end4 = true;
                }
                else if (dt1 == callValue.AddMinutes(30))
                {
                    start3 = true;
                }
                else if (dt2 == callsValue.AddMinutes(30))
                {
                    end4 = true;
                }
                else if (dt1 == callValue.AddMinutes(45))
                {
                    start3 = true;
                }
                else if (dt2 == callsValue.AddMinutes(45))
                {
                    end4 = true;
                }
                else if (callValue <= dt1 && dt1 <= callsValue)
                {
                    start3 = true;
                }
                else if (callValue <= dt2 && dt2 <= callsValue)
                {
                    end4 = true;
                }
                else
                {
                    start3 = false;
                    end4 = false;
                }
            }

            Action<string> addErrorCodes2 = x => MessageBox.Show(x);


            
            

            try
            {

                if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date || dateTimePicker1.Value.Hour > dateTimePicker2.Value.Hour)
                {
                    addErrorCodes2("Start time cannot be later than end time.");
                }
                else if (dateTimePicker1.Value.Day != dateTimePicker2.Value.Day || dateTimePicker2.Value.Day != dateTimePicker1.Value.Day)
                {
                    addErrorCodes2("Appointment has to be on the same day.");
                }
                else if (dateTimePicker1.Value.Hour < 9 || dateTimePicker2.Value.Hour > 15)
                {
                    addErrorCodes2("Appointment has to be within business hours.");
                }
                else if (start3 == true || end4 == true)
                {
                    addErrorCodes2("Cannot update appointment. \nThere is already an appointment during parts of this time.");
                }
                else if (string.IsNullOrEmpty(textBox1.Text))
                {
                    addErrorCodes2("Appointment Type cannot be empty.");
                }
                else
                {

                    DateTime dtp1 = dateTimePicker1.Value;
                    DateTime dtp2 = dateTimePicker2.Value;

                    DateTime dateTimePicker1Format = TimeZoneInfo.ConvertTimeToUtc(dtp1);
                    DateTime dateTimePicker2Format = TimeZoneInfo.ConvertTimeToUtc(dtp2);



                    string dateTimePicker1Format2 = dateTimePicker1Format.ToString("yyyy-MM-dd HH:mm:ss");
                    string dateTimePicker1Format3 = dateTimePicker2Format.ToString("yyyy-MM-dd HH:mm:ss");


                    con2.Open();
                    string updateQuery = "UPDATE appointment SET customerId ='" + comboBox1.SelectedValue.ToString() + "', userId = '" + comboBox2.SelectedValue.ToString() + "', title = 'not needed', description = 'not needed', location = 'not needed', contact = 'not needed', type = '" + textBox1.Text + "', url = 'not needed', start =  '" + dateTimePicker1Format2 + "', end = '" + dateTimePicker1Format3 + "', lastUpdate = NOW(), lastUpdateBy = CURRENT_USER() WHERE appointmentId = '" + appointmentId + "'";
                    MySqlCommand command2;
                    MySqlDataReader mdr2;

                    command2 = new MySqlCommand(updateQuery, con2);

                    command2.ExecuteReader();


                    textBox1.Text = String.Empty;
                    comboBox1.SelectedValue = 1;
                    dateTimePicker1.Value = DateTime.Now;
                    dateTimePicker2.Value = DateTime.Now;
                    comboBox2.SelectedValue = 1;


                    cust.SelectCommand = new MySqlCommand("SELECT * FROM appointment", con);
                    DataTable custTableView = new DataTable();
                    cust.Fill(custTableView);
                    dataGridView1.DataSource = custTableView;

                    MessageBox.Show("Updated Appointment");
                    con2.Close();
                }
            }


            catch (Exception x)
            {
                MessageBox.Show(x.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                deleteAppt.DeleteCommand = new MySqlCommand("DELETE FROM appointment WHERE appointmentId = '" + appointmentId + "'", con);
                con.Open();
                deleteAppt.DeleteCommand.ExecuteNonQuery();
                con.Close();

                textBox1.Text = String.Empty;
                comboBox1.SelectedValue = 1;
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
                comboBox2.SelectedValue = 1;

                cust.SelectCommand = new MySqlCommand("SELECT * FROM appointment", con);
                DataTable custTableView = new DataTable();
                cust.Fill(custTableView);
                dataGridView1.DataSource = custTableView;

                MessageBox.Show("Deleted Appointment");

            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }
    }
}
