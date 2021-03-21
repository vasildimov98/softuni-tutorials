// referentially transparent functions:
function add(a, b) { return a + b };
function mult(a, b) { return a * b};

let x = add(2, mult(3, 4));//mult(3, 4)) can be replaced with 12

//console.log(x);
// not referentially transparent function:
function add(a, b) {
    let result = a + b;
    console.log("Returning " + result);
    return result; // result !== ("Returning " + result)
} 
