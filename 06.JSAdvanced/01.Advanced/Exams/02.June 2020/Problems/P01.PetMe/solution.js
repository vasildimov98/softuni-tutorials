function solve() {
    let adoptionList = document
        .querySelector('#adoption')
        .querySelector('ul');
    let adoptedList = document
        .querySelector('#adopted')
        .querySelector('ul');

    let allInputElements = document
        .querySelectorAll('input');

    let nameInput = allInputElements[0];
    let ageInput = allInputElements[1];
    let kindInput = allInputElements[2];
    let ownerInput = allInputElements[3];

    let addButton = document
        .querySelector('button');

    addButton.addEventListener('click', addNewPet);

    function addNewPet(e) {
        e.preventDefault();

        let name = nameInput.value;
        let age = Number(ageInput.value);
        let kind = kindInput.value;
        let currOwner = ownerInput.value;

        if (!name
            || isNaN(age)
            || !kind
            || !currOwner) {
            return;
        }

        let newPetList = createNewPetList(name, age, kind, currOwner);
        addValue(adoptionList, [newPetList]);

        nameInput.value = '';
        ageInput.value = '';
        kindInput.value = '';
        ownerInput.value = '';
    }

    function createNewPetList(name, age, kind, currOwner) {
        let li = createAnElement('li');

        let p = createAnElement('p');

        let strongName = createAnElement('STRONG', name);

        let strongAge = createAnElement('STRONG', age);

        let strongKind = createAnElement('STRONG', kind);

        addValue(p, [
            strongName,
            ' is a ',
            strongAge,
            ' year old ',
            strongKind,
        ]);

        let spanText = `Owner: ${currOwner}`;
        let span = createAnElement('span', spanText);

        let contactText = `Contact with owner`;
        let contactBtn = createAnElement('button', contactText);

        contactBtn.addEventListener('click', changeButton);

        addValue(li, [
            p,
            span,
            contactBtn,
        ]);

        return li;
    }

    function changeButton(e) {
        let buttonParent = e.target.parentElement;

        e.target.remove();

        let newDivElemet = createAnElement('div');

        let inputElement = createAnElement('input', '', {
            name: 'placeholder',
            value: 'Enter your names',
        });

        let yesButton = createAnElement('button', 'Yes! I take it!');

        yesButton.addEventListener('click', movePetToAdopted);

        addValue(newDivElemet, [inputElement, yesButton]);

        addValue(buttonParent, [newDivElemet]);
    }

    function movePetToAdopted(e) {
        let divElement = e.target.parentElement;
        let newOwner = divElement
            .querySelector('input')
            .value;

        if (!newOwner) {
            return;
        }

        let listElement = divElement.parentElement;

        divElement.remove();

        let spanElement = listElement
            .querySelector('span');

        let newSpanText = `New Owner: ${newOwner}`;

        spanElement.textContent = newSpanText;

        let checkedBtn = createAnElement('button', 'Checked');

        checkedBtn.addEventListener('click', () => {
            listElement.remove();
        });

        addValue(listElement, [spanElement, checkedBtn]);

        addValue(adoptedList, [listElement]);
    }

    function createAnElement(type, text, attribute) {
        let element = document.createElement(type);

        if (text) {
            element.textContent = text;
        }

        if (attribute) {
            let { name, value } = attribute;

            element.setAttribute(name, value);
        }

        return element;
    }

    function addValue(el, valueArr) {
        valueArr.forEach(element => {
            let itemToApeend;
            if (typeof element == 'string') {
                itemToApeend = document
                    .createTextNode(element);

                element = itemToApeend;
            }

            el.appendChild(element);
        });
    }
}