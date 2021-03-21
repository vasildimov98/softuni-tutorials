(function extedArray() {
    Array.prototype.last = function () {
        return this[this.length - 1];
    };

    Array.prototype.skip = function (n) {
        return this
            .filter((_a, i) => i >= n);
    };

    Array.prototype.take = function (n) {
        return this
            .filter((_a, i) => i < n);
    };

    Array.prototype.sum = function () {
        return this
            .reduce((a, b) => a + b, 0);
    };

    Array.prototype.average = function () {
        return this
            .sum() / this.length;
    };
})();

let myArr = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

console.log(myArr.last());
console.log(myArr.skip(7));
console.log(myArr);
console.log(myArr.take(7));
console.log(myArr);
console.log(myArr.sum());
console.log(myArr.average());

;