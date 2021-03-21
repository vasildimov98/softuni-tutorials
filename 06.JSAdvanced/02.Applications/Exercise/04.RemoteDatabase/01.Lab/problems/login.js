const AUTH = firebase.auth();
const SUCCESSFUL_LOG_IN = 'Successfully sign in';
const UNSUCCESSFUL_LOG_IN = 'Couldn\'t sign in';

const LOGIN_BTN = document
    .querySelector('#loginBtn');
const LOGOUT_BTN = document
    .querySelector('#logoutBtn');

const LOGIN_DIV = document
    .querySelector('#login-form');
const LOGOUT_DIV = document
    .querySelector('#logout-form');
const USERNAME_INPUT = document
    .querySelector('#username');
const PASSWORD_INPUT = document
    .querySelector('#pass');
const LOGIN_HEADER = document
    .querySelector('.sub-headers');
const BOOKS_LIST = document
    .querySelector('#books');

function addEvents() {
    LOGIN_BTN.addEventListener('click', signInUser);
    LOGOUT_BTN.addEventListener('click', signOutUser)
}

function signOutUser() {
    LOGIN_DIV.removeAttribute('style');
    LOGOUT_DIV.setAttribute('style', 'display: none');
    AUTH
        .signOut()
        .then(res => console.log(res));
}

function signInUser() {
    let username = USERNAME_INPUT.value;
    let password = PASSWORD_INPUT.value;

    if (!username
        || !password)
        return;

    AUTH
        .signInWithEmailAndPassword(username, password)
        .then(({ user }) => {
            let email = user.email;
            let name = email
                .substring(0, email.indexOf('@'));
            name = name[0].toUpperCase() + name.slice(1);
            LOGIN_HEADER.textContent = `${SUCCESSFUL_LOG_IN}. Hello, ${name}`;
            LOGIN_DIV.setAttribute('style', 'display: none;');
            LOGOUT_DIV.removeAttribute('style');
            //BOOKS_LIST.setAttribute('style', 'display: block;');
        })
        .catch(err => {
            console.log(err);
            LOGIN_HEADER.textContent = `${UNSUCCESSFUL_LOG_IN}. ${err.message} Please try again`;
        });
}

addEvents();