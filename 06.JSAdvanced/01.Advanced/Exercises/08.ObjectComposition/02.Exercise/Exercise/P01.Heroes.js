function solve() {
    function mage(name) {
        return {
            name,
            health: 100,
            mana: 100,
            cast(spell) {
                if (this.mana) {
                    this.mana--;
                }

                console.log(`${this.name} slashes at the foe!`);
            },
        };
    }

    function fighter(name) {
        return {
            name,
            health: 100,
            stamina: 100,
            fight(spell) {
                if (this.stamina) {
                    this.stamina--;
                }
                console.log(`${this.name} cast ${spell}`);
            },
        };
    }

    return {mage, fighter};
}

let create = solve();
const scorcher = create.mage("Scorcher");
scorcher.cast("fireball")
scorcher.cast("thunder")
scorcher.cast("light")

const scorcher2 = create.fighter("Scorcher 2");
scorcher2.fight()

console.log(scorcher2.stamina);
console.log(scorcher.mana);
