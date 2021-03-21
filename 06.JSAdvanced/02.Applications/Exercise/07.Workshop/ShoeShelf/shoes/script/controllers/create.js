export default function() {
    Promise
        .all([
            getTemplate('../templates/common/header.hbs'),
            getTemplate('../templates/common/footer.hbs'),
            getTemplate('../templates/create/create.hbs')
        ])
        .then(([header, footer, create]) => {
            Handlebars.registerPartial('header', header);
            Handlebars.registerPartial('footer', footer);

            const createCreatePage = Handlebars.compile(create);

            checkForUser();

            htmlSelector.mainDiv().innerHTML = createCreatePage(data);
        });
}

export function createShoe() {
    const formData = new FormData(htmlSelector.form());

    const name = formData.get('name');
    const price = Number(formData.get('price'));
    const imageUrl = formData.get('imageUrl');
    const description = formData.get('description');
    const brand = formData.get('brand');

    requests
        .createShoe({ name, price, imageUrl, description, brand })
        .then(({ name }) => {
            if (!name) return;
            redirectRoute('/home');
        });
}