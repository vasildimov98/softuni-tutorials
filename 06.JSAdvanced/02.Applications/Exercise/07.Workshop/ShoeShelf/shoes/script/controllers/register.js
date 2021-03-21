export default function() {
    Promise
        .all([
            getTemplate('../templates/common/header.hbs'),
            getTemplate('../templates/common/footer.hbs'),
            getTemplate('../templates/user-auth/register.hbs')
        ])
        .then(([header, footer, register]) => {
            Handlebars.registerPartial('header', header);
            Handlebars.registerPartial('footer', footer);

            const createRegisterPage = Handlebars.compile(register);

            htmlSelector.mainDiv().innerHTML = createRegisterPage();
        });
}

export function registerUser() {
    const formData = new FormData(htmlSelector.form());

    const email = formData.get('email');
    const password = formData.get('password');
    const rePassword = formData.get('re-password');

    requests
        .registerUser(email, password, rePassword)
        .then(res => {
            if (!res) return;

            redirectRoute('/home');
        });
}