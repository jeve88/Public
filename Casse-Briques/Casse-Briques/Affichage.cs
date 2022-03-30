using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casse_Briques
{
    class Affichage
    {
        public static void Cadre(int _xPos, int _yPos)
        {
            Console.SetCursorPosition(_xPos, _yPos);
            for (int i = 0; i < 84; i++)
            {
                Console.Write("▓");
            }
            for (int i = 1; i < 31; i++)
            {
                Console.SetCursorPosition(_xPos, _yPos + i);
                Console.Write("▓▓");
                Console.SetCursorPosition(_xPos + 82, _yPos + i);
                Console.Write("▓▓");
            }
            Console.SetCursorPosition(_xPos, _yPos + 31);
            for (int i = 0; i < 84; i++)
            {
                Console.Write("▓");
            }
            Console.SetCursorPosition(_xPos, _yPos);
        }

        public static void Start()
        {
            string[] listeAffichageStart = new string[5] { "╔════════════════════════════╗", "║  ▄▄▄ ▄▄▄▄▄  ▄▄  ▄▄▄  ▄▄▄▄▄ ║", "║ ▀▄▄    █   █  █ █▄▄▀   █   ║", "║ ▄▄▄▀   █   █▀▀█ █  █   █   ║", "╚════════════════════════════╝" };
            int xPosStart = (Console.WindowWidth / 2) - (listeAffichageStart[0].Length / 2);
            int yPosStart = Console.WindowHeight / 2 - 5;

            Console.Clear();
            for (int i = 0; i < listeAffichageStart.Length; i++)
            {
                Console.SetCursorPosition(xPosStart, yPosStart + i);
                Console.Write(listeAffichageStart[i]);
            }

            //Console.SetCursorPosition(Console.WindowWidth / 2 - "Appuyez sur[Entrée]".Length / 2 - 1, yPosStart + 6);
            //Console.Write("Appuyez sur [Entrée]");

            ////ConsoleKey key;
            ////do
            ////{
            ////    key = Console.ReadKey(true).Key;
            ////} while (key != ConsoleKey.Enter);

            //while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }

            //Console.Clear();
        }

        public static void AppuyezSurEntree(int _yPos)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - "Appuyez sur[Entrée]".Length / 2 - 1, _yPos);
            Console.Write("Appuyez sur [Entrée]");

            //ConsoleKey key;
            //do
            //{
            //    key = Console.ReadKey(true).Key;
            //} while (key != ConsoleKey.Enter);

            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }

            Console.Clear();
        }
    }
}
