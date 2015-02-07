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
            this.Fila = 0;
            this.Columna = 0;
        }
        /// <summary>
        /// Crea una persona
        /// </summary>
        public Persona() : base()
        {
            this.nom = "Anonymous";
        }
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

            if (!esc[fil, col].Buida && this.Fila != fil && this.Columna != col)
            {
                atraccio = Interes(esc[Fila, Columna]) / Math.Sqrt(Math.Pow(2, Fila - fil) + Math.Pow(2, Fila - col));
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
            List<double> atrracions = new List<double>();
            double amunt = Atraccio(Fila - 1, Columna, esc);
            double dreta = Atraccio(Fila, Columna+1, esc);
            double esquerra = Atraccio(Fila, Columna-1, esc);
            double avall = Atraccio(Fila + 1, Columna, esc);
            double resultat;
            atrracions.Add(amunt);
            atrracions.Add(dreta);
            atrracions.Add(esquerra);
            atrracions.Add(avall);

            resultat = atrracions.Max();

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
