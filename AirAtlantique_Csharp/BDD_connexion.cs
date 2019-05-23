using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;

namespace AirAtlantique_Csharp
{
    class BDD_connexion
    {
        /*static MySqlConnection connection;
        static private string server;
        static private string database;
        static private string uid;
        static private string password;
        static private int port; */


        /* public static MySqlConnection GetConnection()
        {
            if (connection == null)
            {

                server = "localhost";
                database = "w_montagne";
                uid = "w_montagne";
                password = "Epsi2019!";
                port = 3306;
                string connectionString;
                connectionString = "SERVER=" + server + ";" + "Port=" + port + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
                connection = new MySqlConnection(connectionString);
            }
            return connection;
        } */

        private MySqlConnection _connection;
        public MySqlConnection Connection
        {
            get { return _connection; }
        }

        public BDD_connexion()
        {
            this.InitConnexion();
        }

        private void InitConnexion()
        {
            try
            {
                this._connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["localhost"].ConnectionString);
            }
            catch(InvalidCastException e)
            {
                MessageBox.Show(e.Message);
            }
        }


    }
}
