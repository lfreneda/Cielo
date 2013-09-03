namespace Cielo.Enums
{
    public enum AuthorizationType
    {
        DoNotAuthorize = 0,
        AuthorizeIfAuthenticated = 1,
        AuthorizeAuthenticatedOrNot = 2,
        AuthorizeSkippingAuthentication = 3,
        RecurringTransaction = 4
    }
}