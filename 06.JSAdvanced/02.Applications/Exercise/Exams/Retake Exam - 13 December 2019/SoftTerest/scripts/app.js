import { homePage, profilePage } from './controllers/home.js';
import { getUserData } from './utils.js';
import { loginUser, logout, postLogin, postRegister, registerUser } from './controllers/user.js';
import { createIdea, detailPage, likeIdea, postIdea, deleteIdea } from './controllers/ideas.js';


const div = document.querySelector('#loadingBox');
$(document).ajaxSend(() => {
    div.style.display = 'block';
});

$(document).ajaxComplete(() => {
    div.style.display = 'none';
});

const app = Sammy('#root', function() {
    this.use('Handlebars', 'hbs');

    this.userData = getUserData();

    this.get('/', homePage);
    this.get('/home', homePage);
    this.get('/profile', profilePage);

    this.get('/login', loginUser);
    this.get('/logout', logout);
    this.get('/register', registerUser);

    this.get('/create', createIdea);
    this.get('/details/:id', detailPage);

    this.get('/delete/:id', deleteIdea);

    this.post('/create', (ctx) => { postIdea(ctx) });
    this.post('/details/:id', (ctx) => { likeIdea(ctx) });

    this.post('/login', (ctx) => { postLogin(ctx) });
    this.post('/register', (ctx) => { postRegister(ctx) });
});

app.run();