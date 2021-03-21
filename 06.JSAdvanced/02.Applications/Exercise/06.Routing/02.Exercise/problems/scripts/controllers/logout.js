export default function() {
    userAuth
        .signOut()
        .then(() => {
            localStorage.removeItem('userEmail');
            localStorage.removeItem('userToken');
            this.app.userData.loggedIn = false;
            this.redirect(homePageRoute);
        })
        .catch(errorHandler);
}