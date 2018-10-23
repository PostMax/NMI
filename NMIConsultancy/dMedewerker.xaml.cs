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

namespace NMIConsultancy
{
    /// <summary>
    /// Interaction logic for dMedewerker.xaml
    /// </summary>
    public partial class dMedewerker : Window
    {
        public dMedewerker()
        {
            InitializeComponent();
            cbKeus.SelectedIndex = 0;
        }








        //Algemeen stuk om alle forms te kunnen openen.
        //Opent financien form.
        private void btFinancien_Click(object sender, RoutedEventArgs e)
        {
            Financien financien = new Financien();
            financien.Show();
            this.Close();
        }
        //Opent opdrachten form.
        private void btOpdrachten_Click(object sender, RoutedEventArgs e)
        {
            Opdrachten opdrachten = new Opdrachten();
            opdrachten.Show();
            this.Close();
        }
        //Opent welcomescreen form.
        private void btwelcomeScreen_Click(object sender, RoutedEventArgs e)
        {
            WelcomeScreen welcomeScreen = new WelcomeScreen();
            welcomeScreen.Show();
            this.Close();
        }


    }
}
