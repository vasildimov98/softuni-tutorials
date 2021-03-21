export default function() {
    Promise
        .all([
            getTemplate('../templates/common/header.hbs'),
            getTemplate('../templates/common/footer.hbs'),
            getTemplate('../templates/home/shoes.hbs'),
            getTemplate('../templates/home/home.hbs')
        ])
        .then(([header, footer, shoes, home]) => {
            Handlebars.registerPartial('header', header);
            Handlebars.registerPartial('footer', footer);
            Handlebars.registerPartial('collection', shoes);

            const createHomePage = Handlebars.compile(home);

            checkForUser();

            checkForShoes()
                .then(() => {
                    htmlSelector.mainDiv().innerHTML = createHomePage(data);
                });
        });
}