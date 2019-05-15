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
    public class AvionViewModel : INotifyPropertyChanged
    {

        public AvionViewModel()
        {
            try
            {
                int lastId = lastId = AvionDAL.GetLastId();
                Avion Avion = new Avion(lastId, null, null, 0, 0, 0, 0);
            }
            catch
            {
                MessageBox.Show("Une erreur est survenue\nERREUR: Impossible de récupérer le dernier ID dans la base de données.");
            }
            

            try
            {
                ListeAvions = new ObservableCollection<Avion>();
                AvionDAL.SelectAvion(ListeAvions);
            }
            catch
            {
                MessageBox.Show("Une erreur est survenue\nERREUR: Impossible de récupérer la table [Avion] \nVérifiez la connexion à la base de données.");
            }
            

           
        }

        private Avion _avion;

        public Avion Avion
        {
            get { return _avion; }
            set { _avion = value; NotifyPropertyChanged("Avion"); }
        }

        private ObservableCollection<Avion> _listeAvions;
        public ObservableCollection<Avion> ListeAvions
        {
            get
            {
                return _listeAvions;
            }
            set
            {
                _listeAvions = value;
                NotifyPropertyChanged("ListeAvions");
            }
        }

        //Propriétés pour la création d'un avion.
        #region Créer avion
        private string _newModele;
        public string NewModele
        {
            get { return this._newModele; }
            set
            {
                if (this._newModele != value)
                {
                    this._newModele = value;
                    this.NotifyPropertyChanged("NewModele");
                }
            }
        }

        private string _newMotorisation;
        public string NewMotorisation
        {
            get { return this._newMotorisation; }
            set
            {
                if (this._newMotorisation != value)
                {
                    this._newMotorisation = value;
                    this.NotifyPropertyChanged("NewMotorisation");
                }
            }
        }

        private int _newCapacite;
        public int NewCapacite
        {
            get { return this._newCapacite; }
            set
            {
                if (this._newCapacite != value)
                {
                    this._newCapacite = value;
                    this.NotifyPropertyChanged("NewCapacite");
                }
            }
        }

        private int _newNbPlacesPremium;
        public int NewNbPlacesPremium
        {
            get { return this._newNbPlacesPremium; }
            set
            {
                if (this._newNbPlacesPremium != value)
                {
                    this._newNbPlacesPremium = value;
                    this.NotifyPropertyChanged("NewNbPlacesPremium");
                }
            }
        }

        private int _newNbPlacesBusiness;
        public int NewNbPlacesBusiness
        {
            get { return this._newNbPlacesBusiness; }
            set
            {
                if (this._newNbPlacesBusiness != value)
                {
                    this._newNbPlacesBusiness = value;
                    this.NotifyPropertyChanged("NewNbPlacesBusiness");
                }
            }
        }

        private int _newNbPlacesEco;
        public int NewNbPlacesEco
        {
            get { return this._newNbPlacesEco; }
            set
            {
                if (this._newNbPlacesEco != value)
                {
                    this._newNbPlacesEco = value;
                    this.NotifyPropertyChanged("NewNbPlacesEco");
                }
            }
        }
        #endregion

        //Propriétés pour la sélection d'un avion.
        #region Sélection avion
        private Avion _avionSelectionne;
        public Avion AvionSelectionne
        {
            get { return this._avionSelectionne; }
            set {
                if(this._avionSelectionne != value)
                {
                    this._avionSelectionne = value;
                    this.NotifyPropertyChanged("AvionSelectionne");
                }
                
            }
        }
        #endregion

        //Commande pour créer un avion et l'insérer dans la base de données.
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



        private void SubmitExecute(object parameter)
        {
            AvionDAL.InsertAvion(NewModele, NewMotorisation, NewCapacite, NewNbPlacesPremium, NewNbPlacesBusiness, NewNbPlacesEco);

            NewModele = null;
            NewMotorisation = null;
            NewCapacite = 0;
            NewNbPlacesPremium = 0;
            NewNbPlacesBusiness = 0;
            NewNbPlacesEco = 0;

            MessageBox.Show("L'avion a bien été crée");
        }

        private bool CanSubmitExecute(object parameter)
        {
            if (string.IsNullOrEmpty(NewModele) || string.IsNullOrEmpty(NewMotorisation) || string.IsNullOrEmpty(NewCapacite.ToString()) || string.IsNullOrEmpty(NewNbPlacesPremium.ToString()) || string.IsNullOrEmpty(NewNbPlacesBusiness.ToString()) || string.IsNullOrEmpty(NewNbPlacesEco.ToString()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        //Commande pour supprimer un avion de la base de données.
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



        private void DeleteExecute(object parameter)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Voulez-vous vraiment supprimer l'avion " + this.AvionSelectionne.IdProperty + " ?", "Confirmation de suppression", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                //Suppression de l'avion
                AvionDAL.DeleteAvion(AvionSelectionne.IdProperty);
            }
            else if (dialogResult == MessageBoxResult.No)
            {
                
            }

            
            
            
        }

        private bool CanDeleteExecute(object parameter)
        {
            if (string.IsNullOrEmpty(this.AvionSelectionne.IdProperty.ToString()) || string.IsNullOrEmpty(this.AvionSelectionne.MotorisationProperty) || string.IsNullOrEmpty(this.AvionSelectionne.CapaciteProperty.ToString()) || string.IsNullOrEmpty(this.AvionSelectionne.NbPlacesPremiumProperty.ToString()) || string.IsNullOrEmpty(this.AvionSelectionne.NbPlacesBusinessProperty.ToString()) || string.IsNullOrEmpty(this.AvionSelectionne.NbPlacesEcoProperty.ToString()))
            {
                return false;
            }
            else
            {
                return true;
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
