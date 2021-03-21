function processTheList(commandsArgs) {
    let list = [];
    let listProcessor = {
        add: text => list.push(text),
        remove: text => list = list.filter((t => t != text)), 
        print: () => console.log(list.join(',')),
    };

    commandsArgs.forEach(arguments => {
        let [command, text] = arguments.split(' ');

        listProcessor[command](text);
    });
}

// processTheList(['add hello', 'add again', 'remove hello', 'add again', 'print']);
// processTheList(['add pesho', 'add george', 'add peter', 'remove peter','print']);

let commands = ['add peter', 'add george', 'add peter', 'remove peter','print'];
processTheList(commands);

//expect(output).to.equal('george','Expected output did not match!');

