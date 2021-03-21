function solve() {
  let textElement = document.getElementById('newText');

    let newListElement = document.createElement('li');
    newListElement.textContent = textElement.value + " ";
    textElement.value = '';

    let removeElement = document.createElement('a');
    let linkText = document.createTextNode('[Delete]');
    removeElement.appendChild(linkText);
    removeElement.href = '#';

    removeElement
        .addEventListener('click', onClickDeleteElement);

    newListElement.appendChild(removeElement);
    let listItems = document.getElementById('items');
    listItems.appendChild(newListElement);
    
    function onClickDeleteElement() {
        newListElement.remove();
    }
}
