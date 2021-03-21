const HTML_SELECTOR = {
    loadButton: () => document.querySelector('#loadBooks'),
    submitButton: () => document.querySelector('form#create > button'),
    editButton: () => document.querySelector('form#edit > button'),
    deleteButton: () => document.querySelector('form#delete > button'),
    tableBody: () => document.querySelector('.tableBody'),
    errorDiv: () => document.querySelector('#error'),
    createForm: () => document.querySelector('#create'),
    editForm: () => document.querySelector('#edit'),
    deleteForm: () => document.querySelector('#delete'),
    titleInput: () => document.querySelector('#title'),
    authorInput: () => document.querySelector('#author'),
    isbnInput: () => document.querySelector('#isbn'),
    tagsInput: () => document.querySelector('#tags'),
    editTitleInput: () => document.querySelector('#edit-title'),
    editAuthorInput: () => document.querySelector('#edit-author'),
    editIsbnInput: () => document.querySelector('#edit-isbn'),
    editTagsInput: () => document.querySelector('#edit-tags'),
    deleteTitleInput: () => document.querySelector('#delete-title'),
    deleteAuthorInput: () => document.querySelector('#delete-author'),
    deleteIsbnInput: () => document.querySelector('#delete-isbn'),
    deleteTagsInput: () => document.querySelector('#delete-tags'),
}

const URL_FOR_REQUESTS = {
    baseUrl: 'https://my-books-64fa3.firebaseio.com/',
    getOrPostUrl: 'https://my-books-64fa3.firebaseio.com/books.json'
};

const TR_TAG = 'tr';
const TD_TAG = 'td';
const P_TAG = 'p';
const BR_TAG = '<br>';
const BUTTON_TAG = 'button';
const EDIT_BTN_NAME = 'Edit';
const DELETE_BTN_NAME = 'Delete';
const CLICK_EVENT = 'click';
const DATA_KEY = 'data-key';

const MISSING_BOOKS_MSG = 'You don\'t have any saved books. Use create form to save your first book.';
const MISSING_TITLE_MSG = 'Title must exist to create a book';
const MISSING_AUTHOR_MSG = 'Author must exist to create a book';
const MISSING_ISBN_MSG = 'ISBN must exist to create a book';
const MISSING_INPUTS_MSG = 'At least one of the edit input fields should be filled out';

const TABLE_BODY_ELEMENT = HTML_SELECTOR.tableBody();
const ERROR_DIV_ELEMENT = HTML_SELECTOR.errorDiv();
const CREATE_FORM = HTML_SELECTOR.createForm();
const EDIT_FORM = HTML_SELECTOR.editForm();
const DELETE_FORM = HTML_SELECTOR.deleteForm();

const TITLE_INPUT = HTML_SELECTOR.titleInput();
const AUTHOR_INPUT = HTML_SELECTOR.authorInput();
const ISBN_INPUT = HTML_SELECTOR.isbnInput();
const TAGS_INPUT = HTML_SELECTOR.tagsInput();

const EDIT_TITLE_INPUT = HTML_SELECTOR.editTitleInput();
const EDIT_AUTHOR_INPUT = HTML_SELECTOR.editAuthorInput();
const EDIT_ISBN_INPUT = HTML_SELECTOR.editIsbnInput();
const EDIT_TAGS_INPUT = HTML_SELECTOR.editTagsInput();

const DELETE_TITLE_INPUT = HTML_SELECTOR.deleteTitleInput();
const DELETE_AUTHOR_INPUT = HTML_SELECTOR.deleteAuthorInput();
const DELETE_ISBN_INPUT = HTML_SELECTOR.deleteIsbnInput();
const DELETE_TAGS_INPUT = HTML_SELECTOR.deleteTagsInput();

HTML_SELECTOR
    .loadButton()
    .addEventListener(CLICK_EVENT, makeGetRequestForAllBooks);
HTML_SELECTOR
    .submitButton()
    .addEventListener(CLICK_EVENT, makePostRequestForNewBook);
HTML_SELECTOR
    .editButton()
    .addEventListener(CLICK_EVENT, makePutRequestForCurrentBook);
