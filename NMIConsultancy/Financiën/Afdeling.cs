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
    class Afdeling
    {
        private string afdelingsnaam;
        private int medewerkerID;

        public Afdeling(string afdelingsnaam, int medewerkerID)
        {
            this.afdelingsnaam = afdelingsnaam;
            this.medewerkerID = medewerkerID;
        }

        public Afdeling(string afdelingsnaam)
        {
            this.afdelingsnaam = afdelingsnaam;
        }

        public Afdeling()
        {
            return;
        }

        public string GetAfdeling()
        {
            return this.afdelingsnaam;
        }

        public int GetMedewerkerID()
        {
            return this.medewerkerID;
        }

        //Voeg Afdelingen toe aan combobox
        public void FillComboboxAfdeling(List<Afdeling> afdeling, ComboBox comboBox)
        {
            foreach (Afdeling afdelingsnaam in afdeling)
            {
                comboBox.Items.Add(afdelingsnaam.afdelingsnaam);
            }
        }
    }
}
