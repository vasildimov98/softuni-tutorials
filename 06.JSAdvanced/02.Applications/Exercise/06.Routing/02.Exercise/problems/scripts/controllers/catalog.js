export default function() {
    const url = 'https://myjsprojects-7781f.firebaseio.com/teams.json';
    fetch(url)
        .then(res => res.json())
        .then((data) => {

            const userData = this.app.userData;
            attachTeamsToContext(data, userData);
            this.loadPartials({
                [headerPartialName]: headerPartialPath,
                [footerPartialName]: footerPartialPath,
                [teamPartialName]: teamPartialPath,
            }).then(function() {
                this.partial(catalogPageTemplatePath, userData);
            });
        });
}

function attachTeamsToContext(data, context) {
    if (!data)
        return;

    context.teams = [];
    Object
        .keys(data)
        .forEach(teamId => {
            var team = data[teamId];

            team['_id'] = teamId;

            context.teams.push(team);
        });
}