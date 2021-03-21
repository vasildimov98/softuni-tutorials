function getFibonator() {
    let result = {
        first: 0,
        second: 1,
        fibonacci: 0,
    };

    function takeFibonacci() {
        result.first = result.second;
        result.second = result.fibonacci;
        result.fibonacci = result.first + result.second;

        return result.fibonacci
    }

    return takeFibonacci;
}

let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13
console.log(fib()); // 21
