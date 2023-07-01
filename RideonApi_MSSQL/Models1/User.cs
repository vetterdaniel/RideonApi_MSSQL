using System;
using System.Collections.Generic;

namespace RideonApi_MSSQL.Models1;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Username { get; set; } = null!;

    public int Role { get; set; }

    public string PasswordHash { get; set; } = null!;
}
