import { getUserData, setUserData, getUserLocalId, convertObjectToArray } from "./utils.js";

const apiKey = 'AIzaSyAhcK1uWqEYN9egxN7_eYzzfZDXSOFpwmo';
const databaseUrl = 'https://myblog-8e2ac-default-rtdb.firebaseio.com/';

const endpoints = {
    LOGIN: 'https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=',
    REGISTER: 'https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=',
    POSTS: 'posts',
    POST_BY_ID: 'posts/',
};

function host(url) {
    var hostUrl = databaseUrl + url + '.json';
    var auth = getUserData();
    if (auth !== null) hostUrl += '?auth=' + auth.idToken;
    return hostUrl;
}

async function request(method, url, body) {
    let options = {
        method,
    };

    if (body) {
        Object.assign(options, {
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(body)
        });
    }
    let response = await fetch(url, options);

    let data = await response.json();

    if (data && data.hasOwnProperty('error')) {
        const message = data.error.message;
        throw new Error(message);
    }

    return data;
}

function get(url) {
    return request("GET", url);
}

function post(url, body) {
    return request("POST", url, body);
}

function patch(url, body) {
    return request('PATCH', url, body);
}

function del(url) {
    return request("DELETE", url);
}

export async function login(email, password) {
    let data = await post(endpoints.LOGIN + apiKey, {
        email,
        password,
        returnSecureToken: true,
    });

    setUserData(data);

    return data;
}

export async function register(email, password) {
    let data = await post(endpoints.REGISTER + apiKey, {
        email,
        password,
        returnSecureToken: true,
    });

    return data;
}

export async function create(postBody) {
    const body = Object.assign({ _ownerId: getUserLocalId() }, postBody);
    return post(host(endpoints.POSTS), body);
}

export async function getAll() {
    const data = await get(host(endpoints.POSTS));
    const posts = convertObjectToArray(data);
    return posts;
}

export async function getById(id) {
    const posts = await get(host(endpoints.POST_BY_ID + id));
    if (posts) posts._id = id;
    return posts;
}

export async function editById(id, body) {
    return patch(host(endpoints.POST_BY_ID + id), body);
}

export async function deleteById(id) {
    return del(host(endpoints.POST_BY_ID + id));
}