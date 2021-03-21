export default function() {
    const userData = this.app.userData;

    this.loadPartials({
        [headerPartialName]: headerPartialPath,
        [footerPartialName]: footerPartialPath,
        [registerPartialName]: registerPartialPath,
    }).then(function() {
        this.partial(registerPageTemplatePath, userData);
    });
}

export function registerUser() {
    const { email, password, repeatPassword } = this.params;

    if (!validateUserEntries(email, password, repeatPassword)) return;

    userAuth
        .createUserWithEmailAndPassword(email, password)
        .then(() => { this.redirect(loginRoute) })
        .catch(errorHandler);
}