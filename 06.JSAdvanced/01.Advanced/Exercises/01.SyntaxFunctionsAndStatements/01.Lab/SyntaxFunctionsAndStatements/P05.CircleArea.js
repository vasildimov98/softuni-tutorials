function getCircleArea(arg) {
    let typeOfArg = typeof(arg);

    if (typeOfArg == 'number') {
        let circleArea = Math.PI * Math.pow(arg, 2);

        console.log(circleArea.toFixed(2));
    } else {
        console.log(`We can not calculate the circle area, because we receive a ${typeOfArg}.`);
    }
}

getCircleArea(5);
getCircleArea('name');