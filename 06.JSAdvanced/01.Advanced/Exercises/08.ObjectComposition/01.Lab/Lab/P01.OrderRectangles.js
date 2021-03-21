function createRectangles(rectanglesArgs) {
    return rectanglesArgs
        .map(([width, height]) => {
            return {
                width,
                height,
                area() {
                    return this.width * this.height;
                },
                compareTo(otherRect) {
                    let result = otherRect.area() - this.area(); 

                    if (!result) {
                        result = otherRect.width - this.width;
                    }
                  
                    return result;
                },
            };
        }).sort((firstRect, secondRect) => {
            return firstRect.compareTo(secondRect);
        });
}

// console.log(createRectangles([[10, 5], [5, 12]]));
// console.log(createRectangles([[10, 5], [3, 20], [5, 12]]));

let sizes = [[1, 20], [20, 1], [5, 3], [5, 3]];

let sortedRectangles = createRectangles(sizes);

console.log(sortedRectangles[0].compareTo(sortedRectangles[1]));
console.log(sortedRectangles[1].compareTo(sortedRectangles[0]));
console.log(sortedRectangles[1].compareTo(sortedRectangles[2]));
console.log(sortedRectangles[2].compareTo(sortedRectangles[1]));
console.log(sortedRectangles[2].compareTo(sortedRectangles[3]));
console.log(sortedRectangles[2].compareTo(sortedRectangles[2]));