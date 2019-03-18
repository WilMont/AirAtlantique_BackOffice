using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique_Csharp.Models.DAL
{
    class ClientDAL
    {
        private static MySqlConnection connection = BDD_connexion.GetConnection();

        public void SelectClients(ObservableCollection<Client> l)
        {
            connection.Close();
            connection.Open();

            string query = "SELECT c.idClient,c.nom,c.prenom,c.pays,c.ville,c.codePostal,c.telephone,c.adresse,c.ptsFidelite,c.id_dernier_vol,v.arrivee_reelle FROM clients c INNER JOIN vols v ON v.idVol = c.id_dernier_vol Group BY c.idClient";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Client c = new Client(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetInt32(8), reader.GetInt32(9), reader.GetDateTime(10));
                l.Add(c);
            }
            reader.Close();

            connection.Close();
        }

        public void SelectClient(ObservableCollection<Client> l, int id)
        {
            connection.Close();
            connection.Open();

            string query = "SELECT c.idClient,c.nom,c.prenom,c.pays,c.ville,c.codePostal,c.telephone,c.adresse,c.ptsFidelite,c.id_dernier_vol,v.arrivee_reelle FROM clients c INNER JOIN vols v ON v.idVols = c.id_dernier_vol Where c.idClient = @id Group BY c.idClient";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Client c = new Client(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetInt32(8), reader.GetInt32(9), reader.GetDateTime(10));
                l.Add(c);
            }
            reader.Close();

            connection.Close();
        }

        public static void UpdateClient(Client c)
        {
            connection.Open();

            string query = "UPDATE clients SET nom=@nom,prenom=@prenom,pays=@pays,ville=@vil,codePostal=@cp,telephone=@tel,adresse=@adr,ptsFidelite=@pfide WHERE idClient = @idcl";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@nom", c.NomProperty);
            cmd.Parameters.AddWithValue("@prenom", c.PrenomProperty);
            cmd.Parameters.AddWithValue("@pays", c.PaysProperty);
            cmd.Parameters.AddWithValue("@vil", c.VilleProperty);
            cmd.Parameters.AddWithValue("@cp", c.CodePostalProperty);
            cmd.Parameters.AddWithValue("@tel", c.TelephoneProperty);
            cmd.Parameters.AddWithValue("@adr", c.AdresseProperty);
            cmd.Parameters.AddWithValue("@pfide", c.PtsFideliteProperty);
            cmd.Parameters.AddWithValue("@idcl", c.IdClientProperty);

            cmd.ExecuteNonQuery();
            connection.Close();
        }

    }
}
