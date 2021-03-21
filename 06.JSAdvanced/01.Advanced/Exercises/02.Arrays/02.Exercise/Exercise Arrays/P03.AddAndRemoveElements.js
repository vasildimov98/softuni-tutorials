function proceedTheCommands(commands) {
    let numberToAdd = 1;
    let elements = [];

    commands.forEach(element => {
        if (element == 'add') {
            elements.push(numberToAdd);
        } else {
            elements.pop();
        }

        numberToAdd++;
    });

    let result = elements.length > 0 ? elements.join('\n') : 'Empty';
    console.log(result);
}

proceedTheCommands(
    ['add',
    'add',
    'add',
    'add']
);

proceedTheCommands(
    ['add',
    'add',
    'remove',
    'add',
    'add']
);

proceedTheCommands(
    ['remove',
    'remove',
    'remove']
);