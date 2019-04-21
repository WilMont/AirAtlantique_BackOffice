using AirAtlantique_Csharp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique_Csharp.ViewModels.Queries
{
    class ClientDAL
    {
        private static MySqlConnection connection = BDD_connexion.GetConnection();

        public void SelectClients(ObservableCollection<Client> ObsColClient)
        {
            connection.Close();
            connection.Open();

            string query = "SELECT c.id,c.nom,c.prenom,c.pays,c.ville,c.code_postal,c.telephone,c.adresse FROM client c Group BY c.id";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Client c = new Client(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7));
                ObsColClient.Add(c);
            }
            reader.Close();

            connection.Close();
        }

        public void SelectClient(ObservableCollection<Client> l, int id)
        {
            connection.Close();
            connection.Open();

            string query = "SELECT c.idClient,c.nom,c.prenom,c.pays,c.ville,c.code_postal,c.telephone,c.adresse FROM client c Where c.id = @id Group BY c.id";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Client c = new Client(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7));
                l.Add(c);
            }
            reader.Close();

            connection.Close();
        }

        public static void UpdateClient(Client c)
        {
            connection.Open();

            string query = "UPDATE client SET nom=@nom,prenom=@prenom,pays=@pays,ville=@vil,code_postal=@cp,telephone=@tel,adresse=@adr WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@nom", c.NomProperty);
            cmd.Parameters.AddWithValue("@prenom", c.PrenomProperty);
            cmd.Parameters.AddWithValue("@pays", c.PaysProperty);
            cmd.Parameters.AddWithValue("@vil", c.VilleProperty);
            cmd.Parameters.AddWithValue("@cp", c.CodePostalProperty);
            cmd.Parameters.AddWithValue("@tel", c.TelephoneProperty);
            cmd.Parameters.AddWithValue("@adr", c.AdresseProperty);
            cmd.Parameters.AddWithValue("@id", c.IdProperty);

            cmd.ExecuteNonQuery();
            connection.Close();
        }

    }
}
