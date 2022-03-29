using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_2048
{
    [Serializable]
    public class Grille
    {
        public int largeur = 4;
        public Cases[,] grille;
        Random rand = new Random();
        bool aAtteint2048;

        public delegate void Delegate2048();
        public event Delegate2048 ViensDePasser2048;

        public Grille()
        {
            grille = new Cases[4, 4];
            for (int i = 3; i >= 0; i--)
            {
                for (int j = 0; j < 4; j++)
                {
                    grille[i, j] = new Cases();
                    grille[i, j].saValeur = 0;
                }
            }
            aAtteint2048 = false;
        }

        public Grille(int _largeur)
        {
            largeur = _largeur;
            grille = new Cases[largeur, largeur];
            for (int i = largeur - 1; i >= 0; i--)
            {
                for (int j = 0; j < largeur; j++)
                {
                    grille[i, j] = new Cases();
                    grille[i, j].saValeur = 0;
                }
            }
            aAtteint2048 = false;


            //aAtteint2048 = true;
            grille[3, 0].saValeur = 4096 * 4;
            //grille[3, 1].saValeur = 256;
            //grille[3, 2].saValeur = 4;
            //grille[3, 3].saValeur = 2;

            grille[2, 0].saValeur = 4096 * 8;
            //grille[2, 1].saValeur = 32;
            //grille[2, 2].saValeur = 8;
            //grille[2, 3].saValeur = 0;

            grille[1, 0].saValeur = 4096 * 16;
            //grille[1, 1].saValeur = 4;
            //grille[1, 2].saValeur = 2;
            //grille[1, 3].saValeur = 0;

            grille[0, 0].saValeur = 4096 * 32;
            //grille[0, 1].saValeur = 4096 * 16;
            //grille[0, 2].saValeur = 4096 * 8;
            //grille[0, 3].saValeur = 4096 * 4;
        }

        public Grille(Grille _aCloner)
        {
            largeur = _aCloner.largeur;
            grille = new Cases[largeur, largeur];
            for (int i = largeur - 1; i >= 0; i--)
            {
                for (int j = 0; j < largeur; j++)
                {
                    grille[i, j] = new Cases();
                    grille[i, j].saValeur = _aCloner.grille[i, j].saValeur;
                }
            }
            aAtteint2048 = _aCloner.aAtteint2048;
        }

        public void NouveauChiffre()
        {
            List<Cases> IndexCaseVide = new List<Cases>();
            foreach (var item in grille)
            {
                if (item.saValeur == 0)
                {
                    IndexCaseVide.Add(item);
                }
            }
            if (IndexCaseVide.Count > 0)
            {
                IndexCaseVide[rand.Next(0, IndexCaseVide.Count)].saValeur = rand.Next(0, 10) == 0 ? 4 : 2;
            }
        }

        public void ReinitialiserAFusione()
        {
            for (int i = largeur - 1; i >= 0; i--)
            {
                for (int j = 0; j < largeur; j++)
                {
                    grille[i, j].aFusione = false;
                }
            }
        }

        public bool DeplacementGauchePossible()
        {
            bool deplacementPossible;
            bool deplacementEffectuer = false;

            for (int i = 0; i < largeur; i++)
            {
                for (int j = 1; j < largeur; j++)
                {
                    deplacementPossible = grille[i, j].saValeur != 0;

                    if (j > 0 && deplacementPossible)
                    {
                        if (grille[i, j - 1].saValeur == 0)
                        {
                            deplacementEffectuer = true;
                        }
                        else if (grille[i, j - 1].saValeur == grille[i, j].saValeur)
                        {
                            deplacementPossible = false;
                            deplacementEffectuer = true;
                        }
                        else
                        {
                            deplacementPossible = false;
                        }
                    }
                }
            }
            return deplacementEffectuer;
        }

        public bool DeplacementGauche()
        {
            bool deplacementPossible;
            bool deplacementEffectuer = false;
            bool viensDePasser2048 = false;

            for (int i = 0; i < largeur; i++)
            {
                for (int j = 1; j < largeur; j++)
                {
                    deplacementPossible = grille[i, j].saValeur != 0;

                    while (j > 0 && deplacementPossible)
                    {
                        if (grille[i, j - 1].saValeur == 0)
                        {
                            grille[i, j - 1].saValeur = grille[i, j].saValeur;
                            grille[i, j].saValeur = 0;
                            j--;
                            deplacementEffectuer = true;
                        }
                        else if (grille[i, j - 1].saValeur == grille[i, j].saValeur &&
                                 grille[i, j - 1].aFusione == false)
                        {
                            grille[i, j - 1].saValeur = grille[i, j].saValeur * 2;
                            grille[i, j].saValeur = 0;
                            grille[i, j - 1].aFusione = true;
                            if (grille[i, j - 1].saValeur == 2048)
                            {
                                viensDePasser2048 = true;
                            }
                            j--;
                            deplacementPossible = false;
                            deplacementEffectuer = true;
                        }
                        else
                        {
                            deplacementPossible = false;
                        }
                    }
                }
            }
            ReinitialiserAFusione();

            if (!aAtteint2048 && viensDePasser2048 && ViensDePasser2048 != null)
            {
                aAtteint2048 = true;
                ViensDePasser2048();
            }
            return deplacementEffectuer;
        }

        public bool DeplacementDroitePossible()
        {
            bool deplacementPossible;
            bool deplacementEffectuer = false;

            for (int i = 0; i < largeur; i++)
            {
                for (int j = largeur - 2; j >= 0; j--)
                {
                    deplacementPossible = grille[i, j].saValeur != 0;

                    if (j < largeur - 1 && deplacementPossible)
                    {
                        if (grille[i, j + 1].saValeur == 0)
                        {
                            deplacementEffectuer = true;
                        }
                        else if (grille[i, j + 1].saValeur == grille[i, j].saValeur)
                        {
                            deplacementPossible = false;
                            deplacementEffectuer = true;
                        }
                        else
                        {
                            deplacementPossible = false;
                        }
                    }
                }
            }
            return deplacementEffectuer;
        }

        public bool DeplacementDroite()
        {
            bool deplacementPossible;
            bool deplacementEffectuer = false;
            bool viensDePasser2048 = false;

            for (int i = 0; i < largeur; i++)
            {
                for (int j = largeur - 2; j >= 0; j--)
                {
                    deplacementPossible = grille[i, j].saValeur != 0;

                    while (j < largeur - 1 && deplacementPossible)
                    {
                        if (grille[i, j + 1].saValeur == 0)
                        {
                            grille[i, j + 1].saValeur = grille[i, j].saValeur;
                            grille[i, j].saValeur = 0;
                            j++;
                            deplacementEffectuer = true;
                        }
                        else if (grille[i, j + 1].saValeur == grille[i, j].saValeur &&
                                 grille[i, j + 1].aFusione == false)
                        {
                            grille[i, j + 1].saValeur = grille[i, j].saValeur * 2;
                            grille[i, j].saValeur = 0;
                            grille[i, j + 1].aFusione = true;
                            if (grille[i, j + 1].saValeur == 2048)
                            {
                                viensDePasser2048 = true;
                            }
                            j++;
                            deplacementPossible = false;
                            deplacementEffectuer = true;
                        }
                        else
                        {
                            deplacementPossible = false;
                        }
                    }
                }
            }
            ReinitialiserAFusione();
            if (!aAtteint2048 && viensDePasser2048 && ViensDePasser2048 != null)
            {
                aAtteint2048 = true;
                ViensDePasser2048();
            }
            return deplacementEffectuer;
        }

        public bool DeplacementBasPossible()
        {
            bool deplacementPossible;
            bool deplacementEffectuer = false;

            for (int i = 0; i < largeur; i++)
            {
                for (int j = 1; j < largeur; j++)
                {
                    deplacementPossible = grille[j, i].saValeur != 0;

                    if (j > 0 && deplacementPossible)
                    {
                        if (grille[j - 1, i].saValeur == 0)
                        {
                            deplacementEffectuer = true;
                        }
                        else if (grille[j - 1, i].saValeur == grille[j, i].saValeur)
                        {
                            deplacementPossible = false;
                            deplacementEffectuer = true;
                        }
                        else
                        {
                            deplacementPossible = false;
                        }
                    }
                }
            }
            return deplacementEffectuer;
        }

        public bool DeplacementBas()
        {
            bool deplacementPossible;
            bool deplacementEffectuer = false;
            bool viensDePasser2048 = false;

            for (int i = 0; i < largeur; i++)
            {
                for (int j = 1; j < largeur; j++)
                {
                    deplacementPossible = grille[j, i].saValeur != 0;

                    while (j > 0 && deplacementPossible)
                    {
                        if (grille[j - 1, i].saValeur == 0)
                        {
                            grille[j - 1, i].saValeur = grille[j, i].saValeur;
                            grille[j, i].saValeur = 0;
                            j--;
                            deplacementEffectuer = true;
                        }
                        else if (grille[j - 1, i].saValeur == grille[j, i].saValeur &&
                                 grille[j - 1, i].aFusione == false)
                        {
                            grille[j - 1, i].saValeur = grille[j, i].saValeur * 2;
                            grille[j, i].saValeur = 0;
                            grille[j - 1, i].aFusione = true;
                            if (grille[j - 1, i].saValeur == 2048)
                            {
                                viensDePasser2048 = true;
                            }
                            j--;
                            deplacementPossible = false;
                            deplacementEffectuer = true;
                        }
                        else
                        {
                            deplacementPossible = false;
                        }
                    }
                }
            }
            ReinitialiserAFusione();
            if (!aAtteint2048 && viensDePasser2048 && ViensDePasser2048 != null)
            {
                aAtteint2048 = true;
                ViensDePasser2048();
            }
            return deplacementEffectuer;
        }

        public bool DeplacementHautPossible()
        {
            bool deplacementPossible;
            bool deplacementEffectuer = false;

            for (int i = 0; i < largeur; i++)
            {
                for (int j = largeur - 2; j >= 0; j--)
                {
                    deplacementPossible = grille[j, i].saValeur != 0;

                    if (j < largeur - 1 && deplacementPossible)
                    {
                        if (grille[j + 1, i].saValeur == 0)
                        {
                            deplacementEffectuer = true;
                        }
                        else if (grille[j + 1, i].saValeur == grille[j, i].saValeur)
                        {
                            deplacementPossible = false;
                            deplacementEffectuer = true;
                        }
                        else
                        {
                            deplacementPossible = false;
                        }
                    }
                }
            }
            return deplacementEffectuer;
        }

        public bool DeplacementHaut()
        {
            bool deplacementPossible;
            bool deplacementEffectuer = false;
            bool viensDePasser2048 = false;

            for (int i = 0; i < largeur; i++)
            {
                for (int j = largeur - 2; j >= 0; j--)
                {
                    deplacementPossible = grille[j, i].saValeur != 0;

                    while (j < largeur - 1 && deplacementPossible)
                    {
                        if (grille[j + 1, i].saValeur == 0)
                        {
                            grille[j + 1, i].saValeur = grille[j, i].saValeur;
                            grille[j, i].saValeur = 0;
                            j++;
                            deplacementEffectuer = true;
                        }
                        else if (grille[j + 1, i].saValeur == grille[j, i].saValeur &&
                                 grille[j + 1, i].aFusione == false)
                        {
                            grille[j + 1, i].saValeur = grille[j, i].saValeur * 2;
                            grille[j, i].saValeur = 0;
                            grille[j + 1, i].aFusione = true;
                            if (grille[j + 1, i].saValeur == 2048)
                            {
                                viensDePasser2048 = true;
                            }
                            j++;
                            deplacementPossible = false;
                            deplacementEffectuer = true;
                        }
                        else
                        {
                            deplacementPossible = false;
                        }
                    }
                }
            }
            ReinitialiserAFusione();
            if (!aAtteint2048 && viensDePasser2048 && ViensDePasser2048 != null)
            {
                aAtteint2048 = true;
                ViensDePasser2048();
            }
            return deplacementEffectuer;
        }
    }
}






