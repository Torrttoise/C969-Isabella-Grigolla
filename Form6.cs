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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace C969_Isabella_Grigolla
{
    public partial class Form6 : Form
    {
        MySqlConnection con = new MySqlConnection("Data Source=127.0.0.1,3306;" +
                "Initial Catalog =client_schedule;" +
                "Integrated Security =true;" +
                "User =sqlUser;" +
                "Password =Passw0rd!");

        MySqlDataAdapter cust = new MySqlDataAdapter();

        MySqlDataAdapter custIdNames = new MySqlDataAdapter();
        int appointmentId;

        public Form6()
        {
            InitializeComponent();
        }
        
        public void Form6_Load_1(object sender, EventArgs e)
        {
            /*
            Dictionary<string, int> months = new Dictionary<string, int>
            {
                { "Jan", 1 },
                { "Feb", 2 },
                { "Mar", 3 },
                { "Apr", 4 },
                { "May", 5 },
                { "Jun", 6 },
                { "Jul", 7 },
                { "Aug", 8 },
                { "Sep", 9 },
                { "Oct", 10 },
                { "Nov", 11 },
                { "Dec", 12 },
            };
            */
            var months = System.Globalization.DateTimeFormatInfo.InvariantInfo.MonthNames;
            comboBox1.DataSource = months;

            custIdNames.SelectCommand = new MySqlCommand("SELECT userId, userName FROM user", con);
            DataTable userIdView = new DataTable();
            custIdNames.Fill(userIdView);
            comboBox2.DataSource = userIdView;
            comboBox2.DisplayMember = "userName";
            comboBox2.ValueMember = "userId";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                int iVal = comboBox1.SelectedIndex + 1;
                cust.SelectCommand = new MySqlCommand("SELECT type, COUNT(type) FROM appointment WHERE MONTH(start) = " + iVal + " GROUP BY type", con);
                DataTable apptMonth = new DataTable();
                cust.Fill(apptMonth);
                BindingSource apptMSource = new BindingSource();
                apptMSource.DataSource = apptMonth;
                cust.Update(apptMonth);
                dataGridView1.DataSource = apptMonth;
            }

            catch (Exception x)
            {
                MessageBox.Show(x.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cust.SelectCommand = new MySqlCommand("SELECT * FROM appointment WHERE userId ="+ comboBox2.SelectedValue.ToString() +"", con);
                DataTable userMonth = new DataTable();
                cust.Fill(userMonth);
                BindingSource apptMSource = new BindingSource();
                apptMSource.DataSource = userMonth;
                cust.Update(userMonth);
                dataGridView1.DataSource = userMonth;
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
                cust.SelectCommand = new MySqlCommand("SELECT * FROM customer", con);
                DataTable currentCustomers = new DataTable();
                cust.Fill(currentCustomers);
                BindingSource apptMSource = new BindingSource();
                apptMSource.DataSource = currentCustomers;
                cust.Update(currentCustomers);
                dataGridView1.DataSource = currentCustomers;
            }
            catch (Exception x) 
            {
                MessageBox.Show(x.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}
