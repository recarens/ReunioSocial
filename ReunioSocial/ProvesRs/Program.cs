using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassesParty;
namespace ProvesRs
{
    class Program
    {
        private const int NUM_FILES_ESCENARI = 20;
        private const int NUM_COLUMNES_ESCENARI = 20;
        static void Main(string[] args)
        {
            Escenari esc1 = new Escenari(NUM_FILES_ESCENARI, NUM_COLUMNES_ESCENARI);
            Home h1 = new Home("antonio", 1);
            Convidat d2 = new Dona("maria", 2);
            Cambrer c1 = new Cambrer();
            Random rF;
            Random rC;
            //random de files i columnes
            // Mostrem la posicio d'una persona de la taula
            //tp1["antonio"].Fila = 2;
            //tp1["antonio"].Columna = 12;
            //Console.WriteLine("Files: " + esc1.Files + ", Columnes: " + esc1.Columnes);
            //Console.WriteLine(tp1["antonio"].Nom + ": Columna -> "+ tp1["antonio"].Columna + ", Fila -> "+ tp1["antonio"].Fila);
            // Col·loquem un cambrer
            c1.Fila = 4; c1.Columna = 5;
            esc1.posar(c1);
            d2.Fila = 3; d2.Columna = 2;
            esc1.posar(d2);
            esc1.buidar(4, 5);
            Console.WriteLine(c1.Nom);

            Direccio direccio = c1.OnVaig(esc1);

            bool repe = esc1.NomRepetit("maria");
            bool repeC = esc1.NomRepetit("cambrer0");
            bool repe2 = esc1.NomRepetit("ss");
            string[,] escStrings = esc1.ContingutNoms();

            esc1.Cicle();
        }
    }
}
