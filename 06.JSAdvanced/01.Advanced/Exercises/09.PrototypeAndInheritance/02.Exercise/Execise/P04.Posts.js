function getPosts() {
    class Post {
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }
    
        toString() {
            let result = [];
    
            result.push(`Post: ${this.title}`);
            result.push(`Content: ${this.content}`);
    
            return result
                .join('\n');
        }
    }
    
    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes) {
            super(title, content);
            this.likes = likes;
            this.dislikes = dislikes;
            this.comments = [];
        }
    
        addComment = (comment) => this
            .comments
            .push(comment);
    
        toString() {
            let result = [];
    
            result.push(super.toString());
            result.push(`Rating: ${this.likes - this.dislikes}`);
    
            if (this.comments.length) {
                result.push('Comments:');
    
                this.comments.forEach(c => result.push(` * ${c}`));
            }
    
            return result
                .join('\n');
        }
    }
    
    class BlogPost extends Post {
        constructor(title, content, views) {
            super(title, content);
            this.views = views;
        }
    
        view() {
            this.views++;
    
            return this;
        }
    
        toString() {
            let result = [];
    
            result.push(super.toString());
            result.push(`Views: ${this.views}`);
    
            return result
                .join('\n');
        }
    }
    
    return { Post, SocialMediaPost, BlogPost };
}

let post = new Post("Post", "Content");

console.log(post.toString());

// Post: Post
// Content: Content

let scm = new SocialMediaPost("TestTitle", "TestContent", 25, 30);

scm.addComment("Good post");
scm.addComment("Very good post");
scm.addComment("Wow!");

console.log(scm.toString());

// Post: TestTitle
// Content: TestContent
// Rating: -5
// Comments:
//  * Good post
//  * Very good post
//  * Wow!

let blogPost = new BlogPost('My beautiful day', 'I was walking down the road when....', 2);

blogPost
    .view()
    .view()
    .view()
    .view()
    .view()
    .view()
    .view()
    .view()
    .view()
    .view()
    .view()
    .view();

console.log(blogPost.toString());