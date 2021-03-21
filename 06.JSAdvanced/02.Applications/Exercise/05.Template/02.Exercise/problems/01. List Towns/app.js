const htmlSelectors = {
    loadButton: () => document.querySelector('#btnLoadTowns'),
    rootDiv: () => document.querySelector('#root'),
    townsInput: () => document.querySelector('#towns'),
}

const clickEvent = 'click';
const townsSeparator = ', ';
const townsTemplate = './towns-template.hbs';

const { compile } = Handlebars;
const rootDiv = htmlSelectors
    .rootDiv();

const townsInput = htmlSelectors
    .townsInput();

htmlSelectors
    .loadButton()
    .addEventListener(clickEvent, renderTowns);

function renderTowns(e) {
    e.preventDefault();
    let { value } = townsInput;
    let towns = value
        .split(townsSeparator);
    fetch(townsTemplate)
        .then(res => res.text())
        .then((template) => appendTownsToDiv(towns, template))
}

function appendTownsToDiv(towns, template) {
    let createListsOfTowns = compile(template);

    if (towns.includes(''))
        towns = [];
        
    let listsOfTowns = createListsOfTowns({towns});

    rootDiv.innerHTML = listsOfTowns;

    townsInput.value = '';
}