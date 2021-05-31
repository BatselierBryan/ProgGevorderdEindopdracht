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
    /// Interaction logic for Gemeente.xaml
    /// </summary>
    public partial class Gemeente : Window
    {
        public DomainSQL domainsql = new();

        public Gemeente()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
        }

        void vulCombobox()
        {
            cboGemeentes.Items.Clear();

            var gemeenten = domainsql.SelecteerGemeenten();

            foreach (var gemeente in gemeenten)
            {
                cboGemeentes.Items.Add($"{gemeente.Naam} ({gemeente.NISCode})");
            }
            txtGemeente.Text = null;
            txtNiscode.Text = null;
        }

        private void Terug_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new();
            mw.Show();
            this.Close();
        }

        //Vul combobox met alle bestaande gemeenten bij het opstarten van de window
        private void Gemeente_Loaded(object sender, RoutedEventArgs e)
        {
            vulCombobox();
        }

        private void btnGemeenteVoegToe_Click(object sender, RoutedEventArgs e)
        {
            var gewildeGemeente = new AdresbeheerEindopdrachtBatselier.Gemeente("", 0);
            if (String.IsNullOrEmpty(txtGemeente.Text) || String.IsNullOrEmpty(txtNiscode.Text) || !int.TryParse(txtNiscode.Text, out var parsedValue))
            {
                MessageBox.Show("Gelieve correcte gegevens in de textbox te steken", "Verkeerde gegevens", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            } else
            {
                gewildeGemeente = new AdresbeheerEindopdrachtBatselier.Gemeente(txtGemeente.Text, int.Parse(txtNiscode.Text));
            }


            if (domainsql.BestaatGemeente(gewildeGemeente))
            {
                MessageBox.Show("Deze gemeente bestaat al reeds. (Of de NISCODE is al reeds in gebruik door een andere gemeente)", "NISCODE reeds in gebruik", MessageBoxButton.OK, MessageBoxImage.Information);
            } else
            {
                domainsql.VoegGemeenteToe(gewildeGemeente);

                vulCombobox();
            }          
        }

        private void btnGemeenteCheckAanwezigheid_Click(object sender, RoutedEventArgs e)
        {
            var gewildeGemeente = new AdresbeheerEindopdrachtBatselier.Gemeente("", 0);
            if (String.IsNullOrEmpty(txtGemeente.Text) || String.IsNullOrEmpty(txtNiscode.Text) || !int.TryParse(txtNiscode.Text, out var parsedValue))
            {
                MessageBox.Show("Gelieve correcte gegevens in de textbox te steken");
                return;
            } else
            {
                gewildeGemeente = new AdresbeheerEindopdrachtBatselier.Gemeente(txtGemeente.Text, int.Parse(txtNiscode.Text));
            }                  

            if (domainsql.BestaatGemeente(gewildeGemeente))
            {
                MessageBox.Show("Deze gemeente is aanwezig!", "Gemeente aanwezigheid", MessageBoxButton.OK, MessageBoxImage.Information);
            } else
            {
                MessageBox.Show("Deze gemeente is niet aanwezig!", "Gemeente aanwezigheid", MessageBoxButton.OK ,MessageBoxImage.Information);
            }
        }

        private void btnGemeenteVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            var gewildeGemeente = new AdresbeheerEindopdrachtBatselier.Gemeente("", 0);
            if (String.IsNullOrEmpty(txtGemeente.Text) || String.IsNullOrEmpty(txtNiscode.Text) || !int.TryParse(txtNiscode.Text, out var parsedValue))
            {
                MessageBox.Show("Gelieve correcte gegevens in de textbox te steken");
                return;
            } else
            {
                gewildeGemeente = new AdresbeheerEindopdrachtBatselier.Gemeente(txtGemeente.Text, int.Parse(txtNiscode.Text));
            }

            domainsql.VerwijderGemeente(gewildeGemeente.NISCode);
            vulCombobox();
        }

        private void btnGemeenteUpdaten_Click(object sender, RoutedEventArgs e)
        {
            var gewildeGemeente = new AdresbeheerEindopdrachtBatselier.Gemeente("", 0);
            if (String.IsNullOrEmpty(txtGemeente.Text) || String.IsNullOrEmpty(txtNiscode.Text) || !int.TryParse(txtNiscode.Text, out var parsedValue))
            {
                MessageBox.Show("Gelieve correcte gegevens in de textbox te steken");
                return;
            } else
            {
                gewildeGemeente = new AdresbeheerEindopdrachtBatselier.Gemeente(txtGemeente.Text, int.Parse(txtNiscode.Text));
            }

            domainsql.UpdateGemeente(gewildeGemeente);
            vulCombobox();
        }
    }
}
