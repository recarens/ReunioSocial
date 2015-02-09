using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassesParty
{
    public class Escenari
    {
        Persona[,] esc;
        int nHomes;
        int nDones;
        int nCambrers;
        TaulaPersones tp;
        /// <summary>
        /// Crea un escenari donades unes mides
        /// </summary>
        /// <param name="files">Número de files de l'escenari</param>
        /// <param name="columnes">Número de columnes de l'escenari</param>
        public Escenari(int files, int columnes)
        {
            esc = new Persona[files, columnes];
            nHomes = 0;
            nDones = 0;
            nCambrers = 0;
            tp = new TaulaPersones();
        }
        /// <summary>
        /// Retorna el número de files de l'escenari
        /// </summary>
        public int Files
        {
            get { return esc.GetLength(0); }
        }
        /// <summary>
        /// Retorna el número de columnes de l'escenari
        /// </summary>
        public int Columnes
        {
            get { return esc.GetLength(1); }
        }
        /// <summary>
        /// Retorna el número de homes que hi ha dins de l'escenari
        /// </summary>
        public int Homes
        { 
            get { return nHomes;} 
        }
        /// <summary>
        /// Retorna el número de dones que hi ha dins de l'escenari
        /// </summary>
        public int Dones
        {
            get { return nDones; }
        }
        /// <summary>
        /// Retorna el número de Cambrers que hi ha dins de l'escenari
        /// </summary>
        public int Cambrers
        { 
            get { return nCambrers;} 
        }
        /// <summary>
        /// Mou una persona de (filOrig, colOrig) fins a la posicio adjacent(filDesti,colDesti)
        /// Es suposa que les coordenades són vàlides, que hi ha una persona a l'origen i que el destí està buit.
        /// </summary>
        /// <param name="filOrig">Fila de la coordenada d'origen</param>
        /// <param name="colOrig">Columna de la coordenada d'origen</param>
        /// <param name="filDesti">Fila de la coordenada de destí</param>
        /// <param name="colDesti">Columna de la coordenada de destí</param>
        private void Moure(int filOrig, int colOrig, int filDesti, int colDesti)
        {
            if (DestiValid(filDesti, colDesti) && esc[filDesti, colDesti].Buida)
            {
                esc[filDesti, colDesti] = esc[filOrig, colDesti];
                esc[filOrig, colDesti] = null;
            }
        }
        /// <summary>
        /// Retorna la Posició que hi ha en una coordenada donada
        /// </summary>
        public Posicio this[int fila, int col]
        {
            get { return (Posicio)esc[fila,col];}
        }
        /// <summary>
        /// Mira si una coordenada es correcte per ser destí d'una persona
        /// </summary>
        /// <param name="fil">fila de la coordenada</param>
        /// <param name="col">columna de la coordenada</param>
        /// <returns>retorna si la coordenada és vàlida i està buida</returns>
        public bool DestiValid(int fil, int col)
        {
            bool destiValid = false;
            if (fil < esc.GetLength(0) && fil >= 0 && col >= 0 && col < esc.GetLength(1))
                destiValid = true;
            return destiValid;

        }
        /// <summary>
        /// Retorna el contingut del escenari en forma de matriu d'strings,
        /// representant cada persona amb el seu nom
        /// </summary>
        /// <returns>Matriu de caràcters</returns>
        public String[,] ContingutNoms()
        {
            string[,] contingut = new string[esc.GetLength(0), esc.GetLength(1)];
            for(int i = 0; i < contingut.GetLength(0);i++)
            {
                for (int j = 0; j < contingut.GetLength(1); j++)
                {
                    contingut[i, j] = esc[i, j].Nom.ToString().Trim();
                }
            }
            return contingut;
        }
        /// <summary>
        /// Elimina una persona de l'escenari i de la taula de persones
        /// </summary>
        /// <param name="fil">Fila on està la persona</param>
        /// <param name="col">Columna on està la persona</param>
        public void buidar(int fil, int col)
        {
            tp.Eliminar(esc[fil, col]);

            if (!esc[fil, col].EsConvidat())
            {
                nCambrers--;
            }
            else
            {
               //si es home ho dona
            }
            esc[fil, col] = null;
        }
        /// <summary>
        /// Posa una Persona dins de l'escenari i a la taula de persones
        /// Si la posició de la persona ja està ocupada, genera una excepció
        /// </summary>
        /// <param name="pers">Persona a afegir</param>
        public void posar(Persona pers)
        {
            tp.Afegir(pers);

        }
        /// <summary>
        /// Mira si en el tauler hi ha alguna persona amb aquest nom
        /// </summary>
        /// <param name="nom">Nom a cercar</param>
        /// <returns>Si hi ha coincidència</returns>
        public bool NomRepetit(string nom)
        {
            bool repe = false;
            for (int i = 0; i < esc.GetLength(0); i++)
            {
                for (int j = 0; j < esc.GetLength(1); j++)
                {
                    if(esc[i,j].Nom == nom)
                    {
                        repe = true;
                    }
                }
            }
            return repe;
        }
        /// <summary>
        /// Fa que totes les persones facin un moviment
        /// </summary>
        public void Cicle()
        {
        }
    }
}
