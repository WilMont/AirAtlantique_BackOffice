using AirAtlantique_Csharp.ViewModels.Queries;
using System;
using System.ComponentModel;

namespace AirAtlantique_Csharp.Models
{
    public class Client : INotifyPropertyChanged
    {
        private int id;
        private string nom;
        private string prenom;
        private string pays;
        private string ville;
        private string codePostal;
        private string telephone;
        private string adresse;

        public Client() { }

        public Client(int id, string nom, string prenom, string pays, string ville, string codePostal, string telephone, string adresse)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.pays = pays;
            this.ville = ville;
            this.codePostal = codePostal;
            this.telephone = telephone;
            this.adresse = adresse;
        }

        public int IdProperty
        {
            get { return id; }
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