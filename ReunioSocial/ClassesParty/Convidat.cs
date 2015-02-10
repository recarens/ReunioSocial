using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesParty
{
    public abstract class Convidat : Persona
    {
        int[] simp;
        int sexe;
        /// <summary>
        /// Crea un convidat
        /// </summary>
        /// <param name="nom">string que l'identificarà</param>
        /// <param name="simp">Taula de simpaties</param>
        /// <param name="sex">Plus de simpatia sobre el sexe contrari</param>
        public Convidat(string nom, int[] simp, int sexe):base(nom)
        {
            this.simp = simp;
            this.sexe = sexe;
        }
        /// <summary>
        /// Crea un convidat
        /// </summary>
        /// <param name="nom">Caràcter que l'identificarà</param>
        /// <param name="sex">Plus de simpatia sobre el sexe contrari</param>
        public Convidat(string nom, int sexe):base(nom)
        {
            this.simp = new int[0];
            this.sexe = sexe;
        }
        /// <summary>
        /// Retorna o estableix la simpaties envers a algú
        /// </summary>
        public int this[string nom]
        {
            get {return 0;}
            set { simp[0] = (int)value; }
        }
        /// <summary>
        /// Retorna o estableix el plus de simpatia envers del sexe contrari
        /// </summary>
        public int PlusSexe
        {
            get
            {
                return sexe;
            }
            set
            {
                this.sexe = value;
            }
        }
        /// <summary>
        /// Retorna que si és un convidat
        /// </summary>
        /// <returns>Cert</returns>
        public override bool EsConvidat()
        {
            return true;
        }
    }
}