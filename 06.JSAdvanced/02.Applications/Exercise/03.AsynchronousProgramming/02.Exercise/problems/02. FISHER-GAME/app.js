const BASE_URL = 'https://fisher-game.firebaseio.com/catches';
const DIV = 'div';
const LABEL = 'label';
const INPUT = 'input';
const BUTTON = 'button';
const HR_TAG = '<hr>';

const LOAD_BTN = document
    .querySelector('.load');
const ADD_BTN = document
    .querySelector('.add');

const ANGLER_INPUT = document
    .querySelector('.angler');
const WEIGHT_INPUT = document
    .querySelector('.weight');
const SPECIES_INPUT = document
    .querySelector('.species');
const LOCATION_INPUT = document
    .querySelector('.location');
const BAIT_INPUT = document
    .querySelector('.bait');
const CAPTURE_TIME_INPUT = document
    .querySelector('.captureTime');

const CATCHES_DIV = document
    .querySelector('#catches');

function attachEvents() {
    LOAD_BTN.addEventListener('click', makeGetRequest);
    ADD_BTN.addEventListener('click', makePostRequest);
}

function makePutRequest(e) {
    let catchToUpdate = e.target.parentElement;

    let catchId = catchToUpdate
        .getAttribute('data-id');
    let putUrl = `/${catchId}.json`;

    let anglerInput = catchToUpdate
        .querySelector('.angler');
    let weightInput = catchToUpdate
        .querySelector('.weight');
    let speciesInput = catchToUpdate
        .querySelector('.species');
    let locationInput = catchToUpdate
        .querySelector('.location');
    let baitInput = catchToUpdate
        .querySelector('.bait');
    let captureTimeInput = catchToUpdate
        .querySelector('.captureTime');

    let angler = anglerInput.value;
    let weight = Number(weightInput.value);
    let species = speciesInput.value;
    let location = locationInput.value;
    let bait = baitInput.value;
    let captureTime = Number(captureTimeInput.value);

    if (!_validateData(angler,
        weight,
        species,
        location,
        bait,
        captureTime))
        return;

    let jsonObject = JSON.stringify({
        angler,
        weight,
        species,
        location,
        bait,
        captureTime,
    });

    fetch(`${BASE_URL}${putUrl}`, {
        method: 'PUT',
        body: jsonObject
    })
        .catch(displayError);
}

function makeDeleteRequest(e) {
    let catchToUpdate = e.target.parentElement;
    let catchId = catchToUpdate
        .getAttribute('data-id');
    let deleteUrl = `/${catchId}.json`;

    fetch(`${BASE_URL}${deleteUrl}`, { method: 'Delete' })
        .then(() => catchToUpdate.remove())
        .catch(displayError);
}

function makePostRequest() {
    let angler = ANGLER_INPUT.value;
    let weight = Number(WEIGHT_INPUT.value);
    let species = SPECIES_INPUT.value;
    let location = LOCATION_INPUT.value;
    let bait = BAIT_INPUT.value;
    let captureTime = Number(CAPTURE_TIME_INPUT.value);

    if (!_validateData(angler,
        weight,
        species,
        location,
        bait,
        captureTime))
        return;

    let jsonObject = JSON.stringify({
        angler,
        weight,
        species,
        location,
        bait,
        captureTime,
    });

    _clearAllInputFields();

    fetch(`${BASE_URL}.json`, {
        method: 'POST',
        body: jsonObject
    });
}

function makeGetRequest() {
    fetch(`${BASE_URL}.json`)
        .then(response => response.json())
        .then(showListOfAllCatches)
        .catch(displayError);
}

function showListOfAllCatches(catches) {
    _removeAllPrevioslyShownCatches();
    Object
        .keys(catches)
        .forEach(key => {
            let catchDiv = createNewCatch(catches, key)
            _addValue(CATCHES_DIV, catchDiv);
        });
}

function displayError(err) {
    console.log(err);
}

