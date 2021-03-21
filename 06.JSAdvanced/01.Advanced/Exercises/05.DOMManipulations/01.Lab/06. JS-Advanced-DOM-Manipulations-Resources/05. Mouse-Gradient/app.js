function attachGradientEvents() {
    let gradientElement = document
        .getElementById('gradient')
    let resultElement = document
        .getElementById('result');

    gradientElement
        .addEventListener('mousemove', onMouseOverShowPercent);
    gradientElement
        .addEventListener('mouseout', onMouseOutClearPercent);

    function onMouseOverShowPercent(e) {
        let offset = e.offsetX;
        let width = e.target.clientWidth;

        let percent = Math.trunc((offset / (width - 1)) * 100) + '%';

        resultElement.textContent = percent;
    }

    function onMouseOutClearPercent() {
        resultElement.textContent = '';
    }
}