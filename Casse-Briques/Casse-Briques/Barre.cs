using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casse_Briques
{
    class Barre
    {
        public int Xpos = Program.xPos;
        public int Ypos = Program.yPos-1;
        public int largeur = 10; 
        public ConsoleColor color = ConsoleColor.DarkBlue;
        public bool bonusLarg = false;
        public bool malusLarg = false;
        public bool bonus2Balle = false;
        public bool bonus3Balle = false;


        public Barre() { }
        public void Dessiner()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(Xpos - (largeur/2), Ypos);
            for (int i = 0; i < largeur; i++)
            {
                Console.Write("█");
            }
            Console.ResetColor();
        }
        public void Effacer()
        {
            Console.SetCursorPosition(Xpos - (largeur / 2), Ypos);
            for (int i = 0; i < largeur; i++)
            {
                Console.Write(" ");
            }
        }

        public void Bonus(ConsoleColor _color)
        {
            switch (_color)
            {
                case ConsoleColor.Black:
                    break;
                case ConsoleColor.DarkBlue:
                    break;
                case ConsoleColor.DarkGreen:
                    break;
                case ConsoleColor.DarkCyan:
                    break;
                case ConsoleColor.DarkRed:
                    if (bonusLarg==false)
                    {
                        largeur = 14;
                        bonusLarg = true;
                    }
                    break;
                case ConsoleColor.DarkMagenta:
                    break;
                case ConsoleColor.DarkYellow:
                    break;
                case ConsoleColor.Gray:
                    break;
                case ConsoleColor.DarkGray:
                    break;
                case ConsoleColor.Blue:
                    break;
                case ConsoleColor.Green:
                    break;
                case ConsoleColor.Cyan:
                    break;
                case ConsoleColor.Red:
                    break;
                case ConsoleColor.Magenta:
                    break;
                case ConsoleColor.Yellow:
                    break;
                case ConsoleColor.White:
                    break;
                default:
                    break;
            }
        }
    }
}
