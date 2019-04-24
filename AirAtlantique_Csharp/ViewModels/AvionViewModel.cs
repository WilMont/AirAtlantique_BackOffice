using AirAtlantique_Csharp.Command;
using AirAtlantique_Csharp.Models;
using AirAtlantique_Csharp.ViewModels.Queries;
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
                MessageBox.Show("Une erreur est survenue\nERREUR: Impossible de se connecter à la base de données, vérifiez les informations.");
            }
            

           
        }

        private Avion _avion;

        public Avion Avion
        {
            get { return _avion; }
            set { _avion = value; NotifyPropertyChanged("Avion"); }
        }

        private ObservableCollection<Avion> _ListeAvions;
        public ObservableCollection<Avion> ListeAvions
        {
            get
            {
                return _ListeAvions;
            }
            set
            {
                _ListeAvions = value;
                NotifyPropertyChanged("ListeAvions");
            }
        }

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

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                AvionDAL.UpdateAvion(Avion);
            }
        }

    }
}