HTML_SELECTOR
    .deleteButton()
    .addEventListener(CLICK_EVENT, makeDeleteRequestForCurrentBook);

function makeDeleteRequestForCurrentBook(e) {
    e.preventDefault();
    let bookId = DELETE_FORM.dataset.key;
    let urlForDeleteRequest = URL_FOR_REQUESTS.baseUrl + `books/${bookId}.json`;
    let deleteObject = {
        method: 'Delete'
    };

    fetch(urlForDeleteRequest, deleteObject)
        .then(makeGetRequestForAllBooks)
        .catch(errorHandler);
}

function makePutRequestForCurrentBook(e) {
    e.preventDefault();
    let bookId = EDIT_FORM.dataset.key;

    let urlForPutOrPatchRequest = URL_FOR_REQUESTS.baseUrl + `books/${bookId}.json`;

    let title = EDIT_TITLE_INPUT.value;
    let author = EDIT_AUTHOR_INPUT.value;
    let isbn = EDIT_ISBN_INPUT.value;
    let tags = EDIT_TAGS_INPUT.value;

    if (!title && !author && !isbn && !tags) {
        errorHandler({ message: MISSING_INPUTS_MSG });
        return;
    }

    if (title && author && isbn && tags) {
        tags = tags.split(', ');
        let body = JSON.stringify({
            title,
            author,
            isbn,
            tags
        });

        let putObject = {
            method: 'PUT',
            body,
        };

        fetch(urlForPutOrPatchRequest, putObject)
            .then(makeGetRequestForAllBooks)
            .catch(errorHandler);
    } else {
        let body = {};

        if (title)
            body['title'] = title;

        if (author)
            body['author'] = author;

        if (isbn)
            body['isbn'] = isbn;

        if (tags)
            body['tags'] = tags.split(', ');

        body = JSON.stringify(body);

        let patchObject = {
            method: 'PATCH',
            body,
        };

        fetch(urlForPutOrPatchRequest, patchObject)
            .then(makeGetRequestForAllBooks)
            .catch(errorHandler);
    }
}

function makePostRequestForNewBook(e) {
    e.preventDefault();

    let title = TITLE_INPUT.value;
    let author = AUTHOR_INPUT.value;
    let isbn = ISBN_INPUT.value;
    let tags = TAGS_INPUT.value;

    if (!_validateInput(title, author, isbn)) return;

    let urlForPostRequest = URL_FOR_REQUESTS.getOrPostUrl;

    let body = {
        title,
        author,
        isbn,
    };

    if (tags != '') {
        body['tags'] = tags.split(', ');
    }

    body = JSON.stringify(body);

    TITLE_INPUT.value = '';
    AUTHOR_INPUT.value = '';
    ISBN_INPUT.value = '';
    TAGS_INPUT.value = '';

    let initObject = {
        method: 'POST',
        body,
    };

    fetch(urlForPostRequest, initObject)
        .then(makeGetRequestForAllBooks)
        .catch(errorHandler);
}

function makeGetRequestForAllBooks() {
    let urlForGetRequest = URL_FOR_REQUESTS.getOrPostUrl;

    fetch(urlForGetRequest)
        .then(response => response.json())
        .then(showAllBooks)
        .catch(errorHandler);
}

function showAllBooks(books) {

    CREATE_FORM.setAttribute('style', 'display: block');
    EDIT_FORM.setAttribute('style', 'display: none');
    DELETE_FORM.setAttribute('style', 'display: none');

    if (!books) {
        TABLE_BODY_ELEMENT.innerHTML = '';
        errorHandler({ message: MISSING_BOOKS_MSG });
        return;
    }

    TABLE_BODY_ELEMENT.innerHTML = '';

    Object
        .entries(books)
        .forEach(([bookId, { title, author, isbn, tags }]) => {
            if (title != ''
                && author != ''
                && isbn != '') {
                let tableRowWithBookInfo
                    = _createDomElement(TR_TAG, '', {}, {},
                        _createDomElement(TD_TAG, title, {}, {}),
                        _createDomElement(TD_TAG, author, {}, {}),
                        _createDomElement(TD_TAG, isbn, {}, {}),
                        _createDomElement(TD_TAG, tags != undefined ? tags.join(BR_TAG) : '', {}, {}),
                        _createDomElement(TD_TAG, '', {}, {},
                            _createDomElement(BUTTON_TAG, EDIT_BTN_NAME, { [DATA_KEY]: bookId }, { [CLICK_EVENT]: showUpdateFormWithBookInfo }),
                            _createDomElement(BUTTON_TAG, DELETE_BTN_NAME, { [DATA_KEY]: bookId }, { [CLICK_EVENT]: showDeleteFormWithBookInfo })));

                TABLE_BODY_ELEMENT.appendChild(tableRowWithBookInfo);
            }
        });
}

