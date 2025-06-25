using MiniMarketplace.Domain.Models.Dtos;

namespace MiniMarketplace.Tests.Builders;

public sealed class UserCreateRequestBuilder
{
    private string _username = "Sofia";
    private string _password = "123456";
    private string _email = "soft@software.com";
    private string _firstname = "Sofia";
    private string _lastname = "Delacosta";
    private DateTime _createdAt = DateTime.Now;

    public UserCreateRequestBuilder WithUsername(string username)
    {
        _username = username;
        return this;
    }
    
    public UserCreateRequestBuilder WithInvalidUsername()
    {
        _username = "a"; // Violates min length
        return this;
    }

    public UserCreateRequestBuilder WithPassword(string password)
    {
        _password = password;
        return this;
    }
    
    public UserCreateRequestBuilder WithWeakPassword()
    {
        _password = "123"; // Violates min length
        return this;
    }

    public UserCreateRequestBuilder WithEmail(string email)
    {
        _email = email;
        return this;
    }
    
    public UserCreateRequestBuilder WithInvalidEmail()
    {
        _email = "not-an-email";
        return this;
    }

    public UserCreateRequestBuilder WithFirstName(string firstname)
    {
        _firstname = firstname;
        return this;
    }
    
    public UserCreateRequestBuilder WithEmptyFirstName()
    {
        _firstname = string.Empty;
        return this;
    }

    public UserCreateRequestBuilder WithLastName(string lastname)
    {
        _lastname = lastname;
        return this;
    }
    
    public UserCreateRequestBuilder WithEmptyLastName()
    {
        _lastname = string.Empty;
        return this;
    }

    public UserCreateRequest Build() => new()
    {
        Username = _username,
        PasswordHash = _password,
        Email = _email,
        FirstName = _firstname,
        LastName = _lastname,
        CreatedAt = _createdAt,
    };
}