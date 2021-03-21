function showSumOfDiagonals(matrix) {
    let primaryDiagonal = 0;
    let secondaryDiagonal = 0;

    matrix.forEach((row, i) => {
          primaryDiagonal += matrix[i][i];
          let colOfSecDiag = row.length - 1 - i;
          secondaryDiagonal += matrix[i][colOfSecDiag];
    })

    console.log(primaryDiagonal + ' ' + secondaryDiagonal);
}

showSumOfDiagonals(
    [[20, 40],
    [10, 60]]
   );
showSumOfDiagonals(
    [[3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]]
   );