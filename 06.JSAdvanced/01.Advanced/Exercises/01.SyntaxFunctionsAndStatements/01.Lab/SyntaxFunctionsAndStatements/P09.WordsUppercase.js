function GetWordsFromSentenceInUppercase(sentence) {
    let result = sentence
        .toUpperCase()
        .match(/\w+/g)
        .join(', ');

    console.log(result)
}

GetWordsFromSentenceInUppercase('Hi, how are you?');