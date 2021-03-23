namespace SUS.HTTP
{
    public enum HttpStatusCode
    {
        Ok = 200,
        MovedPermanently = 301,
        Found = 302,
        TemporaryRedirect = 307,
        BadRequest = 400,
        NotFound = 404,
        InternalServerError = 500
    }
}
