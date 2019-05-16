using AirAtlantique_Csharp.ViewModels.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique_Csharp.Models
{
    public class Utilisateur : INotifyPropertyChanged
    {

        public Utilisateur(int id, string nomUtilisateur, string motDePasse, string email, string nom, string prenom, DateTime dateNaissance, string pays, string adresse, string ville, string codePostal, string numeroTelephone)
        {
            this._idProperty = id;
            this._nomUtilisateurProperty = nomUtilisateur;
            this._motDePasseProperty = motDePasse;
            this._emailProperty = email;
            this._nomProperty = nom;
            this._prenomProperty = prenom;
            this._dateNaissanceProperty = dateNaissance;
            this._paysProperty = pays;
            this._adresseProperty = adresse;
            this._villeProperty = ville;
            this._codePostalProperty = codePostal;
            this._numeroTelephoneProperty = numeroTelephone;
        }

        private int _idProperty;
        public int IdProperty
        {
            get { return _idProperty; }
        }

        private string _nomUtilisateurProperty;
        public string NomUtilisateurProperty
        {
            get { return _nomUtilisateurProperty; }
            set { this._nomUtilisateurProperty = value; OnPropertyChanged("NomProperty"); }
        }

        private string _motDePasseProperty;
        public string MotDePasseProperty
        {
            get { return _motDePasseProperty; }
            set { this._motDePasseProperty = value; OnPropertyChanged("MotDePasseProperty"); }
        }

        private string _emailProperty;
        public string EmailProperty
        {
            get { return _emailProperty; }
            set { this._emailProperty = value; OnPropertyChanged("EmailProperty"); }
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

        private DateTime _dateNaissanceProperty;
        public DateTime DateNaissanceProperty
        {
            get { return _dateNaissanceProperty; }
            set { this._dateNaissanceProperty = value; OnPropertyChanged("DateNaissanceProperty"); }
        }

        private string _paysProperty;
        public string PaysProperty
        {
            get { return _paysProperty; }
            set { this._paysProperty = value; OnPropertyChanged("PaysProperty"); }
        }

        private string _adresseProperty;
        public string AdresseProperty
        {
            get { return _adresseProperty; }
            set { this._adresseProperty = value; OnPropertyChanged("AdresseProperty"); }
        }

        private string _villeProperty;
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

        private string _numeroTelephoneProperty;
        public string NumeroTelephoneProperty
        {
            get { return _numeroTelephoneProperty; }
            set { this._numeroTelephoneProperty = value; OnPropertyChanged("NumeroTelephoneProperty"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                UtilisateurDAL.UpdateUtilisateur(this);
            }
        }

    }


}