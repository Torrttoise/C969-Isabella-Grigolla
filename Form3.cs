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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetUsersList();

        }

        private DataTable GetUsersList()
        {
            //MySqlCommand cmd = ConnectionDatabase.conn.CreateCommand();
            DataTable userList = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["virtualHostLocal"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("select * from customer", conn))
                {
                    conn.Open();

                    MySqlDataReader reader = cmd.ExecuteReader();

                    userList.Load(reader);
                }
            }
            
            return userList;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Host = localhost; Port = 3306; Database = client_schedule; Username = sqlUser; Password = Passw0rd!
                SqlConnection con = new SqlConnection("Server =localhost; Database=client_schedule; username=test; password=test; Integrated Security = true;");
                con.Open();
                SqlCommand cmd = new SqlCommand(); // you can define commandText and connection in SqlCommand(defineArea);
                cmd.Connection = con;              // like; cmd = newSqlCommand("Insert into...",con);

                DateTime dateTimeVariable = DateTime.Today;


                cmd.CommandText = "Insert into customer(customerName, createDate)values(@customerName, @createDate)";
                cmd.Parameters.AddWithValue("@customerName", textBox1.Text);
                //cmd.Parameters.AddWithValue("@createDate", dateTimeVariable);
                cmd.Parameters.Clear();


                cmd.CommandText = "Insert into address( address, phone)values(@address, @phone)";
                
                cmd.Parameters.AddWithValue("@address", textBox2.Text);
                cmd.Parameters.AddWithValue("@phone", textBox3.Text);
                cmd.Parameters.Clear();

                cmd.CommandText = "Insert into city(city)values(@city)";
                cmd.Parameters.AddWithValue("@city", textBox4.Text);
                cmd.Parameters.Clear();


                cmd.CommandText = "Insert into country(country)values(@country)";
                cmd.Parameters.AddWithValue("@country", textBox1.Text);
                

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.Dispose();
                con.Close();


                MessageBox.Show("Save Success!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception : " + ex);
            }
        }
    }

}
