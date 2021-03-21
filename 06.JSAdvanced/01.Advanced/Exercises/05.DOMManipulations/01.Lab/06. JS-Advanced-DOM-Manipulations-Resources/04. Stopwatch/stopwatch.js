function stopwatch() {
    let timeElement = document.getElementById('time');
    let startBtn = document.getElementById('startBtn');
    let stopBtn = document.getElementById('stopBtn');
    let intervalId;

    startBtn.addEventListener('click', onClickStartTimer);
    stopBtn.addEventListener('click', onClickStopTimer);

    function onClickStartTimer() {
        startBtn.disabled = true;
        stopBtn.disabled = false;

        timeElement.innerHTML = '00:00';
        let [minutes, seconds] = timeElement
            .innerHTML
            .split(':')
            .map(e => Number(e));

        intervalId = setInterval(() => {
            seconds++;
            let currentMinute = ('0' + Math.floor(seconds / 60)).slice(-2);

            let currentSecond = ('0' + seconds % 60).slice(-2);
          
            timeElement.textContent = `${currentMinute}:${currentSecond}`;

            timeElement.textContent = `${currentMinute}:${currentSecond}`;
        }, 1000)
    }

    function onClickStopTimer() {
        stopBtn.disabled = true;
        startBtn.disabled = false;
        clearInterval(intervalId);
    }
}