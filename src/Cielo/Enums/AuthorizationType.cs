namespace Cielo.Enums
{
    public enum AuthorizationType
    {
        DoNotAuthorize = 0,
        AuthorizeIfAuthenticated = 1,
        AuthorizeAuthenticatedOrNot = 2,
        AuthorizePassByAuthentication = 3,
        RecurringTransaction = 4
    }
}