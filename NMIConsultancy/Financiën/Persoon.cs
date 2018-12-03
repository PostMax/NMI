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

namespace NMIConsultancy.Financiën
{
    class Persoon
    {
        private string naam;
        private string email;
        private string functie;
        private string afdeling;

        public Persoon(string naam, string functie, string afdeling)
        {
            this.naam = naam;
            this.functie = functie;
            this.afdeling = afdeling;
        }

        public Persoon()
        {
            return;
        }

        public string getNaam()
        {
            return this.naam;
        }
        public string getEmail()
        {
            return this.email;
        }
        public string getFunctie()
        {
            return this.functie;
        }
        public string getAfdeling()
        {
            return this.afdeling;
        }

        public override string ToString()
        {
            return (naam + " -- " + functie + " -- " + afdeling);
        }

        //Voeg personen toe aan listbox.
        public void FillListboxPersonen(List<Persoon> personen, ListBox listBox)
        {
            foreach (var pers in personen)
            {
                listBox.Items.Add(pers);
            }
        }
    }
}
