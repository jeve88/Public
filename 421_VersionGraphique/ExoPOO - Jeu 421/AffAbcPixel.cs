using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoPOO___Jeu_421
{
    class AffAbcPixel
    {
        static int curTop;
        static int curLeft;
        public static int lenght;

        public static void AbcPixel(string _Phrase)
        {
            char[] abc = new char[43] { ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '.', ',', '?', '!', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '(', ')' };
            _Phrase = _Phrase.ToLower();
            _Phrase = _Phrase.Replace("è", "e");
            _Phrase = _Phrase.Replace("é", "e");
            _Phrase = _Phrase.Replace("ê", "e");
            _Phrase = _Phrase.Replace("ë", "e");
            _Phrase = _Phrase.Replace("à", "a");
            _Phrase = _Phrase.Replace("ù", "u");
            _Phrase = _Phrase.Replace("î", "i");
            _Phrase = _Phrase.Replace("ô", "o");

            foreach (var item in _Phrase)
            {
                for (int i = 0; i < abc.Length; i++)
                {
                    if (item == abc[i])
                    {
                        switch (i)
                        {
                            case 0: Console.SetCursorPosition(Console.CursorLeft + 3, Console.CursorTop); break;
                            case 1: A(); break;
                            case 2: B(); break;
                            case 3: C(); break;
                            case 4: D(); break;
                            case 5: E(); break;
                            case 6: F(); break;
                            case 7: G(); break;
                            case 8: H(); break;
                            case 9: I(); break;
                            case 10: J(); break;
                            case 11: K(); break;
                            case 12: L(); break;
                            case 13: M(); break;
                            case 14: N(); break;
                            case 15: O(); break;
                            case 16: P(); break;
                            case 17: Q(); break;
                            case 18: R(); break;
                            case 19: S(); break;
                            case 20: T(); break;
                            case 21: U(); break;
                            case 22: V(); break;
                            case 23: W(); break;
                            case 24: X(); break;
                            case 25: Y(); break;
                            case 26: Z(); break;
                            case 27: Point(); break;
                            case 28: Virgule(); break;
                            case 29: PointInterrogation(); break;
                            case 30: PointExclamation(); break;
                            case 31: _0(); break;
                            case 32: _1(); break;
                            case 33: _2(); break;
                            case 34: _3(); break;
                            case 35: _4(); break;
                            case 36: _5(); break;
                            case 37: _6(); break;
                            case 38: _7(); break;
                            case 39: _8(); break;
                            case 40: _9(); break;
                            case 41: parenthèseG(); break;
                            case 42: parenthèseD(); break;
                        }
                    }
                }
            }
        }

        public static int AbcLenght(string _Phrase)
        {
            lenght = 0;
            char[] abc = new char[43] { ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '.', ',', '?', '!', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '(', ')' };
            _Phrase = _Phrase.ToLower();
            _Phrase = _Phrase.Replace("è", "e");
            _Phrase = _Phrase.Replace("é", "e");
            _Phrase = _Phrase.Replace("ê", "e");
            _Phrase = _Phrase.Replace("ë", "e");
            _Phrase = _Phrase.Replace("à", "a");
            _Phrase = _Phrase.Replace("ù", "u");
            _Phrase = _Phrase.Replace("î", "i");
            _Phrase = _Phrase.Replace("ô", "o");

            foreach (var item in _Phrase)
            {
                for (int i = 0; i < abc.Length; i++)
                {
                    if (item == abc[i])
                    {
                        switch (i)
                        {
                            case 0: lenght += 3; break;
                            case 1: lenght += 5; break;
                            case 2: lenght += 5; break;
                            case 3: lenght += 5; break;
                            case 4: lenght += 5; break;
                            case 5: lenght += 5; break;
                            case 6: lenght += 5; break;
                            case 7: lenght += 5; break;
                            case 8: lenght += 5; break;
                            case 9: lenght += 4; break;
                            case 10: lenght += 5; break;
                            case 11: lenght += 5; break;
                            case 12: lenght += 5; break;
                            case 13: lenght += 6; break;
                            case 14: lenght += 5; break;
                            case 15: lenght += 5; break;
                            case 16: lenght += 5; break;
                            case 17: lenght += 6; break;
                            case 18: lenght += 5; break;
                            case 19: lenght += 5; break;
                            case 20: lenght += 6; break;
                            case 21: lenght += 5; break;
                            case 22: lenght += 5; break;
                            case 23: lenght += 6; break;
                            case 24: lenght += 5; break;
                            case 25: lenght += 5; break;
                            case 26: lenght += 5; break;
                            case 27: lenght += 2; break;
                            case 28: lenght += 3; break;
                            case 29: lenght += 4; break;
                            case 30: lenght += 3; break;
                            case 31: lenght += 5; break;
                            case 32: lenght += 4; break;
                            case 33: lenght += 5; break;
                            case 34: lenght += 5; break;
                            case 35: lenght += 5; break;
                            case 36: lenght += 5; break;
                            case 37: lenght += 5; break;
                            case 38: lenght += 5; break;
                            case 39: lenght += 5; break;
                            case 40: lenght += 5; break;
                            case 41: lenght += 3; break;
                            case 42: lenght += 3; break;
                        }
                    }
                }
            }
            return lenght;
        }

        static void A()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;
            lenght += 5;
            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write(" ▄▄  ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("█  █ ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("█▀▀█ ");
        }
        static void B()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;

            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write("▄▄▄  ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("█▄▄▀ ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("█▄▄▀ ");
        }
        static void C()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;

            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write(" ▄▄  ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("█  ▀ ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("▀▄▄▀ ");
        }
        static void D()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;

            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write("▄▄▄  ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("█  █ ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("█▄▄▀ ");
        }
        static void E()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;

            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write("▄▄▄▄ ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("█▄▄  ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("█▄▄▄ ");
        }
        static void F()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;

            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write("▄▄▄▄ ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("█▄▄  ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("█    ");
        }
        static void G()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;

            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write(" ▄▄  ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("█ ▄▄ ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("▀▄▄▀ ");
        }
        static void H()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;

            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write("▄  ▄ ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("█▄▄█ ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("█  █ ");
        }
        static void I()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;
            lenght += 4;
            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write("▄▄▄ ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write(" █  ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("▄█▄ ");
        }
        static void J()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;

            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write("  ▄▄ ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("   █ ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("▀▄▄▀ ");
        }
        static void K()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;

            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write("▄  ▄ ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("█▄▀  ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("█ ▀▄ ");
        }
        static void L()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;

            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write("▄    ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("█    ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("█▄▄▄ ");
        }
        static void M()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;

            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write("▄   ▄ ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("█▀▄▀█ ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("█   █ ");
        }
        static void N()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;

            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write("▄  ▄ ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("█▀▄█ ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("█  █ ");
        }
        static void O()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;

            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write(" ▄▄  ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("█  █ ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("▀▄▄▀ ");
        }
        static void P()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;

            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write("▄▄▄  ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("█▄▄▀ ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("█    ");
        }
        static void Q()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;

            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write(" ▄▄   ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("█  █  ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("▀▄▄█▄ ");
        }
        static void R()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;

            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write("▄▄▄  ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("█▄▄▀ ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("█  █ ");
        }
        static void S()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;

            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write(" ▄▄▄ ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("▀▄▄  ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("▄▄▄▀ ");
        }
        static void T()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;

            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write("▄▄▄▄▄ ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("  █   ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("  █   ");
        }
        static void U()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;

            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write("▄  ▄ ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("█  █ ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("▀▄▄▀ ");
        }
        static void V()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;

            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write("▄  ▄ ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("█  █ ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("▀▄▀  ");
        }
        static void W()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;

            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write("▄   ▄ ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("█ ▄ █ ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("▀▄▀▄▀ ");
        }
        static void X()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;

            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write("▄  ▄ ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("▀█▄▀ ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("█ ▀█ ");
        }
        static void Y()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;

            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write("▄  ▄ ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("█▄▄▀ ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write(" ▄▀  ");
        }
        static void Z()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;

            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write("▄▄▄▄ ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write(" ▄▄▀ ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("█▄▄▄ ");
        }
        static void Point()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;

            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("▄ ");
        }
        static void Virgule()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;

            Console.SetCursorPosition(curLeft, curTop);
            Console.Write(" ▄ ");
            Console.SetCursorPosition(curLeft, curTop + 1);
            Console.Write("▀  ");
            Console.SetCursorPosition(curLeft + 3, curTop);
        }
        static void PointInterrogation()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;
            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write("▄▄▄ ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write(" ▄▀ ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write(" ▄  ");
        }
        static void PointExclamation()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;
            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write(" ▄ ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write(" █ ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write(" ▄ ");
        }
        static void _1()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;
            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write("  ▄ ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("▄▀█ ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("  █ ");
        }
        static void _2()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;
            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write("▄▄▄  ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("  ▄▀ ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("▄█▄▄ ");
        }
        static void _3()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;
            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write("▄▄▄  ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write(" ▄▄▀ ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("▄▄▄▀ ");
        }
        static void _4()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;
            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write("  ▄▄ ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("▄▀ █ ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write(" ▀▀█ ");
        }
        static void _5()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;
            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write(" ▄▄▄ ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("█▄▄  ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("▄▄▄▀ ");
        }
        static void _6()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;
            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write(" ▄▄  ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("█▄▄  ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("▀▄▄▀ ");
        }
        static void _7()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;
            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write("▄▄▄▄ ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("  ▄▀ ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write(" █   ");
        }
        static void _8()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;
            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write(" ▄▄  ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("▀▄▄▀ ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("▀▄▄▀ ");
        }
        static void _9()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;
            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write(" ▄▄  ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("▀▄▄█ ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write(" ▄▄▀ ");
        }
        static void _0()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;
            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write(" ▄▄  ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("█▄ █ ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("▀▄█▀ ");
        }
        static void parenthèseG()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;
            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write("▄▀ ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write("█  ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("▀▄ ");
        }
        static void parenthèseD()
        {
            curTop = Console.CursorTop;
            curLeft = Console.CursorLeft;
            Console.SetCursorPosition(curLeft, curTop - 2);
            Console.Write("▀▄ ");
            Console.SetCursorPosition(curLeft, curTop - 1);
            Console.Write(" █ ");
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write("▄▀ ");
        }
    }
}
