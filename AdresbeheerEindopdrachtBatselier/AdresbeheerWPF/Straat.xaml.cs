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
    /// Interaction logic for Straat.xaml
    /// </summary>
    public partial class Straat : Window
    {
        public DomainSQL domainsql = new();

        public Straat()
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

        private void btnVoegStraatToe_Click(object sender, RoutedEventArgs e)
        {
            var gewildeStraat = new AdresbeheerEindopdrachtBatselier.Straat(0, 0, "");
            if (String.IsNullOrEmpty(txtId.Text) || String.IsNullOrEmpty(txtStraatnaam.Text) || String.IsNullOrEmpty(txtNiscode.Text) || !int.TryParse(txtNiscode.Text, out var prsdNIScode) || !int.TryParse(txtId.Text, out var prsdId))
            {
                MessageBox.Show("Gelieve correcte gegevens in de textbox te steken");
                return;
            } else
            {
                gewildeStraat = new AdresbeheerEindopdrachtBatselier.Straat(prsdId,prsdNIScode,txtStraatnaam.Text);
            }


            if (domainsql.BestaatStraatnaam(gewildeStraat.Naam, domainsql.SelecteerGemeente(gewildeStraat.NISCode)))
            {
                MessageBox.Show("Deze straat bestaat al reeds.", "Straatnaam reeds in gebruik", MessageBoxButton.OK, MessageBoxImage.Information);
            } else
            {
                domainsql.VoegStraatToe(gewildeStraat);
                MaakTextboxenLeeg();
            }
        }

        private void btnStraatCheckAanwezigheid_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtId.Text) || String.IsNullOrEmpty(txtStraatnaam.Text) || String.IsNullOrEmpty(txtNiscode.Text) || !int.TryParse(txtNiscode.Text, out var prsdNIScode) || !int.TryParse(txtId.Text, out var prsdId))
            {
                MessageBox.Show("Gelieve correcte gegevens in de textbox te steken");
                return;
            }

            if (domainsql.BestaatStraatnaam(txtStraatnaam.Text, domainsql.SelecteerGemeente(prsdNIScode)))
            {
                MessageBox.Show("Deze straat is aanwezig!", "Straat aanwezigheid", MessageBoxButton.OK, MessageBoxImage.Information);
            } else
            {
                MessageBox.Show("Deze straat is niet aanwezig!", "Straat aanwezigheid", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnVerwijderStraat_Click(object sender, RoutedEventArgs e)
        {
            var gewildeStraat = new AdresbeheerEindopdrachtBatselier.Straat(0, 0, "");
            if (String.IsNullOrEmpty(txtId.Text) || String.IsNullOrEmpty(txtStraatnaam.Text) || String.IsNullOrEmpty(txtNiscode.Text) || !int.TryParse(txtNiscode.Text, out var prsdNIScode) || !int.TryParse(txtId.Text, out var prsdId))
            {
                MessageBox.Show("Gelieve correcte gegevens in de textbox te steken");
                return;
            } else
            {
                gewildeStraat = new AdresbeheerEindopdrachtBatselier.Straat(prsdId, prsdNIScode, txtStraatnaam.Text);
            }

            if (!domainsql.BestaatStraatnaam(gewildeStraat.Naam, domainsql.SelecteerGemeente(gewildeStraat.NISCode)))
            {
                MessageBox.Show("Deze straat bestaat niet.", "Straatnaam reeds in gebruik", MessageBoxButton.OK, MessageBoxImage.Information);
            } else
            {
                domainsql.VerwijderStraat(gewildeStraat.ID);
                MaakTextboxenLeeg();
            }
        }

        private void btnUpdateStraat_Click(object sender, RoutedEventArgs e)
        {
            var gewildeStraat = new AdresbeheerEindopdrachtBatselier.Straat(0, 0, "");
            if (String.IsNullOrEmpty(txtId.Text) || String.IsNullOrEmpty(txtStraatnaam.Text) || String.IsNullOrEmpty(txtNiscode.Text) || !int.TryParse(txtNiscode.Text, out var prsdNIScode) || !int.TryParse(txtId.Text, out var prsdId))
            {
                MessageBox.Show("Gelieve correcte gegevens in de textbox te steken");
                return;
            } else
            {
                gewildeStraat = new AdresbeheerEindopdrachtBatselier.Straat(prsdId, prsdNIScode, txtStraatnaam.Text);
            }
            domainsql.UpdateStraat(gewildeStraat);
            MaakTextboxenLeeg();
        }

        void MaakTextboxenLeeg()
        {
            txtId.Text = null;
            txtNiscode.Text = null;
            txtStraatnaam.Text = null;
        }
    }
}
