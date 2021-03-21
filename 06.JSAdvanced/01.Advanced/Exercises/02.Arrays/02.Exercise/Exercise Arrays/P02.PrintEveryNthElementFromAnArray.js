function showEveryNthElement(elements) {
    let steps = elements.pop();

    elements = elements
    .filter((_el, index) => index % steps == 0)
    .join('\n');

    console.log(elements);
}

showEveryNthElement(['5', '20', '31', '4', '20', '2']);
showEveryNthElement(['dsa','asd', 'test', 'tset', '2']);
showEveryNthElement(['1', '2', '3', '4', '5', '6']);