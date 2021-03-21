import services from '../services.js';

export default function() {
    Promise
        .all([
            getTemplate('../templates/common/header.hbs'),
            getTemplate('../templates/common/footer.hbs'),
            getTemplate('../templates/login/login.hbs')
        ]).then(([header, footer, login]) => {
            Handlebars.registerPartial('header', header);
            Handlebars.registerPartial('footer', footer);

            const createHomePage = Handlebars.compile(login);
            const loginPage = createHomePage();

            htmlSelector.mainDiv().innerHTML = loginPage;
        });
}

export function logInUser() {
    const formData = new FormData(htmlSelector.formElement());

    const email = formData.get('email');
    const password = formData.get('password');

    const userInfo = services
        .login(email, password);

    userInfo
        .then(data => {
            if (!data) return;

            localStorage.setItem('userInfo', JSON.stringify(data));
            redirectRoute('/home');
            successHandler({ message: 'Login successful.' });
        });
}

export function logOutUser() {
    localStorage.removeItem('userInfo');
    redirectRoute('/login');
    successHandler({ message: 'Successful logout.' });
}