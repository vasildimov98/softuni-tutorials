const TITLE_INPUT = document
    .querySelector('#title');
const AUTHOR_INPUT = document
    .querySelector('#author');
const DATE_INPUT = document
    .querySelector('#date');
const LANGUAGE_INPUT = document
    .querySelector('#lang');

const SUBMIT_BTN = document
    .querySelector('#submit')

function addEvents() {
    SUBMIT_BTN
        .addEventListener('click', makePOSTRequest);
}

function makePOSTRequest() {
    let title = TITLE_INPUT.value;
    let author = AUTHOR_INPUT.value;
    let date = DATE_INPUT.value;
    let lang = LANGUAGE_INPUT.value;

    if (!_validateData(title, author, date, lang))
        return;

    let book = {
        title,
        author,
        'originally published': date,
        'original language': lang,
    };

    fetch(`${BASE_URL}books.json`, {
        method: 'POST',
        body: JSON
            .stringify(book),
    })
        .then(res => res.json())
        .then(({name: key}) => {
            let bookList = _createNewElement('li', book.title, {
                name: 'class',
                value: 'movie'
            }, {
                name: 'data-key',
                value: key,
            });

            BOOKS_LIST.appendChild(bookList);
        });
}

function _validateData(title, author, date, lang) {
    if (!title
        || !author
        || !date
        || !lang)
        return false;

    return true;
}

addEvents();