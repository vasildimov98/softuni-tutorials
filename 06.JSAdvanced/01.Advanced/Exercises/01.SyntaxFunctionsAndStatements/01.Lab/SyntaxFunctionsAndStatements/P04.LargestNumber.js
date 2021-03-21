function getTheLargestNum(num1, num2, num3) {
    let largestNum = Math.max(num1, num2, num3);

    let result = `The largest number is ${largestNum}.`;

    console.log(result);
}

getTheLargestNum(5, -3, 16);
getTheLargestNum(-3, -5, -22.5);
