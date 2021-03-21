let person = {
    firstName: 'Albus',
    lastName: 'Dumbledore',
    dateOfBirth: '1881-08-30',
    gender: 'Male',
    colorOfEyes: 'blue',
    occupation: ['Headmaster of Hogwarts School of Witchcraft and Wizardry (1960s–1997)',
        'Chief Warlock of the Wizengamot (1978–1997)',
        'Supreme Mugwamp of the International Confederation of Wizards (1983–1995)',
        'Transfiguration Professor of Hogwarts (1930–1956)',
        'Defense Against the Dark Arts Professor of Hogwarts (c. 1910s–1930)'],
    school: {
        name: `Hogward school of Witchcraft and Wizardry`,
        founded: '9th/10th century',
        location: 'Somewhere in Scotland',
        motto: `Latin: Draco dormiens nunquam titillandus English: Never Tickle a Sleeping Dragon`,
        type: ['Public school', 'Secondary school', 'Boarding school'],
        houses: [
            {
                name: 'Gryffindor',
                headOfHouse: `Pr. Minerva McGonagall`,
                ghost: 'Sir Nicholas de Mimsy-Porpington',
                points: 500,
            },
            {
                name: 'Hufflepuff',
                headOfHouse: `Pr. Pomona Sprout`,
                ghost: 'the Fat Friar',
                points: 1200,
            },
            {
                name: 'Ravenclaw',
                headOfHouse: `Pr. Filius Flitwick`,
                ghost: 'the Grey Lady',
                points: 450,
            },
            {
                name: 'Slytherin',
                headOfHouse: `Pr. Severus Snape`,
                ghost: 'The Bloody Baron',
                points: 500,
            },
        ],
        students: [
            {
                firstName: 'Harry',
                lastName: 'Potter',
                houseInSchool: `Gryffindor`,
                subject: ['Defence Against the Dark Arts', 'Herbology', 'Transfiguration'],
                grades: ['O', 'A', 'EE', 'O'],
            },
            {
                firstName: 'Ron',
                lastName: 'Winsley',
                houseInSchool: `Gryffindor`,
                subject: ['Defence Against the Dark Arts', 'Herbology', 'Transfiguration'],
                grades: ['EE', 'A', 'A', 'EE'],
            },
            {
                firstName: 'Hermione',
                lastName: 'Granger',
                houseInSchool: `Gryffindor`,
                subject: ['Defence Against the Dark Arts', 'Herbology', 'Transfiguration'],
                grades: ['EE', 'O', 'O', 'O'],
            },
            {
                firstName: 'Drago',
                lastName: 'Malfoy',
                houseInSchool: `Slytherin`,
                subject: ['Defence Against the Dark Arts', 'Herbology', 'Transfiguration'],
                grades: ['EE', 'EE', 'O', 'O'],
            },
        ]
    },
    greet() {
        return `Good afternoon, ${this.lastName} said`
    },
    toString() {
        return `${this.firstName} ${this.lastName}. Date of birth: ${this.dateOfBirth}. Main occupation: ${this.occupation[0]}`
    },
};

// // Array Destructuring
// let [firstOcp, secondOcp, ...othersOcps] = person.occupation;
// console.log(firstOcp);
// console.log(secondOcp);
// console.log(othersOcps);

// // Object Destructoring
// let { firstName, lastName, occupation: [firstOc], school: {name, houses: [{name: name1}, {name: name2}, {name: name3}, {name: name4}]} } = person;

// console.log(name1);
// console.log(name2);
// console.log(name3);
// console.log(name4);

// nested Array
let matrix = [
    [{one: [1]}, {two: [2]}, {three: [3]}],
    [4, 5, 6],
    [7, 8, 9],
];

let [[{one: [one]}, {two: [two]}, {three: [three]}], [four, five, six], [seven, eight, nine]] = matrix;

console.log(one);
console.log(two);
console.log(three);