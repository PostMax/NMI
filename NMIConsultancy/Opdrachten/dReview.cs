using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMIConsultancy.Opdrachten
{
    class dReview
    {
        private int opdrachtID;
            private int klantID;
            private int cijfer;
            private DateTime datum;

        //Variabelen worden public gemaakt met behulp van de properties en in de properties kunnen de 
            public int OpdrachtID
            {
                get { return opdrachtID; }
                set { opdrachtID = value; }
            }
            public int KlantID
            {
                get { return klantID; }
                set { klantID = value; }
            }
            public int Cijfer
            {
                get { return cijfer; }
                set { cijfer = value; }
            }
            public DateTime Datum
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

            public dReview(int opdracht_ID, int klant_ID)
            {
                klantID = klant_ID;
                opdrachtID = opdracht_ID;
                cijfer = 0;
                
                
            }



            //Hierdoor worden de variabelen samengevoegd en worden de waardes omgezet naar string 
            public override string ToString()
            {
                return klantID + " " + opdrachtID +  " " + cijfer + " " + datum;
            }

        }
}
