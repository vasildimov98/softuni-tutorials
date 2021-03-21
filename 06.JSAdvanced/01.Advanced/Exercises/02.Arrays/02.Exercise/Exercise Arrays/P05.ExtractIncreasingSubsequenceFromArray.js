function showIncreasingSubsequence(arr) {
    let max = arr[0];
    let increasingSubsequence = arr.reduce((output, el) => {
         if (el >= max) {
             output.push(el);
             max = el;
         }   

        return output;
    }, []);

    console.log(increasingSubsequence.join('\n'));
}

showIncreasingSubsequence(
    [1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24]
);
showIncreasingSubsequence(
    [1,
    2,
    3,
    4]

);

showIncreasingSubsequence(
    [20,
    3,
    2,
    15,
    6,
    1]
);
