using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casse_Briques
{
    class Brique
    {
        public int Xpos { get; private set; }
        public int Ypos { get; private set; }
        public ConsoleColor Color { get; private set; }
        public ConsoleColor Color2 { get; private set; } // pour doubleTouch
        public bool doubleTouche;
        public bool bonus;
        public int spriteBonus = 1;

        public Brique() { }
        public Brique(int _Xpos, int _Ypos, ConsoleColor _color)
        {
            Xpos = _Xpos;
            Ypos = _Ypos;
            Color = _color;
            doubleTouche = false;
        }

        public Brique(int _Xpos, int _Ypos, ConsoleColor _color, bool _doubleTouche)
        {
            Xpos = _Xpos;
            Ypos = _Ypos;
            Color = ConsoleColor.DarkGray;
            Color2 = _color;
            doubleTouche = _doubleTouche;
        }

        public Brique(int _Xpos, int _Ypos, ConsoleColor _color, bool _doubleTouche, bool _bonus)
        {
            Xpos = _Xpos;
            Ypos = _Ypos;
            Color = _color;
            Color2 = _color;
            doubleTouche = _doubleTouche;
            bonus = _bonus;
        }

        public void premiereTouche()
        {
            doubleTouche = false;
            Color = Color2;
            Dessiner();
        }

        public void bonusDown()
        {
            Effacer();
            Ypos++;
            switch (spriteBonus)
            {
                case 1: Dessiner("▒▒▒▒▒▒"); spriteBonus = 2; break;
                case 2: Dessiner("▓▓▓▓▓▓"); spriteBonus = 1; break;
            }
        }

        public void Dessiner()
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(Xpos - 3, Ypos);
            Console.Write("██████");
            Console.ResetColor();
        }

        public void Dessiner(string _sprite)
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(Xpos - 3, Ypos);
            Console.Write(_sprite);
            Console.ResetColor();
        }

        public void Effacer()
        {
            Console.SetCursorPosition(Xpos - 3, Ypos);
            Console.Write("      ");
        }
        public bool TabPosHaut(Balle _balle)
        {
            bool test = false;
            int[,] tabPos = new int[,]
            {
                {Ypos+1,Xpos-3 },
                {Ypos+1,Xpos-2 },
                {Ypos+1,Xpos-1 },
                {Ypos+1,Xpos },
                {Ypos+1,Xpos+1 },
                {Ypos+1,Xpos+2 },
                {Ypos+1,Xpos+3 },
            };
            for (int i = 0; i < 7; i++)
            {
                if (tabPos[i, 0] == _balle.yPos && tabPos[i, 1] == _balle.xPos)
                {
                    Effacer();
                    _balle.mouvement = false;
                    test = true;
                    break;
                }
            }
            return test;
        }
        public bool TabPosBas(Balle _balle)
        {
            bool test = false;
            int[,] tabPos = new int[,]
            {
                {Ypos-1,Xpos-3 },
                {Ypos-1,Xpos-2 },
                {Ypos-1,Xpos-1 },
                {Ypos-1,Xpos },
                {Ypos-1,Xpos+1 },
                {Ypos-1,Xpos+2 },
                {Ypos-1,Xpos+3 },
            };
            for (int i = 0; i < 7; i++)
            {
                if (tabPos[i, 0] == _balle.yPos && tabPos[i, 1] == _balle.xPos)
                {
                    Effacer();
                    _balle.mouvement = true;
                    test = true;
                    break;
                }
            }
            return test;
        }
        public bool Bors(Balle _balle)
        {
            bool test = false;
            if (_balle.mouvement && _balle.xAngle < 0)
            {
                if (Ypos == _balle.yPos && Xpos + 4 == _balle.xPos)
                {
                    Effacer();
                    test = true;
                    _balle.xAngle = -_balle.xAngle;
                }
                else if (Ypos == _balle.yPos && Xpos + 3 == _balle.xPos)
                {
                    Effacer();
                    test = true;
                    _balle.xAngle = -_balle.xAngle;
                }
            }
            else if (!_balle.mouvement && _balle.xAngle < 0)  // A checker
            {
                // Console.Write(_balle.Xpos);
                if (Ypos == _balle.yPos && Xpos + 4 == _balle.xPos)
                {
                    Effacer();
                    test = true;
                    _balle.xAngle = -_balle.xAngle;
                }
                else if (Ypos == _balle.yPos && Xpos + 3 == _balle.xPos)
                {
                    Effacer();
                    test = true;
                    _balle.xAngle = -_balle.xAngle;
                }
            }
            if (_balle.mouvement && _balle.xAngle > 0)
            {
                if (Ypos == _balle.yPos && Xpos - 4 == _balle.xPos)
                {
                    Effacer();
                    test = true;
                    _balle.xAngle = -_balle.xAngle;
                }
                else if (Ypos == _balle.yPos && Xpos - 3 == _balle.xPos)
                {
                    Effacer();
                    test = true;
                    _balle.xAngle = -_balle.xAngle;
                }
            }
            else if (!_balle.mouvement && _balle.xAngle > 0)  // A checker
            {
                if (Ypos == _balle.yPos && Xpos - 4 == _balle.xPos)
                {
                    Effacer();
                    test = true;
                    _balle.xAngle = -_balle.xAngle;
                }
                else if (Ypos == _balle.yPos && Xpos - 3 == _balle.xPos)
                {
                    Effacer();
                    test = true;
                    _balle.xAngle = -_balle.xAngle;
                }
            }
            return test;
        }

    }
}
