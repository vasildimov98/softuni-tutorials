// class Error {
//     constructor(type, message) {
//         this.type = type;
//         this.message = message;
//     }

//     get message() {
//         return this._message;
//     }

//     set message(value) {
//         if (!value)
//             throw new TypeError('Value is undefined')

//         this._message = value;
//     }
// }

// try {
//     let error = new Error();
//     console.log(error.message);
// } catch (error) {
//     console.log(error.message);
//     console.log(error.name);
//     console.log(error.fileName);
//     console.log(error.lineNumber);
//     console.log(error.columnNumber);
//     console.log(error.stack);
// }

try {
    eval('hoo bar');
} catch (e) {
    console.error(e instanceof SyntaxError);
    console.error(e.message);
    console.error(e.name);
    console.error(e.fileName);
    console.error(e.lineNumber);
    console.error(e.columnNumber);
    console.error(e.stack);
}


// function add(a, b) {
//     return a + b;
// }

// console.log(add(2, 3));