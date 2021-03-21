import { getAll } from "../data.js";
import { getUserLocalId, loadPartials } from "../utils.js";

export async function homePage() {
    await loadPartials(this);
    this.partials.dashboard = await this.load('/templates/home/dashboard.hbs');
    this.partials.guest = await this.load('/templates/home/guest.hbs');
    this.partials.idea = await this.load('/templates/home/idea.hbs');

    const ideas = await getAll();
    const context = {};
    ideas.sort((idea1, idea2) => Number(idea2.likes) - Number(idea1.likes));

    context.ideas = ideas;
    context.user = this.app.userData;

    this.partial('/templates/home/home.hbs', context);
}

export async function profilePage() {
    await loadPartials(this);

    const ideas = await getAll();
    const ownerIdeas = getOwnerIdeas(ideas);
    const context = {
        user: this.app.userData,
        countOfIdeas: ownerIdeas.length,
        ideas: ownerIdeas
    };

    this.partial('/templates/profile/profile.hbs', context);
}

function getOwnerIdeas(ideas) {
    let ownerIdeas = [];
    for (const idea of ideas) {
        if (idea._ownerId == getUserLocalId())
            ownerIdeas.push(idea);
    }

    return ownerIdeas;
}