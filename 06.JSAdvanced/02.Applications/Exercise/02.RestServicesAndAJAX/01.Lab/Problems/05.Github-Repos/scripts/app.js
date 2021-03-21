function loadRepos() {
	const HTTP_REQUEST = new XMLHttpRequest();
	const REPOS_DIV = document
		.querySelector('#repos');
	const USERNAME_INPUT = document
		.querySelector('#username');

	HTTP_REQUEST.addEventListener('readystatechange', addRepositories);

	function addRepositories() {
		if (this.readyState == 4
			&& this.status == 200) {
			let responseTextArr = JSON.parse(this.responseText);

			console.log(responseTextArr[0].full_name);
			console.log(responseTextArr[0].html_url);
			REPOS_DIV.innerHTML = responseTextArr
				.map(repo => `<li><a href="${repo.html_url}" target="_blank">${repo.full_name}</a></li>`).join('');
		}
	}

	let url = `https://api.github.com/users/${USERNAME_INPUT.value}/repos`;
	HTTP_REQUEST.open('GET', url);
	HTTP_REQUEST.send();
}