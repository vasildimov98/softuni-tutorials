function showJSONToHTML(myJSON) {
    let students = JSON.parse(myJSON);

    let properties = students[0];

    let tableInHTML = '<table>\n';

    tableInHTML += '   <tr>';

    tableInHTML += Object.keys(properties).map(pr => `<th>${escapeHTML(pr)}</th>`).join('');

    tableInHTML += '</tr>\n';

    students.forEach(arr => {
        tableInHTML += '   <tr>';

        tableInHTML += Object.values(arr).map(v => `<td>${escapeHTML(v)}</td>`).join('');

        tableInHTML += '</tr>\n';
    });

    tableInHTML += '</table>';

    console.log(tableInHTML);

    function escapeHTML(input) {
        input = String(input)
        .replace(/&/g, '&amp;')
        .replace(/</g, '&lt;')
        .replace(/>/g, '&gt;')
        .replace(/"/g, '&quot;')
        .replace(/'/g, '&#39;')
        
        return input;
    }
}

showJSONToHTML([
    '[{"Name":"Tomatoes & Chips","Price":2.35},{"Name":"J&B Chocolate","Price":0.96}]'
]);

showJSONToHTML([
    '[{"Name":"Pesho <div>-a","Age":20,"City":"Sofia"}, {"Name":"Gosho","Age":18,"City":"Plovdiv"},{"Name":"Angel","Age":18,"City":"Veliko Tarnovo"}]'
]
);