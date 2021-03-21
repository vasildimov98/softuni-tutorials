function loadLink(win, fuc) {
    return 'Hi'
}

function hell(win) {
    return function() {
        loadLink(win, function() {
            loadLink(win, function() {
                console.log('Hi');
            })
        })
    }
}

hell()()();