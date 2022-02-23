using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryAscenseur.Etats
{
    public class Descend : Etat
    {
        private Ascenseur ascenseur;

        private Thread? thread;

        public Descend(Ascenseur _ascenseur)
        {
            ascenseur = _ascenseur;
        }


        public void ChangementEtage()
        {
            thread = new Thread(new ThreadStart(ThreadMethodChangementEtage));
            thread.Start();
        }

        public void ThreadMethodChangementEtage()
        {
            int etageDemande = ascenseur.demandesEtageInterne.Count > 0 ? 
                ascenseur.demandesEtageInterne[0] : ascenseur.appelsEtageExterne[0];

            while (ascenseur.EtageCourant.DemandeIntern == false &&
               ascenseur.EtageCourant.AppelDescendre == false &&
               ascenseur.EtageCourant.NumEtage > etageDemande &&
               ascenseur.Etat.GetType() == typeof(Descend))
            {
                ascenseur.MoteurDescendre1Etage();
                Thread.Sleep(2000);
                ascenseur.Descendre1Etage();
            }

            ascenseur.ChangerEtat(new ArretePorteOuverte(ascenseur));
        }

    
    }
}
