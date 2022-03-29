using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Casse_Briques
{
    class Program
    {

        public const int xPos = 45;
        public const int yPos = 31;
        public const int xLimit = 40;

        static void Main(string[] args)
        {
            Console.SetWindowSize(88, 34);
            Console.SetBufferSize(88, 34);
            Console.CursorVisible = false;

            ConsoleKey key;
            Balle balle = new Balle();
            Barre barre = new Barre();
            //Brique brique = new Brique(45, 9);
            Niveau.Niveau1();

            do
            {
                Console.Clear();
                Affichage.Cadre(2, 1);
                balle = new Balle();
                barre = new Barre();
                barre.Dessiner();
                balle.Dessiner();
                //brique.Dessiner();
                Niveau.Dessiner();


                do
                {
                    key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.RightArrow && barre.Xpos <= 78)
                    {
                        barre.Effacer();
                        balle.Effacer();
                        barre.Xpos += 2;
                        balle.Xpos += 2;
                        barre.Dessiner();
                        balle.Dessiner();
                    }
                    else if (key == ConsoleKey.LeftArrow && barre.Xpos >= 11)
                    {
                        barre.Effacer();
                        barre.Xpos -= 2;
                        barre.Dessiner();
                        balle.Effacer();
                        balle.Xpos -= 2;
                        balle.Dessiner();
                    }

                } while (key != ConsoleKey.Spacebar);



                int sleepcount = 0;
                do
                {
                    while (Console.KeyAvailable == false && balle.gameOver == false)
                    {
                        Thread.Sleep(20);
                        sleepcount++;
                        //int[,] tabPos = brique.TabPosHaut();
                        if (sleepcount == 5)
                        {
                            balle.Mouvement(barre.Xpos);
                            if (balle.mouvement)
                            {                                
                                for (int i = 0; i < Niveau.ListeBrique.Count; i++)
                                {
                                    if (Niveau.ListeBrique[i].TabPosHaut(balle))
                                    {
                                        Niveau.ListeBrique.RemoveAt(i);
                                    }
                                }
                            }
                            if (!balle.mouvement)
                            {
                                for (int i = 0; i < Niveau.ListeBrique.Count; i++)
                                {
                                    if (Niveau.ListeBrique[i].TabPosBas(balle))
                                    {
                                        Niveau.ListeBrique.RemoveAt(i);
                                    }
                                }
                            }
                            for (int i = 0; i < Niveau.ListeBrique.Count; i++)
                                {
                                    if (Niveau.ListeBrique[i].Bors(balle))
                                    {
                                        Niveau.ListeBrique.RemoveAt(i);
                                    }
                                }

                            sleepcount = 0;
                        }

                    }
                    if (balle.gameOver == true)
                    {
                        break;
                    }

                    key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.RightArrow && barre.Xpos <= 78)
                    {
                        barre.Effacer();
                        barre.Xpos += 2;
                        barre.Dessiner();
                    }
                    else if (key == ConsoleKey.LeftArrow && barre.Xpos >= 11)
                    {
                        barre.Effacer();
                        barre.Xpos -= 2;
                        barre.Dessiner();
                    }

                } while (true);

            } while (true);


        }
    }
}
