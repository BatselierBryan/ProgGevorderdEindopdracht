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

namespace AdresbeheerWPF
{
    /// <summary>
    /// Interaction logic for Straat.xaml
    /// </summary>
    public partial class Straat : Window
    {
        public Straat()
        {
            InitializeComponent();
        }

        private void Terug_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new();
            mw.Show();
            this.Close();
        }
    }
}
