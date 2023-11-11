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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace C969_Isabella_Grigolla
{
    public partial class Form3 : Form
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
        MySqlDataAdapter cust3 = new MySqlDataAdapter();
        MySqlDataAdapter cust4 = new MySqlDataAdapter();
        MySqlDataAdapter userUpdate = new MySqlDataAdapter();
        int customerId;

        MySqlDataAdapter search = new MySqlDataAdapter();

        MySqlDataAdapter deleteCust = new MySqlDataAdapter();

        //singh = cust;
        //bumrah = custTableView;
        //amandeep = con;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                {
                    cust.SelectCommand = new MySqlCommand("SELECT * FROM customer", con);
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


        void viewCustomer(MySqlConnection con)
        {
            try
            {
                {
                    cust.SelectCommand = new MySqlCommand("SELECT * FROM customer", con);
                    DataTable custTableView = new DataTable();
                    cust.Fill(custTableView);
                    dataGridView1.DataSource = custTableView;
                }

            }
            catch(Exception x)
            {
                MessageBox.Show(x.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand commandUser = new MySqlCommand("SELECT CURRENT_USER()", con);
            DataTable dataUserLog = new DataTable();
            MySqlDataAdapter sda = new MySqlDataAdapter(commandUser);
            sda.Fill(dataUserLog);
            string currentUser;
            currentUser = dataUserLog.Rows[0].ItemArray[0].ToString();
            //User = Form1.User;

            try
            {
                //cust.InsertCommand = new MySqlCommand("INSERT INTO customer (customerName, addressid) VALUES ('" + textBox1.Text + "') SELECT addressId FROM address Order BY addressId DESC LIMIT 1", con);

                //userFind.SelectCommand = new MySqlCommand("SELECT USER()", con);
                if(string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox8.Text) || string.IsNullOrEmpty(textBox3.Text))
                {
                    MessageBox.Show("Data cannot be empty, please enter data.");
                }
                else
                {
                    cust.InsertCommand = new MySqlCommand("INSERT INTO country (country, createDate, createdBy, lastUpdateBy) VALUES ('" + textBox8.Text + "', NOW(), '" + currentUser + "', '" + currentUser + "')", con);
                    cust2.InsertCommand = new MySqlCommand("INSERT INTO city (city, countryId, createDate, createdBy, lastUpdateBy) VALUES ('" + textBox4.Text + "', LAST_INSERT_ID(), NOW(), '" + currentUser + "', '" + currentUser + "')", con);
                    cust3.InsertCommand = new MySqlCommand("INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdateBy) VALUES ('" + textBox2.Text + "', 'not needed', LAST_INSERT_ID(), 'not needed', '" + textBox3.Text + "', NOW(), '" + currentUser + "', '" + currentUser + "')", con);
                    cust4.InsertCommand = new MySqlCommand("INSERT INTO customer (customerName, addressId, active,  createDate, createdBy, lastUpdateBy) VALUES ('" + textBox1.Text + "', LAST_INSERT_ID(), '" + 1 + "', NOW(), '" + currentUser + "', '" + currentUser + "')", con);

                    con.Open();
                    cust.InsertCommand.ExecuteNonQuery();
                    cust2.InsertCommand.ExecuteNonQuery();
                    cust3.InsertCommand.ExecuteNonQuery();
                    cust4.InsertCommand.ExecuteNonQuery();
                    con.Close();

                    textBox1.Text = String.Empty;
                    textBox2.Text = String.Empty;
                    textBox4.Text = String.Empty;
                    textBox8.Text = String.Empty;
                    textBox3.Text = String.Empty;

                    cust.SelectCommand = new MySqlCommand("SELECT * FROM customer", con);
                    DataTable custTableView = new DataTable();
                    cust.Fill(custTableView);
                    dataGridView1.DataSource = custTableView;

                    MessageBox.Show("Added New Customer");
                }
                

            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        
        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //userUpdate
            int addId = (int) dataGridView1.SelectedCells[2].Value;
            int custId = (int)dataGridView1.SelectedCells[0].Value;
            customerId = custId;

            con.Open();

            string selectAddIds = "SELECT address.address , city.city, country.country, address.phone FROM address, city, country WHERE addressId = '" + addId + " ' AND address.cityId = city.cityId AND city.countryId = country.countryId";
            MySqlCommand command;
            MySqlDataReader mdr;

            command = new MySqlCommand(selectAddIds, con);

            mdr = command.ExecuteReader();

            var phoneTest = mdr.GetOrdinal("phone");

            mdr.Read();
            if(Convert.IsDBNull(mdr["phone"]))
            {
                textBox1.Text = dataGridView1.SelectedCells[1].Value.ToString();
                textBox2.Text = mdr.GetString("address");
                textBox4.Text = mdr.GetString("city");
                textBox8.Text = mdr.GetString("country");
                textBox3.Text = "";
                /*
                string phoneNull = mdr.GetString("phone");

                if (phoneNull == null)
                {
                    textBox3.Text = "";
                }
                else
                {
                    textBox3.Text = mdr.GetString("phone");
                } */

                
            }
            else
            {
                textBox1.Text = dataGridView1.SelectedCells[1].Value.ToString();
                textBox2.Text = mdr.GetString("address");
                textBox4.Text = mdr.GetString("city");
                textBox8.Text = mdr.GetString("country");
                textBox3.Text = mdr.GetString("phone");
            }
            con.Close();
            mdr.Close();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox8.Text) || string.IsNullOrEmpty(textBox3.Text))
                {
                    MessageBox.Show("Data cannot be empty, please enter data.");
                }
                else
                {
                    con2.Open();
                    string updateQuery = "UPDATE customer, address, city, country SET customer.customerName ='" + textBox1.Text + "', address.address = '" + textBox2.Text + "', city.city = '" + textBox4.Text + "', country.country = '" + textBox8.Text + "', address.phone = '" + textBox3.Text + "' WHERE customer.customerId = '" + customerId + " ' AND customer.addressId = address.addressId AND address.cityId = city.cityId AND city.countryId = country.countryId";
                    MySqlCommand command2;
                    MySqlDataReader mdr2;

                    command2 = new MySqlCommand(updateQuery, con2);

                    command2.ExecuteReader();


                    textBox1.Text = String.Empty;
                    textBox2.Text = String.Empty;
                    textBox4.Text = String.Empty;
                    textBox8.Text = String.Empty;
                    textBox3.Text = String.Empty;


                    cust.SelectCommand = new MySqlCommand("SELECT * FROM customer", con);
                    DataTable custTableView = new DataTable();
                    cust.Fill(custTableView);
                    dataGridView1.DataSource = custTableView;

                    MessageBox.Show("Updated Customer");
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
                deleteCust.DeleteCommand = new MySqlCommand("DELETE FROM customer WHERE customerId = '"+ customerId + "'", con);
                con.Open();
                deleteCust.DeleteCommand.ExecuteNonQuery();
                con.Close();

                textBox1.Text = String.Empty;
                textBox2.Text = String.Empty;
                textBox4.Text = String.Empty;
                textBox8.Text = String.Empty;
                textBox3.Text = String.Empty;

                cust.SelectCommand = new MySqlCommand("SELECT * FROM customer", con);
                DataTable custTableView = new DataTable();
                cust.Fill(custTableView);
                dataGridView1.DataSource = custTableView;

                MessageBox.Show("Deleted Customer");

            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                //search.SelectCommand = new MySqlCommand("SELECT * FROM customer WHERE CONCAT('customerId', 'customerName', 'createdBy', 'lastUpdateBy') LIKE '" + textBox5.Text + "'", con);
                search.SelectCommand = new MySqlCommand("SELECT * FROM customer WHERE customerId LIKE '%" + textBox5.Text + "%' OR customerName LIKE '%" + textBox5.Text + "%' OR createdBy LIKE '%" + textBox5.Text + "%' OR lastUpdateBy LIKE '%" + textBox5.Text + "%'", con);
                
                DataTable custTableView = new DataTable();
                search.Fill(custTableView);
                BindingSource customerSearch = new BindingSource();
                customerSearch.DataSource = custTableView;
                search.Update(custTableView);
                dataGridView1.DataSource = custTableView;

           

            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    cust.SelectCommand = new MySqlCommand("SELECT * FROM customer", con);
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
