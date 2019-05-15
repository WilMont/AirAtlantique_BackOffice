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
using System.Windows.Shapes;

namespace AirAtlantique_Csharp.Views
{
    /// <summary>
    /// Logique d'interaction pour AjouterVolWindow.xaml
    /// </summary>
    public partial class AjouterVolWindow : Window
    {
        public AjouterVolWindow()
        {
            InitializeComponent();
        }

        private void Btn_Creer(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
