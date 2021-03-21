class Person {
    constructor (name, age) {
        this.name = name;
        this.age = age;
    }

    sayHiTo(name) {
        return `Hello ${name}, my name is ${this.name}`;
    }
}

let pesho = new Person('Pesho', 12);

console.log(pesho.sayHiTo('Peter'));

let peter = new Person('Peter', 42);

console.log(peter);

let Person1 = class {
    constructor(name, age) {
        this.name = name;
        this.age = age;
    }
}

let pesho1 = new Person1('Pesho', 12);

console.log(pesho1);

let peter1 = new Person1('Peter', 42);

console.log(peter1);