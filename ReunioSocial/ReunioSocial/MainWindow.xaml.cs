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

        /// <summary>
        /// crida els metodes inicia Escenari i Graella
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInicia_Click(object sender, RoutedEventArgs e)
        {
            iniciaEscenari();
            iniciaGraella();
   
        }


        /// <summary>
        /// inicia un escenari amb files, columnes, homes dones etc...
        /// </summary>
        private void iniciaEscenari()
        {
            esc = new Escenari(num_files, num_columnes);
            grdEscenari.ColumnDefinitions.Clear();
            grdEscenari.RowDefinitions.Clear();
            grdEscenari.Children.Clear();

            ColumnDefinition colDef;
            RowDefinition rowDef;
            TextBlock persona;

            // columnes grid Escenari
            for (int i = 0; i < num_columnes; i++)
            {
                colDef = new ColumnDefinition();
                grdEscenari.ColumnDefinitions.Add(colDef);
            }
            // files grid Escenari
            for (int i = 0; i < num_files; i++)
            {
                rowDef = new RowDefinition();
                grdEscenari.RowDefinitions.Add(rowDef);
            }

            Random r = new Random();
            int nomRandom, sexe, fila, columna, simpatia;

            // Generem les dones
            for(int dona = 0; dona < num_dones ; dona++)
            {
                // generem valors aleatòris
                fila = r.Next(0, num_files-1);
                columna = r.Next(0, num_columnes-1);
                //nomRandom = r.Next(0,nomsDones.Count());
                sexe = r.Next(0,4);
                
                // Creem una nova dona i la col·loquem a l'escenari
                Dona d = new Dona(nomsDones[dona],sexe);
                d.Columna = columna;
                d.Fila = fila;
                esc.posar(d);

                persona = new TextBlock();
                persona.FontSize = 14;
                persona.FontWeight = FontWeights.Bold;
                persona.Text = d.Nom;
                Grid.SetColumn(persona, d.Columna);
                Grid.SetRow(persona, d.Fila);
                grdEscenari.Children.Add(persona);

            }

            // Generem els homes
            for (int home = 0; home < num_homes; home++)
            {
                // generem valors aleatòris
                fila = r.Next(0, num_files - 1);
                columna = r.Next(0, num_columnes - 1);
                //nomRandom = r.Next(0, nomsHomes.Count());
                sexe = r.Next(0, 4);

                // Creem un nou home i la col·loquem a l'escenari
                Home h = new Home(nomsHomes[home], sexe);
                h.Columna = columna;
                h.Fila = fila;
                esc.posar(h);

                persona = new TextBlock();
                persona.FontSize = 14;
                persona.FontWeight = FontWeights.Bold;
                persona.Text = h.Nom;
                Grid.SetColumn(persona, h.Columna);
                Grid.SetRow(persona, h.Fila);
                grdEscenari.Children.Add(persona);
            }

            // Assignem les simpaties
            for (int person = 0; person < esc.Tp.NumPersones; person++)
            {
                for (int personaALaLlista = 0; personaALaLlista < esc.Tp.NumPersones; personaALaLlista++)
                {
                    if (esc.Tp.ElementAt(person).Nom != esc.Tp.ElementAt(personaALaLlista).Nom)
                    {
                        simpatia = r.Next(-5, 6);
                        // aplicar simpatia per cada persona contra totes les de la llista
                        if(esc.Tp.ElementAt(person) is Home)
                        {
                            Home h = esc.Tp.ElementAt(person) as Home;
                            h[esc.Tp.ElementAt(personaALaLlista).Nom] = simpatia;
                        }
                        else if(esc.Tp.ElementAt(person) is Dona)
                        {
                            Dona d = esc.Tp.ElementAt(person) as Dona;
                            d[esc.Tp.ElementAt(personaALaLlista).Nom] = simpatia;
                        }
                    }
                }
            }
        }

        private void iniciaGraella()
        {
            grdGraella.ColumnDefinitions.Clear();
            grdGraella.RowDefinitions.Clear();
            grdGraella.Children.Clear();

            ColumnDefinition colDef;
            RowDefinition rowDef;
            TextBlock nomPersona, simpatiaPersona;

            ////Columna de noms
            colDef = new ColumnDefinition();
            grdGraella.ColumnDefinitions.Add(colDef);
            //columnes grid Graella
            for (int i = 0; i < esc.Tp.NumPersones; i++)
            {
                colDef = new ColumnDefinition();

                grdGraella.ColumnDefinitions.Add(colDef);

                // Creem l'element que mostrarà el nom de la persona
                nomPersona = new TextBlock();
                nomPersona.Text = esc.Tp.ElementAt(i).Nom;
                nomPersona.FontSize = 14;
                nomPersona.FontWeight = FontWeights.Bold;
                nomPersona.Foreground = new SolidColorBrush(Colors.Black);
                nomPersona.VerticalAlignment = VerticalAlignment.Top;
                nomPersona.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetRow(nomPersona, 0);
                Grid.SetColumn(nomPersona, i+1);
                grdGraella.Children.Add(nomPersona);

            }

            //Fila de noms
            rowDef = new RowDefinition();
            grdGraella.RowDefinitions.Add(rowDef);
            //files grid Graella
            for (int i = 0; i < esc.Tp.NumPersones; i++)
            {
                rowDef = new RowDefinition();
                grdGraella.RowDefinitions.Add(rowDef);

                nomPersona = new TextBlock();
                nomPersona.Text = esc.Tp.ElementAt(i).Nom;
                nomPersona.FontSize = 14;
                nomPersona.FontWeight = FontWeights.Bold;
                nomPersona.Foreground = new SolidColorBrush(Colors.Black);
                nomPersona.VerticalAlignment = VerticalAlignment.Center;
                nomPersona.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetRow(nomPersona, i+1);
                Grid.SetColumn(nomPersona, 0);
                grdGraella.Children.Add(nomPersona);
            }

            grdEscenari.ShowGridLines = true;
            grdGraella.ShowGridLines = true;

            

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
