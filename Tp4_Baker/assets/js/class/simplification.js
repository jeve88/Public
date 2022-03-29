function simplifier(_aSimplifier) {
    if (_aSimplifier < 10000) {
        return (Math.floor( _aSimplifier * 10 ) / 10);
    }
    else if (_aSimplifier < 100000) {
        return (Math.floor( (_aSimplifier / 1000) * 100 ) / 100) + " K";
    }
    else if (_aSimplifier < 1000000) {
        return (Math.floor( (_aSimplifier / 1000) * 10 ) / 10) + " K";
    }
    else if (_aSimplifier < 100000000) {
        return (Math.floor( (_aSimplifier / 1000000) * 100 ) / 100) + " M";
    }else {
        return (Math.floor( (_aSimplifier / 1000000) * 10 ) / 10) + " M";
    }
}

function simplifierSansDecimal(_aSimplifier){
    switch(true) {
        case _aSimplifier < 10000:
            return Math.round(_aSimplifier);
        case _aSimplifier < 1000000:
            return (_aSimplifier / 1000).toFixed(1) + " K";
        default:
        return (_aSimplifier / 1000000).toFixed(1) + " M";

    }
}

export { simplifier, simplifierSansDecimal }; 