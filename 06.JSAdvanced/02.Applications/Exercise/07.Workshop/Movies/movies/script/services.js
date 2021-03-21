export default {
    async login(email, password) {
        const res = await fetch(`https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=${apiKey}`, {
            method: 'POST',
            headers: {
                ['Content-Type']: 'application/json'
            },
            body: JSON.stringify({
                email,
                password,
            })
        });

        const data = await res.json();

        if (data.error) {
            errorHandler({ message: data.error.message });
            return;
        }

        return data;
    },
    async register(email, password, repeatPassword) {
        if (password != repeatPassword) {
            errorHandler({ message: 'Both password should match!' });
            return;
        }

        const res = await fetch(`https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=${apiKey}`, {
            method: 'POST',
            headers: {
                ['Content-Type']: 'application/json'
            },
            body: JSON.stringify({
                email,
                password,
            })
        });

        const data = await res.json();

        if (data.error) {
            errorHandler({ message: data.error.message });
            return;
        }

        return data;
    },
    async addMovie(name, description, imageUrl) {
        if (!name ||
            !description ||
            !imageUrl) {
            errorHandler({ message: 'INVALID INPUT!' });
            return;
        }

        const { email } = JSON.parse(localStorage.getItem('userInfo'));
        const res = await fetch('https://movies-30890.firebaseio.com/movies.json', {
            method: 'POST',
            body: JSON.stringify({
                name,
                description,
                imageUrl,
                creator: email,
                ['people-liked']: [email],
            })
        });

        const data = await res.json();

        return data;
    },
    async getAllMovies() {
        const data = await (await fetch('https://movies-30890.firebaseio.com/movies.json')).json();

        if (!data) return;

        const movies = Object
            .keys(data)
            .map(id => Object.assign({ id }, data[id]));

        return movies;
    },
    async getMovieById(movieId) {
        const data = await (await fetch(`https://movies-30890.firebaseio.com/movies/${movieId}.json`)).json();

        data['movieId'] = movieId;
        return data;
    },
    async editMovieById(movieId, params) {
        const patchBody = {};
        Object
            .keys(params)
            .filter(p => params[p] != '')
            .forEach(p => Object.assign(patchBody, {
                [p]: params[p]
            }));

        const data = await (await fetch(`https://movies-30890.firebaseio.com/movies/${movieId}.json`, {
            method: 'PATCH',
            body: JSON.stringify(patchBody)
        })).json();

        return data;
    },
    async deleteMovieById(movieId) {
        const data = await (await fetch(`https://movies-30890.firebaseio.com/movies/${movieId}.json`, {
            method: 'DELETE',
        })).json();

        return data;
    }
};