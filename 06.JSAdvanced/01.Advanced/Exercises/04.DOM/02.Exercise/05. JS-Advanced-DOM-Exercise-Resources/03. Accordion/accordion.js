function toggle() {
    let buttonElement = document.querySelector('span.button');

    let innerHTML = buttonElement.innerHTML;

    let extraElement = document.getElementById('extra');
    if (innerHTML == 'More') {
        extraElement.style.display = 'block';
        buttonElement.innerHTML = 'Less';
    } else {
        extraElement.style.display = 'none';
        buttonElement.innerHTML = 'More';
    }
}