using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesParty
{
    public class TaulaPersones:IEnumerable<Persona>
    {
        Dictionary<string,Persona> taulaPersones;
        List<string> claus;

        
        /// <summary>
        /// Crea una taula de referències a persones
        /// </summary>
        public TaulaPersones()
        {
            taulaPersones = new Dictionary<string, Persona>();
            claus = new List<string>();
        }
        /// <summary>
        /// Assigna o obté una persona de la taula
        /// </summary>
        public Persona this[string nom]
        {
            get
            {
                nom = nom.ToLower();
                return taulaPersones[nom];
            }
            set
            {
                taulaPersones.Add(nom.ToString().ToLower(),(Persona)value);
                claus.Add(nom.ToString().ToLower());
            }

        }
        /// <summary>
        /// Obtè el número total de persones
        /// </summary>
        public int NumPersones
        {
            get
            {
                return taulaPersones.Count;
            }
        }

        /// <summary>
        /// Obtè les claus del diccionari
        /// </summary>
        public List<string> Claus
        {
            get { return claus; }
        }

        /// <summary>
        /// Afegeix una persona a la taula
        /// </summary>
        /// <param name="conv">Convidat a afegir</param>
        public void Afegir(Persona pers) 
        {
            if (pers.EsConvidat())
            {
                taulaPersones.Add(pers.Nom.ToString().ToLower(), pers);
                claus.Add(pers.Nom.ToString().ToLower());
            }
            else
            {
                taulaPersones.Add(((Cambrer)pers).NomC.ToString().ToLower(), pers);
                claus.Add(((Cambrer)pers).NomC.ToString().ToLower());
            }
            
        }
        /// <summary>
        /// Eliminar una persona de la taula
        /// </summary>
        /// <param name="conv">Convidat a eliminar</param>
        public void Eliminar(Persona pers) 
        {
            if (pers.EsConvidat())
            {
                taulaPersones.Remove(pers.Nom.ToString().ToLower());
                claus.Remove(pers.Nom.ToString().ToLower());
            }
            else
            {
                taulaPersones.Remove(((Cambrer)pers).NomC.ToString().ToLower());
                claus.Remove(((Cambrer)pers).NomC.ToString().ToLower());
            }
        }
        /// <summary>
        /// Elimina la persona donat el seu nom
        /// </summary>
        /// <param name="posicio">Posició a eliminar</param>
        public void Eliminar(string nom)
        {
            nom = nom.ToLower();
            taulaPersones.Remove(nom);
        }

        public IEnumerator<Persona> GetEnumerator()
        {
            List<Persona> llista = new List<Persona>();
            for (int i = 0; i < NumPersones;i++)
            {
                llista.Add(taulaPersones[claus[i]]);
            }
                foreach (Persona tc in llista)
                    yield return tc;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}