const goToHomeBtn = document
    .querySelector('header > button');
const pageTitle = document
    .querySelector('#title');
const rootDiv = document
    .querySelector('#root');

const INIT_TITLE = 'My Hashing';
const STAR_WARS_URL = 'https://swapi.dev/api/people/';

const hashRouter = {
    '#home': '<h2>Welcome to our home page.</h2>',
    '#about': '<h2>Hello there. We can find anything about us here</h2>',
    '#contact': '<h2>How can we help you? Contact us through phone or write us on facebook!</h2>',
    '#star-wars': makeGetRequestForStarWarsCharacter,
};

goToHomeBtn.addEventListener('click', changeHashToHome);
window.addEventListener('load', changePageLayout);
window.addEventListener('hashchange', changePageLayout);

function changeHashToHome() {
    location.hash = '';
    pageTitle.textContent = INIT_TITLE;
    rootDiv.innerHTML = '';
}

function changePageLayout() {
    var hash = location.hash;
    
    if (!hash) return;

    let newTitle = hash
        .replace('#', '')
        .split('-')
        .map(w => w[0].toUpperCase() + w.substring(1))
        .join(' ');

    pageTitle.textContent = newTitle;
    var routerResult = hashRouter[hash]
    if (typeof routerResult == 'string')
        rootDiv.innerHTML = routerResult || '<h2>Nothing found</h2>';
    else routerResult();
}

function makeGetRequestForStarWarsCharacter() {
    fetch(STAR_WARS_URL)
        .then(res => res.json())
        .then(showStarWarsCharacters)
        .catch(errorHandler);
}

function showStarWarsCharacters(data) {
    let characters = data.results;

    rootDiv.innerHTML = characters
        .map(({ name, height }) => `<p><strong>${name} ${height}</strong></p>`)
        .join(' ');
}

function errorHandler() {
    rootDiv.innerHTML = '<h2>Nothing found</h2>';
}