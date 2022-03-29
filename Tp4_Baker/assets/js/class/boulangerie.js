import { EtatBoulangerie } from './etatBoulangerie.js';
import { Commande } from './commande.js';
import { StatutCommande } from './statutCommande.js';
import { LogBoulangerie } from './logBoulangerie.js';
import { simplifier, simplifierSansDecimal } from './simplification.js';


class Boulangerie
{
    constructor() {
        this.etatBoulangerie = EtatBoulangerie.Ouverte;
        this.lvlBoulangerie = 1;
        this.prixLvlSuivant = 100;        
        this.nbrMoulins = 1;
        this.prixMoulin = 80;
        this.or = 200;
        this.farine = 500;
        this.baguettes = 0;

        this.commandes = this.initialiserCommandes();
        this.commandesAcceptee = [];        

        this.orGagne = 0;
        this.orDepense = 0;
        this.farineProduite = 0;
        this.baguettesProduites = 0;

        this.tricheActive = false;
        this.commandeAuto = false;
    }

    gagnerOr(_montant) {
        this.or += _montant;
        this.orGagne += _montant;

        LogBoulangerie.ajoutMsg("La boulangerie a gagné " + simplifier(_montant*35) + " Or.");
    }

    depenserOr(_montant) {
        if( _montant <= this.or ) {

            this.or -= _montant;
            this.orDepense += _montant;
            return true;

        }else {
            return false;
        }
    }

    livrerCommande(_commande) {
        if( _commande.nbrBaguettes <= this.baguettes ) {

            this.baguettes -= _commande.nbrBaguettes;
            LogBoulangerie.ajoutMsg("La boulangerie a livré " + _commande.nbrBaguettes + " baguettes.");

            this.gagnerOr( _commande.prixTotal )

            return true;
            
        }else {
            return false;
        }
    }

    activerTriche() {
        this.tricheActive = !this.tricheActive;
        if(this.commandeAuto){
            this.commandeAuto = false;
        }
    } 
    activerCommandeAuto() {
        this.commandeAuto = !this.commandeAuto;
    }

    gestionProductionParSeconde() {

        //Check faillite:
        if( this.or < 0 ){

            this.etatBoulangerie = EtatBoulangerie.Faillite;
            this.commandes.forEach((item,index) => item.refuserCommande());

            return false;

        }else {

            //prod farine:
            this.farine += this.nbrMoulins;
            this.farineProduite += this.nbrMoulins;

            //prod baguettes:
            if( this.farine >= this.lvlBoulangerie + 1 ){

                this.farine -= this.lvlBoulangerie + 1;
                this.baguettes += this.lvlBoulangerie;
                this.baguettesProduites += this.lvlBoulangerie;
            }
            
            //maintenance boulangerie:
            this.orDepense += 0.05 * this.lvlBoulangerie * this.nbrMoulins;
            this.or -= 0.05 * this.lvlBoulangerie * this.nbrMoulins;
            
            //Commandes:
            this.gestionCommandesAcceptee();
            this.gestionCommandes();

            return true;
        }
    }

    gestionCommandes() {

        this.commandes.forEach((item,index) => {
                
            item.gestionCommandeParSeconde();
            
            if( item.statutCommande == StatutCommande.Annulee 
                || item.statutCommande == StatutCommande.Terminee){

                    if(this.commandes[index].finaliserCommande()){
                        this.commandes[index] = new Commande(this.lvlBoulangerie); 
                    }               
            }
        });

        ///// Triche //////////////////////////////////////////////////////////////////
        if(this.tricheActive){                                                       //
                                                                                     //
            this.commandes.sort((a,b) => a.prixBaguette - b.prixBaguette).reverse(); //
                                                                                     //
            if(this.commandes[0].statutCommande == StatutCommande.NouvelleCommande   //
                && this.commandeAuto){                                               //  
                    this.accepterCommande(this.commandes[0].id);                     //
                }                                                                    //
        }                                                                            //
        ///////////////////////////////////////////////////////////////////////////////
    }

    gestionCommandesAcceptee() {

        if(this.commandesAcceptee.length > 0){
    
            switch(this.commandesAcceptee[0].statutCommande) {

                case StatutCommande.Acceptee:
                    this.commandesAcceptee[0].statutCommande = StatutCommande.EnPreparation;
                    break;
                    
                case StatutCommande.EnPreparation:
                    if(this.livrerCommande(this.commandesAcceptee[0])){
                        this.commandesAcceptee[0].livrerCommande();
                    }
                    break;

                case StatutCommande.Terminee:
                    this.commandesAcceptee.shift();
                    break; 

                case StatutCommande.Annulee:
                    this.commandesAcceptee.shift();
                    break;

                default: break;        
            }
        }
    }

    lvlSuivant() {

        if(this.depenserOr(this.prixLvlSuivant)) {
            
            this.lvlBoulangerie++;
            this.prixLvlSuivant = this.prixLvlSuivant * 1.5;
            return true;

        }else {
            return false;
        }       
    }

    acheterMoulin() {
        
        if(this.depenserOr(this.prixMoulin)) {

            this.nbrMoulins++;
            this.prixMoulin = this.prixMoulin * 1.5;
            return true;

        }else {
            return false;
        }        
    }

    initialiserCommandes() {
        let initCommandes= [];
        for (let i = 0; i < 10; i++) {
            initCommandes[i] = new Commande(this.lvlBoulangerie); 
        }
        return initCommandes;
    }

    accepterCommande(_id) {
        let index = this.commandes.findIndex(com => com.id == _id);
        this.commandes[index].accepterCommande();
        this.commandesAcceptee.push(this.commandes[index]);
    }

    refuserCommande(_id) {
        let index = this.commandes.findIndex(com => com.id == _id);
        this.commandes[index].refuserCommande();         
    }

}

export { Boulangerie }