function attachEvents() {
    const GET_POST_URL = 'https://rest-messanger.firebaseio.com/messanger.json';
    const SUBMIT_BTN = document
        .querySelector('#submit');
    const AUTHOR_INPUT_ELEMENT = document
        .querySelector('#author');
    const CONTENT_INPUT_ELEMENT = document
        .querySelector('#content');
    const REFRESH_BTN = document
        .querySelector('#refresh');
    const MESSAGES_TEXTAREA = document
        .querySelector('#messages');

    SUBMIT_BTN.addEventListener('click', sendPostRequest);
    REFRESH_BTN.addEventListener('click', sendGetRequest);

    function sendGetRequest() {
        fetch(GET_POST_URL)
            .then(response => response.json())
            .then(responseData => {
                showGetResponseData(responseData);
            })
    }

    function showGetResponseData(responseData) {
        let messages = Object
            .keys(responseData)
            .reduce((arr, key) => {
                let infoArgs = responseData[key];
                arr
                    .push(`${infoArgs.author}: ${infoArgs.content}`);

                return arr;
            }, []);

        MESSAGES_TEXTAREA.textContent = messages.join('\n');
    }

    function sendPostRequest() {
        let postRequestBody = JSON.stringify({
            author: AUTHOR_INPUT_ELEMENT.value,
            content: CONTENT_INPUT_ELEMENT.value,
        });

        AUTHOR_INPUT_ELEMENT.value = '';
        CONTENT_INPUT_ELEMENT.value = '';

        fetch(GET_POST_URL, {
            method: 'POST',
            body: postRequestBody,
        });
    }
}

attachEvents();