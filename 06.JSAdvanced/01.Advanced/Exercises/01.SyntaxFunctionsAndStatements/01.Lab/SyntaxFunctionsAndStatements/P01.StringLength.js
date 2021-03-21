function sumOfLengthOfString(str1, str2, str3) {
    let stringLength = str1.length + str2.length + str3.length;

    let avgSum = Math.floor(stringLength / 3);
    
    console.log(stringLength);
    console.log(avgSum);
}

sumOfLengthOfString('pasta', '5', '22.3');