import { getUserData } from './utils.js';
import { homePage } from './controllers/home.js';
import { loginUser, logout, postLogin, postRegister, registerUser } from './controllers/user.js';
import * as api from './data.js';
import { deletePost, detailPage, editPage, postCreate, postEdit } from './controllers/posts.js';

//DON'T FORGET TO DELETE THESE'
window.api = api;

const app = Sammy('#root', function() {
    this.use('Handlebars', 'hbs');

    this.userData = getUserData();

    this.get('/', homePage);
    this.get('/home', homePage);

    this.get('/register', registerUser);
    this.get('/login', loginUser);

    this.get('/details/:id', detailPage);
    this.get('/edit/:id', editPage);

    this.get('/delete/:id', deletePost);
    this.get('/logout', logout);

    this.post('/create', (ctx) => { postCreate(ctx) });
    this.post('/edit/:id', (ctx) => { postEdit(ctx) });

    this.post('/register', (ctx) => { postRegister(ctx) });
    this.post('/login', (ctx) => { postLogin(ctx) });
});

app.run();