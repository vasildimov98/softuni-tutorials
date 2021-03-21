function printConvertedJSON(input) {
    let data = input
    .map(str => str.split('|')
    .filter(str => str != '')
    .map(str => str.trim()));

    let headings = data.shift();

    let table = [];
    data.forEach((arr) => {
        let row = {};
        arr.forEach((value, index) => {

            if (!isNaN(value)) {
                value = Number(Number.parseFloat(value).toFixed(2));
            } 

            row[`${headings[index]}`] = value;
        })

        table.push(row);
    });

    let myJSON = JSON.stringify(table);

    console.log(myJSON);
}

printConvertedJSON([
    '| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |'
]
);

printConvertedJSON([
    '| Town | Latitude | Longitude |',
    '| Veliko Turnovo | 43.0757 | 25.6172 |',
    '| Monatevideo | 34.50 | 56.11 |'
]
);