import { login, register } from "../data.js";
import { getUserData, loadPartials, notify } from "../utils.js";

export async function loginUser() {
    await loadPartials(this);
    this.partial('/templates/user/login.hbs');
}

export function logout() {
    sessionStorage.removeItem('auth');
    this.app.userData = getUserData();
    notify('Successfully logout!', '#successBox');
    this.redirect('/home');
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
            await register(email, password);
            notify('Successfully register!', '#successBox');
            ctx.redirect('/login');
        }
    } catch (error) {
        notify(error.message, '#errorBox');
    }
}

export async function postLogin(ctx) {
    const { email, password } = ctx.params;

    try {
        if (!email || !password)
            throw new Error('All fields are required!');
        else {
            ctx.app.userData = await login(email, password);
            notify('Successfully logged in!', '#successBox');
            ctx.redirect('/home');
        }
    } catch (error) {
        notify(error.message, '#errorBox');
    }
}