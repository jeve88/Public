using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace ExoPOO___Jeu_421
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey key;
            Console.CursorVisible = false;

            Affichage.Animation(200);
            do
            {
                Console.Clear();
                Affichage.TitrePetit(Console.WindowWidth / 2 - 15, 0);

                ////      Initialisation - Partie/Nombre Manches:
                Console.SetCursorPosition((Console.WindowWidth / 2) - ((AffAbcPixel.AbcLenght("Nombre de manche(s)") / 2)), 10);
                AffAbcPixel.AbcPixel("Nombre de manche(s)");
                string temp = "Entrez un nombre entre 1 et 99";
                Console.SetCursorPosition((Console.WindowWidth / 2) - ((temp.Length / 2)), 12);
                Console.WriteLine(temp);
                Partie partie = new Partie(Affichage.NbrManches(Console.WindowWidth / 2 - 9, 14));
                ////

                //       Début du jeu/NouvelleManche :
                do
                {
                    partie.NouvelleManche();
                    Console.Clear();
                    Affichage.TitrePetit(Console.WindowWidth / 2 - 15, 0);
                    Affichage.CadreJeu();
                    Affichage.CadreInfo(true);

                    DesDisplay deDis1 = new DesDisplay(partie.ListeM[partie.Manche - 1].D1, 1 + Affichage.xPosCadreJeu + (Affichage.largeurCadreJeu - 2) / 5, Affichage.yPosCadreJeu + Affichage.hauteurCadreJeu / 2);
                    DesDisplay deDis2 = new DesDisplay(partie.ListeM[partie.Manche - 1].D2, 1 + Affichage.xPosCadreJeu + (Affichage.largeurCadreJeu - 2) / 2, Affichage.yPosCadreJeu + Affichage.hauteurCadreJeu / 2);
                    DesDisplay deDis3 = new DesDisplay(partie.ListeM[partie.Manche - 1].D3, 2 + Affichage.xPosCadreJeu + ((Affichage.largeurCadreJeu - 2) / 5) * 4, Affichage.yPosCadreJeu + Affichage.hauteurCadreJeu / 2);

                    deDis1.AffDe(ConsoleColor.DarkYellow);
                    deDis2.AffDe(ConsoleColor.DarkYellow);
                    deDis3.AffDe(ConsoleColor.DarkYellow);
                    deDis1.AffValNull();
                    deDis2.AffValNull();
                    deDis3.AffValNull();

                    Affichage.MancheEtPoints(partie);
                    Affichage.CadreJeuInstruction("Appuyer sur [Entrée] pour lancer les dés", false);
                    Selection.ReadKey(ConsoleKey.Enter);
                    Affichage.CadreJeuInstruction("Appuyer sur [Entrée] pour lancer les dés", true);


                    partie.ListeM[partie.Manche - 1].LancerDes();

                    // Cheat Code : 
                    if (partie.NbrManches == 0)
                    {
                        partie.ListeM[0].D1.Valeur = 4;
                        partie.ListeM[0].D2.Valeur = 2;
                        partie.ListeM[0].D3.Valeur = 1;
                    }
                    //

                    Affichage.MancheEtPoints(partie);
                    deDis1.AffRandom(deDis2, deDis3, partie.ListeM[partie.Manche - 1].D1, partie.ListeM[partie.Manche - 1].D2, partie.ListeM[partie.Manche - 1].D3);
                    deDis1.AffValeur(partie.ListeM[partie.Manche - 1].D1.Valeur);
                    deDis2.AffValeur(partie.ListeM[partie.Manche - 1].D2.Valeur);
                    deDis3.AffValeur(partie.ListeM[partie.Manche - 1].D3.Valeur);
                    Thread.Sleep(1000);

                    Affichage.CadreInfo(true);
                    if (partie.Manche==1)
                    {
                    Affichage.Instructions();
                    }
                    else
                    {
                        Affichage.CadreInfo(true);
                        Affichage.MancheEtPoints(partie);
                    }

                    bool tempElse = false;
                    while (!partie.ListeM[partie.Manche - 1].Check421() && partie.ListeM[partie.Manche - 1].RelancePossible())
                    {
                        bool relance1 = false;
                        bool relance2 = false;
                        bool relance3 = false;


                        if (!tempElse)
                        {
                            Affichage.CadreJeuInstruction("Sélection: [◄] [►] + [Espace]    Valider: [Entrée]", false);
                            Selection.Select(deDis1, deDis2, deDis3, ref relance1, ref relance2, ref relance3);
                            Affichage.CadreJeuInstruction("Sélection: [◄] [►] + [Espace]    Valider: [Entrée]", true);
                        }
                        else
                        {
                            Affichage.CadreJeuInstruction("Veuillez sélectionner au moins un dé !", false);
                            Selection.Select(deDis1, deDis2, deDis3, ref relance1, ref relance2, ref relance3);
                            Affichage.CadreJeuInstruction("Veuillez sélectionner au moins un dé !", true);
                            tempElse = false;
                        }

                        Affichage.CadreInfo(true);
                        Affichage.MancheEtPoints(partie);


                        if (relance1 && !relance2 && !relance3)
                        {
                            partie.ListeM[partie.Manche - 1].Relancer1De(1);
                            Affichage.CadreInfo(true);
                            Affichage.MancheEtPoints(partie);
                            deDis1.AffRandom(partie.ListeM[partie.Manche - 1].D1);
                        }
                        else if (!relance1 && relance2 && !relance3)
                        {
                            partie.ListeM[partie.Manche - 1].Relancer1De(2);
                            Affichage.CadreInfo(true);
                            Affichage.MancheEtPoints(partie);
                            deDis2.AffRandom(partie.ListeM[partie.Manche - 1].D2);
                        }
                        else if (!relance1 && !relance2 && relance3)
                        {
                            partie.ListeM[partie.Manche - 1].Relancer1De(3);
                            Affichage.CadreInfo(true);
                            Affichage.MancheEtPoints(partie);
                            deDis3.AffRandom(partie.ListeM[partie.Manche - 1].D3);
                        }
                        else if (relance1 && relance2 && !relance3)
                        {
                            partie.ListeM[partie.Manche - 1].Relancer2De(1, 2);
                            Affichage.CadreInfo(true);
                            Affichage.MancheEtPoints(partie);
                            deDis1.AffRandom(deDis2, partie.ListeM[partie.Manche - 1].D1, partie.ListeM[partie.Manche - 1].D2);
                        }
                        else if (relance1 && !relance2 && relance3)
                        {
                            partie.ListeM[partie.Manche - 1].Relancer2De(1, 3);
                            Affichage.CadreInfo(true);
                            Affichage.MancheEtPoints(partie);
                            deDis1.AffRandom(deDis3, partie.ListeM[partie.Manche - 1].D1, partie.ListeM[partie.Manche - 1].D3);
                        }
                        else if (!relance1 && relance2 && relance3)
                        {
                            partie.ListeM[partie.Manche - 1].Relancer2De(2, 3);
                            Affichage.CadreInfo(true);
                            Affichage.MancheEtPoints(partie);
                            deDis2.AffRandom(deDis3, partie.ListeM[partie.Manche - 1].D2, partie.ListeM[partie.Manche - 1].D3);
                        }
                        else if (relance1 && relance2 && relance3)
                        {
                            partie.ListeM[partie.Manche - 1].LancerDes();
                            Affichage.CadreInfo(true);
                            Affichage.MancheEtPoints(partie);
                            deDis1.AffRandom(deDis2, deDis3, partie.ListeM[partie.Manche - 1].D1, partie.ListeM[partie.Manche - 1].D2, partie.ListeM[partie.Manche - 1].D3);
                        }
                        else
                        {
                            tempElse = true;
                        }
                    }


                    if (partie.ListeM[partie.Manche - 1].Check421() == true)
                    {
                        Affichage.Gagne();
                        partie.Points += 30;
                    }
                    else
                    {
                        Affichage.Perdu();
                        partie.Points -= 10;
                    }

                    if (partie.FinDePartie() == false)
                    {
                        Affichage.CadreJeuInstruction("Appuyez sur [Entrée] pour passer à la manche suivante", false);
                        Selection.ReadKey(ConsoleKey.Enter);
                    }

                } while (partie.FinDePartie() == false);

                Affichage.CadreJeuInstruction("Fin de partie !", false);
                Console.SetCursorPosition(23, Console.WindowHeight - 1);
                Console.Write("Nouvelle partie: [Entrée]   Quitter: [Echap]");
                do
                {
                    key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Escape)
                    {
                        break;
                    }
                } while (key != ConsoleKey.Enter);

            } while (key == ConsoleKey.Enter);
        }
    }
}
