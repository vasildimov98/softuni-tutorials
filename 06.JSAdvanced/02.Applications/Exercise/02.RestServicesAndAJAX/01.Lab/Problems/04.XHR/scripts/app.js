function loadRepos() {
   const HTTP_REQUEST = new XMLHttpRequest();
   const URL = `https://api.github.com/users/testnakov/repos`;
   const RES_ELEMENT = document
      .querySelector('#res');

   HTTP_REQUEST.addEventListener('readystatechange', addRepositories);

   function addRepositories() {
      if (this.readyState == 4
         && this.status == 200) {
         let responseText = this.responseText;

         RES_ELEMENT.innerHTML =  responseText;
      }
   }

   HTTP_REQUEST.open('GET', URL);
   HTTP_REQUEST.send();
}