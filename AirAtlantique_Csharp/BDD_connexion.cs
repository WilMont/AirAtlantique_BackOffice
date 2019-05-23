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
            //Création de la chaine de connexion.
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
