using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryAscenseur.Etats
{
    public class ArretePorteFermee : Etat
    {
        private Ascenseur ascenseur;

        public ArretePorteFermee(Ascenseur _ascenseur)
        {
            ascenseur = _ascenseur;
        }


        public void ChangementEtage()
        {
            // Recuperation du numero d'etage à aller en priorité:
            int etageDemande = ascenseur.demandesEtageInterne.Count > 0 ? 
                ascenseur.demandesEtageInterne[0] : ascenseur.appelsEtageExterne[0];
            
            // Si superieur à l'etage courant: Monter
            if (ascenseur.EtageCourant.NumEtage < etageDemande)
            {
                ascenseur.ChangerEtat(new Monte(ascenseur));
                ascenseur.ChangementEtage();
            }
            // Si inferieur à l'etage courant: Descendre
            else if (ascenseur.EtageCourant.NumEtage > etageDemande)
            {
                ascenseur.ChangerEtat(new Descend(ascenseur));
                ascenseur.ChangementEtage();
            }
            // Sinon 
            else if(ascenseur.EtageCourant.NumEtage == etageDemande)
            {
                ascenseur.ChangerEtat(new ArretePorteOuverte(ascenseur));
            }

        }

    }
}