//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ClassLibrary_2048
//{
//    public class Grille
//    {
//        public int largeur = 4;
//        public Cases[,] grille;
//        Random rand = new Random();

//        public Grille()
//        {
//            grille = new Cases[4, 4];
//            for (int i = 3; i >= 0; i--)
//            {
//                for (int j = 0; j < 4; j++)
//                {
//                    grille[i, j] = new Cases();
//                    grille[i, j].saValeur = 0;
//                }
//            }

//            grille[3, 0].saValeur = 8;

//            grille[2, 0].saValeur = 8;
//            grille[2, 1].saValeur = 16;
//            grille[2, 2].saValeur = 2;
//            grille[2, 3].saValeur = 2;

//            grille[1, 0].saValeur = 32;
//            grille[1, 1].saValeur = 2;
//            grille[1, 2].saValeur = 8;
//            grille[1, 3].saValeur = 0;

//            grille[0, 0].saValeur = 128;
//            grille[0, 1].saValeur = 32;
//            grille[0, 2].saValeur = 8;
//            grille[0, 3].saValeur = 2;
//        }

//        public Grille(int _largeur)
//        {
//            largeur = _largeur;
//            grille = new Cases[largeur, largeur];
//            for (int i = largeur - 1; i >= 0; i--)
//            {
//                for (int j = 0; j < largeur; j++)
//                {
//                    grille[i, j] = new Cases();
//                    grille[i, j].saValeur = 0;
//                }
//            }
//        }

