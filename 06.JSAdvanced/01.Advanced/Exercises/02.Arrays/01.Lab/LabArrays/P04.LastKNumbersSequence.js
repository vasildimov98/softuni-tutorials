function showSequence(n, k) {
    let arr = [];
    arr.length = n;
    arr[0] = 1;
    arr[1] = 1;

    for (let i = 2; i < arr.length; i++) {
        let nextEl = 0;
        let end = i - k >= 0 ? i - k : 0;
        for (j = i - 1; j >= end; j--) {
            nextEl += arr[j];
        }

        arr[i] = nextEl;
    }

    let finalResult = arr.join(' ');

    console.log(finalResult);
}

showSequence(6, 3);
showSequence(8, 1);


