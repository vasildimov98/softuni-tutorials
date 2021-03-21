function showTheTimeToTheUniForStudent(steps, length, speed) {
    let stepLength = Number(steps) * Number(length);
    let speedInMeters = Number(speed) / 3.6;
    let rest = Math.floor(stepLength / 500);
    let timeInSec = stepLength / speedInMeters + rest * 60;

    let hour = Math.floor(timeInSec / 3600);
    let min = Math.floor(timeInSec / 60);
    let sec = Math.ceil(timeInSec % 60);

    console.log(`${hour < 10 ? '0' + hour : hour}:${min < 10 ? '0' + min : min}:${sec < 10 ? '0' + sec : sec}`)
}

showTheTimeToTheUniForStudent(4000, 0.60, 5);
showTheTimeToTheUniForStudent(2564, 0.70, 5.5);