//        public Grille(Grille _aCloner)
//        {
//            grille = new Cases[4, 4];
//            for (int i = 3; i >= 0; i--)
//            {
//                for (int j = 0; j < 4; j++)
//                {
//                    grille[i, j] = new Cases();
//                    grille[i, j].saValeur = _aCloner.grille[i, j].saValeur;
//                }
//            }
//        }

//        public void NouveauChiffre()
//        {
//            List<Cases> IndexCaseVide = new List<Cases>();
//            foreach (var item in grille)
//            {
//                if (item.saValeur == 0)
//                {
//                    IndexCaseVide.Add(item);
//                }
//            }
//            if (IndexCaseVide.Count > 0)
//            {
//                IndexCaseVide[rand.Next(0, IndexCaseVide.Count)].saValeur = rand.Next(0, 10) == 0 ? 4 : 2;
//            }
//        }

//        public void ReinitialiserAFusione()
//        {
//            for (int i = largeur - 1; i >= 0; i--)
//            {
//                for (int j = 0; j < largeur; j++)
//                {
//                    grille[i, j].aFusione = false;
//                }
//            }
//        }

//        public bool DeplacementGauchePossible()
//        {
//            bool deplacementPossible;
//            bool deplacementEffectuer = false;

//            for (int i = 0; i < largeur; i++)
//            {
//                for (int j = 1; j < largeur; j++)
//                {
//                    deplacementPossible = grille[i, j].saValeur != 0;

