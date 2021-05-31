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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdresbeheerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
        }

        private void Shutdown_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Gemeente_Click(object sender, RoutedEventArgs e)
        {
            Gemeente g = new();
            g.Show();
            this.Close();
        }    

        private void Straat_Click(object sender, RoutedEventArgs e)
        {
            Straat s = new();
            s.Show();
            this.Close();
        }

        private void Adres_Click(object sender, RoutedEventArgs e)
        {
            Adres a = new();
            a.Show();
            this.Close();
        }
    }
}
