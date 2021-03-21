let objs = [
    { name: 'Peter', age: 35 },
    { age: 22 },
    { name: "Steven" },
    { height: 180 },
    {address: 'Sofia, ul....'},
];

const delegate = (obj, currObj) => {
    obj = Object.create(obj);
    Object.assign(obj, currObj);
    return obj;
}

let d = objs.reduceRight(delegate, {})
console.log(d); // { name: 'Peter', age: 35 }
d.newProperty = 'newProperty';

// const obj1 = {
//     a: 5,
//     b: 2,
// };

// // create an object linked to obj1
// const obj2 = Object.create(obj1);
// console.log(obj2.a); // 5