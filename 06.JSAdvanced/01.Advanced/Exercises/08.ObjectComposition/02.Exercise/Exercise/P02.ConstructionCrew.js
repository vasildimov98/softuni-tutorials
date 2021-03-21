function checkConstructorForDizziness(constructor) {
    let {dizziness, weight, experience} = constructor; 

    if (dizziness) {
        let neededWater = 0.1 * weight * experience;

        constructor.levelOfHydrated += neededWater;

        constructor.dizziness = false;
    }

    return constructor;
}

console.log(checkConstructorForDizziness({
    weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true
}
));

console.log(checkConstructorForDizziness({
    weight: 120,
    experience: 20,
    levelOfHydrated: 200,
    dizziness: true
}
));
console.log(checkConstructorForDizziness({
    weight: 95,
    experience: 3,
    levelOfHydrated: 0,
    dizziness: false
}
));