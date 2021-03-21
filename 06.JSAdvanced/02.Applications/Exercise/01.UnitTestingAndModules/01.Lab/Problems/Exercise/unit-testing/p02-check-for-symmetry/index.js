function isSymmetric(arr) {
    if (!Array.isArray(arr))
        return false; // Non-arrays are non-symmetric
    let reversed = arr.slice(0).reverse(); // Clone and reverse
    let equal = (JSON.stringify(arr) == JSON.stringify(reversed));
    return equal;
}


let non_symmetricalArr = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
let symmetricalArr = [1, 2, 3, 4, 5, 5, 4, 3, 2, 1];

console.log(isSymmetric(non_symmetricalArr));
console.log(isSymmetric(symmetricalArr));

console.log(non_symmetricalArr instanceof Array);
console.log(isSymmetric.arguments);

module.exports = isSymmetric; 