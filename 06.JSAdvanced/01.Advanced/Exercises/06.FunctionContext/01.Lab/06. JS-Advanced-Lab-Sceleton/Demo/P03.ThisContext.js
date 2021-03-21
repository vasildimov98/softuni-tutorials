function reportGrades() {
    return `Hello my name is ${this.name} and my grades are ${this.grades.join(', ')}`;
}

function showGrades() {
    this.grades.forEach(g => {
        console.log(g);
    });
}

let person = {
    name: 'Vasil',
    grades: [6, 6, 6, 6, 6],
    showGrades: showGrades,
    reportGrades: reportGrades,
};

person.reportGrades();