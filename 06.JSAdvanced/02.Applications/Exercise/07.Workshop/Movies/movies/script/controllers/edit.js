import services from "../services.js";

export default function(id) {
    Promise
        .all([
            getTemplate('../templates/common/header.hbs'),
            getTemplate('../templates/common/footer.hbs'),
            getTemplate('../templates/details/edit.hbs')
        ]).then(([header, footer, edit]) => {
            Handlebars.registerPartial('header', header);
            Handlebars.registerPartial('footer', footer);

            checkForLogInUser();

            services
                .getMovieById(id)
                .then(movie => {
                    Object.assign(data, movie);
                    const createEditPage = Handlebars.compile(edit);
                    const editPage = createEditPage(data);

                    htmlSelector.mainDiv().innerHTML = editPage;
                });
        });
}

export function editMovie(id) {
    const formData = new FormData(htmlSelector.formElement());

    const name = formData.get('title');
    const description = formData.get('description');
    const imageUrl = formData.get('imageUrl');

    services
        .editMovieById(id, { name, description, imageUrl })
        .then(() => {
            redirectRoute(`/details/${id}`);
            successHandler({ message: 'Eddited successfully!' });
        });
}