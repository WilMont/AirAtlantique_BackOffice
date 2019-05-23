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
    public class UtilisateurDAL
    {
        private static BDD_connexion bddConnection = new BDD_connexion();
        private static MySqlConnection connection = bddConnection.Connection;

        public static void SelectUtilisateur(ObservableCollection<Utilisateur> ObsColUtilisateur)
        {
            connection.Close();
            connection.Open();

            string query = "SELECT u.id,u.username,u.password,u.email,u.nom,u.prenom,u.date_naissance,u.pays,u.adresse,u.ville,u.code_postal,u.numero_telephone FROM utilisateur u Group BY u.id";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Utilisateur u = new Utilisateur(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetDateTime(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(11));
                ObsColUtilisateur.Add(u);
            }
            reader.Close();

            connection.Close();
        }

        public static void SelectCertainUtilisateur(ObservableCollection<Utilisateur> ObsColUtilisateur, int id)
        {
            connection.Close();
            connection.Open();

            string query = "SELECT u.id,u.username,u.password,u.email,u.nom,u.prenom,u.date_naissance,u.pays,u.adresse,u.ville,u.code_postal,u.numero_telephone FROM utilisateur u WHERE u.id = @id Group BY u.id";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Utilisateur u = new Utilisateur(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetDateTime(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(11));
                ObsColUtilisateur.Add(u);
            }
            reader.Close();

            connection.Close();
        }

        public static void UpdateUtilisateur(Utilisateur u)
        {
            connection.Open();

            string query = "UPDATE utilisateur SET username=@usern,password=@pass,email=@ema,nom=@nom,prenom=@pre,date_naissance=@daten,pays=@pay,adresse=@adr,ville=@vil,code_postal=@cp,numero_telephone=@tel WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@usern", u.NomUtilisateurProperty);
            cmd.Parameters.AddWithValue("@pass", u.MotDePasseProperty);
            cmd.Parameters.AddWithValue("@ema", u.EmailProperty);
            cmd.Parameters.AddWithValue("@nom", u.NomProperty);
            cmd.Parameters.AddWithValue("@pre", u.PrenomProperty);
            cmd.Parameters.AddWithValue("@daten", u.DateNaissanceProperty);
            cmd.Parameters.AddWithValue("@pay", u.PaysProperty);
            cmd.Parameters.AddWithValue("@adr", u.AdresseProperty);
            cmd.Parameters.AddWithValue("@vil", u.VilleProperty);
            cmd.Parameters.AddWithValue("@cp", u.CodePostalProperty);
            cmd.Parameters.AddWithValue("@tel", u.NumeroTelephoneProperty);
            cmd.Parameters.AddWithValue("@id", u.IdProperty);

            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeleteUtilisateur(int id)
        {
            connection.Open();
            string query = "DELETE FROM utilisateur WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static int GetLastId()
        {
            int lastId = new int();

            connection.Open();
            string query = "SELECT id FROM utilisateur ORDER BY id DESC limit 1";
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