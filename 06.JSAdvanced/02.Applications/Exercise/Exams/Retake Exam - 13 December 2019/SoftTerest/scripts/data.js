import { getUserData, setUserData, getUserLocalId, convertObjectToArray } from "./utils.js";

const apiKey = 'AIzaSyAiX-gekS6yUWpqojVwMrmfiFdcmSRA0_o';
const databaseUrl = 'https://temp-3dec5-default-rtdb.firebaseio.com/';

const endpoints = {
    LOGIN: 'https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=',
    REGISTER: 'https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=',
    IDEAS: 'ideas',
    IDEAS_BY_ID: 'ideas/',
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

    setUserData(data);

    return data;
}

export async function create(ideasBody) {
    const body = Object.assign({ _ownerId: getUserLocalId() }, ideasBody);
    return post(host(endpoints.IDEAS), body);
}

export async function getAll() {
    const data = await get(host(endpoints.IDEAS));
    const IDEASs = convertObjectToArray(data);
    return IDEASs;
}

export async function getById(id) {
    const IDEAS = await get(host(endpoints.IDEAS_BY_ID + id));
    if (IDEAS) IDEAS._id = id;
    return IDEAS;
}

export async function editById(id, body) {
    return patch(host(endpoints.IDEAS_BY_ID + id), body);
}

export async function deleteById(id) {
    return del(host(endpoints.IDEAS_BY_ID + id));
}