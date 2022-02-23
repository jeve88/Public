using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryAscenseur
{
    public class Etage
    {
        private Ascenseur ascenseur;

        int numEtage;
        bool demandeIntern;
        bool appelMonter;
        bool appelDescendre;
        bool porteOuverte;

        public int NumEtage => numEtage;
        public bool DemandeIntern => demandeIntern;
        public bool AppelMonter => appelMonter;
        public bool AppelDescendre => appelDescendre;
        public bool PorteOuverte => porteOuverte;

        public delegate void DelegateChangementEtatPorte();
        public event DelegateChangementEtatPorte? ChangementEtatPorte;


        public Etage(Ascenseur _ascenseur, int _numEtage)
        {
            ascenseur = _ascenseur;
            numEtage = _numEtage;
            demandeIntern = false;
            appelMonter = false;
            appelDescendre = false;
        }

        public void AppelerPourMonter()
        {
            appelMonter = true;
            ascenseur.AppelExterne(this);
        }

        public void AppelerPourDescendre()
        {
            appelDescendre = true;
            ascenseur.AppelExterne(this);
        }


        public void DemanderEtageEnInterne()
        {
            demandeIntern = true;
        }
        public void DesactiverDemandeInterne()
        {
            demandeIntern = appelMonter = appelDescendre = false;
        }

        public void OuvrirPorteEtage()
        {
            porteOuverte = true;
            ChangementEtatPorte?.Invoke();
        }
        public void FermerPorteEtage()
        {
            porteOuverte = false;
            ChangementEtatPorte?.Invoke();
        }
    }
}
