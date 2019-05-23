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
    public class VolViewModel : INotifyPropertyChanged
    {

        public VolViewModel()
        {
            //On tente une connexion à la base de données, sinon on retourne un message d'erreur.
            try
            {
                int lastId = lastId = VolDAL.GetLastId();
                Vol Vol = new Vol(lastId, 0, 0, 0, Convert.ToDateTime("01/01/2001 00:00:01"), Convert.ToDateTime("01/01/2001 00:00:01"), Convert.ToDateTime("02/02/2001 00:00:01"), Convert.ToDateTime("02/02/2001 00:00:01"), Convert.ToDecimal(00.00), Convert.ToDecimal(00.00), Convert.ToDecimal(00.00));

            }
            catch
            {
                MessageBox.Show("Une erreur est survenue\nERREUR: Impossible de récupérer le dernier ID dans la base de données.");
            }


            try
            {
                ListeVols = new ObservableCollection<Vol>();
                VolDAL.SelectVol(ListeVols);

                ListeAvions = new ObservableCollection<Avion>();
                AvionDAL.SelectAvion(ListeAvions);

                ListeAeroportsDepart = new ObservableCollection<Aeroport>();
                AeroportDAL.SelectAeroport(ListeAeroportsDepart);

                ListeAeroportsArrivee = new ObservableCollection<Aeroport>();
                AeroportDAL.SelectAeroport(ListeAeroportsArrivee);
            }
            catch
            {
                MessageBox.Show("Une erreur est survenue\nERREUR: Impossible de récupérer la table [Vol] \nVérifiez la connexion à la base de données.");
            }



        }

        private Vol _vol;
        public Vol Vol
        {
            get { return _vol; }
            set { _vol = value; NotifyPropertyChanged("Vol"); }
        }

        private ObservableCollection<Vol> _listeVols;
        public ObservableCollection<Vol> ListeVols
        {
            get
            {
                return _listeVols;
            }
            set
            {
                _listeVols = value;
                NotifyPropertyChanged("ListeVols");
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

        private Aeroport _aeroportDepart;
        public Aeroport AeroportDepart
        {
            get { return _aeroportDepart; }
            set { _aeroportDepart = value; NotifyPropertyChanged("AeroportDepart"); }
        }

        private ObservableCollection<Aeroport> _listeAeroportsDepart;
        public ObservableCollection<Aeroport> ListeAeroportsDepart
        {
            get
            {
                return _listeAeroportsDepart;
            }
            set
            {
                _listeAeroportsDepart = value;
                NotifyPropertyChanged("ListeAeroportsDepart");
            }
        }

        private Aeroport _aeroportArrivee;
        public Aeroport AeroportArrivee
        {
            get { return _aeroportArrivee; }
            set { _aeroportArrivee = value; NotifyPropertyChanged("AeroportArrivee"); }
        }

        private ObservableCollection<Aeroport> _listeAeroportsArrivee;
        public ObservableCollection<Aeroport> ListeAeroportsArrivee
        {
            get
            {
                return _listeAeroportsArrivee;
            }
            set
            {
                _listeAeroportsArrivee = value;
                NotifyPropertyChanged("ListeAeroportsArrivee");
            }
        }

        //Propriétés pour la création d'un vol.
        #region Créer vol
        private int _newAeroportDepart;
        public int NewAeroportDepart
        {
            get { return this._newAeroportDepart; }
            set
            {
                if (this._newAeroportDepart != value)
                {
                    this._newAeroportDepart = value;
                    this.NotifyPropertyChanged("NewAeroportDepart");
                }
            }
        }

        private int _newAeroportArrivee;
        public int NewAeroportArrivee
        {
            get { return this._newAeroportArrivee; }
            set
            {
                if (this._newAeroportArrivee != value)
                {
                    this._newAeroportArrivee = value;
                    this.NotifyPropertyChanged("NewAeroportArrivee");
                }
            }
        }

        private DateTime _newDepartTheorique;
        public DateTime NewDepartTheorique
        {
            get { return this._newDepartTheorique; }
            set
            {
                if (this._newDepartTheorique != value)
                {
                    this._newDepartTheorique = value;
                    this.NotifyPropertyChanged("NewDepartTheorique");
                }
            }
        }

        private DateTime _newDepartReel;
        public DateTime NewDepartReel
        {
            get { return this._newDepartReel; }
            set
            {
                if (this._newDepartReel != value)
                {
                    this._newDepartReel = value;
                    this.NotifyPropertyChanged("NewDepartReel");
                }
                else if (this._newDepartReel == null)
                {
                    this._newDepartReel = NewDepartTheorique;
                    this.NotifyPropertyChanged("NewDepartReel");
                }

            }
        }

        private DateTime _newArriveeTheorique;
        public DateTime NewArriveeTheorique
        {
            get { return this._newArriveeTheorique; }
            set
            {
                if (this._newArriveeTheorique != value)
                {
                    this._newArriveeTheorique = value;
                    this.NotifyPropertyChanged("NewArriveeTheorique");
                }
            }
        }

        private DateTime _newArriveeReelle;
        public DateTime NewArriveeReelle
        {
            get { return this._newArriveeReelle; }
            set
            {
                if (this._newArriveeReelle != value)
                {
                    this._newArriveeReelle = value;
                    this.NotifyPropertyChanged("NewArriveeReelle");
                }
                else if (this._newArriveeReelle == null)
                {
                    this._newArriveeReelle = _newArriveeTheorique;
                    this.NotifyPropertyChanged("NewArriveeReelle");
                }

            }
        }

        private Decimal _newPrixEco;
        public Decimal NewPrixEco
        {
            get { return this._newPrixEco; }
            set
            {
                if (this._newPrixEco != value)
                {
                    this._newPrixEco = value;
                    this.NotifyPropertyChanged("NewPrixEco");
                }
            }
        }

        private Decimal _newPrixBusiness;
        public Decimal NewPrixBusiness
        {
            get { return this._newPrixBusiness; }
            set
            {
                if (this._newPrixBusiness != value)
                {
                    this._newPrixBusiness = value;
                    this.NotifyPropertyChanged("NewPrixBusiness");
                }
            }
        }

        private Decimal _newPrixPremium;
        public Decimal NewPrixPremium
        {
            get { return this._newPrixBusiness; }
            set
            {
                if (this._newPrixPremium != value)
                {
                    this._newPrixPremium = value;
                    this.NotifyPropertyChanged("NewPrixPremium");
                }
            }
        }

        private int _newAvion;
        public int NewAvion
        {
            get { return this._newAvion; }
            set
            {
                if (this._newAvion != value)
                {
                    this._newAvion = value;
                    this.NotifyPropertyChanged("NewAvion");
                }
            }
        }
        #endregion

        //Propriétés pour la sélection d'un vol.
        #region Sélection vol
        private Vol _volSelectionne;
        public Vol VolSelectionne
        {
            get { return this._volSelectionne; }
            set
            {
                if (this._volSelectionne != value)
                {
                    this._volSelectionne = value;
                    this.NotifyPropertyChanged("VolSelectionne");
                }

            }
        }
        #endregion

        //Commande pour créer le vol et l'insérer dans la base de données.
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
            VolDAL.InsertVol(NewAeroportDepart, NewAeroportArrivee, NewAvion, NewDepartTheorique, NewDepartReel, NewArriveeTheorique, NewArriveeReelle, NewPrixEco, NewPrixBusiness, NewPrixPremium);

            MessageBox.Show("Le vol a bien été crée");
        }

        //La condition pour exécuter.
        private bool CanSubmitExecute(object parameter)
        {
            if ((NewAeroportDepart == 0) || (NewAeroportArrivee == 0) || (NewAeroportDepart == NewAeroportArrivee) || (NewDepartTheorique > NewArriveeTheorique) || (NewDepartTheorique == NewArriveeTheorique) ||  string.IsNullOrEmpty(NewDepartTheorique.ToString()) || string.IsNullOrEmpty(NewArriveeTheorique.ToString()) || string.IsNullOrEmpty(NewPrixEco.ToString()) || string.IsNullOrEmpty(NewPrixBusiness.ToString()) || string.IsNullOrEmpty(NewPrixPremium.ToString()) || string.IsNullOrEmpty(NewAvion.ToString()))
            {
                return false;
            }
            else
            {
                return true;
            } 
        }
        #endregion

        //Commande pour supprimer un vol de la base de données.
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
            MessageBoxResult dialogResult = MessageBox.Show("Voulez-vous vraiment supprimer le vol " + this.VolSelectionne.IdProperty + " ?", "Confirmation de suppression", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                //Suppression du vol
                VolDAL.DeleteVol(VolSelectionne.IdProperty);
                MessageBox.Show("Le vol a bien été supprimé.");

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
                if (string.IsNullOrEmpty(this.VolSelectionne.IdProperty.ToString()) || string.IsNullOrEmpty(this.VolSelectionne.AeroportDepartProperty.ToString()) || string.IsNullOrEmpty(this.VolSelectionne.AeroportArriveeProperty.ToString()) || string.IsNullOrEmpty(this.VolSelectionne.AvionProperty.ToString()) || string.IsNullOrEmpty(this.VolSelectionne.DepartTheoriqueProperty.ToString()) || string.IsNullOrEmpty(this.VolSelectionne.DepartReelProperty.ToString()) || string.IsNullOrEmpty(this.VolSelectionne.ArriveeTheoriqueProperty.ToString()) || string.IsNullOrEmpty(this.VolSelectionne.ArriveeReelleProperty.ToString()) || string.IsNullOrEmpty(this.VolSelectionne.PrixEcoProperty.ToString()) || string.IsNullOrEmpty(this.VolSelectionne.PrixBusinessProperty.ToString()) || string.IsNullOrEmpty(this.VolSelectionne.PrixPremiumProperty.ToString()))
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
                MessageBox.Show("Pour supprimer un vol, vous devez en sélectionner un.");
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
