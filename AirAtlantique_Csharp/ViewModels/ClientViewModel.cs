using AirAtlantique_Csharp.Command;
using AirAtlantique_Csharp.Models;
using AirAtlantique_Csharp.ViewModels.Queries;
using AirAtlantique_Csharp.Views;
using MySql.Data.MySqlClient;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace AirAtlantique_Csharp.ViewModels
{
    public class ClientViewModel : INotifyPropertyChanged
    {

        public ClientViewModel()
        {
            try
            {
                int lastId = lastId = ClientDAL.GetLastId();
                Client Client = new Client(lastId, null, null, null, null, null, null, null);
            }
            catch
            {
                MessageBox.Show("Une erreur est survenue\nERREUR: Impossible de récupérer le dernier ID dans la base de données.");
            }


            try
            {
                ListeClients = new ObservableCollection<Client>();
                ClientDAL.SelectClient(ListeClients);
            }
            catch
            {
                MessageBox.Show("Une erreur est survenue\nERREUR: Impossible de récupérer la table [Client] \nVérifiez la connexion à la base de données.");
            }



        }

        private Client _client;

        public Client Client
        {
            get { return _client; }
            set { _client = value; NotifyPropertyChanged("Client"); }
        }

        private ObservableCollection<Client> _listeClients;
        public ObservableCollection<Client> ListeClients
        {
            get
            {
                return _listeClients;
            }
            set
            {
                _listeClients = value;
                NotifyPropertyChanged("ListeClients");
            }
        }

        

        //Propriétés pour la sélection d'un client.
        #region Sélection client
        private Client _clientSelectionne;
        public Client ClientSelectionne
        {
            get { return this._clientSelectionne; }
            set
            {
                if (this._clientSelectionne != value)
                {
                    this._clientSelectionne = value;
                    this.NotifyPropertyChanged("ClientSelectionne");
                }

            }
        }
        #endregion

        

        //Commande pour supprimer un client de la base de données.
        /*#region DeleteCommand
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



        private void DeleteExecute(object parameter)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Voulez-vous vraiment supprimer le client " + this.ClientSelectionne.IdProperty + " ?", "Confirmation de suppression", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                //Suppression du client
                ClientDAL.DeleteClient(ClientSelectionne.IdProperty);
            }
            else if (dialogResult == MessageBoxResult.No)
            {

            }




        }

        private bool CanDeleteExecute(object parameter)
        {
            if (string.IsNullOrEmpty(this.ClientSelectionne.IdProperty.ToString()) || string.IsNullOrEmpty(this.ClientSelectionne.MotorisationProperty) || string.IsNullOrEmpty(this.AvionSelectionne.CapaciteProperty.ToString()) || string.IsNullOrEmpty(this.AvionSelectionne.NbPlacesPremiumProperty.ToString()) || string.IsNullOrEmpty(this.AvionSelectionne.NbPlacesBusinessProperty.ToString()) || string.IsNullOrEmpty(this.AvionSelectionne.NbPlacesEcoProperty.ToString()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion */

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
