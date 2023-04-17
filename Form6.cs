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


        public Form6()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                cust.SelectCommand = new MySqlCommand("SELECT appointmentId, customerId, userId, type, start, end FROM appointment WHERE MONTH(start) = MONTH(NOW())", con);
                DataTable apptMonth = new DataTable();
                cust.Fill(apptMonth);
                BindingSource apptMSource = new BindingSource();
                apptMSource.DataSource = apptMonth;
                cust.Update(apptMonth);

                StringBuilder sb = new StringBuilder();

                string[] columnNames = apptMonth.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();
                //The Lambda expression here is filtering out the data in the datatable to determine which part is the column headers.

                sb.AppendLine(string.Join(",", columnNames));

                foreach (DataRow row in apptMonth.Rows)
                {
                    string[] dataM = row.ItemArray.Select(data => data.ToString()).ToArray();
                    //The Lambda expression here is grabbing each differentiating for of data from their respective headers and seperating it in the statement below.

                    sb.AppendLine(string.Join(",", dataM));

                }

                string paths = @"C:\Users\LabUser\Documents\appointmentsByMonth.csv";

                //System.IO.File.WriteAllText(paths, sb.ToString());

               

                string fileTest = System.IO.Path.Combine(paths, "appointmentsByMonth.csv");


                if (System.IO.File.Exists(paths))
                {
                    System.IO.File.WriteAllText(paths, sb.ToString());
                }
                else
                {
                    System.IO.File.Create(paths);
                    System.IO.File.WriteAllText(paths, sb.ToString());
                }
                MessageBox.Show("The Appointment by month report has been printed.\nThis file can be located in the Documents Folder.");
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
                cust.SelectCommand = new MySqlCommand("SELECT * FROM appointment", con);
                DataTable appointmentSchedule = new DataTable();
                cust.Fill(appointmentSchedule);
                BindingSource apptScSource = new BindingSource();
                apptScSource.DataSource = appointmentSchedule;
                cust.Update(appointmentSchedule);

                StringBuilder sb = new StringBuilder();

                string[] columnNames = appointmentSchedule.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();
                //The Lambda expression here is filtering out the data in the datatable to determine which part is the column headers. * Same as mentioned in the button1_Click function *

                sb.AppendLine(string.Join(",", columnNames));

                foreach (DataRow row in appointmentSchedule.Rows)
                {
                    string[] dataM = row.ItemArray.Select(data => data.ToString()).ToArray();
                    //The Lambda expression here is grabbing each differentiating for of data from their respective headers and seperating it in the statement below. * Same as mentioned in the button1_Click function *

                    sb.AppendLine(string.Join(",", dataM));

                }

                string paths = @"C:\Users\LabUser\Documents\ConsultantsAppointments.csv";


                string fileTest = System.IO.Path.Combine(paths, "ConsultantsAppointments.csv");


                if (System.IO.File.Exists(paths))
                {
                    System.IO.File.WriteAllText(paths, sb.ToString());
                }
                else
                {
                    System.IO.File.Create(paths);
                    System.IO.File.WriteAllText(paths, sb.ToString());
                }
                MessageBox.Show("The scheduled Appointments for all Consultants report has been printed.\nThis file can be located in the Documents Folder.");
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
                DataTable allCustomers = new DataTable();
                cust.Fill(allCustomers);
                BindingSource allCSource = new BindingSource();
                allCSource.DataSource = allCustomers;
                cust.Update(allCustomers);

                StringBuilder sb = new StringBuilder();

                string[] columnNames = allCustomers.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();
                //The Lambda expression here is filtering out the data in the datatable to determine which part is the column headers. * Same as mentioned in the button1_Click function *

                sb.AppendLine(string.Join(",", columnNames));

                foreach (DataRow row in allCustomers.Rows)
                {
                    string[] dataM = row.ItemArray.Select(data => data.ToString()).ToArray();
                    //The Lambda expression here is grabbing each differentiating for of data from their respective headers and seperating it in the statement below. * Same as mentioned in the button1_Click function *

                    sb.AppendLine(string.Join(",", dataM));

                }

                string paths = @"C:\Users\LabUser\Documents\AllCurrentCustomers.csv";


                string fileTest = System.IO.Path.Combine(paths, "AllCurrentCustomers.csv");


                if (System.IO.File.Exists(paths))
                {
                    System.IO.File.WriteAllText(paths, sb.ToString());
                }
                else
                {
                    System.IO.File.Create(paths);
                    System.IO.File.WriteAllText(paths, sb.ToString());
                }
                MessageBox.Show("The report for All current Customers has been printed.\nThis file can be located in the Documents Folder.");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
