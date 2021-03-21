function showRotatedArray(arr) {
    let rotaionCount = arr.pop() % arr.length;

    for (let i = 0; i < rotaionCount; i++) {
        arr.unshift(arr.pop())
    }

    console.log(arr.join(' '));
}

showRotatedArray(
    ['1',
    '2',
    '3',
    '4',
    '2']
);

showRotatedArray(
    ['Banana',
    'Orange',
    'Coconut',
    'Apple',
    '15']
);