function showTableInHTML(myJSON) {
    let htmlTable = '<table>\n';

    let arrWithObj = JSON.parse(myJSON);

    htmlTable += '  <tr>';

    let properties = arrWithObj[0];

    Object
        .keys(properties)
        .forEach(key => {
            htmlTable += `<th>${escapeHTML(key)}</th>`
        });


    htmlTable += '</tr>\n';

    arrWithObj.forEach(obj => {
        htmlTable += '  <tr>';

        Object
            .keys(obj)
            .forEach(key => {
                htmlTable += `<td>${escapeHTML(obj[key])}</td>`
            });

        htmlTable += '</tr>\n';
    });

    htmlTable += '</table>';
    console.log(htmlTable);

    function escapeHTML(str) {

        if (!isNaN(str)) {
            return str;
        }

        str = str.replace(/&/gi, '&amp;');
        str = str.replace(/</gi, '&lt;');
        str = str.replace(/>/gi, '&gt;');
        str = str.replace(/"/gi, '&quot;');
        str = str.replace(/'/gi, '&#39;');

        return str;
    }
}

showTableInHTML([
    '[{"name":"Pesho","score":479}, {"name":"Gosho","score":205}]'
]
);

showTableInHTML([
    '[{"name":"Pesho & Kiro", "score":479}, {"name":"Gosho, Maria & Viki", "score":205}]'
]
);