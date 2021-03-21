function solve() {
   //    //You should be able to add new products to the inventory.
   // Each product have name, quantity and price. When you click the [Add] button, a new list item should be added to the Available Products.
   // Find AddBtn
   let addBtn = document
      .querySelector('#add-new button');

   // Find input section
   let [nameInput,
      quantityInput,
      priceInput] = document
         .querySelectorAll('#add-new input');

   // Find section where to put added products
   let listOfProducts = document
      .querySelector('#products ul');

   // Find filterBtn and filter input;
   let filterBtn = document
      .querySelector('.filter button');
   let filterInput = document
      .querySelector('#filter');

   //Find totalPriceText and Initialize totalPrice;
   let totalPrice = 0;
   let totalPriceText = document
      .querySelectorAll('h1')[1];

   // Find myProducts section and buyBtn
   let myProductsList = document
      .querySelector('#myProducts ul');
   document
      .querySelector('#myProducts button')
      .addEventListener('click', buyAllProducts);

   // add event to addBTn
   addBtn
      .addEventListener('click', addProduct);

   // Add Event Function to filter products;
   filterBtn
      .addEventListener('click', filterProducts);

   function buyAllProducts() {
      Array
         .from(myProductsList
            .children)
         .forEach(p => p.remove());

      totalPriceText.textContent = 'Total Price: 0.00';
   }

   // Make the function to work
   function filterProducts() {
      let filter = filterInput
         .value
         .toLowerCase();

      if (!filter) {
         return;
      }

      Array
         .from(listOfProducts
            .children)
         .filter(pr => {
            let span = pr
               .querySelector('span');

            let name = span
               .textContent
               .toLowerCase();

            return !name.includes(filter);
         }).map(pr => {
            _addAttRibute(pr, {
               name: 'style',
               value: 'display: none',
            });
         });
   }

   // create fuction to add products
   function addProduct(e) {
      e.preventDefault();

      let name = nameInput.value;
      let quantity = Number(quantityInput.value ? quantityInput.value : 'NaN'); // it could have an extrion to be intiger;
      let price = Number(priceInput.value ? priceInput.value : 'NaN');

      // validate input;
      if (!name
         || isNaN(quantity)
         || isNaN(price)) {
         return;
      }

      // CreateElement
      let newProduct = createNewProduct(name,
         quantity,
         price);

      // append element to section
      _addValue(listOfProducts,
         [newProduct]);
      // Clear input
      nameInput.value = '';
      quantityInput.value = '';
      priceInput.value = '';
   }

   function createNewProduct(name, quantity, price) {
      let liElement = _createElement('li');

      let spanElement = _createElement('span');
      _addValue(spanElement, [name]);

      let strongQunatityElement =
         _createElement('STRONG');
      _addValue(strongQunatityElement,
         [`Available: ${quantity}`]);

      let productInfoDiv = _createElement('div');

      let priceStrong = _createElement('STRONG');
      _addValue(priceStrong, [price.toFixed(2)]);

      let addToClinetListBtn = _createElement('button');
      _addValue(addToClinetListBtn, ['Add to Client\'s List']);
      // add Event;
      addToClinetListBtn
         .addEventListener('click', addProductToMyProduct);

      _addValue(productInfoDiv, [priceStrong, addToClinetListBtn]);
      _addValue(liElement, [
         spanElement,
         strongQunatityElement,
         productInfoDiv,
      ]);

      return liElement;
   }

   function addProductToMyProduct(e) {
      //Select product
      let product = e
         .target
         .parentElement
         .parentElement;

      // Find count
      let name = product
         .querySelector('span')
         .textContent;
      let availableProduct = product
         .children[1];
      let price = Number(product
         .querySelector('div strong')
         .textContent);

      let availableProductText = availableProduct
         .textContent;

      let twoPointsIndex = availableProductText
         .indexOf(':');

      let countOfProducts = Number(availableProductText
         .substring(twoPointsIndex + 2));

      countOfProducts--;

      if (!countOfProducts) {
         product
            .remove();
      } else {
         availableProduct
            .textContent = `Available: ${countOfProducts}`;
      }

      totalPrice += price;


      totalPriceText.textContent = `Total Price: ${totalPrice.toFixed(2)}`;

      let newMyProduct = _createElement('li');
      let newStrong = _createElement('STRONG');
      _addValue(newStrong, [price.toFixed(2)]);
      _addValue(newMyProduct, [name, newStrong]);
      _addValue(myProductsList, [newMyProduct]);
   }

   function _createElement(type) {
      let element = document
         .createElement(type);

      return element;
   }

   function _addAttRibute(element, { name, value }) {
      element
         .setAttribute(name, value);
   }

   function _addValue(element, valueArr) {
      valueArr
         .forEach(value => {
            if (typeof value == 'string'
               || typeof value == 'number') {
               let textNode = document
                  .createTextNode(value);

               value = textNode;
            }


            element
               .appendChild(value);
         });
   }
}