//                    if (j > 0 && deplacementPossible)
//                    {
//                        if (grille[i, j - 1].saValeur == 0)
//                        {
//                            deplacementEffectuer = true;
//                        }
//                        else if (grille[i, j - 1].saValeur == grille[i, j].saValeur)
//                        {
//                            deplacementPossible = false;
//                            deplacementEffectuer = true;
//                        }
//                        else
//                        {
//                            deplacementPossible = false;
//                        }
//                    }
//                }
//            }
//            return deplacementEffectuer;
//        }

//        public bool DeplacementGauche()
//        {
//            bool deplacementPossible;
//            bool deplacementEffectuer = false;

//            for (int i = 0; i < largeur; i++)
//            {
//                for (int j = 1; j < largeur; j++)
//                {
//                    deplacementPossible = grille[i, j].saValeur != 0;

//                    while (j > 0 && deplacementPossible)
//                    {
//                        if (grille[i, j - 1].saValeur == 0)
//                        {
//                            grille[i, j - 1].saValeur = grille[i, j].saValeur;
//                            grille[i, j].saValeur = 0;
//                            j--;
//                            deplacementEffectuer = true;
//                        }
//                        else if (grille[i, j - 1].saValeur == grille[i, j].saValeur &&
//                                 grille[i, j - 1].aFusione == false)
//                        {
//                            grille[i, j - 1].saValeur = grille[i, j].saValeur * 2;
//                            grille[i, j].saValeur = 0;
//                            grille[i, j - 1].aFusione = true;
//                            j--;
//                            deplacementPossible = false;
//                            deplacementEffectuer = true;
//                        }
//                        else
//                        {
//                            deplacementPossible = false;
//                        }
//                    }
//                }
//            }
//            ReinitialiserAFusione();
//            return deplacementEffectuer;
//        }

