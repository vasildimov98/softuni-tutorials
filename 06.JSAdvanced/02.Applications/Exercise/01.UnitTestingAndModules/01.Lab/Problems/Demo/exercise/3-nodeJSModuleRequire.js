// console.log(module);
// console.log(require);

const {Accounter, defaultName} = require('./3-nodeJSModuleExport').default;

let accounter = new Accounter(defaultName, 21, 2500);

console.log(`Hello, my name is ${accounter.name}. I currently have ${accounter.numberToAccountingString(accounter.salary)} levas to my bank account!`);