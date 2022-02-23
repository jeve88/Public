using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryAscenseur.Etats
{
    public class Monte : Etat
    {
        private Ascenseur ascenseur;

        private Thread? thread;

        public Monte(Ascenseur _ascenseur)
        {
            ascenseur = _ascenseur;
        }


        public void ThreadMethodChangementEtage()
        {
            // Recuperation du numero d'etage à aller en priorité:
            int etageDemande = ascenseur.demandesEtageInterne.Count > 0 ? 
                ascenseur.demandesEtageInterne[0] : ascenseur.appelsEtageExterne[0];

            // Monte tant que...
            while (
                // L'etage courant est inferieur à l'etage demandé en priorité.
                ascenseur.EtageCourant.NumEtage < etageDemande &&
                // L'etage courant n'a pas été appelé en interne
                ascenseur.EtageCourant.DemandeIntern == false &&
                // L'etage courant n'a pas été appelé pour monter en externe
                ascenseur.EtageCourant.AppelMonter == false  &&
                // L'etat de l'ascenseur est toujours sur "Monte"
                ascenseur.Etat.GetType() == typeof(Monte))
            {
                ascenseur.MoteurMonte1Etage();
                Thread.Sleep(2000);
                ascenseur.Monter1Etage();
            }

            // Ouvrir la porte
            ascenseur.ChangerEtat(new ArretePorteOuverte(ascenseur));
        }

        public void ChangementEtage()
        {
            thread = new Thread(new ThreadStart(ThreadMethodChangementEtage));
            thread.Start();
        }

    }
}
