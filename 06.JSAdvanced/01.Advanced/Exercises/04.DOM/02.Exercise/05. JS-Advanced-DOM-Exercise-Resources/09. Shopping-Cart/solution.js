function solve() {
   let productsBought = {
      'Bread': false,
      'Milk': false,
      'Tomatoes': false,
   };

   let productList = [];
   let totalPrice = 0;

   let addButtons = document
      .querySelectorAll('.add-product');
   let textArea = document.
      querySelector('textarea[rows="5"]');
   let checkoutButton = document
      .querySelector('.checkout');

   Array
      .from(addButtons)
      .map(e => {
         e.addEventListener('click', onAddProductClickEvent);
      });

   checkoutButton.addEventListener('click', onCheckoutButtonClick);

   function onAddProductClickEvent(e) {
      let product = e.target.parentElement.parentElement;

      let productName = product
         .querySelector('.product-title')
         .textContent;

      if (!productsBought[productName]) {
         productsBought[productName] = true;
         productList.push(productName);
      }

      let productPrice = Number(product
         .querySelector('.product-line-price')
         .textContent);

      totalPrice += productPrice;

      textArea.textContent += `Added ${productName} for ${productPrice.toFixed(2)} to the cart.\n`
   }

   function onCheckoutButtonClick(e) {
      textArea.textContent += `You bought ${productList.join(', ')} for ${totalPrice.toFixed(2)}.`;

      Array
         .from(document
            .querySelectorAll('button'))
         .map(b => {
            b.disabled = true;
         });
   }
}