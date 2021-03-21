let cat = {
    breet: 'Tabby',
    color: 'orange',
    favoriteFood: 'Lasagna',
    owner: {
        firstName: 'Jon',
        secondName: 'Arbuckle',
        age: 34,
    },
    toyCollection: ['fluffy toy mouse', 'frisco', 'feather'],
};

Object.defineProperty(cat, 'name', {
    value: 'Garfield',
    enumerable: true,
    writable: false,
    configurable: false,
});

let catNameProperty = Object.getOwnPropertyDescriptor(cat, 'name');

Object.keys(cat).forEach(k => {
    console.log(`${k} ==> ${cat[k]}`);
});

console.log(catNameProperty.value);
console.log(catNameProperty.enumerable);
console.log(catNameProperty.writable);
console.log(catNameProperty.configurable);

Object.defineProperty(cat, 'name', {
    enumerable: false, //TypeError
});