//        public bool DeplacementDroitePossible()
//        {
//            bool deplacementPossible;
//            bool deplacementEffectuer = false;

//            for (int i = 0; i < largeur; i++)
//            {
//                for (int j = largeur - 2; j >= 0; j--)
//                {
//                    deplacementPossible = grille[i, j].saValeur != 0;

//                    if (j < 3 && deplacementPossible)
//                    {
//                        if (grille[i, j + 1].saValeur == 0)
//                        {
//                            deplacementEffectuer = true;
//                        }
//                        else if (grille[i, j + 1].saValeur == grille[i, j].saValeur)
//                        {
//                            deplacementPossible = false;
//                            deplacementEffectuer = true;
//                        }
//                        else
//                        {
//                            deplacementPossible = false;
//                        }
//                    }
//                }
//            }
//            return deplacementEffectuer;
//        }

//        public bool DeplacementDroite()
//        {
//            bool deplacementPossible;
//            bool deplacementEffectuer = false;

//            for (int i = 0; i < largeur; i++)
//            {
//                for (int j = largeur - 2; j >= 0; j--)
//                {
//                    deplacementPossible = grille[i, j].saValeur != 0;

//                    while (j < 3 && deplacementPossible)
//                    {
//                        if (grille[i, j + 1].saValeur == 0)
//                        {
//                            grille[i, j + 1].saValeur = grille[i, j].saValeur;
//                            grille[i, j].saValeur = 0;
//                            j++;
//                            deplacementEffectuer = true;
//                        }
//                        else if (grille[i, j + 1].saValeur == grille[i, j].saValeur &&
//                                 grille[i, j + 1].aFusione == false)
//                        {
//                            grille[i, j + 1].saValeur = grille[i, j].saValeur * 2;
//                            grille[i, j].saValeur = 0;
//                            grille[i, j + 1].aFusione = true;
//                            j++;
//                            deplacementPossible = false;
//                            deplacementEffectuer = true;
//                        }
//                        else
//                        {
//                            deplacementPossible = false;
//                        }
//                    }
//                }
//            }
//            ReinitialiserAFusione();
//            return deplacementEffectuer;
//        }

//        public bool DeplacementBasPossible()
//        {
//            bool deplacementPossible;
//            bool deplacementEffectuer = false;

//            for (int i = 0; i < largeur; i++)
//            {
//                for (int j = 1; j < largeur; j++)
//                {
//                    deplacementPossible = grille[j, i].saValeur != 0;

