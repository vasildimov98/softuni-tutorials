export default function() {
    Promise
        .all([
            getTemplate('../templates/common/header.hbs'),
            getTemplate('../templates/common/footer.hbs'),
            getTemplate('../templates/user-auth/login.hbs')
        ])
        .then(([header, footer, login]) => {
            Handlebars.registerPartial('header', header);
            Handlebars.registerPartial('footer', footer);

            const createLoginPage = Handlebars.compile(login);

            htmlSelector.mainDiv().innerHTML = createLoginPage();
        });
}

export function loginUser() {
    const formData = new FormData(htmlSelector.form());

    const email = formData.get('email');
    const password = formData.get('password');

    requests
        .loginUser(email, password)
        .then(user => {
            if (!user) return;
            localStorage.setItem('userInfo', JSON.stringify(user))
            redirectRoute('/home');
        });
}

export function logoutUser() {
    localStorage.removeItem('userInfo');
    data = {};
    redirectRoute('/login');
}