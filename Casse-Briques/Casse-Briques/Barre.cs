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
        public Barre() { }
        public void Dessiner()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(Xpos - 5, Ypos);
            Console.Write("██████████");
            Console.ResetColor();
        }
        public void Effacer()
        {
            Console.SetCursorPosition(Xpos - 5, Ypos);
            Console.Write("          ");
        }
    }
}
