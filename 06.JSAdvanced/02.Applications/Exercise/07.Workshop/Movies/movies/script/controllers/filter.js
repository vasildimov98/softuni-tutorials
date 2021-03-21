import services from "../services.js";

export default async function(filter) {
    if (!filter) return;

    let movies = await services
        .getAllMovies();

    movies = movies
        .filter(m => m.name.toUpperCase().includes(filter.toUpperCase()));
    Promise
        .all([
            getTemplate('../templates/common/header.hbs'),
            getTemplate('../templates/common/footer.hbs'),
            getTemplate('../templates/home/movie-card.hbs'),
            getTemplate('../templates/home/home.hbs')
        ]).then(([header, footer, movie, home]) => {
            Handlebars.registerPartial('header', header);
            Handlebars.registerPartial('footer', footer);
            Handlebars.registerPartial('movie-card', movie);

            checkForLogInUser();
            data['movies'] = movies;
            const createHomePage = Handlebars.compile(home);
            const homePage = createHomePage(data);

            htmlSelector.mainDiv().innerHTML = homePage;
        })
        .catch(errorHandler);
}