let result = (() => {
    return {
        call: (post, action) => {
            if (action == 'upvote') {
                post.upvotes++;
            } else if (action == 'downvote') {
                post.downvotes++;
            } else {
                let totalVotes = post.upvotes + post.downvotes;

                let newObfuscatedUpvoted = post.upvotes;
                let newObfuscatedDownVotes = post.downvotes;
                if (totalVotes > 50) {
                    let max = Math.max(post.upvotes, post.downvotes);

                    let numberToAddToResult = Math.ceil(0.25 * max);

                    newObfuscatedUpvoted = post.upvotes + numberToAddToResult;
                    newObfuscatedDownVotes = post.downvotes + numberToAddToResult;
                }

                let balance = post.upvotes - post.downvotes;

                let majority = post.upvotes / totalVotes;

                let rating = '';
                if (totalVotes >= 10
                    && majority > 0.66) {
                    rating = 'hot';
                } else if (balance >= 0
                    && (post.upvotes > 100
                        || post.downvotes > 100)) {
                    rating = 'controversial';
                } else if (totalVotes >= 10
                    && balance < 0) {
                    rating = 'unpopular';
                } else {
                    rating = 'new';
                }

                let result = [newObfuscatedUpvoted, newObfuscatedDownVotes, balance, rating];

                return result;
            }
        }
    };
})();


var forumPost = {
    id: '1234',
    author: 'author name',
    content: 'these fields are irrelevant',
    upvotes: 4,
    downvotes: 5
};

// Under border case
var answer = result.call(forumPost, 'score');
var expected = [4, 5, -1, 'new'];
console.log(answer);

// // Past border case
result.call(forumPost, 'downvote');
answer = result.call(forumPost, 'score');
expected = [4, 6, -2, 'unpopular'];
console.log(answer);

result.call(forumPost, 'upvote');
result.call(forumPost, 'upvote');
answer = result.call(forumPost, 'score');
expected = [6, 6, 0, 'new'];
console.log(answer);

// // 38 Upvotes
// for (let i = 0; i < 38; i++) {
//     result.call(forumPost, 'upvote');
// }
// answer = result.call(forumPost, 'score');
// expected = [44, 6, 38, 'hot'];
// console.log(answer);

// // Past obfuscation threshold
// result.call(forumPost, 'downvote');
// answer = result.call(forumPost, 'score');
// expected = [55, 18, 37, 'hot'];
// console.log(answer);

// expect(forumPost.upvotes).to.equal(44, 'Actual upvotes were manipulated');
// expect(forumPost.downvotes).to.equal(7, 'Actual downvotes were manipulated');

// // Bellow hot threshold
// forumPost.upvotes = 132;
// forumPost.downvotes = 68;

// answer = result.call(forumPost, 'score');
// expected = [165, 101, 64, 'controversial'];
// console.log(answer);

// // Past hot threshold
// forumPost.upvotes = 133;

// answer = result.call(forumPost, 'score');
// expected = [167, 102, 65, 'hot'];
// console.log(answer);

// expect(forumPost.upvotes).to.equal(133, 'Actual upvotes were manipulated');
// expect(forumPost.downvotes).to.equal(68, 'Actual downvotes were manipulated');


// let post = {
//     id: '3',
//     author: 'emil',
//     content: 'wazaaaaa',
//     upvotes: 100,
//     downvotes: 100
// };
// result.call(post, 'upvote');
// result.call(post, 'downvote');
// let score = result.call(post, 'score');// [127, 127, 0, 'controversial']
// //console.log(score);
// for (let index = 0; index < 50; index++) {

//     result.call(post, 'downvote')
// }
// score = result.call(post, 'score'); 
// console.log(score);   // [139, 189, -50, 'unpopular']
