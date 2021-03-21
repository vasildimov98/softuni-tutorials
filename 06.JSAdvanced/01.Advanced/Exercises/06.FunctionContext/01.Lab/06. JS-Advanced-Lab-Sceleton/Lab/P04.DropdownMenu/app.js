function solve() {
    let dropdownButton = document
        .getElementById('dropdown');
    let dropdownOptionElements = document
        .getElementById('dropdown-ul');
    let boxElement = document
        .getElementById('box');
    let isFirstTimeClick = true;
    let initColor = 'white';
    let initBackgroundColor = 'black';

    dropdownButton
        .addEventListener('click', showOptions);

    function showOptions() {
        if (isFirstTimeClick) {
            isFirstTimeClick = false;

            dropdownOptionElements
                .style
                .display = 'block';

            dropdownOptionElements
                .addEventListener('click', changeColors);
        } else {
            isFirstTimeClick = true;

            dropdownOptionElements
                .style
                .display = 'none';
            boxElement
                .style
                .backgroundColor = initBackgroundColor;
            boxElement
                .style
                .color = initColor;
        }
    }

    function changeColors(e) {
        let tagName = e.target.tagName;

        if (tagName == 'LI') {
            let rgb = e.target.textContent;

            boxElement.style.backgroundColor = rgb;
            boxElement.style.color = 'black';
        }
    }
}