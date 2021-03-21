function getGCD(first, second) {
    let firstNumber = Number(first);
    let secondNumber = Number(second);

    let lowerNumber = Math.min(firstNumber, secondNumber);
    let higherNumber = Math.max(firstNumber, secondNumber);

    let greatestCommonDivisor;
    for (let i = lowerNumber; i > 0; i--) {
        if (lowerNumber % i == 0 && higherNumber % i == 0) {
            greatestCommonDivisor = i;
            break;
        }
    }

    console.log(greatestCommonDivisor);
}

getGCD(15, 5);
getGCD(2154, 458);
  
function getGCDByRecursion(first, second) {
    let firstNumber = Number(first);
    let secondNumber = Number(second);

    if (secondNumber == 0) {
        console.log(firstNumber);
        return;
    }

    let reminder = firstNumber % secondNumber;
    getGCDByRecursion(secondNumber, reminder);
}

getGCDByRecursion(15, 5);
getGCDByRecursion(2154, 458);