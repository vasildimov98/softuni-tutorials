function add(number) {
    let totalSum = number;

    function sum(number) {
        if (number) {
            totalSum += number;

            return sum;
        } else {
            return totalSum;
        }
    }

    sum.toString = () => totalSum;

    return sum;
}

console.log((add(1)()));
console.log((add(1)(6)(-3)()));