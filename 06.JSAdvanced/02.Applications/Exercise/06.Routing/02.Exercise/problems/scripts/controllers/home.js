export default function() {
    const userData = this.app.userData;
    userData.email = localStorage.getItem('userEmail');
    this.loadPartials({
        [headerPartialName]: headerPartialPath,
        [footerPartialName]: footerPartialPath,
    }).then(function() {
        this.partial(homePageTemplatePath, userData);
    });
}