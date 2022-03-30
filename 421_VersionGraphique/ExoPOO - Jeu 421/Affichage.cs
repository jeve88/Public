using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExoPOO___Jeu_421
{
    public class Affichage
    {
        public static void TitrePetit(int _xPosition, int _yPosition)  // longueur 29
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(_xPosition, _yPosition);
            Console.Write("╔═══════════════════════════╗");
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(_xPosition, _yPosition + 1 + i);
                Console.Write("║                           ║");
            }
            Console.SetCursorPosition(_xPosition, _yPosition + 6);
            Console.Write("╚═══════════════════════════╝");

            Console.ForegroundColor = ConsoleColor.Red;
            string[] titre = new string[5] { "    ▒▒  ▒▒▒▒▒    ▒▒▒ ", "  ▒▒▒▒  ▒   ▒▒ ▒▒ ▒▒ ", " ▒▒ ▒▒     ▒▒     ▒▒ ", "▒▒▒▒▒▒▒  ▒▒       ▒▒ ", "    ▒▒  ▒▒▒▒▒▒  ▒▒▒▒▒" };
            for (int i = 0; i < titre.Length; i++)
            {
                Console.SetCursorPosition(_xPosition + 4, _yPosition + 1 + i);
                Console.Write(titre[i]);
            }
            Console.ResetColor();
        }
        public static void TitreGrand(int _xPosition, int _yPosition)  //longueur 56
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            string[] cadre = new string[12] { "╔══════════════════════════════════════════════════════╗", "║                                                      ║", "║                                                      ║", "║                                                      ║", "║                                                      ║", "║                                                      ║", "║                                                      ║", "║                                                      ║", "║                                                      ║", "║                                                      ║", "║                                                      ║", "╚══════════════════════════════════════════════════════╝" };
            for (int i = 0; i < cadre.Length; i++)
            {
                Console.SetCursorPosition(_xPosition, _yPosition + i);
                Console.Write(cadre[i]);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            string[] cadre421 = new string[10] { "          ▒▒▒▒▒▒       ▒▒▒▒▒▒▒▒▒▒▒▒         ▒▒▒▒    ", "        ▒▒▒▒▒▒▒▒     ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒     ▒▒▒▒▒▒    ", "      ▒▒▒▒▒▒▒▒▒▒     ▒▒▒▒        ▒▒▒▒   ▒▒▒▒▒▒▒▒    ", "    ▒▒▒▒▒▒  ▒▒▒▒               ▒▒▒▒▒▒       ▒▒▒▒    ", "  ▒▒▒▒▒▒    ▒▒▒▒             ▒▒▒▒▒▒         ▒▒▒▒    ", "▒▒▒▒▒▒      ▒▒▒▒           ▒▒▒▒▒▒           ▒▒▒▒    ", "▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒       ▒▒▒▒▒▒             ▒▒▒▒    ", "▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒     ▒▒▒▒▒▒               ▒▒▒▒    ", "            ▒▒▒▒     ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒   ▒▒▒▒▒▒▒▒▒▒▒▒", "            ▒▒▒▒     ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒   ▒▒▒▒▒▒▒▒▒▒▒▒" };
            for (int i = 0; i < cadre421.Length; i++)
            {
                Console.SetCursorPosition(_xPosition + 2, _yPosition + 1 + i);
                Console.Write(cadre421[i]);
            }
            Console.ResetColor();
        }
        public static int NbrManches(int xPosition, int yPosition)
        {
            string[] cadreNbr = new string[5] { "▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄", "█               █", "█               █", "█               █", "█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█" };
            ConsoleKey key;
            ConsoleKey[,] liste09 = new ConsoleKey[2, 10] { { ConsoleKey.NumPad0, ConsoleKey.NumPad1, ConsoleKey.NumPad2, ConsoleKey.NumPad3, ConsoleKey.NumPad4, ConsoleKey.NumPad5, ConsoleKey.NumPad6, ConsoleKey.NumPad7, ConsoleKey.NumPad8, ConsoleKey.NumPad9 }, { ConsoleKey.D0, ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.D4, ConsoleKey.D5, ConsoleKey.D6, ConsoleKey.D7, ConsoleKey.D8, ConsoleKey.D9 } };
            bool check = false;
            string chiffre1;
            string chiffre2;

        Point1:
            chiffre1 = "";

            //Affiche cadre / Efface interieur cadre)
            for (int i = 0; i < cadreNbr.Length; i++)
            {
                Console.SetCursorPosition(xPosition, yPosition + i);
                Console.Write(cadreNbr[i]);
            }
            //

            Console.CursorVisible = true;
            do
            {
                //Capture touche invisible:
                Console.SetCursorPosition(xPosition + 8, yPosition + 3);
                key = Console.ReadKey().Key;
                Console.SetCursorPosition(xPosition + 8, yPosition + 3);
                Console.Write(" ");
                //

                for (int i = 0; i < 10; i++)
                {
                    if (liste09[0, i] == key || liste09[1, i] == key)
                    {
                        check = true;
                        chiffre1 = Convert.ToString(i);
                    }
                }
            } while (check == false);

        Point2:
            chiffre2 = "";
            do
            {
                // Efface interieur cadre:
                for (int i = 0; i < cadreNbr.Length; i++)
                {
                    Console.SetCursorPosition(xPosition, yPosition + i);
                    Console.Write(cadreNbr[i]);
                }//

                Console.SetCursorPosition(xPosition + 6, yPosition + 3);
                AffAbcPixel.AbcPixel(chiffre1);

                check = false;

                //Capture touche invisible:
                Console.SetCursorPosition(xPosition + 12, yPosition + 3);
                key = Console.ReadKey().Key;
                Console.SetCursorPosition(xPosition + 12, yPosition + 3);
                Console.Write(" ");
                //

                for (int i = 0; i < 10; i++)
                {
                    if (liste09[0, i] == key || liste09[1, i] == key)
                    {
                        check = true;
                        chiffre2 = Convert.ToString(i);
                    }
                }
                if (key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (key == ConsoleKey.Backspace)
                {
                    goto Point1;
                }
                if (check)
                {
                    //efface cadre:
                    for (int i = 0; i < cadreNbr.Length; i++)
                    {
                        Console.SetCursorPosition(xPosition, yPosition + i);
                        Console.Write(cadreNbr[i]);
                    }//
                }
            } while (check == false);

            if (key != ConsoleKey.Enter)
            {
                Console.SetCursorPosition(xPosition + 4, yPosition + 3);
                AffAbcPixel.AbcPixel(chiffre1 + chiffre2);

                do
                {
                    //Capture touche invisible:
                    Console.SetCursorPosition(xPosition + 14, yPosition + 3);
                    key = Console.ReadKey().Key;
                    Console.SetCursorPosition(xPosition + 14, yPosition + 3);
                    Console.Write(" ");
                    //

                    if (key == ConsoleKey.Backspace)
                    {
                        goto Point2;
                    }
                } while (key != ConsoleKey.Enter);
            }

            Console.CursorVisible = false;

            return Convert.ToInt32(chiffre1 + chiffre2);

        }
        public static int hauteurCadreJeu = 21;
        public static int largeurCadreJeu = 79;
        public static int xPosCadreJeu = (Console.WindowWidth / 20);
        public static int yPosCadreJeu = (7 + Console.WindowHeight / 20);
        public static void CadreJeu()
        {
            Console.SetCursorPosition(xPosCadreJeu, yPosCadreJeu);
            Console.Write("╔");
            for (int i = 0; i < largeurCadreJeu - 2; i++)
            {
                Console.Write("═");
            }
            Console.Write("╗");
            for (int i = 1; i < hauteurCadreJeu - 1; i++)
            {
                Console.SetCursorPosition(xPosCadreJeu, yPosCadreJeu + i);
                Console.Write("║");
                Console.SetCursorPosition(xPosCadreJeu + largeurCadreJeu - 1, yPosCadreJeu + i);
                Console.Write("║");
            }
            Console.SetCursorPosition(xPosCadreJeu, yPosCadreJeu + hauteurCadreJeu - 1);
            Console.Write("╚");
            for (int i = 0; i < largeurCadreJeu - 2; i++)
            {
                Console.Write("═");
            }
            Console.Write("╝");
        }
        public static void CadreJeuInstruction(string _texte, bool _effacer)
        {
            if (!_effacer)
            {
                Console.SetCursorPosition(Affichage.xPosCadreJeu + (Affichage.largeurCadreJeu / 2) - (_texte.Length / 2) - 2, Affichage.yPosCadreJeu + Affichage.hauteurCadreJeu - 4);
                Console.Write("┌");
                for (int i = 0; i < _texte.Length + 2; i++)
                {
                    Console.Write("─");
                }
                Console.Write("┐");
                Console.SetCursorPosition(Affichage.xPosCadreJeu + (Affichage.largeurCadreJeu / 2) - (_texte.Length / 2) - 2, Affichage.yPosCadreJeu + Affichage.hauteurCadreJeu - 3);
                Console.Write("│ {0} │", _texte);
                Console.SetCursorPosition(Affichage.xPosCadreJeu + (Affichage.largeurCadreJeu / 2) - (_texte.Length / 2) - 2, Affichage.yPosCadreJeu + Affichage.hauteurCadreJeu - 2);
                Console.Write("└");
                for (int i = 0; i < _texte.Length + 2; i++)
                {
                    Console.Write("─");
                }
                Console.Write("┘");
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.SetCursorPosition(Affichage.xPosCadreJeu + (Affichage.largeurCadreJeu / 2) - (_texte.Length / 2) - 2, Affichage.yPosCadreJeu + Affichage.hauteurCadreJeu - 4+i);
                    for (int j = 0; j < _texte.Length + 4; j++)
                    {
                        Console.Write(" ");
                    }
                }             
            }
        }
        public static void CadreInfo(bool _effacer)
        {
            int hauteur = 20;
            int largeur = 26;
            int xPos = (Console.WindowWidth - largeur) - (Console.WindowWidth / 20);
            int yPos = 8 + Console.WindowHeight / 20;
            if (!_effacer)
            {
                Console.SetCursorPosition(xPos, yPos);
                Console.Write("╔");
                for (int i = 0; i < largeur - 2; i++)
                {
                    Console.Write("═");
                }
                Console.Write("╗");
                for (int i = 1; i < hauteur - 1; i++)
                {
                    Console.SetCursorPosition(xPos, yPos + i);
                    Console.Write("║");
                    Console.SetCursorPosition(xPos + largeur - 1, yPos + i);
                    Console.Write("║");
                }
                Console.SetCursorPosition(xPos, yPos + hauteur - 1);
                Console.Write("╚");
                for (int i = 0; i < largeur - 2; i++)
                {
                    Console.Write("═");
                }
                Console.Write("╝");
            }
            else
            {
                Console.SetCursorPosition(xPos, yPos);
                Console.Write("╔");
                for (int i = 0; i < largeur - 2; i++)
                {
                    Console.Write("═");
                }
                Console.Write("╗");
                for (int i = 1; i < hauteur - 1; i++)
                {
                    Console.SetCursorPosition(xPos, yPos + i);
                    Console.Write("║");
                    for (int j = 0; j < largeur - 2; j++)
                    {
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(xPos + largeur - 1, yPos + i);
                    Console.Write("║");
                }
                Console.SetCursorPosition(xPos, yPos + hauteur - 1);
                Console.Write("╚");
                for (int i = 0; i < largeur - 2; i++)
                {
                    Console.Write("═");
                }
                Console.Write("╝");
            }
        }
        public static void Instructions()
        {
            int xPos = (Console.WindowWidth - 26) - (Console.WindowWidth / 20) + 1;
            int yPos = 8 + (Console.WindowHeight / 20) + 1;

            Console.SetCursorPosition(xPos, yPos + 1);
            Console.Write("    Relance des dés :");
            Console.SetCursorPosition(xPos, yPos + 2);
            Console.Write("(Deux relances possible)");
            Console.SetCursorPosition(xPos, yPos + 6);
            Console.Write(" Choisir un, deux ou");
            Console.SetCursorPosition(xPos, yPos + 7);
            Console.Write(" trois dés à relancer.");
            Console.SetCursorPosition(xPos, yPos + 10);
            Console.Write(" Appuyez sur [Entrée]");
            Console.SetCursorPosition(xPos, yPos + 11);
            Console.Write(" pour relancer les dés");
            Console.SetCursorPosition(xPos, yPos + 12);
            Console.Write(" sélectionnés...");
        }
        public static void MancheEtPoints(Partie _partie)
        {
            int xPos = (Console.WindowWidth - 26) - (Console.WindowWidth / 20) - 1;
            int yPos = 8 + (Console.WindowHeight / 20) - 1;
            //         ┌ ┘ ┐ └  ─  │
            Console.SetCursorPosition(xPos + 4, yPos + 2);
            Console.Write("╔══════════════════╗");
            Console.SetCursorPosition(xPos + 4, yPos + 3);
            Console.Write("║    ┌────────┐    ║");
            Console.SetCursorPosition(xPos + 4, yPos + 4);
            Console.Write("║    │ Manche │    ║");
            Console.SetCursorPosition(xPos + 4, yPos + 5);
            Console.Write("║    └────────┘    ║");
            Console.SetCursorPosition(xPos + 4, yPos + 6);
            Console.Write("║                  ║");
            Console.SetCursorPosition(xPos + 4, yPos + 7);
            Console.Write("╚══════════════════╝");
            Console.SetCursorPosition(xPos + 4, yPos + 8);
            Console.Write("╔══════════════════╗");
            Console.SetCursorPosition(xPos + 4, yPos + 9);
            Console.Write("║    ┌────────┐    ║");
            Console.SetCursorPosition(xPos + 4, yPos + 10);
            Console.Write("║    │ Points │    ║");
            Console.SetCursorPosition(xPos + 4, yPos + 11);
            Console.Write("║    └────────┘    ║");
            Console.SetCursorPosition(xPos + 4, yPos + 12);
            Console.Write("║                  ║");
            Console.SetCursorPosition(xPos + 4, yPos + 13);
            Console.Write("╚══════════════════╝");
            Console.SetCursorPosition(xPos + 4, yPos + 14);
            Console.Write("╔══════════════════╗");
            Console.SetCursorPosition(xPos + 4, yPos + 15);
            Console.Write("║    ┌────────┐    ║");
            Console.SetCursorPosition(xPos + 4, yPos + 16);
            Console.Write("║    │ Lancer │    ║");
            Console.SetCursorPosition(xPos + 4, yPos + 17);
            Console.Write("║    └────────┘    ║");
            Console.SetCursorPosition(xPos + 4, yPos + 18);
            Console.Write("║                  ║");
            Console.SetCursorPosition(xPos + 4, yPos + 19);
            Console.Write("╚══════════════════╝");

            if (_partie.NbrManches < 10)
            {
                Console.SetCursorPosition(xPos + 11, yPos + 6);
                Console.Write("{0} / {1}", _partie.Manche, _partie.NbrManches);
            }
            else
            {
                Console.SetCursorPosition(xPos + 10, yPos + 6);
                if (_partie.Manche < 10)
                {
                    Console.Write("0{0} / {1}", _partie.Manche, _partie.NbrManches);
                }
                else
                {
                    Console.Write("{0} / {1}", _partie.Manche, _partie.NbrManches);
                }
            }

            if (_partie.Points < 100)
            {

                Console.SetCursorPosition(xPos + 13, yPos + 12);
                Console.Write(_partie.Points);
            }
            else if (_partie.Points == 0)
            {
                Console.SetCursorPosition(xPos + 13, yPos + 12);
                Console.Write("00");
            }
            else
            {
                Console.SetCursorPosition(xPos + 12, yPos + 12);
                Console.Write(_partie.Points);
            }
            Console.SetCursorPosition(xPos + 11, yPos + 18);
            Console.Write("{0} / 3", _partie.ListeM[_partie.Manche - 1].countRelance);
        }
        public static void Animation(int _speed)
        {
            string[] listeAffichageStart = new string[5] { "╔════════════════════════════╗", "║  ▄▄▄ ▄▄▄▄▄  ▄▄  ▄▄▄  ▄▄▄▄▄ ║", "║ ▀▄▄    █   █  █ █▄▄▀   █   ║", "║ ▄▄▄▀   █   █▀▀█ █  █   █   ║", "╚════════════════════════════╝" };
            int xPosStart = (Console.WindowWidth / 2) - (listeAffichageStart[0].Length / 2);
            int yPosStart = Console.WindowHeight / 2 - 5;

            for (int i = 0; i < listeAffichageStart.Length; i++)
            {
                Console.SetCursorPosition(xPosStart, yPosStart + i);
                Console.Write(listeAffichageStart[i]);
            }

            Console.SetCursorPosition(Console.WindowWidth / 2 - "Appuyez sur[Entrée]".Length / 2 - 1, yPosStart + 6);
            Console.Write("Appuyez sur [Entrée]");
            Selection.ReadKey(ConsoleKey.Enter);
            Console.Clear();

            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            int sleep = _speed; // ==>200
            int xPos = (Console.WindowWidth / 2) - 60;
            //int xPos = 0;
            int yPos = 3;

            for (int i = 0; i < 2; i++)
            {
                DesAnim(1, xPos, yPos);
                Thread.Sleep(sleep);
                Console.Clear();
                xPos += 4;
                yPos++;
                DesAnim(2, xPos, yPos);
                Thread.Sleep(sleep);
                Console.Clear();
                xPos += 4;
                yPos++;
            }
            for (int i = 0; i < 2; i++)
            {
                DesAnim(4, xPos, yPos);
                Thread.Sleep(Convert.ToInt32(sleep * 1.5));
                Console.Clear();
                xPos += 4;
                yPos++;
                DesAnim(3, xPos, yPos);
                Thread.Sleep(Convert.ToInt32(sleep * 1.5));
                Console.Clear();
                xPos += 4;
                yPos++;
            }
            DesAnim(5, xPos, yPos);
            Thread.Sleep(sleep * 2);
            Console.Clear();
            xPos += 4;
            yPos++;
            DesAnim(6, xPos, yPos);
            Thread.Sleep(Convert.ToInt32(sleep * 2.5));
            Console.Clear();
            xPos += 4;
            yPos++;
            DesAnim(5, xPos, yPos);
            Thread.Sleep(sleep * 3);
            Console.Clear();
            xPos += 4;
            yPos++;

            DesAnim(6, Console.WindowWidth / 2 - 13, yPos);
            //Affichage.Des6(xPos, yPos);
            Thread.Sleep(1000);

            TitreGrand(Console.WindowWidth / 2 - 28, 1);
            Thread.Sleep(3000);
            Console.Clear();
        }
        public static void DesAnim(int _numDe, int _xPos, int _yPos)
        {
            string[] draw;
            switch (_numDe)
            {
                case 1:
                    draw = new string[5] { "  ____  ", " /\\' .\\ ", "/: \\___\\", "\\' / . /", " \\/___/ " };
                    for (int i = 0; i < draw.Length; i++)
                    {
                        Console.SetCursorPosition(_xPos, _yPos + i);
                        Console.Write(draw[i]);
                    }
                    break;
                case 2:
                    draw = new string[5] { "  _____  ", " / .  /\\ ", "/____/..\\", "\\'  '\\  /", " \\'__'\\/ " };
                    for (int i = 0; i < draw.Length; i++)
                    {
                        Console.SetCursorPosition(_xPos, _yPos + i);
                        Console.Write(draw[i]);
                    }
                    break;
                case 3:
                    draw = new string[7] { "   _______   ", "  /O     /\\  ", " /   O  /O \\ ", "/_____O/    \\", "\\O    O\\    /", " \\O    O\\ O/ ", "  \\O____O\\/  " };
                    for (int i = 0; i < draw.Length; i++)
                    {
                        Console.SetCursorPosition(_xPos, _yPos + i);
                        Console.Write(draw[i]);
                    }
                    break;
                case 4:
                    draw = new string[7] { "   _______   ", "  /\\O    O\\  ", " /  \\      \\ ", "/ O  \\O____O\\", "\\    /O     /", " \\  /   O  / ", "  \\/_____O/  " };
                    for (int i = 0; i < draw.Length; i++)
                    {
                        Console.SetCursorPosition(_xPos, _yPos + i);
                        Console.Write(draw[i]);
                    }
                    break;
                case 5:
                    draw = new string[13] { "       ____________       ", "     /\\             \\     ", "    /  \\  ()      () \\    ", "   /    \\             \\   ", "  /      \\             \\  ", " /        \\  ()     ()  \\ ", "/    ()    \\ ____________\\", "\\          / ()          /", " \\        /             / ", "  \\      /     ()      /  ", "   \\    /             /   ", "    \\  /          () /    ", "     \\/_____________/     " };
                    for (int i = 0; i < draw.Length; i++)
                    {
                        Console.SetCursorPosition(_xPos, _yPos + i);
                        Console.Write(draw[i]);
                    }
                    break;
                case 6:
                    string[] des = new string[13] { "       ____________       ", "     /             /\\     ", "    /  ()      () /  \\    ", "   /             /    \\   ", "  /             /      \\  ", " / ()      ()  /        \\ ", "/____________ /    ()    \\", "\\             \\          /", " \\         ()  \\        / ", "  \\             \\      /  ", "   \\             \\    /   ", "    \\   ()        \\  /    ", "     \\ ____________\\/     " };
                    for (int i = 0; i < des.Length; i++)
                    {
                        Console.SetCursorPosition(_xPos, _yPos + i);
                        Console.Write(des[i]);
                    }
                    break;
            }
        }
        public static void Gagne()
        {
            string[] gagne = new string[4] { "                     ▄▀     ", " ▄▄   ▄▄   ▄▄  ▄  ▄ ▄▄▄▄   ▄", "█ ▄▄ █  █ █ ▄▄ █▀▄█ █▄▄    █", "▀▄▄▀ █▀▀█ ▀▄▄▀ █  █ █▄▄▄   ▄" };
            int xPos = xPosCadreJeu+1 + (largeurCadreJeu / 2) - (gagne[0].Length / 2);
            int yPos = yPosCadreJeu + 1;

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            for (int i = 0; i < gagne.Length; i++)
            {
                Console.SetCursorPosition(xPos, yPos + i);
                Console.Write(gagne[i]);
            }
            Console.ResetColor();
        }
        public static void Perdu()
        {
            string[] perdu = new string[3] { "▄▄▄  ▄▄▄▄ ▄▄▄  ▄▄▄  ▄  ▄  ▄", "█▄▄▀ █▄▄  █▄▄▀ █  █ █  █  █", "█    █▄▄▄ █  █ █▄▄▀ ▀▄▄▀  ▄" };
            int xPos = xPosCadreJeu + (largeurCadreJeu / 2) - (perdu[0].Length / 2);
            int yPos = yPosCadreJeu + 1;

            Console.ForegroundColor = ConsoleColor.DarkRed;
            for (int i = 0; i < perdu.Length; i++)
            {
                Console.SetCursorPosition(xPos, yPos + i);
                Console.Write(perdu[i]);
            }
            Console.ResetColor();
        }
    }
}
