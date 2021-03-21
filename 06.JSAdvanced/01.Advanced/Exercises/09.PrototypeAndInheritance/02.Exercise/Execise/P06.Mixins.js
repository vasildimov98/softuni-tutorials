function createMixins() {
    function computerQualityMixin(classToExtend) {
        let proto = classToExtend.prototype;
        proto.getQuality = function () {
            return (this.processorSpeed + this.ram + this.hardDiskSpace) / 3
        };

        proto.isFast = function () {
            return this.processorSpeed > (this.ram / 4);
        };

        proto.isRoomy = function () {
            return this.hardDiskSpace > Math.floor(this.ram * this.processorSpeed);
        };
    }

    function styleMixin(classToExtend) {
        let proto = classToExtend.prototype;
        proto.isFullSet = function () {
            let isSameKeyboardManufacturer = this.manufacturer === this.keyboard.manufacturer;
            let isSameMonitorManufacturer = this.manufacturer === this.monitor.manufacturer;
            return isSameKeyboardManufacturer && isSameMonitorManufacturer;
        };

        proto.isClassy = function () {
            return this.battery.expectedLife >= 3
                && (this.color == 'Silver' || this.color == 'Black')
                && this.weight < 3;
        };
    }

    return {
        computerQualityMixin,
        styleMixin,
    };
}

class Manufacturable {
    constructor(manufacturer) {
        if (new.target === Manufacturable) {
            throw new Error('Cannot instantiate an abstract class!');
        }
        this.manufacturer = manufacturer;
    }
}

class Keyboard extends Manufacturable {
    constructor(manufacturer, responseTime) {
        super(manufacturer);
        this.responseTime = responseTime;
    }
}

class Monitor extends Manufacturable {
    constructor(manufacturer, width, height) {
        super(manufacturer);
        this.width = width;
        this.height = height;
    }
}

class Battery extends Manufacturable {
    constructor(manufacturer, expectedLife) {
        super(manufacturer);
        this.expectedLife = expectedLife;
    }
}

class Computer extends Manufacturable {
    constructor(manufacturer, processorSpeed, ram, hardDiskSpace) {
        if (new.target === Computer) {
            throw new Error('Cannot instantiate an abstract class!');
        }
        super(manufacturer);
        this.manufacturer = manufacturer;
        this.processorSpeed = processorSpeed;
        this.ram = ram;
        this.hardDiskSpace = hardDiskSpace;
    }
}

class Laptop extends Computer {
    constructor(manufacturer, processorSpeed, ram, hardDiskSpace, weight, color, battery) {
        super(manufacturer, processorSpeed, ram, hardDiskSpace);
        this.weight = weight;
        this.color = color;
        this.battery = battery;
    }

    get battery() {
        return this._battery;
    }

    set battery(value) {
        if (!(value instanceof Battery)) {
            throw new TypeError('Value should be instance of Battery!');
        }

        this._battery = value;
    }
}

class Desktop extends Computer {
    constructor(manufacturer, processorSpeed, ram, hardDiskSpace, keyboard, monitor) {
        super(manufacturer, processorSpeed, ram, hardDiskSpace);
        this.keyboard = keyboard;
        this.monitor = monitor;
    }

    get keyboard() {
        return this._keyboard;
    }

    set keyboard(value) {
        if (!(value instanceof Keyboard)) {
            throw new TypeError('Value should be instance of Keyboard!');
        }

        this._keyboard = value;
    }

    get monitor() {
        return this._monitor;
    }

    set monitor(value) {
        if (!(value instanceof Monitor)) {
            throw new TypeError('Value should be instance of Monitor!');
        }

        this._monitor = value;
    }
}

let mixins = createMixins();
let computerQualityMixin = mixins.computerQualityMixin;
let styleMixin = mixins.styleMixin;

computerQualityMixin(Desktop);
styleMixin(Desktop);
computerQualityMixin(Laptop);
styleMixin(Laptop);

let keyboard = new Keyboard('Logitech',70);
let keyboard2 = new Keyboard('A-4',70);
let monitor = new Monitor('Logitech',28,18);
let battery = new Battery('Energy',3);
let laptop = new Laptop("Hewlett Packard",2.4,4,0.5,2.99,"Silver",battery);
let laptop2 = new Laptop("Hewlett Packard",2.4,4,12,2.99,"Silver",battery);
let desktop = new Desktop("Logitech",3.3,8,1,keyboard,monitor);
let desktop2 = new Desktop("Logitech",1.3,8,10,keyboard2,monitor);

console.log(desktop.isFullSet);//.to.exist;
console.log(laptop.isFullSet);//.to.exist;

console.log(desktop.isFullSet());//.to.be.true;
console.log(desktop2.isFullSet());//.to.be.false;

;

// let laptop = new Laptop('TestManufacturer', 12, 16, 12, 2, 'Black', new Battery('TestManufacturer', 10));
// let desktop = new Desktop('TestManufacturer', 12, 16, 12, new Keyboard('TestManufacturer', 1), new Monitor('TestManufacturer', 12, 2));

// let mixinFuncs = createMixins();

// mixinFuncs.computerQualityMixin(desktop);
// mixinFuncs.styleMixin(laptop);

// console.log(laptop.isClassy());
// console.log(desktop.isRoomy());