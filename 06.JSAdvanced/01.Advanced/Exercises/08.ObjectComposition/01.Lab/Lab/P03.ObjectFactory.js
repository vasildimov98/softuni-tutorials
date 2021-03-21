function createObject(propertyArgs) {
    return JSON
        .parse(propertyArgs)
        .reduce((obj, currObj) => {
            return { ...obj, ...currObj };
        }, {});
}

console.log(createObject(`[{"canMove": true},{"canMove":true, "doors": 4},{"capacity": 5}]`));
console.log(createObject(`[{"canFly": true},{"canMove":true, "doors": 4},{"capacity": 255},{"canFly":false, "canLand": true}]`));