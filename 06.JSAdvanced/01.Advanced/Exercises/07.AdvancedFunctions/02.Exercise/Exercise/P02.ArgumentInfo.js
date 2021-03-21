function showArgumentInfo(...arguments) {
    let tally = {}
    arguments.forEach(arg => {
        let type = typeof arg;
        let value = arg;

        console.log(`${type}: ${value}`);

        if (!tally[type]) {
            tally[type] = 0;
        }

        tally[type]++;
    });

    Object
        .keys(tally)
        .sort((fT, sT) => {
            return tally[sT] - tally[fT];
        }).forEach(t => {
            console.log(`${t} = ${tally[t]}`);
        });
}

showArgumentInfo('cat', 42, function () { console.log('Hello world!'); }, 31, 123, 'vasko');