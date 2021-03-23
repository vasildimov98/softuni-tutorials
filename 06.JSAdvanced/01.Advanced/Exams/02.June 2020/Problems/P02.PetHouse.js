function getPetClasses() {
    class Pet {
        comments = [];

        constructor(owner, name) {
            this.owner = owner;
            this.name = name;
        }

        addComment(comment) {
            if (this.comments.includes(comment)) {
                throw new Error('This comment is already added!');
            }

            this
                .comments
                .push(comment);

            return 'Comment is added.';
        }

        feed() { return `${this.name} is fed` };

        toString() {
            let result = [];

            result.push(`Here is ${this.owner}'s pet ${this.name}.`);
            this.comments.length ?
                result.push(`Special requirements: ${this.comments.join(', ')}`)
                : '';

            return result.join('\n');
        }
    }

    class Cat extends Pet {
        constructor(owner, name, insideHabits, scratching) {
            super(owner, name);
            this.insideHabits = insideHabits;
            this.scratching = scratching;
        }

        feed() { return `${super.feed()}, happy and purring.` };

        toString() {
            let result = [];

            result
                .push(super
                    .toString());
            result
                .push('Main information:');
            result
                .push(this.scratching ?
                    `${this.name} is a cat with ${this.insideHabits}, but beware of scratches.`
                    : `${this.name} is a cat with ${this.insideHabits}`);

            return result.join('\n');
        }
    }

    class Dog extends Pet {
        constructor(owner, name, runningNeeds, trainability) {
            super(owner, name);
            this.runningNeeds = runningNeeds;
            this.trainability = trainability;
        }

        feed() { return `${super.feed()}, happy and wagging tail.` };

        toString() {
            let result = [];

            result
                .push(super
                    .toString());
            result
                .push('Main information:');
            result
                .push(`${this.name} is a dog with need of ${this.runningNeeds}km running every day and ${this.trainability} trainability.`);

            return result.join('\n');
        }
    }

    return {
        Pet,
        Cat,
        Dog,
    }
}

let classes = getPetClasses();
// let pet = new classes.Pet('Ann', 'Merry');
// console.log(pet.addComment('likes bananas'));
// console.log(pet.addComment('likes sweets'));
// console.log(pet.feed());
// console.log(pet.toString());

let cat = new classes.Cat('Jim', 'Sherry', 'very good habits', false);
// console.log(cat.addComment('likes to be brushed '));
// console.log(cat.addComment('likes to be brushed'));
console.log(cat.feed());
console.log(cat.toString());

// let dog = new classes.Dog('Susan', 'Max', 5, 'good');
// console.log(dog.addComment('likes to be brushed'));
// console.log(dog.addComment('sleeps a lot'));
// console.log(dog.feed());
// console.log(dog.toString());