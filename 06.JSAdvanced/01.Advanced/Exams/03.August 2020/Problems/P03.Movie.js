class Movie {
    constructor(movieName, ticketPrice) {
        this.movieName = movieName;
        this.ticketPrice = Number(ticketPrice);
        this.screenings = [];
        this.totalProfit = 0;
        this.totalSoldTickets = 0;
    }

    newScreening(date, hall, description) {
        let currScreening = this
            .screenings
            .find(sc => sc.date == date
                && sc.hall == hall);

        if (currScreening) {
            throw new Error(`Sorry, ${hall} hall is not available on ${date}`);
        }

        currScreening = {
            date,
            hall,
            description,
        }

        this.screenings.push(currScreening);

        return `New screening of ${this.movieName} is added.`;
    }

    endScreening(date, hall, soldTickets) {
        let currScreening = this
            .screenings
            .find(sc => sc.date == date
                && sc.hall == hall);

        if (!currScreening) {
            throw new Error(`Sorry, there is no such screening for ${this.movieName} movie.`);
        }

        let profit = soldTickets * this.ticketPrice;
        this.totalProfit += profit;
        this.totalSoldTickets += soldTickets;
        this.screenings.splice(this.screenings.indexOf(currScreening), 1);

        return `${this.movieName} movie screening on ${date} in ${hall} hall has ended. Screening profit: ${profit}`;
    }

    toString() {
        let result = [];

        result.push(`${this.movieName} full information:`);
        result.push(`Total profit: ${this.totalProfit.toFixed(0)}$`);
        result.push(`Sold Tickets: ${this.totalSoldTickets}`);
        if (this.screenings.length) {
            result.push('Remaining film screenings:');
            this
                .screenings
                .sort((sc1, sc2) => {
                    return sc1.hall.localeCompare(sc2.hall);
                }).forEach(sc => {
                    result.push(`${sc.hall} - ${sc.date} - ${sc.description}`);
                });
        } else {
            result
                .push('No more screenings!');
        }


        return result.join('\n');
    }
}


let m = new Movie('Wonder Woman 1984', '10.3123');
console.log(m.newScreening('October 2, 2020', 'IMAX 3D', `3D`));
console.log(m.newScreening('October 3, 2020', 'Main', `regular`));
console.log(m.newScreening('October 4, 2020', 'IMAX 3D', `3D`));
console.log(m.endScreening('October 4, 2020', 'IMAX 3D', 72));
console.log(m.endScreening('October 2, 2020', 'IMAX 3D', 150));
console.log(m.endScreening('October 3, 2020', 'Main', 78));
console.log(m.toString());

m.newScreening('October 4, 2020', '235', `regular`);
m.newScreening('October 5, 2020', 'Main', `regular`);
m.newScreening('October 3, 2020', '235', `regular`);
m.newScreening('October 4, 2020', 'Main', `regular`);
console.log(m.toString());

// Corresponding output
// New screening of Wonder Woman 1984 is added.
// New screening of Wonder Woman 1984 is added.
// New screening of Wonder Woman 1984 is added.
// Wonder Woman 1984 movie screening on October 2, 2020 in IMAX 3D hall has ended. Screening profit: 1500
// Wonder Woman 1984 movie screening on October 3, 2020 in Main hall has ended. Screening profit: 780
// Wonder Woman 1984 full information:
// Total profit: 2280$
// Sold Tickets: 228
// Remaining film screenings:
// IMAX 3D - October 4, 2020 - 3D

// Wonder Woman 1984 full information:
// Total profit: 2280$
// Sold Tickets: 228
// Remaining film screenings:
// 235 - October 4, 2020 - regular
// 235 - October 3, 2020 - regular
// IMAX 3D - October 4, 2020 - 3D
// Main - October 5, 2020 - regular
// Main - October 4, 2020 - regular