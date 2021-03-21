class Article {
    _comments = [];
    _likes = [];
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
    }

    get likes() {
        let firstPersonToLike = this._likes[0];

        return !firstPersonToLike ?
            `${this.title} has 0 likes` :
            this._likes.length == 1 ?
                `${firstPersonToLike} likes this article!` :
                `${firstPersonToLike} and ${this._likes.length - 1} others like this article!`;
    }

    like(username) {
        if (this._likes.includes(username)) {
            throw new Error('You can\'t like the same article twice!');
        }

        if (this.creator == username) {
            throw new Error(`You can't like your own articles!`);
        }

        this._likes.push(username);

        return `${username} liked ${this.title}!`;
    }

    dislike(username) {
        if (!this._likes.includes(username)) {
            throw new Error(`You can't dislike this article!`);
        }

        this
            ._likes
            .splice(this
                ._likes
                .indexOf(username), 1);

        return `${username} disliked ${this.title}`;
    }

    comment(username, content, id) {
        let currComment = this
            ._comments[id - 1];
        if (!id
            || !currComment) {
            this._comments.push({
                id: this._comments.length + 1,
                username,
                content,
                replies: [],
            });

            return `${username} commented on ${this.title}`;
        }

        currComment
            .replies
            .push({
                id: currComment.id + `.${currComment.replies.length + 1}`,
                username,
                content,
            });

        return 'You replied successfully';
    }


    toString(sortingType) {
        let result = [];

        result.push(`Title: ${this.title}`);
        result.push(`Creator: ${this.creator}`);
        result.push(`Likes: ${this._likes.length}`);
        result.push(`Comments:`);

        this._comments
            .sort((c1, c2) => {
                return sortingType == 'asc' ?
                    c1.id - c2.id :
                    sortingType == 'desc' ?
                        c2.id - c1.id :
                        c1.username.localeCompare(c2.username);
            }).forEach(c => {
                result
                    .push(`-- ${c.id}. ${c.username}: ${c.content}`);
                c
                    .replies
                    .sort((r1, r2) => {
                        return sortingType == 'asc' ?
                            r1.id - r2.id :
                            sortingType == 'desc' ?
                                r2.id - r1.id :
                                r1.username.localeCompare(r2.username);
                    }).forEach(r => {
                        result
                            .push(`--- ${r.id}. ${r.username}: ${r.content}`);
                    });
            });

        return result
            .join('\n');
    }
}

let art = new Article("My Article", "Anny");
console.log(art.like("John"));//, "John liked My Article!");
console.log(art.likes);// "John likes this article!");
//console.log(art.dislike("Sally"));//, "You can't dislike this article!");
console.log(art.like("Ivan"))//,"Ivan liked My Article!");
console.log(art.like("Steven"));//, "Steven liked My Article!");
console.log(art.likes);//, "John and 2 others like this article!");
console.log(art.comment("Anny", "Some Content"));//,"Anny commented on My Article");
console.log(art.comment("Ammy", "New Content", 1));//,"You replied successfully");
console.log(art.comment("Zane", "Reply", 2));//,"Zane commented on My Article");
console.log(art.comment("Jessy", "Nice :)"));//, "Jessy commented on My Article");
console.log(art.comment("SAmmy", "Reply@", 2));//, "You replied successfully");

console.log(art.toString('asc'));
//`Title: My Article
// Creator: Anny
// Likes: 3
// Comments:
// -- 1. Anny: Some Content
// --- 1.1. Ammy: New Content
// -- 2. Zane: Reply
// --- 2.1. SAmmy: Reply@
// -- 3. Jessy: Nice :)`);