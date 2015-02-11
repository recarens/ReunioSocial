﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesParty
{
    public class TaulaPersones
    {
        Dictionary<string,Persona> taulaPersones;
        int i;
        /// <summary>
        /// Crea una taula de referències a persones
        /// </summary>
        public TaulaPersones()
        {
            taulaPersones = new Dictionary<string, Persona>();
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
        /// Afegeix una persona a la taula
        /// </summary>
        /// <param name="conv">Convidat a afegir</param>
        public void Afegir(Persona pers) 
        {
            if (pers.EsConvidat())
                taulaPersones.Add(pers.Nom.ToString().ToLower(), pers);
            else
            {
                taulaPersones.Add(((Cambrer)pers).NomC.ToString().ToLower(), pers);
            }

        }
        /// <summary>
        /// Eliminar una persona de la taula
        /// </summary>
        /// <param name="conv">Convidat a eliminar</param>
        public void Eliminar(Persona pers) 
        {

            taulaPersones.Remove(((Cambrer)pers).NomC.ToString().ToLower());
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
    }
}