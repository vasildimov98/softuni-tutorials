function encodeAndDecodeMessages() {
    let mainElement = document
        .getElementById('main');

    mainElement.addEventListener('click', getMessage)

    function getMessage(e) {
        let tagName = e.target.tagName
        if (tagName == 'BUTTON') {
            let currDivParent = e.target.parentElement;
            let btnValue = e.target.textContent;
            let textAreaForEncode = currDivParent.querySelector('textarea');
            let textAreaForDecode = mainElement.querySelector('textarea[disabled]');

            let encodeMsg = '';
            if (btnValue == 'Encode and send it') {
                let message = textAreaForEncode.value;

                encodeMsg = getNewMessage(message, 1);

                textAreaForEncode.value = '';
            } else {
                let message = textAreaForDecode.value;

                encodeMsg = getNewMessage(message, -1);
            }
            textAreaForDecode.value = encodeMsg;
        }

        function getNewMessage(msg, encodeRule) {
            let encodeMsg = '';

            for (let index = 0; index < msg.length; index++) {
                encodeMsg += String.fromCharCode(msg[index].charCodeAt(0) + encodeRule);
            }

            return encodeMsg;
        }
    }
}