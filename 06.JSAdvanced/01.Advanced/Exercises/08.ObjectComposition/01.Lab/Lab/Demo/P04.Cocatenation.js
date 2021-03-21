let concatenate = (obj, currObj) => ({...obj, ...currObj});


const objs = [
    { name: 'Peter', age: 35 },
    { age: 22 },
    { name: "Steven" },
    { height: 180 }
];

let person = objs.reduce(concatenate, {});

console.log(person);

