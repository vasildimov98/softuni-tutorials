function solve() {
    let inputElement = document
        .querySelector('input[type="text"]')
    let buttonElement = document
        .querySelector('button[type="button"]');

    let alphabetWithIndex = {};

    for (let index = 65; index < 91; index++) {
        let letter = String.fromCharCode(index);

        alphabetWithIndex[letter] = index - 65;
    }

    buttonElement.addEventListener('click', onClickAddNameToList);

    function onClickAddNameToList() {
        let liElements = document
            .querySelector('ol[type="A"]')
            .children;

        let name = inputElement.value;
        let firstLetter = name[0].toUpperCase();
        let afterFirstLetterPartOfTheName = name
            .slice(1)
            .toLowerCase();
        
        let corectName = firstLetter + afterFirstLetterPartOfTheName;

        let letterIndex = alphabetWithIndex[firstLetter];
        let currLetterPosition = liElements[letterIndex];
        if (currLetterPosition.innerHTML != '') {
            currLetterPosition.innerHTML += ', ';
        }

        currLetterPosition.innerHTML += corectName;
        inputElement.value = '';
    }
}