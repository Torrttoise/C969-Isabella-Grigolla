using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Isabella_Grigolla.Database_Files
{
    class ConnectionDatabase
    {
        public static MySqlConnection conn { get; set; }

        public static void startConnection()
        {
            string constr = ConfigurationManager.ConnectionStrings["virtualHostLocal"].ConnectionString;


            try
            {
                conn = new MySqlConnection(constr);

                conn.Open();

                MessageBox.Show("Connection is Successful");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void closeConnection()
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();
                }
                conn = null;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
