function getBallonClasses() {
    class Balloon {
        constructor(color, gasWeight) {
            this.color = color;
            this.gasWeight = gasWeight;
        }
    }

    class PartyBalloon extends Balloon {
        constructor(color, gasWeight, ribbonColor, ribbonLength) {
            super(color, gasWeight);
            this._ribbon = { color: ribbonColor, length: ribbonLength };
        }

        get ribbon() {
            return this._ribbon;
        }
    }

    class BirthdayBalloon extends PartyBalloon {
        constructor(color, gasWeight, ribbonColor, ribbonLength, text) {
            super(color, gasWeight, ribbonColor, ribbonLength);
            this._text = text;
        }

        get text() {
            return this._text;
        }
    }

    return {
        Balloon,
        PartyBalloon,
        BirthdayBalloon,
    };
}

let ballons = getBallonClasses();

let ballon = new ballons.Balloon('red', 213);
let partyBallon = new ballons.PartyBalloon('red', 213, 'yellow', 22);
let birthdayBallon = new ballons.BirthdayBalloon('red', 213, 'pink', 2, 'Happy Birthday!!!');

console.log(ballon);
console.log(partyBallon);
console.log(birthdayBallon);