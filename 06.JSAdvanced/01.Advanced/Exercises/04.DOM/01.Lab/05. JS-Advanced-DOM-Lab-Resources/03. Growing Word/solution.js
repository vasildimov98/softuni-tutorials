function growingWord() {
  let word = document.querySelector('#exercise > p');

  let colors = {
    'blue': 'green',
    'green': 'red',
    'red': 'blue',
  }

  if (!word.hasAttribute('style')) {
    word.setAttribute('style', `color: blue; font-size: 2px`);
  } else {
    let currPx = word.style['font-size'];
    px = Number(currPx.substring(0, currPx.length - 2)) * 2;
    let currColor = word.style['color'];
    word.setAttribute('style', `color: ${colors[currColor]}; font-size: ${px}px`);
  }
}