function printARectangle(count = 5) {
    for (i = 1; i <= count; i++) {
        console.log('* '.repeat(count));
    }
}

printARectangle(1);
printARectangle(2);
printARectangle(10);
printARectangle();