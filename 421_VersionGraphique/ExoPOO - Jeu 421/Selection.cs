using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoPOO___Jeu_421
{
    public class Selection
    {        
        public static void Select(DesDisplay _d1, DesDisplay _d2, DesDisplay _d3,ref bool _relance1, ref bool _relance2, ref bool _relance3)
        {
            ConsoleKey lettre;
            int cadreSelect = 2;
            _relance1 = false;
            _relance2 = false;
            _relance3 = false;
            
            _d2.AffCadreDe();
            do
            {
                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                lettre = Console.ReadKey().Key;
                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                Console.Write(" ");

                if (lettre == ConsoleKey.RightArrow)
                {
                    switch (cadreSelect)
                    {
                        case 1:
                            _d1.ErraseCadreDe();
                            _d2.AffCadreDe();
                            cadreSelect = 2;
                            break;
                        case 2:
                            _d2.ErraseCadreDe();
                            _d3.AffCadreDe();
                            cadreSelect = 3;
                            break;
                        case 3:
                            _d3.ErraseCadreDe();
                            _d1.AffCadreDe();
                            cadreSelect = 1;
                            break;
                    }
                }
                if (lettre == ConsoleKey.LeftArrow)
                {
                    switch (cadreSelect)
                    {
                        case 1:
                            _d1.ErraseCadreDe();
                            _d3.AffCadreDe();
                            cadreSelect = 3;
                            break;
                        case 2:
                            _d2.ErraseCadreDe();
                            _d1.AffCadreDe();
                            cadreSelect = 1;
                            break;
                        case 3:
                            _d3.ErraseCadreDe();
                            _d2.AffCadreDe();
                            cadreSelect = 2;
                            break;
                    }
                }
                if (lettre == ConsoleKey.Spacebar)
                {
                    switch (cadreSelect)
                    {
                        case 1:
                            if (_relance1)
                            {
                                _d1.AffDe(ConsoleColor.Gray);
                                _relance1 = false;
                            }
                            else
                            {
                                _d1.AffDe(ConsoleColor.DarkRed);
                                _relance1 = true;
                            }
                            break;
                        case 2:
                            if (_relance2)
                            {
                                _d2.AffDe(ConsoleColor.Gray);
                                _relance2 = false;
                            }
                            else
                            {
                                _d2.AffDe(ConsoleColor.DarkRed);
                                _relance2 = true;
                            }
                            break;
                        case 3:
                            if (_relance3)
                            {
                                _d3.AffDe(ConsoleColor.Gray);
                                _relance3 = false;
                            }
                            else
                            {
                                _d3.AffDe(ConsoleColor.DarkRed);
                                _relance3 = true;
                            }
                            break;
                    }
                }
            } while (lettre != ConsoleKey.Enter);

            switch (cadreSelect)
            {
                case 1:
                    _d1.ErraseCadreDe();                  
                    break;
                case 2:
                    _d2.ErraseCadreDe();
                    break;
                case 3:
                    _d3.ErraseCadreDe();
                    break;
            }
        }

       public static void ReadKey(ConsoleKey _key)
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
            } while (key != _key);
        }




    }
}
