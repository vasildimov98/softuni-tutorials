function createRoute(path, callback) {
    routes[path] = callback;
}

function redirectRoute(fullUrl, isNotState) {
    if (fullUrl == '/') fullUrl = '/home';

    const [url, id] = fullUrl.split('/').filter(x => x != '');

    var renderer = routes[`/${url}`];

    if (!renderer) return;

    if (!isNotState)
        history.pushState({}, '', fullUrl);

    renderer(id);
}