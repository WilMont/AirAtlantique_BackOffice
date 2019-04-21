using AirAtlantique_Csharp.Command;
using AirAtlantique_Csharp.Models;
using AirAtlantique_Csharp.ViewModels.Queries;
using MySql.Data.MySqlClient;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows.Input;

namespace AirAtlantique_Csharp.ViewModels
{
    public class AvionViewModel : INotifyPropertyChanged
    {

        public AvionViewModel()
        {
            int lastId = lastId = AvionDAL.GetLastId();
            Avion Avion = new Avion(lastId, null, null, 0, 0, 0, 0);

            ListeAvions = new ObservableCollection<Avion>();
            AvionDAL.SelectAvion(ListeAvions);

           
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

        /*private ICommand _SubmitCommand;

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
            //ListeAvions.Add(Avion);

        }

        private bool CanSubmitExecute(object parameter)
        {
            if (string.IsNullOrEmpty(Avion.ModeleProperty) || string.IsNullOrEmpty(Avion.MotorisationProperty) || string.IsNullOrEmpty(Avion.NbPlacesPremiumProperty.ToString()) || string.IsNullOrEmpty(Avion.NbPlacesBusinessProperty.ToString()) || string.IsNullOrEmpty(Avion.NbPlacesEcoProperty.ToString()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }*/

        #region Créer avion


        private ICommand _testCommand;

        public ICommand TestCommand
        {
            get
            {
                if (_testCommand == null)
                {
                    _testCommand = new RelayCommand(TestExecute, CanTestExecute, false);
                }
                return _testCommand;
            }
        }



        private void TestExecute(object parameter)
        {
            AvionDAL.InsertAvion(Avion.ModeleProperty, Avion.MotorisationProperty, Avion.CapaciteProperty,Avion.NbPlacesPremiumProperty, Avion.NbPlacesBusinessProperty, Avion.NbPlacesEcoProperty);

        }

        private bool CanTestExecute(object parameter)
        {
            if (string.IsNullOrEmpty(Avion.ModeleProperty) || string.IsNullOrEmpty(Avion.MotorisationProperty) || string.IsNullOrEmpty(Avion.NbPlacesPremiumProperty.ToString()) || string.IsNullOrEmpty(Avion.NbPlacesBusinessProperty.ToString()) || string.IsNullOrEmpty(Avion.NbPlacesEcoProperty.ToString()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
