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
        private int num_convidats;
        private int num_cambrers;
        private int num_files = 0;
        private int num_columnes = 0;
        string[] nomsDones = { "maria","marta","anna","cristina","susana","ague","channel","noa","maite","mercedes","nuria","silvia" };
        string[] nomsHomes = { "joan", "jordi", "cristian", "eric", "david", "alex", "sergi", "martí", "xavier", "eudald", "gabri", "arnau" };

        string[] imgHomes = { "Brian.png", "Peter Griffin.png", "Quagmire.PNG", "xerxes.png" };
        string[] imgDones = { "tia1.png", "tia2.png", "tia3.png" };

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
            //PintarEscenari();
            
            RePintaEscenari();
            
            //MessageBox.Show("Convidat: " + esc.Tp.ElementAt(0).Nom + " -> fila: " + esc.Tp.ElementAt(0).Fila + " -> Columna: " + esc.Tp.ElementAt(0).Columna);
        }

        private void RePintaEscenari()
        {
            StackPanel blocPersona;
            TextBlock persona;
            grdEscenari.Children.Clear();
            string nomImatge;
            Random r = new Random();

            for (int i = 0; i < esc.Tp.NumPersones; i++)
            {
                blocPersona = new StackPanel();

                persona = new TextBlock();
                persona.FontSize = 14;
                

                if (esc.Tp.ElementAt(i) is Cambrer)
                {
                    creaQuadre("/Fotos/Cambrer/Camarero.png","*",esc.Tp.ElementAt(i).Fila,esc.Tp.ElementAt(i).Columna,30);
             
                }
                else
                {
                    nomImatge = esc.Tp.ElementAt(i).NomImg;
                        
                    creaQuadre(nomImatge,esc.Tp.ElementAt(i).Nom,esc.Tp.ElementAt(i).Fila,esc.Tp.ElementAt(i).Columna,14);
                }
            }
        }

        /// <summary>
        /// pinta l'escenari
        /// </summary>
        private void PintarEscenari()
        {
            ColumnDefinition colDef;
            RowDefinition rowDef;

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
        }

        private void CrearPersones()
        {
            Random r = new Random();
            int sexe, fila, columna;
            string nomImatge;

            // Generem les dones
            for (int dona = 0; dona < num_dones; dona++)
            {
                // generem valors aleatòris
                fila = r.Next(0, num_files - 1);
                columna = r.Next(0, num_columnes - 1);
                sexe = r.Next(0, 4);

                // Assignem el nom de la imatge
                nomImatge = "/Fotos/Dones/"+imgDones[r.Next(0, imgDones.Length)];

                // Creem una nova dona i la col·loquem a l'escenari
                Dona d = new Dona(nomsDones[dona], sexe, nomImatge);
                d.Columna = columna;
                d.Fila = fila;
                esc.posar(d);

                creaQuadre(nomImatge,d.Nom,d.Fila,d.Columna,14);
            }

            // Generem els homes
            for (int home = 0; home < num_homes; home++)
            {
                // generem valors aleatòris
                fila = r.Next(0, num_files - 1);
                columna = r.Next(0, num_columnes - 1);
                sexe = r.Next(0, 4);

                // Assignem el nom de la imatge
                nomImatge =  "/Fotos/Homes/"+imgHomes[r.Next(0, imgHomes.Length)];
                

                // Creem un nou home i la col·loquem a l'escenari
                Home h = new Home(nomsHomes[home], sexe, nomImatge);
                h.Columna = columna;
                h.Fila = fila;
                esc.posar(h);

                creaQuadre(nomImatge, h.Nom, h.Fila, h.Columna,14);
            }

            // Generem els cambrers
            for (int cambrer = 0; cambrer < num_cambrers; cambrer++)
            {
                // generem valors aleatòris
                fila = r.Next(0, num_files - 1);
                columna = r.Next(0, num_columnes - 1);

                nomImatge = "/Fotos/Cambrer/Camarero.png";                

                // Creem un nou home i la col·loquem a l'escenari
                Cambrer c = new Cambrer();
                c.Columna = columna;
                c.Fila = fila;
                esc.posar(c);

                creaQuadre(nomImatge, "*", c.Fila, c.Columna,14);
            }
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

            // Generem l'escenari
            PintarEscenari();

            // Generem totes les persones de l'escenari
            CrearPersones();

            // Assignem les simpaties a tots els convidats anvers tots els convidats menys a ell mateix i als cambrers
            assignarSimpaties();
            
        }

        /// <summary>
        /// Assignem les simpaties de tots els convidats
        /// </summary>
        private void assignarSimpaties()
        {
            Random r = new Random();
            int simpatia;

            for (int person = 0; person < esc.Tp.NumPersones; person++)
            {
                for (int personaALaLlista = 0; personaALaLlista < esc.Tp.NumPersones; personaALaLlista++)
                {
                    if (esc.Tp.ElementAt(person).Nom != esc.Tp.ElementAt(personaALaLlista).Nom)
                    {
                        simpatia = r.Next(-5, 6);

                        if (!(esc.Tp.ElementAt(personaALaLlista) is Cambrer && !(esc.Tp.ElementAt(person) is Cambrer)))
                        {
                            // aplicar simpatia per cada persona contra totes les de la llista menys dels cambrers
                            if (esc.Tp.ElementAt(person) is Home)
                            {
                                Home h = esc.Tp.ElementAt(person) as Home;
                                h[esc.Tp.ElementAt(personaALaLlista).Nom] = simpatia;
                            }
                            else if (esc.Tp.ElementAt(person) is Dona)
                            {
                                Dona d = esc.Tp.ElementAt(person) as Dona;
                                d[esc.Tp.ElementAt(personaALaLlista).Nom] = simpatia;
                            }
                        }

                    }
                }
            }
        }

        private void iniciaGraella()
        {
            // Reiniciem la graella
            grdGraella.ColumnDefinitions.Clear();
            grdGraella.RowDefinitions.Clear();
            grdGraella.Children.Clear();

            // Calculem el nombre de convidats per fer la graella sense tenir en compte els cambrers
            // ja que no cal que apareixin
            num_convidats = num_dones + num_homes;

            inicialitzaGraella();

            ompleSimpaties();

            grdEscenari.ShowGridLines = true;
            grdGraella.ShowGridLines = true;
            
        }

        #region GENEREM TOTA LA GRAELLA DE SIMPATIES
        private void ompleSimpaties()
        {
            TextBlock simpatiaPersona;

            // Mostrem les simpaties de cada convidat anvers a totes les altres a la graella
            for (int i = 0; i < num_convidats; i++)
            {
                for (int j = 0; j < num_convidats; j++)
                {
                    if (j != i && !(esc.Tp.ElementAt(i) is Cambrer) && !(esc.Tp.ElementAt(j) is Cambrer))
                    {
                        simpatiaPersona = new TextBlock();
                        simpatiaPersona.FontSize = 16;
                        simpatiaPersona.FontWeight = FontWeights.Bold;
                        simpatiaPersona.VerticalAlignment = VerticalAlignment.Center;
                        simpatiaPersona.HorizontalAlignment = HorizontalAlignment.Center;

                        if (esc.Tp.ElementAt(i) is Home)
                        {
                            Home aux = (Home)esc.Tp.ElementAt(i);
                            simpatiaPersona.Text = aux[esc.Tp.ElementAt(j).Nom].ToString();
                        }
                        else if (esc.Tp.ElementAt(i) is Dona)
                        {
                            Dona aux = (Dona)esc.Tp.ElementAt(i);
                            simpatiaPersona.Text = aux[esc.Tp.ElementAt(j).Nom].ToString();
                        }

                        Grid.SetColumn(simpatiaPersona, j + 1);
                        Grid.SetRow(simpatiaPersona, i + 1);
                        grdGraella.Children.Add(simpatiaPersona);
                    }
                }
            }            
        }

        // Inicialitzem la graella amb els noms dels convidats a la primera fila i també a la primera columna
        private void inicialitzaGraella()
        {
            ColumnDefinition colDef;
            RowDefinition rowDef;
            TextBlock nomPersona;

            ////Columna de noms
            colDef = new ColumnDefinition();
            grdGraella.ColumnDefinitions.Add(colDef);

            // Generem les columnes de la graella 
            // i també posem els noms dels convidats a la primera fila
            for (int i = 0; i < num_convidats; i++)
            {
                colDef = new ColumnDefinition();

                grdGraella.ColumnDefinitions.Add(colDef);

                // Creem l'element que mostrarà el nom de la persona
                nomPersona = new TextBlock();
                nomPersona.Text = esc.Tp.ElementAt(i).Nom;
                nomPersona.FontSize = 14;
                nomPersona.FontWeight = FontWeights.Bold;
                nomPersona.Foreground = new SolidColorBrush(Colors.Black);
                nomPersona.VerticalAlignment = VerticalAlignment.Center;
                nomPersona.HorizontalAlignment = HorizontalAlignment.Center;
                nomPersona.RenderTransformOrigin = new Point(0.5, 0.5); 
                nomPersona.RenderTransform = new RotateTransform(-90);
                Grid.SetRow(nomPersona, 0);
                Grid.SetColumn(nomPersona, i + 1);
                grdGraella.Children.Add(nomPersona);
            }

            //Fila de noms
            rowDef = new RowDefinition();
            grdGraella.RowDefinitions.Add(rowDef);

            // Generem les files de la graella 
            // i també posem els noms dels convidats a la primera columna
            for (int i = 0; i < num_convidats; i++)
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
                Grid.SetRow(nomPersona, i + 1);
                Grid.SetColumn(nomPersona, 0);
                grdGraella.Children.Add(nomPersona);
            }
        }

        #endregion

        public void creaQuadre(string rutaImatge, string nom, int fila, int columna, int midaLletra)
        {
            StackPanel persona = new StackPanel();
            TextBlock nomPersona = new TextBlock();

            nomPersona.FontSize = midaLletra;
            nomPersona.FontWeight = FontWeights.Bold;
            nomPersona.HorizontalAlignment = HorizontalAlignment.Center;
            nomPersona.VerticalAlignment = VerticalAlignment.Bottom;
            nomPersona.Text = nom;

            persona.Children.Add(nomPersona);
            ImageBrush fons = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), rutaImatge)));
            persona.Background = fons;
            
            Grid.SetColumn(persona, columna);
            Grid.SetRow(persona, fila);
            grdEscenari.Children.Add(persona);
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
