function lockedProfile() {
    let mainElement = document
        .getElementById('main');

    mainElement
        .addEventListener('click', makeChangeOnProfile);

    function makeChangeOnProfile(e) {
        let tagName = e.target.tagName;
        if (tagName == 'BUTTON') {
            let parentElement = e.target.parentElement;

            let isLocked = parentElement.querySelector('input[type="radio"]').checked;

            if (!isLocked) {
                let targetValue = e.target.innerHTML;
                let hidenDivElement = parentElement.querySelector('div');

                if (targetValue == 'Show more') {
                    hidenDivElement.style.display = 'block';
                    e.target.innerHTML = 'Hide it';
                } else {
                    hidenDivElement.style.display = 'none';
                    e.target.innerHTML = 'Show more';
                }
            }
        }
    }
}