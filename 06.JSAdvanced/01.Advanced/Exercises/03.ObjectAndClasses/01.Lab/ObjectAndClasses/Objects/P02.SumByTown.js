function showTheIncomeOfTown(arr) {
    let townsWithSum = {};
    for (let i = 0; i < arr.length; i += 2) {
        let element = arr[i];
         if (!townsWithSum.hasOwnProperty(arr[i])) {
                townsWithSum[`${element}`] = 0;
            }
        
        let income = arr[i + 1];
        townsWithSum[`${element}`] += Number(income);
    }

    let myJSON = JSON.stringify(townsWithSum);

    console.log(myJSON);
}

showTheIncomeOfTown(['Sofia','20','Varna','3','Sofia','5','Varna','4']);
showTheIncomeOfTown(['Sofia','20','Varna','3','sofia','5','varna','4']);