function showGladiatorSkills(gladiatorInfo) {
    let gladiators = {};

    gladiatorInfo
        .forEach(line => {
            if (line.includes('->')) {
                addGladiator(line);
            } else if (line.includes('vs')) {
                battleGladiators(line);
            }
        });

    printGladiatorsInfo();

    function printGladiatorsInfo() {
        Object
        .keys(gladiators)
        .sort((a, b) => {
            let glad1Skills = gladiators[a].skills;
            let glad2Skills = gladiators[b].skills;

            let comperor = glad2Skills - glad1Skills;

            if (comperor == 0) {
                return a.localeCompare(b);
            }

            return comperor;
        }).forEach(g => {
            console.log(`${g}: ${gladiators[g].skills} skill`);

            let techniques = gladiators[g].techniques;

            Object
                .keys(techniques)
                .sort((a, b) => {
                    let tech1Skills = techniques[a];
                    let tech2Skills = techniques[b];
        
                    let comperor = tech2Skills - tech1Skills;
        
                    if (comperor === 0) {
                        return a.localeCompare(b);
                    }
        
                    return comperor;
                }).forEach(t => {
                    console.log(`- ${t} <!> ${techniques[t]}`);
                });
        });
    }

    function battleGladiators(gladsArgs) {
        let [glad1, glad2] = gladsArgs.split(' vs ');

        let gladOne = gladiators[glad1];
        let gladTwo = gladiators[glad2];

        if (gladOne && gladTwo) {
            let gladOneTechniques = Object.keys(gladOne.techniques);
            let gladTwoTechniques = Object.keys(gladTwo.techniques);

            for (const tech1 of gladOneTechniques) {
                for (const tech2 of gladTwoTechniques) {
                    if (tech1 === tech2) {
                        if (gladOne.skills > gladTwo.skills) {
                            delete gladiators[glad2];
                        } else if (gladTwo.skills > gladOne.skills) {
                            delete gladiators[glad1];
                        }
                    }
                }
            }
        }
    }

    function addGladiator(gladArgs) {
        let [glad, technique, skill] = gladArgs.split(' -> ');

        skill = Number(skill);

        if (!gladiators[glad]) {
            gladiators[glad] = {
                techniques: {},
                skills: 0,
            };
        }

        if (!gladiators[glad].techniques[technique]) {
            gladiators[glad].techniques[technique] = 0;
        }

        if (gladiators[glad].techniques[technique] < skill) {
            gladiators[glad].skills -= gladiators[glad].techniques[technique];
            gladiators[glad].skills += skill;
            gladiators[glad].techniques[technique] = skill;
        }
    }
}

// showGladiatorSkills([
//     'Pesho -> BattleCry -> 400',
//     'Gosho -> PowerPunch -> 300',
//     'Stamat -> Duck -> 200',
//     'Stamat -> Tiger -> 250',
//     'Ave Cesar'
//]
//);

showGladiatorSkills([
    'Pesho -> Duck -> 400',
    'Pesho -> Heal -> 10',
    'Julius -> Shield -> 150',
    'Gladius -> Heal -> 200',
    'Gladius -> Heal -> 250',
    'Gladius -> Shield -> 250',
    'Pesho vs Gladius',
    'Gladius vs Julius',
    'Gladius vs Gosho',
    'Ave Cesar'
]
);