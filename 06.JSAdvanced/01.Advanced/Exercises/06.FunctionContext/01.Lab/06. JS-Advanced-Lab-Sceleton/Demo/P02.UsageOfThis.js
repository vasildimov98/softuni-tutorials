// //1. this in Methods

// let person = {
//     firstName: "Peter",
//     lastName: "Ivanov",
//     fullName: function () {
//         return this.firstName + " " + this.lastName
//     },
//     whatIsThis: function () { return this }
// }
// console.log(person.fullName());  // Peter Ivanov
// console.log(person.whatIsThis()); 

// // 2. this refering to the parent object
// function foo() {
//     console.log(this === global);
// }
// let user = {
//     count: 10,
//     foo: foo,
//     bar: function () { console.log(this === global); }
// }

// foo() //true;
// user.foo()  // false
// let func = user.bar;
// console.log(user.bar == foo); // false
// func() // true
// user.bar()  // false

// // 3. this usage in classes
// class Person {
//     constructor(fn, ln) {
//       this.first_name = fn;
//       this.last_name = ln;
//       this.displayName = function () {
//         console.log(`Name: ${this.first_name} ${this.last_name}`);
//       } } };
//   let person = new Person("John", "Doe");
//   let person2 = new Person("John2", "Doe2");
//   person.displayName();  // John Doe  
//   person2.displayName();  // John2 Doe2 

// // 4. this in Functions
// function outer() {
//     console.log(this); // Object {name: "Peter"}

//     let inner = () => {
//         console.log(this); // Global
//     }

//     inner();
// }

// const obj = {
//     name: 'Peter',
//     func: outer
// };

// obj.func();