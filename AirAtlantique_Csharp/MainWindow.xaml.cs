using AirAtlantique_Csharp.Views;
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

namespace AirAtlantique_Csharp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ContenuPage.Content = new AccueilView();
            BtnAccueil.Background = Brushes.Azure;
        }

        #region MENU_GAUCHE
        private void BtnAccueil_Click(object sender, RoutedEventArgs e)
        {
            ContenuPage.Content = new AccueilView();
            RAZDesCouleursBoutons();
            BtnAccueil.Background = Brushes.Azure;
        }

        private void BtnGestionDesAvions_Click(object sender, RoutedEventArgs e)
        {
            ContenuPage.Content = new GestionAvionsView();
            RAZDesCouleursBoutons();
            BtnGestionDesAvions.Background = Brushes.Azure;
        }

        private void BtnGestionDesAeroports_Click(object sender, RoutedEventArgs e)
        {
            ContenuPage.Content = new GestionAeroportsView();
            RAZDesCouleursBoutons();
            BtnGestionDesAeroports.Background = Brushes.Azure;
        }

        private void BtnGestionDesVols_Click(object sender, RoutedEventArgs e)
        {
            ContenuPage.Content = new GestionVolsView();
            RAZDesCouleursBoutons();
            BtnGestionDesVols.Background = Brushes.Azure;
        }

        private void BtnGestionDesUtilisateurs_Click(object sender, RoutedEventArgs e)
        {
            ContenuPage.Content = new GestionUtilisateursView();
            RAZDesCouleursBoutons();
            BtnGestionDesUtilisateurs.Background = Brushes.Azure;
        }
        #endregion

        #region FONCTIONS_DIVERSES

        private void RAZDesCouleursBoutons()
        {
            BtnAccueil.Background = Brushes.White;
            BtnGestionDesAvions.Background = Brushes.White;
            BtnGestionDesAeroports.Background = Brushes.White;
            BtnGestionDesVols.Background = Brushes.White;
            BtnGestionDesUtilisateurs.Background = Brushes.White;
        }

        #endregion



    }
}
