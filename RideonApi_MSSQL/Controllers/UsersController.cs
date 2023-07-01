namespace RideonApi_MSSQL.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Data;
using RideonApi_MSSQL.Authorization;
using RideonApi_MSSQL.Entities;
using RideonApi_MSSQL.Models.Users;
using RideonApi_MSSQL.Services;
using Microsoft.EntityFrameworkCore;
using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.AspNetCore.Identity;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost("[action]")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);
        return Ok(response);
    }

    [Authorize(Role.Admin)]
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }


    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {      
        var currentUser = (User)HttpContext.Items["User"];
        if (id != currentUser.Id && currentUser.Role > Role.Contributer)
            return Unauthorized(new { message = "Unauthorized" });

        var user = _userService.GetById(id);
        return Ok(user);
    }

    [AllowAnonymous]
    [HttpPost("[action]")]
    public ActionResult<User> CreateUser(CreateUserrequest user)
    {        
        _userService.CreateUser(user);
        return Ok(user);
    }

    [HttpPut("[action]/{id:int}")]
    public ActionResult<User> UpdateUser(int id, CreateUserrequest createuser)
    {
        var currentUser = (User)HttpContext.Items["User"];

        if (id != currentUser.Id && currentUser.Role > Role.Contributer)
            return Unauthorized(new { message = "Unauthorized" });

        var user = _userService.GetById(id);
        
        if (user.Role < currentUser.Role)
            return Unauthorized(new { message = "Unauthorized" });

        user = _userService.UpdateUser(id, createuser);
        return Ok(user);
    }

    [Authorize(Role.Admin)]
    [HttpPatch("[action]/{id:int}")]
    public ActionResult<User> ChangeUserLevel(int id, Role role)
    {
        User user = _userService.ChangeUserLevel(id, role);
        return Ok(user);
    }

    [HttpDelete("[action]/{id:int}")]
    public ActionResult DeleteUser(int id)
    {
        var currentUser = (User)HttpContext.Items["User"];

        if (id != currentUser.Id && currentUser.Role > Role.Contributer)
            return Unauthorized(new { message = "Unauthorized" });        

        var user = _userService.GetById(id);

        if (user.Role < currentUser.Role)
            return Unauthorized(new { message = "Unauthorized" });

        _userService.DeleteUser(id);

        return Ok("User deleted");

    }

}
