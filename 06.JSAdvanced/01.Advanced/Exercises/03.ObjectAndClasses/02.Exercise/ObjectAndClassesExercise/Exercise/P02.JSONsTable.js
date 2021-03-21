function showHTMLsTable(employeesInfo) {
    let htmlTable = '<table>\n';

    employeesInfo.forEach(myJSON => {
        htmlTable += '\t<tr>\n';

        let employee = JSON.parse(myJSON);
        Object.keys(employee).forEach(key => {
            htmlTable += `\t\t<td>${employee[key]}</td>\n`
        })

        htmlTable += '\t</tr>\n';
    });

    htmlTable += '</table>';

    console.log(htmlTable);
}


showHTMLsTable([
    '{"name":"Pesho","position":"Promenliva","salary":100000}',
    '{"name":"Teo","position":"Lecturer","salary":1000}',
    '{"name":"Georgi","position":"Lecturer","salary":1000}'
]
);