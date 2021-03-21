const SUBMIT_BUTTON = document
    .querySelector('#submit');

const LOCATION_URL = 'https://judgetests.firebaseio.com/locations.json';
const BASE_FORECAST_URL = 'https://judgetests.firebaseio.com/forecast';

const LOCATION_INPUT = document
    .querySelector('#location');
const FORECAST_SECTION = document
    .querySelector('#forecast');
const CURRENT_DIV = document
    .querySelector('#current');
const UPCOMMING_DIV = document
    .querySelector('#upcoming');

const SYMBOLS = {
    Sunny: '&#x2600',
    'Partly sunny': '&#x26C5',
    Overcast: '&#x2601',
    Rain: '&#x2614',
    Degrees: '&#176',
};

function attachEvents() {
    SUBMIT_BUTTON.addEventListener('click', makeGetRequestForLocation);
}

function makeGetRequestForLocation() {
    fetch(LOCATION_URL)
        .then(response => response.json())
        .then(_getAllPromisesForForecasts)
        .then(_showForecastInfo)
        .catch(_displayAnError);
}

function _displayAnError() {
    err = 'Error ';
    FORECAST_SECTION.setAttribute('style', 'display: block;');

    FORECAST_SECTION.textContent = err;
}

function _showForecastInfo([todayForcast, upcomingForecast]) {
    FORECAST_SECTION.setAttribute('style', 'display: block;');

    _clearOldDataIfNeeded();

    _showForecastForToday(todayForcast);
    _showThreeDayForecast(upcomingForecast);
}

function _clearOldDataIfNeeded() {
    LOCATION_INPUT.value = '';

    [...CURRENT_DIV.children]
        .slice(1)
        .forEach(ch => ch.remove());
    [...UPCOMMING_DIV.children]
        .slice(1)
        .forEach(ch => ch.remove());
}

function _showThreeDayForecast(upcomingForecast) {
    let { forecast } = upcomingForecast;
    let forecastInfoDiv = _createElement('div', {
        name: 'class',
        value: 'forecast-info',
    });

    forecast.forEach(f => {
        let { condition, high, low } = f;
        let spanForData = _createElement('span', {
            name: 'class',
            value: 'upcoming',
        });

        let spanForSymbol = _createElement('span', {
            name: 'class',
            value: 'symbol',
        });
        spanForSymbol.innerHTML = SYMBOLS[condition];

        let spanForDegree = _createElement('span', {
            name: 'class',
            value: 'forecast-data',
        });
        spanForDegree.innerHTML = `${low}${SYMBOLS.Degrees}/${high}${SYMBOLS.Degrees}`;

        let spanForCondition = _createElement('span', {
            name: 'class',
            value: 'forecast-data',
        });
        spanForCondition.textContent = condition;

        _addValue(spanForData, spanForSymbol, spanForDegree, spanForCondition);

        _addValue(forecastInfoDiv, spanForData);
    });

    _addValue(UPCOMMING_DIV, forecastInfoDiv);
}

function _showForecastForToday({ forecast, name }) {
    let { condition, high, low } = forecast;

    let forcastsDiv = _createElement('div', {
        name: 'class',
        value: 'forecasts'
    });

    let conditionSymbolSpan = _createElement('span', {
        name: 'class',
        value: 'condition symbol',
    });
    conditionSymbolSpan.innerHTML = SYMBOLS[condition];

    let spanForData = _createElement('span', {
        name: 'class',
        value: 'condition',
    });

    let spanForName = _createElement('span', {
        name: 'class',
        value: 'forecast-data',
    });

    _addValue(spanForName, name)

    let spanForHighAndLow = _createElement('span', {
        name: 'class',
        value: 'forecast-data',
    });
    spanForHighAndLow.innerHTML = `${low}${SYMBOLS.Degrees}/${high}${SYMBOLS.Degrees}`;

    let spanForCondition = _createElement('span', {
        name: 'class',
        value: 'forecast-data',
    });
    _addValue(spanForCondition, condition)

    _addValue(spanForData, spanForName, spanForHighAndLow, spanForCondition);

    _addValue(forcastsDiv, conditionSymbolSpan, spanForData);

    _addValue(CURRENT_DIV, forcastsDiv);
}

function _addValue(element, ...values) {
    values
        .forEach(v => {
            if (typeof v == 'string')
                v = document
                    .createTextNode(v);

            element
                .appendChild(v);
        });
}

function _createElement(type, attribute) {
    let element = document
        .createElement(type);

    if (attribute) {
        let { name, value } = attribute;

        element.setAttribute(name, value);
    }

    return element;
}

function _getAllPromisesForForecasts(locations) {
    let location = LOCATION_INPUT.value;
    let { code: locationCode } = locations
        .find(l => l.name == location);

    if (locationCode == undefined)
        throw 'Error';

    let todayUrl = `today/${locationCode}.json`
    let todayForcast = fetch(`${BASE_FORECAST_URL}/${todayUrl}`)
        .then(response => response.json());

    let upcomingUrl = `upcoming/${locationCode}.json`
    let upcomingForecast = fetch(`${BASE_FORECAST_URL}/${upcomingUrl}`)
        .then(response => response.json());

    return Promise.all([todayForcast, upcomingForecast]);
}

attachEvents();