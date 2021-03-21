const HTML_SELECTOR = {
    signupbtn: () => document
        .querySelector('.signupbtn'),
    alreadybtn: () => document
        .querySelector('.alreadybtn'),
    signinbtn: () => document
        .querySelector('.signinbtn'),
    gobackbtn: () => document
        .querySelector('.gobackbtn'),
    signoutbtn: () => document
        .querySelector('.signoutbtn'),
    email: () => document
        .querySelectorAll('.email'),
    password: () => document
        .querySelectorAll('.psw'),
    infoArea: () => document
        .querySelector('.infoArea'),
    signUpContainer: () => document
        .querySelector('.signUpContainer'),
    signInContainer: () => document
        .querySelector('.signInContainer'),
    signOutContainer: () => document
        .querySelector('.signOutContainer'),
}

const AUTH = firebase.auth();

HTML_SELECTOR
    .signupbtn()
    .addEventListener('click', registerUser);

HTML_SELECTOR
    .signinbtn()
    .addEventListener('click', singInUser);

HTML_SELECTOR
    .signoutbtn()
    .addEventListener('click', signOutUser);

HTML_SELECTOR
    .alreadybtn()
    .addEventListener('click', showSignInContainer);

HTML_SELECTOR
    .gobackbtn()
    .addEventListener('click', showRegisterContainer);

const EMAIL_SIGN_UP_INPUT = HTML_SELECTOR.email()[0];
const PASSWORD_SIGN_UP_INPUT = HTML_SELECTOR.password()[0];

const EMAIL_SIGN_IN_INPUT = HTML_SELECTOR.email()[1];
const PASSWORD_SIGN_IN_INPUT = HTML_SELECTOR.password()[1];

const INFO_PARAGRAPH = HTML_SELECTOR.infoArea();

const SING_UP_CONTAINER = HTML_SELECTOR.signUpContainer();
const SING_IN_CONTAINER = HTML_SELECTOR.signInContainer();
const SING_OUT_CONTAINER = HTML_SELECTOR.signOutContainer();

function signOutUser(e) {
    e.preventDefault();

    AUTH
        .signOut()
        .then(showRegisterContainer)
}

function singInUser(e) {
    e.preventDefault();

    let email = EMAIL_SIGN_IN_INPUT.value;
    let password = PASSWORD_SIGN_IN_INPUT.value;

    AUTH
        .signInWithEmailAndPassword(email, password)
        .then(showWebsite)
        .catch(errorHandler);

    EMAIL_SIGN_IN_INPUT.value = '';
    PASSWORD_SIGN_IN_INPUT.value = '';
}

function registerUser(e) {
    e.preventDefault();

    let email = EMAIL_SIGN_UP_INPUT.value;
    let password = PASSWORD_SIGN_UP_INPUT.value;

    AUTH
        .createUserWithEmailAndPassword(email, password)
        .then(showSignInContainer)
        .catch(errorHandler);

    EMAIL_SIGN_UP_INPUT.value = '';
    PASSWORD_SIGN_UP_INPUT.value = '';
}

function showRegisterContainer() {
    SING_UP_CONTAINER.setAttribute('style', 'display: border');
    SING_OUT_CONTAINER.setAttribute('style', 'display: none');
    SING_IN_CONTAINER.setAttribute('style', 'display: none');
}

function showWebsite() {
    SING_IN_CONTAINER.setAttribute('style', 'display: none');
    SING_OUT_CONTAINER.setAttribute('style', 'display: border');
}

function showSignInContainer() {
    SING_UP_CONTAINER.setAttribute('style', 'display: none');
    SING_IN_CONTAINER.setAttribute('style', 'display: border');
}

function errorHandler({ message }) {
    INFO_PARAGRAPH.setAttribute('style', 'color: red');
    INFO_PARAGRAPH.textContent = message;
}