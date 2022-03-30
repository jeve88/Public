using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExoPOO___Jeu_421
{
    public class De
    {
        public int Valeur { get; /*private*/ set; } // A decommenter  (test 421 gagné 1er coup)
        public int NumDe { get; private set; }
        public De() { }
        public De(int _numDe)
        {
            NumDe = _numDe;
        }
        public void Lancer()
        {
            Valeur = Alea.Instance().Nouveau(1, 6);
        }

    }
}