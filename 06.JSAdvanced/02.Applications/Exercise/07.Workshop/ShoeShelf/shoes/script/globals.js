const apiKey = 'AIzaSyBe1zU-cLKjKMfDT74e_MYonG2QL_WC25c';

const routes = {};
let data = {};

const htmlSelector = {
    mainDiv: () => document.querySelector('#root'),
    form: () => document.querySelector('form'),
}

function getTemplate(path) {
    return fetch(path).then(res => res.text());
}

function checkForUser() {
    const userInfo = JSON.parse(localStorage.getItem('userInfo'));

    if (!userInfo) return;

    data['isLoggedIn'] = true;
    data['email'] = userInfo.email;
}

async function checkForShoes() {
    const shoes = await requests.getAllShoes();
    if (shoes) {
        shoes
            .sort((a, b) => b['people-bought-it'].length - a['people-bought-it'].length)
        data['shoes'] = shoes;
    } else delete data['shoes'];
}