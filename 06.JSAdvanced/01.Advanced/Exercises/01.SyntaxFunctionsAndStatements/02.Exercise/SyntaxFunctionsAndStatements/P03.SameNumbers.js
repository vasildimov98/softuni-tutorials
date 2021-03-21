function analyseNumber(number) {
    let parseNumber = Number(number);

    let lastDigit = parseNumber % 10;
    let sum = lastDigit;
    let isTheSame = true;
    while (true) {
        parseNumber = Math.floor(parseNumber / 10);

        if (parseNumber == 0) {
            break;
        }
        
        let nextDigit = parseNumber % 10;
        sum += nextDigit;

        if (lastDigit != nextDigit && isTheSame) {
            isTheSame = false;
        }

        lastDigit = nextDigit;
    }

    console.log(isTheSame);
    console.log(sum);
}

analyseNumber(2222222);
analyseNumber(1234);