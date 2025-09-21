using MiniMarketplace.Domain.Models.Dtos;

namespace MiniMarketplace.Tests.Builders;

public sealed class UserUpdateRequestBuilder
{
    private string _username = "BirdOfParadise";
    private string _password = "BirdOfParadise68";
    private string _email = "mary.mtd@gmail.com";
    private string _firstname = "Mary";
    private string _lastname = "Mtd";

    public UserUpdateRequestBuilder WithUsername(string username)
    {
        _username = username;
        return this;
    }
    public UserUpdateRequestBuilder WithInvalidUsername(string invalidUsername)
    {
        _username = "a"; // Violates min length
        return this;
    }
    
     public UserUpdateRequestBuilder WithPassword(string password)
    {
        _password = password;
        return this;
    }
    
    public UserUpdateRequestBuilder WithWeakPassword()
    {
        _password = "123"; // Violates min length
        return this;
    }

    public UserUpdateRequestBuilder WithEmail(string email)
    {
        _email = email;
        return this;
    }
    
    public UserUpdateRequestBuilder WithInvalidEmail()
    {
        _email = "not-an-email";
        return this;
    }

    public UserUpdateRequestBuilder WithFirstName(string firstname)
    {
        _firstname = firstname;
        return this;
    }
    
    public UserUpdateRequestBuilder WithEmptyFirstName()
    {
        _firstname = string.Empty;
        return this;
    }

    public UserUpdateRequestBuilder WithLastName(string lastname)
    {
        _lastname = lastname;
        return this;
    }
    
    public UserUpdateRequestBuilder WithEmptyLastName()
    {
        _lastname = string.Empty;
        return this;
    }

    public UserUpdateRequest Build() => new()
    {
        Username = _username,
        PasswordHash = _password,
        Email = _email,
        FirstName = _firstname,
        LastName = _lastname
    };
}