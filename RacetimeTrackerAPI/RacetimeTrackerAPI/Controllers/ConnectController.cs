using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RacetimeTrackerAPI.Context;
using RacetimeTrackerAPI.Controllers.Viewmodels;
using RacetimeTrackerAPI.Entities;
using RacetimeTrackerAPI.Services;

namespace RacetimeTrackerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConnectController : ControllerBase
{
    private readonly PasswordHashingService _passwordHashingService;
    private readonly UserService _userService;

    public ConnectController(PasswordHashingService passwordHashingService, UserService userService)
    {
        _passwordHashingService = passwordHashingService;
        _userService = userService;
    }
    [HttpPost]
    public ActionResult Post([FromBody] UserVM userVm)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        DTOs.User? user = _userService.GetUserByName(userVm.Name);
        if (user == null)
        {
            return BadRequest("User not found");
        }
        bool passwordValid = _passwordHashingService.VerifyHashedPassword(userVm.ToDTO(), user.PasswordHash, userVm.Password);

        if (!passwordValid)
        {
            return BadRequest("Invalid password");
        }

        return this.Accepted();
    }
}