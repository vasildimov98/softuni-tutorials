const requests = {
    async registerUser(email, password, rePassword) {
        if (!email ||
            password.length < 6 ||
            password != rePassword) return;

        const data = await (await fetch(`https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=${apiKey}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ email, password }),
        })).json();

        if (data.error) return;

        return data;
    },
    async loginUser(email, password) {
        if (!email ||
            password.length < 6) return;

        const data = await (await fetch(`https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=${apiKey}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ email, password }),
        })).json();

        if (data.error) return;

        return data;
    },
    async createShoe(postBody) {
        var keys = Object.keys(postBody).filter(k => postBody[k]);

        if (keys.length != 5) return;
        const { email } = JSON.parse(localStorage.getItem('userInfo'));
        postBody['creator'] = email;
        postBody['people-bought-it'] = [email];

        postBody = JSON.stringify(postBody);

        const data = await (await fetch(`https://shoes-1425d.firebaseio.com/shoes.json`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: postBody,
        })).json();

        if (data.error) return;

        return data;
    },
    async getAllShoes() {
        const data = await (await fetch('https://shoes-1425d.firebaseio.com/shoes.json')).json()

        if (!data) return;

        return Object
            .keys(data)
            .map(id => ({ id, ...data[id] }));
    },
    async getShoeDetailsById(id) {
        const data = await (await fetch(`https://shoes-1425d.firebaseio.com/shoes/${id}.json`)).json()
        if (!data) return;
        data['id'] = id;
        return data;
    },
    async editShoeDetailsById(id, params) {
        let patchBody = {};
        Object
            .keys(params)
            .filter(k => params[k])
            .forEach(k => patchBody[k] = params[k]);

        patchBody = JSON.stringify(patchBody);

        const data = await (await fetch(`https://shoes-1425d.firebaseio.com/shoes/${id}.json`, {
            method: 'PATCH',
            body: patchBody
        })).json()

        if (!data) return;

        return data;
    },
    async deleteShoeById(id, params) {
        return await (await fetch(`https://shoes-1425d.firebaseio.com/shoes/${id}.json`, {
            method: 'DELETE'
        })).json()
    },
}