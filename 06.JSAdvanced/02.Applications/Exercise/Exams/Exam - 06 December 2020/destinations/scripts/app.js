import { destinationDashboard, homePage } from './controllers/home.js';
import { loginUser, logout, postLogin, postRegister, registerUser } from './controllers/user.js';
import { getUserData, removeNotification } from './utils.js';
import { createPage, deleteDest, detailPage, editPage, postCreate, postEdit } from './controllers/destinations.js';

document
    .querySelector('div')
    .addEventListener('click', removeNotification);

$(document)
    .ajaxSend(() => {
        document.querySelector('.loadingBox').style.display = 'block';
    });

$(document)
    .ajaxComplete(() => {
        document.querySelector('.loadingBox').style.display = 'none';
    });

const app = Sammy('#container', function() {
    this.use('Handlebars', 'hbs');

    this.userData = getUserData();

    this.get('/', homePage);
    this.get('/home', homePage);

    this.get('/register', registerUser);
    this.get('/login', loginUser);
    this.get('/logout', logout);

    this.get('/create', createPage);
    this.get('/details/:id', detailPage);
    this.get('/edit/:id', editPage);
    this.get('/destinations', destinationDashboard);

    this.get('/delete/:id', deleteDest);

    this.post('/create', (ctx) => { postCreate(ctx) });
    this.post('/edit/:id', (ctx) => { postEdit(ctx) });

    this.post('/register', (ctx) => { postRegister(ctx) });
    this.post('/login', (ctx) => { postLogin(ctx) });
});

app.run();