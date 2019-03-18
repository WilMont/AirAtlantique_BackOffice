using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique_Csharp
{
    class BDD_connexion
    {
        static MySqlConnection connection;
        static private string server;
        static private string database;
        static private string uid;
        static private string password;
        static private int port;


        public static MySqlConnection GetConnection()
        {
            if (connection == null)
            {

                server = "localhost";
                database = "airatlantiquecsharp";
                uid = "root";
                password = "Epsi2018!";
                port = 3306;
                string connectionString;
                connectionString = "SERVER=" + server + ";" + "Port=" + port + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
                connection = new MySqlConnection(connectionString);
            }
            return connection;
        }
    }
}
