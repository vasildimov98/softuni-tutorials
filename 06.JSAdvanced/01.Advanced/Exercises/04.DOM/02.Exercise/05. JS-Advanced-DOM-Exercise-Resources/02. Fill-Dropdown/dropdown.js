function addItem() {
    let textElement = document.getElementById('newItemText');
    let valueElement = document.getElementById('newItemValue');

    let newOptionElement = document.createElement('option');
    newOptionElement.value = valueElement.value;
    newOptionElement.textContent = textElement.value;

    valueElement.value = '';
    textElement.value = '';

    let selectElement = document.getElementById('menu');
    selectElement.appendChild(newOptionElement);
}