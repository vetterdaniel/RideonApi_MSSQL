namespace RideonApi_MSSQL.Services;
using BCrypt.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RideonApi_MSSQL.Authorization;
using RideonApi_MSSQL.Entities;
using RideonApi_MSSQL.Helpers;
using RideonApi_MSSQL.Models.Users;
using BCryptNet = BCrypt.Net.BCrypt;


public interface IUserService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<User> GetAll();
    User GetById(int id);
    User CreateUser(CreateUserrequest createUser);
    User UpdateUser(int id, CreateUserrequest createuser);
    User ChangeUserLevel(int id, Role role);
    void DeleteUser(int id);
}

public class UserService : IUserService
{
    private DataContext _context;
    private IJwtUtils _jwtUtils;
    private readonly AppSettings _appSettings;

    public UserService(
        DataContext context,
        IJwtUtils jwtUtils,
        IOptions<AppSettings> appSettings)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _appSettings = appSettings.Value;
    }


    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        var user = _context.Users.SingleOrDefault(x => x.Username == model.Username);

        // validate
        if (user == null || !BCrypt.Verify(model.Password, user.PasswordHash))
            throw new AppException("Username or password is incorrect");

        // authentication successful so generate jwt token
        var jwtToken = _jwtUtils.GenerateJwtToken(user);

        return new AuthenticateResponse(user, jwtToken);
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users;
    }

    public User GetById(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }

    public User CreateUser(CreateUserrequest createUser)
    {
        if (_context.Users.SingleOrDefault(x => x.Username == createUser.Username) != null) throw new AppException("Username already exists");

        User user = new User { FirstName = createUser.Firstname, LastName = createUser.Lastname, Username = createUser.Username, PasswordHash = BCryptNet.HashPassword(createUser.Password), Role = Role.User };

            
        _context.Users.Add(user);            
        _context.SaveChanges();

        return user;
    }

    public User UpdateUser(int id, CreateUserrequest createuser)
    {
        var user = _context.Users.Find(id);
        if (user == null) throw new KeyNotFoundException("User not found");

        user.Username = createuser.Username;
        user.PasswordHash = BCryptNet.HashPassword(createuser.Password);
        user.FirstName = createuser.Firstname;
        user.LastName = createuser.Lastname;

        _context.Entry(user).State = EntityState.Modified;
        _context.SaveChanges();

        return user;
     
    }

    public User ChangeUserLevel(int id, Role role)
    {
        var user = _context.Users.Find(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        
        user.Role = role;

        _context.Entry(user).State = EntityState.Modified;
        _context.SaveChanges();

        return user;
    }

    public void DeleteUser(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        _context.Users.Remove(user);
        _context.SaveChanges();
    }
}
