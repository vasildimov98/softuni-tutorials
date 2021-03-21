function showUniqueArrays(arrays) {
    let uniqueArrays = new Map();
    arrays.forEach(myJSON => {
        let arr = JSON.parse(myJSON)
            .map(Number)
            .sort((a, b) => b - a);

        let uniqueArrayKey = `[${arr.join(', ')}]`

        if (!uniqueArrays.has(uniqueArrayKey)) {
            uniqueArrays.set(uniqueArrayKey, arr.length);
        }
    });

    console.log([...uniqueArrays.keys()].sort((a, b) => uniqueArrays.get(a) - uniqueArrays.get(b)).join('\n'));
}

showUniqueArrays([
    "[-3, -2, -1, 0, 1, 2, 3, 4]",
    "[10, 1, -17, 0, 2, 13]",
    "[4, -3, 3, -2, 2, -1, 1, 0]"
]
);
showUniqueArrays([
    "[7.14, 7.180, 7.339, 80.099]",
    "[7.339, 80.0990, 7.140000, 7.18]",
    "[7.339, 7.180, 7.14, 80.099]"
]
);