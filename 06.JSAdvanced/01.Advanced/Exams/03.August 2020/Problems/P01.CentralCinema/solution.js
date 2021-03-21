function solve() {
    // 1. Find on screen button 
    let onScreenBtn = document
        .querySelector('#container button');
    // 2. Attached an event
    onScreenBtn
        .addEventListener('click', addNewMovie);
    // 3. Select all inputs field
    let [nameInput, hallInput, ticketPriceInput] = Array
        .from(document
            .querySelectorAll('#container input'));
    // 7. Select the movies on screen section
    let movieOnScreenSection = document
        .querySelector('#movies ul');
    // 15. Select archive section
    let archiveMovieSection = document
        .querySelector('#archive ul');
    let clearBtn = document
        .querySelector('#archive > button');

    // 16. Add event to [Clear] button 
    clearBtn.addEventListener('click', clearAllArchiveMovies);

    // 17. Delete all li element when the clear event is called;
    function clearAllArchiveMovies() {
        Array
            .from(archiveMovieSection
                .children)
            .forEach(m => {
                m.remove();
            });
    }

    function addNewMovie(e) {
        e.preventDefault();

        // 4. Make sure all inputs are filled corectly
        let name = nameInput.value;
        let hall = hallInput.value;
        let ticketPrice = Number(ticketPriceInput.value == '' ?
            'NaN' :
            ticketPriceInput.value);

        if (!name
            || !hall
            || isNaN(ticketPrice)) {
            return;
        }
        // 5. Create new Element 
        /*You should create a li element that contains span element with the name of the movie, a strong element with the name of the hall like “Hall: { hallName }“ and a div element. Inside the div element, there are a strong element with the ticket price, input element with placeholder containing “Tickets Sold” and a button [Archive].*/

        let newMovieList = createNewMovieList(name, hall, ticketPrice);
        // 8. Add the new element to the section
        _addValue(movieOnScreenSection, [newMovieList]);
        // 9. Clear the input fields
        nameInput.value = '';
        hallInput.value = '';
        ticketPriceInput.value = '';
    }

    function createNewMovieList(name, hall, ticketPrice) {
        let listElement = _createElement('li');
        let spanElemet = _createElement('span', name);
        let strongHallElement = _createElement('STRONG', `Hall: ${hall}`);
        let divElement = _createElement('div');
        let strongPriceElement = _createElement('STRONG', ticketPrice.toFixed(2));
        let inputElement = _createElement('input', '', {
            name: 'placeholder',
            value: 'Tickets Sold',
        });

        // 6. Add new Event to archive button
        let archiveBtn = _createElement('button', 'Archive');

        archiveBtn
            .addEventListener('click', archiveMovie);

        _addValue(divElement, [
            strongPriceElement,
            inputElement,
            archiveBtn
        ]);
        _addValue(listElement, [spanElemet, strongHallElement, divElement]);

        return listElement;
    }

    function archiveMovie(e) {
        // 10. Make sure the input is valid (number or integer)
        let costInfoElemet = e.target.parentElement;
        let countOfTickets = Number(costInfoElemet
            .querySelector('input')
            .value == '' ? 'NaN' : costInfoElemet
                .querySelector('input')
                .value);
        if (isNaN(countOfTickets)) {
            return;
        }

        // 16. Move the element to Archive section 
        let newArchiveMoveList = createNewArchiveList(costInfoElemet,
            countOfTickets);
        costInfoElemet
            .parentElement
            .remove();
        _addValue(archiveMovieSection, [newArchiveMoveList]);
    }

    function createNewArchiveList(costInfoElemet, countOfTickets) {
        // 11. Create new Element /*Here we have list item containing span element with the name of the movie, strong element with total profit like “Total amount: {total price}” fixed to the second digit after the decimal point. Add a delete button [Delete].*/
        let movieName = costInfoElemet
            .parentElement
            .querySelector('span')
            .textContent;
        let moviePrice = Number(costInfoElemet
            .querySelector('strong')
            .textContent);

        let newArchiveList = _createElement('li');
        let nameOfTheMovieEl = _createElement('span', movieName);
        let titalAmount = countOfTickets * moviePrice;
        let strongAmountText = `Total amount: ${titalAmount.toFixed(2)}`;
        let strongAmountEl = _createElement('STRONG', strongAmountText);
        let deleteBtn = _createElement('button', 'Delete');

        // 13. Add event to delete button
        deleteBtn
            .addEventListener('click', () => {
                // 14. Delete the element when the event is called
                newArchiveList.remove();
            });

        _addValue(newArchiveList, [
            nameOfTheMovieEl,
            strongAmountEl,
            deleteBtn
        ]);

        return newArchiveList;
    }

    function _createElement(type, text, attribute) {
        let element = document
            .createElement(type);

        if (text) {
            let textNode = document
                .createTextNode(text);

            element.appendChild(textNode);
        }

        if (attribute) {
            let { name, value } = attribute;

            element
                .setAttribute(name, value);
        }

        return element;
    }

    function _addValue(element, valuesArr) {
        valuesArr.forEach(value => {
            if (typeof value == 'string') {
                let textNode = document
                    .createTextNode(value);

                value = textNode;
            }

            element.appendChild(value);
        });
    }
}