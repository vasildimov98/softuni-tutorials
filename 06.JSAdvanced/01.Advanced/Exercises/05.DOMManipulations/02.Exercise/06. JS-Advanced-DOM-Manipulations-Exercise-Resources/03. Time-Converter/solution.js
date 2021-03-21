function attachEventsListeners() {
    let daysInputElement = document
        .getElementById('days');
    let hoursInputElement = document
        .getElementById('hours');
    let minutesInputElement = document
        .getElementById('minutes');
    let secondsInputElement = document
        .getElementById('seconds');

    let daysBtnElement = document
        .getElementById('daysBtn');
    let hoursBtnElement = document
        .getElementById('hoursBtn');
    let minutesBtnElement = document
        .getElementById('minutesBtn');
    let secondsBtnElement = document
        .getElementById('secondsBtn');

    daysBtnElement.addEventListener('click', () => convert(+daysInputElement.value * 86400));
    hoursBtnElement.addEventListener('click', () => convert(+hoursInputElement.value * 3600));
    minutesBtnElement.addEventListener('click', () => convert(+minutesInputElement.value * 60));
    secondsBtnElement.addEventListener('click', () => convert(+secondsInputElement.value));

    function convert(sec = 0) {
        let days = sec / 86400;
        let hours = sec / 3600;
        let minutes = sec / 60;

        daysInputElement.value = days;
        hoursInputElement.value = hours;
        minutesInputElement.value = minutes;
        secondsInputElement.value = sec;
    }
}