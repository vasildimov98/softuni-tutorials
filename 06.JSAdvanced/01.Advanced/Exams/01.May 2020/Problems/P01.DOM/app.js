function solve() {
    let addButtonElement = document
        .getElementById('add');
    let openSection = document
        .querySelectorAll('section')[1]
        .querySelectorAll('div')[1];
    let progressSection = document
        .querySelectorAll('section')[2]
        .querySelectorAll('div')[1];
    let completeSection = document
        .querySelectorAll('section')[3]
        .querySelectorAll('div')[1];

    addButtonElement.addEventListener('click', addArticle);

    function addArticle(e) {
        e.preventDefault();

        let taskInputElement = document
            .getElementById('task');
        let descriptionInputElement = document
            .getElementById('description');
        let dateInputElement = document
            .getElementById('date');

        if (taskInputElement.value
            && descriptionInputElement.value
            && dateInputElement.value) {
            createArticle(taskInputElement, descriptionInputElement, dateInputElement);
        }
    }

    function createArticle(titleElement, descriptionInputElement, dateInputElement) {
        let newArticleElement = document
            .createElement('article');

        let h3 = createElement('h3', titleElement.value);

        let firstParagraphValue = `Description: ${descriptionInputElement.value.trim()}`;
        descriptionInputElement
        let fistParagraph = createElement('p', firstParagraphValue);

        let secondParagraphValue = `Due Date: ${dateInputElement
            .value.trim()}`;
        let secondParagraph = createElement('p', secondParagraphValue);

        titleElement.value = '';
        descriptionInputElement.value = '';
        dateInputElement.value = '';

        let divElement = createElement('div', '', 'flex');

        let greenButton = createElement('button', 'Start', 'green')
        let redButton = createElement('button', 'Delete', 'red')
        let orageButton = createElement('button', 'Finish', 'orange');

        divElement.appendChild(greenButton);
        divElement.appendChild(redButton);

        greenButton.addEventListener('click', () => {
            progressSection.appendChild(newArticleElement);
            greenButton.remove();
            divElement.appendChild(orageButton);
        });

        orageButton.addEventListener('click', () => {
            completeSection.appendChild(newArticleElement);
            divElement.remove();
        });

        redButton.addEventListener('click', () => {
            newArticleElement.remove();
        });

        newArticleElement.appendChild(h3);
        newArticleElement.appendChild(fistParagraph);
        newArticleElement.appendChild(secondParagraph);
        newArticleElement.appendChild(divElement);

        openSection.appendChild(newArticleElement);
    }

    function createElement(type, value, className) {
        let element = document
            .createElement(type);

        if (className) {
            element.classList.add(className);
        }

        if (value) {
            element
                .textContent = value;
        }

        return element;
    }
}