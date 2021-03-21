let string = 'Pesho';
let $String = 'Pesho';
let number = 20;
let number20 = 20;
let float = 20.213;
let decimal = 213.142451561151515616;

Number;

let bool1 = true;
let bool2 = false;

let undefined;

console.log(undefined);

let nullable = null;

console.log(nullable);

function sum(x, y) {
    if (x == 5) {
        var result = 20;
    }
     console.log(result);
    result = x + y;
  return result;
}

Sum(5, 12);

function logTruthiness (val) {
    if (val) {
        console.log("Truthy!");
    } else {
        console.log('Falsy.')
    }
}

logTruthiness (3.14);      //Truthy!
logTruthiness ({});        //Truthy!
logTruthiness (NaN);       //Falsy.
logTruthiness ("NaN");     //Truthy!
logTruthiness ([]);        //Truthy!
logTruthiness (null);      //Falsy.
logTruthiness ("");        //Falsy.
logTruthiness (undefined); //Falsy.
logTruthiness (0);         //Falsy.

let sum = (a, b = 5) => a + b;

let result = sum(12)

console.log(result);

function running() {
    return 'Running'
}

function category(run, type) {
    return run() + ' ' + type;
}

console.log(category(running, 'sprint'));



function hypotenuse(m, n) {
    function square(num) {
        return num * num;
    }
    return Math.sqrt(square(m) + square(n))
}

console.log(hypotenuse(3, 4));
