import services from '../services.js';

export default function() {
    Promise
        .all([
            getTemplate('./templates/common/header.hbs'),
            getTemplate('./templates/common/footer.hbs'),
            getTemplate('./templates/add/add.hbs')
        ]).then(([header, footer, add]) => {
            Handlebars.registerPartial('header', header);
            Handlebars.registerPartial('footer', footer);

            const createAddPage = Handlebars.compile(add);
            const addPage = createAddPage();

            htmlSelector.mainDiv().innerHTML = addPage;
        });
}

export function addMovie() {
    const formData = new FormData(htmlSelector.formElement());

    const title = formData.get('title');
    const description = formData.get('description');
    const imageUrl = formData.get('imageUrl');

    services
        .addMovie(title, description, imageUrl)
        .then(() => {
            redirectRoute('/home');
            successHandler({ message: 'Created successfully!' });
        });
}