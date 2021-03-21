function getSortedList() {
    let sortedList = [];

    return {
        size: 0,
        add(elemenent) {
            sortedList
                .push(elemenent);

            sortedList.sort((a, b) => a - b);

            this.size++;
        },
        remove(index) {
            if (index >= 0 && index < sortedList.length) {
                sortedList
                    .splice(index, 1);

                this.size--;
            }
        },
        get(index) {
            if (index >= 0 && index < sortedList.length) {
                return sortedList[index];
            }
        },
    };
}

let sortedList = getSortedList();

sortedList.add(112);
sortedList.add(56);
sortedList.add(23);
sortedList.add(2);
sortedList.add(73);
sortedList.add(41);

console.log(sortedList.get(0));
console.log(sortedList.get(1));
console.log(sortedList.get(2));
console.log(sortedList.get(3));
console.log(sortedList.get(4));
console.log(sortedList.get(5));

sortedList.remove(2);
sortedList.remove(1);
sortedList.remove(0);

console.log(sortedList.get(0));
console.log(sortedList.get(1));
console.log(sortedList.get(2));

/*Implement a collection, which keeps a list of numbers, sorted in ascending order. It must support the following functionality:
•	add(elemenent) - adds a new element to the collection
•	remove(index) - removes the element at position index
•	get(index) - returns the value of the element at position index
•	size - number of elements stored in the collection
The correct order of the element must be kept at all times, regardless of which operation is called.
Removing and retrieving elements shouldn’t work if the provided index points outside the length of the collection (either throw an error or do nothing). Note the size of the collection is NOT a function. Write your code such that the first function in your solution returns an instance of your Sorted List.
*/