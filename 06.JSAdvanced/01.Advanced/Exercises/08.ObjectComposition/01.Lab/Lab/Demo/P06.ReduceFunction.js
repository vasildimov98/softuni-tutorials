let list = [1, 2, 3, 4];

const addOne = (acc, element) => {
    acc = [element + 1, ...acc];

    return acc;
}

let sum = (totalSum, element) => {
    totalSum += element;

    return totalSum;
}

let reduce = (reduceFunc, acc, [firstElement, ...otherElements]) => {
    if (firstElement) {
        acc = reduceFunc(acc, firstElement);
        return reduce(reduceFunc, acc, otherElements)
    }

    return acc;
}

let reduceRight = (reduceFunc, acc, [firstElement, ...otherElements]) => {
    if (firstElement) {
        return reduceFunc(reduceRight(reduceFunc, acc, otherElements), firstElement);
    }

    return acc;
}

let listLeft = reduce(addOne, [], list);
let listRight = reduceRight(sum, 0, list);

console.log(listLeft);
console.log(listRight);
