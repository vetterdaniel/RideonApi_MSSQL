namespace RideonApi_MSSQL.Models.Users;

using System.ComponentModel.DataAnnotations;

public class CreateUserrequest
{
    [Required]
    public string Username { get; set; }
   
    [Required]
    public string Password { get; set; }
    
    public string Firstname { get; set; }

    public string Lastname { get; set; }
}

