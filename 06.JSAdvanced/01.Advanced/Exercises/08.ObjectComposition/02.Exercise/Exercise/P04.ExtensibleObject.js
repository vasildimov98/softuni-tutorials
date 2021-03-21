function getExtensibleObject() {
    let obj = {
        extend(template) {
            Object
                .keys(template)
                .forEach(k => {
                    let prototypeOfThisObj = Object.getPrototypeOf(obj);
                    if (typeof template[k] == 'function') {
                        prototypeOfThisObj[k] = template[k];
                    } else {
                        this[k] = template[k];
                    }
                });
        },
    };

    return obj;
}

let template =  {
    extensionMethod: () => 'Hi I extended your object',
    extensionProperty: 'someString',
    color: 'blue',
};

let extensibleObject = getExtensibleObject();

extensibleObject.extend(template);

console.log(extensibleObject);