let cat = {
    breet: 'Tabby',
    color: 'orange',
    favoriteFood: 'Lasagna',
    owener: {
        firstName: 'Jon',
        secondName: 'Arbuckle',
        age: 34,
    },
    toyCollection: ['fluffy toy mouse', 'frisco', 'feather'],
};

Object.keys(cat).forEach(key => {
    console.log(`${key} - ${cat[key]}`);
});

Object.defineProperty(cat, 'name', {
    value: 'Garfield',
    enumerable: true,
});

console.log('--------------------------------------');

console.log(cat.name);

let carNameProperty = Object.getOwnPropertyDescriptor(cat, 'name');

console.log('---------------------------------------');

Object.values(cat).forEach(value => {
    console.log(value);
});

console.log('---------------------------------------');

console.log(carNameProperty.enumerable);
console.log(carNameProperty.writable);
console.log(carNameProperty.configurable);
console.log(carNameProperty.value);

let jsonCat = JSON.stringify(cat);

console.log(jsonCat);