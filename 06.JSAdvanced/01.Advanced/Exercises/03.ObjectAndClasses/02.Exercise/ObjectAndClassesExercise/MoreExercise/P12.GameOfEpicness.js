function showWinnerKingdom(kingdomsInfo, battlesInfo) {
    let kingdoms = {};

    kingdomsInfo.forEach(kingdomArgs => {
        addKingdom(kingdomArgs);
    });

    battlesInfo.forEach(battleArgs => {
        battleKindoms(battleArgs);
    });

    let winner = Object
        .keys(kingdoms)
        .sort(sortKingdoms)[0];

    printWinner(winner);

    function printWinner(winner) {
        Object
            .keys(kingdoms[winner])
            .forEach(w => {
                console.log(`Winner: ${winner}`);
                let generals = kingdoms[winner][w];

                Object
                    .keys(generals)
                    .sort(sortGenerals)
                    .forEach(g => {
                        console.log(`/\\general: ${g}`);
                        console.log(`---army: ${generals[g].army}`);
                        console.log(`---wins: ${generals[g].wins}`);
                        console.log(`---losses: ${generals[g].losses}`);
                    });
            });
    }

    function sortGenerals(firstGeneral, secondGeneral) {
        let firstGeneralArmy = kingdoms[winner].generals[firstGeneral].army;
        let secondGeneralArmy = kingdoms[winner].generals[secondGeneral].army;

        return secondGeneralArmy - firstGeneralArmy;
    }

    function sortKingdoms(firstKingdom, secondKingdom) {
        let firstKingdomWins = Object
            .keys(kingdoms[firstKingdom].generals)
            .reduce((w, a) => {
                if (a != 'wins' && a != 'losses') {
                    return w += kingdoms[firstKingdom].generals[a].wins;
                } else {
                    return w;
                }
            }, 0);

        let secondKingdomWins = Object
            .keys(kingdoms[secondKingdom].generals)
            .reduce((w, a) => {
                if (a != 'wins' && a != 'losses') {
                    return w += kingdoms[secondKingdom].generals[a].wins;
                } else {
                    return w;
                }
            }, 0);

        let comparer = secondKingdomWins - firstKingdomWins;

        if (comparer == 0) {
            let firstKingdomLosses = Object
                .keys(kingdoms[firstKingdom].generals)
                .reduce((l, a) => {
                    if (a != 'wins' && a != 'losses') {
                        return l += kingdoms[firstKingdom].generals[a].losses;
                    } else {
                        return w;
                    }
                }, 0);

            let secondKingdomLosses = Object
                .keys(kingdoms[secondKingdom].generals)
                .reduce((l, a) => {
                    if (a != 'wins' && a != 'losses') {
                        return l += kingdoms[secondKingdom].generals[a].losses;
                    } else {
                        return w;
                    }
                }, 0);

            comparer = firstKingdomLosses - secondKingdomLosses;
        }

        if (comparer == 0) {
            comparer = firstKingdom.localeCompare(secondKingdom);
        }

        return comparer;
    }

    function battleKindoms(battleArgs) {
        let attackingKingdom = battleArgs[0];
        let attackingGeneral = battleArgs[1];
        let defendingKingdom = battleArgs[2];
        let defendingGeneral = battleArgs[3];

        if (attackingKingdom === defendingKingdom) {
            return;
        }

        let firstGeneralArmy = kingdoms[attackingKingdom].generals[attackingGeneral].army;
        let secondGeneralArmy = kingdoms[defendingKingdom].generals[defendingGeneral].army;

        let diff = firstGeneralArmy - secondGeneralArmy;

        if (diff === 0) {
            return;
        }

        if (diff > 0) {
            kingdoms[attackingKingdom].generals[attackingGeneral].wins++;
            kingdoms[defendingKingdom].generals[defendingGeneral].losses++;

            kingdoms[attackingKingdom].generals[attackingGeneral].army = Math.floor(firstGeneralArmy * 1.1);
            kingdoms[defendingKingdom].generals[defendingGeneral].army = Math.floor(secondGeneralArmy * 0.9);
        } else {
            kingdoms[defendingKingdom].generals[defendingGeneral].wins++;
            kingdoms[attackingKingdom].generals[attackingGeneral].losses++;

            kingdoms[defendingKingdom].generals[defendingGeneral].army = Math.floor(secondGeneralArmy * 1.1);
            kingdoms[attackingKingdom].generals[attackingGeneral].army = Math.floor(firstGeneralArmy * 0.9);
        }
    }

    function addKingdom(kingdomArgs) {
        let kingdom = kingdomArgs.kingdom;
        let general = kingdomArgs.general;
        let army = kingdomArgs.army;

        if (!kingdoms[kingdom]) {
            kingdoms[kingdom] = {
                generals: {},
            };
        }

        if (!kingdoms[kingdom].generals[general]) {
            kingdoms[kingdom].generals[general] = {
                army: 0,
                wins: 0,
                losses: 0,
            };
        }

        kingdoms[kingdom].generals[general].army += army;
    }
}

// showWinnerKingdom([
//     { kingdom: "Maiden Way", general: "Merek", army: 5000 },
//     { kingdom: "Stonegate", general: "Ulric", army: 4900 },
//     { kingdom: "Stonegate", general: "Doran", army: 70000 },
//     { kingdom: "YorkenShire", general: "Quinn", army: 0 },
//     { kingdom: "YorkenShire", general: "Quinn", army: 2000 },
//     { kingdom: "Maiden Way", general: "Berinon", army: 100000 }
// ], [
//     ["YorkenShire", "Quinn", "Stonegate", "Ulric"],
//     ["Stonegate", "Ulric", "Stonegate", "Doran"],
//     ["Stonegate", "Doran", "Maiden Way", "Merek"],
//     ["Stonegate", "Ulric", "Maiden Way", "Merek"],
//     ["Maiden Way", "Berinon", "Stonegate", "Ulric"]
// ]
// );

// showWinnerKingdom([
//     { kingdom: "Stonegate", general: "Ulric", army: 5000 },
//     { kingdom: "YorkenShire", general: "Quinn", army: 5000 },
//     { kingdom: "Maiden Way", general: "Berinon", army: 1000 }
// ], [
//     ["YorkenShire", "Quinn", "Stonegate", "Ulric"],
//     ["Maiden Way", "Berinon", "YorkenShire", "Quinn"]
// ]
// );

// showWinnerKingdom([
//     { kingdom: "Maiden Way", general: "Merek", army: 5000 },
//     { kingdom: "Stonegate", general: "Ulric", army: 4900 },
//     { kingdom: "Stonegate", general: "Doran", army: 70000 },
//     { kingdom: "YorkenShire", general: "Quinn", army: 0 },
//     { kingdom: "YorkenShire", general: "Quinn", army: 2000 }
// ], [
//     ["YorkenShire", "Quinn", "Stonegate", "Doran"],
//     ["Stonegate", "Ulric", "Maiden Way", "Merek"]
// ]
// );