function willYouMarryMe(answer) {
    if (answer == 'yes') return true;
    else return false;
}

const ANSWER = 'yes';

let engagementPromise = new Promise((resolve, reject) => {
    setTimeout(function() {
        resolve('Yes')
    }, 2000)
});

engagementPromise
    .then((resolve) => {
        console.log(`Then print: ${resolve}`);
    })
    .catch((reject) => {
        console.log(`Else catch print: ${reject}`);
    });