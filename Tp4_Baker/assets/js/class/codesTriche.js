var codes = [
    {
        nom: 'or',
        valeur: [38,40,37,39] // haut,bas,gauche,droite
    },
    {
        nom: 'lvlUp',
        valeur: [38,38,38,40] // haut,haut,haut,bas
    },
    {
        nom: 'test',
        valeur: [38,38,38,38] // haut, haut, haut, haut
    }
];

function arrayEquals(a, b) {
    return Array.isArray(a) &&
      Array.isArray(b) &&
      a.length === b.length &&
      a.every((val, index) => val === b[index]);
}

function chercherCode(_code) {
    let i = 0;
    let codeTrouve = null;

    while( i < codes.length && codeTrouve == null){
        if( arrayEquals(_code, codes[i].valeur) ){
             codeTrouve = codes[i].nom;
        }
        i++;
    }

    return codeTrouve;
}

export { chercherCode };


