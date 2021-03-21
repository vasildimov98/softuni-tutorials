export default function(id) {
    Promise
        .all([
            getTemplate('../templates/common/header.hbs'),
            getTemplate('../templates/common/footer.hbs'),
            getTemplate('../templates/details/edit.hbs')
        ])
        .then(([header, footer, edit]) => {
            Handlebars.registerPartial('header', header);
            Handlebars.registerPartial('footer', footer);

            const createEditPage = Handlebars.compile(edit);

            checkForUser();
            requests
                .getShoeDetailsById(id)
                .then(shoe => {
                    if (!shoe) return;
                    data['shoe'] = shoe;

                    htmlSelector.mainDiv().innerHTML = createEditPage(data);
                });
        });
}

export function editShoeDetails(id) {
    const formData = new FormData(htmlSelector.form());

    const name = formData.get('name');
    const price = Number(formData.get('price'));
    const imageUrl = formData.get('imageUrl');
    const description = formData.get('description');
    const brand = formData.get('brand');
    requests
        .editShoeDetailsById(id, { name, price, imageUrl, description, brand })
        .then(data => {
            if (!data) return;
            redirectRoute(`/details/${id}`);
        });
}