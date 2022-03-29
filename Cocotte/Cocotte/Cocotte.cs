using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocotte
{
    class Cocotte
    {
        private bool position1;
        public bool Position1 => position1;
        private Affichage affEnCours;
        public Affichage AffEnCours => affEnCours;
        private int nbrMouvAFaire;
        public int NbrMouvAFaire { get => nbrMouvAFaire; set => nbrMouvAFaire = value; }
        public Couleur couleurChoisie;

        private string[] messages;

        Random rand = new Random();

        public delegate void DelegateEventCocotte();
        public event DelegateEventCocotte MouvementsTermine;

        public Cocotte()
        {
            position1 = rand.Next(0, 2) == 0;
            affEnCours = Affichage.carre;
            nbrMouvAFaire = 3;

            if (File.Exists("messages.bin"))
            {
                messages = Serialisation.DeserializeMessages("messages.bin");
            }
            else
            {
                messages =new string[] { "[][][][][]","[][][][][]","[][][][][]","[][][][][]","[][][][][]","[][][][][]","[][][][][]","[][][][][]"};
                Serialisation.SerializeMessages(messages,"messages.bin");
            }
        }

        public void MouvementsDeCocotte()
        {
            if (nbrMouvAFaire > 0)
            {
                if (affEnCours == Affichage.position1 || affEnCours == Affichage.position2)
                {
                    affEnCours = Affichage.carre;
                }
                else if (position1)
                {
                    affEnCours = Affichage.position2;
                    position1 = false;
                    nbrMouvAFaire--;
                }
                else
                {
                    affEnCours = Affichage.position1;
                    position1 = true;
                    nbrMouvAFaire--;
                }
            }
            if (nbrMouvAFaire == 0)
            {
                if (MouvementsTermine != null)
                {
                    MouvementsTermine();
                }
            }
        }

        public string Message()
        {
            string copieMessage = messages[(int)couleurChoisie];
            string retour = "";

            for (int i = 0; i < 5; i++)
            {
                copieMessage = copieMessage.Substring(1, copieMessage.Length - 1);
                while (copieMessage[0] != ']')
                {
                    retour += copieMessage[0];
                    copieMessage = copieMessage.Substring(1, copieMessage.Length - 1);
                }
                copieMessage = copieMessage.Substring(1, copieMessage.Length - 1);
                if (i < 4)
                {
                    retour += "\r";
                }
            }

            return retour;
        }

        public enum Affichage
        {
            carre,
            position1,
            position2
        }

        public enum Couleur
        {
            cyan,
            rouge,
            violet,
            jaune,
            rose,
            bleu,
            orange,
            vert
        }


    }
}
