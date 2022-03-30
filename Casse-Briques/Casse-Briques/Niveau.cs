using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casse_Briques
{
    class Niveau
    {
        public static List<Brique> ListeBrique = new List<Brique>();
        public static void Niveau1()
        {
            ListeBrique = new List<Brique>();

            //for (int i = 3; i < 11; i++)
            //{
            //    ListeBrique.Add(new Brique(i*7, 9,ConsoleColor.DarkMagenta));
            //}
            //for (int i = 3; i < 11; i++)
            //{
            //    ListeBrique.Add(new Brique(i * 7, 7, ConsoleColor.DarkGreen));
            //}
            //for (int i = 3; i < 11; i++)
            //{
            //    ListeBrique.Add(new Brique(i * 7, 5, ConsoleColor.DarkRed));
            //}

            for (int i = 3; i < 6; i++)
            {
                ListeBrique.Add(new Brique(i * 11, 9, ConsoleColor.DarkMagenta));
            }
            for (int i = 3; i < 9; i++)
            {
                ListeBrique.Add(new Brique(i * 8, 7, ConsoleColor.DarkGreen));
            }
            for (int i = 3; i < 8; i++)
            {
                ListeBrique.Add(new Brique(i * 10, 11, ConsoleColor.DarkRed));
            }
        }

        public static void Niveau2()
        {
            ListeBrique = new List<Brique>();

            for (int i = 3; i < 11; i++)
            {
                ListeBrique.Add(new Brique(i * 7, 9, ConsoleColor.DarkMagenta,true));
            }
            for (int i = 3; i < 11; i++)
            {
                ListeBrique.Add(new Brique(i * 7, 7, ConsoleColor.DarkGreen));
            }
            for (int i = 3; i < 11; i++)
            {
                ListeBrique.Add(new Brique(i * 7, 5, ConsoleColor.DarkRed));
            }
        }

        public static void Niveau3()
        {
            ListeBrique = new List<Brique>();

            for (int i = 3; i < 11; i++)
            {
                ListeBrique.Add(new Brique(i * 7, 5, ConsoleColor.DarkMagenta, true));
            }
            for (int i = 3; i < 11; i++)
            {
                if (i==3||i==10)
                {
                    ListeBrique.Add(new Brique(i * 7, 7, ConsoleColor.DarkMagenta, true));
                }
                else
                {
                ListeBrique.Add(new Brique(i * 7, 7, ConsoleColor.DarkGreen));
                }
            }
            for (int i = 3; i < 11; i++)
            {
                if (i == 3 || i == 10)
                {
                    ListeBrique.Add(new Brique(i * 7, 9, ConsoleColor.DarkMagenta, true));
                }
                else
                {
                    ListeBrique.Add(new Brique(i * 7, 9, ConsoleColor.DarkRed));
                }
            }
            for (int i = 3; i < 11; i++)
            {
                ListeBrique.Add(new Brique(i * 7, 11, ConsoleColor.DarkMagenta, true));
            }

        }

        public static void Dessiner()
        {
            foreach (var item in ListeBrique)
            {
                item.Dessiner();
            }
        }

        public static bool FinDeNiveau()
        {
            return ListeBrique.Count == 0;
        }
    }
}
