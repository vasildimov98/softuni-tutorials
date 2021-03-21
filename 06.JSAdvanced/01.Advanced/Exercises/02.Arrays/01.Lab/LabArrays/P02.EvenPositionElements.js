function showEvenPositionsEl(numbers) {
    let evenPositionEl = numbers
                .filter((_x, i) => i % 2 === 0)
                .join(' ');

    console.log(evenPositionEl);
}

showEvenPositionsEl(['20', '30', '40']);
showEvenPositionsEl(['5', '10']);