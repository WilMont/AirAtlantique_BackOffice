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

        //Requête SQL pour sélectionner tous les utilisateurs dans la base de données.
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

        //Requête SQL pour mettre à jour un utilisateur dans la base de données.
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

        //Requête SQL pour supprimer un utilisateur de la base de données (Si des billets sont au nom de l'utilisateur on les supprime aussi).
        public static void DeleteUtilisateur(int id)
        {
            connection.Open();
            string queryBillet = "DELETE FROM billet WHERE utilisateur_id = @id";
            MySqlCommand cmdBillet = new MySqlCommand(queryBillet, connection);
            cmdBillet.Parameters.AddWithValue("@id", id);
            cmdBillet.ExecuteNonQuery();

            string queryUtilisateur = "DELETE FROM utilisateur WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(queryUtilisateur, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        //Requête SQL pour récuperer l'id du dernier utilisateur dans la base de données.
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