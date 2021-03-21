function getInfo() {
    const VALID_BUS_DATA = ['1287', '1308', '1327', '2334'];
    const STOP_ID_INPUT_ELEMENT = document
        .getElementById('stopId');
    const STOP_ID_VALUE = STOP_ID_INPUT_ELEMENT.value;
    const URL = `https://judgetests.firebaseio.com/businfo/${STOP_ID_VALUE}.json`;
    const STOP_NAME_DIV = document
        .getElementById('stopName');
    const LIST_OF_BUSSES = document
        .getElementById('buses');

    if (!VALID_BUS_DATA.includes(STOP_ID_VALUE)) {
        STOP_NAME_DIV.innerHTML = 'Error';
        return;
    }

    fetch(URL)
        .then((response) => response.json())
        .then((response) => {
            _deleteLasBusStopInfo();
            _showBusStopInfo(response);
        });
    
    function _deleteLasBusStopInfo() {
        STOP_ID_INPUT_ELEMENT.value = '';
        STOP_NAME_DIV.innerHTML = '';
        while (LIST_OF_BUSSES.firstChild)
            LIST_OF_BUSSES.firstChild.remove();
    }

    function _showBusStopInfo(response) {
        let stopNameTextNode = document
            .createTextNode(response.name);

        let busesInfo = response.buses;

        Object
            .keys(busesInfo)
            .forEach(busId => {
                let listElement = document
                    .createElement('li');

                let busTextInfo = `Bus ${busId} arrives in ${busesInfo[busId]}`

                let busTextNode = document
                    .createTextNode(busTextInfo);

                listElement.appendChild(busTextNode);

                LIST_OF_BUSSES.appendChild(listElement);
            })

        STOP_NAME_DIV.appendChild(stopNameTextNode);
    }
}