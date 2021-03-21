function solve() {
    let expressionOutput = document
        .getElementById('expressionOutput');
    let resultOutput = document
        .getElementById('resultOutput');

    document
        .querySelector('.clear')
        .addEventListener('click', onClickClearFunction);

    document
        .querySelector('.keys')
        .addEventListener('click', onClickButtonFunction);

    function onClickButtonFunction(e) {
        let btnPressedValue = e.target.value;

        if (btnPressedValue == '=') {
            let expression = expressionOutput
                .innerHTML
                .split(' ')
                .filter(a => a != '');

            if (expression.length < 3) {
                resultOutput.innerHTML = 'NaN';
            } else {
                let [leftOperand, operator, rightOperand] = expression;

                leftOperand = Number(leftOperand);
                rightOperand = Number(rightOperand);

                let result = getResult(leftOperand, operator, rightOperand);
                resultOutput.innerHTML = result;
            }
        } else if (isOperator(btnPressedValue)) {
            expressionOutput.innerHTML += ` ${btnPressedValue} `;
        } else {
            expressionOutput.innerHTML += btnPressedValue;
        }
    }

    function onClickClearFunction(e) {
        expressionOutput.innerHTML = '';
        resultOutput.innerHTML = '';
    }

    function isOperator(value) {
        return value == '+'
            || value == '-'
            || value == '*'
            || value == '/'
    }

    function getResult(leftOperand, operator, rightOperand) {
        switch (operator) {
            case '+':
                return leftOperand + rightOperand;
            case '-':
                return leftOperand - rightOperand;
            case '*':
                return leftOperand * rightOperand;
            case '/':
                return leftOperand / rightOperand;
        }
    }
}