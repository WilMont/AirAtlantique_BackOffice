using AirAtlantique_Csharp.ViewModels.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique_Csharp.Models
{
    public class Vol : INotifyPropertyChanged
    {

        public Vol(int id, int aeroportDepart, int aeroportArrivee, int avion, DateTime departTheorique, DateTime departReel, DateTime arriveeTheorique, DateTime arriveeReelle, Decimal prixEco, Decimal prixBusiness, Decimal prixPremium)
        {
            this._idProperty = id;
            this._aeroportDepartProperty = aeroportDepart;
            this._aeroportArriveeProperty = aeroportArrivee;
            this._avionProperty = avion;
            this._departTheoriqueProperty = departTheorique;
            this._departReelProperty = departReel;
            this._arriveeTheoriqueProperty = arriveeTheorique;
            this._arriveeReelleProperty = arriveeReelle;
            this._prixEcoProperty = prixEco;
            this._prixBusinessProperty = prixBusiness;
            this._prixPremiumProperty = prixPremium;
        }

        private int _idProperty;
        public int IdProperty
        {
            get { return _idProperty; }
        }

        private int _aeroportDepartProperty;
        public int AeroportDepartProperty
        {
            get { return _aeroportDepartProperty; }
            set { _aeroportDepartProperty = value; OnPropertyChanged("AeroportDepartProperty"); }
        }

        private int _aeroportArriveeProperty;
        public int AeroportArriveeProperty
        {
            get { return _aeroportArriveeProperty; }
            set { _aeroportArriveeProperty = value; OnPropertyChanged("AeroportArriveeProperty"); }
        }

        private int _avionProperty;
        public int AvionProperty
        {
            get { return _avionProperty; }
            set { _avionProperty = value; OnPropertyChanged("AvionProperty"); }
        }

        private DateTime _departTheoriqueProperty;
        public DateTime DepartTheoriqueProperty
        {
            get { return _departTheoriqueProperty; }
            set { _departTheoriqueProperty = value; OnPropertyChanged("DepartTheoriqueProperty"); }
        }

        private DateTime _departReelProperty;
        public DateTime DepartReelProperty
        {
            get { return _departReelProperty; }
            set { _departReelProperty = value; OnPropertyChanged("DepartReelProperty"); }
        }

        private DateTime _arriveeTheoriqueProperty;
        public DateTime ArriveeTheoriqueProperty
        {
            get { return _arriveeTheoriqueProperty; }
            set { _arriveeTheoriqueProperty = value; OnPropertyChanged("ArriveeTheoriqueProperty"); }
        }

        private DateTime _arriveeReelleProperty;
        public DateTime ArriveeReelleProperty
        {
            get { return _arriveeTheoriqueProperty; }
            set { _arriveeTheoriqueProperty = value; OnPropertyChanged("ArriveeReelleProperty"); }
        }

        private Decimal _prixEcoProperty;
        public Decimal PrixEcoProperty
        {
            get { return _prixEcoProperty; }
            set { _prixEcoProperty = value; OnPropertyChanged("PrixEcoProperty"); }
        }

        private Decimal _prixBusinessProperty;
        public Decimal PrixBusinessProperty
        {
            get { return _prixBusinessProperty; }
            set { _prixBusinessProperty = value; OnPropertyChanged("PrixBusinessProperty"); }
        }

        private Decimal _prixPremiumProperty;
        public Decimal PrixPremiumProperty
        {
            get { return _prixPremiumProperty; }
            set { _prixPremiumProperty = value; OnPropertyChanged("PrixPremiumProperty"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                VolDAL.UpdateVol(this);
            }
        }

    }
}
