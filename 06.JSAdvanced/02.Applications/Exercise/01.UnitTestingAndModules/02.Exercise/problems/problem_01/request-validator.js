function validateHTTPRequest(request) {
    let { method, uri, version, message } = request;

    let validMethods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    let validURI = /^[*]$|^[A-Za-z0-9.]+$/g;
    let validVersion = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    let validMsg = /^[^<>\\&'"]*$/g;

    if (!validMethods.includes(method))
        _throwNewError('Method');

    if (!validURI.test(uri))
        _throwNewError('URI');

    if (!validVersion.includes(version))
        _throwNewError('Version');

    if (!validMsg.test(message))
        _throwNewError('Message');

    return request;

    function _throwNewError(invalidProperty) {
        throw new Error(`Invalid request header: Invalid ${invalidProperty}`);
    }
}

try {
    let result = validateHTTPRequest({
        method: 'POST',
        uri: 'home.bash',
        message: 'rm -rf /*'
    }
    );

    console.log(result);
} catch (error) {
    console.log(error.message);
}