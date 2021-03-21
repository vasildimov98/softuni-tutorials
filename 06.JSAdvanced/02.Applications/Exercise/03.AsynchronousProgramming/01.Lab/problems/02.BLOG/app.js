function attachEvents() {
    const BASE_URL = 'https://blog-apps-c12bf.firebaseio.com/posts'
    const LOAD_BTN = document
        .querySelector('#btnLoadPosts');
    const POSTS_SECTION = document
        .querySelector('#posts');
    const VIEW_BTN = document
        .querySelector('#btnViewPost');
    const POST_TITLE_ELEMENT = document
        .querySelector('#post-title')
    const POST_BODY_ELEMENT = document
        .querySelector('#post-body');
    const POST_COMMENTS_ELEMENT = document
        .querySelector('#post-comments');

    LOAD_BTN.addEventListener('click', makeGetRequestToPosts);
    VIEW_BTN.addEventListener('click', makeGetRequestToPostId);

    function makeGetRequestToPostId() {
        let postId = POSTS_SECTION.value;

        fetch(`${BASE_URL}/${postId}.json`)
            .then(response => response.json())
            .then(data => {
                POST_TITLE_ELEMENT.textContent = data.title;
                POST_BODY_ELEMENT.innerHTML = `<p>${data.body}</p>`;
                let comments = data.comments;

                if (comments != undefined) {
                    comments = comments
                        .map(c => {
                            return `<li id="${c.id}">${c.text}</li>`
                        }).join('');
                    POST_COMMENTS_ELEMENT.innerHTML = comments;

                } else POST_COMMENTS_ELEMENT.innerHTML = 'No comments';

            });
    }

    function makeGetRequestToPosts() {
        fetch(`${BASE_URL}.json`)
            .then(response => response.json())
            .then(data => {
                Object
                    .keys(data)
                    .forEach(key => {
                        var title = data[key].title;

                        let option = document
                            .createElement('option');

                        option.setAttribute('value', key);

                        option.textContent = title;

                        POSTS_SECTION.appendChild(option);
                    });
            });
    }
}

attachEvents();