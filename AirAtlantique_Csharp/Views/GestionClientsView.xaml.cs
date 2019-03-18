using AirAtlantique_Csharp.Models;
using AirAtlantique_Csharp.Models.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirAtlantique_Csharp.Views
{
    /// <summary>
    /// Logique d'interaction pour GestionClientsView.xaml
    /// </summary>
    public partial class GestionClientsView : Page
    {

        private ClientDAL CDAL = new ClientDAL();
        private ObservableCollection<Client> OCClient = new ObservableCollection<Client>();

        public GestionClientsView()
        {
            InitializeComponent();
            CDAL.SelectClients(OCClient);
            listeClients.ItemsSource = OCClient;
        }
    }
}
