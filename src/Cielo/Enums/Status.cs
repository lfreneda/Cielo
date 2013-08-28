namespace Cielo.Enums
{
    public enum Status
    {
        Default = -1,
        Created = 0,
        InProgress = 1,
        Authenticated = 2,
        NotAuthenticated = 3,
        Authorized = 4,
        NotAuthorized = 5,
        Success = 6,
        Canceled = 9,
        AuthenticationProgress = 10,
        CancellationProgress = 12
    }
}