function showWordsWithCount(sentence) {
    let words = sentence
        .pop()
        .split(' ');

    let countOfWords = {};
    words.forEach(word => {
        let isWithComma = word.includes(',');
        let isWithPoint = word.includes('.');
        let IsWithScope = word.includes('-');
        let isWithUpperComma = word.includes("'");

        if (checkForOtherWords(isWithComma, ',', word)
            && checkForOtherWords(isWithPoint, '.', word)
            && checkForOtherWords(IsWithScope, '-', word)
            && checkForOtherWords(isWithUpperComma, "'", word)) {
            if (!countOfWords[word]) {
                countOfWords[word] = 0;
            }

            countOfWords[word]++;
        }

    });

    console.log(JSON.stringify(countOfWords));

    function checkForOtherWords(predicate, symbol, word) {
        if (predicate) {
            let indexOfComma = word.indexOf(symbol);

            let firstWord = word.substring(0, indexOfComma);
            let secondWord = word.substring(indexOfComma + 1);

            if (!countOfWords[firstWord]) {
                countOfWords[firstWord] = 0;
            }

            countOfWords[firstWord]++;

            if (secondWord
                && !secondWord.includes("'")
                && !secondWord.includes(",")
                && !secondWord.includes(".")
                && !secondWord.includes("-")) {
                if (!countOfWords[secondWord]) {
                    countOfWords[secondWord] = 0;
                }

                countOfWords[secondWord]++;
            }

            return false;
        }

        return true;
    }
}

showWordsWithCount(["Far too slow, you're far too slow."]);
showWordsWithCount(['JS devs use Node.js for server-side JS.-- JS for devs']);