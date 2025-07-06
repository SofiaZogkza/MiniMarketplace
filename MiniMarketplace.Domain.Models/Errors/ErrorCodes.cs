namespace MiniMarketplace.Domain.Models.Errors;

public static class ErrorCodes
{
    public const string InvalidGuid = "INVALID_GUID";
    public const string InvalidRequest = "INVALID_REQUEST";
    public const string RegistrationFailed = "USER_REGISTRATION_FAILED";
    public const string UserNotFound = "USER_NOT_FOUND";
}