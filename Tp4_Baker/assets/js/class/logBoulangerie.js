class LogBoulangerie 
{
    static logger = null;

    constructor()
    {
        this.log = [];
    }

    static getLogger()
    {
        if(LogBoulangerie.logger===null){
            LogBoulangerie.logger = new LogBoulangerie();
        }
        return LogBoulangerie.logger;
    }

    static ajoutMsg(_msg)
    {
        LogBoulangerie.getLogger().ajout(_msg);
    }

    ajout(_msg)
    {
        this.log.unshift(new Date().toLocaleTimeString('fr-FR', { timeZone: 'Europe/Paris' }) 
        + ": " + _msg);

        if(this.log.length >100 ){
            this.log.pop();
        }
    }
}

export { LogBoulangerie }