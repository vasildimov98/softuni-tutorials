function sumOfNtoM(n, m) {
    let parseN = (Number(n));
    let parseM = (Number(m));
    let result = 0;
    while (parseN <= parseM) {
        result += parseN;

        parseN++;
    }

    console.log(result);
}

sumOfNtoM('1', '5');
sumOfNtoM('-8', '20');

