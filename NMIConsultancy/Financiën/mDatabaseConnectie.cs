using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace NMIConsultancy.Financiën
{
    class mDatabaseConnectie
    {
        //Connectionstring
        private static string GetConnectionString()
        {
            return "Data Source=mssql.fhict.local;Initial Catalog=dbi403800_nmi;Persist Security Info=True;User ID=dbi403800_nmi;Password=nmi";
        }
        static string connectionString = GetConnectionString();

        //Combobox vullen met Afdelingsnamen
        public List<Afdeling> FillAfdeling()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT afdelingsnaam AS Afdeling FROM [Afdeling]", connection);
            SqlDataReader afdelingsnamen = cmd.ExecuteReader();

            List<Afdeling> afdelingen = new List<Afdeling>();

            while (afdelingsnamen.Read())
            {
                string afdelingsnaam = afdelingsnamen["Afdeling"].ToString();
                Afdeling afdeling = new Afdeling(afdelingsnaam);
                afdelingen.Add(afdeling);
            }
            connection.Close();
            return afdelingen;
        }

        public List<Persoon> FillPersoon()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT naam, functie, afdelingsnaam FROM [Medewerker]", connection);
            SqlDataReader medewerkerinformatie = cmd.ExecuteReader();

            List<Persoon> personen = new List<Persoon>();

            while (medewerkerinformatie.Read())
            {
                string naam = medewerkerinformatie["naam"].ToString();
                string functie = medewerkerinformatie["functie"].ToString();
                string afdeling = medewerkerinformatie["afdelingsnaam"].ToString();
                Persoon persoon = new Persoon(naam, functie, afdeling);
                personen.Add(persoon);
            }
            connection.Close();
            return personen;
        }



        List<Afdeling> afdelingsnamen = new List<Afdeling>();

        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        //0 is assigned because there are instances where the while loop is not executed.
        //        double Meerderjarig = 0;
        //        connection.Open();
        //        SqlCommand cmd = new SqlCommand("SELECT SUM(Leeftijd) AS leeftijd, Naam FROM [Persoonlijk] GROUP BY Naam", connection);
        //        // SqlCommand cmd = new SqlCommand("SELECT  Naam FROM [Persoonlijk] ORDER BY Naam", connection);
        //        SqlDataReader meerderjarig = cmd.ExecuteReader();

        //        List<Persoon> personen = new List<Persoon>();

        //        while (meerderjarig.Read())
        //        {
        //            Meerderjarig = Convert.ToDouble(meerderjarig["Leeftijd"]);
        //            string naam = meerderjarig["Naam"].ToString();
        //            Persoon persoon = new Persoon(naam, Meerderjarig);
        //            personen.Add(persoon);
        //        }
        //        return personen;


    }
}
