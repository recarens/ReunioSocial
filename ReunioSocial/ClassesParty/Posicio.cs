using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesParty
{
    public enum Direccio { Quiet, Amunt, Dreta, Avall, Esquerra }
    public class Posicio
    {
        int columna;
        int fila;

        public int Columna
        {
            get { return columna; }
            set { columna = value; }
        }
        public int Fila
        {
            get { return fila; }
            set { fila = value; }
        }
        public bool Buida
        {
            get { return true; }
        }

        double Distancia(Posicio pos)
        {
            double distancia = 0;
            int numColumnes = Math.Abs(this.Fila - pos.Fila);
            int numFiles =  Math.Abs(this.Columna - pos.Columna);
            distancia = Math.Sqrt((numColumnes * numColumnes) + (numColumnes * numColumnes));
            return distancia;
        }
        
    }
}
