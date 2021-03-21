import articleArgs from './article-database.js';

const articleDiv = document
    .querySelector('#articles');

const articleTemplate = document
    .querySelector('#article-template').innerHTML;
const createArticle = Handlebars.compile(articleTemplate);

window
    .addEventListener('load', showAllCurrentArticle);


function showAllCurrentArticle() {
    articleDiv.innerHTML = articleArgs
        .map(ar => createArticle(ar)).join('');
}