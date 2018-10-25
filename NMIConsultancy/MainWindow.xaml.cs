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
using System.Data.SqlClient;

namespace NMIConsultancy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Aparte methode om de connectionstring op te halen.
        private static string GetConnectionString()
        {
            return "Data Source=mssql.fhict.local;Initial Catalog=dbi403800_nmi;Persist Security Info=True;User ID=dbi403800_nmi;Password=nmi";
        }
        string connectionString = GetConnectionString();

        //Houdt bij hoevaak er een foute inlog is geweest / hoeveel pogingen er nog over zijn met startwaarden.
        int foutief = 0;
        int poging = 3;

        //Login button
        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection();
                //Deze ff aanpassen naar eigen datasource / gezamenlijke server. :D
                connection.ConnectionString = connectionString;
                SqlCommand loginquery = new SqlCommand("select count(*) from medewerker where email=@gebruikersnaam and wachtwoord=@wachtwoord", connection);
                loginquery.Parameters.Clear();
                loginquery.Parameters.AddWithValue("@gebruikersnaam", textboxGebruikersnaam.Text);
                loginquery.Parameters.AddWithValue("@wachtwoord", textboxWachtwoord.Password.ToString());
                connection.Open();

                //Als het maximum van 3 inlogpogingen is bereikt, dan kan de gebruiker niet meer inloggen.
                if (foutief == 3)
                {
                    MessageBox.Show("U heeft geen pogingen meer over.", "Inloglimiet overschreden!", MessageBoxButton.OK, MessageBoxImage.Stop);
                    Loginscreen.Close();
                }
                else
                {
                    // Als er 1 overeenkomst is met de database wordt er succesvol ingelogd.
                    // Als er geen (of meer) overeenkomsten zijn, dan wordt er niet ingelogd.
                    if (loginquery.ExecuteScalar().ToString() == "1")
                    {
                        MessageBox.Show("Succesvol ingelogd!");
                        NewForm();
                        Loginscreen.Close();
                    }
                    else
                    {
                        MessageBox.Show("Gebruikersnaam en/of wachtwoord onjuist!", "Error!", MessageBoxButton.OK, MessageBoxImage.Warning);
                        Clear();
                    }
                    connection.Close();
                }
            }
            //Exceptionhandling voor als de connectie met de database niet mogelijk is. Hierdoor crashed het programma niet.
            catch(Exception exLogin)
            {
                MessageBox.Show(exLogin.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

        }

        //Open het volgende scherm.
        private void NewForm()
        {
            WelcomeScreen welcome = new WelcomeScreen();
            welcome.Show();
        }

        //Na een foute invoer worden de textboxes geleegd en kan de gebruiker direct weer typen.
        private void Clear()
        {
            textboxGebruikersnaam.Text = String.Empty;
            textboxWachtwoord.Password = String.Empty;
            textboxGebruikersnaam.Focus();
            foutief = foutief + 1;
            poging = poging - 1;
            labelPoging.Content = "Aantal pogingen over: " + Convert.ToString(poging);
        }

        //Dubbel klikken maakt de gebruiksnaam textbox leeg.
        private void textboxGebruikersnaam_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textboxGebruikersnaam.Text = String.Empty;
        }
    }
}
