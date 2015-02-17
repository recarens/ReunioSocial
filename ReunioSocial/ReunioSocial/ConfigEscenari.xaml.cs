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

namespace ReunioSocial
{
    /// <summary>
    /// Lógica de interacción para ConfigEscenari.xaml
    /// </summary>
    public partial class ConfigEscenari : Window
    {
        MainWindow m;
        public ConfigEscenari(MainWindow m)
        {
            InitializeComponent();
            this.m = m;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAcceptar_Click(object sender, RoutedEventArgs e)
        {
            m.Num_homes = (int)sldHomes.Value;
            m.Num_dones = (int)sldDones.Value;
            m.Num_cambrers = (int)sldCambrers.Value;
            m.Num_files = (int)sldFiles.Value;
            m.Num_columnes = (int)sldColumnes.Value;
        }


        private void sldCambrers_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tbnumCambrers.Text = sldCambrers.Value.ToString();
        }

        private void sldHomes_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tbnumHomes.Text = sldHomes.Value.ToString();
        }

        private void sldDones_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tbnumDones.Text = sldDones.Value.ToString();
        }

        private void sldFiles_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tbnumFiles.Text = sldFiles.Value.ToString();
        }

        private void sldColumnes_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tbnumColumnes.Text = sldColumnes.Value.ToString();
        }
    }
}
