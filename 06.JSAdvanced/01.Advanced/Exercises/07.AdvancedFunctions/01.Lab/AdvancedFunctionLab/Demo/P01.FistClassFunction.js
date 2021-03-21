function createFunction(criteria) {
    if (criteria == 'add') {
        return add;
    } else {
        return pow;
    }
}

function mathOperation(operation, num1, num2) {
    let oprResult = operation(num1, num2);
    return oprResult;
}

function add(number1, number2) {
    return number1 + number2;
}

function pow(number, sqr) {
    let result = number ** sqr;

    return result;
}

let number = 10;

let sqrResult = mathOperation(pow, number, 2);
let addResult = mathOperation(add, number, number);

console.log(sqrResult);
console.log(addResult);

let funcCreated = createFunction('add');

console.log(funcCreated(1, 3));

let arr = [1, 2, 5, 6, 12];

let foundNumber = arr.some(n => n > 5);

console.log(foundNumber);

function mapPow(n) {
    return n ** 2;
}

let multArr = arr.map(mapPow);

console.log(multArr);

// f(x) = x ** 2;