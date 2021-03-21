function solve() {
  let rightAnswers = 3;
  let correctAnswers = {
    'onclick': true,
    'JSON.stringify()': true,
    'A programming API for HTML and XML documents': true,
  }

  let sectionIndex = 0;
  let sections = document
    .getElementsByTagName('section');
  let currSection = sections[sectionIndex++];

  Array
    .from(document
      .querySelectorAll('.answer-text'))
    .map(e => e
      .addEventListener('click', onClickMoveToNextSection));

  function onClickMoveToNextSection(e) {
    let answer = e.target.innerHTML;

    if (!correctAnswers[answer]) {
      rightAnswers--;
    }

    currSection.style.display = 'none';
    currSection = sections[sectionIndex++];

    if (currSection) {
      currSection.style.display = 'block'
    } else {
      document
        .getElementById('results')
        .style
        .display = 'block';

      let h1ResultElment = document
        .querySelector('#results h1');

      if (rightAnswers == 3) {
        h1ResultElment.innerHTML += 'You are recognized as top JavaScript fan!';
      } else {
        h1ResultElment.innerHTML += `You have ${rightAnswers} right answers`;
      }
    }
  }
}
