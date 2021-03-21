function showCatalogOfUsernames(usernames) {
    usernames.sort((a, b) => {
        let comparer = a.length - b.length;

        if (comparer == 0) {
            return a.localeCompare(b);
        }

        return comparer;
    }).filter(onlyUnique)
        .forEach(username => {
            console.log(username);
        });

    function onlyUnique(value, index, usernames) {
         return usernames.indexOf(value) === index; 
    }
}

showCatalogOfUsernames([
    'Ashton',
    'Kutcher',
    'Ariel',
    'Lilly',
    'Keyden',
    'Aizen',
    'Billy',
    'Braston'
]
);

showCatalogOfUsernames([
    'Denise',
    'Ignatius',
    'Iris',
    'Isacc',
    'Indie',
    'Dean',
    'Donatello',
    'Enfuego',
    'Benjamin',
    'Biser',
    'Bounty',
    'Renard',
    'Rot',
    'Rot'
]
);