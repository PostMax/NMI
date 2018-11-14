using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMIConsultancy.Opdrachten
{
    class Klant
    {
        
            private string naam;
            private string email;
            private string adres;
            private string geslacht;
            private string postcode;
            private string regio;
            private string bedrijf;



            //Variabelen worden public gemaakt met behulp van de properties en in de properties kunnen de variabelen aangepast worden 
            public string Naam
            {
                get { return naam; }
                set { naam = value; }
            }
            public string Email
            {
                get { return email; }
                set { email = value; }
            }
            public string Adres
            {
                get { return adres; }
                set { adres = value; }
            }
            public string Geslacht
            {
                get { return geslacht; }
                set { geslacht = value; }
            }
            public string Postcode
            {
                get { return postcode; }
                set { postcode = value; }
            }
            public string Regio
            {
                get { return regio; }
                set { regio = value; }
            }
            public string Bedrijf
            {
                get { return bedrijf; }
                set { bedrijf = value; }
            }


            /*public Klant(int klantnr, string naam1, string achternaam1)
            {
                klantId = klantnr;
                naam = naam1;
                achternaam = achternaam1;

            }*/

            public Klant()
            {
                naam = "";
                email = "";
                adres = "";
                geslacht = "";
                postcode = "";
                regio = "";
                bedrijf = "";
            }

            //Hierdoor worden de variabelen samengevoegd en worden de waardes omgezet naar string 
            public override string ToString()
            {
                return naam + " " + email + " " + adres + " " + geslacht + " " + postcode + " " + regio + " " + bedrijf;
            }
        
    }
}
