export default function() {
    const teamId = this.params.teamId;
    const url = `https://myjsprojects-7781f.firebaseio.com/teams/${teamId}.json`;
    fetch(url)
        .then(res => res.json())
        .then(teamData => {

            const userData = this.app.userData;

            attachDataToContext(userData, teamData);

            userData.members = { email: userData.email };
            if (teamId == userData.teamId) {
                userData.isAuthor = true;
                this.teamId = teamId;
            }

            this.loadPartials({
                [headerPartialName]: headerPartialPath,
                [footerPartialName]: footerPartialPath,
                [teamMemberPartialName]: teamMemberPartialPath,
                [teamControlPartialName]: teamControlPartialPath,
            }).then(function() {
                this.partial(detailsPageTemplatePath, userData);
            });
        });
}

function attachDataToContext(context, data) {
    context.isOnTeam = context.teamId ? true : false;
    context.hasNoTeam = context.isOnTeam ? false : true;
    context.name = data.name;
    context.comment = data.comment;
}