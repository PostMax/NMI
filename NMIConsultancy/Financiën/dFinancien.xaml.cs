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
    /// Interaction logic for Financien.xaml
    /// </summary>
    public partial class Financien : Window
    {
        public Financien()
        {
            InitializeComponent();
            cbKeus.SelectedIndex = 0;
            Financiën.mDatabaseConnectie database = new Financiën.mDatabaseConnectie();
            Financiën.Afdeling afdeling = new Financiën.Afdeling();
            Financiën.Persoon persoon = new Financiën.Persoon();
            afdeling.FillComboboxAfdeling(database.FillAfdeling(), cbAfdeling);
            persoon.FillListboxPersonen(database.FillPersoon(), lbPersoneel);
        }

        //Voor toevoegen van soort financiën. (Inkomst en uitgave)
        private void BtInkomst_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtUitgave_Click(object sender, RoutedEventArgs e)
        {

        }


        //Populate combobox:
        //https://stackoverflow.com/questions/20344378/populate-combobox-from-a-list



        //Algemeen deel dat zorgt voor navigatie binnen de applicatie.
        //Opent medewerker form.
        private void btMedewerker_Click(object sender, RoutedEventArgs e)
        {
            dMedewerker medewerker = new dMedewerker();
            medewerker.Show();
            this.Close();
        }
        //Opent opdrachten form.
        private void btOpdrachten_Click(object sender, RoutedEventArgs e)
        {
            dOpdrachten opdrachten = new dOpdrachten();
            opdrachten.Show();
            this.Close();
        }
        //Opent thuisscherm.
        private void btWelcomeScreen_Click(object sender, RoutedEventArgs e)
        {
            WelcomeScreen welcomeScreen = new WelcomeScreen();
            welcomeScreen.Show();
            this.Close();
        }



    }
}
