let person = {
    name: 'John',
    age: 25,
    address: 'Hometown 12',
    isWorking: true,
    sayHello: function (name) {
        return `Hello ${name}, my name is ${this.name}`;
    }
};

// console.log(person);
// console.log(person.sayHello('Peter'));
// console.log(person.address);
// let address = 'address';
// console.log(person[address]);
// person.eyesColor = 'blue';
// console.log(person);

// let secondPerson = person;

// secondPerson.age = 37;

// console.log(person.age);
// console.log(secondPerson.age);

// delete person.name;

// console.log(person);

let person1 = {
    name: 'John',
    age: 25,
    address: 'Hometown 12',
    isWorking: true,
    sayHello: function (name) {
        return `Hello ${name}, my name is ${this.name}`;
    }
};

console.log(person == person1);
console.log(person === person1);

person1 = person;

console.log(person == person1);
console.log(person === person1);