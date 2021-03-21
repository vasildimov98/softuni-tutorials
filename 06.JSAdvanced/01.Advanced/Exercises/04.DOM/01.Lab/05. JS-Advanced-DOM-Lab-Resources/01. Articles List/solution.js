function createArticle() {
	let title = document.getElementById('createTitle');
	let content = document.getElementById('createContent');

	let articles = document.getElementById('articles');

	let newArticle = document.createElement('article');
	let h3 = document.createElement('h3');
	let p = document.createElement('p');

	if (title.value !== '' && content.value !== '') {
		h3.innerHTML += title.value;
		p.innerHTML += content.value;

		newArticle.appendChild(h3);
		newArticle.appendChild(p);

		articles.appendChild(newArticle);
	}
	
	title.value = '';
	content.value = '';
}