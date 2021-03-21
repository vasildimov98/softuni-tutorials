// 1. Initialization

// let arr = [];

// console.log(arr);
// console.log(arr[-1231.234145]);

// arr.length = 10;

// console.log(arr);

// arr = [1, 2, 3, 4, 5, 6, 7];

// arr[arr.length] = 8;

// arr[173] = 20;

// console.log(arr[0]);
// console.log(arr[4]);
// console.log(arr[arr.length - 1]);
// console.log(arr.length); // not contiguous
// console.log(arr); // not dense

// let wierdArr = [1, 'Pesho', true, [], {name:pesho, age:3}];

// console.log(wierdArr);

// 2. Indextion and accesion

// let emptyArr = [];

// console.log(emptyArr.length);

// emptyArr[-1.2] = 'Orange';

// console.log(emptyArr[-1.2]); // 'Orange!'
// console.log(emptyArr[0]); // undefined
// console.log(emptyArr); // (0) ['Orange']
// console.log(emptyArr.length); // 0
// console.log(emptyArr.hasOwnProperty(-1.2));// true

// emptyArr[0] = 'Apple';

// console.log(emptyArr[-1.2]); // 'Orange'
// console.log(emptyArr[0]); // undefined
// console.log(emptyArr); // (1) ['Apple', 'Orange', ...]
// console.log(emptyArr.length); // 1
// console.log(emptyArr.hasOwnProperty(0));// true
// console.log(emptyArr[1000000000000000000000000000000000000000000000000]); //undefined


// // 3. Rest Operations
// function showNames(names) {
//     let firName = names[0];
//     let secName = names[1];

//     let [firstName, secondName, ...others] = names;

//     console.log(firstName);
//     console.log(secondName);
//     console.log(others);
//     console.log(others[2]);
// }

// let names = ['Vasko', 'Pesho', 'Raliza', 'Nadia', 'Liubov', 'Vyara'];
// showNames(names);

// // 4. Mutator Methods

// // A. Pop
// let arr = [1, 15, 874, 75, 86, 56, 123, 19];

// console.log(arr);

// let lastEl = arr.pop();

// console.log(lastEl);
// console.log(arr);

// // B. Push
// console.log(arr)

// let newLength = arr.push(100);

// console.log(newLength);
// console.log(arr);

// // C. Shift

// let arr = [1, 15, 874, 75, 86, 56, 123, 19];

// console.log(arr);

// let firstEl = arr.shift();

// console.log(firstEl);
// console.log(arr);

// // D. Unshift

// let newLength = arr.unshift(1312);

// console.log(newLength);
// console.log(arr[0]);

// // E. Splice

// let names = ['Vasko', 'Pesho', 'Raliza', 'Nadia', 'Liubov', 'Vyara'];

// names.splice(2, 1);

// console.log(names);

// // F. Fill

// let numbers = [1, 2, 3, 4];

// numbers.fill(1, 2);

// console.log(numbers);

// // J. Reverse

// let arr = [1, 2, 3, 4];

// arr.reverse();

// // console.log(arr);

// let unsortedNumbers = [7, 2, 72, 1, 45];

// unsortedNumbers.sort(compareNumbers);

// console.log(unsortedNumbers);

// function compareNumbers(a, b) {
//     return b - a;
// }

// let superheroes = ['Spiderman', 'Superman', 'Ironman', 'Wonderwoman', 'Flash', 'Captain America', 'Batman'];
// 5. Accessors Method

// // A. Joins
// console.log(superheros.join('^-^'));

// // B. IdexOf()
// let indexOfWonderwoman = superheros.indexOf('Wonderwoman');
// let invalidIndex = superheros.indexOf('Supertuperboy');

// console.log(indexOfWonderwoman);
// console.log(invalidIndex);

// // C. Concat()
// let otherHeroes = ['Wolverine', 'Captain Marvel', 'Green Lantern', 'Aquaman'];

// let concatHeroes = superheroes.concat(otherHeroes);

// console.log(concatHeroes);
// console.log(superheroes);

// // D. Includes
// let isHeroExistent = superheroes.includes('Spiderman', -2); // arr.length = 3 + -2 = 1;

// console.log(isHeroExistent);

// // E. Slice
// let firstHalf = superheroes.slice(1, superheroes.length / 2 + 1);

// console.log(firstHalf);

// // 6. Iterator Method;

// // A. ForEach()
// superheroes.forEach((v) => {
//     console.log(v);
// })

// // B. Filter()
// function predicateForName(heroes, letter) {
//     return heroes.filter((h) => {
//         return h[0].toLowerCase() === letter.toLowerCase();
//     })
// }

// console.log(predicateForName(superheroes, 'b'));

// // C. Find()
// let findValue = superheroes.find((h) => h.length >= 10);

// console.log(findValue);

// // D. Some()
// let isTrue = superheroes.some((h) => h.startsWith('B'));

// console.log(isTrue);

// // E. Map()
// let newMapedArr = superheroes.map((h) => h.toUpperCase());

// console.log(newMapedArr);

// // F. Reduce()
// let numbers = [13, 7, 5, 12, 66 , 10, -3];

// let sum = numbers.reduce((s, x) => {
//    return s + x;
// }, 0);

// console.log(sum);

// let average = numbers.reduce((total, number, index, arr) => {
//     total += number;
//     if (index === arr.length - 1){
//         return total / arr.length;
//     } else {
//         return total;
//     }
// }, 0);

// function sortNumbers(a, b) {
//     return a - b;
// };

// console.log(numbers.sort(sortNumbers));

// console.log(average);

/// 7. Array of Arrays

// let matrix = [
//         [[1 , 3, 4, 5], 6, 3, 0],
//         [2, 1, -2],
//         [-5, 17],
//         [7, 3, 9, 12]
//     ];

// let firstArr = matrix[0];
// console.log(matrix[0][0][0]);

// let result = matrix.join(', ');

// console.log(result);