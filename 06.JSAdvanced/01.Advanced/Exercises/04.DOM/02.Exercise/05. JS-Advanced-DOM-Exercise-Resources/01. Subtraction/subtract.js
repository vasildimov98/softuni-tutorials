function subtract() {
    let firstNumber = Number(document.getElementById('firstNumber').value);
    let secondNumber = Number(document.getElementById('secondNumber').value);

    let resultElement = document.getElementById('result');

    resultElement.innerHTML += firstNumber - secondNumber;
}