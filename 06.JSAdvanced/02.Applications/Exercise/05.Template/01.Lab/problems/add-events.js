(function () {
    const htmlSelector = {
        contactsDiv: () => document.querySelector('#contacts'),
    }

    const contactsDiv = htmlSelector.contactsDiv();

    function makeGetRequestForTamplates() {
        const contactTemplate = fetch('./contact-card-template.hbs')
            .then(res => res.text());
        const contactsTemplate = fetch('./contact-cards-template.hbs')
            .then(res => res.text());

        Promise
            .all([contactTemplate, contactsTemplate])
            .then(showContacts);
    }

    function showContacts([contactTemplate, contactsTemplate]) {
        Handlebars.registerPartial('contact', contactTemplate);

        const createDivWithContactInfo = Handlebars.compile(contactsTemplate);

        let allContactDivs = createDivWithContactInfo({ contacts });

        contactsDiv.innerHTML = allContactDivs;
        contactsDiv.addEventListener('click', showContactDetails);
    }

    function showContactDetails(e) {
        if (!e.target.classList.contains('detailsBtn')) return;

        const detailsDiv = e.target.parentElement
            .querySelector('.details');
        let detailsStyle = detailsDiv.style.display;

        if (!detailsStyle
            || detailsStyle == 'none')
            detailsDiv.setAttribute('style', 'display: block')
        else detailsDiv.setAttribute('style', 'display: none')
    }

    makeGetRequestForTamplates();
})();