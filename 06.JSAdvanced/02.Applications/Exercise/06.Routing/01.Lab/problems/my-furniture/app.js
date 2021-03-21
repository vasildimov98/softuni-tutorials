const navClass = '.topnav';
const createClass = '.create';
const furnitureClass = '.all-furniture';
const currFurnitureClass = '.curr-furniture';
const myFurnitureClass = '.my-furniture';
const delFurnitureClass = '.del-furniture';
const primaryBtnClass = '.btn-primary';
const errorDivClass = '.error';
const furnituresDivsClass = '.furnitures';

const makeId = '#new-make';
const modelId = '#new-model';
const yearId = '#new-year';
const descriptionId = '#new-description';
const priceId = '#new-price';
const imageId = '#new-image';
const materialId = '#new-material';
const currFurnituresDivId = '#clicked-furniture';
const delFurnituresDivId = '#del-cur-furniture';


const clickEvent = 'click';
const loadEvent = 'load';
const popstateEvent = 'popstate';

const linkTag = 'A';
const styleAttr = 'style';
const hideEl = 'display: none';
const showEl = 'display: block';
const getRequest = 'GET';
const postRequest = 'POST';
const deleteRequest = 'DELETE';
const myFurnPartialName = 'myFurnPartial';
const myDelFurnPartialName = 'myDeleteFurnPartial';
const routeSeparator = '/';

const startPageRoute = '/';
const createRoute = '/furniture/create';
const allFurnitureRoute = '/furniture/all';
const detailsRoute = '/furniture/details';
const myFurnitureRoute = '/furniture/mine';
const deleteRoute = '/furniture/delete';

const basePageUrl = 'http://localhost:3000';
const hrefForFurnitures = basePageUrl + allFurnitureRoute;
const furnitureURLForGetAndPostRequest = 'https://furniture-store-8210a.firebaseio.com/furniture.json';
const basefurnitureURLSpecificRequest = 'https://furniture-store-8210a.firebaseio.com/furniture';

const furnitureTemplatePath = './furniture-template.hbs';
const furniturePartialPath = './furn-partial.hbs';
const detailsTamplatePath = './detail-template.hbs';
const deleteTamplatePath = './delete-template.hbs';
const deleteFurnTemplatePath = './delete-furniture-template.hbs';
const deleteFurnPartialPath = './delete-furn-partial.hbs';

const makeModelErrorMsg = '<p>Make and Model must be at least 4 symbols long!</p>';
const yearErrorMsg = '<p>Year must be between 1950 and 2050!</p>';
const descriptionErrorMsg = '<p>Description must be more than 10 symbols!</p>';
const priceErrorMsg = '<p>Price must be a positive number!</p>';
const imageErrorMsg = '<p>Image URL is required!</p>';

const htmlSelector = {
    navigationBar: () => document.querySelector(navClass),
    createContainer: () => document.querySelector(createClass),
    furnitureContainer: () => document.querySelector(furnitureClass),
    currFurnitureContainer: () => document.querySelector(currFurnitureClass),
    myFurnitureContainer: () => document.querySelector(myFurnitureClass),
    delFurnitureContainer: () => document.querySelector(delFurnitureClass),
    primaryBtn: () => document.querySelector(primaryBtnClass),
    makeInput: () => document.querySelector(makeId),
    modelInput: () => document.querySelector(modelId),
    yearInput: () => document.querySelector(yearId),
    descriptionInput: () => document.querySelector(descriptionId),
    priceInput: () => document.querySelector(priceId),
    imageInput: () => document.querySelector(imageId),
    materialInput: () => document.querySelector(materialId),
    errorDiv: () => document.querySelector(errorDivClass),
    furnituresDiv: () => document.querySelectorAll(furnituresDivsClass),
    currFurnituresDiv: () => document.querySelector(currFurnituresDivId),
    delFurnituresDiv: () => document.querySelector(delFurnituresDivId),
};

const routes = {
    [startPageRoute]: hideAllContainers,
    [createRoute]: htmlSelector.createContainer,
    [allFurnitureRoute]: htmlSelector.furnitureContainer,
    [detailsRoute]: htmlSelector.currFurnitureContainer,
    [myFurnitureRoute]: htmlSelector.myFurnitureContainer,
    [deleteRoute]: htmlSelector.delFurnitureContainer,
};

window
    .addEventListener(loadEvent, () => redirectPagePath(location.href));
window
    .addEventListener(popstateEvent, () => routerPath(location.pathname));
htmlSelector
    .navigationBar()
    .addEventListener(clickEvent, renderPage);
htmlSelector
    .primaryBtn()
    .addEventListener(clickEvent, makePostRequestForFurniture);
htmlSelector
    .furnituresDiv()[0]
    .addEventListener(clickEvent, takePathAndRedirectIt);
htmlSelector
    .furnituresDiv()[1]
    .addEventListener(clickEvent, takePathAndRedirectIt);
htmlSelector
    .delFurnituresDiv()
    .addEventListener(clickEvent, delFurniture);

function delFurniture() {
    let pathnameParts = location.pathname.split(routeSeparator);
    let productId = pathnameParts[pathnameParts.length - 1]

    const requestInfo = `${basefurnitureURLSpecificRequest}/${productId}.json`;
    const deleteObj = { method: deleteRequest };
    fetch(requestInfo, deleteObj)
        .then(() => history.back())
        .catch(errorHandler);
}

function takePathAndRedirectIt(e) {
    const target = e.target;
    if (target.tagName != linkTag) return;
    e.preventDefault();
    const href = target.href;
    redirectPagePath(href);
}

