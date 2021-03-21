function validate() {
    let inputElement = document
        .getElementById('email');
    let validEmailRegex = /^[a-z]+[@][a-z]+.[a-z]+$/;

    inputElement
        .addEventListener('change', validateEmail);

    function validateEmail(e) {
        let target = e.target;
        if (validEmailRegex.test(target.value)) {
            target.classList.remove('error');
        } else {
            target.classList.add('error');
        }
    }
}