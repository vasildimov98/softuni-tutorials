function outerFunction() {
    let outerValue = 0;

    return function innerFunction() {
        let innerValue = 2;
        outerValue += innerValue; 
        return outerValue;
    }
}

let func = outerFunction();

console.log(func());
console.log(func());
console.log(func());

''.substring()