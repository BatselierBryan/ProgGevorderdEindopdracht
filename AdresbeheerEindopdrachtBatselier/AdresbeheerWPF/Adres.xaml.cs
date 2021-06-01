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
using AdresbeheerEindopdrachtBatselier.DomainLayer;

namespace AdresbeheerWPF
{
    /// <summary>
    /// Interaction logic for Adres.xaml
    /// </summary>
    public partial class Adres : Window
    {
        public DomainSQL domainsql = new();

        public Adres()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
        }

        private void Terug_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new();
            mw.Show();
            this.Close();
        }

        private void btnVoegAdresToe_Click(object sender, RoutedEventArgs e)
        {
            var gewildeAdres = CheckAanwezigheid();


            if (domainsql.BestaatAdres(gewildeAdres))
            {
                MessageBox.Show("Deze adres bestaat al reeds.", "Adres reeds in gebruik", MessageBoxButton.OK, MessageBoxImage.Information);
            } else
            {
                domainsql.VoegAdresToe(gewildeAdres);
                MaakTextboxenLeeg();
            }
        }

        private void btnAdresCheckAanwezigheid_Click(object sender, RoutedEventArgs e)
        {
            var gewildeAdres = CheckAanwezigheid();

            if (domainsql.BestaatAdres(gewildeAdres))
            {
                MessageBox.Show("Deze adres bestaat.", "Adres in gebruik", MessageBoxButton.OK, MessageBoxImage.Information);
            } else
            {
                MessageBox.Show("Deze adres bestaat niet.", "Adres niet in gebruik", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnVerwijderAdres_Click(object sender, RoutedEventArgs e)
        {
            var gewildeAdres = CheckAanwezigheid();

            if (domainsql.BestaatAdres(gewildeAdres))
            {
                MessageBox.Show("Deze adres bestaat.", "Adres in gebruik", MessageBoxButton.OK, MessageBoxImage.Information);
            } else
            {
                domainsql.VerwijderAdres(gewildeAdres.ID);
                MaakTextboxenLeeg();
            }
        }

        private void btnUpdateAdres_Click(object sender, RoutedEventArgs e)
        {
            var gewildeAdres = CheckAanwezigheid();

            if (domainsql.BestaatAdres(gewildeAdres))
            {
                MessageBox.Show("Deze adres bestaat.", "Adres in gebruik", MessageBoxButton.OK, MessageBoxImage.Information);
            } else
            {
                domainsql.UpdateAdres(gewildeAdres);
                MaakTextboxenLeeg();
            }
        }

        void MaakTextboxenLeeg()
        {
            txtAdreslocatieid.Text = null;
            txtAppnummer.Text = null;
            txtBusnummer.Text = null;
            txtHuisnummer.Text = null;
            txtHuisnummerlabel.Text = null;
            txtId.Text = null;
            txtPostcode.Text = null;
            txtStraatID.Text = null;
        }
        AdresbeheerEindopdrachtBatselier.Adres CheckAanwezigheid()
        {
            var gewildeAdres = new AdresbeheerEindopdrachtBatselier.Adres(0, 0, 0, 0, "", "", "", "", "");
            if (String.IsNullOrEmpty(txtId.Text) || String.IsNullOrEmpty(txtStraatID.Text) || String.IsNullOrEmpty(txtPostcode.Text) || String.IsNullOrEmpty(txtAdreslocatieid.Text) || String.IsNullOrEmpty(txtHuisnummerlabel.Text) || String.IsNullOrEmpty(txtHuisnummer.Text) || !int.TryParse(txtStraatID.Text, out var prsdStraatId) || !int.TryParse(txtId.Text, out var prsdId) || !int.TryParse(txtHuisnummer.Text, out var prsdHuisnummer) || !int.TryParse(txtAdreslocatieid.Text, out var prsdAdreslocatieId) || !int.TryParse(txtPostcode.Text, out var prsPostcode))
            {
                MessageBox.Show("Gelieve correcte gegevens in de textbox te steken");
                return null;
            } else
            {
                gewildeAdres = new AdresbeheerEindopdrachtBatselier.Adres(prsdId, prsdStraatId, prsdAdreslocatieId, prsPostcode, txtHuisnummer.Text, txtBusnummer.Text, txtAppnummer.Text, txtHuisnummerlabel.Text, domainsql.SelecteerStraat(prsdId).Naam);
                return gewildeAdres;
            }
        }
    }
}
