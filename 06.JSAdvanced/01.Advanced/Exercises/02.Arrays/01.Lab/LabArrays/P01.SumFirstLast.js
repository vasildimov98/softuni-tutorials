function showSumOfFirstLast(numbers) {
    let firstNum = Number(numbers[0]);
    let secNum = Number(numbers[numbers.length - 1]);

    let sum = firstNum + secNum;

    console.log(sum);
}

showSumOfFirstLast(['20', '30', '40']);
showSumOfFirstLast(['5', '10']);