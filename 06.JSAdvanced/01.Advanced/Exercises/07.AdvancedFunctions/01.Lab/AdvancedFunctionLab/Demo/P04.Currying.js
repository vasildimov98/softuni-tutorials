function sum(a, b, c) {
    return a + b + c;
}

let currySum = (a) => (b) => (c) => a + b + c;

let notCurryResult = sum(1, 5, 4);
let curryResult = currySum(1)(5)(4);

console.log(notCurryResult);
console.log(curryResult);