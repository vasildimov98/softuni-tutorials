function showCoutOfNeighbors(matrix) {
    let count = 0;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {

            let rightEl = matrix[row][col + 1];
            if (rightEl !== undefined && rightEl === matrix[row][col]) {
                count++;
            }

            if (row > 0) {
                let upEl = matrix[row - 1][col];
                if (upEl !== undefined && upEl === matrix[row][col]) {
                    count++;
                }
            }
        }
    }

    console.log(count);
}

showCoutOfNeighbors(
        [['2', '3', '4', '7', '0'],
        ['4', '0', '5', '3', '4'],
        ['2', '3', '5', '4', '2'],
        ['9', '8', '7', '5', '4']]
    );
showCoutOfNeighbors(
        [['test', 'yes', 'yo', 'ho'],
        ['well', 'done', 'yo', '6'],
        ['not', 'done', 'yet', '5']]
    );