function createNewCatch(catches, key) {
    let { angler, weight, species, location, bait, captureTime } = catches[key];

    let catchDiv = _createNewElement(DIV, '', {
        name: 'class',
        value: 'catch'
    }, {
        name: 'data-id',
        value: `${key}`
    });

    let anglerLabel = _createNewElement(LABEL, 'Angler');

    let anglerInput = _createNewElement(INPUT, '', {
        name: 'type',
        value: 'text',
    }, {
        name: 'class',
        value: 'angler',
    }, {
        name: 'value',
        value: angler
    });

    let weightLabel = _createNewElement(LABEL, 'Weight');

    let weightInput = _createNewElement(INPUT, '', {
        name: 'type',
        value: 'text',
    }, {
        name: 'class',
        value: 'weight',
    }, {
        name: 'value',
        value: weight
    });

    let speciesLabel = _createNewElement(LABEL, 'Species');

    let speciesInput = _createNewElement(INPUT, '', {
        name: 'type',
        value: 'text',
    }, {
        name: 'class',
        value: 'species',
    }, {
        name: 'value',
        value: species
    });

    let locationLabel = _createNewElement(LABEL, 'Location');

    let locationInput = _createNewElement(INPUT, '', {
        name: 'type',
        value: 'text',
    }, {
        name: 'class',
        value: 'location',
    }, {
        name: 'value',
        value: location
    });

    let baitLabel = _createNewElement(LABEL, 'Bait');

    let baitInput = _createNewElement(INPUT, '', {
        name: 'type',
        value: 'text',
    }, {
        name: 'class',
        value: 'bait',
    }, {
        name: 'value',
        value: bait
    });

    let captureTimeLabel = _createNewElement(LABEL, 'Capture Time');

    let captureTimeInput = _createNewElement(INPUT, '', {
        name: 'type',
        value: 'text',
    }, {
        name: 'class',
        value: 'captureTime',
    }, {
        name: 'value',
        value: captureTime
    });

    let updateBtn = _createNewElement(BUTTON, 'Update', {
        name: 'class',
        value: 'update',
    });
    let deleteBtn = _createNewElement(BUTTON, 'Delete', {
        name: 'class',
        value: 'update',
    });

    _addEventListenerToButtons(updateBtn, deleteBtn);

    _addValue(catchDiv,
        anglerLabel,
        anglerInput,
        HR_TAG,
        weightLabel,
        weightInput,
        HR_TAG,
        speciesLabel,
        speciesInput,
        HR_TAG,
        locationLabel,
        locationInput,
        HR_TAG,
        baitLabel,
        baitInput,
        HR_TAG,
        captureTimeLabel,
        captureTimeInput,
        HR_TAG,
        updateBtn,
        deleteBtn);

    return catchDiv;
}

function _validateData(angler,
    weight,
    species,
    location,
    bait,
    captureTime) {
    if (!isNaN(angler)
        || !weight
        || !isNaN(species)
        || !isNaN(location)
        || !isNaN(bait)
        || !captureTime)
        return false;

    return true;
}

function _clearAllInputFields() {
    ANGLER_INPUT.value = '';
    WEIGHT_INPUT.value = '';
    SPECIES_INPUT.value = '';
    LOCATION_INPUT.value = '';
    BAIT_INPUT.value = '';
    CAPTURE_TIME_INPUT.value = '';
}

function _addEventListenerToButtons(updateBtn, deleteBtn) {
    updateBtn.addEventListener('click', makePutRequest);
    deleteBtn.addEventListener('click', makeDeleteRequest);
}

function _removeAllPrevioslyShownCatches() {
    while (CATCHES_DIV.firstChild)
        CATCHES_DIV
            .firstChild
            .remove();
}

function _addValue(element, ...values) {
    values
        .forEach(v => {
            if (typeof v == 'string')
                element.innerHTML += v;
            else element.appendChild(v);
        });
}

function _createNewElement(type, content, ...attachments) {
    let element = document
        .createElement(type);

    if (content)
        element.innerHTML = content;

    if (attachments)
        attachments
            .forEach(({ name, value }) => {
                element
                    .setAttribute(name, value);
            });

    return element;
}

attachEvents();