function showHeroRegister(heroesInfo) {
    let heroes = [];
    heroesInfo.forEach(line => {
        let heroArgs = line
        .split(' / ');

        let[name, level, items] = heroArgs;

        level = Number(level);
        items = items === undefined ? [] : items.split(', ');

        let hero = {
            name,
            level,
            items,
        }

        heroes.push(hero);
    });

    console.log(JSON.stringify(heroes));
}

showHeroRegister([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
]
);

showHeroRegister(['Jake / 1000 / Gauss, HolidayGrenade']);