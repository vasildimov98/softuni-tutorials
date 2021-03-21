(function getLogger(scope) {
    let loadingMsg = 'You have logged in!!';
    let unlogMsg = 'You have logged out!!';
    
    let login = function getLogin() {
        console.log(loadingMsg);
    }
    
    let logout = function getLogout() {
        console.log(unlogMsg);
    }

    scope.logger = {
        login,
        logout,
    };
})(window);