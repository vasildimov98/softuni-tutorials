function focus() {
    let divElement = document.querySelector('div');

    divElement.addEventListener('focus', focus, true);

    divElement.addEventListener('blur', blur, true);

    function focus(e) {
       e.target.parentElement.classList.add('focused');
    }

    function blur(e) {
        e.target.parentElement.classList.remove('focused');
    }
}