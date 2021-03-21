function solve() {
    let inputElements = document
        .querySelectorAll('input');
    
    let tableElement = document
        .querySelector('table')
    let checkParagraph = document
        .querySelector('#check p');

    let checkBtn = document
        .querySelectorAll('button')[0];
    let clearBtn = document
        .querySelectorAll('button')[1];

    checkBtn.style.cursor = 'pointer';
    clearBtn.style.cursor = 'pointer';

    checkBtn.addEventListener('click', checkTableValue);
    clearBtn.addEventListener('click', clearTableValue);

    function checkTableValue() {
        let sudomuMatrix = [
        ];

        fillMatrixWithInput(sudomuMatrix);

        let isSudomuCorrect = true;
        for (let i = 0; i < sudomuMatrix.length; i++) {
            let row = sudomuMatrix[i];
            let col = sudomuMatrix
                .map(r => r[i]);

            if (row.length != [...new Set(row)].length
                || col.length != [...new Set(col)].length) {
                isSudomuCorrect = false;
                break;
            }
        }

        if (isSudomuCorrect) {
            tableElement.style.border = '2px solid green';
            checkParagraph.style.color = 'green'
            checkParagraph.textContent = 'You solve it! Congratulations!';
        } else {
            tableElement.style.border = '2px solid red';
            checkParagraph.style.color = 'red'
            checkParagraph.textContent = 'NOP! You are not done yet...';
        }
    }

    function clearTableValue() {
        [...inputElements]
            .forEach(e => e.value = '');
        tableElement.style.border = 'none';
        checkParagraph.textContent = '';
    }

    function fillMatrixWithInput(matrix) {
        let matrixLenght = inputElements.length == 81 ? 9 : 3;
        let inputIndex = 0;
        for (let row = 0; row < matrixLenght; row++) {
            matrix[row] = [];
            for (let col = 0; col < matrixLenght; col++) {
                matrix[row][col] = inputElements[inputIndex++].value;
            }
        }
    }
}