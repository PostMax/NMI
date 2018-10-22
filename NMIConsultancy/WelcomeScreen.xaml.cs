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
    /// Interaction logic for WelcomeScreen.xaml
    /// </summary>
    public partial class WelcomeScreen : Window
    {
        public WelcomeScreen()
        {
            InitializeComponent();
            cbKeus.SelectedIndex = 0;
        }

        //Opent financiën form.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Financien financien = new Financien();
            financien.Show();
            welcomeScreen.Close();
        }

        //Opent medewerker form.
        private void btMedewerker_Click(object sender, RoutedEventArgs e)
        {
            dMedewerker medewerker = new dMedewerker();
            medewerker.Show();
            welcomeScreen.Close();
        }

        //Opent opdrachten form.
        private void btOpdrachten_Click(object sender, RoutedEventArgs e)
        {
            Opdrachten opdrachten = new Opdrachten();
            opdrachten.Show();
            welcomeScreen.Close();
        }
    }
}
