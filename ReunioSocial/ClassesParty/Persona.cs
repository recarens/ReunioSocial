using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesParty
{
    public abstract class Persona : Posicio
    {
        string nom;
        /// <summary>
        /// Crea una persona
        /// </summary>
        /// <param name="nom">Strng que identifica la persona</param>
        /// <param name="fil">Fila on està localitzada</param>
        /// <param name="col">Columna on està localitzada</param>
        public Persona(string nom, int fil, int col) : base(fil, col)
        {
            this.nom = nom;
        }
        /// <summary>
        /// Crea una persona
        /// </summary>
        /// <param name="nom">nom de la persona</param>
        public Persona(string nom)
        {
            this.nom = nom;
        }
        /// <summary>
        /// Crea una persona
        /// </summary>
        public Persona() : base(){}
        /// <summary>
        /// Obté el nom de la persona
        /// </summary>
        public string Nom
        {
            get { return nom;}
        }
        /// <summary>
        /// Retorna que la posició ocupada per aquesta persona no està buida
        /// </summary>
        public override bool Buida
        {
            get { return false;}
        }
        /// <summary>
        /// Atraccio de persona sobre una determinada posicio
        /// </summary>
        /// <param name="fil">Fila de la posició</param>
        /// <param name="col">Columan de la posició</param>
        /// <param name="esc">Escenari on estan situats</param>
        /// <returns>Atracció quantificada</returns>
        private double Atraccio(int fil, int col, Escenari esc)
        {
            double atraccio = 0;

            if (!esc[fil, col].Buida && (this.Fila != fil) || (this.Columna != col))
            {
                atraccio = Interes(esc[Fila, Columna]) / Math.Sqrt((Math.Pow(2, Fila - fil)) + (Math.Pow(2, Columna - col)));
            }
            return atraccio;
        }
        /// <summary>
        /// Decideix quin serà el següent moviment que farà la persona
        /// </summary>
        /// <param name="esc">Escenari on esta situada la persona</param>
        /// <returns>Una de les 5 possibles direccions (Quiet, Amunt, Avall, Dreta, Esquerra</returns>
        public Direccio OnVaig(Escenari esc)
        {
            List<double> atraccions = new List<double>();
            double amunt = 0;
            double dreta =0;
            double esquerra = 0;
            double avall = 0;
            double resultat;
            foreach (Persona p in esc.Tp)
            {
                if (p.Nom != this.nom)
                {
                    if (amunt < Atraccio(p.Fila, p.Columna, esc))
                        amunt = Atraccio(p.Fila, p.Columna, esc);

                    if (dreta < Atraccio(p.Fila, p.Columna, esc))
                        dreta = Atraccio(Fila, Columna + 1, esc);

                    if (esquerra < Atraccio(p.Fila, p.Columna, esc))
                        esquerra = Atraccio(Fila, Columna - 1, esc);

                    if (avall < Atraccio(p.Fila, p.Columna, esc))
                        avall = Atraccio(Fila + 1, Columna, esc);
                }
            }
            atraccions.Add(amunt);
            atraccions.Add(dreta);
            atraccions.Add(esquerra);
            atraccions.Add(avall);
            
            resultat = atraccions.Max();

            if(resultat == amunt)
            {
                return Direccio.Amunt;
            }
            else if (resultat == avall)
            {
                return Direccio.Avall;
            }
            else if (resultat == dreta)
            {
                return Direccio.Dreta;
            }
            else if (resultat == esquerra)
            {
                return Direccio.Esquerra;
            }
            else
            {
                return Direccio.Quiet;
            }
        }
        /// <summary>
        /// Interès de la persona sobre una determinada posició
        /// </summary>
        /// <param name="pos">Posició</param>
        /// <returns>Interès quantificat</returns>
        public abstract int Interes(Posicio pos);
        /// <summary>
        /// Determina si la persona es un convidat (home o dona) o un cambrer
        /// </summary>
        /// <returns>Retorna si és convidat</returns>
        public abstract bool EsConvidat();

    }
}
