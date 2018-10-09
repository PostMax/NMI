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
        }
        //Opent het opdrachten form.
        private void buttonOpdrachten_Click(object sender, RoutedEventArgs e)
        {
            Opdrachten opdrachten = new Opdrachten();
            opdrachten.Show();
            welcomeScreen.Close();
        }
        //Opent het financien form.
        private void buttonFinancien_Click(object sender, RoutedEventArgs e)
        {
            Financien financien = new Financien();
            financien.Show();
            welcomeScreen.Close();
        }
        //Opent het medewerker form.
        //Test test
        private void button_Medewerker_Click(object sender, RoutedEventArgs e)
        {
            dMedewerker medewerker = new dMedewerker();
            medewerker.Show();
            welcomeScreen.Close();
        }
    }
}
