function subtract(a, b) {
    console.log(this == global);
    return a - b;
}

console.log(subtract(1, 3));

function speak() {
    console.log(this == global);
    console.log(this == person);
    return `Hello my name is ${this.name}`; 
}

let person = {
    name: "Pehso",
    sayHello: speak,
};

console.log(speak());
console.log(person.sayHello());