function makeGetRequestForClickedFurniture(id, templatePath) {
    const requestInfo = `${basefurnitureURLSpecificRequest}/${id}.json`;
    fetch(requestInfo)
        .then(res => res.json())
        .then(fur => renderCurrFurrDetails(fur, templatePath));
}

function renderCurrFurrDetails(furnitureData, templatePath) {
    getTemplate(templatePath)
        .then(template => {
            let createFurDetailDiv = Handlebars.compile(template);

            if (templatePath == detailsTamplatePath)
                htmlSelector.currFurnituresDiv().innerHTML = createFurDetailDiv(furnitureData);
            else htmlSelector.delFurnituresDiv().innerHTML = createFurDetailDiv(furnitureData);
        });
}

function makePostRequestForFurniture(e) {
    e.preventDefault();

    const makeInput = htmlSelector.makeInput();
    const modelInput = htmlSelector.modelInput();
    const yearInput = htmlSelector.yearInput();
    const descriptionInput = htmlSelector.descriptionInput();
    const priceInput = htmlSelector.priceInput();
    const imageInput = htmlSelector.imageInput();
    const materialInput = htmlSelector.materialInput();

    let make = makeInput.value;
    let model = modelInput.value;
    let year = Number(yearInput.value);
    let description = descriptionInput.value;
    let price = Number(priceInput.value);
    let image = imageInput.value;
    let material = materialInput.value;

    if (!validateFurnitureData(make, model, year, description, price, image)) return;

    let furnitureObj = {};
    if (!material)
        furnitureObj = { make, model, year, description, price, image };
    else furnitureObj = { make, model, year, description, price, image, material };

    makeInput.value = '';
    modelInput.value = '';
    yearInput.value = '';
    descriptionInput.value = '';
    priceInput.value = '';
    imageInput.value = '';
    materialInput.value = '';

    const postObj = {
        method: postRequest,
        body: JSON.stringify(furnitureObj),
    };

    fetch(furnitureURLForGetAndPostRequest, postObj)
        .then(() => redirectPagePath(hrefForFurnitures))
        .catch(errorHandler);
}

function makeGetRequestForAllFurniture(templatePath, partialPath, partialName) {
    fetch(furnitureURLForGetAndPostRequest)
        .then(res => res.json())
        .then((f) => renderAllFurniture(f, templatePath, partialPath, partialName));
}

function renderAllFurniture(furniture, templatePath, partialPath, partialName) {
    Object
        .keys(furniture)
        .forEach(id => furniture[id]['id'] = id);

    Promise
        .all([getTemplate(templatePath), getTemplate(partialPath)])
        .then(([template, partial]) => {
            Handlebars.registerPartial(partialName, partial);
            var createFurn = Handlebars.compile(template);

            let allFurniture = createFurn({ furniture });


            if (!partialName.includes('Del'))
                htmlSelector.furnituresDiv()[0].innerHTML = allFurniture;
            else htmlSelector.furnituresDiv()[1].innerHTML = allFurniture;

        })
        .catch(errorHandler);
}

function getTemplate(path) {
    return fetch(path)
        .then(res => res.text());
}

function validateFurnitureData(make, model, year, description, price, image) {
    let errorMsg = '';

    if (make.length < 4)
        errorMsg += makeModelErrorMsg;
    if (model.length < 4)
        errorMsg += makeModelErrorMsg;
    if (!(year >= 1950 && year <= 2050))
        errorMsg += yearErrorMsg;
    if (description.length <= 10)
        errorMsg += descriptionErrorMsg;
    if (price <= 0)
        errorMsg += priceErrorMsg;
    if (!image)
        errorMsg += imageErrorMsg;

    if (errorMsg) {
        errorHandler({ message: errorMsg });
        return false;
    }

    return true;
}

function errorHandler({ message }) {
    const errorDiv = htmlSelector.errorDiv();
    errorDiv.style.display = 'block';
    errorDiv.innerHTML = message;

    setTimeout(() => errorDiv.style.display = 'none', 5000);
};

function renderPage(e) {
    let target = e.target;

    if (target.tagName != linkTag) return;

    e.preventDefault();

    redirectPagePath(target.href);
}

function redirectPagePath(url) {
    history.pushState({}, '', url);

    var pathname = location.pathname;

    routerPath(pathname);
}

function routerPath(route) {
    let currRoute;
    let productId;
    if (route.includes(detailsRoute)) {
        const routeParts = route
            .split(routeSeparator);

        productId = routeParts.splice(routeParts.length - 1)[0];
        route = routeParts.join(routeSeparator);
        currRoute = routes[detailsRoute]();
    } else if (route.includes(deleteRoute)) {
        const routeParts = route
            .split(routeSeparator);

        productId = routeParts.splice(routeParts.length - 1)[0];
        route = routeParts.join(routeSeparator);
        currRoute = routes[deleteRoute]();
    } else currRoute = routes[route]();

    if (currRoute == undefined) return;

    hideAllContainers();

    currRoute.setAttribute(styleAttr, showEl);

    switch (route) {
        case allFurnitureRoute:
            makeGetRequestForAllFurniture(furnitureTemplatePath, furniturePartialPath, myFurnPartialName);
            break;
        case myFurnitureRoute:
            makeGetRequestForAllFurniture(deleteFurnTemplatePath, deleteFurnPartialPath, myDelFurnPartialName);
            break;
        case detailsRoute:
            makeGetRequestForClickedFurniture(productId, detailsTamplatePath);
            break;
        case deleteRoute:
            makeGetRequestForClickedFurniture(productId, deleteTamplatePath);
            break;
    }
}

function hideAllContainers() {
    Object
        .values(routes)
        .filter(f => f !== hideAllContainers)
        .forEach(r => r().setAttribute(styleAttr, hideEl));
}