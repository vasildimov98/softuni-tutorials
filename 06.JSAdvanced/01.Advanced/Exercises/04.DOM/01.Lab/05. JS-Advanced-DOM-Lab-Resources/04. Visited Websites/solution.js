function solve() {
  let sites = document.querySelectorAll('.link-1 a');

  for (const site of sites) {
    site.addEventListener('click', onClickEvent)
  }

  function onClickEvent(e) {
    let visitedCountElement = e.currentTarget.nextElementSibling;

    let count = Number(visitedCountElement.innerHTML.split(' ')[1]);
    count++; 
    
    visitedCountElement.innerHTML = `visited ${count} times`;
  }
}