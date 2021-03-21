function willYouMarryMe() {
    let possibleAnswer = ['yes', 'no', 'i need to think about it'];

    let randomIndex = Math.floor(Math.random() * 2);

    let answer = possibleAnswer[randomIndex];

    let promise = new Promise((resolve, reject) => {
        setTimeout(() => {
            if (answer == 'yes') {
                resolve('Just married!')
                console.log(promise);
            } else if (answer == 'no') {
                reject('The wedding is off');
                console.log(promise);
            } else {
                return Promise.resolve('Yes');
            }
        }, 2000);
    });

    return promise;
}

let promise = willYouMarryMe();

console.log(promise);

promise
    .then(response => {
        if (response == 'Just married!')
            console.log(response);
        else if (response == 'yes')
            return Promise.resolve('Guests are invited');
    })
    .then(response => {
        if (response != undefined && response == 'Guests are invited')
            return Promise.resolve('Wedding is prepared')
    })
    .then(response => {
        if (response == 'Wedding is prepared')
            return Promise.resolve('Just married')
    })
    .then(response => console.log(response))
    .catch(onrejectResponse => {
        console.log(onrejectResponse);
    });

console.log(promise);