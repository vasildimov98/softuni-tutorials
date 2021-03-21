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

Object.defineProperty(cat.owner, 'firstName', {
    writable: false,
});

let newOwner = {
    name: 'Vasko',
    age: 13,
};

cat.owner.firstName = 'Vasko'
cat.owner.secondName = 'Vasko'

let catOwnerProperty = Object.getOwnPropertyDescriptor(cat, 'owner');

console.log('---------------------------------------');

console.log(catOwnerProperty.enumerable);
console.log(catOwnerProperty.writable);
console.log(catOwnerProperty.configurable);
console.log(catOwnerProperty.value);
