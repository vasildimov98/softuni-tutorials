export function setUserData(data) {
    if (data)
        sessionStorage.setItem('auth', JSON.stringify(data));
}

export function getUserData() {
    const auth = sessionStorage.getItem('auth');
    if (auth !== null) return JSON.parse(auth);
    else return null;
}

export function getUserLocalId() {
    const auth = sessionStorage.getItem('auth');
    if (auth !== null) return JSON.parse(auth).localId;
    else return null;
}

export function convertObjectToArray(object) {
    return object == null ? [] : Object.entries(object).map(([k, v]) => Object.assign({ _id: k }, v));
}

export async function loadPartials(ctx) {
    ctx.partials = {
        header: await ctx.load('/templates/common/header.hbs')
    };
}

export function checkForCreators(posts) {
    for (const post of posts) {
        if (post._ownerId == getUserLocalId())
            post.isCreator = true;
        else post.isCreator = false;
    }
}

export function notify(message, selector) {
    const div = document.querySelector(selector);
    div.textContent = message;
    div.parentElement.style.display = 'block';

    setTimeout(() => {
        div.parentElement.style.display = 'none';
    }, 5000);
}