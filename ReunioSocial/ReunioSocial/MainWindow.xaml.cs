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
        private int num_homes;
        private int num_dones;
        private int num_cambrers;
        private int num_files = 0;
        private int num_columnes = 0;
        string[] nomsDones = { "maria","marta","anna","cristina","susana","ague","channel","noa","maite","mercedes","nuria","silvia" };
        string[] nomsHomes = { "joan", "jordi", "cristian", "eric", "david", "alex", "sergi", "martí", "xavier", "eudald", "gabri", "arnau" };
        Escenari esc;

        public MainWindow()
        {
            InitializeComponent();
            esc = new Escenari(num_files, num_columnes);
            
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

        private void btnConfigura_Click(object sender, RoutedEventArgs e)
        {
            Window configura = new ConfigEscenari(this);
            configura.ShowDialog();
        }


        private void btnInicia_Click(object sender, RoutedEventArgs e)
        {

            iniciaGraella();
            iniciaEscenari();

            grdEscenari.ColumnDefinitions.Clear();
            grdEscenari.RowDefinitions.Clear();

            grdGraella.ColumnDefinitions.Clear();
            grdGraella.RowDefinitions.Clear();
            
            ColumnDefinition colDef;
            RowDefinition rowDef;

            #region Columnes i Files
            //columnes grid Escenari
            for (int i = 0; i < num_columnes; i++)
            {
                colDef = new ColumnDefinition();
                grdEscenari.ColumnDefinitions.Add(colDef);
            }
            //files grid Escenari
            for (int i = 0; i < num_files; i++)
            {
                rowDef = new RowDefinition();
                grdEscenari.RowDefinitions.Add(rowDef);
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

            grdEscenari.ShowGridLines = true;
            grdGraella.ShowGridLines = true;
            #endregion
        }

        private void iniciaGraella()
        {
            Random r = new Random();
            int nomRandom, sexe, fila, columna;

            for(int dona = 0; dona < num_dones ; dona++)
            {
                fila = r.Next(0, num_files);
                columna = r.Next(0, num_columnes);
                nomRandom = r.Next(0,nomsDones.Count());
                sexe = r.Next(0,4);
                
                Persona p = new Dona(nomsDones[nomRandom],sexe);
                esc.posar(p);

            }
        }


        #region PROPIETATS
        public int Num_homes
        {
            get { return num_homes; }
            set { num_homes = value; }
        }
        public int Num_dones
        {
            get { return num_dones; }
            set { num_dones = value; }
        }
        public int Num_cambrers
        {
            get { return num_cambrers; }
            set { num_cambrers = value; }
        }
        public int Num_files
        {
            get { return num_files; }
            set { num_files = value; }
        }
        public int Num_columnes
        {
            get { return num_columnes; }
            set { num_columnes = value; }
        }

        #endregion
    }
}
