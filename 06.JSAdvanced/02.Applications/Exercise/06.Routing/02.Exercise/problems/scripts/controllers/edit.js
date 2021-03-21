export default function() {
    const teamId = this.params.teamId;
    const url = `https://myjsprojects-7781f.firebaseio.com/teams/${teamId}.json`;
    fetch(url)
        .then(res => res.json())
        .then(teamData => {

            const userData = this.app.userData;

            attachDataToContext(userData, teamData);

            if (teamId == userData.teamId) {
                userData.isAuthor = true;
                userData.teamId = teamId;
            }

            this.loadPartials({
                [headerPartialName]: headerPartialPath,
                [footerPartialName]: footerPartialPath,
                [editPartialName]: editPartialPath
            }).then(function() {
                this.partial(editPageTemplatePath, userData);
            });
        });
}

export function editCurrTeam() {
    const { name, comment, teamId } = this.params;

    if (!name || !comment) {
        errorHandler({ message: "Values should not be empty!" })
        return;
    }

    const newTeam = {
        name,
        comment,
    }

    const putRequest = 'PUT';
    const putBody = JSON.stringify(newTeam);

    const userToken = localStorage.getItem('userToken');
    if (!userToken) {
        errorHandler({ message: 'User is not logged in!' })
        return;
    }

    const headerBody = {
        'Content-Type': 'application/json',
        'user-token': userToken
    };

    const url = `https://myjsprojects-7781f.firebaseio.com/teams/${teamId}.json`;

    const putObj = {
        method: putRequest,
        header: headerBody,
        body: putBody,
    }

    fetch(url, putObj)
        .then(() => this.redirect(`/catalog/${teamId}`))
        .catch(errorHandler);
}


function attachDataToContext(context, data) {
    context.isOnTeam = context.teamId ? true : false;
    context.hasNoTeam = context.isOnTeam ? false : true;
    context.name = data.name;
    context.comment = data.comment;
}