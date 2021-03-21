import renderHome from './controllers/home.js';
import renderLogin, { logInUser, logOutUser } from './controllers/logIn.js';
import renderRegister, { registerUser } from './controllers/register.js';
import renderAddForm, { addMovie } from './controllers/add.js';
import renderMovieDetails, { likeCurrMovie, deleteCurrMovie } from './controllers/details.js';
import renderMovieEdit, { editMovie } from './controllers/edit.js';
import filterMovies from './controllers/filter.js';

window.addEventListener('load', navigateRoute);
window.addEventListener('popstate', () => redirectRoute(location.pathname, true))
htmlSelector
    .mainDiv()
    .addEventListener('click', navigateRoute);

createRoutePath('/', renderHome);
createRoutePath('/home', renderHome);
createRoutePath('/login', renderLogin);
createRoutePath('/register', renderRegister);
createRoutePath('/add', renderAddForm);
createRoutePath('/details', renderMovieDetails);
createRoutePath('/edit', renderMovieEdit);

function createRoutePath(path, callback) {
    routes[`${path || ''}`] = callback;
}

function navigateRoute(e) {
    let target = e.target;
    let tagName = e.target.tagName;
    if (target == document) {
        redirectRoute(location.pathname, true);
        return;
    } else if (tagName == 'BUTTON') {
        e.preventDefault();
        const path = location.pathname;
        if (path.includes('/login')) logInUser();
        else if (path.includes('/register')) registerUser();
        else if (path.includes('/add')) addMovie();
        else if (path.includes('/edit')) {
            const [_, id] = path
                .split('/')
                .filter(p => p != "");
            editMovie(id);
        } else if (path == '/home' ||
            location.pathname == '/') {
            target = e.target.parentElement;
            tagName = target.tagName;
        } else return;
    } else if (target.value == 'Search') {
        e.preventDefault();
        const filter = target.parentElement.querySelector('input').value;
        filterMovies(filter);
    }

    if (tagName == 'A') {
        e.preventDefault();

        const url = new URL(target.href);
        const path = url.pathname;
        if (path.includes('/logout')) logOutUser();
        else if (path.includes('/like')) {
            const [_, id] = path
                .split('/')
                .filter(p => p != "");

            likeCurrMovie(id);
        } else if (path.includes('/delete')) {
            const [_, id] = path
                .split('/')
                .filter(p => p != "");

            deleteCurrMovie(id);
        } else redirectRoute(path);

    } else return;
}