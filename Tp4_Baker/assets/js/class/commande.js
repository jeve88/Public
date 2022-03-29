import { fixRandom, twoDecimalRandom } from './rands.js';
import { StatutCommande } from './statutCommande.js';

class Commande
{
    static compteurId = 1;

    constructor(_lvlBoulangerie) {
        this.level = _lvlBoulangerie;
        this.id = 0;
        this.nbrBaguettes = 0;
        this.prixBaguette = 0;
        this.prixTotal = 0;
        this.temps = 0; 
        this.statutCommande = StatutCommande.EnAttente;
        this.tpsFinalisation = 3;
    }


    gestionCommandeParSeconde(){
        if(this.statutCommande == StatutCommande.EnAttente) {

            this.attendreCommande();

        }else if( this.statutCommande != StatutCommande.Annulee 
                && this.statutCommande != StatutCommande.Terminee ){
                    
                    this.temps > 0 ? this.temps-- : this.statutCommande = StatutCommande.Annulee;
        }
    }
    

    attendreCommande() {
       
        if(fixRandom(0,9) <= 4){ // 50% de chance de déclencher la commande

        this.id = Commande.compteurId++;
        this.nbrBaguettes = fixRandom(5, 30 * this.level);
        this.prixBaguette = twoDecimalRandom(this.level/10, 30*(this.level/100));
        this.prixTotal = this.nbrBaguettes * this.prixBaguette;
        this.temps = fixRandom(5, 10); 
        this.statutCommande = StatutCommande.NouvelleCommande;
        }        
    }  

    accepterCommande() {
        this.statutCommande = StatutCommande.Acceptee;
        this.temps = 90;
    }

    refuserCommande() {
        this.statutCommande = StatutCommande.Annulee;
    }

    livrerCommande() {
        this.statutCommande = StatutCommande.Terminee;
    }

    finaliserCommande() {
        this.tpsFinalisation--;
        if(this.tpsFinalisation == 0) {
            return true;
        }else {
            return false;
        }
    }

}

export { Commande }