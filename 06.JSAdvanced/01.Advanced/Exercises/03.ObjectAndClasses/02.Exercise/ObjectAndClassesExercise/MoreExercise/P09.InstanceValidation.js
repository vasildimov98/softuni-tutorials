class CheckingAccount {
    constructor(clientId, email, firstName, lastName) {
        this.clientId = clientId;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
    }

    get clientId() {
        return this.value;
    }

    set clientId(value) {
        if (!value.match(/^\d{6}$/g)) {
            throw new TypeError('Client ID must be a 6-digit number');
        }

        this.value = value;
    }

    get email() {
        return this.value;
    }

    set email(value) {
        if (!value.match(/[a-z0-9]+[@][a-z.]+/i)) {
            throw new TypeError('Invalid e-mail');
        }

        this.value = value;
    }

    get firstName() {
        return this.value;
    }

    set firstName(value) {
        if (!(value.length >= 3 && value.length <= 20)) {
            throw new TypeError(`First name must be between 3 and 20 characters long`);
        }

        if (!value.match(/[A-z]+/i)) {
            throw new TypeError(`First name must contain only Latin characters`);
        }

        this.value = value;
    }

    get lastName() {
        return this.value;
    }

    set lastName(value) {
        if (!(value.length >= 3 && value.length <= 20)) {
            throw new TypeError(`Last name must be between 3 and 20 characters long`);
        }

        if (!value.match(/^[A-z]+$/i)) {
            throw new TypeError(`Last name must contain only Latin characters`);
        }

        this.value = value;
    }
}

// let acc = new CheckingAccount('1314', 'ivan@some.com', 'Ivan', 'Petrov');
// let acc = new CheckingAccount('131455', 'ivan@', 'Ivan', 'Petrov');
// let acc = new CheckingAccount('131455', 'ivan@some.com', 'I', 'Petrov');
let acc = new CheckingAccount('131455', 'ivan@some.com', 'Петкан', 'Petrov');