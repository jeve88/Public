using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryAscenseur.Etats
{
    public class ArretePorteOuverte : Etat
    {
        private Ascenseur ascenseur;

        private Thread? t;

        public ArretePorteOuverte(Ascenseur _ascenseur)
        {
            ascenseur = _ascenseur;
            OuvrirPorte();
        }

        public void ChangementEtage()
        {
            
        }

        public void OuvrirPorte()
        {
            t = new Thread(new ThreadStart(ThreadMethodOuvrirPorte));
            t.Start();
        }

        public void ThreadMethodOuvrirPorte()
        {
            // Pause avent ouverture
            Thread.Sleep(500);

            // Ouverture porte etage (ihm)
            ascenseur.EtageCourant.OuvrirPorteEtage();
            // Ouverture porte ascenseur (ihm)
            ascenseur.EventChangementEtatPorte();
            // Temps d'ouverture
            Thread.Sleep(1250);


            // Suppression des demandes d'etage
            ascenseur.demandesEtageInterne.Remove(ascenseur.EtageCourant.NumEtage);
            ascenseur.appelsEtageExterne.Remove(ascenseur.EtageCourant.NumEtage);
            ascenseur.EtageCourant.DesactiverDemandeInterne();


            // Attente porte ouverte:
            Thread.Sleep(10);


            // Fermeture porte etage (ihm)
            ascenseur.EtageCourant.FermerPorteEtage();
            // Fermeture porte ascenseur (ihm)
            ascenseur.EventChangementEtatPorte();
            // Temps de fermeture
            Thread.Sleep(1250);

            // Arreter l'ascenseur
            ascenseur.ChangerEtat(new ArretePorteFermee(ascenseur));

            // Si etage présent dans les listes
            if (ascenseur.demandesEtageInterne.Count > 0 ||
                ascenseur.appelsEtageExterne.Count > 0)
            {
                //Changement d'etage 
                ascenseur.ChangementEtage();
            }
        }
    }
}
