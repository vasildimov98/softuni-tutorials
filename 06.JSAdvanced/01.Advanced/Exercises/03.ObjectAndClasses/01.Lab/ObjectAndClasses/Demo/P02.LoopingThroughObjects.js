let person = {
    name: 'John',
    age: 25,
    address: 'Hometown 12',
    isWorking: true,
    sayHello: function (name) {
        return `Hello ${name}, my name is ${this.name}`;
    }
};

// //Object keys
// let personKeys = Object.keys(person);

// console.log(personKeys);

// personKeys.forEach(k => {
//     console.log(`${k}: ${person[k]}`);
// });

// //Object values
// let personValues = Object.values(person);

// console.log(personValues);

// personValues.forEach(v => {
//     console.log(v);
// });

// for... in loop

for (const key in person) {
    if (person.hasOwnProperty(key)) {
        console.log(`${key} = ${person[key]}`);
    }
}

// for... of
for (const key of Object.keys(person)) {
    console.log(`${key} = ${person[key]}`);
}