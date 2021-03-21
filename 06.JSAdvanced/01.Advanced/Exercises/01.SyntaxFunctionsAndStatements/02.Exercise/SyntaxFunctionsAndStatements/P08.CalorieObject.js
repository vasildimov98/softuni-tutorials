function showCalories(foodInfo) {
    let arr = [];
    for (let i = 0; i < foodInfo.length; i += 2) {
        let foodName = foodInfo[i];
        let foodCalories = foodInfo[i + 1];

        let food = {name: foodName, calories: foodCalories};
        let objResul = `${food.name}: ${food.calories}`;
        arr.push(objResul);
    }

    let result = arr.join(', ');

    console.log(`{ ${result} }`);
}

showCalories(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);
showCalories(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']);