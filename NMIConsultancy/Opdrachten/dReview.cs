using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMIConsultancy.Opdrachten
{
    class dReview
    {
            private string klantID;
            private int cijfer;
            private string datum;

            //Variabelen worden public gemaakt met behulp van de properties en in de properties kunnen de 
            public string KlantID
            {
                get { return KlantID; }
                set { klantID = value; }
            }
            public int Cijfer
            {
                get { return cijfer; }
                set { cijfer = value; }
            }
            public string Datum
            {
                get { return datum; }
                set { datum = value; }
            }

            /*public Klant(int klantnr, string naam1, string achternaam1)
            {
                klantId = klantnr;
                naam = naam1;
                achternaam = achternaam1;

            }*/

            public dReview()
            {
                klantID = "";
                cijfer = 0;
                datum = "";
            }



            //Hierdoor worden de variabelen samengevoegd en worden de waardes omgezet naar string 
            public override string ToString()
            {
                return klantID + " " + cijfer + " " + datum;
            }

        }
}
