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
            Home h1 = new Home("antonio", 1);
            Convidat d2 = new Dona("maria", 2);
            Cambrer c1 = new Cambrer(1);
        }
    }
}
