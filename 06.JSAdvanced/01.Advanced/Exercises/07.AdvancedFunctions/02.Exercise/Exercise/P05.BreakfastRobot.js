function solution() {
    let robotStorage = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0,
    };

    return function manager(args) {
        let [order, ...restOfArgs] = args.split(' ');

        if (order == 'restock') {
            let [microelement, quantity] = restOfArgs;

            robotStorage[microelement] += Number(quantity);

            return 'Success';
        } else if (order == 'prepare') {
            let [recipe, quantity] = restOfArgs;

            quantity = Number(quantity);
            recipe = recipe.toUpperCase();

            if (recipe == 'APPLE') {
                let neededCarp = 1 * quantity;
                let neededFlavour = 2 * quantity;

                if (!validateIngrediente('carbohydrate', neededCarp)) {
                    return `Error: not enough carbohydrate in stock`
                }

                if (!validateIngrediente('flavour', neededFlavour)) {
                    return `Error: not enough flavour in stock`
                }

                robotStorage['carbohydrate'] -= neededCarp;
                robotStorage['flavour'] -= neededFlavour;
            } else if (recipe == 'LEMONADE') {
                let neededCarp = 10 * quantity;
                let neededFlavour = 20 * quantity;

                if (!validateIngrediente('carbohydrate', neededCarp)) {
                    return `Error: not enough carbohydrate in stock`
                }

                if (!validateIngrediente('flavour', neededFlavour)) {
                    return `Error: not enough flavour in stock`
                }

                robotStorage['carbohydrate'] -= neededCarp;
                robotStorage['flavour'] -= neededFlavour;
            } else if (recipe == 'BURGER') {
                let neededCarp = 5 * quantity;
                let neededFat = 7 * quantity;
                let neededFlavour = 3 * quantity;

                if (!validateIngrediente('carbohydrate', neededCarp)) {
                    return `Error: not enough carbohydrate in stock`
                }

                if (!validateIngrediente('fat', neededCarp)) {
                    return `Error: not enough fat in stock`
                }

                if (!validateIngrediente('flavour', neededFlavour)) {
                    return `Error: not enough flavour in stock`
                }

                robotStorage['carbohydrate'] -= neededCarp;
                robotStorage['fat'] -= neededFat;
                robotStorage['flavour'] -= neededFlavour;
            } else if (recipe == 'EGGS') {
                let neededProtein = 5 * quantity;
                let neededFat = 1 * quantity;
                let neededFlavour = 1 * quantity;

                if (!validateIngrediente('protein', neededProtein)) {
                    return `Error: not enough protein in stock`
                }

                if (!validateIngrediente('fat', neededProtein)) {
                    return `Error: not enough fat in stock`
                }

                if (!validateIngrediente('flavour', neededFlavour)) {
                    return `Error: not enough flavour in stock`
                }

                robotStorage['protein'] -= neededProtein;
                robotStorage['fat'] -= neededFat;
                robotStorage['flavour'] -= neededFlavour;
            } else {
                let neededProtein = 10 * quantity;
                let neededCarp = 10 * quantity;
                let neededFat = 10 * quantity;
                let neededFlavour = 10 * quantity;

                if (!validateIngrediente('protein', neededProtein)) {
                    return `Error: not enough protein in stock`
                }

                if (!validateIngrediente('carbohydrate', neededCarp)) {
                    return `Error: not enough carbohydrate in stock`
                }

                if (!validateIngrediente('fat', neededProtein)) {
                    return `Error: not enough fat in stock`
                }

                if (!validateIngrediente('flavour', neededFlavour)) {
                    return `Error: not enough flavour in stock`
                }

                robotStorage['protein'] -= neededProtein;
                robotStorage['carbohydrate'] -= neededCarp;
                robotStorage['fat'] -= neededFat;
                robotStorage['flavour'] -= neededFlavour;
            }

            return 'Success';
        } else {
            return `protein=${robotStorage['protein']} carbohydrate=${robotStorage['carbohydrate']} fat=${robotStorage['fat']} flavour=${robotStorage['flavour']}`;
        }
    }

    function validateIngrediente(ingrediente, neededQuantity) {
        let ingredienteInStock = robotStorage[ingrediente];
        if (ingredienteInStock < neededQuantity) {
            return false;
        }

        return true;
    }
}

let manager = solution();
// console.log(manager("restock flavour 50"));  // Success
// console.log(manager("prepare lemonade 4"));  // Error: not enough carbohydrate in stock

// console.log(manager('restock carbohydrate 10'));
// console.log(manager('restock flavour 10'));
// console.log(manager('prepare apple 1'));
// console.log(manager('restock fat 10'));
// console.log(manager('prepare burger 1'));
// console.log(manager('report'));

console.log(manager(`prepare turkey 1`));
console.log(manager(`restock protein 10`));
console.log(manager(`prepare turkey 1`));
console.log(manager(`restock carbohydrate 10`));
console.log(manager(`prepare turkey 1`));
console.log(manager(`restock fat 10`));
console.log(manager(`prepare turkey 1`));
console.log(manager(`restock flavour 10`));
console.log(manager(`prepare turkey 1`));
console.log(manager(`report`));