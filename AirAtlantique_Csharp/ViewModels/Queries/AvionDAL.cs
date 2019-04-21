using AirAtlantique_Csharp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique_Csharp.ViewModels.Queries
{
    public class AvionDAL
    {
        private static MySqlConnection connection = BDD_connexion.GetConnection();

        public static void SelectAvion(ObservableCollection<Avion> l)
        {
            connection.Close();
            connection.Open();
            string query = "SELECT a.id,a.modele,a.motorisation,a.capacite,a.nb_places_premium,a.nb_places_business,a.nb_places_eco FROM avion a Group BY a.id";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Avion a = new Avion(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6));
                l.Add(a);
            }
            reader.Close();
            connection.Close();
        }

        public static void UpdateAvion(Avion a)
        {
            connection.Open();
            string query = "UPDATE avions SET modele=\"" + a.ModeleProperty + "\",motorisation=\"" + a.MotorisationProperty + "\",capacite=\"" + a.CapaciteProperty + "\",nb_place_premium=\"" + a.NbPlacesPremiumProperty + "\",nb_place_business=\"" + a.NbPlacesBusinessProperty + "\",nb_place_eco=\"" + a.NbPlacesEcoProperty + "\" WHERE idAvion=" + a.IdProperty + "";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void InsertAvion(string mo, string moto, int capa, int prem, int busi, int eco)
        {
            connection.Open();
            string query = "INSERT INTO avion(modele, motorisation, capacite, nb_place_premium, nb_place_business, nb_place_eco) VALUES(@mo,@moto,@capa,@prem,@busi,@eco)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@mo", mo);
            cmd.Parameters.AddWithValue("@moto", moto);
            cmd.Parameters.AddWithValue("@capa", capa);
            cmd.Parameters.AddWithValue("@prem", prem);
            cmd.Parameters.AddWithValue("@busi", busi);
            cmd.Parameters.AddWithValue("@eco", eco);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeleteAvion(int id)
        {
            connection.Open();
            string query = "DELETE FROM avion WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static int GetLastId()
        {
            int lastId = new int();

            connection.Open();
            string query = "SELECT id FROM avion ORDER BY id DESC limit 1";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lastId = Convert.ToInt32(reader["id"]);
            }
            reader.Close();
            connection.Close();

            return lastId;
        }

    }
}