using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ExoPOO___Jeu_421
{
    public class DesDisplay
    {
        public int xPos { get; private set; }
        public int yPos { get; private set; }
        //int valeur;
        public int NumDe { get; private set; }

        public DesDisplay() { }
        public DesDisplay(De _de, int _xPos, int _yPos)
        {
            xPos = _xPos;
            yPos = _yPos;
            //NumDe = _numDe;
            //valeur = _de.Valeur;
        }
        public void AffDe(ConsoleColor _Color)
        {
            Console.ForegroundColor = _Color;
            Console.SetCursorPosition(xPos - 6, yPos - 4);
            Console.Write("▄▄▄▄▄▄▄▄▄▄▄▄▄");
            Console.SetCursorPosition(xPos - 8, yPos - 3);
            Console.Write("▄██▀▀▀▀▀▀▀▀▀▀▀██▄");
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(xPos - 8, yPos - 2 + i);
                Console.Write("██");
                Console.SetCursorPosition(xPos + 7, yPos - 2 + i);
                Console.Write("██");
            }
            Console.SetCursorPosition(xPos - 8, yPos + 3);
            Console.Write("▀██▄▄▄▄▄▄▄▄▄▄▄██▀");
            Console.SetCursorPosition(xPos - 6, yPos + 4);
            Console.Write("▀▀▀▀▀▀▀▀▀▀▀▀▀");
            Console.ResetColor();
        }

        public void AffValNull()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(xPos - 1, yPos - 1);
            Console.Write("▄▄▄");
            Console.SetCursorPosition(xPos - 1, yPos);
            Console.Write(" ▄▀");
            Console.SetCursorPosition(xPos - 1, yPos + 1);
            Console.Write(" ▄ ");
            Console.ResetColor();
        }
        public void AffValeur(int _valeur)
        {
            string point = "██";

            ErraseValeur();
            Console.ForegroundColor = ConsoleColor.White;
            switch (_valeur)
            {
                case 1:
                    Console.SetCursorPosition(xPos - 1, yPos);
                    Console.Write(point);
                    Console.ResetColor();
                    break;
                case 2:
                    Console.SetCursorPosition(xPos - 4, yPos - 1);
                    Console.Write(point);
                    Console.SetCursorPosition(xPos + 2, yPos + 1);
                    Console.Write(point);
                    Console.ResetColor();
                    break;
                case 3:
                    Console.SetCursorPosition(xPos - 5, yPos - 2);
                    Console.Write(point);
                    Console.SetCursorPosition(xPos - 1, yPos);
                    Console.Write(point);
                    Console.SetCursorPosition(xPos + 3, yPos + 2);
                    Console.Write(point);
                    Console.ResetColor();
                    break;
                case 4:
                    Console.SetCursorPosition(xPos - 4, yPos - 2);
                    Console.Write("▄▄     ▄▄");
                    Console.SetCursorPosition(xPos - 4, yPos - 1);
                    Console.Write("▀▀     ▀▀");
                    Console.SetCursorPosition(xPos - 4, yPos + 1);
                    Console.Write("▄▄     ▄▄");
                    Console.SetCursorPosition(xPos - 4, yPos + 2);
                    Console.Write("▀▀     ▀▀");
                    Console.ResetColor();
                    break;
                case 5:
                    Console.SetCursorPosition(xPos - 5, yPos - 2);
                    Console.Write(point);
                    Console.SetCursorPosition(xPos - 1, yPos);
                    Console.Write(point);
                    Console.SetCursorPosition(xPos + 3, yPos + 2);
                    Console.Write(point);
                    Console.SetCursorPosition(xPos + 3, yPos - 2);
                    Console.Write(point);
                    Console.SetCursorPosition(xPos - 5, yPos + 2);
                    Console.Write(point);
                    Console.ResetColor();
                    break;
                case 6:
                    Console.SetCursorPosition(xPos - 4, yPos - 2);
                    Console.Write(point);
                    Console.SetCursorPosition(xPos + 3, yPos - 2);
                    Console.Write(point);
                    Console.SetCursorPosition(xPos - 4, yPos);
                    Console.Write(point);
                    Console.SetCursorPosition(xPos + 3, yPos);
                    Console.Write(point);
                    Console.SetCursorPosition(xPos - 4, yPos + 2);
                    Console.Write(point);
                    Console.SetCursorPosition(xPos + 3, yPos + 2);
                    Console.Write(point);
                    Console.ResetColor();
                    break;
            }
        }
        public void ErraseValeur()
        {
            string errase = "           ";
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(xPos - 5, yPos - 2 + i);
                Console.Write(errase);
            }
        }

        public void AffCadreDe()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            Console.SetCursorPosition(xPos - 10, yPos - 5);
            Console.Write("  ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄  ");
            Console.SetCursorPosition(xPos - 10, yPos - 4);
            Console.Write("▄█▀");
            Console.SetCursorPosition(xPos + 8, yPos - 4);
            Console.Write("▀█▄");
            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(xPos - 10, yPos - 3 + i);
                Console.Write("█");
                Console.SetCursorPosition(xPos + 10, yPos - 3 + i);
                Console.Write("█");
            }
            Console.SetCursorPosition(xPos - 10, yPos + 4);
            Console.Write("▀█▄");
            Console.SetCursorPosition(xPos + 8, yPos + 4);
            Console.Write("▄█▀");
            Console.SetCursorPosition(xPos - 10, yPos + 5);
            Console.Write("  ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ");

            Console.ResetColor();
        }
        public void ErraseCadreDe()
        {
            Console.SetCursorPosition(xPos - 10, yPos - 5);
            Console.Write("                     ");
            Console.SetCursorPosition(xPos - 10, yPos - 4);
            Console.Write("   ");
            Console.SetCursorPosition(xPos + 8, yPos - 4);
            Console.Write("   ");
            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(xPos - 10, yPos - 3 + i);
                Console.Write(" ");
                Console.SetCursorPosition(xPos + 10, yPos - 3 + i);
                Console.Write(" ");
            }
            Console.SetCursorPosition(xPos - 10, yPos + 4);
            Console.Write("   ");
            Console.SetCursorPosition(xPos + 8, yPos + 4);
            Console.Write("   ");
            Console.SetCursorPosition(xPos - 10, yPos + 5);
            Console.Write("                     ");
        }

        public void AffRandom(De _de)
        {
            int tempRand1;
            int tempRand2 = 0;
            int sleep = 50;

            AffDe(ConsoleColor.Yellow);
            for (int i = 0; i < 11; i++)
            {
                do
                {
                    tempRand1 = Alea.Instance().Nouveau(1, 6);
                } while (tempRand1 == tempRand2);
                AffValeur(tempRand1);
                Thread.Sleep(sleep += i * 5);
                ErraseValeur();
                do
                {
                    tempRand2 = Alea.Instance().Nouveau(1, 6);
                } while (tempRand2 == tempRand1);
                AffValeur(tempRand2);
                Thread.Sleep(sleep += i * 5);
                ErraseValeur();
            }
            do
            {
                tempRand1 = Alea.Instance().Nouveau(1, 6);
            } while (tempRand1 == _de.Valeur || tempRand1 == tempRand2);
            AffValeur(tempRand1);
            Thread.Sleep(800);
            ErraseValeur();
            AffValeur(_de.Valeur);

            AffDe(ConsoleColor.DarkYellow);
        }

        public void AffRandom(DesDisplay _deDis2, De _de1, De _de2)
        {
            int tempRandD1_1;
            int tempRandD1_2 = 0;
            int tempRandD2_1;
            int tempRandD2_2 = 0;
            int sleep = 50;

            AffDe(ConsoleColor.Yellow);
            _deDis2.AffDe(ConsoleColor.Yellow);
            for (int i = 0; i < 11; i++)
            {
                do
                {
                    tempRandD1_1 = Alea.Instance().Nouveau(1, 6);
                } while (tempRandD1_1 == tempRandD1_2);
                do
                {
                    tempRandD2_1 = Alea.Instance().Nouveau(1, 6);
                } while (tempRandD2_1 == tempRandD2_2);
                AffValeur(tempRandD1_1);
                _deDis2.AffValeur(tempRandD2_1);
                Thread.Sleep(sleep += i * 5);
                ErraseValeur();
                _deDis2.ErraseValeur();
                do
                {
                    tempRandD1_2 = Alea.Instance().Nouveau(1, 6);
                } while (tempRandD1_2 == tempRandD1_1);
                do
                {
                    tempRandD2_2 = Alea.Instance().Nouveau(1, 6);
                } while (tempRandD2_2 == tempRandD2_1);
                AffValeur(tempRandD1_2);
                _deDis2.AffValeur(tempRandD2_2);
                Thread.Sleep(sleep += i * 5);
                ErraseValeur();
                _deDis2.ErraseValeur();
            }
            do
            {
                tempRandD1_1 = Alea.Instance().Nouveau(1, 6);
            } while (tempRandD1_1 == _de1.Valeur || tempRandD1_1 == tempRandD1_2);
            do
            {
                tempRandD2_1 = Alea.Instance().Nouveau(1, 6);
            } while (tempRandD2_1 == _de2.Valeur || tempRandD2_1 == tempRandD2_2);
            AffValeur(tempRandD1_1);
            _deDis2.AffValeur(tempRandD2_1);
            Thread.Sleep(800);
            ErraseValeur();
            _deDis2.ErraseValeur();
            AffValeur(_de1.Valeur);
            _deDis2.AffValeur(_de2.Valeur);

            AffDe(ConsoleColor.DarkYellow);
            _deDis2.AffDe(ConsoleColor.DarkYellow);
        }

        public void AffRandom(DesDisplay _deDis2, DesDisplay _deDis3, De _de1, De _de2, De _de3)
        {
            int tempRandD1_1;
            int tempRandD1_2 = 0;
            int tempRandD2_1;
            int tempRandD2_2 = 0;
            int tempRandD3_1;
            int tempRandD3_2 = 0;
            int sleep = 50;

            AffDe(ConsoleColor.Yellow);
            _deDis2.AffDe(ConsoleColor.Yellow);
            _deDis3.AffDe(ConsoleColor.Yellow);

            for (int i = 0; i < 11; i++)
            {
                do
                {
                    tempRandD1_1 = Alea.Instance().Nouveau(1, 6);
                } while (tempRandD1_1 == tempRandD1_2);
                do
                {
                    tempRandD2_1 = Alea.Instance().Nouveau(1, 6);
                } while (tempRandD2_1 == tempRandD2_2);
                do
                {
                    tempRandD3_1 = Alea.Instance().Nouveau(1, 6);
                } while (tempRandD3_1 == tempRandD3_2);
                AffValeur(tempRandD1_1);
                _deDis2.AffValeur(tempRandD2_1);
                _deDis3.AffValeur(tempRandD3_1);
                Thread.Sleep(sleep += i * 5);
                ErraseValeur();
                _deDis2.ErraseValeur();
                _deDis3.ErraseValeur();
                do
                {
                    tempRandD1_2 = Alea.Instance().Nouveau(1, 6);
                } while (tempRandD1_2 == tempRandD1_1);
                do
                {
                    tempRandD2_2 = Alea.Instance().Nouveau(1, 6);
                } while (tempRandD2_2 == tempRandD2_1);
                do
                {
                    tempRandD3_2 = Alea.Instance().Nouveau(1, 6);
                } while (tempRandD3_2 == tempRandD3_1);
                AffValeur(tempRandD1_2);
                _deDis2.AffValeur(tempRandD2_2);
                _deDis3.AffValeur(tempRandD3_2);
                Thread.Sleep(sleep += i * 5);
                ErraseValeur();
                _deDis2.ErraseValeur();
                _deDis3.ErraseValeur();
            }
            do
            {
                tempRandD1_1 = Alea.Instance().Nouveau(1, 6);
            } while (tempRandD1_1 == _de1.Valeur || tempRandD1_1 == tempRandD1_2);
            do
            {
                tempRandD2_1 = Alea.Instance().Nouveau(1, 6);
            } while (tempRandD2_1 == _de2.Valeur || tempRandD2_1 == tempRandD2_2);
            do
            {
                tempRandD3_1 = Alea.Instance().Nouveau(1, 6);
            } while (tempRandD3_1 == _de3.Valeur || tempRandD3_1 == tempRandD3_2);
            AffValeur(tempRandD1_1);
            _deDis2.AffValeur(tempRandD2_1);
            _deDis3.AffValeur(tempRandD3_1);
            Thread.Sleep(800);
            ErraseValeur();
            _deDis2.ErraseValeur();
            _deDis3.ErraseValeur();
            AffValeur(_de1.Valeur);
            _deDis2.AffValeur(_de2.Valeur);
            _deDis3.AffValeur(_de3.Valeur);

            AffDe(ConsoleColor.DarkYellow);
            _deDis2.AffDe(ConsoleColor.DarkYellow);
            _deDis3.AffDe(ConsoleColor.DarkYellow);
        }
    }
}
