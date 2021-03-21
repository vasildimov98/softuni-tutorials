function solveClasses() {
    class Developer {
        constructor(firstName, lastName) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.baseSalary = 1000;
            this.tasks = [];
            this.experience = 0;
        }

        addTask(id, taskName, priority) {
            let newTaskObj = {
                id,
                name: taskName,
                priority
            }

            if (priority == 'high') {
                this.tasks
                    .unshift(newTaskObj);
            } else {
                this.tasks
                    .push(newTaskObj);
            }

            return `Task id ${id}, with ${priority} priority, has been added.`;
        }

        doTask() {
            if (!this.tasks.length) {
                return `${this.firstName}, you have finished all your tasks. You can rest now.`;
            }

            let newestTask = this.tasks
                .shift();

            return newestTask.name;
        }

        getSalary() {
            return `${this.firstName} ${this.lastName} has a salary of: ${this.baseSalary}`;
        }

        reviewTasks() {
            let result = [];

            result.push('Tasks, that need to be completed:');

            this.tasks
                .forEach(t => {
                    result.push(`${t.id}: ${t.name} - ${t.priority}`);
                });

            return result
                .join('\n');
        }
    }

    class Junior extends Developer {
        constructor(firstName, lastName, bonus, experience) {
            super(firstName, lastName);
            this.baseSalary += bonus;
            this.experience = experience;
        }

        learn(years) {
            this.experience += years;

            return this.experience;
        }
    }

    class Senior extends Developer {
        constructor(firstName, lastName, bonus, experience) {
            super(firstName, lastName);
            this.baseSalary += bonus;
            this.experience += experience + 5;
        }

        changeTaskPriority(taskId) {
            let task = this.tasks
                .find(t => t.id == taskId);

            this
                .tasks
                .splice(this.tasks.indexOf(task), 1);

            if (task.priority == 'high') {
                task.priority = 'low';
                this.tasks.push(task);
            } else {
                task.priority = 'high';
                this.tasks.unshift(task);
            }

            return task;
        }
    }

    return {
        Developer,
        Junior,
        Senior
    }
}

let classes = solveClasses();
const developer = new classes.Developer("George", "Joestar");
console.log(developer.addTask(1, "Inspect bug", "low"));
console.log(developer.addTask(2, "Update repository", "high"));
console.log(developer.reviewTasks());
console.log(developer.getSalary());
// //----------------------------------------------------------------------------
const junior = new classes.Junior("Jonathan", "Joestar", 200, 2);
console.log(junior.getSalary());
// //----------------------------------------------------------------------------
const senior = new classes.Senior("Joseph", "Joestar", 200, 2);
senior.addTask(1, "Create functionality", "low");
senior.addTask(2, "Update functionality", "high");
console.log(senior.changeTaskPriority(1)["priority"]);
console.log(senior.getSalary());
console.log(senior.experience);
// Corresponding output
// Task id 1, with low priority, has been added.
// Task id 2, with high priority, has been added.
// Tasks, that need to be completed:
// 2: Update repository - high
// 1: Inspect bug - low
// George Joestar has a salary of: 1000
// ----------------------------------------------------------------------------
// Jonathan Joestar has a salary of: 1200
// ----------------------------------------------------------------------------
// high