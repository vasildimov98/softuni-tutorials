function solve() {
   let messageElement = document.getElementById('chat_input');
   let button = document.getElementById('send');
   
   button.addEventListener('click', onClickEventFunction);

   function onClickEventFunction() {
       let message = messageElement.value;

       let myChatBox = document.getElementById('chat_messages');

       let newChatBox = document.createElement('div');

       newChatBox.setAttribute('class', 'message my-message');

       newChatBox.innerHTML = message;
       messageElement.value = '';

       myChatBox.appendChild(newChatBox);
   }
}


