using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_3._6___Jeu_du_pendu
{
    public class Program
    {
        public static char[] CopieMot;
        public static string Mot;
        public static string RMot;
        public static void Main(string[] args)
        {bool check = false; 
                string Touche;
            do
            {


                Console.Clear();
                Affichage.Titre();

                int CountEssais = 6;
                char Lettre;
                bool CheckLettre;
                bool CheckMot;
                int NbrLettres;
                string Temp;
                char CharTemp;
                

                Affichage.Joueur1();

                Console.SetCursorPosition(10, 8);
                Console.WriteLine("Entrez un mot...");
                Console.SetCursorPosition(10, 9);

                Affichage.CadreMotJ1();

                Mot = Console.ReadLine().ToUpper();
                if (int.TryParse(Mot, out NbrLettres))
                {
                    switch (NbrLettres)
                    {
                        case 4:
                            Mot = ListeMots.QuatreL(Mot).ToUpper();
                            break;
                        case 5:
                            Mot = ListeMots.CinqL(Mot).ToUpper();
                            break;
                        case 6:
                            Mot = ListeMots.SixL(Mot).ToUpper();
                            break;
                        case 7:
                            Mot = ListeMots.SeptL(Mot).ToUpper();
                            break;
                        case 8:
                            Mot = ListeMots.HuitL(Mot).ToUpper();
                            break;
                        case 9:
                            Mot = ListeMots.NeufL(Mot).ToUpper();
                            break;
                        case 10:
                            Mot = ListeMots.DixL(Mot).ToUpper();
                            break;
                    }
                }


                CopieMot = new char[Mot.Length];
                CopieMot[0] = Mot[0];
                CopieMot[Mot.Length - 1] = Mot[Mot.Length - 1];
                for (int i = 1; i < CopieMot.Length - 1; i++)
                {
                    CopieMot[i] = '_';
                }

                Console.CursorVisible = false;

                do
                {
                    Console.Clear();
                    Affichage.Titre();

                    Affichage.Joueur2();
                    Console.SetCursorPosition(10, 8);
                    Console.WriteLine(" Essayez de deviner le mot !");
                    Affichage.CadreMotJ2();
                    Console.SetCursorPosition(10, 12);
                    Console.WriteLine(" Entrez une lettre...");
                    Console.SetCursorPosition(10, 13);
                    if (CountEssais > 1)
                    {
                        Console.WriteLine(" (Encore {0} essais)", CountEssais);
                    }
                    else
                    {
                        Console.WriteLine(" Dernier essai ...");
                    }
                    Affichage.CadrePendu();
                    Affichage.Potence();

                    switch (CountEssais)
                    {
                        case 5:
                            Affichage.PenduTete();
                            break;
                        case 4:
                            Affichage.PenduTete();
                            Affichage.PenduTorse();
                            break;
                        case 3:
                            Affichage.PenduTete();
                            Affichage.PenduTorse();
                            Affichage.PenduBrasG();
                            break;
                        case 2:
                            Affichage.PenduTete();
                            Affichage.PenduTorse();
                            Affichage.PenduBrasG();
                            Affichage.PenduBrasD();
                            break;
                        case 1:
                            Affichage.PenduTete();
                            Affichage.PenduTorse();
                            Affichage.PenduBrasG();
                            Affichage.PenduBrasD();
                            Affichage.PenduJambeG();
                            break;
                    }

                    Lettre = Console.ReadKey().KeyChar;
                    Temp = Convert.ToString(Lettre);
                    Temp = Filtreaccent(Temp);
                    Lettre = Convert.ToChar(Temp);
                    CheckLettre = false;
                    CheckMot = true;

                    for (int i = 1; i < Mot.Length - 1; i++)

                    {
                        Temp = Convert.ToString(Mot[i]).ToLower();
                        Temp = Filtreaccent(Temp);
                        CharTemp = Convert.ToChar(Temp);
                        if (char.ToUpper(CharTemp) == char.ToUpper(Lettre))
                        {
                            CopieMot[i] = Mot[i];
                            CheckLettre = true;
                        }

                    }

                    if (CheckLettre == false)
                    {
                        CountEssais--;
                    }

                    for (int i = 1; i < Mot.Length - 1; i++)
                    {
                        if (Mot[i] != CopieMot[i])
                        {
                            CheckMot = false;
                        }
                    }

                    if (CountEssais == 0)
                    {
                        break;
                    }
                } while (CheckMot == false);

                if (CheckMot == true)
                {
                    Affichage.CadreMotJ2();
                    Affichage.Gagne();
                }

                else if (CountEssais == 0)
                {
                    Console.Clear();
                    Affichage.Titre();
                    Affichage.Joueur2();
                    Console.SetCursorPosition(10, 8);
                    Console.WriteLine(" Le mot était:");
                    Affichage.CadreMotJ2();

                    Console.SetCursorPosition(11, 10);
                    Console.Write("│   ");
                    foreach (var item in Program.Mot)
                    {
                        Console.Write(item + " ");
                    }

                    Affichage.CadrePendu();
                    Affichage.Potence();
                    Affichage.PenduTete();
                    Affichage.PenduTorse();
                    Affichage.PenduBrasG();
                    Affichage.PenduBrasD();
                    Affichage.PenduJambeG();
                    Affichage.PenduJambeD();
                    Affichage.Perdu();
                }

                ConsoleKeyInfo Caractere;

                Console.SetCursorPosition((Console.WindowWidth / 4) - 19, 25);
                Console.WriteLine("Appuyez sur: 'ENTREE' pour recommencer,");
                Console.SetCursorPosition((Console.WindowWidth / 4) - 6, 26);
                Console.WriteLine("'ECHAP'  pour quitter...");
                do
                {
                    check = false;
                    Caractere = Console.ReadKey();
                    Touche = Caractere.Key.ToString();
                    Console.WriteLine(Touche);

                    if (Touche == "Escape")
                    {
                        check = true;
                    }
                    if (Touche == "Enter")
                    {
                        check = true;
                    }
                } while (check == false);

            } while (Touche == "Enter");
        }





        static public string Filtreaccent(string _Phrase)
        {
            _Phrase = _Phrase.Replace(" ", string.Empty);
            _Phrase = _Phrase.Replace("è", "e");
            _Phrase = _Phrase.Replace("é", "e");
            _Phrase = _Phrase.Replace("ê", "e");
            _Phrase = _Phrase.Replace("ë", "e");
            _Phrase = _Phrase.Replace("à", "a");
            _Phrase = _Phrase.Replace("ù", "u");
            _Phrase = _Phrase.Replace("î", "i");
            _Phrase = _Phrase.Replace("ô", "o");
            _Phrase = _Phrase.Replace("œ", "oe");
            _Phrase = _Phrase.Replace("â", "a");
            _Phrase = _Phrase.Replace("ï", "i");
            return _Phrase;
        }
    }





    class Affichage
    {
        public static void Titre()
        {
            Console.Title = ".... Exercice 3.6 ....";
            string Titre = "Jeu du pendu";


            for (int i = 0; i < 16 + Titre.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - (8 + (Titre.Length / 2)) + i, 0);
                Console.Write("/");
            }

            Console.SetCursorPosition(Console.WindowWidth / 2 - (8 + (Titre.Length / 2)), 1);
            Console.WriteLine("/       " + Titre + "       /");

            for (int i = 0; i < 16 + Titre.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - (8 + (Titre.Length / 2)) + i, 2);
                Console.Write("/");
            }
            Console.SetCursorPosition(0, 4);
        }

        public static void Joueur1()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition((Console.WindowWidth / 4) - 6, Console.CursorTop);
            Console.WriteLine("╔══════════╗");
            Console.SetCursorPosition((Console.WindowWidth / 4) - 6, Console.CursorTop);
            Console.WriteLine("║ Joueur 1 ║");
            Console.SetCursorPosition((Console.WindowWidth / 4) - 6, Console.CursorTop);
            Console.WriteLine("╚══════════╝");
            Console.ResetColor();
            Affichage.CadrePendu();
            Console.SetCursorPosition(86, 5);
            Console.Write("INSTRUCTIONS");
            Console.SetCursorPosition(70, 8);
            Console.Write("Entrez un mot de minimun 4 caractères");
            Console.SetCursorPosition(70, 9);
            Console.Write("et valider avec 'ENTREE' .");
            Console.SetCursorPosition(70, 11);
            Console.Write("ou");
            Console.SetCursorPosition(70, 13);
            Console.Write("Pour que l'ordinateur génére un mot");
            Console.SetCursorPosition(70, 14);
            Console.Write("aléatoirement:");
            Console.SetCursorPosition(70, 16);
            Console.Write("Entrez un chiffre entre 4 et 10 pour");
            Console.SetCursorPosition(70, 17);
            Console.Write("choisir la longueur du mot à trouver ");
            Console.SetCursorPosition(70, 18);
            Console.Write("et valider avec 'ENTREE' .");

        }

        public static void Joueur2()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition((Console.WindowWidth / 4) - 6, Console.CursorTop);
            Console.WriteLine("╔══════════╗");
            Console.SetCursorPosition((Console.WindowWidth / 4) - 6, Console.CursorTop);
            Console.WriteLine("║ Joueur 2 ║");
            Console.SetCursorPosition((Console.WindowWidth / 4) - 6, Console.CursorTop);
            Console.WriteLine("╚══════════╝");
            Console.WriteLine();
            Console.ResetColor();
        }

        public static void CadreMotJ1()
        {
            Console.SetCursorPosition(9, 10);
            Console.WriteLine("┌───────────────────────────┐");
            Console.SetCursorPosition(9, 11);
            Console.WriteLine("│                           │");
            Console.SetCursorPosition(9, 12);
            Console.WriteLine("└───────────────────────────┘");
            Console.SetCursorPosition(11, 11);
        }

        public static void CadreMotJ2()
        {
            Console.SetCursorPosition(11, 9);
            Console.Write("┌");
            for (int i = 0; i < 6 + Program.CopieMot.Length * 2 - 1; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine("┐");

            Console.SetCursorPosition(11, 10);
            Console.Write("│   ");
            foreach (var item in Program.CopieMot)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("  │");

            Console.SetCursorPosition(11, 11);
            Console.Write("└");
            for (int i = 0; i < 6 + Program.CopieMot.Length * 2 - 1; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine("┘");
        }

        public static void CadrePendu()
        {
            string Cadre1 = "╔═════════════════════════════════════════════╗"; //length=47
            string Cadre2 = "║                                             ║";
            string Cadre3 = "╚═════════════════════════════════════════════╝";

            Console.SetCursorPosition((Console.WindowWidth / 2) + (Console.WindowWidth / 4) - (Cadre1.Length / 2), 4);
            Console.WriteLine(Cadre1);

            for (int i = 0; i < 19; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) + (Console.WindowWidth / 4) - (Cadre1.Length / 2), 5 + i);
                Console.WriteLine(Cadre2);
            }

            Console.SetCursorPosition((Console.WindowWidth / 2) + (Console.WindowWidth / 4) - (Cadre1.Length / 2), 24);
            Console.WriteLine(Cadre3);

            Console.SetCursorPosition(0, 0);
        }


        public static void Potence()
        {
            string[] Potence = new string[12];
            Potence[0] = "  ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄";
            Potence[1] = "     ║     ▀▄    █";
            Potence[2] = "     ║       ▀▄  █";
            Potence[3] = "               ▀▄█";
            Potence[4] = "                 █";
            Potence[5] = "                 █";
            Potence[6] = "                 █";
            Potence[7] = "                 █";
            Potence[8] = "                 █";
            Potence[9] = "                 █";
            Potence[10] = "                 █";
            Potence[11] = "▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀";

            for (int i = 0; i < Potence.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) + (Console.WindowWidth / 4) - 9, 8 + i);
                Console.Write(Potence[i]);
            }
            Console.SetCursorPosition(Console.WindowWidth - 2, Console.WindowHeight - 2);
        }

        public static void PenduTete()
        {
            Console.SetCursorPosition((Console.WindowWidth / 2) + (Console.WindowWidth / 4) - 9, 11);
            Console.Write("   ▄███▄");
            Console.SetCursorPosition((Console.WindowWidth / 2) + (Console.WindowWidth / 4) - 9, 12);
            Console.Write("   ▀███▀");
            Console.SetCursorPosition(Console.WindowWidth - 2, Console.WindowHeight - 2);
        }
        public static void PenduTorse()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) + (Console.WindowWidth / 4) - 9, 13 + i);
                Console.Write("     █");
            }
            Console.SetCursorPosition(Console.WindowWidth - 2, Console.WindowHeight - 2);
        }
        public static void PenduBrasG()
        {
            Console.SetCursorPosition((Console.WindowWidth / 2) + (Console.WindowWidth / 4) - 9, 13);
            Console.Write("    ▄");
            Console.SetCursorPosition((Console.WindowWidth / 2) + (Console.WindowWidth / 4) - 9, 14);
            Console.Write("  ▄▀");
            Console.SetCursorPosition(Console.WindowWidth - 2, Console.WindowHeight - 2);
        }
        public static void PenduBrasD()
        {
            Console.SetCursorPosition((Console.WindowWidth / 2) + (Console.WindowWidth / 4) - 9, 13);
            Console.Write("    ▄█▄");
            Console.SetCursorPosition((Console.WindowWidth / 2) + (Console.WindowWidth / 4) - 9, 14);
            Console.Write("  ▄▀ █ ▀▄");
            Console.SetCursorPosition(Console.WindowWidth - 2, Console.WindowHeight - 2);
        }
        public static void PenduJambeG()
        {
            Console.SetCursorPosition((Console.WindowWidth / 2) + (Console.WindowWidth / 4) - 9, 16);
            Console.Write("   ▄▀");
            Console.SetCursorPosition((Console.WindowWidth / 2) + (Console.WindowWidth / 4) - 9, 17);
            Console.Write("  ▀");
            Console.SetCursorPosition(Console.WindowWidth - 2, Console.WindowHeight - 2);
        }
        public static void PenduJambeD()
        {
            Console.SetCursorPosition((Console.WindowWidth / 2) + (Console.WindowWidth / 4) - 9, 16);
            Console.Write("   ▄▀ ▀▄");
            Console.SetCursorPosition((Console.WindowWidth / 2) + (Console.WindowWidth / 4) - 9, 17);
            Console.Write("  ▀     ▀");
            Console.SetCursorPosition(Console.WindowWidth - 2, Console.WindowHeight - 2);
        }

        public static void Gagne()
        {
            Console.SetCursorPosition((Console.WindowWidth / 4) - 19, 15);
            Console.Write("                                   ▒▒");
            Console.SetCursorPosition((Console.WindowWidth / 4) - 19, 16);
            Console.Write("                                 ▒▒");
            Console.SetCursorPosition((Console.WindowWidth / 4) - 19, 18);
            Console.Write("▒▒▒▒▒▒    ▒▒    ▒▒▒▒▒▒ ▒▒▒   ▒▒ ▒▒▒▒▒▒");
            Console.SetCursorPosition((Console.WindowWidth / 4) - 19, 19);
            Console.Write("▒▒      ▒▒  ▒▒  ▒▒     ▒▒▒▒▒ ▒▒ ▒▒");
            Console.SetCursorPosition((Console.WindowWidth / 4) - 19, 20);
            Console.Write("▒▒ ▒▒▒ ▒▒    ▒▒ ▒▒ ▒▒▒ ▒▒ ▒▒▒▒▒ ▒▒▒▒");
            Console.SetCursorPosition((Console.WindowWidth / 4) - 19, 21);
            Console.Write("▒▒  ▒▒ ▒▒▒▒▒▒▒▒ ▒▒  ▒▒ ▒▒   ▒▒▒ ▒▒");
            Console.SetCursorPosition((Console.WindowWidth / 4) - 19, 22);
            Console.Write("▒▒▒▒▒▒ ▒▒    ▒▒ ▒▒▒▒▒▒ ▒▒    ▒▒ ▒▒▒▒▒▒");

            //efface la derniere lettre entré:
            Console.SetCursorPosition(Console.WindowWidth - 2, Console.WindowHeight - 2);
            Console.Write(" ");
        }

        public static void Perdu()
        {
            Console.SetCursorPosition((Console.WindowWidth / 4) - 19, 15);
            Console.Write("▒▒▒▒▒▒  ▒▒▒▒▒▒ ▒▒▒▒▒▒   ▒▒▒▒▒▒  ▒▒   ▒▒");
            Console.SetCursorPosition((Console.WindowWidth / 4) - 19, 16);
            Console.Write("▒▒   ▒▒ ▒▒     ▒▒   ▒▒  ▒▒   ▒▒ ▒▒   ▒▒");
            Console.SetCursorPosition((Console.WindowWidth / 4) - 19, 17);
            Console.Write("▒▒▒▒▒▒  ▒▒▒▒   ▒▒▒▒▒▒   ▒▒   ▒▒ ▒▒   ▒▒");
            Console.SetCursorPosition((Console.WindowWidth / 4) - 19, 18);
            Console.Write("▒▒      ▒▒     ▒▒   ▒▒  ▒▒   ▒▒ ▒▒   ▒▒");
            Console.SetCursorPosition((Console.WindowWidth / 4) - 19, 19);
            Console.Write("▒▒      ▒▒▒▒▒▒ ▒▒    ▒▒ ▒▒▒▒▒▒   ▒▒▒▒▒");
        }
    }

    class ListeMots
    {
        static List<string> Liste4 = new List<string> { "Âtre", "Beau", "Bête", "Boxe", "Brun", "Cerf", "Chez", "Cire", "Dame", "Dent", "Dock", "Dodo", "Drap", "Dune", "Emeu", "Fado", "Faux", "Ibis", "Jazz", "Joli", "Joue", "Kaki", "Logo", "Loin", "Long", "Lune", "Lynx", "Mine", "Mûre", "Ouïe", "Ours", "Pion", "Rhum", "Ride", "Rock", "Seau", "Test", "Thym", "Trou", "Truc", "User", "Vert", "Yogi", "Watt" };
        static List<string> Liste5 = new List<string> { "Accès", "Aimer", "Aloès", "Assez", "Avion", "Awalé", "Balai", "Banjo", "Barbe", "Bonne", "Bruit", "Buche", "Cache", "Capot", "Carte", "Chien", "Crâne", "Cycle", "Ébène", "Essai", "Gifle", "Honni", "Jambe", "Koala", "Livre", "Lourd", "Maman", "Moult", "Noeud", "Ortie", "Pêche", "Poire", "Pomme", "Poste", "Prune", "Radar", "Radis", "Robot", "Route", "Rugby", "Seuil", "Taupe", "Tenue", "Texte", "Tyran", "Usuel", "Valse" };
        static List<string> Liste6 = new List<string> { "Acajou", "Agneau", "Alarme", "Ananas", "Angora", "Animal", "Arcade", "Aviron", "Azimut", "Babine", "Balade", "Bonzaï", "Basson", "Billet", "Bouche", "Boucle", "Bronze", "Cabane", "Caïman", "Cloche", "Chèque", "Cirage", "Coccyx", "Crayon", "Garage", "Gospel", "Goulot", "Gramme", "Grelot", "Guenon", "Hochet", "Hormis", "Humour", "Hurler", "Jargon", "Limite", "Lionne", "Menthe", "Oiseau", "Podium", "Poulpe", "Poumon", "Puzzle", "Quartz", "Rapide", "Séisme", "Tétine", "Tomate", "Walabi", "Whisky", "Zipper" };
        static List<string> Liste7 = new List<string> { "Abriter", "Ballast", "Baryton", "Bassine", "Batavia", "Billard", "Bretzel", "Cithare", "Chariot", "Clairon", "Corbeau", "Cortège", "Crapaud", "Cymbale", "Dentier", "Djembé", "Drapeau", "Exemple", "Fourmis", "Grandir", "Iceberg", "Javelot", "Jockey", "Journal", "Journée", "Jouxter", "Losange", "Macadam", "Mondial", "Notable", "Oxygène", "Panique", "Pétrole", "Poterie", "Pouvoir", "Renégat", "Scooter", "Senteur", "Sifflet", "Spirale", "Sucette", "Strophe", "Tonneau", "Trousse", "Tunique", "Ukulélé", "Vautour", "Zozoter" };
        static List<string> Liste8 = new List<string> { "Aquarium", "Araignée", "Arbalète", "Archipel", "Banquise", "Batterie", "Brocante", "Brouhaha", "Capeline", "Clavecin", "Cloporte", "Débutant", "Diapason", "Gangster", "Gothique", "Hautbois", "Hérisson", "Logiciel", "Objectif", "Paranoïa", "Parcours", "Pastiche", "Question", "Quetsche", "Scarabée", "Scorpion", "Symptôme", "Tabouret", "Tomahawk", "Toujours", "Tourisme", "Triangle", "Utopique", "Zeppelin" };
        static List<string> Liste9 = new List<string> { "Accordéon", "Ascenseur", "Ascension", "Aseptiser", "Autoroute", "Avalanche", "Balalaïka", "Bilboquet", "Bourricot", "Brillance", "Cabriolet", "Contrario", "Cornemuse", "Dangereux", "Épluchage", "Féodalité", "Forteresse", "Gondolier", "Graphique", "Horoscope", "Intrépide", "Klaxonner", "Mascarade", "Métaphore", "Narrateur", "Péripétie", "Populaire", "Printemps", "Quémander", "Tambourin", "Vestiaire", "Xylophone" };
        static List<string> Liste10 = new List<string> { "Acrostiche", "Apocalypse", "Attraction", "Aventurier", "Bouillotte", "Citrouille", "Controverse", "Coquelicot", "Dissimuler", "Flibustier", "Forestière", "Grenouille", "Impossible", "Labyrinthe", "Maharadjah", "Prudemment", "Quadriceps", "Soliloquer", "Subjective" };
        public static string QuatreL(string MotRandom)
        {

            var Rand = new Random();
            int IndexMot;

            IndexMot = Rand.Next(0, Liste4.Count);
            MotRandom = Liste4[IndexMot];
            Liste4.RemoveAt(IndexMot);


            return MotRandom;

        }
        public static string CinqL(string MotRandom)
        {

            var Rand = new Random();
            int IndexMot;

            IndexMot = Rand.Next(0, Liste5.Count);
            MotRandom = Liste5[IndexMot];
            Liste5.RemoveAt(IndexMot);


            return MotRandom;
        }
        public static string SixL(string MotRandom)
        {

            var Rand = new Random();
            int IndexMot;

            IndexMot = Rand.Next(0, Liste6.Count);
            MotRandom = Liste6[IndexMot];
            Liste6.RemoveAt(IndexMot);


            return MotRandom;
        }
        public static string SeptL(string MotRandom)
        {

            var Rand = new Random();
            int IndexMot;

            IndexMot = Rand.Next(0, Liste7.Count);
            MotRandom = Liste7[IndexMot];
            Liste7.RemoveAt(IndexMot);


            return MotRandom;
        }
        public static string HuitL(string MotRandom)
        {

            var Rand = new Random();
            int IndexMot;

            IndexMot = Rand.Next(0, Liste8.Count);
            MotRandom = Liste8[IndexMot];
            Liste8.RemoveAt(IndexMot);


            return MotRandom;
        }
        public static string NeufL(string MotRandom)
        {

            var Rand = new Random();
            int IndexMot;

            IndexMot = Rand.Next(0, Liste9.Count);
            MotRandom = Liste9[IndexMot];
            Liste9.RemoveAt(IndexMot);


            return MotRandom;
        }
        public static string DixL(string MotRandom)
        {

            var Rand = new Random();
            int IndexMot;

            IndexMot = Rand.Next(0, Liste10.Count);
            MotRandom = Liste10[IndexMot];
            Liste10.RemoveAt(IndexMot);


            return MotRandom;
        }
    }
}
