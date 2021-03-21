function showPopulationInTowns(townsInfo) {
    let townsWithPopulation = {};
    
    townsInfo.forEach(element => {
        let townArgs = element
        .split(' <-> ');

        let town = townArgs[0];
        let population = Number(townArgs[1]);

        if (!townsWithPopulation.hasOwnProperty(town)) {
            townsWithPopulation[`${town}`] = 0;
        }

        townsWithPopulation[`${town}`] += population;
    })

    let keys = Object.keys(townsWithPopulation);

    keys.forEach(town => {
        let population = townsWithPopulation[town];

        console.log(`${town} : ${population}`);
    })
}

showPopulationInTowns([
    'Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000'
]
);

showPopulationInTowns([
    'Istanbul <-> 100000',
    'Honk Kong <-> 2100004',
    'Jerusalem <-> 2352344',
    'Mexico City <-> 23401925',
    'Istanbul <-> 1000'
]
);