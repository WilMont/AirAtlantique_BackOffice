using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour GestionVolsView.xaml
    /// </summary>
    public partial class GestionVolsView : Page
    {
        public GestionVolsView()
        {
            InitializeComponent();
        }

        private void Btn_AjouterVol(object sender, RoutedEventArgs e)
        {
            AjouterVolWindow ajouterVolWindow = new AjouterVolWindow();
            ajouterVolWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ajouterVolWindow.Show();


        }

    }
}
