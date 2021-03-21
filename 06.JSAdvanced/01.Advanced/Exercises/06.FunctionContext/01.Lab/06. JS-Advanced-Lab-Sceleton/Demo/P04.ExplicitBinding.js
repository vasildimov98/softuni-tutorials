let person1 = {
    name: "Alex",
    age: 34,
};

let person2 = {
    name: "Peter",
    age: 21,
};

function intoducePerson(saySthElse, job) {
    console.log(`Hy my name is ${this.name} and I am ${this.age} years old. ${saySthElse} and I work as a ${job}`);
}

// call() and apply()
let person1Args = ['I live in Texas', 'constructor'];
let person2Args = ['I live in Sofia', 'filmaker'];

intoducePerson.apply(person1, person1Args);
intoducePerson.apply(person2, person2Args);

// bind()
let person1Func = intoducePerson.bind(person1, ...person1Args);

intoducePerson.apply({
    name: "Penka",
    age: 12,
}, person2Args);