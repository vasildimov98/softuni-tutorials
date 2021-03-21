function getArticleGenerator(articles) {
    let buttonElement = document
        .querySelector('button');
    let contentElement = document
        .querySelector('#content');

    function showNext() {
        if (articles.length != 0) {
            let currArticleText = articles.shift();

            let newArticle = document
                .createElement('article');

            newArticle.textContent = currArticleText;
            contentElement.appendChild(newArticle);
        }
    }

    return showNext;
}
