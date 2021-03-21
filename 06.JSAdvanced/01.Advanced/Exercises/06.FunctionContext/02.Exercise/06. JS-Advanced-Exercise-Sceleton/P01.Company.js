class Company {
    constructor() {
        this.departments = [];
    }

    addEmployee(name, salary, position, department) {

        this._validateParameter(name);
        this._validateParameter(salary);
        this._validateParameter(position);
        this._validateParameter(department);

        let newEmployee = {
            name,
            salary,
            position,
        };

        let departmentInCompany = this.departments
            .find(d => d.department == department);

        if (!departmentInCompany) {
            departmentInCompany = {
                department,
                employees: [],
                totalSalary: 0,
                countOfEmployee: 0,
            };

            this.departments.push(departmentInCompany);
        }

        departmentInCompany.employees.push(newEmployee);
        departmentInCompany.countOfEmployee++;
        departmentInCompany.totalSalary += salary;

        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment() {
        let bestDepartmentInCompany = this.departments
            .sort((a, b) => {
                let firstEmployeeAvgSalary = a.totalSalary / a.countOfEmployee;
                let secondEmployeeAvgSalary = b.totalSalary / b.countOfEmployee;

                return secondEmployeeAvgSalary - firstEmployeeAvgSalary;
            })[0];

        let averageSalary = bestDepartmentInCompany.totalSalary / bestDepartmentInCompany.countOfEmployee;

        let result = `Best Department is: ${bestDepartmentInCompany.department}\n`;
        result += `Average salary: ${averageSalary.toFixed(2)}\n`;

        bestDepartmentInCompany
            .employees
            .sort((e1, e2) => {
                let salDiff = e2.salary - e1.salary;

                if (salDiff == 0) {
                    return e1.name.localeCompare(e2.name);
                }

                return salDiff;
            }).forEach(e => {
                result += `${e.name} ${e.salary} ${e.position}\n`;
            });

        return result.trim();
    }

    _validateParameter(parameter) {
        if (parameter === ''
            || parameter === null
            || parameter === undefined
            || !isNaN(parameter)
            && parameter < 0) {
            throw new Error("Invalid input!");
        }
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
