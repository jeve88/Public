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
        public int xPos = Program.xPos;
        public int yPos = Program.yPos - 2;
        public int xAngle = 2;
        public bool mouvement = true; // true:haut  false:bas 
        public bool gameOver = false;

        public Balle() { }
        public Balle(int _xPos, int _yPos, int _angle, bool _mouvement)
        {
            xPos = _xPos;
            yPos = _yPos;
            xAngle = _angle;
            mouvement = _mouvement;
        }
        public void Dessiner()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(xPos - 1, yPos);
                Console.Write("██");
                Console.ResetColor();
            }
            catch (Exception)
            {
                Console.ResetColor();
            }

        }
        public void Effacer()
        {
            try
            {
                Console.SetCursorPosition(xPos - 1, yPos);
                Console.Write("  ");
            }
            catch (Exception)
            {

            }

        }
        public void VersLeHaut()
        {
            try
            {
                if (xPos <= 83 && xPos >= 5)
                {
                    Effacer();
                }
                xPos += xAngle;
                yPos -= 1;
                if (xPos <= 83 && xPos >= 5)
                {
                    Dessiner();
                }

                if (yPos == 2)
                {
                    mouvement = false;
                }

                if (xPos <= 5 || xPos >= 83)
                {
                    xAngle = -xAngle;
                }
            }
            catch (Exception)
            {
            }

        }
        public void VersLeBas(int _xBar, int _largBarre)
        {
            try
            {
                if (xPos <= 83 && xPos >= 5)
                {
                    Effacer();
                }
                xPos += xAngle;
                yPos += 1;
                if (xPos <= 83 && xPos >= 5)
                {
                    Dessiner();
                }
                if (yPos == 29)
                {
                    if (_xBar >= xPos - (_largBarre / 2) && _xBar <= xPos + (_largBarre / 2))
                    {
                        mouvement = true;
                        xAngle = xPos - _xBar;
                        if (xAngle < -4) xAngle = -4;
                        if (xAngle > 4) xAngle = 4;
                    }
                    else
                    {
                        Effacer();
                        xPos += xAngle;
                        yPos += 1;
                        Dessiner();
                        Thread.Sleep(50);
                        Effacer();
                        xPos += xAngle;
                        yPos += 1;
                        Dessiner();
                        Thread.Sleep(500);
                        Effacer();
                        gameOver = true;
                    }
                }
                if (xPos <= 5 || xPos >= 83)
                {
                    xAngle = -xAngle;
                }
            }
            catch (Exception)
            {
            }

        }
        public void Mouvement(int _xBar, int _largBarre)
        {
            try
            {
                if (mouvement)
                {
                    VersLeHaut();
                }
                else
                {
                    VersLeBas(_xBar, _largBarre);
                }
            }
            catch (Exception)
            {
            }

        }
    }
}
