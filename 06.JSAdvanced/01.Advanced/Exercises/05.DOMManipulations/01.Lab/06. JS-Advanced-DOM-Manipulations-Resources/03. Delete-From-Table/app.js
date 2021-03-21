function deleteByEmail() {
    let textElement = document.querySelector('input[name="email"]');

    let emails = Array
        .from(document
            .querySelector('table#customers > tbody')
            .childNodes)
        .filter((e) => e.tagName === 'TR');

    let emailMatched = emails
        .find(e => e.innerText
            .includes(textElement.value));

    let resultElement = document
        .getElementById('result');
    if (emailMatched) {
        emailMatched.remove();

        resultElement.innerHTML = 'Deleted.';
    } else {
        resultElement.innerHTML = 'Not found.';
    }
}