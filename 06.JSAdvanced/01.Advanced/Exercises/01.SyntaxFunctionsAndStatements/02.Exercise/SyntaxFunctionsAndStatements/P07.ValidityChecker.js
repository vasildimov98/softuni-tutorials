function showIfPoinsAreValid(pointsInfo) {
    let x1 = pointsInfo.shift();
    let y1 = pointsInfo.shift();
    let x2 = pointsInfo.shift();
    let y2 = pointsInfo.shift();

    let isValid1 = getDistanceBetweenTwoPoints(x1, y1, 0, 0);
    let isValid2 = getDistanceBetweenTwoPoints(x2, y2, 0, 0);
    let isValid3 = getDistanceBetweenTwoPoints(x1, y1, x2, y2);

    console.log(`{${x1}, ${y1}} to {0, 0} is ${isValid1}`);
    console.log(`{${x2}, ${y2}} to {0, 0} is ${isValid2}`);
    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${isValid3}`);

    function getDistanceBetweenTwoPoints(x1, y1, x2, y2) {
        let distance = Math.sqrt(((x2 - x1) ** 2) + ((y2 - y1)) ** 2);

        if (Number.isInteger(distance)) {
            return 'valid';
        } else {
            return 'invalid';
        }
    }
}

showIfPoinsAreValid([2, 1, 1, 1]);
showIfPoinsAreValid([3, 0, 0, 4]);