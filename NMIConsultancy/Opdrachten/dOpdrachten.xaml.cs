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
using System.Data;
using System.Data.SqlClient;
using NMIConsultancy.Opdrachten;

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




        dbi403800_nmiDataSet1 dbi403800_nmiDataSet1;

        dbi403800_nmiDataSet1TableAdapters.KlantTableAdapter dbi403800_nmiDataSet1KlantTableAdapter;
        CollectionViewSource klantViewSource;

        CollectionViewSource reviewViewSource;
        NMIConsultancy.dbi403800_nmiDataSet1TableAdapters.ReviewTableAdapter dbi403800_nmiDataSet1ReviewTableAdapter;






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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            dbi403800_nmiDataSet1 = ((dbi403800_nmiDataSet1)(this.FindResource("dbi403800_nmiDataSet1")));

            dbi403800_nmiDataSet1KlantTableAdapter = new dbi403800_nmiDataSet1TableAdapters.KlantTableAdapter();
            dbi403800_nmiDataSet1KlantTableAdapter.Fill(dbi403800_nmiDataSet1.Klant);
            klantViewSource = ((CollectionViewSource)(this.FindResource("klantViewSource")));
            klantViewSource.View.MoveCurrentToFirst();

            dbi403800_nmiDataSet1ReviewTableAdapter = new dbi403800_nmiDataSet1TableAdapters.ReviewTableAdapter();
            dbi403800_nmiDataSet1ReviewTableAdapter.Fill(dbi403800_nmiDataSet1.Review);
            reviewViewSource = ((CollectionViewSource)(this.FindResource("reviewViewSource")));
            reviewViewSource.View.MoveCurrentToFirst();

            klantIDTextBox.IsReadOnly = true;

        }

        private void btInvoerKlant_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dKlant klant1 = new dKlant(tbNaam.Text);
                //klant.bedrijf = tbfdhfhfh.text


                dbi403800_nmiDataSet1TableAdapters.KlantTableAdapter qa = new dbi403800_nmiDataSet1TableAdapters.KlantTableAdapter();


                qa.spKlantInsert((int)qa.klantIDNieuw(), klant1.Naam, klant1.Email, klant1.Adres, klant1.Geslacht, klant1.Postcode, klant1.Regio, klant1.Bedrijf);
                dbi403800_nmiDataSet1KlantTableAdapter.Fill(dbi403800_nmiDataSet1.Klant);
                klantViewSource.View.MoveCurrentToFirst();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }


        }

        private void btVerwijderenKlant_Click(object sender, RoutedEventArgs e)
        {
            if (klantDataGrid.SelectedItem != null)
            {


                DataRowView dr = (DataRowView)klantViewSource.View.CurrentItem;
                dbi403800_nmiDataSet1.KlantRow delRow = (dbi403800_nmiDataSet1.KlantRow)dr.Row;

                dbi403800_nmiDataSet1TableAdapters.KlantTableAdapter qa = new dbi403800_nmiDataSet1TableAdapters.KlantTableAdapter();
                qa.DeleteKlant(delRow.klantID);
                dbi403800_nmiDataSet1KlantTableAdapter.Fill(dbi403800_nmiDataSet1.Klant);
                klantViewSource.View.MoveCurrentToFirst();

            }
            else
            {
                MessageBox.Show("Er is geen klant geselecteerd");
            }

        }

        private void btWijzigenKlant_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                dKlant klant1 = new dKlant(naamTextBox.Text);
                DataRowView dr = (DataRowView)klantViewSource.View.CurrentItem;
                dbi403800_nmiDataSet1.KlantRow delRow = (dbi403800_nmiDataSet1.KlantRow)dr.Row;

                dbi403800_nmiDataSet1TableAdapters.KlantTableAdapter qa = new dbi403800_nmiDataSet1TableAdapters.KlantTableAdapter();
                qa.spUpdateKlant(klant1.Naam, klant1.Email, klant1.Adres, klant1.Geslacht, klant1.Postcode, klant1.Regio, klant1.Bedrijf, delRow.klantID);
                dbi403800_nmiDataSet1KlantTableAdapter.Fill(dbi403800_nmiDataSet1.Klant);
                klantViewSource.View.MoveCurrentToFirst();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btFilter_Click(object sender, RoutedEventArgs e)
        {
            dbi403800_nmiDataSet1TableAdapters.KlantTableAdapter qa = new dbi403800_nmiDataSet1TableAdapters.KlantTableAdapter();
            if (tbRegioFilter.Text == "" && tbGeslachtFilter.Text == "")
            {
                dbi403800_nmiDataSet1KlantTableAdapter.Fill(dbi403800_nmiDataSet1.Klant);
                MessageBox.Show("Geen filter ingevoerd");
            }
            else if (tbGeslachtFilter.Text == "" && tbRegioFilter.Text != "")
            {

                qa.FillByregio(dbi403800_nmiDataSet1.Klant, tbRegioFilter.Text);
            }
            else if (tbGeslachtFilter.Text != "" && tbRegioFilter.Text == "")
            {

                qa.FillByGeslacht(dbi403800_nmiDataSet1.Klant, tbGeslachtFilter.Text);
            }
            else
            {

                qa.FillByGeslachtEnRegio(dbi403800_nmiDataSet1.Klant, tbRegioFilter.Text, tbGeslachtFilter.Text);
            }
        }

        private void btInvoerReview_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int opdrachtId = Convert.ToInt32(tbOpdrachtID.Text);
                int klantID = Convert.ToInt32(tbKlantReview.Text);
                dReview review1 = new dReview(opdrachtId, klantID);


                review1.Cijfer = Convert.ToInt32(tbCijfer.Text);
                //review1.Datum = Convert.ToDateTime(dpDatumReview.Text);


                dbi403800_nmiDataSet1TableAdapters.ReviewTableAdapter qa = new dbi403800_nmiDataSet1TableAdapters.ReviewTableAdapter();


                qa.spInsertReview(review1.OpdrachtID, review1.KlantID, review1.Cijfer, review1.Datum);
                dbi403800_nmiDataSet1ReviewTableAdapter.Fill(dbi403800_nmiDataSet1.Review);
                reviewViewSource.View.MoveCurrentToFirst();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }


        }

        private void btVerwijderenReview_Click(object sender, RoutedEventArgs e)
        {
            if (reviewDataGrid.SelectedItem != null)
            {

                DataRowView dr = (DataRowView)reviewViewSource.View.CurrentItem;
                dbi403800_nmiDataSet1.ReviewRow delRow = (dbi403800_nmiDataSet1.ReviewRow)dr.Row;

                dbi403800_nmiDataSet1TableAdapters.ReviewTableAdapter qa = new dbi403800_nmiDataSet1TableAdapters.ReviewTableAdapter();
                qa.spDeleteReview(delRow.opdrachtID);
                dbi403800_nmiDataSet1ReviewTableAdapter.Fill(dbi403800_nmiDataSet1.Review);
                reviewViewSource.View.MoveCurrentToFirst();
            }
            else
            {
                MessageBox.Show("Er is geen review geselecteerd");
            }
        }

        private void tbWijzigenReview_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int opdrachtId = Convert.ToInt32(opdrachtIDTextBox.Text);
                int klantID = Convert.ToInt32(klantReviewTextBox.Text);

                dReview review1 = new dReview(opdrachtId, klantID);
                review1.Cijfer = Convert.ToInt32(tbCijfer.Text);
                //review1.Datum = Convert.ToDateTime(dpDatumReview.Text);

                DataRowView dr = (DataRowView)reviewViewSource.View.CurrentItem;
                dbi403800_nmiDataSet1.ReviewRow delRow = (dbi403800_nmiDataSet1.ReviewRow)dr.Row;

                dbi403800_nmiDataSet1TableAdapters.ReviewTableAdapter qa = new dbi403800_nmiDataSet1TableAdapters.ReviewTableAdapter();

                qa.spUpdateReview(review1.OpdrachtID, review1.KlantID, review1.Cijfer, review1.Datum);
                dbi403800_nmiDataSet1ReviewTableAdapter.Fill(dbi403800_nmiDataSet1.Review);
                reviewViewSource.View.MoveCurrentToFirst();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btFilterOpdrachtID_Click(object sender, RoutedEventArgs e)
        {
            dbi403800_nmiDataSet1TableAdapters.ReviewTableAdapter qa = new dbi403800_nmiDataSet1TableAdapters.ReviewTableAdapter();


            if (tbFilterOpdrachtID.Text == "")
            {
                dbi403800_nmiDataSet1KlantTableAdapter.Fill(dbi403800_nmiDataSet1.Klant);
                MessageBox.Show("Geen filter ingevoerd");
            }
            else 
            {
                int filteropdrachtID = Convert.ToInt32(tbFilterOpdrachtID.Text);
                qa.FillByOpdrachtID(dbi403800_nmiDataSet1.Review, filteropdrachtID);
            }
        }
    }
}
