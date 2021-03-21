class Demo {
    constructor(name) {
        console.log(this);
        this.name = name;
    }
}

function FucDemo(a, b, c) {
    console.log(arguments);
}

FucDemo(1, 2, 3);

let myArr =[1, 2, 3];

console.log(myArr);

throw new RuntimeError();