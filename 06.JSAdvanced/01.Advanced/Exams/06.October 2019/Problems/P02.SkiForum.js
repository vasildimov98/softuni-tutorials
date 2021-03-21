class Forum {
    constructor() {
        this._users = [];
        this._questions = [];
        this._id = 1;
    }

    register(username,
        password,
        repeatPassword,
        email) {
        if (!username
            || !password
            || !repeatPassword
            || !email) {
            throw new Error('Input can not be empty');
        }

        if (password != repeatPassword) {
            throw new Error('Passwords do not match');
        }

        let user = this
            ._users
            .find(u => u.username == username
                && u.password == password);

        if (user) {
            throw new Error('This user already exists!');
        }

        user = {
            username,
            email,
            password,
        };

        this._users.push(user);

        return `${username} with ${email} was registered successfully!`;
    }

    login(username, password) {
        let user = this._validateUser(username, password);

        user.isLogin = true;

        return 'Hello! You have logged in successfully';
    }

    logout(username, password) {
        let user = this._validateUser(username, password);

        user.isLogin = false;

        return 'You have logged out successfully';
    }

    postQuestion(username, question) {
        let user = this._validateUserIsLockedIn(username,
            'You should be logged in to post questions');

        if (!question) {
            throw new Error('Invalid question');
        }


        this._questions.push({ id: this._id++, username: user.username, answers: [], question });

        return 'Your question has been posted successfully';
    }

    postAnswer(username, questionId, answer) {
        let user = this._validateUserIsLockedIn(username,
            'You should be logged in to post answers');

        if (!answer) {
            throw new Error('Invalid answer');
        }

        let question = this
            ._questions
            .find(q => q.id == questionId);

        if (!question) {
            throw new Error('There is no such question');
        }

        question.answers.push({
            username: user.username,
            answer
        });

        return 'Your answer has been posted successfully';
    }

    showQuestions() {
        return this
            ._questions
            .reduce((r, q) => {
                r.push(`Question ${q.id} by ${q.username}: ${q.question}`);

                q
                    .answers
                    .forEach(a => {
                        r.push(`---${a.username}: ${a.answer}`)
                    });

                return r;
            }, [])
            .join('\n');
    }

    _validateUser(username, password) {
        let user = this
            ._users
            .find(u => u.username == username
                && u.password == password);

        if (!user) {
            throw new Error('There is no such user');
        }

        return user;
    }

    _validateUserIsLockedIn(username, msg) {
        let user = this
            ._users
            .find(u => u.username == username);

        if (!user
            || !user.isLogin) {
            throw new Error(msg);
        }

        return user;
    }
}

//Sample code usage
// let forum = new Forum();

// forum.register('Michael', '123', '123', 'michael@abv.bg');
// forum.register('Stoyan', '123ab7', '123ab7', 'some@gmail@.com');
// forum.login('Michael', '123');
// forum.login('Stoyan', '123ab7');

// forum.postQuestion('Michael', "Can I rent a snowboard from your shop?");
// forum.postAnswer('Stoyan', 1, "Yes, I have rented one last year.");
// forum.postQuestion('Stoyan', "How long are supposed to be the ski for my daughter?");
// forum.postAnswer('Michael', 2, "How old is she?");
// forum.postAnswer('Michael', 2, "Tell us how tall she is.");

// console.log(forum.showQuestions());

// Corresponding output
// Question 1 by Michael: Can I rent a snowboard from your shop?
// ---Stoyan: Yes, I have rented one last year.
// Question 2 by Stoyan: How long are supposed to be the ski for my daughter?
// ---Michael: How old is she?
// ---Michael: Tell us how tall she is.

//Sample code usage
let forum = new Forum();

forum.register('Jonny', '12345', '12345', 'jonny@abv.bg');
forum.register('Peter', '123ab7', '123ab7', 'peter@gmail@.com');
forum.login('Jonny', '12345');
forum.login('Peter', '123ab7');

forum.postQuestion('Jonny', "Do I need glasses for skiing?");
forum.postAnswer('Peter', 1, "Yes, I have rented one last year.");
forum.postAnswer('Jonny', 1, "What was your budget");
forum.postAnswer('Peter', 1, "$50");
forum.postAnswer('Jonny', 1, "Thank you :)");

console.log(forum.showQuestions());
// Corresponding output
// Question 1 by Jonny: Do I need glasses for skiing?
// ---Peter: Yes, I have rented one last year.
// ---Jonny: What was your budget
// ---Peter: $50
// ---Jonny: Thank you :)
