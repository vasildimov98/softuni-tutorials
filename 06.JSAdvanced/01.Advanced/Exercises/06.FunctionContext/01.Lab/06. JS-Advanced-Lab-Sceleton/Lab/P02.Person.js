class Person {
    constructor(firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
    }

    get fullName() {
        return `${this.firstName} ${this.lastName}`;
    }

    set fullName(value) {
        let regex = /\w \w/;
        if (regex.test(value)) {
            let [firstName, lastName] = value.split(' ');

            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}

let person = new Person("Peter", "Ivanov");
console.log(person.fullName);//Peter Ivanov
person.firstName = "George";
console.log(person.fullName);//George Ivanov
person.lastName = "Peterson";
console.log(person.fullName);//George Peterson
person.fullName = "Nikola Tesla";
console.log(person.firstName)//Nikola
console.log(person.lastName)//Tesla


let person1 = new Person("Albert", "Simpson");
console.log(person1.fullName);//Albert Simpson
person1.firstName = "Simon";
console.log(person1.fullName);//Simon Simpson
person1.fullName = "Peter";
console.log(person1.firstName) // Simon
console.log(person1.lastName) // Simpson