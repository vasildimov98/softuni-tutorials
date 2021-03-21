function solution() {
    //1. Select all section
    let [addGiftsSection,
        listOfGiftsSection,
        sentGiftsSection,
        discardGiftsSection] = document
            .querySelectorAll('.container .card');

    //2. Find add button and input
    let addBtn = addGiftsSection
        .querySelector('button');
    let textInput = document
        .querySelector('input');
    let listOfGifst = listOfGiftsSection
        .querySelector('ul');
    let sentGifst = sentGiftsSection
        .querySelector('ul');
    let discardGifst = discardGiftsSection
        .querySelector('ul');

    //3. Add event to button
    addBtn
        .addEventListener('click', addGifts);
    //4. Create event function to add element to list of gifst
    function addGifts() {
        //5. Validate input
        let gift = textInput.value;

        if (!gift
            || !isNaN(gift)) {
            return;
        }

        //6. Create listElement: 
        /* Append two buttons to each list item
        o	Add class “gift” to each list item
        o	[Send] button with id “sendButton”
        o	[Discard] button with id “discardButton”
        */

        let giftList = createNewGiftList(gift);

        _addValue(listOfGifst, [giftList]);
        _sortListOfGifts();

        //12. Clear Input
        textInput.value = '';
    }

    function createNewGiftList(gift) {
        let liElement = _createElement('li', {
            name: 'class',
            value: 'gift'
        });

        let sendBtn = _createElement('button', {
            name: 'id',
            value: 'sendButton'
        });

        _addValue(sendBtn, ['Send']);

        //7. Add event to send button
        sendBtn
            .addEventListener('click', addGiftToSentSection);

        let discardBtn = _createElement('button', {
            name: 'id',
            value: 'discardButton'
        });

        _addValue(discardBtn, ['Discard']);

        //9. add event to discard button
        discardBtn
            .addEventListener('click', addGiftToDiscardSection);

        _addValue(liElement, [gift, sendBtn, discardBtn]);

        return liElement;
    }

    //8. Create event function to add elements to sent gifts
    function addGiftToSentSection(e) {
        let parent = e.target.parentElement;
        parent
            .querySelector('button')
            .remove();
        parent
            .querySelector('button')
            .remove();

        sentGifst
            .appendChild(parent);
    }

    //10. Create event function to add element to discard gifts
    function addGiftToDiscardSection(e) {
        let parent = e.target.parentElement;
        parent
            .querySelector('button')
            .remove();
        parent
            .querySelector('button')
            .remove();

        discardGifst
            .appendChild(parent);
    }

    //11. sort lists of gifts and add the new element;
    function _sortListOfGifts() {
        let sortedArrWithGifts = Array
            .from(listOfGifst
                .children)
            .sort((g1, g2) => g1.textContent
                .localeCompare(g2.textContent));

        while (listOfGifst
            .firstChild) {
            listOfGifst
                .firstChild
                .remove();
        }

        sortedArrWithGifts
            .forEach(g => {
                listOfGifst.appendChild(g);
            });
    }

    function _createElement(type, attr) {
        let element = document
            .createElement(type);

        if (attr) {
            let { name, value } = attr;

            element.setAttribute(name, value);
        }

        return element;
    }

    function _addValue(element, valueArr) {
        valueArr
            .forEach(value => {
                if (typeof value == 'string') {
                    let textNode = document
                        .createTextNode(value);

                    value = textNode;
                }

                element.appendChild(value);
            });
    }
}

//!!! maybeyou should also sort the discard and send section!! 