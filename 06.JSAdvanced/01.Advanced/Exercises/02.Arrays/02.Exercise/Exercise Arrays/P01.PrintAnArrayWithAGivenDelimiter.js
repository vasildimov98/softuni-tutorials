function showArrayWithGivenDelimiter(arrayWithDelimiter) {
    let delimiter = arrayWithDelimiter.pop();

    console.log(arrayWithDelimiter.join(delimiter));
}

showArrayWithGivenDelimiter(['One', 'Two','Three', 'Four', 'Five', '-']);
showArrayWithGivenDelimiter(['How about no?', 'I','will', 'not', 'do', 'it!', '_']);