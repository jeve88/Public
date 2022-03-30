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
        public const int speedConst = 7;
        public const int bonusChance = 4; // grand = moins de bonus

        static void Main(string[] args)
        {
            Console.SetWindowSize(88, 34);
            Console.SetBufferSize(88, 34);
            Console.CursorVisible = false;

            Random rand = new Random();
            int nbrRand;

            do
            {
                ///////////
                int speed = speedConst;  // Augmenter pour ralentir!  Vitesse max: 1  
                int vies = 10;
                int countNiv = 1;
                ///////////



                //initialisation:
                //Console.Write("Nbr vie(s): ");
                //vies = int.Parse(Console.ReadLine());
                //Console.Write("Vitesse: ");
                //speed = int.Parse(Console.ReadLine());
                //Console.Write("Niveau: ");
                //countNiv = int.Parse(Console.ReadLine());
                //


                // Start:
                Affichage.Start();
                Affichage.AppuyezSurEntree(18);
                //

                do
                {
                    ConsoleKey key;
                    //Balle balle = new Balle();
                    Barre barre = new Barre();
                    List<Balle> listBalle = new List<Balle>();
                    listBalle.Add(new Balle());

                    List<Brique> ListeBriqueBonus = new List<Brique>();

                    // Niveau:
                    switch (countNiv)
                    {
                        case 1: Niveau.Niveau1(); break;
                        case 2: Niveau.Niveau2(); break;
                        case 3: Niveau.Niveau3(); break;
                        default:
                            Niveau.Niveau1();
                            countNiv = 1;
                            break;
                    }


                    //affichage niveau:
                    Console.Clear();
                    Console.SetCursorPosition((Console.WindowWidth / 2) - ("NIVEAU  ".Length / 2), Console.WindowHeight / 2);
                    Console.Write("NIVEAU " + countNiv);
                    Thread.Sleep(1500);


                    countNiv++;
                //

                hardReset:
                    do
                    {


                        try
                        {

                            Console.Clear();

                            Console.SetCursorPosition((Console.WindowWidth / 2) - ("Vie(s) :  ".Length / 2), 0);
                            Console.Write("Vie(s) : " + vies);

                            Affichage.Cadre(2, 1);
                            //balle = new Balle();
                            listBalle[0] = new Balle();
                            barre = new Barre();
                            barre.Dessiner();
                            //balle.Dessiner();
                            listBalle[0].Dessiner();
                            Niveau.Dessiner();


                            do
                            {
                                key = Console.ReadKey(true).Key;
                                if (key == ConsoleKey.RightArrow && barre.Xpos <= 78 - ((barre.largeur / 2) - 5))
                                {
                                    barre.Effacer();
                                    //balle.Effacer();
                                    listBalle[0].Effacer();
                                    barre.Xpos += 2;
                                    //balle.Xpos += 2;
                                    listBalle[0].xPos += 2;
                                    barre.Dessiner();
                                    //balle.Dessiner();
                                    listBalle[0].Dessiner();
                                }
                                else if (key == ConsoleKey.LeftArrow && barre.Xpos >= 11 + ((barre.largeur / 2) - 5))
                                {
                                    barre.Effacer();
                                    barre.Xpos -= 2;
                                    barre.Dessiner();
                                    //balle.Effacer();
                                    //balle.Xpos -= 2;
                                    //balle.Dessiner();
                                    listBalle[0].Effacer();
                                    listBalle[0].xPos -= 2;
                                    listBalle[0].Dessiner();
                                }
                                // PAUSE:
                                else if (key == ConsoleKey.P)
                                {
                                    Console.Clear();
                                    Console.SetCursorPosition((Console.WindowWidth / 2) - ("PAUSE".Length / 2), Console.WindowHeight / 2);
                                    Console.Write("PAUSE");

                                    while (Console.ReadKey(true).Key != ConsoleKey.P) { }

                                    Console.Clear();
                                    Console.SetCursorPosition((Console.WindowWidth / 2) - ("Vie(s) :  ".Length / 2), 0);
                                    Console.Write("Vie(s) : " + vies);
                                    Affichage.Cadre(2, 1);
                                    barre.Dessiner();
                                    //balle.Dessiner();
                                    listBalle[0].Dessiner();
                                    Niveau.Dessiner();
                                }

                            } while (key != ConsoleKey.Spacebar);



                            int sleepcount = 0;
                            int bonusDownCount = 0;

                            do
                            {


                                //pour listeBalle:
                                bool test = true;
                                for (int i = 0; i < listBalle.Count; i++)
                                {
                                    if (!listBalle[i].gameOver)
                                    {
                                        test = false;
                                    }
                                }
                                //
                                while (Console.KeyAvailable == false && test == false && !Niveau.FinDeNiveau())
                                {
                                    Thread.Sleep(10);
                                    sleepcount++;
                                    bonusDownCount++;

                                    //Gerer descente brique bonus
                                    if (bonusDownCount == (speed * 2))
                                    {
                                        for (int i = 0; i < ListeBriqueBonus.Count; i++)
                                        {
                                            if (ListeBriqueBonus[i].Ypos < 31)
                                            {
                                                if (ListeBriqueBonus[i].Ypos == 29)
                                                {
                                                    if (barre.Xpos > ListeBriqueBonus[i].Xpos - 8 && barre.Xpos < ListeBriqueBonus[i].Xpos + 8)
                                                    {
                                                        Console.SetCursorPosition(0, 0);
                                                        //Console.Write("success !!!!!!!!!!!!!!!!!!!!!!!!!!!");
                                                        switch (ListeBriqueBonus[i].Color)
                                                        {
                                                            case ConsoleColor.DarkRed:
                                                                if (!barre.bonusLarg)
                                                                {
                                                                    barre.largeur = 14;
                                                                    barre.bonusLarg = true;
                                                                    barre.color = ConsoleColor.DarkCyan;
                                                                    barre.Dessiner();
                                                                }
                                                                break;
                                                            case ConsoleColor.DarkGreen:
                                                                if (listBalle.Count < 2)
                                                                {
                                                                    do
                                                                    {
                                                                        nbrRand = rand.Next(-2, 3);
                                                                    } while (nbrRand == listBalle[0].xAngle);
                                                                    listBalle.Add(new Balle(listBalle[0].xPos, listBalle[0].yPos, nbrRand, listBalle[0].mouvement));
                                                                }
                                                                break;
                                                            case ConsoleColor.DarkMagenta:
                                                                if (speed != 10)
                                                                {
                                                                    speed = 10;
                                                                    sleepcount = 0;
                                                                }
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                        ListeBriqueBonus[i].Effacer();
                                                        ListeBriqueBonus.RemoveAt(i);
                                                    }
                                                    else
                                                    {
                                                        ListeBriqueBonus[i].bonusDown();
                                                    }
                                                }
                                                else
                                                {
                                                    ListeBriqueBonus[i].bonusDown();
                                                }
                                            }
                                            else
                                            {
                                                ListeBriqueBonus[i].Effacer();
                                                ListeBriqueBonus.RemoveAt(i);
                                            }
                                        }
                                        bonusDownCount = 0;
                                    }

                                    //Mouvement Balle et Contact balle/brique
                                    if (sleepcount == speed)
                                    {
                                        for (int j = 0; j < listBalle.Count; j++)
                                        {
                                            listBalle[j].Mouvement(barre.Xpos, barre.largeur);
                                            if (listBalle[j].mouvement)
                                            {
                                                for (int i = 0; i < Niveau.ListeBrique.Count; i++)
                                                {
                                                    if (Niveau.ListeBrique[i].TabPosHaut(listBalle[j]))
                                                    {
                                                        if (Niveau.ListeBrique[i].doubleTouche)
                                                        {
                                                            Niveau.ListeBrique[i].premiereTouche();
                                                        }
                                                        else
                                                        {
                                                            // Brique bonus
                                                            nbrRand = rand.Next(0, bonusChance);
                                                            if (nbrRand == 0)
                                                            {
                                                                ListeBriqueBonus.Add(new Brique(Niveau.ListeBrique[i].Xpos, Niveau.ListeBrique[i].Ypos, Niveau.ListeBrique[i].Color, false, true));
                                                                ListeBriqueBonus[ListeBriqueBonus.Count - 1].Dessiner("░░░░░░");
                                                            }
                                                            //

                                                            Niveau.ListeBrique.RemoveAt(i);
                                                        }
                                                    }
                                                }
                                            }
                                            if (!listBalle[j].mouvement)
                                            {
                                                for (int i = 0; i < Niveau.ListeBrique.Count; i++)
                                                {
                                                    if (Niveau.ListeBrique[i].TabPosBas(listBalle[j]))
                                                    {
                                                        if (Niveau.ListeBrique[i].doubleTouche)
                                                        {
                                                            Niveau.ListeBrique[i].premiereTouche();
                                                        }
                                                        else
                                                        {
                                                            // Brique bonus
                                                            nbrRand = rand.Next(0, bonusChance);
                                                            if (nbrRand == 0)
                                                            {
                                                                ListeBriqueBonus.Add(new Brique(Niveau.ListeBrique[i].Xpos, Niveau.ListeBrique[i].Ypos, Niveau.ListeBrique[i].Color, false, true));
                                                                ListeBriqueBonus[ListeBriqueBonus.Count - 1].Dessiner("░░░░░░");
                                                            }
                                                            //

                                                            Niveau.ListeBrique.RemoveAt(i);
                                                        }
                                                    }
                                                }
                                            }
                                            for (int i = 0; i < Niveau.ListeBrique.Count; i++)
                                            {
                                                if (Niveau.ListeBrique[i].Bors(listBalle[j]))
                                                {
                                                    if (Niveau.ListeBrique[i].doubleTouche)
                                                    {
                                                        Niveau.ListeBrique[i].premiereTouche();
                                                    }
                                                    else
                                                    {
                                                        // Brique bonus
                                                        nbrRand = rand.Next(0, bonusChance);
                                                        if (nbrRand == 0)
                                                        {
                                                            ListeBriqueBonus.Add(new Brique(Niveau.ListeBrique[i].Xpos, Niveau.ListeBrique[i].Ypos, Niveau.ListeBrique[i].Color, false, true));
                                                            ListeBriqueBonus[ListeBriqueBonus.Count - 1].Dessiner("░░░░░░");
                                                        }
                                                        //

                                                        Niveau.ListeBrique.RemoveAt(i);
                                                    }
                                                }
                                            }
                                        }
                                        //balle.Mouvement(barre.Xpos,barre.largeur);
                                        //if (balle.mouvement)
                                        //{
                                        //    for (int i = 0; i < Niveau.ListeBrique.Count; i++)
                                        //    {
                                        //        if (Niveau.ListeBrique[i].TabPosHaut(balle))
                                        //        {
                                        //            if (Niveau.ListeBrique[i].doubleTouche)
                                        //            {
                                        //                Niveau.ListeBrique[i].premiereTouche();
                                        //            }
                                        //            else
                                        //            {
                                        //                ListeBriqueBonus.Add(new Brique(Niveau.ListeBrique[i].Xpos, Niveau.ListeBrique[i].Ypos, Niveau.ListeBrique[i].Color, false, true));
                                        //                ListeBriqueBonus[ListeBriqueBonus.Count - 1].Dessiner("░░░░░░");
                                        //                Niveau.ListeBrique.RemoveAt(i);
                                        //            }
                                        //        }
                                        //    }
                                        //}
                                        //if (!balle.mouvement)
                                        //{
                                        //    for (int i = 0; i < Niveau.ListeBrique.Count; i++)
                                        //    {
                                        //        if (Niveau.ListeBrique[i].TabPosBas(balle))
                                        //        {
                                        //            if (Niveau.ListeBrique[i].doubleTouche)
                                        //            {
                                        //                Niveau.ListeBrique[i].premiereTouche();
                                        //            }
                                        //            else
                                        //            {
                                        //                Niveau.ListeBrique.RemoveAt(i);
                                        //            }
                                        //        }
                                        //    }
                                        //}
                                        //for (int i = 0; i < Niveau.ListeBrique.Count; i++)
                                        //{
                                        //    if (Niveau.ListeBrique[i].Bors(balle))
                                        //    {
                                        //        if (Niveau.ListeBrique[i].doubleTouche)
                                        //        {
                                        //            Niveau.ListeBrique[i].premiereTouche();
                                        //        }
                                        //        else
                                        //        {
                                        //            Niveau.ListeBrique.RemoveAt(i);
                                        //        }
                                        //    }
                                        //}

                                        sleepcount = 0;
                                    }

                                    //pour listeBalle:
                                    test = true;
                                    for (int i = 0; i < listBalle.Count; i++)
                                    {
                                        if (!listBalle[i].gameOver)
                                        {
                                            test = false;
                                        }
                                        else
                                        {
                                            if (listBalle.Count > 1)
                                            {
                                                listBalle.RemoveAt(i);
                                            }
                                        }
                                    }
                                    //
                                }
                                if (/*balle.gameOver == true*/listBalle.Count < 2 && listBalle[0].gameOver)
                                {
                                    vies--;
                                    ListeBriqueBonus = new List<Brique>();
                                    speed = speedConst;
                                    break;
                                }

                                // Deplacement Barre:
                                key = Console.ReadKey(true).Key;
                                if (key == ConsoleKey.RightArrow && barre.Xpos <= 78 - ((barre.largeur / 2) - 5))
                                {
                                    barre.Effacer();
                                    barre.Xpos += 2;
                                    barre.Dessiner();
                                }
                                else if (key == ConsoleKey.LeftArrow && barre.Xpos >= 11 + ((barre.largeur / 2) - 5))
                                {
                                    barre.Effacer();
                                    barre.Xpos -= 2;
                                    barre.Dessiner();
                                }


                                // PAUSE:
                                else if (key == ConsoleKey.P)
                                {
                                    Console.Clear();
                                    Console.SetCursorPosition((Console.WindowWidth / 2) - ("PAUSE".Length / 2), Console.WindowHeight / 2);
                                    Console.Write("PAUSE");

                                    while (Console.ReadKey(true).Key != ConsoleKey.P) { }

                                    Console.Clear();
                                    Console.SetCursorPosition((Console.WindowWidth / 2) - ("Vie(s) :  ".Length / 2), 0);
                                    Console.Write("Vie(s) : " + vies);
                                    Affichage.Cadre(2, 1);
                                    barre.Dessiner();
                                    //balle.Dessiner();
                                    listBalle[0].Dessiner();
                                    Niveau.Dessiner();
                                }
                                ////TEMP////
                                //Hard Reset
                                else if (key == ConsoleKey.R)
                                {
                                    Niveau.Niveau1();
                                    ListeBriqueBonus = new List<Brique>();
                                    goto hardReset;
                                }
                                //Delete success !!!!!!
                                else if (key == ConsoleKey.Delete)
                                {
                                    Console.SetCursorPosition(0, 0);
                                    Console.Write("                                   ");
                                }
                                //Taille barre + -
                                else if (key == ConsoleKey.PageDown)
                                {
                                    barre.largeur -= 2;
                                }
                                else if (key == ConsoleKey.PageUp)
                                {
                                    barre.largeur += 2;
                                }



                            } while (!Niveau.FinDeNiveau() && vies >= 0);
                        }
                        catch (Exception e)
                        {
                            Console.SetCursorPosition(0, 0);
                            Console.Write(e);

                            Console.ReadLine();
                            listBalle = new List<Balle>();
                            Console.Clear();
                            Console.ResetColor();
                            Console.SetCursorPosition((Console.WindowWidth / 2) - ("Vie(s) :  ".Length / 2), 0);
                            Console.Write("Vie(s) : " + vies);
                            Affichage.Cadre(2, 1);
                            barre.Dessiner();
                            listBalle[0].Dessiner();
                            Niveau.Dessiner();
                        }



                    } while (!Niveau.FinDeNiveau() && vies >= 0);

                    if (vies >= 0)
                    {
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 7, Console.WindowHeight / 2);
                        Console.WriteLine("Niveau terminé !");
                        Console.ReadLine();
                    }


                } while (vies >= 0);


                Console.Clear();
                Console.SetCursorPosition((Console.WindowWidth / 2) - ("GAME OVER".Length / 2), Console.WindowHeight / 2);
                Console.Write("GAME OVER");
                Affichage.AppuyezSurEntree(19);
            } while (true);
        }

    }
}
