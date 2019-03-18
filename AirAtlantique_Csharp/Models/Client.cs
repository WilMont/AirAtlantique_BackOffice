using AirAtlantique_Csharp.Models.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique_Csharp.Models
{
    class Client : INotifyPropertyChanged
    {
        private int idClient;
        private string nom;
        private string prenom;
        private string pays;
        private string ville;
        private string codePostal;
        private string telephone;
        private string adresse;
        private int ptsFidelite;
        private int idDernierVol;
        private DateTime dateDernierVol;

        public Client() { }

        public Client(int idClient, string nom, string prenom, string pays, string ville, string codePostal, string telephone, string adresse, int ptsFidelite, int idDernierVol, DateTime dateDernierVol)
        {
            this.idClient = idClient;
            this.nom = nom;
            this.prenom = prenom;
            this.pays = pays;
            this.ville = ville;
            this.codePostal = codePostal;
            this.telephone = telephone;
            this.adresse = adresse;
            this.ptsFidelite = ptsFidelite;
            this.idDernierVol = idDernierVol;
            this.dateDernierVol = dateDernierVol;
        }

        public int IdClientProperty
        {
            get { return idClient; }
        }

        public string NomProperty
        {
            get { return nom; }
            set { this.nom = value; OnPropertyChanged("NomProperty"); }
        }

        public string PrenomProperty
        {
            get { return prenom; }
            set { this.prenom = value; OnPropertyChanged("PrenomProperty"); }
        }

        public string PaysProperty
        {
            get { return pays; }
            set { this.pays = value; OnPropertyChanged("PaysProperty"); }
        }

        public string VilleProperty
        {
            get { return ville; }
            set { this.ville = value; OnPropertyChanged("VilleProperty"); }
        }

        public string CodePostalProperty
        {
            get { return codePostal; }
            set { this.codePostal = value; OnPropertyChanged("CodePostalProperty"); }
        }

        public string TelephoneProperty
        {
            get { return telephone; }
            set { this.telephone = value; OnPropertyChanged("TelephoneProperty"); }
        }

        public string AdresseProperty
        {
            get { return adresse; }
            set { this.adresse = value; OnPropertyChanged("AdresseProperty"); }
        }

        public int PtsFideliteProperty
        {
            get { return ptsFidelite; }
            set { this.ptsFidelite = value; OnPropertyChanged("PtsFideliteProperty"); }
        }

        public int IdDernierVolProperty
        {
            get { return idDernierVol; }
        }

        public DateTime DateDernierVolProperty
        {
            get { return dateDernierVol; }
            set { this.dateDernierVol = value; OnPropertyChanged("DateDernierVolProperty"); }
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