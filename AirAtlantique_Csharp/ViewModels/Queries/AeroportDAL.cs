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
    public class AeroportDAL
    {
        private static MySqlConnection connection = BDD_connexion.GetConnection();

        public static void SelectAeroport(ObservableCollection<Aeroport> ObsColAeroport)
        {
            connection.Close();
            connection.Open();
            string query = "SELECT aero.id,aero.aita,aero.pays,aero.ville FROM aeroport aero Group BY aero.id";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Aeroport aero = new Aeroport(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                ObsColAeroport.Add(aero);
            }
            reader.Close();
            connection.Close();
        }

        public static void UpdateAeroport(Aeroport aero)
        {
            connection.Open();
            string query = "UPDATE Aeroport SET aita=\"" + aero.AitaProperty + "\",pays=\"" + aero.PaysProperty + "\",ville=\"" + aero.VilleProperty + "\" WHERE id=" + aero.IdProperty + "";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void InsertAeroport(string aita, string pays, string ville)
        {
            connection.Open();
            string query = "INSERT INTO aeroport(aita, pays, ville) VALUES(@aita,@pays,@ville)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@aita", aita);
            cmd.Parameters.AddWithValue("@pays", pays);
            cmd.Parameters.AddWithValue("@ville", ville);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeleteAeroport(int id)
        {
            connection.Open();
            string query = "DELETE FROM Aeroport WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static int GetLastId()
        {
            int lastId = new int();

            connection.Open();
            string query = "SELECT id FROM Aeroport ORDER BY id DESC limit 1";
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
