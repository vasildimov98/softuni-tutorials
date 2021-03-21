class VeterinaryClinic {
    constructor(clinicName, capacity) {
        this.clinicName = clinicName;
        this.capacity = capacity;
        this.clients = [];
        this.currentWorkload = 0;
        this.totalProfit = 0;
    }

    newCustomer(ownerName, petName, kind, procedures) {
        if (this.currentWorkload + 1 > this.capacity) {
            throw new Error('Sorry, we are not able to accept more patients!');
        }

        let currOwner = this.clients
            .find(o => o.name == ownerName);

        if (!currOwner) {
            currOwner = {
                name: ownerName,
                pets: [],
            };

            this.clients.push(currOwner);
        }

        let currPet = currOwner
            .pets
            .find(p => p.name == petName);

        if (!currPet) {
            currPet = {
                name: petName,
                kind: kind.toLowerCase(),
                procedures: [],
            };

            currOwner.pets.push(currPet);
        }

        if (currPet.procedures.length > 0) {
            throw new Error(`This pet is already registered under ${currOwner.name} name! ${currPet.name} is on our lists, waiting for ${currPet.procedures.join(', ')}.`);
        }

        currPet.procedures = procedures;

        this.currentWorkload++;
        return `Welcome ${petName}!`;
    }

    onLeaving(ownerName, petName) {
        let currOwner = this.clients
            .find(o => o.name == ownerName);

        if (!currOwner) {
            throw new Error('Sorry, there is no such client!');
        }

        let currPet = currOwner
            .pets
            .find(p => p.name == petName);

        if (!currPet
            || currPet.procedures.length == 0) {
            throw new Error(`Sorry, there are no procedures for ${petName}!`);
        }

        let profit = currPet
            .procedures
            .length * 500.00;
        currPet.procedures = [];

        this.totalProfit += profit;
        this.currentWorkload--;

        return `Goodbye ${currPet.name}. Stay safe!`;
    }

    toString() {
        let clinicInfo = [];
        let bussyness = Math.floor((this.currentWorkload / this.capacity) * 100);

        clinicInfo.push(`${this.clinicName} is ${bussyness}% busy today!`);
        clinicInfo.push(`Total profit: ${this.totalProfit.toFixed(2)}$`);
        this
            .clients
            .sort((cl1, cl2) => cl1.name.localeCompare(cl2.name))
            .forEach(cl => {
                clinicInfo
                    .push(`${cl.name} with:`);
                cl
                    .pets
                    .sort((p1, p2) => p1.name.localeCompare(p2.name))
                    .forEach(p => {
                        clinicInfo
                            .push(`---${p.name} - a ${p.kind} that needs: ${p.procedures.join(', ')}`);
                    });
            });

        return clinicInfo
            .join('\n');
    }
}


//Zero test 2 - same + toString
let clinic = new VeterinaryClinic('SoftCare', 5);
clinic.newCustomer('Jim Jones', 'Tom', 'Cat', ['A154B', '2C32B', '12CDB']);
clinic.newCustomer('Anna Morgan', 'Max', 'Dog', ['SK456', 'DFG45', 'KS456'])
clinic.newCustomer('Jim Jones', 'Tiny', 'Cat', ['A154B'])
clinic.newCustomer('Jim Jones', 'Sarah', 'Cat', ['A154B'])
clinic.newCustomer('Jim Jones', 'Pesho', 'Cat', ['A154B'])
//clinic.onLeaving('Jim Jones', 'Tom');
//clinic.onLeaving('Jim Jones', 'Tiny');
//clinic.onLeaving('Anna Morgan', 'Max');
//clinic.onLeaving('Anna organ', 'Sarah');

let string = `SoftCare is 20% busy today!
Total profit: 500.00$
Anna Morgan with:
---Max - a dog that needs: SK456, DFG45, KS456
Jim Jones with:
---Tiny - a cat that needs: 
---Tom - a cat that needs: A154B, 2C32B, 12CDB`;
console.log(clinic.toString());//.to.be.equal(string, 'Incorrect output');
