function solve() {
   let tableElement = document
      .querySelector('.minimalistBlack');
   let prevElement;
   tableElement.addEventListener('click', changeColor);

   function changeColor(e) {
      let tagName = e.target.parentElement.parentElement.tagName;
      if (tagName == 'TBODY') {
         let currTarget = e.target.parentElement;

         let style = currTarget.getAttribute('style');
         if (style) {
            currTarget.removeAttribute('style');
         } else {
            if (prevElement
               && prevElement !== currTarget) {
               prevElement.removeAttribute('style');
            }
            currTarget.setAttribute('style', 'background-color: #413f5e');
            prevElement = currTarget
         }
      }
   }
}
