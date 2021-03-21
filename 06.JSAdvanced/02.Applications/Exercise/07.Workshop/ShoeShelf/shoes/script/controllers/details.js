export default function(id) {
    Promise
        .all([
            getTemplate('../templates/common/header.hbs'),
            getTemplate('../templates/common/footer.hbs'),
            getTemplate('../templates/details/details.hbs')
        ])
        .then(([header, footer, details]) => {
            Handlebars.registerPartial('header', header);
            Handlebars.registerPartial('footer', footer);

            const createDetailsPage = Handlebars.compile(details);

            checkForUser();
            requests
                .getShoeDetailsById(id)
                .then(shoe => {
                    if (!shoe) return;

                    data['shoe'] = shoe;
                    const { email } = JSON.parse(localStorage.getItem('userInfo'));

                    if (shoe['people-bought-it'].includes(email)) data['userBoughtIt'] = true;
                    else data['userBoughtIt'] = false;

                    data['buyers'] = shoe['people-bought-it'].length - 1;
                    if (email == shoe.creator)
                        data['isCreator'] = true;
                    else data['isCreator'] = false;

                    htmlSelector.mainDiv().innerHTML = createDetailsPage(data);
                });
        });
}

export function buyCurrShoe(id) {
    requests
        .getShoeDetailsById(id)
        .then(shoe => {
            const { email } = JSON.parse(localStorage.getItem('userInfo'));
            shoe['people-bought-it'].push(email);
            return requests
                .editShoeDetailsById(id, { 'people-bought-it': shoe['people-bought-it'] })
        })
        .then(() => redirectRoute(`/details/${id}`));
}

export function deleteCurrShoe(id) {
    requests
        .deleteShoeById(id)
        .then(() => redirectRoute('/home'));
}