function addItem() {
    let textElement = document.getElementById('newItemText');

    let newListElement = document.createElement('li');

    newListElement.textContent = textElement.value;
    textElement.value = '';

    let itemsListElement = document.getElementById('items');
    itemsListElement.appendChild(newListElement);
}