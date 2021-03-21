class Animal {
    constructor(name, age, owner) {
        if (new.target.name == 'Animal') {
            throw new TypeError('Cannot instantiate abstract class!');
        }

        this.name = name;
        this.age = age;
        this.owner = owner;
    }

    get name() {
        return this._name;
    }

    set name(value) {
        if (value == ''
            || value == null) {
            throw new TypeError('Name cannot be null or empty!');
        }

        this._name = value;
    }

    get age() {
        return this._age;
    }

    set age(value) {
        if (value < 0
            || value == undefined) {
            throw new TypeError('Age cannot be less than zero!');
        }

        this._age = value;
    }

    get owner() {
        return this._owner;
    }

    set owner(value) {
        if (!value) {
            throw new TypeError('Cannot have animal without an owner!');
        }

        this._owner = value;
    }
}

class Dog extends Animal {
    constructor(name, age, owner) {
        super(name, age, owner);
    }

    bark() {
        return `${this.name} is barking!`
    }
}

class Cat extends Animal {
    constructor(name, age, owner) {
        super(name, age, owner);
    }

    meow() {
        return `${this.name} is meawing...`
    }
}

let dog = new Dog('Sharo', 2, {
    name: 'Vasil',
});

let cat = new Cat('Puhanes', 2, {
    owner: 'Dessy',
});

export default {
    Cat,
    Dog,
}