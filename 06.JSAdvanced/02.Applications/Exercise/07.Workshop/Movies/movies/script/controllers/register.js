import services from '../services.js';

export default function() {
    Promise
        .all([
            getTemplate('./templates/common/header.hbs'),
            getTemplate('./templates/common/footer.hbs'),
            getTemplate('./templates/register/register.hbs')
        ]).then(([header, footer, register]) => {
            Handlebars.registerPartial('header', header);
            Handlebars.registerPartial('footer', footer);

            const createRegisterPage = Handlebars.compile(register);
            const registerPage = createRegisterPage();

            htmlSelector.mainDiv().innerHTML = registerPage;
        });
}

export function registerUser() {
    const formData = new FormData(htmlSelector.formElement());

    const email = formData.get('email');
    const password = formData.get('password');
    const repeatPassword = formData.get('repeatPassword');

    const userInfo = services
        .register(email, password, repeatPassword);

    userInfo
        .then(data => {
            if (!data) return;
            redirectRoute('/home');
            successHandler({ message: 'Successful registration!' });
        });
}