using AirAtlantique_Csharp.ViewModels.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique_Csharp.Models
{
    public class Aeroport : INotifyPropertyChanged
    {

        public Aeroport(int id, string aita, string pays, string ville)
        {
            this._idProperty = id;
            this._aitaProperty = aita;
            this._paysProperty = pays;
            this._villeProperty = ville;
        }

        private int _idProperty;
        public int IdProperty
        {
            get { return _idProperty; }
        }

        private string _aitaProperty;
        public string AitaProperty
        {
            get { return _aitaProperty; }
            set { _aitaProperty = value; OnPropertyChanged("AitaProperty"); }
        }

        private string _paysProperty;
        public string PaysProperty
        {
            get { return _paysProperty; }
            set { _paysProperty = value; OnPropertyChanged("PaysProperty"); }
        }

        private string _villeProperty;
        public string VilleProperty
        {
            get { return _villeProperty; }
            set { _villeProperty = value; OnPropertyChanged("VilleProperty"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                AeroportDAL.UpdateAeroport(this);
            }
        }

    }
}