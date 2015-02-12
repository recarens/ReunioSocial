﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesParty
{
    public class Dona : Convidat
    {
        Dictionary<Posicio, int> interessos;
        /// <summary>
        /// Crea una Dona
        /// </summary>
        /// <param name="nom">String que identifica aquesta Dona</param>
        /// <param name="simpa">Taula de simpaties envers els altres convidats</param>
        /// <param name="sexe">Plus de simpatia envers convidats del sexe contrari</param>
        public Dona(string nom, int[] simpa, int sexe) : base(nom, simpa, sexe)
        {
            interessos = new Dictionary<Posicio, int>();
        }
        /// <summary>
        /// Crea una Dona
        /// </summary>
        /// <param name="nom"> String que identifica aquesta Dona</param>
        /// <param name="sexe">Plus de simpatia envers convidats del sexe contrari</param>
        public Dona(string nom, int sexe):base(nom,sexe)
        {
            interessos = new Dictionary<Posicio, int>();
        }
        /// <summary>
        /// Interès d'aquesta dona per una posició
        /// </summary>
        /// <param name="pos">Posició per la qual s'interessa</param>
        /// <returns>Interès quantificat</returns>
        public override int Interes(Posicio pos)
        {

            int interes = 0;
            if(!pos.Buida)
            {
                if(((Convidat)pos).EsConvidat())
                { 
                     if (pos.GetType().Equals(typeof(Home)))
                     {
                         interes = base[((Convidat)pos).Nom] + PlusSexe;
                     }
                     else if (pos.GetType().Equals(typeof(Dona)))
                     {
                         interes = base[((Convidat)pos).Nom];
                     }
                }
            }
            return interes;
        }
    }
}
