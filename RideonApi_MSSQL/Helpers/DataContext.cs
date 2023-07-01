namespace RideonApi_MSSQL.Helpers;

using Microsoft.EntityFrameworkCore;
using RideonApi_MSSQL.Entities;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }

    private readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(Configuration.GetConnectionString("ConStr"));
    }
}
