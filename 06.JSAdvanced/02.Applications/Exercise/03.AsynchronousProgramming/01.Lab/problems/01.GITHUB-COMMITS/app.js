function loadCommits() {
    const USERNAME = document
        .getElementById('username');
    const REPO = document
        .getElementById('repo');
    const COMMIT_ELEMENT = document
        .getElementById('commits');

    const GET_URL = `https://api.github.com/repos/${USERNAME.value}/${REPO.value}/commits`;

    fetch(GET_URL)
        .then(response => response.json())
        .then(collection => {
            let allMessages = collection
                .reduce((result, commitObj) => {
                    let commit = commitObj.commit;

                    let authorName = commit.author.name;
                    let commitMessage = commit.message;

                    let text = `<li>${authorName}: ${commitMessage}</li>`;

                    result.push(text);

                    return result;
                }, []);

            COMMIT_ELEMENT.innerHTML = allMessages.join('\n');
        })
        .catch(error => {
            COMMIT_ELEMENT.innerHTML = `<li>Error: ${error.status} (${error.statusText})</li>`
        });
}