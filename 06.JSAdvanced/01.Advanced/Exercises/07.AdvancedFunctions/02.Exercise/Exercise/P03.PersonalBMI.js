function getPatientCharts(...personArgs) {
    let [name, age, weight, height] = personArgs;

    let heightInM = height / 100;

    let personBMI = Math.round(weight / Math.pow(heightInM, 2));

    let status;
    if (personBMI < 18.5) {
        status = 'underweight';
    } else if (personBMI < 25) {
        status = 'normal';
    } else if (personBMI < 30) {
        status = 'overweight';
    } else {
        status = 'obese';
    }

    let patientCharts = {
        name,
        personalInfo: {
            age,
            weight,
            height,
        },
        BMI: personBMI,
        status,
    };

    if (status == 'obese') {
        patientCharts['recommendation'] = 'admission required';
    }

    return patientCharts
}

// let firstCharts = getPatientCharts('Peter', 29, 75, 182);
// console.log(firstCharts);
let secondCharts = getPatientCharts('Honey Boo Boo', 9, 57, 137);
console.log(secondCharts);