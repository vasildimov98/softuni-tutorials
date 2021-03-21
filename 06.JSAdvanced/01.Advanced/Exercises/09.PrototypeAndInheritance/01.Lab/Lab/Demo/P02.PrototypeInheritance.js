// A. Functional Constructor
function Person(firstName, lastName, age) {
    this.firstName = firstName; // constructor 
    this.lastName = lastName;
    this.age = age;
}

// B. Prototype Function and Variable declaration and private property;
Object.defineProperty(Person.prototype, 'fullName', {
    get() {
        return this.firstName + ' ' + this.lastName;
    },
});

Object.defineProperty(Person.prototype, 'socialNumber', {
    get() {
        return this._socialNumber;
    },
    set(value) {
        if (this._socialNumber == undefined) {
            this._socialNumber = value;
        }
    }
});

Person.prototype.getAllData = function () {
    return `name: ${this.fullName}, age: ${this.age}`;
};

Person.prototype.nationality = 'Bulgarian';

// C. Behind the keyword 'new' keyword
function createNewObject(Class, ...arguments) {
    // Create new object
    let newObj = {};

    // Attached prototype to the new object
    newObj = Object.create(Class.prototype);

    // Call Constructor with context and arguments
    Class.apply(newObj, arguments)

    // Return object
    return newObj;
}

let almina = new Person('Almina', 'Itsova', 23);
let verzhiniya = new Person('Verzhiniya', 'Ivanova', 21);

// D. Extending or Inheriting other object
function Teacher(firtName, lastName, age, course) {
    Person.call(this, firtName, lastName, age); // super(name, age)
    this.course = course;
}

// extends
Teacher.prototype = Object.create(Person.prototype);
Teacher.prototype.constructor = Teacher;

// E. Replacing a Function
Teacher.prototype.getAllData = function () {
    // super.getAllData();
    return `${Person.prototype.getAllData.call(this)}, course: ${this.course}`;
};

// F. Adding a functions
Teacher.prototype.sayHello = function () {
    return `Hello students, my name is ${this.fullName} and I am ${this.age} years old. How about you?`;
};

Teacher.prototype.speak = function (message) {
    return `${this.lastName} said: ${message}`;
};

// Instansiating a object
let vasil = new Teacher('Vasil', 'Dimov', 22, 'JS Advanced');

// G. Making the prototype inheritance multilevel;
function Director(firtName, lastName, age, course, school) {
    Teacher.call(this, firtName, lastName, age, course);
    this.school = school;
}

Director.prototype = Object.create(Teacher.prototype);
Director.prototype.constructor = Director;

// Replacing methods
Director.prototype.getAllData = function () {
    // super.getAllData();
    return `${Teacher.prototype.getAllData.call(this)}, school: ${this.school.name}`;
};

Director.prototype.sayHello = function () {
    let parentResult = Teacher
        .prototype
        .sayHello
        .call(this);
    let substring = parentResult
        .substring(0, parentResult.indexOf('.'));
    return `${substring}. I am the headmaster here at ${this.school.name}. I am glad to see all of you back and pleace to welcome the newcomers too!`;
};

let dumbledore = new Director('Albus', 'Dumbledore', 114, 'Transfiguration', { name: 'Hogwarts School of Witchcraft and Wizardry', address: 'Scotland', });

console.log(dumbledore);
console.log(dumbledore.fullName);
console.log(dumbledore.age);
console.log(dumbledore.course);
console.log(dumbledore.school);
console.log(dumbledore.getAllData());
console.log(dumbledore.sayHello());
console.log(dumbledore.speak(`Welcome to your first class of ${dumbledore.course}!`));
console.log(dumbledore.nationality);
dumbledore.socialNumber = 31241516136
dumbledore.socialNumber = 'affasfasfasf';
console.log(dumbledore.socialNumber);

dumbledore.fullName = 'Albina Dumbledorka';

console.log(dumbledore.firstName);
console.log(dumbledore.lastName);