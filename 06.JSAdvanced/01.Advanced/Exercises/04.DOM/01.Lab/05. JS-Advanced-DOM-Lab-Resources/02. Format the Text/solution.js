function solve() {
  let inputParagraph = document.getElementById('input');

  let sentences = inputParagraph.innerText.split('.');

  let divOutput = document.getElementById('output');

  let newParagraph = document.createElement('p');
  sentences.forEach((s, i) => {
    newParagraph.innerText += s;

    if ((i + 1) % 3 == 0) {
      divOutput.appendChild(newParagraph);
      newParagraph = document.createElement('p');
    }
  });

  if (sentences.length % 3 != 0) {
    divOutput.appendChild(newParagraph);
  }
}