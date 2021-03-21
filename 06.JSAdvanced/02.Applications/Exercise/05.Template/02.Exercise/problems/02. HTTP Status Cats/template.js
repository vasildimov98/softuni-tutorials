(() => {
    const htmlSelector = {
        allCatsSection: () => document.querySelector('#allCats'),
    };

    const catPartialTamplatePath = './cat-partial-template.hbs';
    const catsTamplatePath = './cats-template.hbs';
    const catPartialName = 'catPartial';

    const clickEvent = 'click';

    const showBtnClass = 'showBtn';
    const catStatusDivClass = '.status';

    const styleAttribute = 'style';
    const showStatusStyle = 'display: block';
    const hideStatusStyle = 'display: none';

    const showBtnName = 'Show status code';
    const hideBtnName = 'Hide status code';

    const allCatsSection = htmlSelector
        .allCatsSection();

    Promise
        .all([
            fetch(catPartialTamplatePath)
                .then(res => res.text()),
            fetch(catsTamplatePath)
                .then(res => res.text()),
        ])
        .then(proceedWithTemplates)
        .catch(console.error);

    function proceedWithTemplates([catPartial, catTemplate]) {
        Handlebars.registerPartial(catPartialName, catPartial.toString());

        let createUnorderedListWithCatsInfo = Handlebars.compile(catTemplate);

        renderCatTemplate(createUnorderedListWithCatsInfo);
    }

    function renderCatTemplate(createUnorderedListWithCatsInfo) {
        let unorderedListWithCats = createUnorderedListWithCatsInfo({ cats });
        allCatsSection.innerHTML = unorderedListWithCats;
        allCatsSection.addEventListener(clickEvent, showStatus)
    }

    function showStatus(e) {
        let btn = e.target;
        if (!btn
            .classList
            .contains(showBtnClass)) return;

        let catStatusDiv = btn
            .parentElement
            .querySelector(catStatusDivClass);

        if (btn.textContent == showBtnName) {
            catStatusDiv.setAttribute(styleAttribute, showStatusStyle);
            btn.textContent = hideBtnName;
        }
        else {
            catStatusDiv.setAttribute(styleAttribute, hideStatusStyle)
            btn.textContent = showBtnName;
        }


    }
})();
