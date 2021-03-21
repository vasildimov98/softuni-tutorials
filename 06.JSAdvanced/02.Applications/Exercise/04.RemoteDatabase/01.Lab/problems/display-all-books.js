const BASE_URL = 'https://my-books-64fa3.firebaseio.com/';
const BOOK_DETAILS_DIV = document
    .querySelector('.book-details');

function addEvents() {
    BOOKS_LIST
        .addEventListener('click', makeGetRequestForSpecifiedBook);
}

function makeGetRequestForSpecifiedBook(e) {
    let book = e.target;

    if (book.textContent == 'Edit')
        return;

    let bookKey = book.dataset.key;

    let bookURL = `${BASE_URL}books/${bookKey}.json`;
    fetch(bookURL)
        .then(res => res.json())
        .then(showBookDetails)
        .catch(err => console.log(err));
}

function makeGetRequestForBooks() {
    fetch(`${BASE_URL}books.json`)
        .then(response => response.json())
        .then(showAllBooks);
}


function showBookDetails(book) {
    _removeOldPreviousDetail();
    let detailsList = _createNewElement('ul', '', {
        name: 'class',
        value: 'details',
    });

    Object
        .keys(book)
        .forEach(b => {
            let detail = _createNewElement('li', `${b}: ${book[b]}`);

            _addValue(detailsList, detail);
        });

    BOOK_DETAILS_DIV.appendChild(detailsList);
}

function showAllBooks(books) {
    if (!books) return;
    Object
        .keys(books)
        .forEach(bookId => {
            let book = books[bookId];
            let bookList = _createNewElement('li', book.title, {
                name: 'class',
                value: 'movie'
            }, {
                name: 'data-key',
                value: bookId,
            });

            BOOKS_LIST.appendChild(bookList);
        });
}

function _removeOldPreviousDetail() {
    [...BOOK_DETAILS_DIV
        .children]
        .slice(1)
        .forEach(ch => ch.remove());
}

function _addValue(element, ...values) {
    values
        .forEach(v => {
            if (typeof v == 'string')
                v = document.createTextNode(v);

            if (v instanceof Array)
                v = document.createTextNode(v.join(' '));

            element.appendChild(v);
        });
}

function _createNewElement(type, content, ...attachments) {
    let elememnt = document.createElement(type);

    if (content) _addValue(elememnt, content);

    if (attachments)
        attachments
            .forEach(({ name, value }) => {
                elememnt
                    .setAttribute(name, value);
            });

    return elememnt;
}


addEvents();
makeGetRequestForBooks();