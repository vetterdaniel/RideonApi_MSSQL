namespace RideonApi_MSSQL.Entities;

public class Token
{
    public string TokenString;
    public DateTime? Expiration;

    public Token(string tokenString, DateTime? expiration)
    {
        TokenString = tokenString;
        Expiration = expiration;
    }
}
