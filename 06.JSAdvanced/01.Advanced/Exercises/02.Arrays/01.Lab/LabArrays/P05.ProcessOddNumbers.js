function showDoubledOddNumbersInReverse(numbers) {
    let finalResult = numbers
                .filter((_el, i) => i % 2 != 0)
                .map((el) => el *= 2)
                .reverse()
                .join(' ');

    console.log(finalResult);
}

showDoubledOddNumbersInReverse([10, 15, 20, 25]);
showDoubledOddNumbersInReverse([3, 0, 10, 4, 7, 3]);