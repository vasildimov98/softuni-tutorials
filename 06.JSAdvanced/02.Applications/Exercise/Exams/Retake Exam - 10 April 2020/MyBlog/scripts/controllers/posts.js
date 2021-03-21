import { create, deleteById, editById, getById } from "../data.js";
import { getUserData, getUserLocalId, loadPartials, notify } from "../utils.js";

export async function postCreate(ctx) {
    const { title, category, content } = ctx.params;

    try {
        if (!title || !category || !content)
            throw new Error('All fields are required!');
        else {
            await create({
                title,
                category,
                content
            });
            notify('Successfully created post!', '#successBox');

            ctx.redirect('/home');
        }
    } catch (error) {
        notify(error.message, '#errorBox');
    }
}

export async function postEdit(ctx) {
    const { title, category, content } = ctx.params;
    const id = ctx.params.id;

    try {
        if (!title || !category || !content)
            throw new Error('All fields are required!');
        else {
            await editById(id, {
                title,
                category,
                content
            });

            notify('Successfully edited post!', '#successBox');

            ctx.redirect('/home');
        }
    } catch (error) {
        notify(error.message, '#errorBox');
    }
}

export async function deletePost() {
    try {
        const id = this.params.id;
        const post = await getById(id);
        if (post._ownerId !== getUserLocalId()) {
            notify('Invalid credentials. Please retry your request with correct credentials', '#errorBox');
            this.redirect('/home');
            return;
        }

        await deleteById(id);
        notify('Successfully deleted post!', '#successBox');
        this.redirect('/home');
    } catch (error) {
        notify(error.message, '#errorBox');
    }
}

export async function detailPage() {
    await loadPartials(this);

    const id = this.params.id;

    const context = {
        user: getUserData(),
        post: await getById(id),
    }

    this.partial('/templates/posts/details.hbs', context)
}

export async function editPage() {
    await loadPartials(this);
    this.partials.post = await this.load('/templates/home/post.hbs')

    const id = this.params.id;

    const post = await getById(id);

    if (post._ownerId !== getUserLocalId()) {
        notify('Invalid credentials. Please retry your request with correct credentials', '#errorBox');
        this.redirect('/home');
        return;
    }

    const context = {
        user: getUserData(),
        post,
    }

    this.partial('/templates/posts/edit.hbs', context)
}