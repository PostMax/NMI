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
    /// Interaction logic for Opdrachten.xaml
    /// </summary>
    public partial class dOpdrachten : Window
    {
        public dOpdrachten()
        {
            InitializeComponent();
            cbKeus.SelectedIndex = 0;
        }





        //Algemene code om de andere forms te openen.
        //Opent financien form.
        private void btFinancien_Click(object sender, RoutedEventArgs e)
        {
            Financien financien = new Financien();
            financien.Show();
            this.Close();
        }
        //Opent medewerker form.
        private void btMedewerker_Click(object sender, RoutedEventArgs e)
        {
            dMedewerker medewerker = new dMedewerker();
            medewerker.Show();
            this.Close();
        }
        //Opent welcomescreen form.
        private void btWelcomeScreen_Click(object sender, RoutedEventArgs e)
        {
            WelcomeScreen welcomeScreen = new WelcomeScreen();
            welcomeScreen.Show();
            this.Close();
        }
    }
}
