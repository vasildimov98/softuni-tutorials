function fillTheOrbit(orbitInfo) {
    let [width, height, r, c] = orbitInfo;

    let matrix = [];   
    for (let row = 0; row < width; row++) {
        matrix[row] = [];
        for (let col = 0; col < height; col++) {
            matrix[row][col]
             = Math.max(Math.abs(r - row),Math.abs(c - col)) + 1;
        }
    }

    matrix.forEach(element => {
        console.log(element.join(' '));
    });
}

fillTheOrbit([4, 4, 0, 0]);
fillTheOrbit([5, 5, 2, 2]);
fillTheOrbit([3, 3, 2, 2]);