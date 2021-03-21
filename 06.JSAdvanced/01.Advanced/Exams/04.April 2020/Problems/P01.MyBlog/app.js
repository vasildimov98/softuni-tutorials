function solve() {
   // 1. Select [Create] button
   let createBtn = document
      .querySelector('button[class="btn create"]');

   // 2. Add Event to the button
   createBtn
      .addEventListener('click', appendArticle);
   // 3. Select the input from article;
   let authorInput = document
      .querySelector('#creator');
   let titleInput = document
      .querySelector('#title');
   let categoryInput = document
      .querySelector('#category');
   let contentInput = document
      .querySelector('#content');

   // 9.1 Select the archive section 
   let archiveLists = document
      .querySelector('section[class="archive-section"] ul');

   // 10. Select the article content section
   let articleContent = document
      .querySelector('div[class="site-content"] main > section');

   function appendArticle(e) {
      e.preventDefault();

      // 4. When Event is called validate the input
      let creator = authorInput.value;
      let title = titleInput.value;
      let category = categoryInput.value;
      let content = contentInput.value;

      if (!creator
         || !title
         || !category
         || !content) {
         return;
      }

      // 5. If Input is valid than create a new element
      let newArticle = createArticle(creator,
         title,
         category,
         content);

      // 10.1. Add new Element to site content
      articleContent
         .appendChild(newArticle);


      // 4.1 Clear input
      // authorInput.value = '';
      // titleInput.value = '';
      // categoryInput.value = '';
      // contentInput.value = '';
   }

   function createArticle(creator, title, category, content) {
      let articleEl = _createElement('article');
      let titleEl = _createElement('h1', title);
      let categoryP = _createElement('p');
      let strongCtg = _createElement('STRONG', category);
      _addValue(categoryP, ['Category: ', strongCtg]);
      let creatorP = _createElement('p');
      let strongCrt = _createElement('STRONG', creator);
      _addValue(creatorP, ['Creator: ', strongCrt]);
      let contentP = _createElement('p', content);
      let buttonsDiv = _createElement('div', '', {
         name: 'class',
         value: 'buttons',
      });
      let deleteBtn = _createElement('button', 'Delete', {
         name: 'class',
         value: 'btn delete',
      });

      // 6. Add Event to [Delete]
      // 7. Create a function to delete item when event is called
      deleteBtn.addEventListener('click', deleteArticle);

      let archiveBtn = _createElement('button', 'Archive', {
         name: 'class',
         value: 'btn archive',
      });

      // 8. Add Event to [Archieve]
      // 9. Create a function to archive the element when the event is called
      archiveBtn.addEventListener('click', archiveArticle);

      _addValue(buttonsDiv, [
         deleteBtn,
         archiveBtn,
      ]);

      _addValue(articleEl, [
         titleEl,
         categoryP,
         creatorP,
         contentP,
         buttonsDiv,
      ]);

      return articleEl;
   }

   function archiveArticle(e) {
      let articleEl = e
         .target
         .parentElement
         .parentElement;

      let title = articleEl
         .querySelector('h1')
         .innerHTML;

      let newArchiveList = _createElement('li', title);

      archiveLists
         .appendChild(newArchiveList);

      let sortedArchiveList = Array
         .from(archiveLists
            .children)
         .sort((li1, li2) => {
            return (li1.innerHTML).localeCompare(li2.innerHTML);
         });

      while (archiveLists.firstChild) {
         archiveLists.removeChild(archiveLists.firstChild);
      }

      sortedArchiveList
         .forEach(li => {
            archiveLists.appendChild(li);
         });

      deleteArticle(e);
   }

   function deleteArticle(e) {
      e
         .target
         .parentElement
         .parentElement
         .remove();
   }

   function _addValue(element, argsArr) {
      argsArr.forEach(arg => {
         if (typeof arg == 'string') {
            let textNode = document
               .createTextNode(arg);

            arg = textNode;
         }

         element.appendChild(arg);
      });
   }

   function _createElement(type, text, attr) {
      let element = document
         .createElement(type);

      if (text) {
         let textNode = document
            .createTextNode(text);

         element
            .appendChild(textNode);
      }

      if (attr) {
         let { name, value } = attr;
         if (name == 'class') {
            element.classList.add(...value
               .split(' '));
         } else {
            element.setAttribute(name, value);
         }
      }

      return element;
   }
}

// function solve() {
//    let buttonCreate = document.querySelector('.btn.create');
//    buttonCreate.addEventListener('click', createArticle)

//    function createArticle(e) {
//       e.preventDefault();
//       let author = document.getElementById('creator');
//       let title = document.getElementById('title');
//       let category = document.getElementById('category');
//       let content = document.getElementById('content');

//       if(areTheFieldsFilled(author, title, category, content)){
//          generateArticleStructure(author, title, category, content);
//       }

//    }

//    function remove(e) {
//       e.target.parentElement.parentElement.remove();
//    }

//    function archive(e) {
//       let titleArticle = e.target.parentElement.parentElement.querySelector('h1').textContent;

//       let titleLI = document.createElement('li');
//       titleLI.textContent = titleArticle;

//       let archiveUl = document.querySelector('.archive-section ul');
//       archiveUl.appendChild(titleLI);

//       let sortedLi = Array.from(archiveUl.getElementsByTagName('li'))
//          .sort((a, b) => (a.innerHTML).localeCompare(b.innerHTML));

//       while (archiveUl.firstChild) {
//          archiveUl.removeChild(archiveUl.firstChild);
//       }

//       for (const element of sortedLi) {
//          archiveUl.appendChild(element);
//       }

//       remove(e);
//    }

//    function generateArticleStructure(author, title, category, content) {
//       let newArticle = document.createElement('article');
//       let newTitle = document.createElement('h1');
//       newTitle.textContent = title.value;
//       newArticle.appendChild(newTitle);

//       let newPcategory = document.createElement('p');
//       newPcategory.innerHTML += 'Category:';
//       let newStrongCategory = document.createElement('strong');
//       newStrongCategory.textContent = category.value;
//       newPcategory.appendChild(newStrongCategory);
//       newArticle.appendChild(newPcategory);

//       let newPauthor = document.createElement('p');
//       newPauthor.innerHTML += 'Creator:';
//       let newStrongAuthor = document.createElement('strong');
//       newStrongAuthor.textContent = author.value;
//       newPauthor.appendChild(newStrongAuthor);
//       newArticle.appendChild(newPauthor);

//       let newPcontent = document.createElement('p');
//       newPcontent.textContent = content.value;
//       newArticle.appendChild(newPcontent);

//       let newButtonsDiv = document.createElement('div');
//       newButtonsDiv.classList.add('buttons');

//       let newDelButton = document.createElement('button');
//       newDelButton.classList.add('btn', 'delete');
//       newDelButton.textContent = 'Delete';
//       newDelButton.addEventListener('click', remove);

//       let newArchiveButton = document.createElement('button');
//       newArchiveButton.classList.add('btn', 'archive');
//       newArchiveButton.textContent = 'Archive';
//       newArchiveButton.addEventListener('click', archive);

//       newButtonsDiv.appendChild(newDelButton);
//       newButtonsDiv.appendChild(newArchiveButton);

//       newArticle.appendChild(newButtonsDiv);
//       document.querySelector('main section').appendChild(newArticle);

//    }

//    function areTheFieldsFilled(...fields) {
//       return fields.filter(f => f.value.length > 0).length === fields.length;
//    }
// }