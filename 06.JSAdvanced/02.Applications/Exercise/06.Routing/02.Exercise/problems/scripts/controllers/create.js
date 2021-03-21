export default function() {
    const userData = this.app.userData;

    this.loadPartials({
        [headerPartialName]: headerPartialPath,
        [footerPartialName]: footerPartialPath,
        [createPartialName]: createPartialPath,
    }).then(function() {
        this.partial(createPageTemplatePath, userData);
    });
}

export function createNewTeam() {
    const { name, comment } = this.params;

    if (!name || !comment) {
        errorHandler({ message: "Values should not be empty!" })
        return;
    }

    const newTeam = {
        name,
        comment,
    }

    const postRequest = 'POST';
    const postBody = JSON.stringify(newTeam);

    const userToken = localStorage.getItem('userToken');
    if (!userToken) {
        errorHandler({ message: 'User is not logged in!' })
        return;
    }

    const headerBody = {
        'Content-Type': 'application/json',
        'user-token': userToken
    }

    const url = 'https://myjsprojects-7781f.firebaseio.com/teams.json';

    const postObj = {
        method: postRequest,
        header: headerBody,
        body: postBody,
    }

    fetch(url, postObj)
        .then(res => res.json())
        .then((data) => joinTeam(data, this));
}

function joinTeam(data, context) {
    context.app.userData.teamId = data.name;
    context.redirect(`#/catalog/${data.name}`);
}