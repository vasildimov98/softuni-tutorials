function aggreate(data, currData) {
    let foundSameData = data.find(d => d.id == currData.id);

    if (foundSameData) {
        foundSameData.score += currData.score;
    } else {
        data.push(currData);
    }

    return data;
}

let dataArray = [{ id: "a", score: 1 }, { id: "b", score: 2 },
{ id: "c", score: 5 }, { id: "a", score: 3 }, { id: "c", score: 2 },];

let aggreateData = dataArray
    .reduce(aggreate, []);

console.log(aggreateData);