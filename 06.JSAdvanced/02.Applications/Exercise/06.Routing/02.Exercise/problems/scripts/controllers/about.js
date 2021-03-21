export default function() {
    const userData = this.app.userData;

    this.loadPartials({
        [headerPartialName]: headerPartialPath,
        [footerPartialName]: footerPartialPath,
    }).then(function() {
        this.partial(aboutPageTemplatePath, userData);
    });
}