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
        private static MySqlConnection connection = BDD_connexion.GetConnection();

        public static void SelectVol(ObservableCollection<Vol> ObsColVol)
        {
            connection.Close();
            connection.Open();

            string query = "SELECT v.id, v.aeroportDepart, v.aeroportArrivee, v.avion, v.departTheorique, v.departReel, v.arriveeTheorique, v.arriveeReelle, v.prixEco, v.prixBusiness, v.prixPremium FROM vol v Group BY v.id";
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

            string query = "SELECT v.id, v.aeroportDepart, v.aeroportArrivee, v.avion, v.departTheorique, v.departReel, v.arriveeTheorique, v.arriveeReelle, v.prixEco, v.prixBusiness, v.prixPremium FROM vol v Where v.id = @id Group BY v.id";
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

            string query = "UPDATE vol SET aeroportDepart=@aeDep,aeroportArrivee=@aeArr,avion=@avi,departTheorique=@depThe,departReel=@depRe,arriveeTheorique=@arrThe,arriveeReelle=@arrRe, prixEco=@priEco, prixBusiness=@priBus, prixPremium=@priPre WHERE id = @id";
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
            string query = "INSERT INTO vol(aeroportDepart, aeroportArrivee, avion, departTheorique, departReel, arriveeTheorique, arriveeReelle, prixEco, prixBusiness, prixPremium) VALUES(@aeDep,@aeArr,@avi,@depThe,@depRe,@arrThe,@arrRe,@priEco,@priBus,@priPre)";
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
            string query = "DELETE FROM vol WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
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
