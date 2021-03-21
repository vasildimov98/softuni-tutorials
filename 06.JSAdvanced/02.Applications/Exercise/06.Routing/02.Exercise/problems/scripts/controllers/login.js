export default function() {
    const userData = this.app.userData;

    this.loadPartials({
        [headerPartialName]: headerPartialPath,
        [footerPartialName]: footerPartialPath,
        [loginPartialName]: loginPartialPath,
    }).then(function() {
        this.partial(loginPageTemplatePath, userData);
    });
}

export function loginUser() {
    const { email, password } = this.params;

    if (!validateUserEntries(email, password)) return;

    userAuth
        .signInWithEmailAndPassword(email, password)
        .then(({ user }) => {
            localStorage.setItem('userEmail', user.email);
            localStorage.setItem('userToken', user.uid);
            this.app.userData['email'] = email;
            this.app.userData['loggedIn'] = true;

            this.redirect(homePageRoute);
        }).catch(errorHandler);
}