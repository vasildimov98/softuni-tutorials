function showSpiralMatrix(...dimentions) {
    let [rows, cols] = dimentions;

    let [minNum, maxNum, minRow, minCol, maxRow, maxCol] = [1, rows * cols, 0, 0, rows - 1, cols - 1];
    let matrix = [];

    for (let r = 0; r < rows; r++) {
        matrix[r] = [];
    }

    while (minNum <= maxNum) {
        for (let c = minCol; c <= maxCol && minNum <= maxNum; c++) {
            matrix[minRow][c] = minNum++;
        }
        minRow++;

        for (let r = minRow; r <= maxRow && minNum <= maxNum; r++) {
            matrix[r][maxCol] = minNum++;
        }
        maxCol--;

        for (let c = maxCol; c >= minCol && minNum <= maxNum; c--) {
            matrix[maxRow][c] = minNum++;
        }
        maxRow--;

        for (let r = maxRow; r >= minRow && minNum <= maxNum; r--) {
            matrix[r][minCol] = minNum++;
        }
        minCol++;
    }

    matrix.forEach(element => {
        console.log(element.join(' '));
    });
}

showSpiralMatrix(5, 5);
showSpiralMatrix(3, 3);