const HTML_SELECTOR = {
    createButton: () => document.querySelector('#create > button'),
    tableBody: () => document.querySelector('table > tbody'),
    errorDiv: () => document.querySelector('#error'),
    idInput: () => document.querySelector('#id'),
    firstNameInput: () => document.querySelector('#first-name'),
    lastNameInput: () => document.querySelector('#last-name'),
    facultyNumberInput: () => document.querySelector('#faculty-number'),
    gradeInput: () => document.querySelector('#grade'),
}

const ON_CLICK_EVENT = 'click';
const TR_TAG = 'tr';
const TD_TAG = 'td';

const URL_FOR_POST_OR_GET_REQUEST = 'https://university-27039.firebaseio.com/students.json';

const VALID_NAME_REGEX = /[A-Z][a-z]{2,}/;

const INVALID_ID_MSG = 'Id is empty or already exists!';
const INVALID_FIST_NAME_MSG = 'First name cannot be empty or contain a number!';
const INVALID_LAST_NAME_MSG = 'Last name cannot be empty or contain a number!';
const INVALID_FACULTY_NUMBER_MSG = 'Faculty number is empty or contains a character/s!';
const INVALID_GRADE_MSG = 'Grade can only be 2 3 4 5 or 6!';
const NO_STUDENTS_DATA = 'There are no student\'s data. You can create your first one using the create form!';

const ERROR_DIV = HTML_SELECTOR.errorDiv();
const TABLE_BODY = HTML_SELECTOR.tableBody();

const ID_INPUT = HTML_SELECTOR.idInput();
const FIRST_NAME_INPUT = HTML_SELECTOR.firstNameInput();
const LAST_NAME_INPUT = HTML_SELECTOR.lastNameInput();
const FACULTY_NUMBER_INPUT = HTML_SELECTOR.facultyNumberInput();
const GRADE_INPUT = HTML_SELECTOR.gradeInput();

window
    .addEventListener('load', makeGetRequest);
HTML_SELECTOR
    .createButton()
    .addEventListener(ON_CLICK_EVENT, makePostRequest);

function makeGetRequest() {
    fetch(URL_FOR_POST_OR_GET_REQUEST)
        .then(response => response.json())
        .then(showAllStudents)
        .catch(errorHandler)
}

function showAllStudents(students) {
    if (!students) {
        errorHandler({ message: NO_STUDENTS_DATA });
        TABLE_BODY.innerHTML = '';
        return;
    }

    TABLE_BODY.innerHTML = '';

    Object
        .values(students)
        .sort(({ id: id1 }, { id: id2 }) => {
            return Number(id1) - Number(id2);
        })
        .forEach(({ id, firstName, lastName, facultyNumber, grade }) => {
            let tableRowWithStudentInfo
                = _createDomElement(TR_TAG, '',
                    _createDomElement(TD_TAG, id),
                    _createDomElement(TD_TAG, firstName),
                    _createDomElement(TD_TAG, lastName),
                    _createDomElement(TD_TAG, facultyNumber),
                    _createDomElement(TD_TAG, grade));

            TABLE_BODY.appendChild(tableRowWithStudentInfo);
        });
}

function makePostRequest(e) {
    e.preventDefault();

    let id = ID_INPUT.value;
    let firstName = FIRST_NAME_INPUT.value;
    let lastName = LAST_NAME_INPUT.value;
    let facultyNumber = FACULTY_NUMBER_INPUT.value;
    let grade = Number(GRADE_INPUT.value);

    if (!validateData(id,
        firstName,
        lastName,
        facultyNumber,
        grade)) return;

    let body = JSON
        .stringify({
            id,
            firstName,
            lastName,
            facultyNumber,
            grade,
        });


    let postInitObj = {
        method: 'POST',
        body,
    };

    fetch(URL_FOR_POST_OR_GET_REQUEST, postInitObj)
        .then(makeGetRequest)
        .catch(errorHandler);

    ID_INPUT.value = '';
    FIRST_NAME_INPUT.value = '';
    LAST_NAME_INPUT.value = '';
    FACULTY_NUMBER_INPUT.value = '';
    GRADE_INPUT.value = '';
}

function validateData(id, firstName, lastName, facultyNumber, grade) {
    if (!id) {
        errorHandler({ message: INVALID_ID_MSG });
        return false;
    }

    if (!firstName
        || !VALID_NAME_REGEX.test(firstName)) {
        errorHandler({ message: INVALID_FIST_NAME_MSG });
        return false;
    }


    if (!lastName
        || !VALID_NAME_REGEX.test(lastName)) {
        errorHandler({ message: INVALID_LAST_NAME_MSG });
        return false;
    }

    if (!facultyNumber
        || isNaN(facultyNumber)) {
        errorHandler({ message: INVALID_FACULTY_NUMBER_MSG });
        return false;
    }

    if (!grade
        || grade < 2
        || grade > 6) {
        errorHandler({ message: INVALID_GRADE_MSG });
        return false;
    }

    return true;
}

function errorHandler({ message }) {
    ERROR_DIV.setAttribute('style', 'display: block');

    ERROR_DIV.innerHTML = message;
    setTimeout(() => {
        ERROR_DIV
            .setAttribute('style', 'display: none');
        ERROR_DIV.innerHTML = '';
    }, 5000);
}

function _createDomElement(type, text, ...children) {
    var element = document.createElement(type);

    if (text) element.innerHTML = text;

    if (children)
        children
            .forEach(child => element
                .appendChild(child));

    return element;
}