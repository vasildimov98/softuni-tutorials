(function extendString() {
    Object
        .defineProperty(String.prototype, 'ensureStart', {
            value: function ensureStart(str) {
                if (!this.startsWith(str)) {
                    return str + this;
                }

                return String(this);
            },
        });

    Object
        .defineProperty(String.prototype, 'ensureEnd', {
            value: function ensureEnd(str) {
                if (!this.endsWith(str)) {
                    return this + str;
                }

                return String(this);
            },
        });

    Object
        .defineProperty(String.prototype, 'isEmpty', {
            value: function isEmpty() { return this == '' }
        });

    Object
        .defineProperty(String.prototype, 'truncate', {
            value: function truncate(n) {
                if (this.length <= n) {
                    return String(this);
                } else if (this.length > n
                    && this.includes(' ')) {
                        
                    let splitString = this.split(' ');
                    let newString = [];

                    let currStr = splitString.shift();
                    let lengthSum = newString
                        .reduce((a, b) => a + b.length, 0)
                        + currStr.length + 3;

                    while (lengthSum <= n) {
                        newString.push(currStr + ' ');

                        currStr = splitString.shift();
                        lengthSum = newString
                            .reduce((a, b) => a + b.length, 0)
                            + currStr.length + 3;
                    }

                    return newString.join('').trim() + '...';
                } else {
                    if (n < 4) {
                        return '.'.repeat(n);
                    } else {
                        return this.substring(0, n - 3) + '...';
                    }
                }
            }
        });

    Object
        .defineProperty(String, 'format', {
            value: function format(string, ...params) {
                return string.replace(/{\d+}/g, (match) => {
                    let index = Number(match[1]);

                    return params[index] ? params[index] : match;
                });
            }
        });
})();

// let str = 'my string';
// str = str.ensureStart('my');
// str = str.ensureStart('hello ');
// str = str.truncate(16);
// str = str.truncate(14);
// str = str.truncate(8);
// str = str.truncate(4);
// str = str.truncate(2);
// str = String.format('The {0} {1} fox',
//     'quick', 'brown');
// console.log(str);
// str = String.format('jumps {0} {1}',
//     'dog');
// console.log(str);

var testString = 'the quick brown fox jumps over the lazy dog';
console.log(testString.length);
console.log(testString.truncate(45));
//expect(String.prototype.hasOwnProperty('truncate')).to.equal(true, "Couldn't find truncate() function");
//expect(testString.truncate(10)).to.equal('the...', 'Incorrect truncate() functionality 1');
//expect(testString.truncate(25)).to.equal('the quick brown fox...', 'Incorrect truncate() functionality 2');
//expect(testString.truncate(43)).to.equal('the quick brown fox jumps over the lazy dog', 'Incorrect truncate() functionality 3');
//expect(testString.truncate(45)).to.equal('the quick brown fox jumps over the lazy dog', 'Incorrect truncate() functionality 4');