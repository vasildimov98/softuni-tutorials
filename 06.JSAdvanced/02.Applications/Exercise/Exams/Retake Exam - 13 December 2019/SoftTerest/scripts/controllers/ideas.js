import { getUserLocalId, loadPartials, notify } from "../utils.js";
import { create, deleteById, editById, getById } from '../data.js';

export async function createIdea() {
    await loadPartials(this);

    const context = {
        user: this.app.userData,
    };

    this.partial('/templates/dashboards/create.hbs', context)
}

export async function deleteIdea() {
    const id = this.params.id;
    try {
        await deleteById(id);
        notify('Idea deleted successfully.', '#successBox');
        this.redirect('/home');
    } catch (error) {
        notify(error.message, '#errorBox');
    }

}

export async function detailPage() {
    await loadPartials(this);

    const id = this.params.id;
    const idea = await getById(id);

    const context = {
        user: this.app.userData,
        isCreator: idea._ownerId == getUserLocalId(),
        idea,
    };

    await this.partial('/templates/dashboards/details.hbs', context);

    const commentBtn = document.querySelector('form > button');
    const likeLink = document.querySelector('form > a');

    if (commentBtn)
        commentBtn.addEventListener('click', (e) => addComment(e, id, idea, this));

    if (likeLink)
        likeLink.addEventListener('click', (e) => likeIdea(e, id, idea, this));
}

export async function likeIdea(e, id, idea, ctx) {
    e.preventDefault();
    const likeElment = e.target.parentElement.parentElement.querySelector('#likes');
    const likes = Number(likeElment.innerHTML) + 1;

    if (!likes) return;

    await editById(id, { likes });

    await loadPartials(ctx);

    idea = await getById(id);
    const context = {
        user: ctx.app.userData,
        isCreator: idea._ownerId == getUserLocalId(),
        idea,
    };

    await ctx.partial('/templates/dashboards/details.hbs', context);

    const commentBtn = document.querySelector('form > button');
    const likeLink = document.querySelector('form > a');

    if (commentBtn)
        commentBtn.addEventListener('click', (e) => addComment(e, id, idea, ctx));

    if (likeLink)
        likeLink.addEventListener('click', (e) => likeIdea(e, id, idea, ctx));
}

async function addComment(e, id, idea, ctx) {
    e.preventDefault();
    const commentEl = e.target.parentElement.querySelector('#comment');
    const comment = commentEl.value;

    if (!comment) return;

    commentEl.value = '';

    if (!idea.comments)
        idea.comments = [];

    idea.comments.push(comment);

    await editById(id, { comments: idea.comments });

    await loadPartials(ctx);
    idea = await getById(id);
    const context = {
        user: ctx.app.userData,
        isCreator: idea._ownerId == getUserLocalId(),
        idea,
    };

    await ctx.partial('/templates/dashboards/details.hbs', context);

    const commentBtn = document.querySelector('form > button');
    const likeLink = document.querySelector('form > a');

    if (commentBtn)
        commentBtn.addEventListener('click', (e) => addComment(e, id, idea, ctx));

    if (likeLink)
        likeLink.addEventListener('click', (e) => likeIdea(e, id, idea, ctx));
}

export async function postIdea(ctx) {
    const { title, description, imageURL } = ctx.params;
    console.log(imageURL.startsWith('https://'));
    console.log(imageURL.startsWith('http://'));
    try {
        if (title.length < 6 ||
            description.length < 10 ||
            (!imageURL.startsWith('https://') &&
                !imageURL.startsWith('http://')))
            throw new Error('Something went wrong!');

        await create({ title, description, imageURL, likes: 0 })
        notify('Idea created successfully.', '#successBox');
        ctx.redirect('/home');
    } catch (error) {
        notify(error.message, '#errorBox');
    }
}