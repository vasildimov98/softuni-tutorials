function showTicTacToeResult(input) {
    let moves = input.map((m) => m.split(' ').map(Number));
    
    let dashboard = [[false, false, false],
    [false, false, false],
    [false, false, false]];

    let count = 0;

    let mark = 'X';
    for (let index = 0; index < moves.length; index++) {
        let move = moves[index];

        let row = move[0];
        let col = move[1];

        if (!dashboard[row][col]) {
            dashboard[row][col] = mark;

            count++;

            if (checkIfPlayerHasWon(mark, dashboard)) {
                console.log(`Player ${mark} wins!`);
                showTheDashboard(dashboard);
                return;
            };

            mark = mark === 'X' ? 'O' : 'X';
        } else {
            console.log('This place is already taken. Please choose another!');
        }

        if (count == 9) {
            console.log('The game ended! Nobody wins :(');
            showTheDashboard(dashboard);
            return;
        }
    }

    function showTheDashboard(dashboard) {
        dashboard.forEach((row) => {
            console.log(row.join('\t'));
        });
    }

    function checkIfPlayerHasWon(mark, dashboard) {
        if (checkIfCellAreEqual(0, 0, 0, 1, 0, 2, mark, dashboard)) {
            return true;
        } else if (checkIfCellAreEqual(1, 0, 1, 1, 1, 2, mark, dashboard)) {
            return true;
        } else if (checkIfCellAreEqual(2, 0, 2, 1, 2, 2, mark, dashboard)) {
            return true;
        } else if (checkIfCellAreEqual(0, 0, 1, 0, 2, 0, mark, dashboard)) {
            return true;
        } else if (checkIfCellAreEqual(0, 1, 1, 1, 2, 1, mark, dashboard)) {
            return true;
        } else if (checkIfCellAreEqual(0, 2, 1, 2, 2, 2, mark, dashboard)) {
            return true;
        } else if (checkIfCellAreEqual(0, 0, 1, 1, 2, 2, mark, dashboard)) {
            return true;
        } else if (checkIfCellAreEqual(2, 0, 1, 1, 0, 2, mark, dashboard)) {
            return true;
        } else {
            return false;
        }
    }

    function checkIfCellAreEqual(row1, col1, row2, col2, row3, col3, mark, dashboard) {
        return dashboard[row1][col1] === mark && dashboard[row2][col2] === mark && dashboard[row3][col3] === mark;
    }
}

showTicTacToeResult([
    "0 1",
    "0 0",
    "0 2",
    "2 0",
    "1 0",
    "1 1",
    "1 2",
    "2 2",
    "2 1",
    "0 0"]
);
showTicTacToeResult([
    "0 0",
    "0 0",
    "1 1",
    "0 1",
    "1 2",
    "0 2",
    "2 2",
    "1 2",
    "2 2",
    "2 1"]
);
showTicTacToeResult([
    "0 1",
    "0 0",
    "0 2",
    "2 0",
    "1 0",
    "1 2",
    "1 1",
    "2 1",
    "2 2",
    "0 0"]
);