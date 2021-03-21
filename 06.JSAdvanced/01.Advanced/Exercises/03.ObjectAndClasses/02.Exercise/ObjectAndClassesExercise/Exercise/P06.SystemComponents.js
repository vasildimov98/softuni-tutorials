function showSystemComponents(systemsInfo) {
    let systems = {};
    systemsInfo.forEach(systemArgs => {
        let [system, component, subcomponent] = systemArgs.split(' | ');

        if (!systems[system]) {
            systems[system] = {};
        }

        if (!systems[system][component]) {
            systems[system][component] = [];
        }

        systems[system][component].push(subcomponent);
    });

    Object
        .keys(systems)
        .sort((a, b) => {
            let sizeOfA = Object
                .keys(systems[a])
                .length;
            let sizeOfB = Object
                .keys(systems[b])
                .length;

            let compare = sizeOfB - sizeOfA;

            if (compare == 0) {
                return a.localeCompare(b);
            }

            return compare;
        }).forEach(s => {
            console.log(s);
            Object
                .keys(systems[s])
                .sort((a, b) => systems[s][b].length - systems[s][a].length)
                .forEach(c => {
                    console.log(`|||${c}`);
                    systems[s][c]
                        .forEach(sub => {
                            console.log(`||||||${sub}`);
                        })
                })
        })
}

showSystemComponents([
    'SULS | Main Site | Home Page',
    'SULS | Main Site | Login Page',
    'SULS | Main Site | Register Page',
    'SULS | Judge Site | Login Page',
    'SULS | Judge Site | Submittion Page',
    'Lambda | CoreA | A23',
    'SULS | Digital Site | Login Page',
    'Lambda | CoreB | B24',
    'Lambda | CoreA | A24',
    'Lambda | CoreA | A25',
    'Lambda | CoreC | C4',
    'Indice | Session | Default Storage',
    'Indice | Session | Default Security'
]
);