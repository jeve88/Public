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
            //List<Brique> listeBrique = new List<Brique>();
            //ListeBrique.Add(new Brique(52, 9));
            //ListeBrique.Add(new Brique(45, 9));
            for (int i = 3; i < 11; i++)
            {
                ListeBrique.Add(new Brique(i*7, 9,ConsoleColor.DarkMagenta));
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

        public static void Dessiner()
        {
            foreach (var item in ListeBrique)
            {
                item.Dessiner();
            }
        }
    }
}
