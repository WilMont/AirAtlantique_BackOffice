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
    public class AeroportViewModel : INotifyPropertyChanged
    {

        public AeroportViewModel()
        {
            //On tente une connexion à la base de données, sinon on retourne un message d'erreur.
            try
            {
                int lastId = lastId = AeroportDAL.GetLastId();
                Aeroport Aeroport = new Aeroport(lastId, null, null, null);
            }
            catch
            {
                MessageBox.Show("Une erreur est survenue\nERREUR: Impossible de récupérer le dernier ID dans la base de données.");
            }


            try
            {
                ListeAeroports = new ObservableCollection<Aeroport>();
                AeroportDAL.SelectAeroport(ListeAeroports);
            }
            catch
            {
                MessageBox.Show("Une erreur est survenue\nERREUR: Impossible de récupérer la table [Aeroport] \nVérifiez la connexion à la base de données.");
            }



        }

        private Aeroport _aeroport;

        public Aeroport Aeroport
        {
            get { return _aeroport; }
            set { _aeroport = value; NotifyPropertyChanged("Aeroport"); }
        }

        private ObservableCollection<Aeroport> _listeAeroports;
        public ObservableCollection<Aeroport> ListeAeroports
        {
            get
            {
                return _listeAeroports;
            }
            set
            {
                _listeAeroports = value;
                NotifyPropertyChanged("ListeAeroports");
            }
        }

        //Propriétés pour la création d'un aéroport.
        #region Créer aeroport
        private string _newAita;
        public string NewAita
        {
            get { return this._newAita; }
            set
            {
                if (this._newAita != value)
                {
                    this._newAita = value;
                    this.NotifyPropertyChanged("NewAita");
                }
            }
        }

        private string _newPays;
        public string NewPays
        {
            get { return this._newPays; }
            set
            {
                if (this._newPays != value)
                {
                    this._newPays = value;
                    this.NotifyPropertyChanged("NewPays");
                }
            }
        }

        private string _newVille;
        public string NewVille
        {
            get { return this._newVille; }
            set
            {
                if (this._newVille != value)
                {
                    this._newVille = value;
                    this.NotifyPropertyChanged("NewVille");
                }
            }
        }
        #endregion

        //Propriétés pour la sélection d'un aéroport.
        #region Sélection aeroport
        private Aeroport _aeroportSelectionne;
        public Aeroport AeroportSelectionne
        {
            get { return this._aeroportSelectionne; }
            set
            {
                if (this._aeroportSelectionne != value)
                {
                    this._aeroportSelectionne = value;
                    this.NotifyPropertyChanged("AeroportSelectionne");
                }

            }
        }
        #endregion

        //Commande pour créer un aéroport et l'insérer dans la base de données.
        #region SubmitCommand
        private ICommand _SubmitCommand;

        public ICommand SubmitCommand
        {
            get
            {
                if (_SubmitCommand == null)
                {
                    _SubmitCommand = new RelayCommand(SubmitExecute, CanSubmitExecute, false);
                }
                return _SubmitCommand;
            }
        }


        //Ce qui est exécuté selon si la condition est vraie ou fausse.
        private void SubmitExecute(object parameter)
        {
            AeroportDAL.InsertAeroport(NewAita, NewPays, NewVille);

            NewAita = null;
            NewPays = null;
            NewVille = null;

            MessageBox.Show("L'aéroport a bien été crée");
        }

        //La condition pour exécuter.
        private bool CanSubmitExecute(object parameter)
        {
            if (string.IsNullOrEmpty(NewAita) || (NewAita.Length != 3) || string.IsNullOrEmpty(NewPays) || string.IsNullOrEmpty(NewVille))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        //Commande pour supprimer un aéroport de la base de données.
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
            MessageBoxResult dialogResult = MessageBox.Show("Voulez-vous vraiment supprimer l'aéroport " + this.AeroportSelectionne.IdProperty + " ?", "Confirmation de suppression", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                //Suppression de l'aéroport
                AeroportDAL.DeleteAeroport(AeroportSelectionne.IdProperty);
                MessageBox.Show("L'aéroport a bien été supprimé.");

            }
            else if (dialogResult == MessageBoxResult.No)
            {

            }




        }

        //La condition pour exécuter.
        private bool CanDeleteExecute(object parameter)
        {
            try { 
            if (string.IsNullOrEmpty(this.AeroportSelectionne.IdProperty.ToString()) || string.IsNullOrEmpty(this.AeroportSelectionne.AitaProperty) || string.IsNullOrEmpty(this.AeroportSelectionne.PaysProperty) || string.IsNullOrEmpty(this.AeroportSelectionne.VilleProperty))
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
                MessageBox.Show("Pour supprimer un aéroport, vous devez en sélectionner un.");
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
