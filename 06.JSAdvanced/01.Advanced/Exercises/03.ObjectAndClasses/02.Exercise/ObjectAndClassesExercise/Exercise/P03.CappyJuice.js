function showProducedJuice(juiceInfo) {
    let juices = {};
    let bottles = {};
    juiceInfo.forEach(line => {
        let [juice, qunatity] = line.split(' => ');

        if (!juices[juice]) {
            juices[juice] = 0;
        }

        juices[juice] += Number(qunatity);

        if (juices[juice] >= 1000) {
            let bottleCount = parseInt(juices[juice] / 1000);

            if (!bottles[juice]) {
                bottles[juice] = 0;
            }

            bottles[juice] += bottleCount;
    
            juices[juice] -= bottleCount * 1000;
        }
    });

    Object.keys(bottles).forEach(juice => {
        console.log(`${juice} => ${bottles[juice]}`);
    })
}

showProducedJuice([
    'Orange => 2000',
    'Peach => 1432',
    'Banana => 450',
    'Peach => 600',
    'Strawberry => 549'
]
);

showProducedJuice([
    'Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789'
]
);