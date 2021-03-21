function create(words) {
   let contentElement = document
      .getElementById('content');

   words.forEach(word => {
      let newDivElement = document
         .createElement('div');

      let newParagraphElement = document
         .createElement('p');
      newParagraphElement.innerHTML = word;
      newParagraphElement.style.display = 'none';

      newDivElement.appendChild(newParagraphElement);

      newDivElement.addEventListener('click', () => {
         newParagraphElement.style.display = 'block';
      })

      contentElement.appendChild(newDivElement);
   });
}