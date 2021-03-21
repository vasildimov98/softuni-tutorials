function redirectRoute(fullUrl, isBack) {
    const [url, ...params] = fullUrl
        .split('/')
        .filter(p => p != "");

    var routeFunc = routes[`/${url || ''}`];

    if (!routeFunc) return;

    routes[`/${url || ''}`](...params);

    if (fullUrl == '/')
        fullUrl = '/home';

    if (!isBack)
        history.pushState({}, '', fullUrl)
}