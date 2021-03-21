//DON'T FORGET TO DELETE THESE'
import * as api from './data.js';
window.api = api;

const app = Sammy('#root', function() {
    this.use('Handlebars', 'hbs');

    // this.userData = getUserData();

    // this.get('/', homePage);
    // this.get('/home', homePage);

    // this.get('/login', loginUser);
    // this.get('/register', registerUser);

    // this.get('/create', createPage);
    // this.get('/details/:id', detailsPage);
    // this.get('/edit/:id', editPage);

    // this.get('/delete/:id', deleteArticle);
    // this.get('/logout', logout);

    // this.post('/create', (ctx) => { postArticle(ctx) });
    // this.post('/edit/:id', (ctx) => { postEdit(ctx) });

    // this.post('/login', (ctx) => { postLogin(ctx) });
    // this.post('/register', (ctx) => { postRegister(ctx) });
});

app.run();