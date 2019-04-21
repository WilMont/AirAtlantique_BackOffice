using AirAtlantique_Csharp.Command;
using AirAtlantique_Csharp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AirAtlantique_Csharp.ViewModels
{
    public class ClientViewModel : INotifyPropertyChanged
    {

        private Client _client;

        public Client Client
        {
            get { return _client; }
            set { _client = value; NotifyPropertyChanged("Client"); }
        }

        private ObservableCollection<Client> _listeClients;
        public ObservableCollection<Client> ListeClients
        {
            get
            {
                return _listeClients;
            }
            set
            {
                _listeClients = value;
                NotifyPropertyChanged("listeClients");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
