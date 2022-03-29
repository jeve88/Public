using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Casse_Briques
{
    class Balle
    {
        public int Xpos = Program.xPos;
        public int Ypos = Program.yPos-2;
        public int Xangle = 2;
        public bool mouvement = true; // true:haut  false:bas 
        public bool gameOver = false;

        public Balle() { }
        public void Dessiner()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(Xpos - 1, Ypos);
            Console.Write("██");
            Console.ResetColor();
        }
        public void Effacer()
        {
            Console.SetCursorPosition(Xpos - 1, Ypos);
            Console.Write("  ");
        }
        public void VersLeHaut()
        {
            if (Xpos <= 83 && Xpos >= 5)
            {
                Effacer();
            }
            Xpos += Xangle;
            Ypos -= 1;
            if (Xpos <= 83 && Xpos >= 5)
            {
                Dessiner();
            }

            if (Ypos == 2)
            {
                mouvement = false;
            }

            if (Xpos <= 5 || Xpos >= 83)
            {
                Xangle = -Xangle;
            }
        }
        public void VersLeBas(int _xBar)
        {
            if (Xpos <= 83 && Xpos >= 5)
            {
                Effacer();
            }
            Xpos += Xangle;
            Ypos += 1;
            if (Xpos <= 83 && Xpos >= 5)
            {
                Dessiner();
            }
            if (Ypos == 29)
            {
                if (_xBar >= Xpos - 5 && _xBar <= Xpos + 5)
                {
                    mouvement = true;
                    Xangle = Xpos - _xBar;
                }
                else
                {
                    Effacer();
                    Xpos += Xangle;
                    Ypos += 1;
                    Dessiner();
                    Thread.Sleep(50);
                    Effacer();
                    Xpos += Xangle;
                    Ypos += 1;
                    Dessiner();
                    Thread.Sleep(500);
                    Effacer();
                    gameOver = true;
                }
            }
            if (Xpos <= 5 || Xpos >= 83)
            {
                Xangle = -Xangle;
            }
        }
        public void Mouvement(int _xBar)
        {
            if (mouvement)
            {
                VersLeHaut();
            }
            else
            {
                VersLeBas(_xBar);
            }
        }
    }
}
