$(() => {
    const htmlSelector = {
        monkeysDiv: () => document.querySelector('.monkeys'),
    }

    const monkeyPartialPath = './monkey-partial.hbs';
    const monkeyTemplatePath = './monkey-template.hbs';

    const partialName = 'monkeyPartial';
    const buttonType = 'BUTTON';
    const paragraphTag = 'p';
    const showBtnName = 'SHOW INFO';
    const hideBtnName = 'HIDE INFO';

    const styleAttribute = 'style';
    const showStyle = 'display: block;';
    const hideStyle = 'display: none;';

    const clickEvent = 'click';

    const monkeyDiv = htmlSelector
        .monkeysDiv();

    Promise
        .all([
            getTemplate(monkeyPartialPath),
            getTemplate(monkeyTemplatePath)
        ])
        .then(registerTemplates)
        .catch(console.error);


    function registerTemplates([partial, template]) {
        Handlebars.registerPartial(partialName, partial);
        let createDivWithMonkeysInfo = Handlebars.compile(template);
        showMonkeys(createDivWithMonkeysInfo);
    }

    function showMonkeys(createDivWithMonkeysInfo) {
        let divWithMonkeysInfo = createDivWithMonkeysInfo({ monkeys });
        monkeyDiv.innerHTML = divWithMonkeysInfo;
        monkeyDiv
            .addEventListener(clickEvent, showMonkeyInfo);
    }

    function showMonkeyInfo(e) {
        let btn = e.target;
        let btnType = btn.nodeName;
        if (btnType != buttonType) return;

        let infoParagraph = btn
            .parentElement
            .querySelector(paragraphTag)

        if (btn.textContent == showBtnName) {
            infoParagraph.setAttribute(styleAttribute, showStyle)
            btn.textContent = hideBtnName;
        }
        else {
            infoParagraph.setAttribute(styleAttribute, hideStyle)
            btn.textContent = showBtnName;
        }
    }

    function getTemplate(templatePath) {
        return fetch(templatePath)
            .then(res => res.text());
    }
});