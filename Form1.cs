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
using System.Configuration;
using MySql.Data.MySqlClient;
using C969_Isabella_Grigolla.Database_Files;
using System.Globalization;

namespace C969_Isabella_Grigolla
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var culture = new CultureInfo("EN");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox1.Enter += new EventHandler(textBox1_Enter);
            this.textBox1.Leave += new EventHandler(textBox1_Leave);
            textBox1_SetText();
            this.textBox2.Enter += new EventHandler(textBox2_Enter);
            this.textBox2.Leave += new EventHandler(textBox2_Leave);
            textBox2_SetText();
        }

        protected void textBox1_SetText()
        {
            this.textBox1.Text = "Please input Username";
            textBox1.ForeColor = Color.Gray;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.ForeColor == Color.Black)
                return;
            textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
                textBox1_SetText();
        }


        protected void textBox2_SetText()
        {
            this.textBox2.Text = "Please input Password";
            textBox2.ForeColor = Color.Gray;
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.ForeColor == Color.Black)
                return;
            textBox2.Text = "";
            textBox2.ForeColor = Color.Black;
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "")
                textBox2_SetText();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
        int i;
        public void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            MySqlCommand cmd = ConnectionDatabase.conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from user where userName='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());



            if (i==0)
            {
                MessageBox.Show("Invalid Login./n Please Try Again.");
            }
            else
            {
                this.Hide();
                Form2 t = new Form2();
                //MessageBox.Show("Login Successful");
                t.Show();
                
            }

           /* if (f == true)
            { 

            }*/


        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
