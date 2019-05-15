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
            try
            {
                int lastId = lastId = VolDAL.GetLastId();
                Vol vol = new Vol(lastId, 0, 0, 0, Convert.ToDateTime("01/01/2000 00:00:01"), Convert.ToDateTime("01/01/2000 00:00:01"), Convert.ToDateTime("01/01/2000 00:00:01"), Convert.ToDateTime("01/01/2000 00:00:01"), Convert.ToDecimal(0.00), Convert.ToDecimal(0.00), Convert.ToDecimal(0.00));
            }
            catch
            {
                MessageBox.Show("Une erreur est survenue\nERREUR: Impossible de récupérer le dernier ID dans la base de données.");
            }


            try
            {
                ListeVols = new ObservableCollection<Vol>();
                VolDAL.SelectVol(ListeVols);
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
        public int NewNewAeroportArrivee
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



        private void SubmitExecute(object parameter)
        {
            VolDAL.InsertVol(NewAeroportDepart, NewNewAeroportArrivee, NewAvion, NewDepartTheorique, NewDepartReel, NewArriveeTheorique, NewArriveeReelle, NewPrixEco, NewPrixBusiness, NewPrixPremium);

            

            MessageBox.Show("Le vol a bien été crée");
        }

        private bool CanSubmitExecute(object parameter)
        {
            if ((NewAeroportDepart == 0) || (NewNewAeroportArrivee == 0) || string.IsNullOrEmpty(NewDepartTheorique.ToString()) || string.IsNullOrEmpty(NewArriveeTheorique.ToString()) || string.IsNullOrEmpty(NewPrixEco.ToString()) || string.IsNullOrEmpty(NewPrixBusiness.ToString()) || string.IsNullOrEmpty(NewPrixPremium.ToString()))
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



        private void DeleteExecute(object parameter)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Voulez-vous vraiment supprimer le vol " + this.VolSelectionne.IdProperty + " ?", "Confirmation de suppression", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                //Suppression du vol
                VolDAL.DeleteVol(VolSelectionne.IdProperty);
            }
            else if (dialogResult == MessageBoxResult.No)
            {

            }




        }

        private bool CanDeleteExecute(object parameter)
        {
            if ((NewAeroportDepart == 0) || (NewNewAeroportArrivee == 0) || string.IsNullOrEmpty(NewDepartTheorique.ToString()) || string.IsNullOrEmpty(NewArriveeTheorique.ToString()) || string.IsNullOrEmpty(NewPrixEco.ToString()) || string.IsNullOrEmpty(NewPrixBusiness.ToString()) || string.IsNullOrEmpty(NewPrixPremium.ToString()))
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
