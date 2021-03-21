function showDriverSpeedInfo(driverInfos) {
    let driverSpeed = driverInfos[0];
    let area = driverInfos[1];

    let result;
    switch (area) {
        case 'motorway':
            result = getInfoForDrivingLimit(130);
        break;
        case 'interstate':
            result = getInfoForDrivingLimit(90);
        break;
        case 'city':
            result = getInfoForDrivingLimit(50);
        break;
        case 'residential':
            result = getInfoForDrivingLimit(20);
        break;
    }

    console.log(result);

    function getInfoForDrivingLimit(speedLimit) {
        let diff = driverSpeed - speedLimit;

        if (diff > 0 && diff <= 20) {
            return 'speeding';
        } else if (diff > 20 && diff <= 40) {
            return 'excessive speeding';
        } else if (diff > 40) {
            return 'reckless driving';
        } else {
            return '';
        }
    }
}

showDriverSpeedInfo([40, 'city']);
showDriverSpeedInfo([21, 'residential']);
showDriverSpeedInfo([120, 'interstate']);
showDriverSpeedInfo([200, 'motorway']);