let Extensible = (function solve(){
    let id = 0;
  class Extensible {
        constructor() {
          this.id = id++;
        }
        
        extend(template) {
            for (let prop in template) {
              if (typeof template[prop] == 'function')
                 Extensible.prototype[prop] = template[prop];
              else
                 this[prop] = template[prop];
            }
          }
          
  }
   
return Extensible;
})();

let obj1 = new Extensible();
let obj2 = new Extensible();
let obj3 = new Extensible();
obj1.extend(obj2);
console.log(obj1.id);
console.log(obj2.id);
console.log(obj3.id);
