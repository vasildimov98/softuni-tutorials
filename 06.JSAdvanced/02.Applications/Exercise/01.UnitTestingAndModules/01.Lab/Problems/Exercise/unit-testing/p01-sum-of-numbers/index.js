let sum = require('./sum-func');

let wrongArr =[1, 'two', 3, 4, {five: 5}, 6, 7, 'tree', 9, 10];
let stringNumbers = ['1', '2', '3', '4', '5', '6', '7', '8', '9', '10'];
let expectedSum = stringNumbers
    .reduce((totalSum, num) => totalSum += Number(num), 0);

console.log(sum(wrongArr));
console.log(expectedSum);