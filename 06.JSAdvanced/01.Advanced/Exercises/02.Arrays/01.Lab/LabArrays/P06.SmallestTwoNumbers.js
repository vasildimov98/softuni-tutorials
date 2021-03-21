function showSmallestTwoNumbers(numbers) {
    let [firstNum, secNum] = numbers
                .sort((a, b) => a - b);

    console.log(`${firstNum} ${secNum}`);
}

showSmallestTwoNumbers([30, 15, 50, 5]);
showSmallestTwoNumbers([3, 0, 10, 4, 7, 3]);