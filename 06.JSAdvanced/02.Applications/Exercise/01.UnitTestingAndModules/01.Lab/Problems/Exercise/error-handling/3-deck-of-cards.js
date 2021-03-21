function printDeckOfCards(cards) {
    let Card = (function createCard() {
        class Card {
            _acceptableCardFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
            _acceptableCardSuits = ['S', 'H', 'D', 'C'];

            constructor(face, suit) {
                this.face = face;
                this.suit = suit;
            }

            get face() {
                return this._face;
            }

            set face(value) {
                if (!this._acceptableCardFaces.includes(value)) {
                    throw new Error('Invalid card face!');
                }

                this._face = value;
            }

            get suit() {
                return this._suit;
            }

            set suit(value) {
                if (!this._acceptableCardSuits.includes(value)) {
                    throw new Error('Invalid card suit!');
                }

                this._suit = value;
            }

            toString() {
                return `${this.face}${this.suit == 'S' ?
                    '\u2660' :
                    this.suit == 'H' ?
                        '\u2665' :
                        this.suit == 'D' ?
                            '\u2666' :
                            '\u2663'}`;
            }
        }

        return Card;
    })();

    let cardSequence = cards
        .reduce((sequence, card) => {
            let face = card
                .substring(0, card.length - 1);
            let suit = card
                .substring(face.length);

            try {
                let currCard = new Card(face, suit);
                sequence.push(currCard.toString());

                return sequence;
            } catch (error) {
                console.log(`Invalid card: ${card}`);
                return;
            }
        }, []);

    if (cardSequence) console.log(cardSequence
        .join(' '));
}

printDeckOfCards(['AS', '10D', 'KH', '2C']);
printDeckOfCards(['5S', '3D', 'QD', '1C', '223']);