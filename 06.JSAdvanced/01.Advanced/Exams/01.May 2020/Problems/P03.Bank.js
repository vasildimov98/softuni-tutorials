class Bank {
    constructor(bankName) {
        this._bankName = bankName;
        this.allCustomers = [];
    }

    newCustomer(customer) {
        let sameCustomer = this
            .allCustomers
            .find(c => c.firstName === customer.firstName
                && c.lastName === customer.lastName);

        if (sameCustomer) {
            throw new Error(`${customer.firstName} ${customer.lastName} is already our customer!`);
        }

        this.allCustomers.push(customer);

        return customer;
    }

    depositMoney(personalId, amount) {
        let customer = this._validateCustomer(personalId);

        if (customer['totalMoney'] === undefined) {
            customer['totalMoney'] = 0;
        }

        customer['totalMoney'] += amount;

        if (customer['transactionInfos'] === undefined) {
            customer['transactionInfos'] = [];
        }

        customer['transactionInfos'].unshift(`${customer['transactionInfos'].length + 1}. ${customer.firstName} ${customer.lastName} made deposit of ${amount}$!`)

        return `${customer.totalMoney}$`;
    }

    withdrawMoney(personalId, amount) {
        let customer = this._validateCustomer(personalId);

        if (customer['totalMoney'] === undefined) {
            customer['totalMoney'] = 0;
        }

        if (customer['totalMoney'] - amount < 0) {
            throw new Error(`${customer.firstName} ${customer.lastName} does not have enough money to withdraw that amount!`);
        }

        customer['totalMoney'] -= amount;

        if (customer['transactionInfos'] === undefined) {
            customer['transactionInfos'] = [];
        }

        customer['transactionInfos'].unshift(`${customer['transactionInfos'].length + 1}. ${customer.firstName} ${customer.lastName} withdrew ${amount}$!`)

        return `${customer.totalMoney}$`;
    }

    customerInfo(personalId) {
        let customer = this._validateCustomer(personalId);
        let result = [];
        result.push(`Bank name: ${this._bankName}`);
        result.push(`Customer name: ${customer.firstName} ${customer.lastName}`);
        result.push(`Customer ID: ${customer.personalId}`);
        result.push(`Total Money: ${customer.totalMoney}$`);
        result.push(`Transactions:`);
        if (customer['transactionInfos']) {
            customer['transactionInfos']
                .forEach(info => {
                    result
                        .push(info);
                });
        }

        return result.join('\n');
    }

    _validateCustomer(id) {
        let customer = this
            .allCustomers
            .find(c => c.personalId === id);

        if (!customer) {
            throw new Error(`We have no customer with this ID!`);
        }

        return customer;
    }
}

//zero test 1
let name = 'SoftUni Bank';
let bank = new Bank(name);

let customer1 = bank.newCustomer({ firstName: 'Svetlin', lastName: 'Nakov', personalId: 1111111 });
console.log(bank.depositMoney(1111111, 1000000));
console.log(bank.depositMoney(1111111, 1000000));
console.log(bank.depositMoney(1111111, 1000000));
console.log(bank.depositMoney(1111111, 1000000));
console.log(bank.depositMoney(1111111, 1000000));
console.log(bank.depositMoney(1111111, 1000000));
console.log(bank.withdrawMoney(1111111, 1000000));
console.log(bank.withdrawMoney(1111111, 1000000));
console.log(bank.withdrawMoney(1111111, 1000000));
console.log(bank.withdrawMoney(1111111, 1000000));

console.log(bank.customerInfo(1111111));