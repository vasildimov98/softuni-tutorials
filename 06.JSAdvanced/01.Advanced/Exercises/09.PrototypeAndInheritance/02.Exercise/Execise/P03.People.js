function getEmployees() {
    class Employee {
        constructor(name, age) {
            if (new.target === 'Employee') {
                throw new Error('Cannor instantiate directly.');
            }
            this.name = name;
            this.age = age;
            this.salary = 0;
            this.tasks = [];
        }

        work() {
            let currTask = this.tasks.shift();
            console.log(this.name + currTask);
            this.tasks.push(currTask);
        }

        collectSalary() {
            console.log(`${this.name} received ${this.getSalary()} this month.`);
        }

        getSalary() {
            return this.salary;
        }
    }

    class Junior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks.push(' is working on a simple task.');
        }
    }

    class Senior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks.push(' is working on a complicated task.');
            this.tasks.push(' is taking time off work.');
            this.tasks.push(' is supervising junior workers.');
        }
    }

    class Manager extends Employee {
        constructor(name, age) {
            super(name, age);
            this.dividend = 0;
            this.tasks.push(' scheduled a meeting.');
            this.tasks.push(' is preparing a quarterly report.');
        }

        getSalary() {
            return this.salary + this.dividend;
        }
    }

    return { Employee, Junior, Senior, Manager };
}

let employees = getEmployees();

let junior = new employees.Junior('Pesho', 13);
let senior = new employees.Senior('Vasil', 21);
let manager = new employees.Manager('John', 34);

junior.work();
senior.work();
manager.work();
junior.work();
senior.work();
manager.work();

manager.salary += 2133;
manager.dividend += 1919;

manager.collectSalary();