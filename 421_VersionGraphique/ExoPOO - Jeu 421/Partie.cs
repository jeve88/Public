using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExoPOO___Jeu_421
{
    public class Partie
    {
        public int NbrManches { get; private set; }
        public int Points { get; set; }
        public int Manche { get; /*private*/ set; }
        public List<Manche421> ListeM { get; private set; }
        public Partie() { }
        public Partie(int nbrManches)
        {
            NbrManches = nbrManches;
            Points = nbrManches * 10;
            Manche = 0;
            ListeM = new List<Manche421>();            
        }

        public void NouvelleManche()
        {
            Manche++;
            ListeM.Add(new Manche421());
        }
        public bool FinDePartie()
        {
            if (Manche == NbrManches)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}