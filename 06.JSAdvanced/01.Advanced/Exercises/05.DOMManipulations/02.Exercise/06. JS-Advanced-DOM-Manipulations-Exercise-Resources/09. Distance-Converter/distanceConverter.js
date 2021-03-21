function attachEventsListeners() {
    document
        .getElementById('convert')
        .addEventListener('click', convert);

    function convert() {
        let convertFromValue = Number(document
            .getElementById('inputDistance')
            .value);
        let convertedToOutputElement = document
            .getElementById('outputDistance')
        let convertFrom = document
            .getElementById('inputUnits')
            .value;
        let convertTo = document
            .getElementById('outputUnits')
            .value;

        let inputToM = 0;
        switch (convertFrom) {
            case 'km':
                inputToM = convertFromValue * 1000;
                break;
            case 'm':
                inputToM = convertFromValue;
                break;
            case 'cm':
                inputToM = convertFromValue * 0.01;
                break;
            case 'mm':
                inputToM = convertFromValue * 0.001;
                break;
            case 'mi':
                inputToM = convertFromValue * 1609.34;
                break;
            case 'yrd':
                inputToM = convertFromValue * 0.9144;
                break;
            case 'ft':
                inputToM = convertFromValue * 0.3048;
                break;
            case 'in':
                inputToM = convertFromValue * 0.0254;
                break;
        }

        let convertedResult = 0;
        switch (convertTo) {
            case 'km':
                convertedResult = inputToM / 1000;
                break;
            case 'm':
                convertedResult = inputToM;
                break;
            case 'cm':
                convertedResult = inputToM / 0.01;
                break;
            case 'mm':
                convertedResult = inputToM / 0.001;
                break;
            case 'mi':
                convertedResult = inputToM / 1609.34;
                break;
            case 'yrd':
                convertedResult = inputToM / 0.9144;
                break;
            case 'ft':
                convertedResult = inputToM / 0.3048;
                break;
            case 'in':
                convertedResult = inputToM / 0.0254;
                break;
        }

        convertedToOutputElement.value = convertedResult;
    }
}