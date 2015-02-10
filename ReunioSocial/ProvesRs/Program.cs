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
        static void Main(string[] args)
        {
            Escenari esc1 = new Escenari(10, 10);
            TaulaPersones tp1 = new TaulaPersones();
            Home h1 = new Home("antonio", 1);
            Convidat d2 = new Dona("maria", 2);
            Cambrer c1 = new Cambrer();
            Random rF;
            Random rC;
            
            //random de files i columnes
            tp1.Afegir(h1);
            tp1.Afegir(d2);
            tp1.Afegir(c1);
        }
    }
}
