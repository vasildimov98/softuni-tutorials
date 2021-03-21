let result = (function () {
    let Suits = {
        SPADES: '♠',
        HEARTS: '♥',
        DIAMONDS: '♦',
        CLUBS: '♣',
    }

    class Card {
        constructor(face, suit) {
            this.face = face;
            this.suit = suit;
        }

        get face() {
            return this.faceValue;
        }

        set face(value) {
            if (Number(value) >= 2
            && Number(value) <= 10) {
                this.faceValue = value;
            } else if (value == 'J' || value == 'Q' || value == 'K' || value == 'A') {
                this.faceValue = value;
            } else {
                throw new Error('Invalid face!');
            }
        }

        get suit() {
            return this.suitValue;
        }

        set suit(value) {
            if (value != '♣'
                && value != '♥'
                && value != '♦'
                && value != '♠') {
                throw new Error('Invalid suit!');
            }

            this.suitValue = value;
        }
    }

    return {
        Suits: Suits,
        Card: Card,
    }
}());

let Card = result.Card;
let Suits = result.Suits;

let card = new Card('2', Suits.CLUBS);
card.face = 'A';
card.suit = Suits.DIAMONDS;

let card2 = new Card('1', Suits.DIAMONDS);
