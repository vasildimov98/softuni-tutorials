function Spy(target, method) {
    let orgFunc = target[method];

    let result = {
        count: 0,
    };

    target[method] = function () {
        result.count++;

        return orgFunc.call(this, ...arguments);
    }

    return result;
}

// let obj = {
//     method: () => "invoked"
// };

// let spy = Spy(obj, "method");

// obj.method();
// obj.method();
// obj.method();

// console.log(spy) // { count: 3 }

// let spy1 = Spy(console, "log");

// console.log(spy1); // { count: 1 }
// console.log(spy1); // { count: 2 }
// console.log(spy1); // { count: 3 }

let spy3 = new Spy(Array.prototype, 'map');

[1, 2, 3].map(x => x * 2);

console.log(spy3);
