const emptyPathRoute = '/';
const homePageRoute = '/home';
const registerRoute = '/register';
const loginRoute = '/login';
const logoutRoute = '/logout';
const aboutRoute = '/about';
const catalogRoute = '/catalog';
const teamRoute = '/catalog/:teamId';
const editRoute = '/edit/:teamId';
const createRoute = '/create';

const handlebarsName = 'Handlebars';
const extensionName = 'hbs';
const headerPartialName = 'header';
const footerPartialName = 'footer';
const registerPartialName = 'registerForm';
const loginPartialName = 'loginForm';
const teamPartialName = 'team';
const createPartialName = 'createForm';
const teamMemberPartialName = 'teamMember';
const teamControlPartialName = 'teamControls';
const editPartialName = 'editForm';

const styleAttr = 'style';
const showElStyle = 'display: block;';
const hideElStyle = 'display: none;';

const homePageTemplatePath = './templates/home/home.hbs';
const registerPageTemplatePath = './templates/register/registerPage.hbs';
const loginPageTemplatePath = './templates/login/loginPage.hbs';
const aboutPageTemplatePath = './templates/about/about.hbs';
const catalogPageTemplatePath = './templates/catalog/teamCatalog.hbs';
const createPageTemplatePath = './templates/create/createPage.hbs';
const detailsPageTemplatePath = './templates/catalog/details.hbs';
const editPageTemplatePath = 'templates/edit/editPage.hbs';

const headerPartialPath = './templates/common/header.hbs'
const footerPartialPath = './templates/common/footer.hbs';
const registerPartialPath = './templates/register/registerForm.hbs';
const loginPartialPath = './templates/login/loginForm.hbs';
const teamPartialPath = './templates/catalog/team.hbs';
const teamMemberPartialPath = './templates/catalog/teamMember.hbs';
const teamControlPartialPath = './templates/catalog/teamControls.hbs';
const createPartialPath = './templates/create/createForm.hbs';
const editPartialPath = './templates/edit/editForm.hbs';

const emptyDataMsg = 'Data cannot be empty. Please fill the forms with correct data!';
const diffPasswords = 'Passwords are different! Please write the same password in the repeate password field!';

const userProperty = 'userInfo';

const userAuth = firebase.auth();

const loadEvent = 'load';

const mainDivId = '#main';
const errorDivId = '#errorBox';
const infoDivId = '#infoBox';

const htmlSelectors = {
    getErrorDiv: () => document.querySelector(errorDivId),
    getInfoDiv: () => document.querySelector(infoDivId),
};

function errorHandler({ message }) {
    const errorDiv = htmlSelectors.getErrorDiv();
    errorDiv.setAttribute(styleAttr, showElStyle);
    errorDiv.innerHTML = message;
    const seconstToShowMsg = 5000;
    setTimeout(() => {
        errorDiv.setAttribute(styleAttr, hideElStyle);
    }, seconstToShowMsg);
}

function validateUserEntries(email, password, repeatPassword) {
    var message = '';

    if (!email ||
        !password ||
        repeatPassword === '') {
        message = emptyDataMsg;
        errorHandler({ message });
        return false;
    }

    if (repeatPassword == undefined) return true;

    if (password != repeatPassword) {
        message = diffPasswords;
        errorHandler({ message });
        return false;
    }

    return true;
}