function showDeleteFormWithBookInfo(e) {
    DELETE_FORM.setAttribute('style', 'display: block');
    CREATE_FORM.setAttribute('style', 'display: none');
    EDIT_FORM.setAttribute('style', 'display: none');

    let currBookId = e.target.dataset.key;
    DELETE_FORM.dataset.key = currBookId;
    let currBookUrl = URL_FOR_REQUESTS.baseUrl + `books/${currBookId}.json`
    fetch(currBookUrl)
        .then(response => response.json())
        .then(showDeleteBookInfo)
        .catch(errorHandler);
}

function showUpdateFormWithBookInfo(e) {
    EDIT_FORM.setAttribute('style', 'display: block');
    CREATE_FORM.setAttribute('style', 'display: none');
    DELETE_FORM.setAttribute('style', 'display: none');

    let currBookId = e.target.dataset.key;
    EDIT_FORM.dataset.key = currBookId;
    let currBookUrl = URL_FOR_REQUESTS.baseUrl + `books/${currBookId}.json`
    fetch(currBookUrl)
        .then(response => response.json())
        .then(showEditBookInfo)
        .catch(errorHandler);
}

function showDeleteBookInfo({ title, author, isbn, tags }) {
    DELETE_TITLE_INPUT.value = title;
    DELETE_AUTHOR_INPUT.value = author;
    DELETE_ISBN_INPUT.value = isbn;
    DELETE_TAGS_INPUT.value = tags.join(', ');
}

function showEditBookInfo({ title, author, isbn, tags }) {
    EDIT_TITLE_INPUT.value = '';
    EDIT_AUTHOR_INPUT.value = '';
    EDIT_ISBN_INPUT.value = '';
    EDIT_TAGS_INPUT.value = '';

    EDIT_TITLE_INPUT.placeholder = title;
    EDIT_AUTHOR_INPUT.placeholder = author;
    EDIT_ISBN_INPUT.placeholder = isbn;
    EDIT_TAGS_INPUT.placeholder = tags.join(', ');
}

function errorHandler({ message }) {
    ERROR_DIV_ELEMENT.setAttribute('style', 'display: block');

    ERROR_DIV_ELEMENT.innerHTML = message;
    setTimeout(() => {
        ERROR_DIV_ELEMENT
            .setAttribute('style', 'display: none');
        ERROR_DIV_ELEMENT.innerHTML = '';
    }, 5000);
}

function _validateInput(title, author, isbn) {
    if (!title
        || !author
        || !isbn) {
        let message = '';

        if (!title)
            message += MISSING_TITLE_MSG + BR_TAG;

        if (!author)
            message += MISSING_AUTHOR_MSG + BR_TAG;

        if (!isbn)
            message += MISSING_ISBN_MSG + BR_TAG;

        errorHandler({ message });
        return false;
    };

    return true;
}

function _createDomElement(type, text, attachments, events, ...children) {
    let element = document.createElement(type);

    if (text) element.innerHTML = text;

    if (attachments)
        Object
            .entries(attachments)
            .forEach(([name, value]) => element
                .setAttribute(name, value));

    if (events)
        Object
            .entries(events)
            .forEach(([event, handler]) => element
                .addEventListener(event, handler));

    if (children)
        children
            .forEach(child => element
                .appendChild(child));

    return element;
}