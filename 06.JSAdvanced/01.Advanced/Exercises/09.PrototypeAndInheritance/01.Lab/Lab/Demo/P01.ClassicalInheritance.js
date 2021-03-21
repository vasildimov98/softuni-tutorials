// A. Creating copy by instantiating... 
class Person {
    constructor(name, age) {
        this.name = name;
        this.age = age;
    }

    getAllData() {
        return `name: ${this.name}, age: ${this.age}`;
    }
}

let pesho = new Person('Pesho', 21);

let ivan = new Person('Ivan', 43);

let marijka = new Person('Marijka', 32);

let zlati = new Person('Zlati', 29);

// B. Creating copy by inheritance
class Teacher extends Person {
    constructor(name, age, course) {
        super(name, age);
        this.course = course;
    }

    getAllData() {
        return `${super.getAllData()}, course: ${this.course}`;
    }
}

let vasil = new Teacher('Vasil', 22, 'JS Advanced');

class Director extends Teacher {
    constructor(name, age, course, school) {
        super(name, age, course);
        this.school = school;
    }

    getAllData() {
        return `${super.getAllData()}, school: ${this.school.name}`;
    }
}

let dumbledore = new Director('Dubledore', 114, 'Transfiguration', { name: 'Hogwarts', address: 'Scotland' });

console.log(marijka.getAllData());
console.log(vasil.getAllData());
console.log(dumbledore.getAllData());

let marijkaProto = Object.getPrototypeOf(marijka);

console.log(dumbledore.getAllData === marijka.getAllData);