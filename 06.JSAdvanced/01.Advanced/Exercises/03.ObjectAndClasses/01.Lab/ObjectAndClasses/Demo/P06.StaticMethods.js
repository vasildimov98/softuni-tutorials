class Person {
    #age;
    constructor (name, age) {
        this.name = name;
        this.#age = age;
    }

    static sayHiTo(name) {
        return `Hello ${name}, my name is ${this.name}`;
    }

    get age() {
        return this.#age;
    }
}

let pesho = new Person('Pesho', 13);

console.log(Person.sayHiTo('Peter'));
console.log(pesho.age);

pesho.age = 12424;

console.log(pesho.age);