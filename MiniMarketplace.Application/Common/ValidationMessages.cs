namespace MiniMarketplace.Application.Common;

public class ValidationMessages
{
    public const string Required = "Is Required.";
    public const string Invalid = "Is Invalid.";
    public const string MinLength = "Must be at least {MinLength} characters.";
    
    public const string MinLength3 = "Must be at least 3 characters.";
    public const string MinLength6 = "Must be at least 6 characters.";
    
    public static string MinLengthMessage(int minLength) =>
        MinLength.Replace("{MinLength}", minLength.ToString());
}