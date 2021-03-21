function showReareachedArr(numbers) {
    let newArr = [];

    numbers.forEach((el) => {
        if (el < 0) {
            newArr.unshift(el);
        } else {
            newArr.push(el);
        }
    });

    newArr.forEach((el) => console.log(el));
}

showReareachedArr([7, -2, 8, 9]);
showReareachedArr([3, -2, 0, -1]);