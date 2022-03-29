import { Boulangerie } from './class/boulangerie.js';
import { EtatBoulangerie } from './class/etatBoulangerie.js';
import { simplifier, simplifierSansDecimal } from './class/simplification.js';
import { chercherCode } from './class/codesTriche.js';
import { LogBoulangerie } from './class/logBoulangerie.js';

const boulangerieApp = {
    data() {
        return {
            boulangerie: new Boulangerie(),
            msgErreur: null,
            intervalId: undefined,  
            log: LogBoulangerie.getLogger(),

            vitesse: 1000,
            tricheActive: false,
            codeTriche:[],

            activeColor: 'red',  
            idTest: "btnCommandeAuto",  

            id1000: "btnXActiv", 
            id500: "btnXDesactif", 
            id300: "btnXDesactif", 
            id150: "btnXDesactif", 
            id50: "btnXDesactif", 
        }
    },


    mounted() {
        
        this.demarrerTimer();

        // Capture touches (codes triche):
        window.addEventListener("keydown", e => {


            //                              //
                if( e.keyCode == 107){
                    if(this.boulangerie.or >= this.boulangerie.prixLvlSuivant + this.boulangerie.prixMoulin)
                    {
                        this.acheterMoulin();
                        this.lvlSuivant();
                    }                    
                }
            //                              //



            this.codeTriche.push(e.keyCode);
            if( this.codeTriche.length == 5 ){
                this.codeTriche.shift();
            }
            this.keyEventCodeSecret();
          });
    },

    computed: {
        or() {
            // Arrondi inferieur à une décimal :
            // (Pour afficher un nbr négatif en cas de faillite)        
            //return (Math.floor( this.boulangerie.or * 10 ) / 10).toFixed(1);




            if(this.boulangerie.lvlBoulangerie >= this.boulangerie.nbrMoulins){
                //this.acheterMoulin();
            }
            else if(this.boulangerie.or >= this.boulangerie.prixLvlSuivant + this.boulangerie.prixMoulin)
                    {
                        //this.lvlSuivant();
                    } 






            return simplifier(this.boulangerie.or);
        },
        orGagne() {
            return simplifier(this.boulangerie.orGagne);
        }, 
        orDepense() {
            return simplifier(this.boulangerie.orDepense);
        },
    },

    methods: {
        keyEventCodeSecret() {
            switch( chercherCode(this.codeTriche) ){
                case null: break;
                case 'or': 
                    this.boulangerie.or += this.boulangerie.lvlBoulangerie * 1000;
                    break;
                case 'lvlUp':
                    this.boulangerie.lvlBoulangerie++;
                case 'test':

                    break;
            }
        },

        simplifier(_aSimp) {
            return simplifier(_aSimp);
        },

        simplifierSansDecimal(_aSimp) {
            return simplifierSansDecimal(_aSimp);
        },

        lvlSuivant() {

            if( this.boulangerie.lvlSuivant() ) {

                LogBoulangerie.ajoutMsg("La boulangerie a atteint le niveau " + this.boulangerie.lvlBoulangerie + ".");
                this.msgErreur = null;

            }else{

                this.msgErreur = "Pas assez d'or (" 
                        + simplifier(this.boulangerie.prixLvlSuivant - this.boulangerie.or) 
                        + " manquants)"
            }
        },

        acheterMoulin() {

            if( this.boulangerie.acheterMoulin() ) {

                LogBoulangerie.ajoutMsg("La boulangerie dispose désormais de "+this.boulangerie.nbrMoulins+" moulins.");
                this.msgErreur = null;
                
                return true;
            
            }else{

                this.msgErreur = "Pas assez d'or (" 
                        + (this.boulangerie.prixMoulin - this.boulangerie.or).toFixed(1) 
                        + " manquants)";
                        
                return false;
            }
        },

        eventAccepterCommande(event) {
            this.boulangerie.accepterCommande(event.target.dataset.tab);
            LogBoulangerie.ajoutMsg("La commande "+event.target.dataset.tab+" a été acceptée.");

            this.fermerErreur();
        },

        eventRefuserCommande() {   //  <-- fonctionne sans 'event' ???
            this.boulangerie.refuserCommande(event.target.dataset.tab);

            this.fermerErreur();
        },

        changerEtatBoulangerie() {
            
            switch(this.boulangerie.etatBoulangerie){
                case EtatBoulangerie.Fermer: 
                    this.boulangerie.etatBoulangerie = EtatBoulangerie.Ouverte;
                    break;
                case EtatBoulangerie.Ouverte: 
                    this.boulangerie.etatBoulangerie = EtatBoulangerie.Fermer;
                    break;  
                default: break;
            }

            this.fermerErreur();
        },

        fermerErreur() {
            this.msgErreur = null;
        },

        demarrerTimer() {
            this.intervalId = setInterval(() => {
                if(this.boulangerie.etatBoulangerie == EtatBoulangerie.Ouverte){
                    if(this.boulangerie.gestionProductionParSeconde() == false){
                        this.msgErreur = "Vous avez fait faillite !";
                    }
                }
            }, this.vitesse);
        },

        arreterTimer() {
            clearInterval(this.intervalId);
        },
        
        
        
        
        // Temp (btn vitesse)

        modifierVitesse() {
            this.arreterTimer();
            this.vitesse = event.target.dataset.tab;
            this.demarrerTimer();

            switch(event.target.dataset.tab){
                case "1000": 
                    this.id1000 = "btnXActiv"; 
                    this.id500 = this.id300 = this.id150 = this.id50 = "btnXDesactif";
                    break;
                case "500": 
                    this.id500 = "btnXActiv"; 
                    this.id1000 = this.id300 = this.id150 = this.id50 = "btnXDesactif";
                    break;
                case "300": 
                    this.id300 = "btnXActiv"; 
                    this.id1000 = this.id500 = this.id150 = this.id50 = "btnXDesactif";
                    break;
                case "150": 
                    this.id150 = "btnXActiv"; 
                    this.id1000 = this.id300 = this.id500 = this.id50 = "btnXDesactif";
                    break;
                case "50": 
                    this.id50 = "btnXActiv"; 
                    this.id1000 = this.id300 = this.id150 = this.id500 = "btnXDesactif";
                    break;            
                default: break;
            }
        },

        // Triche
        activerTriche() {
            this.boulangerie.activerTriche();
            this.arreterTimer();
            this.vitesse = 1000;
            this.demarrerTimer();

            this.idTest = this.boulangerie.commandeAuto ? "btnCommandeAutoActiver" : "btnCommandeAuto";

        },

        commandeAuto() {
            this.boulangerie.activerCommandeAuto();

            this.idTest = this.boulangerie.commandeAuto ? "btnCommandeAutoActiver" : "btnCommandeAuto";
        },

    }
}

Vue.createApp(boulangerieApp).mount('#app');