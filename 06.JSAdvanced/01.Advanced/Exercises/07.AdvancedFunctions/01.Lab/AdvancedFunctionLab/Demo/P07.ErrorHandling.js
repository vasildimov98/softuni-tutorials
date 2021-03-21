function errorFunction() {
    throw new TypeError('sth is incorect');
}

try {
    errorFunction();
} catch (error) {
    console.log(error.message);
}