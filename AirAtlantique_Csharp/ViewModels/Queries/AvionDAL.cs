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
        private static BDD_connexion bddConnection = new BDD_connexion();
        private static MySqlConnection connection = bddConnection.Connection;

        //Requête SQL pour sélectionner tous les avions dans la base de données.
        public static void SelectAvion(ObservableCollection<Avion> ObsColAvion)
        {
            connection.Close();
            connection.Open();
            string query = "SELECT a.id,a.modele,a.motorisation,a.capacite,a.nb_places_premium,a.nb_places_business,a.nb_places_eco FROM avion a Group BY a.id";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Avion a = new Avion(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6));
                ObsColAvion.Add(a);
            }
            reader.Close();
            connection.Close();
        }

        //Requête SQL pour mettre à jour un avion dans la base de données.
        public static void UpdateAvion(Avion a)
        {
            connection.Open();
            string query = "UPDATE avion SET modele=\"" + a.ModeleProperty + "\",motorisation=\"" + a.MotorisationProperty + "\",capacite=\"" + a.CapaciteProperty + "\",nb_places_premium=\"" + a.NbPlacesPremiumProperty + "\",nb_places_business=\"" + a.NbPlacesBusinessProperty + "\",nb_places_eco=\"" + a.NbPlacesEcoProperty + "\" WHERE id=" + a.IdProperty + "";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        //Requête SQL pour insérer un nouvel avion dans la base de données.
        public static void InsertAvion(string mo, string moto, int capa, int prem, int busi, int eco)
        {
            connection.Open();
            string query = "INSERT INTO avion(modele, motorisation, capacite, nb_places_premium, nb_places_business, nb_places_eco) VALUES(@mo,@moto,@capa,@prem,@busi,@eco)";
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

        //Requête SQL pour supprimer un avion dans la base de données (On supprime aussi les vols et les billets liés à l'avion).
        public static void DeleteAvion(int id)
        {
            connection.Open();
            string queryBillet = "DELETE FROM billet WHERE vol_id = (SELECT id FROM vol WHERE avion_id = @id)";
            MySqlCommand cmdBillet = new MySqlCommand(queryBillet, connection);
            cmdBillet.Parameters.AddWithValue("@id", id);
            cmdBillet.ExecuteNonQuery();

            string queryVol = "DELETE FROM vol WHERE avion_id = @id";
            MySqlCommand cmdVol = new MySqlCommand(queryVol, connection);
            cmdVol.Parameters.AddWithValue("@id", id);
            cmdVol.ExecuteNonQuery();

            string queryAvion = "DELETE FROM avion WHERE id = @id";
            MySqlCommand cmdAvion = new MySqlCommand(queryAvion, connection);
            cmdAvion.Parameters.AddWithValue("@id", id);
            cmdAvion.ExecuteNonQuery();
            connection.Close();
        }

        //Requête SQL pour récupérer l'id du dernier avion dans la base de données.
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