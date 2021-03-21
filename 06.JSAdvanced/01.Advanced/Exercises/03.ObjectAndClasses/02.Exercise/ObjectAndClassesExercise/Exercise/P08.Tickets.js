function getSortedArrayOfTickets(ticketsInfo, sortingCriteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let tickets = [];
    ticketsInfo.forEach(ticketArgs => {
        let [destination, price, status] = ticketArgs.split('|');

        price = Number(price).toFixed(2);

        let ticket = new Ticket(destination, Number(price), status);

        tickets.push(ticket);
    });

    tickets.sort((a, b) => {
        if (sortingCriteria == 'destination') {
            return a.destination.localeCompare(b.destination);
        } else if (sortingCriteria == 'price') {
            return a.price - b.price;
        } else {
            return a.status.localeCompare(b.status);
        }
    })

   return tickets;
}

console.log(getSortedArrayOfTickets([
    'Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'
],
    'destination'
));
console.log(getSortedArrayOfTickets([
    'Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'
],
    'status'
));