class Circle {
    constructor(radius) { this.radius = radius; }
    get diameter() { return 2 * this.radius; }
    set diameter(diameter) {
        this.radius = diameter / 2;
    }
    get area() {
        return Math.PI * this.radius * this.radius;
    }
}

let circle = new Circle(2);

console.log(circle.radius);

circle.radius = 7;

console.log(circle.radius);

console.log(circle.area);

circle.area = 13414;

console.log(circle.area);