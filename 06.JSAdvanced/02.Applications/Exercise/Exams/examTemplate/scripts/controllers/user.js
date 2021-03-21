import { login, register } from "../data.js";
import { getUserData, loadPartials } from "../utils.js";

export async function loginUser() {
    await loadPartials(this);
    this.partial('/templates/user/login.hbs');
}

export function logout() {
    sessionStorage.removeItem('auth');
    this.app.userData = getUserData();
    this.redirect('/login');
}

export async function registerUser() {
    await loadPartials(this);
    this.partial('/templates/user/register.hbs');
}

export async function postRegister(ctx) {
    const { email, password, repPass } = ctx.params;

    try {
        if (!email || !password || !repPass)
            throw new Error('All fields are required!');
        else if (password != repPass)
            throw new Error('Passwords should match!');
        else {
            ctx.app.userData = await register(email, password);
            ctx.redirect('/home');
        }
    } catch (error) {
        alert(error.message);
    }
}

export async function postLogin(ctx) {
    const { email, password } = ctx.params;

    try {
        if (!email || !password)
            throw new Error('All fields are required!');
        else {
            ctx.app.userData = await login(email, password);
            ctx.redirect('/home');
        }
    } catch (error) {
        alert(error.message);
    }
}