//                    if (j > 0 && deplacementPossible)
//                    {
//                        if (grille[j - 1, i].saValeur == 0)
//                        {
//                            deplacementEffectuer = true;
//                        }
//                        else if (grille[j - 1, i].saValeur == grille[j, i].saValeur)
//                        {
//                            deplacementPossible = false;
//                            deplacementEffectuer = true;
//                        }
//                        else
//                        {
//                            deplacementPossible = false;
//                        }
//                    }
//                }
//            }
//            return deplacementEffectuer;
//        }

//        public bool DeplacementBas()
//        {
//            bool deplacementPossible;
//            bool deplacementEffectuer = false;

//            for (int i = 0; i < largeur; i++)
//            {
//                for (int j = 1; j < largeur; j++)
//                {
//                    deplacementPossible = grille[j, i].saValeur != 0;

//                    while (j > 0 && deplacementPossible)
//                    {
//                        if (grille[j - 1, i].saValeur == 0)
//                        {
//                            grille[j - 1, i].saValeur = grille[j, i].saValeur;
//                            grille[j, i].saValeur = 0;
//                            j--;
//                            deplacementEffectuer = true;
//                        }
//                        else if (grille[j - 1, i].saValeur == grille[j, i].saValeur &&
//                                 grille[j - 1, i].aFusione == false)
//                        {
//                            grille[j - 1, i].saValeur = grille[j, i].saValeur * 2;
//                            grille[j, i].saValeur = 0;
//                            grille[j - 1, i].aFusione = true;
//                            j--;
//                            deplacementPossible = false;
//                            deplacementEffectuer = true;
//                        }
//                        else
//                        {
//                            deplacementPossible = false;
//                        }
//                    }
//                }
//            }
//            ReinitialiserAFusione();
//            return deplacementEffectuer;
//        }

//        public bool DeplacementHautPossible()
//        {
//            bool deplacementPossible;
//            bool deplacementEffectuer = false;

//            for (int i = 0; i < largeur; i++)
//            {
//                for (int j = largeur - 2; j >= 0; j--)
//                {
//                    deplacementPossible = grille[j, i].saValeur != 0;

//                    if (j < 3 && deplacementPossible)
//                    {
//                        if (grille[j + 1, i].saValeur == 0)
//                        {
//                            deplacementEffectuer = true;
//                        }
//                        else if (grille[j + 1, i].saValeur == grille[j, i].saValeur)
//                        {
//                            deplacementPossible = false;
//                            deplacementEffectuer = true;
//                        }
//                        else
//                        {
//                            deplacementPossible = false;
//                        }
//                    }
//                }
//            }
//            return deplacementEffectuer;
//        }

//        public bool DeplacementHaut()
//        {
//            bool deplacementPossible;
//            bool deplacementEffectuer = false;

//            for (int i = 0; i < largeur; i++)
//            {
//                for (int j = largeur - 2; j >= 0; j--)
//                {
//                    deplacementPossible = grille[j, i].saValeur != 0;

//                    while (j < 3 && deplacementPossible)
//                    {
//                        if (grille[j + 1, i].saValeur == 0)
//                        {
//                            grille[j + 1, i].saValeur = grille[j, i].saValeur;
//                            grille[j, i].saValeur = 0;
//                            j++;
//                            deplacementEffectuer = true;
//                        }
//                        else if (grille[j + 1, i].saValeur == grille[j, i].saValeur &&
//                                 grille[j + 1, i].aFusione == false)
//                        {
//                            grille[j + 1, i].saValeur = grille[j, i].saValeur * 2;
//                            grille[j, i].saValeur = 0;
//                            grille[j + 1, i].aFusione = true;
//                            j++;
//                            deplacementPossible = false;
//                            deplacementEffectuer = true;
//                        }
//                        else
//                        {
//                            deplacementPossible = false;
//                        }
//                    }
//                }
//            }
//            ReinitialiserAFusione();
//            return deplacementEffectuer;
//        }
//    }
//}



