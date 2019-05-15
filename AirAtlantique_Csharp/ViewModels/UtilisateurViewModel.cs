using AirAtlantique_Csharp.Models;
using AirAtlantique_Csharp.ViewModels.Queries;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AirAtlantique_Csharp.ViewModels
{
    public class UtilisateurViewModel : INotifyPropertyChanged
    {

        public UtilisateurViewModel()
        {
            try
            {
                int lastId = lastId = UtilisateurDAL.GetLastId();
            }
            catch
            {
                MessageBox.Show("Une erreur est survenue\nERREUR: Impossible de récupérer le dernier ID dans la base de données.");
            }


            try
            {
                ListeUtilisateurs = new ObservableCollection<Utilisateur>();
                UtilisateurDAL.SelectUtilisateur(ListeUtilisateurs);
            }
            catch
            {
                MessageBox.Show("Une erreur est survenue\nERREUR: Impossible de récupérer la table [Utilisateur] \nVérifiez la connexion à la base de données.");
            }



        }

        private Utilisateur _utilisateur;

        public Utilisateur Utilisateur
        {
            get { return _utilisateur; }
            set { _utilisateur = value; NotifyPropertyChanged("Utilisateur"); }
        }

        private ObservableCollection<Utilisateur> _listeUtilisateurs;
        public ObservableCollection<Utilisateur> ListeUtilisateurs
        {
            get
            {
                return _listeUtilisateurs;
            }
            set
            {
                _listeUtilisateurs = value;
                NotifyPropertyChanged("ListeUtilisateurs");
            }
        }


        //Propriétés pour la sélection d'un utilisateur.
        #region Sélection utilisateur
        private Utilisateur _utilisateurSelectionne;
        public Utilisateur UtilisateurSelectionne
        {
            get { return this._utilisateurSelectionne; }
            set
            {
                if (this._utilisateurSelectionne != value)
                {
                    this._utilisateurSelectionne = value;
                    this.NotifyPropertyChanged("UtilisateurSelectionne");
                }

            }
        }
        #endregion


        //Implémentation de l'interface INotifyPropertyChanged.
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}