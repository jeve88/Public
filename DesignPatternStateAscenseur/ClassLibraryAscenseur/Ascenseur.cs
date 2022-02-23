using ClassLibraryAscenseur.Etats;

namespace ClassLibraryAscenseur
{
    public class Ascenseur
    {
        Etat etat;
        public Etat Etat => etat;


        Etage etageCourant;
        public Etage EtageCourant => etageCourant;

        public Dictionary<int, Etage> etages;
        public List<int> demandesEtageInterne;
        public List<int> appelsEtageExterne;


        public Ascenseur(int _etageMin, int _etageMax)
        {
            demandesEtageInterne = new List<int>();
            appelsEtageExterne = new List<int>();

            etat = new ArretePorteFermee(this);

            etages = new Dictionary<int, Etage>();
            for (int i = _etageMin; i <= _etageMax; i++)
            {
                etages.Add(i, new Etage(this,i));
            }

            etageCourant = etages[0];
        }


        public void ChangerEtat(Etat _nouvelEtat)
        {
            etat = _nouvelEtat;
        }

        public void ChangementEtage()
        {
            etat.ChangementEtage();
        }

        // Demande depuis les bouton à l'interieur de l'ascenseur:
        public void DemandeEtageInterne(int _etage)
        {
            // Si aucune demande et aucun appel en cours:
            if (demandesEtageInterne.Count == 0 && appelsEtageExterne.Count == 0)
            {
                // Ajout de la demande a l'etage, et a la liste.
                etages[_etage].DemanderEtageEnInterne();
                demandesEtageInterne.Add(_etage);
                // Lancement du changement d'etage
                etat.ChangementEtage();
            }
            // Sinon 
            else if (!demandesEtageInterne.Contains(_etage))
            {
                // Ajout simple à l'etage et à la liste
                etages[_etage].DemanderEtageEnInterne();
                demandesEtageInterne.Add(_etage);
            }
        }

        // Demande depuis les bouton à l'exterieur de l'ascenseur
        // aux differents etages (monter/descendre) :
        public void AppelExterne(Etage _etage)
        {
            if (demandesEtageInterne.Count == 0 && appelsEtageExterne.Count == 0)
            {
                appelsEtageExterne.Add(_etage.NumEtage);
                etat.ChangementEtage();
            }
            else if (!appelsEtageExterne.Contains(_etage.NumEtage))
            {
                appelsEtageExterne.Add(_etage.NumEtage);
            }
        }




        public void Descendre1Etage()
        {
            etageCourant = etages[etageCourant.NumEtage - 1];
        }

        public void Monter1Etage()
        {
            etageCourant = etages[etageCourant.NumEtage + 1];
        }








        /////////////////////////////////
        //  DELEGATES / EVENTS  (ihm)  //
        /////////////////////////////////

        public delegate void DelegateChangementEtatPorte();
        public event DelegateChangementEtatPorte? ChangementEtatPorte;

        // Delegate sur l'initialisation du changement d'etage pour l'IHM (Mise en route du moteur de l'ascenseur)
        public delegate void DelegateChangementEtage(bool _monte);
        public event DelegateChangementEtage? EventChangementEtage;
        //


        // Events pour monter/descendre de l'IHM (moteur ascenseur)
        public void MoteurDescendre1Etage()
        {
            EventChangementEtage?.Invoke(false);
        }

        public void MoteurMonte1Etage()
        {
            EventChangementEtage?.Invoke(true);
        }


        // Event pour l'ouverture des portes de l'IHM (moteur porte)
        public void EventChangementEtatPorte()
        {
            ChangementEtatPorte?.Invoke();
        }
    }
}