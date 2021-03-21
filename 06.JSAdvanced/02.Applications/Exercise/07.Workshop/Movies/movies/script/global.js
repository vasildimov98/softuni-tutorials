const apiKey = 'AIzaSyC-D-weFVqOHENBxNhUMNZg7CA-2zdFHRw';

const routes = {};
const data = {};

const htmlSelector = {
    mainDiv: () => document.querySelector('#main'),
    formElement: () => document.querySelector('form'),
    errorBox: () => document.querySelector('#errorBox'),
    successBox: () => document.querySelector('#successBox'),
};

function getTemplate(path) {
    return fetch(path).then(res => res.text());
}

function errorHandler({ message }) {
    htmlSelector.errorBox().innerHTML = message;
    htmlSelector.errorBox().parentElement.setAttribute('style', 'display: block');

    setTimeout(() => {
        htmlSelector.errorBox().parentElement.setAttribute('style', 'display: none');
    }, 1000);
}

function successHandler({ message }) {
    htmlSelector.successBox().innerHTML = message;
    htmlSelector.successBox().parentElement.style.display = 'block';

    setTimeout(() => {
        htmlSelector.successBox().parentElement.style.display = 'none';
    }, 1000);
}

function checkForLogInUser() {
    const userInfo = JSON.parse(localStorage.getItem('userInfo'));
    if (userInfo) {
        data['loggedIn'] = true;
        data['email'] = userInfo.email;
    } else {
        data['loggedIn'] = false;
    }
}