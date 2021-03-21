import services from "../services.js";

export default function(id) {
    Promise
        .all([
            getTemplate('../templates/common/header.hbs'),
            getTemplate('../templates/common/footer.hbs'),
            getTemplate('../templates/details/details.hbs')
        ]).then(([header, footer, details]) => {
            Handlebars.registerPartial('header', header);
            Handlebars.registerPartial('footer', footer);

            checkForLogInUser();

            services
                .getMovieById(id)
                .then(movie => {
                    if (data.email == movie.creator)
                        data['isCreator'] = true;
                    else data['isCreator'] = false;

                    const likes = movie['people-liked'];

                    if (likes.includes(data.email)) {
                        data['userHasLikedIt'] = true;
                        data['likes'] = likes.length - 1;
                    } else data['userHasLikedIt'] = false;

                    Object.assign(data, movie);
                    const createDetailsPage = Handlebars.compile(details);
                    const detailsPage = createDetailsPage(data);

                    htmlSelector.mainDiv().innerHTML = detailsPage;
                });
        });
}

export function likeCurrMovie(id) {
    services
        .getMovieById(id)
        .then(movie => {
            const oldLikes = movie['people-liked'];
            services
                .editMovieById(id, {
                    ['people-liked']: [...oldLikes, data.email]
                }).then(() => {
                    redirectRoute(`/details/${id}`, true);
                    successHandler({ message: 'Liked successfully' });
                });
        });
}

export function deleteCurrMovie(id) {
    services
        .deleteMovieById(id)
        .then(() => {
            redirectRoute(`/home`);
            successHandler({ message: 'Deleted successfully!' });
        });
}