function sortArray(arr, criteria) {
    return arr.sort((a, b) => {
        if (criteria == 'asc') {
            return a - b;
        } else {
            return b - a;
        }
    });
}

// console.log(sortArray([14, 7, 17, 6, 8], 'asc'));
console.log(sortArray([14, 7, 17, 6, 8], 'desc'));