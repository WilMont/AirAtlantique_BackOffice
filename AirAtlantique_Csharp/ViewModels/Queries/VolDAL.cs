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
    public class VolDAL
    {
        private static BDD_connexion bddConnection = new BDD_connexion();
        private static MySqlConnection connection = bddConnection.Connection;

        public static void SelectVol(ObservableCollection<Vol> ObsColVol)
        {
            connection.Close();
            connection.Open();

            string query = "SELECT v.id,v.aeroport_depart_id,v.aeroport_arrivee_id,v.avion_id,v.depart_theorique,v.depart_reel,v.arrivee_theorique,v.arrivee_reelle,v.prix_eco,v.prix_business,v.prix_premium FROM vol v Group BY v.id";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Vol v = new Vol(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetDateTime(4), reader.GetDateTime(5), reader.GetDateTime(6), reader.GetDateTime(7), reader.GetDecimal(8), reader.GetDecimal(9), reader.GetDecimal(10));
                ObsColVol.Add(v);
            }
            reader.Close();

            connection.Close();
        }

        public static void SelectCertainVol(ObservableCollection<Vol> ObsColVol, int id)
        {
            connection.Close();
            connection.Open();

            string query = "SELECT v.id, v.aeroport_depart_id, v.aeroport_arrivee_id, v.avion_id, v.depart_theorique, v.depart_reel, v.arrivee_theorique, v.arrivee_reelle, v.prix_eco, v.prix_business, v.prix_premium FROM vol v Where v.id = @id Group BY v.id";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Vol v = new Vol(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetDateTime(4), reader.GetDateTime(5), reader.GetDateTime(6), reader.GetDateTime(7), reader.GetDecimal(8), reader.GetDecimal(9), reader.GetDecimal(10));
                ObsColVol.Add(v);
            }
            reader.Close();

            connection.Close();
        }

        public static void UpdateVol(Vol v)
        {
            connection.Open();

            string query = "UPDATE vol SET aeroport_depart_id=@aeDep,aeroport_arrivee_id=@aeArr,avion_id=@avi,depart_theorique=@depThe,depart_reel=@depRe,arrivee_theorique=@arrThe,arrivee_reelle=@arrRe, prix_eco=@priEco, prix_business=@priBus, prix_premium=@priPre WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@aeDep", v.AeroportDepartProperty);
            cmd.Parameters.AddWithValue("@aeArr", v.AeroportArriveeProperty);
            cmd.Parameters.AddWithValue("@avi", v.AvionProperty);
            cmd.Parameters.AddWithValue("@depThe", v.DepartTheoriqueProperty);
            cmd.Parameters.AddWithValue("@depRe", v.DepartReelProperty);
            cmd.Parameters.AddWithValue("@arrThe", v.ArriveeTheoriqueProperty);
            cmd.Parameters.AddWithValue("@arrRe", v.ArriveeReelleProperty);
            cmd.Parameters.AddWithValue("@priEco", v.PrixEcoProperty);
            cmd.Parameters.AddWithValue("@priBus", v.PrixBusinessProperty);
            cmd.Parameters.AddWithValue("@priPre", v.PrixPremiumProperty);
            cmd.Parameters.AddWithValue("@id", v.IdProperty);

            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void InsertVol(int aeroportDepart, int aeroportArrivee, int avion, DateTime departTheorique, DateTime departReel, DateTime arriveeTheorique, DateTime arriveeReelle, Decimal prixEco, Decimal prixBusiness, Decimal prixPremium)
        {
            connection.Open();
            string query = "INSERT INTO vol(aeroport_depart_id, aeroport_arrivee_id, avion_id, depart_theorique, depart_reel, arrivee_theorique, arrivee_reelle, prix_eco, prix_business, prix_premium) VALUES(@aeDep,@aeArr,@avi,@depThe,@depRe,@arrThe,@arrRe,@priEco,@priBus,@priPre)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@aeDep", aeroportDepart);
            cmd.Parameters.AddWithValue("@aeArr", aeroportArrivee);
            cmd.Parameters.AddWithValue("@avi", avion);
            cmd.Parameters.AddWithValue("@depThe", departTheorique);
            cmd.Parameters.AddWithValue("@depRe", departReel);
            cmd.Parameters.AddWithValue("@arrThe", arriveeTheorique);
            cmd.Parameters.AddWithValue("@arrRe", arriveeReelle);
            cmd.Parameters.AddWithValue("@priEco", prixEco);
            cmd.Parameters.AddWithValue("@priBus", prixBusiness);
            cmd.Parameters.AddWithValue("@priPre", prixPremium);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeleteVol(int id)
        {
            connection.Open();
            string queryBillet = "DELETE FROM billet WHERE vol_id = @id";
            MySqlCommand cmdBillet = new MySqlCommand(queryBillet, connection);
            cmdBillet.Parameters.AddWithValue("@id", id);
            cmdBillet.ExecuteNonQuery();

            string queryVol = "DELETE FROM vol WHERE id = @id";
            MySqlCommand cmdVol = new MySqlCommand(queryVol, connection);
            cmdVol.Parameters.AddWithValue("@id", id);
            cmdVol.ExecuteNonQuery();
            connection.Close();
        }

        public static int GetLastId()
        {
            int lastId = new int();

            connection.Open();
            string query = "SELECT id FROM vol ORDER BY id DESC limit 1";
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
