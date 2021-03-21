let manager = {
    name: 'Vasil',
    age: 22,
    employees: [
        { firstName: "John", lastName: "Doe" },
        { firstName: "Anna", lastName: "Smith" },
        { firstName: "Peter", lastName: "Jones" }
    ]
}

console.log(manager.employees[0]);

let myJSON = JSON.stringify(manager);

console.log(myJSON);

let obj = JSON.parse(myJSON);

console.log(obj);

console.log(manager == obj);
console.log(manager === obj);