using ClassLibrary_2048;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTest2048
{
    class Program
    {
        static Cases[,] maGrille = new Cases[4, 4];
        static Random rand = new Random();

        static void Main(string[] args)
        {
            for (int i = 3; i >= 0; i--)
            {
                for (int j = 0; j < 4; j++)
                {
                    maGrille[i, j] = new Cases();
                    maGrille[i, j].saValeur = 0;
                }
            }

            NouveauChiffre();
            NouveauChiffre();

            while (true)
            {
                AffichGrille(maGrille);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.LeftArrow:
                        DeplacementGauche();
                        break;
                    case ConsoleKey.UpArrow:
                        DeplacementHaut();
                        break;
                    case ConsoleKey.RightArrow:
                        DeplacementDroite();
                        break;
                    case ConsoleKey.DownArrow:
                        DeplacementBas();
                        break;
                    default: break;
                }
                NouveauChiffre();
            }
            
        }

        static void NouveauChiffre()
        {
            List<Cases> IndexCaseVide = new List<Cases>();
            foreach (var item in maGrille)
            {
                if (item.saValeur == 0)
                {
                    IndexCaseVide.Add(item);
                }
            }

            IndexCaseVide[rand.Next(0, IndexCaseVide.Count)].saValeur = rand.Next(0, 2) == 0 ? 2 : 4;
        }

        static void DeplacementGauche()
        {
            bool deplacementPossible;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    deplacementPossible = maGrille[i, j].saValeur != 0;

                    while (j > 0 && deplacementPossible)
                    {
                        if (maGrille[i, j - 1].saValeur == 0)
                        {
                            maGrille[i, j - 1].saValeur = maGrille[i, j].saValeur;
                            maGrille[i, j].saValeur = 0;
                            j--;
                        }
                        else if (maGrille[i, j - 1].saValeur == maGrille[i, j].saValeur)
                        {
                            maGrille[i, j - 1].saValeur = maGrille[i, j].saValeur * 2;
                            maGrille[i, j].saValeur = 0;
                            j--;
                            deplacementPossible = false;

                        }
                        else
                        {
                            deplacementPossible = false;
                        }
                    }
                }
            }
        }

        static void DeplacementDroite()
        {
            bool deplacementPossible;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 2; j >= 0; j--)
                {
                    deplacementPossible = maGrille[i, j].saValeur != 0;

                    while (j < 3 && deplacementPossible)
                    {
                        if (maGrille[i, j + 1].saValeur == 0)
                        {
                            maGrille[i, j + 1].saValeur = maGrille[i, j].saValeur;
                            maGrille[i, j].saValeur = 0;
                            j++;
                        }
                        else if (maGrille[i, j + 1].saValeur == maGrille[i, j].saValeur)
                        {
                            maGrille[i, j + 1].saValeur = maGrille[i, j].saValeur * 2;
                            maGrille[i, j].saValeur = 0;
                            j++;
                            deplacementPossible = false;

                        }
                        else
                        {
                            deplacementPossible = false;
                        }
                    }
                }
            }
        }

        static void DeplacementBas()
        {
            bool deplacementPossible;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    deplacementPossible = maGrille[j, i].saValeur != 0;

                    while (j > 0 && deplacementPossible)
                    {
                        if (maGrille[j - 1, i].saValeur == 0)
                        {
                            maGrille[j - 1, i].saValeur = maGrille[j, i].saValeur;
                            maGrille[j, i].saValeur = 0;
                            j--;
                        }
                        else if (maGrille[j - 1, i].saValeur == maGrille[j, i].saValeur)
                        {
                            maGrille[j - 1, i].saValeur = maGrille[j, i].saValeur * 2;
                            maGrille[j, i].saValeur = 0;
                            j--;
                            deplacementPossible = false;

                        }
                        else
                        {
                            deplacementPossible = false;
                        }
                    }
                }
            }
        }

        static void DeplacementHaut()
        {
            bool deplacementPossible;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 2; j >= 0; j--)
                {
                    deplacementPossible = maGrille[j, i].saValeur != 0;

                    while (j < 3 && deplacementPossible)
                    {
                        if (maGrille[j + 1, i].saValeur == 0)
                        {
                            maGrille[j + 1, i].saValeur = maGrille[j, i].saValeur;
                            maGrille[j, i].saValeur = 0;
                            j++;
                        }
                        else if (maGrille[j + 1, i].saValeur == maGrille[j, i].saValeur)
                        {
                            maGrille[j + 1, i].saValeur = maGrille[j, i].saValeur * 2;
                            maGrille[j, i].saValeur = 0;
                            j++;
                            deplacementPossible = false;

                        }
                        else
                        {
                            deplacementPossible = false;
                        }
                    }
                }
            }
        }

        static void AffichGrille(Cases[,] _maGrille)
        {
            for (int i = 3; i >= 0; i--)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(_maGrille[i, j].saValeur + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }

    

}
