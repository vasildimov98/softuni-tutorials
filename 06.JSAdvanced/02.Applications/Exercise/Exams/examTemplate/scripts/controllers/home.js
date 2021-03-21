import { getAll } from "../data.js";
import { loadPartials } from "../utils.js";

export async function homePage() {
    await loadPartials(this);
    this.partials.article = await this.load('/templates/home/article.hbs');

    const categories = await getAll();
    const context = categories;
    context.user = this.app.userData;

    this.partial('/templates/home/home.hbs', context);
}