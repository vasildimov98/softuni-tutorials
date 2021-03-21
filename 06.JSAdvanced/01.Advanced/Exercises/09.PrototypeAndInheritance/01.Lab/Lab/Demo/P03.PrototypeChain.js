// A. Literal object creation
let dog = {
    name: 'Djaro',
    age: 6,
    getInfo() {
        return `My name is ${this.name}`;
    },
};

// B. Object.create();
let myDog = Object.create(dog);

myDog.name = 'Rex';
myDog.breed = 'German Shepherd';
myDog.getInfo = function () {
    let proto = Object.getPrototypeOf(myDog);
    return `${proto.getInfo.call(this)} and my breed is ${this.breed}`;
}

console.log(dog.getInfo());
console.log(myDog.getInfo());

// C. Constructed Object
function Dog(name, age) {
    this.name = name;
    this.age = age;
}

Dog.prototype.getInfo = function () {
    return `My name is ${this.name}`;
};

let constructedDog = new Dog('Djaro', 6);

console.log(dog);
console.log(constructedDog);