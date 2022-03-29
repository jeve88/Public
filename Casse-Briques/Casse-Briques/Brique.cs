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

        public Brique() { }
        public Brique(int _Xpos, int _Ypos, ConsoleColor _color)
        {
            Xpos = _Xpos;
            Ypos = _Ypos;
            Color = _color;
        }

        public void Dessiner()
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(Xpos - 3, Ypos);
            Console.Write("██████");
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
                if (tabPos[i, 0] == _balle.Ypos && tabPos[i, 1] == _balle.Xpos)
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
                if (tabPos[i, 0] == _balle.Ypos && tabPos[i, 1] == _balle.Xpos)
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
            if (_balle.mouvement && _balle.Xangle<0)
            {
                if (Ypos == _balle.Ypos && Xpos + 4 == _balle.Xpos)
                {
                    Effacer();
                    test = true;
                    _balle.Xangle = -_balle.Xangle;
                }
                else if (Ypos == _balle.Ypos && Xpos + 3 == _balle.Xpos)
                {
                    Effacer();
                    test = true;
                    _balle.Xangle = -_balle.Xangle;
                }
            }
            else if (!_balle.mouvement && _balle.Xangle < 0)  // A checker
            {
                // Console.Write(_balle.Xpos);
                if (Ypos == _balle.Ypos && Xpos + 4 == _balle.Xpos)
                {
                    Effacer();
                    test = true;
                    _balle.Xangle = -_balle.Xangle;
                }
                else if (Ypos == _balle.Ypos && Xpos + 3 == _balle.Xpos)
                {
                    Effacer();
                    test = true;
                    _balle.Xangle = -_balle.Xangle;
                }
            }
            if (_balle.mouvement && _balle.Xangle > 0)
            {
                if (Ypos == _balle.Ypos && Xpos -4 == _balle.Xpos)
                {
                    Effacer();
                    test = true;
                    _balle.Xangle = -_balle.Xangle;
                }
                else if (Ypos == _balle.Ypos && Xpos - 3 == _balle.Xpos)
                {
                    Effacer();
                    test = true;
                    _balle.Xangle = -_balle.Xangle;
                }
            }
            else if (!_balle.mouvement && _balle.Xangle > 0)  // A checker
            {
                if (Ypos == _balle.Ypos && Xpos - 4 == _balle.Xpos)
                {
                    Effacer();
                    test = true;
                    _balle.Xangle = -_balle.Xangle;
                }
                else if (Ypos == _balle.Ypos && Xpos - 3 == _balle.Xpos)
                {
                    Effacer();
                    test = true;
                    _balle.Xangle = -_balle.Xangle;
                }
            }
            return test;
        }

    }
}
