function sortArray(arr) {
    arr.sort((a, b) => {
        if (a.length - b.length === 0) {
            return a.localeCompare(b);
        } else {
            return a.length - b.length;
        }
    })

    console.log(arr.join('\n'));
}

sortArray([
    'alpha',
    'beta',
    'gamma']
);
sortArray([
    'Isacc',
    'Theodor',
    'Jack',
    'Harrison',
    'George']
);
sortArray([
    'test',
    'Deny',
    'omen',
    'Default']
);