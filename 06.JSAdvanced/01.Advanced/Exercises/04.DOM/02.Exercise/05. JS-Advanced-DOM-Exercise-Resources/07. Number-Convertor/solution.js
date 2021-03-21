function solve() {
    let numberElement = document
        .getElementById('input');
    let outputElement = document
        .getElementById('result');
    let selectElement = document
        .getElementById('selectMenuTo');

    let binaryOptionElement = document
        .createElement('option');
    binaryOptionElement.value = 'binary';
    binaryOptionElement.textContent = 'Binary';

    let hexadecimalOptionElement = document
        .createElement('option');
    hexadecimalOptionElement.value = 'hexadecimal';
    hexadecimalOptionElement.textContent = 'Hexadecimal';

    selectElement.appendChild(binaryOptionElement);
    selectElement.appendChild(hexadecimalOptionElement);

    let binaryMap = {
        'binary': num => num.toString(2),
        'hexadecimal': num => num.toString(16).toUpperCase(),
    }

    document
        .querySelector('button')
        .addEventListener('click', onClickConvert);

    function onClickConvert() {
        let output = binaryMap[selectElement.value](+numberElement.value);

        outputElement.value = output;
    }
}