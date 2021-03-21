import { getAll } from "../data.js";
import { getAllUserDestination, loadPartials } from "../utils.js";

export async function homePage() {
    await loadPartials(this);
    this.partials.dest = await this.load('/templates/home/destination.hbs');

    const destinations = await getAll();

    const context = { destinations };
    context.user = this.app.userData;

    this.partial('/templates/home/home.hbs', context);
}

export async function destinationDashboard() {
    await loadPartials(this);
    this.partials.userDest = await this.load('/templates/home/userDestination.hbs');

    const destinations = await getAll();
    const userDestionation = getAllUserDestination(destinations)
    const context = { userDestionation };
    context.user = this.app.userData;

    this.partial('/templates/destinations/dashboard.hbs', context);
}