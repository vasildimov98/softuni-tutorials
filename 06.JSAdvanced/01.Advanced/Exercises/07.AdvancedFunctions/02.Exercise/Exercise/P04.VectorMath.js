let solution = (function vectorrMath() {
    return {
        add: (vec1, vec2) => {
            let [x1, y1] = vec1;
            let [x2, y2] = vec2;
            return [x1 + x2, y1 + y2];
        },
        multiply: (vec1, scalar) => {
            let [x1, y1] = vec1;

            return [x1 * scalar, y1 * scalar];
        },
        length: (vec1) => {
            let [x1, y1] = vec1;

            return Math.sqrt(Math.pow(x1, 2) + Math.pow(y1, 2));
        },
        dot: (vec1, vec2) => {
            let [x1, y1] = vec1;
            let [x2, y2] = vec2;

            return x1 * x1 + y1 * y2;
        },
        cross: (vec1, vec2) => {
            let [x1, y1] = vec1;
            let [x2, y2] = vec2;
            
            return x1 * y2 - x2 * y1;
        },
    }
})();

let addResult = solution.add([1, 1], [1, 0]);
let multResult = solution.multiply([3.5, -2], 2);
let lengthResult = solution.length([3, -4]);
let dotResult = solution.dot([2, 3], [2, -1]);
let crossResult = solution.cross([3, 7], [1, 0]);

//console.log(addResult);
//console.log(multResult);
//console.log(lengthResult);
console.log(dotResult);
//console.log(crossResult);