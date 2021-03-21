function showBiggestNumberInMatrix(matrix) {
    let currMaxNum = matrix
            .map((row) => Math.max(...row))
            .reduce((min, num) => Math.max(min, num), Number.MIN_SAFE_INTEGER);

    console.log(currMaxNum);
}

showBiggestNumberInMatrix([[20, 50, 10],
                          [8, 33, 145]]);
showBiggestNumberInMatrix([[3, 5, 7, 12],
                        [-1, 4, 33, 2],
                        [8, 3, 0, 4]]);