function solve() {
    const BASE_URL = 'https://judgetests.firebaseio.com/schedule/'
    const INFO_ELEMENT = document
        .querySelector('.info');
    const DEPART_BTN = document
        .querySelector('#depart');
    const ARRIVE_BTN = document
        .querySelector('#arrive');

    let stopName;
    let currStopId = 'depot';


    function depart() {
        let currURL = `${BASE_URL}${currStopId}.json`

        fetch(currURL)
            .then(response => response.json())
            .then(data => {
                stopName = data.name;
                currStopId = data.next;

                INFO_ELEMENT.textContent = `Next stop ${stopName}`;
                DEPART_BTN.setAttribute('disabled', true);
                ARRIVE_BTN.removeAttribute('disabled');
            })
            .catch(() => {
                INFO_ELEMENT.textContent = 'Error';
                ARRIVE_BTN.setAttribute('disabled', true);
                DEPART_BTN.setAttribute('disabled', true);
            });
    }

    function arrive() {
        INFO_ELEMENT.textContent = `Arriving at ${stopName}`;
        DEPART_BTN.removeAttribute('disabled');
        ARRIVE_BTN.setAttribute('disabled', true);
    }

    return {
        depart,
        arrive
    };
}

let result = solve();