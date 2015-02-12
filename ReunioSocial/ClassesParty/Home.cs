using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesParty
{
    public class Home : Convidat
    {
        Dictionary<Posicio, int> interessos;
        /// <summary>
        /// Crea un Home
        /// </summary>
        /// <param name="nom">String que l'identificarà</param>
        /// <param name="simpa">Taula de simpaties</param>
        /// <param name="sexe">Plus de simpatia envers del sexe contrari</param>
        /// 
        public Home(string nom, int[] simpa, int sexe) : base(nom, simpa, sexe)
        {
            interessos = new Dictionary<Posicio, int>();
        }
        /// <summary>
        /// Crea un Home
        /// </summary>
        /// <param name="nom">String que l'identificarà</param>
        /// <param name="sexe">Plus de simpatia envers del sexe contrari</param>
        /// 
        public Home(string nom, int sexe) : base(nom, sexe)
        {
            interessos = new Dictionary<Posicio, int>();
        }
        /// <summary>
        /// Interès d'aquest home per una posició
        /// </summary>
        /// <param name="pos">Posició per la qual s'interessa</param>
        /// <returns>Interès quantificat</returns>
        /// 
        public override int Interes(Posicio pos)
        {
            int interes = 0;
            if (!pos.Buida)
            {
                if (((Convidat)pos).EsConvidat())
                {
                    if (pos.GetType().Equals(typeof(Dona)))
                    {
                        interes = interessos[pos] + PlusSexe;
                    }
                    else
                    {
                        interes = interessos[pos];
                    }
                }
                else
                {
                    interes = 1;
                }
            }
            return interes;
        }
    }
}
