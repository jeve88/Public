/**
 * Returns a pseudorandom number with two decimals between _min and _max (included)
 * @param {*} _min 
 * @param {*} _max 
 */
function twoDecimalRandom(_min,_max) {
    return (Math.random() * (_max + 1 - _min) + _min).toFixed(2);
}
/**
 * Returns a pseudorandom number between _min and _max (included)
 * @param {*} _min
 * @param {*} _max 
 */
function fixRandom(_min,_max) {
    return Math.floor(Math.random() * (_max + 1 - _min) + _min);
}

export { fixRandom, twoDecimalRandom };