using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExoPOO___Jeu_421
{
    public class Manche421
    {
        private int[] mesDes = new int[3];
        public De D1 { get; private set; }
        public De D2 { get; private set; }
        public De D3 { get; private set; }
        public int countRelance { get; private set; }

        public Manche421()
        {
            D1 = new De();
            D2 = new De();
            D3 = new De();
            countRelance = 0;
        }

        public void LancerDes()
        {
            D1.Lancer();
            D2.Lancer();
            D3.Lancer();
            countRelance++;
        }
        public bool Check421()
        {
            mesDes[0] = D1.Valeur;
            mesDes[1] = D2.Valeur;
            mesDes[2] = D3.Valeur;

            Array.Sort(mesDes);
            if (mesDes[2] == 4 && mesDes[1] == 2 && mesDes[0] == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RelancePossible()
        {
            if (countRelance < 3)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void Relancer1De(int _deArelancer)
        {
            switch (_deArelancer)
            {
                case 1: D1.Lancer(); break;
                case 2: D2.Lancer(); break;
                case 3: D3.Lancer(); break;
            }
            countRelance++;
        }
        public void Relancer2De(int _deArelancer1, int _deArelancer2)
        {
            switch (_deArelancer1)
            {
                case 1: D1.Lancer(); break;
                case 2: D2.Lancer(); break;
                case 3: D3.Lancer(); break;
            }
            switch (_deArelancer2)
            {
                case 1: D1.Lancer(); break;
                case 2: D2.Lancer(); break;
                case 3: D3.Lancer(); break;
            }
            countRelance++;
        }
    }
}