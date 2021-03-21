function showNewMatrix(input) {
    let matrix = input.map((str) => str.split(' ').map(Number));

    let mainDiagonal = 0;
    let secondaryDiagonal = 0;
    for (let row = 0; row < matrix.length; row++) {
        mainDiagonal += matrix[row][row];
        secondaryDiagonal += matrix[matrix.length - 1 - row][row];
    }

    if (mainDiagonal == secondaryDiagonal) {
        for (let row = 0; row < matrix.length; row++) {
            for (let col = 0; col < matrix[row].length; col++) {
                if (!validateIndex(row, col, matrix.length - 1 - row)) {
                    matrix[row][col] = mainDiagonal;
                }
            }
        }
    }

    matrix.forEach((arr) => {
        console.log(arr.join(' '));
    });

    function validateIndex(row, col, length) {
        return row === col || col === length;
    }
}

showNewMatrix([
    '5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1']
);

showNewMatrix([
    '1 1 1',
    '1 1 1',
    '1 1 0']
);