import { getUserLocalId, loadPartials, notify } from "../utils.js";
import { createWithBody, deleteById, editById, getById } from '../data.js';

export async function createPage() {
    await loadPartials(this);

    const context = {
        user: this.app.userData,
    };

    this.partial('/templates/destinations/create.hbs', context)
}

export async function editPage() {
    await loadPartials(this);

    const id = this.params.id;

    const dest = await getById(id);

    if (dest._ownerId != getUserLocalId()) {
        notify('Error: Invalid credentials. Please retry your request with correct credentials.', '.errorBox');
        this.redirect('/home');
        return;
    }

    const context = {
        user: this.app.userData,
        dest,
    };

    this.partial('/templates/destinations/edit.hbs', context)
}

export async function deleteDest() {
    const id = this.params.id;

    const dest = await getById(id);

    if (dest._ownerId != getUserLocalId()) {
        notify('Error: Invalid credentials. Please retry your request with correct credentials.', '.errorBox');
        this.redirect('/home');
        return;
    }

    try {
        await deleteById(id);
        notify('Destination deleted.', '.infoBox');
        this.redirect('/destinations');
    } catch (error) {
        notify(error.message, '.errorBox');
    }
}

export async function detailPage() {
    await loadPartials(this);

    const id = this.params.id;
    const dest = await getById(id);
    var date = new Date(dest.departureDate);

    const months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

    dest.day = date.getDate() < 10 ? `0${date.getDate()}` : date.getDate();
    dest.month = months[date.getMonth()];
    dest.year = date.getFullYear();

    const context = {
        user: this.app.userData,
        isCreator: dest._ownerId == getUserLocalId(),
        dest,
    };

    await this.partial('/templates/destinations/details.hbs', context);
}

export async function postEdit(ctx) {
    const { destination, city, duration, departureDate, imgUrl } = ctx.params;

    try {
        if (!destination ||
            !city ||
            !duration ||
            !departureDate ||
            !imgUrl)
            throw new Error('Empty fields! All fields are required!');

        if (!imgUrl.startsWith('https://') &&
            !imgUrl.startsWith('http://'))
            throw new Error('Image url should starts with either https:// or http://!');

        if (Number(duration) < 1 || Number(duration) > 100)
            throw new Error('Duration should be between 1 and 100!');

        const id = ctx.params.id;

        await editById(id, { destination, city, duration, departureDate, imgUrl });
        notify('Successfully edited destination.', '.infoBox');
        ctx.redirect(`/details/${id}`);
    } catch (error) {
        notify(error.message, '.errorBox');
    }
}

export async function postCreate(ctx) {
    const { destination, city, duration, departureDate, imgUrl } = ctx.params;

    try {
        if (!destination ||
            !city ||
            !duration ||
            !departureDate ||
            !imgUrl)
            throw new Error('Empty fields! All fields are required!');

        if (!imgUrl.startsWith('https://') &&
            !imgUrl.startsWith('http://'))
            throw new Error('Image url should starts with either https:// or http://!');

        if (Number(duration) < 1 || Number(duration) > 100)
            throw new Error('Duration should be between 1 and 100!');

        await createWithBody({ destination, city, duration, departureDate, imgUrl });
        notify('Destination created successfully.', '.infoBox');
        ctx.redirect('/home');
    } catch (error) {
        notify(error.message, '.errorBox');
    }
}