function showIfMatrixIsMagical(matrix) {
    let initialSum = matrix[0].reduce((sum, el) => sum += el);
    for (let row = 0; row < matrix.length; row++) {
        let rowSum = getSumOfRow(matrix[row]);

        if (rowSum != initialSum) {
            console.log(false);
            return;
        }
    }

    for (let col = 0; col < matrix[0].length; col++) {
        let colSum = getSumOfCol(col);
        if (colSum != initialSum) {
            console.log(false);
            return
        }
    }

    console.log(true);

    function getSumOfRow(arr) {
        return arr
            .reduce((sum, el) => sum += el);
    }

    function getSumOfCol(col) {
        let sum = 0;
        for (let row = 0; row < matrix.length; row++) {
            sum += matrix[row][col];
        }

        return sum;
    }
}

showIfMatrixIsMagical([
    [4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
);
showIfMatrixIsMagical([
    [11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]
);
showIfMatrixIsMagical([
    [1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]
);