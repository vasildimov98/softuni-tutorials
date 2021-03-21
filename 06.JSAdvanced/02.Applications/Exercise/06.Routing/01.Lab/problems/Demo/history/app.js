const headerId = '#header';
const contentDivId = '#content';
const pageTitleId = '#title';
const documentTitlePath = 'title';

const clickEvent = 'click';
const loadEvent = 'load';
const popstateEvent = 'popstate';

const pageState = { count: 0 };
const functionType = 'function';
const myLinkAttribute = 'myLink';
const pathSeparator = ':';

const mainDocumentTitle = 'Main Page';
const homeDocumentTitle = 'Home Page';
const contactDocumentTitle = 'Contact Page';
const aboutDocumentTitle = 'About Page';
const starWarsDocumentTitle = 'Star Wars Page';

const mainPageTitle = 'My History Demo'
const homePageTitle = 'My Home';
const homePageH2 = '<h2>Welcome to my history demo home page ';
const contactPageTitle = 'My Contacts';
const contactPageH2 = '<h2>How can we help you? Contact us through our phone or write us on facebook!</h2>';
const aboutPageTitle = 'About Us!';
const aboutPageH2 = '<h2>Hello there. We can find anything about us here!</h2>';
const starWarsPageTitle = 'My Star Wars Characters';
const starWarsPageH2 = '<h2>Welcome to your star wars characters page. You can see your top favourite ones in here</h2>';

const baseUrl = 'http://localhost:8000';
const starWarsUrl = 'https://swapi.dev/api/people/';
const emptyString = '';

const homeRoute = '/home:page:temp';
const contactRoute = '/contacts';
const aboutRoute = '/about';
const starWarsRoute = '/star-wars';

const routes = {};
const routesParams = {};

createPath(homeRoute, homePage);
createPath(contactRoute, contactsPage);
createPath(aboutRoute, aboutPage);
createPath(starWarsRoute, starWarsPage);

const htmlSelector = {
    divHeader: () => document.querySelector(headerId),
    contentDiv: () => document.querySelector(contentDivId),
    pageTitle: () => document.querySelector(pageTitleId),
    documentTitle: () => document.querySelector(documentTitlePath),
};

const contentDiv = htmlSelector
    .contentDiv();
const pageTitle = htmlSelector
    .pageTitle();
const documentTitle = htmlSelector
    .documentTitle();

htmlSelector
    .divHeader()
    .addEventListener(clickEvent, showCurrPageByRouter);
window
    .addEventListener(loadEvent, (e) => router(e.target));
window
    .addEventListener(popstateEvent, (e) => router(e, true))

function createPath(path, callback) {
    const allPaths = path
        .split(pathSeparator);
    const realPath = allPaths.splice(0, 1);

    routes[realPath] = callback;
    routesParams[realPath] = allPaths;
}

function showMainPage() {
    documentTitle.innerHTML = mainDocumentTitle;
    pageTitle.innerHTML = mainPageTitle;
    contentDiv.innerHTML = '';
    history
        .pushState(
            { count: pageState.count++ },
            '',
            baseUrl
        );
}

function showCurrPageByRouter(e) {
    var target = e.target;
    if (!target.dataset.hasOwnProperty(myLinkAttribute)) {
        if (target.nodeName == 'BUTTON')
            showMainPage();
        return;
    }
    e.preventDefault();

    router(target);
}

function router(target, isBack) {
    if (!isBack) 
    {
        let href = target.href;
        history
            .pushState(
                { count: pageState.count++ },
                '',
                href
            );
    }

    let currRoute = location.pathname;

    if (typeof routes[currRoute] === functionType) {
        let currParams = routesParams[currRoute];

        let seach = location.search;
        let queryParams = [...new URLSearchParams(seach)
            .entries()]
            .filter(e => currParams.includes(e[0]))
            .map(e => e[1]);

        routes[currRoute](...queryParams);
    }
}

function homePage(page, temp) {
    documentTitle.innerHTML = homeDocumentTitle;
    pageTitle.innerHTML = homePageTitle;
    contentDiv.innerHTML = homePageH2 + `=> Page: ${page} | Temp: ${temp}</h2>`;
}

function contactsPage() {
    documentTitle.innerHTML = contactDocumentTitle;
    pageTitle.innerHTML = contactPageTitle;
    contentDiv.innerHTML = contactPageH2;
}

function aboutPage() {
    documentTitle.innerHTML = aboutDocumentTitle;
    pageTitle.innerHTML = aboutPageTitle;
    contentDiv.innerHTML = aboutPageH2;
}

function starWarsPage() {
    documentTitle.innerHTML = starWarsDocumentTitle;
    pageTitle.innerHTML = starWarsPageTitle;
    contentDiv.innerHTML = starWarsPageH2;
    makeGetRequestForStarWarsCharacter();
}

function makeGetRequestForStarWarsCharacter() {
    fetch(starWarsUrl)
        .then(res => res.json())
        .then(showStarWarsCharacters)
        .catch(errorHandler);
}

function showStarWarsCharacters(data) {
    let characters = data.results;

    contentDiv.innerHTML += characters
        .map(({ name, height }) => `<p><strong>${name} ${height}</strong></p>`)
        .join(' ');
}

function errorHandler() {
    contentDiv.innerHTML += '<h2>Nothing found</h2>';
}