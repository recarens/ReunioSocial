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
using ClassesParty;
namespace ReunioSocial
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Escenari esc;
        public MainWindow()
        {
            InitializeComponent();
            esc = new Escenari(10,10);
            grdEscencari.ShowGridLines = true;
            grdGraella.ShowGridLines = true;
            ColumnDefinition colDef;
            RowDefinition rowDef;

            #region Columnes i Files
            //columnes grid Escenari
            for(int i = 0; i < esc.Columnes; i++)
            {
                colDef = new ColumnDefinition();
                grdEscencari.ColumnDefinitions.Add(colDef);
            }
            //files grid Escenari
            for (int i = 0; i < esc.Files; i++)
            {
                rowDef = new RowDefinition();
                grdEscencari.RowDefinitions.Add(rowDef);
            }

            //Columna de noms
            colDef = new ColumnDefinition();
            grdGraella.ColumnDefinitions.Add(colDef);
            //columnes grid Graella
            for (int i = 0; i < esc.Tp.NumPersones; i++)
            {
                colDef = new ColumnDefinition();
                grdGraella.ColumnDefinitions.Add(colDef);
            }

            //Fila de noms
            rowDef = new RowDefinition();
            grdGraella.RowDefinitions.Add(rowDef);
            //files grid Graella
            for (int i = 0; i < esc.Tp.NumPersones; i++)
            {
                rowDef = new RowDefinition();
                grdGraella.RowDefinitions.Add(rowDef);
            }
            #endregion
        }

        /// <summary>
        /// fa un cicle d'events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCicle_Click(object sender, RoutedEventArgs e)
        {
            esc.Cicle();
            PintarEscenari();
        }

        /// <summary>
        /// pinta l'escenari
        /// </summary>
        private void PintarEscenari()
        {

        }

        private void CrearPersones()
        {
            
        }
    }
}
