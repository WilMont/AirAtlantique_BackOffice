using AirAtlantique_Csharp.Command;
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
using System.Windows.Input;

namespace AirAtlantique_Csharp.ViewModels
{
    public class UtilisateurViewModel : INotifyPropertyChanged
    {

        public UtilisateurViewModel()
        {
            //On tente une connexion à la base de données, sinon on retourne un message d'erreur.
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

        //Commande pour supprimer un utilisateur de la base de données.
        #region DeleteCommand
        private ICommand _DeleteCommand;

        public ICommand DeleteCommand
        {
            get
            {
                if (_DeleteCommand == null)
                {
                    _DeleteCommand = new RelayCommand(DeleteExecute, CanDeleteExecute, false);
                }
                return _DeleteCommand;
            }
        }


        //Ce qui est exécuté selon si la condition est vraie ou fausse.
        private void DeleteExecute(object parameter)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Voulez-vous vraiment supprimer l'utilisateur " + this.UtilisateurSelectionne.IdProperty + " ?", "Confirmation de suppression", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                //Suppression de l'utilisateur
                UtilisateurDAL.DeleteUtilisateur(UtilisateurSelectionne.IdProperty);
                MessageBox.Show("L'utilisateur a bien été supprimé.");

            }
            else if (dialogResult == MessageBoxResult.No)
            {

            }




        }

        //La condition pour exécuter.
        private bool CanDeleteExecute(object parameter)
        {
            try
            {
                if (string.IsNullOrEmpty(this.UtilisateurSelectionne.IdProperty.ToString()))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                MessageBox.Show("Pour supprimer un utilisateur, vous devez en sélectionner un.");
                return false;
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