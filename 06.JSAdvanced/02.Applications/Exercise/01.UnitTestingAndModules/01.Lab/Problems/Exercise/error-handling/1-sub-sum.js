function subSum(arr, startIndex, endIndex) {
    if (!(arr instanceof Array)) return NaN;
    if (startIndex < 0) startIndex = 0;
    if (endIndex >= arr.length) endIndex = arr.length - 1;

    let totalSum = 0;
    for (let index = startIndex; index <= endIndex; index++)
        totalSum += Number(arr[index]);

    return Number.isInteger(totalSum) ?
        totalSum :
        totalSum.toFixed(1);
}

console.log(subSum([10, 20, 30, 40, 50, 60], 3, 300));
console.log(subSum([1.1, 2.2, 3.3, 4.4, 5.5], -3, 1));
console.log(subSum([10, 'twenty', 30, 40], 0, 2));
console.log(subSum([], 1, 2));
console.log(subSum('text', 0, 2));