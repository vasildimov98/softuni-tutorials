function showCookingNumber(cookingInfo) {
    let cookNumber = cookingInfo.shift();

    for (let i = 0; i < cookingInfo.length; i++) {
        let currOperation = cookingInfo[i];
        
        switch (currOperation) {
            case 'chop':
                cookNumber /= 2;
            break;
            case 'dice':
                cookNumber = Math.sqrt(cookNumber);
            break;
            case 'spice':
                cookNumber++;
            break;
            case 'bake':
                cookNumber *= 3;
            break;
            case 'fillet':
                cookNumber *= 0.8;
            break;
        } 

        console.log(cookNumber)
    }
}

showCookingNumber(['32', 'chop', 'chop', 'chop', 'chop', 'chop']);
showCookingNumber(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);