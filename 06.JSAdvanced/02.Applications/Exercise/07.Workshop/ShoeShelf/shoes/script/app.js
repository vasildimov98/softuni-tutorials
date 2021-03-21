import renderHomePage from './controllers/home.js';
import renderRegisterPage, { registerUser } from './controllers/register.js';
import renderLoginPage, { loginUser, logoutUser } from './controllers/login.js';
import renderCreatePage, { createShoe } from './controllers/create.js';
import renderDetailsPage, { buyCurrShoe, deleteCurrShoe } from './controllers/details.js';
import renderEditPage, { editShoeDetails } from './controllers/edit.js';

window
    .addEventListener('load', function() {
        createRoute('/home', renderHomePage);
        createRoute('/register', renderRegisterPage);
        createRoute('/login', renderLoginPage);
        createRoute('/logout', logoutUser);
        createRoute('/create', renderCreatePage);
        createRoute('/details', renderDetailsPage);
        createRoute('/edit', renderEditPage);
        createRoute('/buy', buyCurrShoe);
        createRoute('/delete', deleteCurrShoe);

        redirectRoute(location.pathname);
    });

window
    .addEventListener('popstate', () => redirectRoute(location.pathname, true));

htmlSelector
    .mainDiv()
    .addEventListener('click', function(e) {
        let target = e.target;
        let tagName = target.tagName;

        let parent = e.target.parentElement;
        let parentTagName = parent.tagName;

        if (tagName == 'BUTTON') {
            e.preventDefault();
            const pathname = location.pathname;

            const id = pathname
                .split('/')
                .filter(x => x != '')[1];

            if (pathname.includes('register')) registerUser();
            else if (pathname.includes('login')) loginUser();
            else if (pathname.includes('create')) createShoe();
            else if (pathname.includes('edit')) editShoeDetails(id);
            return;
        }

        if (tagName != 'A' && parentTagName != 'A') return;

        e.preventDefault();

        if (parentTagName == 'A')
            target = parent;

        let url = new URL(target.href);

        if (url.pathname.includes('logout')) redirectRoute(url.pathname, true);
        else if (url.pathname.includes('buy')) redirectRoute(url.pathname, true);
        else if (url.pathname.includes('delete')) redirectRoute(url.pathname, true);
        else redirectRoute(url.pathname);
    });