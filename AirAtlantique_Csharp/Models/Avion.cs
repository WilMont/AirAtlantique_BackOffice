using AirAtlantique_Csharp.ViewModels.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique_Csharp.Models
{
    public class Avion : INotifyPropertyChanged
    {

        public Avion(int id, string modele, string motorisation, int capacite, int nbPlacesPremium, int nbPlacesBusiness, int nbPlacesEco)
        {
            this._idProperty = id;
            this._modeleProperty = modele;
            this._motorisationProperty = motorisation;
            this._capaciteProperty = capacite;
            this._nbPlacesPremiumProperty = nbPlacesPremium;
            this._nbPlacesBusinessProperty = nbPlacesBusiness;
            this._nbPlacesEcoProperty = nbPlacesEco;
        }

        private int _idProperty;
        public int IdProperty
        {
            get { return _idProperty; }
        }

        private string _modeleProperty;
        public string ModeleProperty
        {
            get { return _modeleProperty; }
            set { _modeleProperty = value; OnPropertyChanged("ModeleProperty"); }
        }

        private string _motorisationProperty;
        public string MotorisationProperty
        {
            get { return _motorisationProperty; }
            set { _motorisationProperty = value; OnPropertyChanged("MotorisationProperty"); }
        }

        private int _capaciteProperty;
        public int CapaciteProperty
        {
            get { return _capaciteProperty; }
            set { _capaciteProperty = value; OnPropertyChanged("CapaciteProperty"); }
        }

        private int _nbPlacesPremiumProperty;
        public int NbPlacesPremiumProperty
        {
            get { return _nbPlacesPremiumProperty; }
            set { _nbPlacesPremiumProperty = value; OnPropertyChanged("NbPlacesPremiumProperty"); }
        }

        private int _nbPlacesBusinessProperty;
        public int NbPlacesBusinessProperty
        {
            get { return _nbPlacesBusinessProperty; }
            set { _nbPlacesBusinessProperty = value; OnPropertyChanged("NbPlacesBusinessProperty"); }
        }

        private int _nbPlacesEcoProperty;
        public int NbPlacesEcoProperty
        {
            get { return _nbPlacesEcoProperty; }
            set { _nbPlacesEcoProperty = value; OnPropertyChanged("NbPlacesEcoProperty"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                AvionDAL.UpdateAvion(this);
            }
        }

    }
}
