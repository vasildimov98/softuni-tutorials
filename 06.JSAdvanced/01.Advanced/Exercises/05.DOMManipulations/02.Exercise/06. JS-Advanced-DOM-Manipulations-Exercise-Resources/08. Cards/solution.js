function solve() {
   let sectionWithCartsElement = document
      .querySelector('.cards');
   let resultElement = document
      .querySelector('#result');
   let historyElement = document
      .querySelector('#history');
   let topCardResult = resultElement
      .children[0];
   let bottomCardResult = resultElement.children[2];
   let firstPlayerIsSelected = false;
   let selectedTopCard;
   let secondPlayerIsSelected = false;
   let selectedBottomCard;

   sectionWithCartsElement
      .addEventListener('click', getCard);

   function getCard(e) {
      let target = e.target;
      let targetParent = e.target.parentElement;

      if (targetParent.id == 'player1Div'
         && !firstPlayerIsSelected) {
         selectedTopCard = target;
         selectedTopCard.src = "images/whiteCard.jpg"
         let textNode = document.createTextNode(target.name);
         topCardResult
            .appendChild(textNode);

         firstPlayerIsSelected = true;
      }

      if (targetParent.id == 'player2Div' && !secondPlayerIsSelected) {
         selectedBottomCard = target;
         selectedBottomCard.src = "images/whiteCard.jpg"
         let textNode = document.createTextNode(target.name);
         bottomCardResult.appendChild(textNode);

         secondPlayerIsSelected = true;
      }

      if (firstPlayerIsSelected
         && secondPlayerIsSelected) {
         firstPlayerIsSelected = false;
         secondPlayerIsSelected = false;
         let leftNumber = Number(topCardResult
            .textContent);
         let rightNumber = Number(bottomCardResult
            .textContent);

         let max = Math.max(leftNumber, rightNumber);

         if (max == leftNumber) {
            selectedTopCard.style.border = '2px solid green';
            selectedBottomCard.style.border = '2px solid red';
         } else {
            selectedTopCard.style.border = '2px solid red';
            selectedBottomCard.style.border = '2px solid green';
         }

         let history = `[${topCardResult.textContent
            } vs ${bottomCardResult.textContent}] `;
         topCardResult.textContent = '';
         bottomCardResult.textContent = '';
         historyElement.textContent += `${history}`;
      }
   }
}