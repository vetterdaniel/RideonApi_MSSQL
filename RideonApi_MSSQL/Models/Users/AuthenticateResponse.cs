namespace RideonApi_MSSQL.Models.Users;

using RideonApi_MSSQL.Entities;

public class AuthenticateResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public Role Role { get; set; }
    public String Token { get; set; }
    public DateTime? Expires { get; set; }

    public AuthenticateResponse(User user, Token token)
    {
        Id = user.Id;
        FirstName = user.FirstName;
        LastName = user.LastName;
        Username = user.Username;
        Role = user.Role;
        Token = token.TokenString;
        Expires = token.Expiration;
        
    }
}