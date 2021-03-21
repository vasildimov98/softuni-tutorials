function solve() {
   let tableBodyChildrenElements = Array
      .from(document
         .querySelectorAll('tbody > tr'));
   let inputElement = document
      .getElementById('searchField');
   let searchBtn = document
      .getElementById('searchBtn');

   searchBtn.addEventListener('click', searchForElement);

   function searchForElement() {
      let searchedValue = inputElement.value.toUpperCase();
      let regex = new RegExp(searchedValue, 'gim');
      tableBodyChildrenElements
         .map(e => {
            e.classList.remove('select');
            
            if (e.innerHTML.match(regex) !== null) {
               e.className = 'select';
            }
         });

      inputElement.value = '';
   }
}