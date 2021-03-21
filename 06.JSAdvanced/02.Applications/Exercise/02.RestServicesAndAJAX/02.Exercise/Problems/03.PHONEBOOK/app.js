function attachEvents() {
    const GET_AND_POST_URL = 'https://phonebook-nakov.firebaseio.com/phonebook.json';
    const PHONEBOOK_LIST = document
        .querySelector('#phonebook');
    const LOAD_BTN = document
        .querySelector('#btnLoad');
    const CREATE_BTN = document
        .querySelector('#btnCreate');
    const PERSON_INPUT_ELEMENT = document
        .querySelector('#person');
    const PHONE_INPUT_ELEMENT = document
        .querySelector('#phone');

    LOAD_BTN.addEventListener('click', sendGetRequest);
    CREATE_BTN.addEventListener('click', sendPostRequest);

    function sendPostRequest() {

        let postBodyJSON = JSON.stringify({
            person: PERSON_INPUT_ELEMENT.value,
            phone: PHONE_INPUT_ELEMENT.value,
        });

        fetch(GET_AND_POST_URL, {
            method: 'POST',
            body: postBodyJSON
        });
    }

    function sendGetRequest() {
        fetch(GET_AND_POST_URL)
            .then(response => response.json())
            .then(data => {
                displayGetResponse(data);
            });
    }

    function displayGetResponse(getResponse) {
        PHONEBOOK_LIST.innerHTML = '';
        Object
            .keys(getResponse)
            .forEach(phonebookKey => {
                let person = getResponse[phonebookKey];

                let liElementText = `${person.person}: ${person.phone}`
                let createdLiElemenet = _createElement('li', liElementText);

                let deleteBtn = _createElement('button', 'Delete');

                deleteBtn.addEventListener('click', () => sendDeleteRequest(phonebookKey));

                createdLiElemenet.appendChild(deleteBtn);

                PHONEBOOK_LIST.appendChild(createdLiElemenet);
            });
    }

    function sendDeleteRequest(phonebookKey) {
        let deleteUrl = `https://phonebook-nakov.firebaseio.com/phonebook/${phonebookKey}.json`;

        fetch(deleteUrl, {
            method: 'DELETE',
        });
    }

    function _createElement(type, text) {
        let element = document
            .createElement(type);

        if (text) {
            let textNode = document
                .createTextNode(text);

            element.appendChild(textNode);
        }

        return element;
    }
}

attachEvents();