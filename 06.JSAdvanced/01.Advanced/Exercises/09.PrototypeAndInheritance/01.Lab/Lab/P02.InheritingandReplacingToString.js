function toStringExtension() {
    function Person(name, email) {
        this.name = name;
        this.email = email;
    }

    Person.prototype.toString = function () {
        let className = Object
            .getPrototypeOf(this)
            .constructor
            .name;

        return `${className} (name: ${this.name}, email: ${this.email}${className == 'Person' ? ')' : ''}`;
    };

    function Teacher(name, email, subject) {
        Person.call(this, name, email);
        this.subject = subject;
    }

    Teacher.prototype = Object.create(Person.prototype);
    Teacher.prototype.constructor = Teacher;

    Teacher.prototype.toString = function () {
        let parentToString = Person
            .prototype
            .toString
            .call(this);

        return `${parentToString}, subject: ${this.subject})`;
    };

    function Student(name, email, course) {
        Person.call(this, name, email);
        this.course = course;
    }

    Student.prototype = Object.create(Person.prototype);
    Student.prototype.constructor = Student;

    Student.prototype.toString = function () {
        let parentToString = Person
            .prototype
            .toString
            .call(this);

        return `${parentToString}, course: ${this.course})`;
    };

    return {
        Person,
        Teacher,
        Student,
    };
}

let result = toStringExtension();

let person = new result.Person('Vasil', 'vasil@abv.bg');
let teacher = new result.Teacher('Pesho', 'pesho@abv.bg', 'JS Advanced');
let student = new result.Student('Lora', 'lora@abv.bg', 'C# Advanced');

console.log(person.toString());
console.log(teacher.toString());
console.log(student.toString());