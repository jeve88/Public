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
    }
}
