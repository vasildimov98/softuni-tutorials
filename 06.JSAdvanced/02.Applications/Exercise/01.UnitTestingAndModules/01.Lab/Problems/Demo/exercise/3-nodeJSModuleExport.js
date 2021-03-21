class Person {
    constructor(name, age) {
        this.name = name;
        this.age = age;
    }

    get name() {
        return this._name;
    }

    set name(value) {
        this._name = value;
    }
}

class Accounter extends Person {
    constructor(name, age, salary) {
        super(name, age);
        this.salary = salary;
    }

    numberToAccountingString(number) {
        if (number == null) return;
        if (number >= 0) return number.toString();
        return `(${Math.abs(number)})`;
    }
}

function getName(name) {
    return name;
}

function numberToAccountingString(number) {
    if (number == null) return;
    if (number >= 0) return number.toString();
    return `(${Math.abs(number)})`;
}

let two = 2;
let minusTwo = -2;
let twenty = 20;
let minusThirty = -30;

// console.log(numberToAccountingString(two));
// console.log(numberToAccountingString(minusTwo));
// console.log(numberToAccountingString(twenty));
// console.log(numberToAccountingString(minusThirty));
// console.log(numberToAccountingString(undefined));

console.log(module);

const defaultName = 'Vasil';

const _getName = getName;
export { _getName as getName };
const _numberToAccountingString = numberToAccountingString;
export { _numberToAccountingString as numberToAccountingString };
const _Person = Person;
export { _Person as Person };

export default {
    Accounter,
    defaultName,
};

console.log(module);

;