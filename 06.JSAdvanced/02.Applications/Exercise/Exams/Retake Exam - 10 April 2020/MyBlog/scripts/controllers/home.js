import { getAll } from "../data.js";
import { checkForCreators, loadPartials } from "../utils.js";

export async function homePage() {
    await loadPartials(this);
    this.partials.post = await this.load('/templates/home/post.hbs');

    const context = {
        user: this.app.userData,
        posts: await getAll(),
    };

    checkForCreators(context.posts);

    this.partial('/templates/home/home.hbs', context);
}