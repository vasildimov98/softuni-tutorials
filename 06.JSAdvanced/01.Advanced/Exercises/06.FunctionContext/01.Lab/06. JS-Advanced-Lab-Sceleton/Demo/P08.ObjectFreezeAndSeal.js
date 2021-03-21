let cat = {
    name: 'Garfield',
    age: 1,
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

Object.seal(cat);

delete cat.name;
cat.age = 12;
cat.gender = 'male';

console.log(cat);