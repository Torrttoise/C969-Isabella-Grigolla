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
    public partial class Form5 : Form
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
        MySqlDataAdapter cust2 = new MySqlDataAdapter();



        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            try
            {
                {
                    cust.SelectCommand = new MySqlCommand("SELECT appointmentId, customerId, userId, type, start, end FROM appointment", con);
                    DataTable custTableView = new DataTable();
                    cust.Fill(custTableView);
                    dataGridView1.DataSource = custTableView;
                }

            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    cust.SelectCommand = new MySqlCommand("SELECT appointmentId, customerId, userId, type, start, end FROM appointment", con);
                    DataTable custTableView = new DataTable();
                    cust.Fill(custTableView);
                    dataGridView1.DataSource = custTableView;
                }

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
                {
                    cust.SelectCommand = new MySqlCommand("SELECT appointmentId, customerId, userId, type, start, end FROM appointment WHERE YEARWEEK(start) = YEARWEEK(NOW())", con);
                    DataTable custTableView = new DataTable();
                    cust.Fill(custTableView);
                    dataGridView1.DataSource = custTableView;
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
                {
                    cust.SelectCommand = new MySqlCommand("SELECT appointmentId, customerId, userId, type, start, end FROM appointment WHERE MONTH(start) = MONTH(NOW())", con);
                    DataTable custTableView = new DataTable();
                    cust.Fill(custTableView);
                    dataGridView1.DataSource = custTableView;
                }

            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
        }
    }
}
