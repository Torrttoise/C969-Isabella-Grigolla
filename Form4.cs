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
    public partial class Form4 : Form
    {
       //MySqlConnection connection = new MySqlConnection("virtualHostLocal");
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["virtualHostLocal"].ConnectionString;
                MySqlConnection conn = new MySqlConnection(constr);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(); // you can define commandText and connection in SqlCommand(defineArea);
                cmd.Connection = conn;              // like; cmd = newSqlCommand("Insert into...",con);
                
                cmd.CommandText = "Insert into customer(customerName)values('" + textBox1.Text + "')";
                cmd.CommandText = "Insert into address(address, phone)values('" + textBox2.Text + "', '" + "')";
                cmd.CommandText = "Insert into city(city)values('" + textBox4.Text + "')";
                cmd.CommandText = "Insert into country(country)values('" + textBox8.Text + "')";

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();

                
                MessageBox.Show("Save Success!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception : " + ex);
            }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
