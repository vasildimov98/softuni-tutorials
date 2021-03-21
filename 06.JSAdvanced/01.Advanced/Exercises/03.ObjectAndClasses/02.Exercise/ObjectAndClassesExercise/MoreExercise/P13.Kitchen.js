class Kitchen {
    constructor(budget) {
        this.budget = Number(budget);
        this.menu = {};
        this.productsInStock = {}
        this.actionsHistory = []
    }

    loadProducts(productsArr) {
        productsArr
            .forEach(productsArgs => {
                let [name, quantity, price] = productsArgs.split(' ');

                quantity = Number(quantity);
                price = Number(price);

                if (this.budget >= price) {
                    this.budget -= price;

                    if (!this.productsInStock[name]) {
                        this.productsInStock[name] = 0;
                    }

                    this.productsInStock[name] += quantity;

                    this.actionsHistory.push(`Successfully loaded ${quantity} ${name}`);
                } else {
                    this.actionsHistory.push(`There was not enough money to load ${quantity} ${name}`);
                }
            });

        return this.actionsHistory.join('\n');
    }

    addToMenu(meal, neededProducts, price) {
        if (!this.menu[meal]) {
            
            this.menu[meal] = {
                products: neededProducts,
                price: +price
            }
            return `Great idea! Now with the ${meal} we have ${Object.keys(this.menu).length} meals on the menu, other ideas?`;
        } else return `The ${meal} is already in our menu, try something different.`;
    }

    showTheMenu() {
        let result = [];

        Object
            .keys(this.menu)
            .forEach(m => {
                result.push(`${m} - $ ${this.menu[m].price}`);
            });


        if (result.length === 0) {
            return "Our menu is not ready yet, please come later...";
        } else {
            return result.join('\n') + '\n';
        }
    }

    makeTheOrder(meal) {
        if (!this.menu[meal]) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }

        let neededProducts = this.menu[meal].products;

        for (const p of neededProducts) {
            let [name, quantity] = p.split(' ');

            quantity = Number(quantity);

            if (!this.productsInStock[name] || this.productsInStock[name] < quantity) {
                return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
            }
        }

        neededProducts.forEach(p => {
            let [name, quantity] = p.split(' ');

            quantity = Number(quantity);

            this.productsInStock[name] -= quantity
        });

        let price = this.menu[meal].price;

        this.budget += price;

        return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${price}.`
    }
}

let kitchen = new Kitchen(1000);
console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));
console.log(kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99));
console.log(kitchen.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));
console.log(kitchen.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));
console.log(kitchen.makeTheOrder('Pizza'));
console.log(kitchen.showTheMenu());