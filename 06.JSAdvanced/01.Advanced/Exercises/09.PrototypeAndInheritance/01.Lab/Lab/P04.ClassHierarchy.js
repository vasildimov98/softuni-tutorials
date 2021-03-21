function getTheFigures() {
    class Figure {
        constructor(unit) {
            this.unit = unit ? unit : 'cm';
        }
    
        get area() {
            const message = 'Area is not implemented!';
            throw new Error(message);
        }
    
        changeUnits(newUnit) {
            this.unit = newUnit;
        }
    
        toString() {
            return `Figures units: ${this.unit} Area: ${this.area}`;
        }
    
        changeValueMetric(value) {
            return this.unit == 'm' ?
                value / 100 : this.unit == 'mm' ?
                    value * 10 : value;
        }
    }
    
    
    class Circle extends Figure {
        constructor(radius, unit) {
            super(unit);
            this.radius = radius;
        }
    
        get area() {
            let newRadius = this.changeValueMetric(this.radius);
            return Math.PI * Math.pow(newRadius, 2);
        }
    
        toString() {
            let newRadius = this.changeValueMetric(this.radius);
            return `${super.toString()} - radius: ${newRadius}`;
        }
    }
    
    class Rectangle extends Figure {
        constructor(width, height, unit) {
            super(unit);
            this.width = width;
            this.height = height;
        }
    
        get area() {
            let newWidth = this.changeValueMetric(this.width);
            let newHeight = this.changeValueMetric(this.height);
            return newWidth * newHeight;
        }
    
        toString() {
            let newWidth = this.changeValueMetric(this.width);
            let newHeight = this.changeValueMetric(this.height);
            return `${super.toString()} - width: ${newWidth}, height: ${newHeight}`;
        }
    }

    return {
        Figure,
        Circle,
        Rectangle,
    };
}

let c = new Circle(5);
console.log(c.area); // 78.53981633974483
console.log(c.toString()); // Figures units: cm Area: 78.53981633974483 - radius: 5

let r = new Rectangle(3, 4, 'mm');
console.log(r.area); // 1200 
console.log(r.toString()); //Figures units: mm Area: 1200 - width: 30, height: 40

r.changeUnits('cm');
console.log(r.area); // 12
console.log(r.toString()); // Figures units: cm Area: 12 - width: 3, height: 4

c.changeUnits('mm');
console.log(c.area); // 7853.981633974483
console.log(c.toString()) // Figures units: mm Area: 7853.981633974483 - radius: 50