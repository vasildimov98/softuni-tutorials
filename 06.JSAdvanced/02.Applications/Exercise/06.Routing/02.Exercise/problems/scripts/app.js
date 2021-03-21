import home from './controllers/home.js';
import about from './controllers/about.js';
import login, { loginUser } from './controllers/login.js';
import logout from './controllers/logout.js';
import register, { registerUser } from './controllers/register.js';
import catalog from './controllers/catalog.js';
import create, { createNewTeam } from './controllers/create.js';
import details from './controllers/details.js';
import edit, { editCurrTeam } from './controllers/edit.js';

$(() => {
    const app = Sammy(mainDivId, function() {
        this.use(handlebarsName, extensionName);

        this.userData = {
            loggedIn: true,
            hasNoTeam: true,
        };

        this.get(emptyPathRoute, home);
        this.get(homePageRoute, home);

        this.get(aboutRoute, about);

        this.get(loginRoute, login);
        this.get(logoutRoute, logout);
        this.post(loginRoute, loginUser);

        this.get(registerRoute, register);
        this.post(registerRoute, registerUser);

        this.get(catalogRoute, catalog);
        this.get(teamRoute, details);

        this.get(createRoute, create);
        this.post(createRoute, createNewTeam);

        this.get(editRoute, edit);
        this.post(editRoute, editCurrTeam);
    });

    app.run();
});