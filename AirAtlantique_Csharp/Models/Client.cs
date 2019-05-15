using AirAtlantique_Csharp.ViewModels.Queries;
using System;
using System.ComponentModel;

namespace AirAtlantique_Csharp.Models
{
    public class Client : INotifyPropertyChanged
    {

        public Client(int id, string nom, string prenom, string pays, string ville, string codePostal, string telephone, string adresse)
        {
            this._idProperty = id;
            this._nomProperty = nom;
            this._prenomProperty = prenom;
            this._paysProperty = pays;
            this._villeProperty = ville;
            this._codePostalProperty = codePostal;
            this._telephoneProperty = telephone;
            this._adresseProperty = adresse;
        }

        private int _idProperty;
        public int IdProperty
        {
            get { return _idProperty; }
        }

        private string _nomProperty;
        public string NomProperty
        {
            get { return _nomProperty; }
            set { this._nomProperty = value; OnPropertyChanged("NomProperty"); }
        }

        private string _prenomProperty;
        public string PrenomProperty
        {
            get { return _prenomProperty; }
            set { this._prenomProperty = value; OnPropertyChanged("PrenomProperty"); }
        }

        private string _paysProperty;
        public string PaysProperty
        {
            get { return _paysProperty; }
            set { this._paysProperty = value; OnPropertyChanged("PaysProperty"); }
        }

        public string _villeProperty;
        public string VilleProperty
        {
            get { return _villeProperty; }
            set { this._villeProperty = value; OnPropertyChanged("VilleProperty"); }
        }

        private string _codePostalProperty;
        public string CodePostalProperty
        {
            get { return _codePostalProperty; }
            set { this._codePostalProperty = value; OnPropertyChanged("CodePostalProperty"); }
        }

        private string _telephoneProperty;
        public string TelephoneProperty
        {
            get { return _telephoneProperty; }
            set { this._telephoneProperty = value; OnPropertyChanged("TelephoneProperty"); }
        }

        private string _adresseProperty;
        public string AdresseProperty
        {
            get { return _adresseProperty; }
            set { this._adresseProperty = value; OnPropertyChanged("AdresseProperty"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                ClientDAL.UpdateClient(this);
            }
        }

    }

    
}    